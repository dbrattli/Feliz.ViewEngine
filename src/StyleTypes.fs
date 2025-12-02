namespace Feliz.ViewEngine.Styles

open System

type IBorderStyle = interface end

type ITextAlignment = interface end

type ITextDecoration = interface end

type ITextDecorationLine = interface end

type IVisibility = interface end

type IPosition = interface end

type IAlignContent = interface end

type IAlignItems = interface end

type IAlignSelf = interface end

type IDisplay = interface end

type IFontStyle = interface end

type IFontVariant = interface end

type IFontWeight = interface end

type IFontStretch = interface end

type IFontKerning = interface end

type IOverflow = interface end

type IWordWrap = interface end

type IBackgroundRepeat = interface end

type IBackgroundClip = interface end

type ICssUnit = interface end

type ITransitionProperty = interface end

type ITransformProperty = interface end

type IStyleAttribute = interface end

type StyleAttribute =
    | Style of string * obj
    interface IStyleAttribute

    override x.ToString () =
        let (Style (key, value)) = x
        String.Join(":", key, value)

type CssUnit =
    | CssUnit of string
    interface ICssUnit

    override x.ToString () =
        let (CssUnit value) = x
        value

type BorderStyle =
    | BorderStyle of string
    interface IBorderStyle

    override x.ToString () =
        let (BorderStyle value) = x
        value

type TextDecorationLine =
    | TextDecorationLine of string
    interface ITextDecorationLine

    override x.ToString () =
        let (TextDecorationLine value) = x
        value

type TextDecoration =
    | TextDecoration of string
    interface ITextDecoration

    override x.ToString () =
        let (TextDecoration value) = x
        value