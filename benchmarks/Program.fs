module Feliz.ViewEngine.Benchmarks.Program

open BenchmarkDotNet.Running
open Feliz.ViewEngine.Benchmarks.HtmlBenchmarks

[<EntryPoint>]
let main args =
    // Run all benchmarks
    BenchmarkSwitcher
        .FromAssembly(typeof<HtmlRenderBenchmarks>.Assembly)
        .Run(args)
    |> ignore
    0
