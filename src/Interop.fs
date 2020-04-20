namespace Feliz.ViewEngine

open System
open Feliz.ViewEngine.Styles

[<AttributeUsage(AttributeTargets.Class)>]
type EraseAttribute () =
    inherit Attribute ()

/// Describes a basic style attribute
// Interop between Feliz React DSL and Giraffe XmlNode.
[<RequireQualifiedAccess>]
module Interop =
    let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) : ReactElement =
        Element (name, [ List.ofSeq children |> Children])

    // let inline reactElementWithChild (name: string) (child: 'a) =
    let inline reactElementWithChild (name: string) (child: 'a) : ReactElement =
        Element (name, [ child.ToString () |> Text ])

    // let inline createElement name (properties: ReactProperty list) : ReactElement =
    let createElement name (props: ReactProperty list) : ReactElement =
         Element (name, props)

    // let mkAttr (key: string) (value: obj) : ReactProperty = unbox (key, value)
    let mkAttr (key: string) (value: 'a) : ReactProperty = KeyValue (key, value.ToString ())

    // let mkStyle (key: string) (value: obj) : IStyleAttribute = unbox (key, value)
    let mkStyle (key: string) (value: obj) : IStyleAttribute = Style (key, value) :> _

type FunctionComponent<'Props> = 'Props -> ReactElement

type React =
    static member functionComponent(name: string, render: 'props -> ReactElement) : FunctionComponent<'props> =
        render
