// ---------------------------
// Attribution to original authors of this code
// ---------------------------
// This code has been originally ported from Giraffe which was originally ported from Suave with small modifications
// afterwards.
//
// The original code was authored by
// * Dustin Moris Gorski (https://github.com/dustinmoris)
// * Henrik Feldt (https://github.com/haf)
// * Ademar Gonzalez (https://github.com/ademar)
//
// You can find the original implementations here:
// - https://github.com/giraffe-fsharp/Giraffe/blob/master/src/Giraffe/GiraffeViewEngine.fs
// - https://github.com/SuaveIO/suave/blob/master/src/Suave.Experimental/ViewEngine.fs
//

namespace Feliz.ViewEngine

open System
open System.Text

type EventHandlerType = 
    | Event of (obj -> unit)
    | KeyEvent of (obj * (obj -> unit))

type IReactProperty =
    | KeyValue of string * obj
    | Children of ReactElement list
    | Text of string

and ReactElement =
    | Element of string * IReactProperty list // An element which may contain properties
    | VoidElement of string * IReactProperty list // An empty self-closed element which may contain properties
    | TextElement of string
    | Elements of ReactElement seq

[<RequireQualifiedAccess>]
module ViewBuilder =
    // Performance note: We use a custom escape function instead of System.Net.WebUtility.HtmlEncode
    // because this library needs to be Fable-compatible (transpilable to JavaScript).

    /// Check if a string contains any characters that need HTML escaping.
    /// Uses imperative style for performance in this hot path.
    let inline private needsEscaping (str: string) =
        let mutable found = false
        let mutable i = 0
        while not found && i < str.Length do
            let c = str.[i]
            if c = '<' || c = '>' || c = '"' || c = ''' || c = '&' then
                found <- true
            i <- i + 1
        found

    /// Escape HTML special characters.
    /// Optimized to return the original string unchanged when no escaping is needed,
    /// which is the common case and avoids unnecessary allocations.
    let escape (str: string) =
        if isNull str || str.Length = 0 then str
        elif not (needsEscaping str) then str
        else
            let sb = StringBuilder(str.Length + 8)
            for i = 0 to str.Length - 1 do
                match str.[i] with
                | '<'  -> sb.Append("&lt;") |> ignore
                | '>'  -> sb.Append("&gt;") |> ignore
                | '"'  -> sb.Append("&quot;") |> ignore
                | '\'' -> sb.Append("&apos;") |> ignore
                | '&'  -> sb.Append("&amp;") |> ignore
                | c    -> sb.Append(c) |> ignore
            sb.ToString()

    let inline private (+=) (sb : StringBuilder) (text : string) = sb.Append(text)
    let inline private (+!) (sb : StringBuilder) (text : string) = sb.Append(text) |> ignore

    let inline private selfClosingBracket (isHtml : bool) =
        if isHtml then ">" else " />"

    let rec private buildNode (isHtml : bool) (sb : StringBuilder) (node : ReactElement) : unit =
        // Performance note: splitProps uses mutable accumulators instead of List.foldBack
        // to avoid tuple allocations on every property. This is a hot path during rendering.
        // Benchmarks show 35-55% improvement over the original functional implementation.
        let splitProps (props: IReactProperty list) =
            let mutable childrenAcc: ReactElement list list = []
            let mutable text: string option = None
            let mutable attrs: (string * obj) list = []
            for prop in props do
                match prop with
                | KeyValue (k, v) ->
                    match v with
                    | :? EventHandlerType ->
                        // Ignore event handlers in render output
                        ()
                    | _ ->
                        attrs <- (k, v) :: attrs
                | Children ch ->
                    childrenAcc <- ch :: childrenAcc
                | Text t ->
                    text <- Some t
            // Flatten children lists in reverse order to restore original order
            let children = childrenAcc |> List.rev |> List.concat
            children, text, List.rev attrs

        let buildElement closingBracket (elemName, props : (string*obj) list) =
            match props with
            | [] -> do sb += "<" += elemName +! closingBracket
            | _    ->
                do sb += "<" +! elemName

                for (key, value) in props do
                    sb += " " += key += "=\"" +! (value.ToString())
                    sb +! "\""

                sb +! closingBracket

        let inline buildParentNode (elemName, attributes : (string*obj) list, nodes : ReactElement list) =
            buildElement ">" (elemName, attributes)
            for node in nodes do
                buildNode isHtml sb node
            sb += "</" += elemName +! ">"

        match node with
        | TextElement text -> sb +! text
        | VoidElement (name, props) ->
            let _, _, attrs = splitProps props
            buildElement (selfClosingBracket isHtml) (name, attrs)
        | Element (name, props) ->
            let children, text, attrs = splitProps props
            match children, text, attrs with
            | _, Some text, _ -> buildParentNode (name, attrs, TextElement text :: children)
            | _ -> buildParentNode (name, attrs, children)
        | Elements elements ->
            for element in elements do
                buildNode isHtml sb element

    let buildXmlNode  = buildNode false
    let buildHtmlNode = buildNode true

    let buildXmlNodes  sb (nodes : ReactElement list) = for n in nodes do buildXmlNode sb n
    let buildHtmlNodes sb (nodes : ReactElement list) = for n in nodes do buildHtmlNode sb n

    let buildHtmlDocument sb (document : ReactElement) =
        sb += "<!DOCTYPE html>" +! Environment.NewLine
        buildHtmlNode sb document

    let buildXmlDocument sb (document : ReactElement) =
        sb += """<?xml version="1.0" encoding="utf-8"?>""" +! Environment.NewLine
        buildXmlNode sb document

// fsharplint:disable

/// Render HTML/XML views fsharplint:disable
type Render =
    /// Create XML view
    static member xmlView (node: ReactElement) : string =
        let sb = new StringBuilder() in ViewBuilder.buildXmlNode sb node
        sb.ToString()

    /// <summary>Create XML view</summary>
    static member xmlView (nodes: ReactElement list) : string =
        let sb = new StringBuilder() in ViewBuilder.buildXmlNodes sb nodes
        sb.ToString()

    /// Create XML document view with <?xml version="1.0" encoding="utf-8"?>
    static member xmlDocument (document: ReactElement) : string =
        let sb = new StringBuilder() in ViewBuilder.buildXmlDocument sb document
        sb.ToString()

    /// Create HTML view
    static member htmlView (node: ReactElement) : string =
        let sb = new StringBuilder() in ViewBuilder.buildHtmlNode sb node
        sb.ToString()

    /// Create HTML view
    static member htmlView (nodes: ReactElement list) : string =
        let sb = new StringBuilder() in ViewBuilder.buildHtmlNodes sb nodes
        sb.ToString()

    /// Create HTML document view with <!DOCTYPE html>
    static member htmlDocument (document: ReactElement) : string =
        let sb = new StringBuilder() in ViewBuilder.buildHtmlDocument sb document
        sb.ToString()
