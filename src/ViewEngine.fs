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

type ReactProperty =
    | KeyValue of string * obj
    | Children of ReactElement list
    | Text of string

and ReactElement =
    | Element of string * ReactProperty list // An element which contains properties
    | TextElement of string

[<RequireQualifiedAccess>]
module ViewBuilder =
    let getEscapeSequence c =
        match c with
        | '<'  -> "&lt;"
        | '>'  -> "&gt;"
        | '\"' -> "&quot;"
        | '\'' -> "&apos;"
        | '&'  -> "&amp;"
        | ch -> ch.ToString()

    let escape str = String.collect getEscapeSequence str

    let inline private (+=) (sb : StringBuilder) (text : string) = sb.Append(text)
    let inline private (+!) (sb : StringBuilder) (text : string) = sb.Append(text) |> ignore

    let inline private selfClosingBracket (isHtml : bool) =
        if isHtml then ">" else " />"

    let rec private buildNode (isHtml : bool) (sb : StringBuilder) (node : ReactElement) : unit =
        let init = [], None, []
        let splitProps ((children, text, attrs) : ReactElement list * string option * (string*obj) list) (prop: ReactProperty) =
            match prop with
            | KeyValue (k, v) -> children, text,  (k, v) :: attrs
            | Children ch -> List.append children ch, text, attrs
            | Text text -> children, Some text, attrs

        let buildElement closingBracket (elemName, props : (string*obj) list) =
            match props with
            | [] -> do sb += "<" += elemName +! closingBracket
            | _    ->
                do sb += "<" +! elemName

                props
                |> List.iter (fun (key, value) ->
                    sb += " " += key += "=\"" += value.ToString () +! "\"")

                sb +! closingBracket

        let inline buildParentNode (elemName, attributes : (string*obj) list, nodes : ReactElement list) =
            buildElement ">" (elemName, attributes)
            for node in nodes do buildNode isHtml sb node
            sb += "</" += elemName +! ">"

        match node with
        | TextElement text -> sb +! text
        | Element (name, props) ->
            let children, text, attrs = props |> List.fold splitProps init
            match children, text, attrs with
            | [], None, _ -> buildElement (selfClosingBracket isHtml) (name, attrs)
            | _, Some text, _ -> buildParentNode (name, attrs, TextElement text :: children)
            | _ -> buildParentNode (name, attrs, children)

    let buildXmlNode  = buildNode false
    let buildHtmlNode = buildNode true

    let buildXmlNodes  sb (nodes : ReactElement list) = for n in nodes do buildXmlNode sb n
    let buildHtmlNodes sb (nodes : ReactElement list) = for n in nodes do buildHtmlNode sb n

    let buildHtmlDocument sb (document : ReactElement) =
        sb += "<!DOCTYPE html>" +! Environment.NewLine
        buildHtmlNode sb document

/// Render HTML/XML views
type Render =
    // Create XML view
    static member xmlView (node: ReactElement) : string =
        let sb = new StringBuilder() in ViewBuilder.buildXmlNode sb node
        sb.ToString()

    // Create XML view
    static member xmlView (nodes: ReactElement list) : string =
        let sb = new StringBuilder() in ViewBuilder.buildXmlNodes sb nodes
        sb.ToString()

    // Create HTML view
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
