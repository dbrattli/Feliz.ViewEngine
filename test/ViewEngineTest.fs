module Tests.ViewEngine

open Feliz.ViewEngine
open Swensen.Unquote
open Xunit

[<Fact>]
let ``Simple text element is Ok``() =
    // Arrange / Act
    let result =
        Html.text "test"
        |> Render.htmlNode

    // Assert
    test <@ result = "test" @>

[<Fact>]
let ``Simple p element with text is Ok``() =
    // Arrange / Act
    let result =
        Html.p "test"
        |> Render.htmlNode

    // Assert
    test <@ result = "<p>test</p>" @>

[<Fact>]
let ``Simple p element with text property is Ok``() =
    // Arrange / Act
    let result =
        Html.p [
            prop.text "test"
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<p>test</p>" @>

[<Fact>]
let ``Simple p element with text element is Ok``() =
    // Arrange / Act
    let result =
        Html.p [
            Html.text "test"
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<p>test</p>" @>


[<Fact>]
let ``Simple p element with text element and class property is Ok``() =
    // Arrange / Act
    let result =
        Html.p [
            prop.className "main"
            prop.children [
                Html.text "test"
            ]
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<p class=\"main\">test</p>" @>