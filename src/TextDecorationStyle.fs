namespace Feliz.ViewEngine

open Feliz.ViewEngine.Styles

[<Erase>]
type textDecorationStyle =
    /// Default value. The line will display as a single line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=solid
    static member inline solid : ITextDecoration = TextDecoration "solid" :> _
    /// The line will display as a double line.
    ///
    /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=double
    static member inline double : ITextDecoration = TextDecoration "double" :> _
    /// The line will display as a dotted line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dotted
    static member inline dotted : ITextDecoration = TextDecoration "dotted" :> _
    /// The line will display as a dashed line.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=dashed
    static member inline dashed : ITextDecoration = TextDecoration "dashed" :> _
    /// The line will display as a wavy line.
    ///
    /// https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=wavy
    static member inline wavy : ITextDecoration = TextDecoration "wavy" :> _
    /// Sets this property to its default value.
    ///
    /// See example https://www.w3schools.com/cssref/playit.asp?filename=playcss_text-decoration-style&preval=initial
    static member inline initial : ITextDecoration = TextDecoration "initial" :> _
    /// Inherits this property from its parent element.
    static member inline inheritFromParent : ITextDecoration = TextDecoration "inherit" :> _