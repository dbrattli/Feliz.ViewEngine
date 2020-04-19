module Tests.ViewEngine

open Feliz.ViewEngine
open Swensen.Unquote
open Xunit

[<Fact>]
let ``Text element is Ok``() =
    let result =
        Html.text "test"
        |> Render.htmlNode

    // Assert
    test <@ result = "test" @>