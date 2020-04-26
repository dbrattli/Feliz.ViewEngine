// Yes, this doesn't look to good 😱

namespace Feliz

open Feliz.ViewEngine

type ReactElement = Feliz.ViewEngine.ReactElement
type Html = Feliz.ViewEngine.Html

type IReactProperty = ReactProperty

type prop = Feliz.ViewEngine.prop

module prop =
    type type' = prop.type'

module Interop =
    let mkAttr = Feliz.ViewEngine.Interop.mkAttr

namespace Fable.Core

open System

type EraseAttribute () =
    inherit Attribute ()
