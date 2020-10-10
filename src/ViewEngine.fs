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

open Fable.React

type IReactProperty =
    | KeyValue of string * obj
    | Children of ReactElement list
    | Text of string


and HtmlElement =
    | Element of string * IReactProperty list // An element which may contain properties
    | VoidElement of string * IReactProperty list // An empty self-closed element which may contain properties
    | TextElement of string
    | Elements of ReactElement seq

    interface ReactElement

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
        let splitProps (props: IReactProperty list) =
            let init = [], None, []
            let folder (prop: IReactProperty) ((children, text, attrs) : ReactElement list * string option * (string*obj) list) =
                match prop with
                | KeyValue (k, v) -> children, text,  (k, v) :: attrs
                | Children ch -> List.append children ch, text, attrs
                | Text text -> children, Some text, attrs
            List.foldBack folder props init

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
            for node in nodes do
                buildNode isHtml sb node
            sb += "</" += elemName +! ">"

        match node :?> HtmlElement with
        | TextElement text -> sb +! text
        | VoidElement (name, props) ->
            let _, _, attrs = splitProps props
            buildElement (selfClosingBracket isHtml) (name, attrs)
        | Element (name, props) ->
            let children, text, attrs = splitProps props
            match children, text, attrs with
            | _, Some text, _ -> buildParentNode (name, attrs, TextElement text :> _ :: children)
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
