namespace Feliz.ViewEngine

open Feliz.ViewEngine.Styles

//fsharplint:disable

[<Erase>]
type textDecorationLine =
    static member inline none : ITextDecorationLine = TextDecorationLine "none" :> _
    static member inline underline : ITextDecorationLine = TextDecorationLine "underline" :> _
    static member inline overline : ITextDecorationLine = TextDecorationLine "overline" :> _
    static member inline lineThrough : ITextDecorationLine = TextDecorationLine "line-through" :> _
    static member inline initial : ITextDecorationLine = TextDecorationLine "initial" :> _
    static member inline inheritFromParent : ITextDecorationLine = TextDecorationLine "inherit" :> _