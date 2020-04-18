namespace Feliz.Giraffe

open System
open Giraffe.GiraffeViewEngine

[<AttributeUsage(AttributeTargets.Class)>]
type EraseAttribute () =
    inherit Attribute ()

/// Describes a basic style attribute
type IStyleAttribute = interface end

type StyleAttribute =
    | Style of string * obj
    interface IStyleAttribute

    override x.ToString () =
        let (Style (key, value)) = x
        String.Join(":", key, value)

type XmlAttribute =
    | KeyValue of string * string
    | Children of XmlNode list
    | Text of string

type XmlNode = Giraffe.GiraffeViewEngine.XmlNode

// Interop between Feliz React DSL and Giraffe XmlNode.
[<RequireQualifiedAccess>]
module Interop =
    let private getAttr = function
        | KeyValue (key, value) -> Some (attr key value)
        | _ -> None

    let private getText = function
        | Text string -> Some string
        | _ -> None

    // let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) =
    let inline reactElementWithChildren (name: string) (children: #seq<XmlNode>) =
        List.ofSeq children |> tag name []

    // let inline reactElementWithChild (name: string) (child: 'a) =
    let inline reactElementWithChild (name: string) (child: 'a) =
        tag name [] [ child.ToString () |> str ]

    // let inline createElement name (properties: IReactProperty list) : ReactElement =
    let createElement name (props: XmlAttribute list) : XmlNode =
        let children =
            match List.tryLast props with
            | Some (Children xs) -> xs
            | _ -> []
        let attributes = props |> List.choose getAttr
        let textAttr = props |> List.tryPick getText
        match textAttr with
        | Some text -> tag name attributes [ str text ]
        | None -> tag name attributes children

    let createClosedElement name (props: XmlAttribute list) : XmlNode =
        let attributes = props |> List.choose getAttr
        let textAttr = props |> List.tryPick getText
        match textAttr with
        | Some text -> tag name attributes [ str text ]
        | None -> voidTag name attributes

    // let mkAttr (key: string) (value: obj) : IReactProperty = unbox (key, value)
    let mkAttr (key: string) (value: 'a) : XmlAttribute = KeyValue (key, value.ToString ())

    // let mkStyle (key: string) (value: obj) : IStyleAttribute = unbox (key, value)
    let mkStyle (key: string) (value: obj) : IStyleAttribute = Style (key, value) :> _

type FunctionComponent<'Props> = 'Props -> XmlNode

type React =
    static member functionComponent(name: string, render: 'props -> XmlNode) : FunctionComponent<'props> =
        render
