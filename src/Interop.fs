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
    let mkText (content : 'a) = content.ToString () |> ViewBuilder.escape |> Text

    let inline mkChildren (props: #seq<ReactElement>) = props |> List.ofSeq |> Children

    let inline reactElementWithChildren (name: string) (children: #seq<ReactElement>) : ReactElement =
        Element (name, [ mkChildren children ])
    let inline reactElementWithChild (name: string) (child: 'a) : ReactElement =
        Element (name, [ mkText child ])

    let inline createElement name (props: ReactProperty list) : ReactElement =
        Element (name, props)
    let inline createVoidElement name (props: ReactProperty list) : ReactElement =
        VoidElement (name, props)
    let inline createTextElement (content : string) = ViewBuilder.escape content |> TextElement
    let inline createRawTextElement (content : string) = TextElement content

    let mkAttr (key: string) (value: obj) : ReactProperty =
        let result =
            match value with
            | :? bool -> value.ToString().ToLower()
            | _ -> value.ToString() |> ViewBuilder.escape
        KeyValue (key, result)

    let inline mkStyle (key: string) (value: obj) : IStyleAttribute = Style (key, value) :> _

type FunctionComponent<'Props> = 'Props -> ReactElement

// fsharplint:disable

type React =
    static member functionComponent(name: string, render: 'props -> ReactElement) : FunctionComponent<'props> =
        render

type Event () = class end
    with
        member x.preventDefault () = ()
        member x.type' = "Event"

type AnimationEvent () = inherit Event ()
type ClipboardEvent () = inherit Event ()
type CompositionEvent () = inherit Event ()
type DragEvent () = inherit Event ()
type IKeyboardKey = interface end
type KeyboardEvent () = inherit Event ()
type FocusEvent () = inherit Event ()
type MouseEvent () = inherit Event ()
type TouchEvent () = inherit Event ()
type TransitionEvent () = inherit Event ()
type WheelEvent () = inherit Event ()
type File = class end
