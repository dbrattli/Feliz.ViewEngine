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
let ``p element with text is Ok``() =
    // Arrange / Act
    let result =
        Html.p "test"
        |> Render.htmlNode

    // Assert
    test <@ result = "<p>test</p>" @>

[<Fact>]
let ``p element with text property is Ok``() =
    // Arrange / Act
    let result =
        Html.p [
            prop.text "test"
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<p>test</p>" @>

[<Fact>]
let ``p element with text element is Ok``() =
    // Arrange / Act
    let result =
        Html.p [
            Html.text "test"
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<p>test</p>" @>


[<Fact>]
let ``p element with text element and class property is Ok``() =
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

[<Fact>]
let ``p element with text element and classes property is Ok``() =
    // Arrange / Act
    let result =
        Html.p [
            prop.classes ["c1"; "c2"]
            prop.children [
                Html.text "test"
            ]
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<p class=\"c1 c2\">test</p>" @>


[<Fact>]
let ``h1 element with text and style property is Ok``() =
    // Arrange / Act
    let result =
        Html.h1 [
            prop.style [ style.fontSize(100); style.color("#137373") ]
            prop.text "examples"
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<h1 style=\"font-size:100px;color:#137373\">examples</h1>" @>

[<Fact>]
let ``Simple h1 element with text and style property is Ok``() =
    // Arrange / Act
    let result =
        Html.h1 [
            prop.style [ style.fontSize(100); style.color("#137373") ]
            prop.text "examples"
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<h1 style=\"font-size:100px;color:#137373\">examples</h1>" @>

[<Fact>]
let ``Closed element Ok``() =
    // Arrange / Act
    let result =
        Html.div [
            Html.br []
        ]
        |> Render.htmlNode

    // Assert
    test <@ result = "<div><br></div>" @>
