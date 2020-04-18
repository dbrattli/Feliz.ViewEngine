# Feliz Giraffe

Work in progress (WIP) for using [Feliz](https://github.com/Zaid-Ajaj/Feliz) DSL with Giraffe both for HTML (and XML).

## Getting started

```fs
#if FABLE_COMPILER
open Feliz
#else
open Feliz.Giraffe
#endif

let view  =
    Html.html [
        prop.classes [ "has-navbar-fixed-top" ]
        prop.children [
            Html.head [
                Html.meta [ prop.content "text/html" ]
                Html.title [ rawText "One Happy Giraffe" ]
            ]
            Html.body [
                ...
            ]
```