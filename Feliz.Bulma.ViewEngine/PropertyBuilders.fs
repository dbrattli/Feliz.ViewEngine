module internal Feliz.Bulma.ViewEngine.PropertyBuilders

open Feliz.ViewEngine

let inline mkClass (value:string) = Interop.mkAttr "class" value
let inline mkType (value:string) = Interop.mkAttr "type" value
let inline mkValue (value:int) = Interop.mkAttr "value" value
let inline mkMax (value:int) = Interop.mkAttr "max" value