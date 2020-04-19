# Feliz.ViewEngine

Work in progress (WIP) for using [Feliz](https://github.com/Zaid-Ajaj/Feliz) DSL with Server Side Rendering (SSR). Can be used for Giraffe or other servers. Both for HTML and XML.

## Getting started

```fs
#if FABLE_COMPILER
open Feliz
#else
open Feliz.ViewEngine
#endif

let view  = ...
```

Giraffe example at https://github.com/dbrattli/Feliz.ViewEngine/blob/master/examples/giraffe/Program.fs

## License

This work is dual-licensed under Apache 2.0 and MIT. You can choose between one of them if you use this work.

`SPDX-License-Identifier: Apache-2.0 OR MIT`
