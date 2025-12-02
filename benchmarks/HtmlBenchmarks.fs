module Feliz.ViewEngine.Benchmarks.HtmlBenchmarks

open BenchmarkDotNet.Attributes
open Feliz.ViewEngine

/// Benchmarks matching the tests from hamy.xyz blog posts
[<MemoryDiagnoser>]
[<RankColumn>]
type HtmlRenderBenchmarks() =

    /// Simple element - baseline
    [<Benchmark>]
    member _.SimpleElement() =
        Html.div [ prop.className "test" ]
        |> Render.htmlView

    /// Element with text content
    [<Benchmark>]
    member _.ElementWithText() =
        Html.p [
            prop.className "paragraph"
            prop.text "Hello, World!"
        ]
        |> Render.htmlView

    /// Element with styles
    [<Benchmark>]
    member _.ElementWithStyles() =
        Html.div [
            prop.style [
                style.color "red"
                style.fontSize 16
                style.margin 10
                style.padding 5
            ]
            prop.text "Styled"
        ]
        |> Render.htmlView

    /// Text that needs escaping
    [<Benchmark>]
    member _.TextEscaping() =
        Html.p [
            prop.text "Hello <world> & \"friends\" it's great"
        ]
        |> Render.htmlView

    /// Text that doesn't need escaping
    [<Benchmark>]
    member _.TextNoEscaping() =
        Html.p [
            prop.text "Hello world this is plain text without special characters"
        ]
        |> Render.htmlView


/// Long page benchmarks - similar to hamy.xyz flat/shallow benchmarks
[<MemoryDiagnoser>]
[<RankColumn>]
type LongPageBenchmarks() =

    let createItem i =
        Html.div [
            prop.className "item"
            prop.children [
                Html.span [ prop.text $"Item {i}" ]
                Html.p [ prop.text "Description text here" ]
            ]
        ]

    [<Params(10, 100, 1000)>]
    member val ItemCount = 0 with get, set

    [<Benchmark>]
    member this.LongFlatPage() =
        Html.div [
            prop.className "container"
            prop.children [
                for i in 1 .. this.ItemCount do
                    createItem i
            ]
        ]
        |> Render.htmlView


/// Deeply nested benchmarks - similar to hamy.xyz nested benchmarks
[<MemoryDiagnoser>]
[<RankColumn>]
type DeeplyNestedBenchmarks() =

    let rec createNestedDiv depth =
        if depth <= 0 then
            Html.span [ prop.text "Leaf" ]
        else
            Html.div [
                prop.className $"level-{depth}"
                prop.children [ createNestedDiv (depth - 1) ]
            ]

    [<Params(10, 100, 500)>]
    member val Depth = 0 with get, set

    [<Benchmark>]
    member this.DeeplyNested() =
        createNestedDiv this.Depth
        |> Render.htmlView


/// Table rendering benchmark - common real-world scenario
[<MemoryDiagnoser>]
[<RankColumn>]
type TableBenchmarks() =

    [<Params(10, 100, 500)>]
    member val RowCount = 0 with get, set

    [<Benchmark>]
    member this.TableRendering() =
        Html.table [
            Html.thead [
                Html.tr [
                    Html.th "ID"
                    Html.th "Name"
                    Html.th "Email"
                    Html.th "Status"
                ]
            ]
            Html.tbody [
                for i in 1 .. this.RowCount do
                    Html.tr [
                        Html.td $"{i}"
                        Html.td $"User {i}"
                        Html.td $"user{i}@example.com"
                        Html.td "Active"
                    ]
            ]
        ]
        |> Render.htmlView
