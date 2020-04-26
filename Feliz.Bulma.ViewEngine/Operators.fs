module Feliz.Bulma.ViewEngine.Operators

open Feliz.ViewEngine

let (++) (prop1:ReactProperty) (prop2:ReactProperty) =
    ElementBuilders.Helpers.getClasses [prop1; prop2]
    |> fun classes -> prop.classes classes