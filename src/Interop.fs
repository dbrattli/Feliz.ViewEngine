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

    let inline createElement name (props: IReactProperty list) : ReactElement =
        Element (name, props)
    let inline createElements (elements : ReactElement seq) : ReactElement =
        Elements elements
    let inline createVoidElement name (props: IReactProperty list) : ReactElement =
        VoidElement (name, props)
    let inline createTextElement (content : string) = ViewBuilder.escape content |> TextElement
    let inline createRawTextElement (content : string) = TextElement content

    let mkAttr (key: string) (value: obj) : IReactProperty =
        let result =
            match value with
            | :? bool -> value.ToString().ToLower()
            | _ -> value.ToString() |> ViewBuilder.escape
        KeyValue (key, result)

    let mkEventHandler(name: string) (handler: obj -> unit) : IReactProperty =
        let event = EventHandlerType.Event(handler)
        IReactProperty.KeyValue(name, event)

    let mkEventHandlerWithKey name key (handler: obj -> unit) =
        let keyEvent = EventHandlerType.KeyEvent(key, handler)
        IReactProperty.KeyValue(name, keyEvent)

    let inline mkStyle (key: string) (value: obj) : IStyleAttribute = Style (key, value) :> _

type FunctionComponent<'Props> = 'Props -> ReactElement