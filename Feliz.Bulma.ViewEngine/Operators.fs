module Feliz.Bulma.ViewEngine.Operators

open Feliz.ViewEngine

let (++) (prop1: IReactProperty) (prop2: IReactProperty) =
    ElementBuilders.Helpers.getClasses [prop1; prop2]
    |> prop.classes