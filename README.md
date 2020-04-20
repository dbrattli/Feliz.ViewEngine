# Feliz.ViewEngine

![Build and Test](https://github.com/dbrattli/Feliz.ViewEngine/workflows/Build%20and%20Test/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Feliz.ViewEngine.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.ViewEngine)

Work in progress (WIP) for using [Feliz](https://github.com/Zaid-Ajaj/Feliz) DSL with Server Side Rendering (SSR). Can be used for Giraffe or other servers. Both for HTML and XML.

## Installation

Feliz.ViewEngine is available as a [NuGet package](https://www.nuget.org/packages/Feliz.ViewEngine/). To install:

Using Package Manager:
```sh
Install-Package Feliz.ViewEngine
```

Using .NET CLI:
```sh
dotnet add package Feliz.ViewEngine
```

## Getting started

```fs
open Feliz.ViewEngine

let html =
    Html.h1 [
        prop.style [ style.fontSize(100); style.color("#137373") ]
        prop.text "Hello, world!"
    ]
    |> Render.htmlNode

printfn "Output: %s" html
```

Giraffe example at https://github.com/dbrattli/Feliz.ViewEngine/blob/master/examples/giraffe/Program.fs

## Sharing views between client and server

```fs
#if FABLE_COMPILER
open Feliz
#else
open Feliz.ViewEngine
#endif

let view  = ...
```

## Documentation

Feliz has extensive documentation at https://zaid-ajaj.github.io/Feliz with live examples along side code samples, check them out and if you have any question, let us know!

## License

This work is dual-licensed under Apache 2.0 and MIT. You can choose between one of them if you use this work.

`SPDX-License-Identifier: Apache-2.0 OR MIT`
