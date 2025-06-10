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

```powershell
Install-Package Feliz.ViewEngine
```

Using .NET CLI:

```bash
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

Giraffe example at <https://github.com/dbrattli/Feliz.ViewEngine/blob/master/examples/giraffe/Program.fs>

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

Feliz has extensive documentation at <https://zaid-ajaj.github.io/Feliz> with live examples along side code samples, check
them out and if you have any question, let us know!

## Extensions

- [Feliz.Bulma.ViewEngine](https://www.nuget.org/packages/Feliz.Bulma.ViewEngine/) - Port of
  [Feliz.Bulma](https://github.com/Dzoukr/Feliz.Bulma) to Feliz.ViewEngine.

## Common Pitfalls

Feliz.ViewEngine (`ReactElement`) is not compatible with GiraffeViewEngine (`XmlNode`) so you cannot mix the two as you
can with Feliz and Fable.React. Thus when you convert your existing server side rendering code, then all the elements
must be converted to Feliz.

## Projects and Examples

Projects and examples using Feliz.ViewEngine:

- [Felizia](https://github.com/dbrattli/Felizia) - Uses Feliz.ViewEngine server-side for SSR and Feliz client-side
- [Giraffe server](https://github.com/dbrattli/Feliz.ViewEngine/tree/master/examples/giraffe) - simple example

## Porting an Existing Feliz Library to Feliz.ViewEngine

To port an existing `Feliz` library to `Feliz.ViewEngine` you basically need to reimplement everything from the library
you want to port. However this is usually not a lot of work since you can reuse most of the files from the existing
library, and you can do the work incrementally and add support for more elements and properties as needed.

Start with the file that generates the HTML elements, comment out the whole file using `(* ... *)` and start enabling
element by element. Then port properties, styles, colors, etc.

The `Feliz.ViewEngine` types are different from `ReactElement`:

```fs
type IReactProperty =
    | KeyValue of string * obj
    | Children of ReactElement list
    | Text of string

and ReactElement =
    | Element of string * IReactProperty list
    | VoidElement of string * IReactProperty list
    | TextElement of string
```

However you usually don't have to care about the difference since the `Interop` interface is very similar:

```fs
module Interop =
    /// Output a string where the content has been HTML encoded.
    val mkText: content : 'a -> IReactProperty
    val mkChildren: props: #seq<ReactElement> -> IReactProperty
    val reactElementWithChildren: name: string -> children: #seq<ReactElement> -> ReactElement
    val reactElementWithChild: name: string -> child: 'a -> ReactElement
    val createElement: name: string -> props: IReactProperty list -> ReactElement
    val createVoidElement: name: string -> props: IReactProperty list -> ReactElement
    val createTextElement: content : string -> ReactElement
    val createRawTextElement: content : string -> ReactElement
    let mkAttr: key: string -> value: obj -> IReactProperty
    val mkStyle: key: string -> value: obj -> IStyleAttribute
```

Using the `Interop` module, many elements is exactly the same for `Feliz` and `Feliz.ViewEngine`. E.g `Feliz` code such
as:

```fs
module Html =
    static member inline div xs = Interop.createElement "div" xs
```

For `Feliz.ViewEngine` it will be exactly the same:

```fs
module Html =
    static member inline div xs = Interop.createElement "div" xs
```

However other elements may require some work. E.g all elements that use unboxing such as:

```fs
    static member inline none : ReactElement = unbox null
    static member inline text (value: int) : ReactElement = unbox value
```

For `Feliz.ViewEngine` this needs to be rewritten as:

```fs
    static member inline none : ReactElement = Interop.createTextElement ""
    static member inline text (value: int) : ReactElement = Interop.createTextElement (value.ToString ())
```

Properties may also require some work, e.g:

```fs
[<Erase>]
type prop =
    static member inline dangerouslySetInnerHTML (content: string) = Interop.mkAttr "dangerouslySetInnerHTML" (createObj [ "__html" ==> content ])

```

For `Feliz.ViewEngine` this needs to be rewritten as:

```fs
type prop =
    static member inline dangerouslySetInnerHTML (content: string) = Interop.mkChildren [ Interop.createRawTextElement content ]

```

As you go along, always remember that `Feliz.ViewEngine` and SSR is about generating HTML that will become text. You
just need to make sure that the elements and properties you add generate the expected text output when rendered. Thus
you can add unit-tests to check the output is as expected by calling `Render.htmlView`:

```fs
[<Fact>]
let ``h1 element with text and style property with css unit is Ok``() =
    // Arrange / Act
    let result =
        Html.h1 [
            prop.style [ style.fontSize(length.em(100)) ]
            prop.text "examples"
        ]
        |> Render.htmlView

    // Assert
    test <@ result = "<h1 style=\"font-size:100em\">examples</h1>" @>
```

## License

This work is dual-licensed under Apache 2.0 and MIT. You can choose between one of them if you use this work.

`SPDX-License-Identifier: Apache-2.0 OR MIT`

## Duplication of Code

Yes, Feliz.ViewEngine duplicates a lot of code and violates the [DRY
principle](https://en.wikipedia.org/wiki/Don%27t_repeat_yourself). This is currently [by
design](https://www.sandimetz.com/blog/2016/1/20/the-wrong-abstraction).
