# Feliz Giraffe

Work in progress (WIP) for using [Feliz](https://github.com/Zaid-Ajaj/Feliz) DSL with Giraffe both for HTML (and XML).

## Getting started

```fs
#if FABLE_COMPILER
open Feliz
#else
open Feliz.Giraffe
#endif

let view  = ...
```

Giraffe example at https://github.com/dbrattli/Feliz.Giraffe/blob/master/examples/giraffe/Program.fs