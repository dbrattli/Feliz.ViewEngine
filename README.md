# Feliz.ViewEngine

![Build and Test](https://github.com/dbrattli/Feliz.ViewEngine/workflows/Build%20and%20Test/badge.svg)
[![NuGet](https://img.shields.io/nuget/v/Feliz.ViewEngine.svg?maxAge=0&colorB=brightgreen)](https://www.nuget.org/packages/Feliz.ViewEngine)

Feliz.ViewEngine lets you render [Feliz](https://github.com/Zaid-Ajaj/Feliz) DSL to plain HTML (or XML). Use with e.g
Giraffe for handling Server Side Rendering (SSR), returning HTML or XML. You can use it for e.g generating HTML emails
or any other use-case where you need to generate HTML output.

Feliz.ViewEngine have no dependencies, is Fable compatible, and can thus be used with both servers (e.g Node.js) or
clients.

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
    |> Render.htmlView

printfn "Output: %s" html
// Will output "<h1 style=\"font-size:100px;color:#137373\">Hello, world!</h1>"
```

Giraffe example at https://github.com/dbrattli/Feliz.ViewEngine/blob/master/examples/giraffe/Program.fs

## Sharing views between client and server

Feliz.ViewEngine re-implements Feliz DSL for server-side so you will need to choose Feliz for client side rendering and
Feliz.ViewEngine for server side rendering:

```fs
#if FABLE_COMPILER
open Feliz
#else
open Feliz.ViewEngine
#endif

let view = ...
```

## Documentation

The following API is available for converting a `ReactElement` view into a string that you can return from e.g a Giraffe
HTTP handler.

```fs
type Render
  /// Create HTML document view with <!DOCTYPE html>
  static member htmlDocument: document: ReactElement -> string
  /// Create HTML view
  static member htmlView: node: ReactElement -> string (+ 1 overloads)
  /// Create XML document view with <?xml version="1.0" encoding="utf-8"?>
  static member xmlDocument: document: ReactElement -> string
  /// Create XML view
  static member xmlView: node: ReactElement -> string (+ 1 overloads)
```

Feliz has extensive documentation at https://zaid-ajaj.github.io/Feliz with live examples along side code samples, check
them out and if you have any question, let us know!

## Extensions

- [Feliz.Bulma.ViewEngine](https://www.nuget.org/packages/Feliz.Bulma.ViewEngine/) - Port of
  [Feliz.Bulma](https://github.com/Dzoukr/Feliz.Bulma) to Feliz.ViewEngine.

## Common Pitfalls

Feliz.ViewEngine (`ReactElement`) is not compatible with GiraffeViewEngine (`XmlNode`) so you cannot mix the two as you
can with Feliz and React. Thus when you convert your existing server side rendering, then all the elements must be
converted to Feliz.

## License

This work is dual-licensed under Apache 2.0 and MIT. You can choose between one of them if you use this work.

`SPDX-License-Identifier: Apache-2.0 OR MIT`
