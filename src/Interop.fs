namespace Feliz.ViewEngine

open System
open Feliz.ViewEngine.Styles

#if FABLE_COMPILER
type EraseAttribute = Fable.Core.EraseAttribute
#else
[<AttributeUsage(AttributeTargets.Class)>]
type EraseAttribute () =
    inherit Attribute ()
#endif

/// Describes a basic style attribute. Interop between Feliz React and ViewEngine DSLs.
[<RequireQualifiedAccess>]
module Interop =
    /// Output a string where the content has been HTML encoded.
    let inline mkText (content : 'a) = content.ToString() |> ViewBuilder.escape |> Text

    let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) : ReactElement =
        Element (name, [ List.ofSeq children |> Children])
    let inline reactElementWithChild (name: string) (child: 'a) : ReactElement =
        Element (name, [ mkText child ])

    let createElement name (props: ReactProperty list) : ReactElement =
        Element (name, props)

    let createVoidElement name (props: ReactProperty list) : ReactElement =
        VoidElement (name, props)

    let inline createRawTextElement (content : string) = TextElement content
    let inline createTextElement (content : string) = ViewBuilder.escape content |> TextElement

    let mkAttr (key: string) (value: obj) : ReactProperty =
        let result =
            match value with
            | :? bool -> value.ToString().ToLower()
            | _ -> value.ToString() |> ViewBuilder.escape
        KeyValue (key, result)

    let mkStyle (key: string) (value: obj) : IStyleAttribute = Style (key, value) :> _

type FunctionComponent<'Props> = 'Props -> ReactElement

// fsharplint:disable

type React =
    static member functionComponent(name: string, render: 'props -> ReactElement) : FunctionComponent<'props> =
        render
