module Tests.Bulma.ViewEngine

open Feliz.ViewEngine
open Feliz.Bulma.ViewEngine
open Feliz.Bulma.ViewEngine.Operators
open Swensen.Unquote
open Xunit


[<Fact>]
let ``Test custom class to bulma elements are combined``() =
    // Arrange / Act
    let result =
        Bulma.section [
            prop.classes ["test"]
        ]
        |> Render.htmlView

    // Assert
    test <@ result = "<section class=\"section test\"></section>" @>

[<Fact>]
let ``Test custom classes to bulma elements are combined``() =
    // Arrange / Act
    let result =
        Bulma.section [
            prop.classes ["test"; "ing"]
        ]
        |> Render.htmlView

    // Assert
    test <@ result = "<section class=\"section test ing\"></section>" @>

[<Fact>]
let ``Test custom class to bulma elements with modifiers are combined``() =
    // Arrange / Act
    let result =
        Bulma.section [
            section.isLarge
            color.isDanger
        ]
        |> Render.htmlView

    // Assert
    test <@ result = "<section class=\"section is-large is-danger\"></section>" @>

[<Fact>]
let ``Test bulma modifiers with html elements are combined``() =
    // Arrange / Act
    let result =
        Html.div [
            section.isLarge
            ++ color.isDanger
        ]
        |> Render.htmlView

    // Assert
    test <@ result = "<div class=\"is-large is-danger\"></div>" @>


[<Fact>]
let ``Test bulma input text has correct classes``() =
    // Arrange / Act
    let result =
        Bulma.input.text [ color.isDanger ]
        |> Render.htmlView

    // Assert
    test <@ result = "<input type=\"text\" class=\"input is-danger\">" @>

[<Fact>]
let ``Test bulma input text has correct properties``() =
    // Arrange / Act
    let result =
        Bulma.input.text [ prop.name "theName"; prop.placeholder "a placeholder" ]
        |> Render.htmlView

    // Assert
    test <@ result = "<input type=\"text\" class=\"input\" name=\"theName\" placeholder=\"a placeholder\">" @>
