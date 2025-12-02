# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

Feliz.ViewEngine is an F# library that renders the Feliz DSL to plain HTML or XML strings. It's designed for server-side rendering (SSR) scenarios like Giraffe web handlers, HTML email generation, or any case where HTML output is needed. The library has no dependencies and is Fable-compatible.

## Build Commands

```bash
# Restore dependencies (uses Paket)
dotnet restore

# Build all projects
dotnet build

# Run tests
dotnet test test/Tests.Feliz.ViewEngine.fsproj

# Build specific project
dotnet build src/Feliz.ViewEngine.fsproj
```

## Architecture

### Core Types (src/ViewEngine.fs)

The library defines its own `ReactElement` discriminated union (not Fable.React):

```fsharp
type IReactProperty =
    | KeyValue of string * obj
    | Children of ReactElement list
    | Text of string

type ReactElement =
    | Element of string * IReactProperty list
    | VoidElement of string * IReactProperty list  // self-closing like <br>, <img>
    | TextElement of string
    | Elements of ReactElement seq
```

The `Render` module converts these to strings via `htmlView`, `xmlView`, `htmlDocument`, or `xmlDocument`.

### Interop Module (src/Interop.fs)

Provides the API bridge between Feliz DSL and the ViewEngine types. Key functions:

- `createElement` / `createVoidElement` - create elements with properties
- `mkAttr` / `mkStyle` - create attributes and style properties
- `createTextElement` / `createRawTextElement` - create text (escaped vs raw)

### DSL Modules

- `Html` (src/Html.fs) - HTML element functions (`Html.div`, `Html.p`, etc.)
- `prop` (src/Properties.fs) - HTML properties (`prop.className`, `prop.style`, etc.)
- `style` (src/Styles.fs) - CSS style properties
- `React` (src/React.fs) - React-compatible utilities like `fragment`

### Feliz.Bulma.ViewEngine Extension

A port of Feliz.Bulma for server-side rendering, located in `Feliz.Bulma.ViewEngine/`.

## Client/Server Code Sharing

Use compiler directives to share views between client (Feliz) and server (Feliz.ViewEngine):

```fsharp
#if FABLE_COMPILER
open Feliz
#else
open Feliz.ViewEngine
#endif
```

## Key Differences from Feliz

- Event handlers are stored in the DOM tree but ignored during rendering
- `Html.none` returns an empty `TextElement` (not `unbox null`)
- `Html.text` uses `createTextElement` (not unboxing)
- HTML is escaped by default; use `Html.rawText` for unescaped content
