namespace Feliz.Giraffe

open System
open Giraffe.GiraffeViewEngine

type Html =
    static member inline a xs = Interop.createElement "a" xs
    static member inline a (children: #seq<XmlNode>) = Interop.reactElementWithChildren "a" children

    static member inline abbr xs = Interop.createElement "abbr" xs
    static member inline abbr (value: float) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (value: int) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (value: XmlNode) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (value: string) = Interop.reactElementWithChild "abbr" value
    static member inline abbr (children: #seq<XmlNode>) = Interop.reactElementWithChildren "abbr" children

    static member inline address xs = Interop.createElement "address" xs
    static member inline address (value: float) = Interop.reactElementWithChild "address" value
    static member inline address (value: int) = Interop.reactElementWithChild "address" value
    static member inline address (value: XmlNode) = Interop.reactElementWithChild "address" value
    static member inline address (value: string) = Interop.reactElementWithChild "address" value
    static member inline address (children: #seq<XmlNode>) = Interop.reactElementWithChildren "address" children

    static member inline anchor xs = Interop.createElement "a" xs
    static member inline anchor (children: #seq<XmlNode>) = Interop.reactElementWithChildren "a" children

    static member inline area xs = Interop.createElement "area" xs

    static member inline article xs = Interop.createElement "article" xs
    static member inline article (children: #seq<XmlNode>) = Interop.reactElementWithChildren "article" children

    static member inline aside xs = Interop.createElement "aside" xs
    static member inline aside (children: #seq<XmlNode>) = Interop.reactElementWithChildren "aside" children

    static member inline audio xs = Interop.createElement "audio" xs
    static member inline audio (children: #seq<XmlNode>) = Interop.reactElementWithChildren "audio" children

    static member inline b xs = Interop.createElement "b" xs
    static member inline b (value: float) = Interop.reactElementWithChild "b" value
    static member inline b (value: int) = Interop.reactElementWithChild "b" value
    static member inline b (value: XmlNode) = Interop.reactElementWithChild "b" value
    static member inline b (value: string) = Interop.reactElementWithChild "b" value
    static member inline b (children: #seq<XmlNode>) = Interop.reactElementWithChildren "b" children

    static member inline base' xs = Interop.createElement "base" xs

    static member inline bdi xs = Interop.createElement "bdi" xs
    static member inline bdi (value: float) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (value: int) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (value: XmlNode) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (value: string) = Interop.reactElementWithChild "bdi" value
    static member inline bdi (children: #seq<XmlNode>) = Interop.reactElementWithChildren "bdi" children

    static member inline bdo xs = Interop.createElement "bdo" xs
    static member inline bdo (value: float) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (value: int) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (value: XmlNode) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (value: string) = Interop.reactElementWithChild "bdo" value
    static member inline bdo (children: #seq<XmlNode>) = Interop.reactElementWithChildren "bdo" children

    static member inline blockquote xs = Interop.createElement "blockquote" xs
    static member inline blockquote (value: float) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (value: int) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (value: XmlNode) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (value: string) = Interop.reactElementWithChild "blockquote" value
    static member inline blockquote (children: #seq<XmlNode>) = Interop.reactElementWithChildren "blockquote" children

    static member inline body xs = Interop.createElement "body" xs
    static member inline body (value: float) = Interop.reactElementWithChild "body" value
    static member inline body (value: int) = Interop.reactElementWithChild "body" value
    static member inline body (value: XmlNode) = Interop.reactElementWithChild "body" value
    static member inline body (value: string) = Interop.reactElementWithChild "body" value
    static member inline body (children: #seq<XmlNode>) = Interop.reactElementWithChildren "body" children

    static member inline br xs = Interop.createElement "br" xs

    static member inline button xs = Interop.createElement "button" xs
    static member inline button (children: #seq<XmlNode>) = Interop.reactElementWithChildren "button" children

    static member inline canvas xs = Interop.createElement "canvas" xs

    static member inline caption xs = Interop.createElement "caption" xs
    static member inline caption (value: float) = Interop.reactElementWithChild "caption" value
    static member inline caption (value: int) = Interop.reactElementWithChild "caption" value
    static member inline caption (value: XmlNode) = Interop.reactElementWithChild "caption" value
    static member inline caption (value: string) = Interop.reactElementWithChild "caption" value
    static member inline caption (children: #seq<XmlNode>) = Interop.reactElementWithChildren "caption" children

    static member inline cite xs = Interop.createElement "cite" xs
    static member inline cite (value: float) = Interop.reactElementWithChild "cite" value
    static member inline cite (value: int) = Interop.reactElementWithChild "cite" value
    static member inline cite (value: XmlNode) = Interop.reactElementWithChild "cite" value
    static member inline cite (value: string) = Interop.reactElementWithChild "cite" value
    static member inline cite (children: #seq<XmlNode>) = Interop.reactElementWithChildren "cite" children

    static member inline circle xs = Interop.createElement "circle" xs
    static member inline circle (children: #seq<XmlNode>) = Interop.reactElementWithChildren "circle" children

    static member inline clipPath xs = Interop.createElement "clipPath" xs
    static member inline clipPath (children: #seq<XmlNode>) = Interop.reactElementWithChildren "clipPath" children

    static member inline code xs = Interop.createElement "code" xs
    static member inline code (value: bool) = Interop.reactElementWithChild "code" value
    static member inline code (value: float) = Interop.reactElementWithChild "code" value
    static member inline code (value: int) = Interop.reactElementWithChild "code" value
    static member inline code (value: XmlNode) = Interop.reactElementWithChild "code" value
    static member inline code (value: string) = Interop.reactElementWithChild "code" value
    static member inline code (children: #seq<XmlNode>) = Interop.reactElementWithChildren "code" children

    static member inline col xs = Interop.createElement "col" xs

    static member inline colgroup xs = Interop.createElement "colgroup" xs
    static member inline colgroup (children: #seq<XmlNode>) = Interop.reactElementWithChildren "colgroup" children

    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: float) : XmlNode = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: int) : XmlNode = unbox value
    [<Obsolete("This deprecated API should no longer be used, but will probably still work.")>]
    static member inline content (value: string) : XmlNode = unbox value

    static member inline data xs = Interop.createElement "data" xs
    static member inline data (value: float) = Interop.reactElementWithChild "data" value
    static member inline data (value: int) = Interop.reactElementWithChild "data" value
    static member inline data (value: XmlNode) = Interop.reactElementWithChild "data" value
    static member inline data (value: string) = Interop.reactElementWithChild "data" value
    static member inline data (children: #seq<XmlNode>) = Interop.reactElementWithChildren "data" children

    static member inline datalist xs = Interop.createElement "datalist" xs
    static member inline datalist (value: float) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (value: int) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (value: XmlNode) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (value: string) = Interop.reactElementWithChild "datalist" value
    static member inline datalist (children: #seq<XmlNode>) = Interop.reactElementWithChildren "datalist" children

    static member inline dd xs = Interop.createElement "dd" xs
    static member inline dd (value: float) = Interop.reactElementWithChild "dd" value
    static member inline dd (value: int) = Interop.reactElementWithChild "dd" value
    static member inline dd (value: XmlNode) = Interop.reactElementWithChild "dd" value
    static member inline dd (value: string) = Interop.reactElementWithChild "dd" value
    static member inline dd (children: #seq<XmlNode>) = Interop.reactElementWithChildren "dd" children

    static member inline defs xs = Interop.createElement "defs" xs
    static member inline defs (children: #seq<XmlNode>) = Interop.reactElementWithChildren "defs" children

    static member inline del xs = Interop.createElement "del" xs
    static member inline del (value: float) = Interop.reactElementWithChild "del" value
    static member inline del (value: int) = Interop.reactElementWithChild "del" value
    static member inline del (value: XmlNode) = Interop.reactElementWithChild "del" value
    static member inline del (value: string) = Interop.reactElementWithChild "del" value
    static member inline del (children: #seq<XmlNode>) = Interop.reactElementWithChildren "del" children

    static member inline details xs = Interop.createElement "details" xs
    static member inline details (children: #seq<XmlNode>) = Interop.reactElementWithChildren "details" children

    static member inline dfn xs = Interop.createElement "ins" xs
    static member inline dfn (value: float) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (value: int) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (value: XmlNode) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (value: string) = Interop.reactElementWithChild "dfn" value
    static member inline dfn (children: #seq<XmlNode>) = Interop.reactElementWithChildren "dfn" children

    static member inline dialog xs = Interop.createElement "dialog" xs
    static member inline dialog (value: float) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (value: int) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (value: XmlNode) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (value: string) = Interop.reactElementWithChild "dialog" value
    static member inline dialog (children: #seq<XmlNode>) = Interop.reactElementWithChildren "dialog" children

    /// The `<div>` tag defines a division or a section in an HTML document
    static member inline div xs = Interop.createElement "div" xs
    static member inline div (value: float) = Interop.reactElementWithChild "div" value
    static member inline div (value: int) = Interop.reactElementWithChild "div" value
    static member inline div (value: XmlNode) = Interop.reactElementWithChild "div" value
    static member inline div (value: string) = Interop.reactElementWithChild "div" value
    static member inline div (children: #seq<XmlNode>) = Interop.reactElementWithChildren "div" children

    static member inline dl xs = Interop.createElement "dl" xs
    static member inline dl (children: #seq<XmlNode>) = Interop.reactElementWithChildren "dl" children

    static member inline dt xs = Interop.createElement "dt" xs
    static member inline dt (value: float) = Interop.reactElementWithChild "dt" value
    static member inline dt (value: int) = Interop.reactElementWithChild "dt" value
    static member inline dt (value: XmlNode) = Interop.reactElementWithChild "dt" value
    static member inline dt (value: string) = Interop.reactElementWithChild "dt" value
    static member inline dt (children: #seq<XmlNode>) = Interop.reactElementWithChildren "dt" children

    static member inline ellipse xs = Interop.createElement "ellipse" xs
    static member inline ellipse (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ellipse" children

    static member inline em xs = Interop.createElement "em" xs
    static member inline em (value: float) = Interop.reactElementWithChild "em" value
    static member inline em (value: int) = Interop.reactElementWithChild "em" value
    static member inline em (value: XmlNode) = Interop.reactElementWithChild "em" value
    static member inline em (value: string) = Interop.reactElementWithChild "em" value
    static member inline em (children: #seq<XmlNode>) = Interop.reactElementWithChildren "em" children

    static member inline embed xs = Interop.createElement "embed" xs

    static member inline fieldSet xs = Interop.createElement "fieldset" xs
    static member inline fieldSet (children: #seq<XmlNode>) = Interop.reactElementWithChildren "fieldset" children

    static member inline figcaption xs = Interop.createElement "figcaption" xs
    static member inline figcaption (children: #seq<XmlNode>) = Interop.reactElementWithChildren "figcaption" children

    static member inline figure xs = Interop.createElement "figure" xs
    static member inline figure (children: #seq<XmlNode>) = Interop.reactElementWithChildren "figure" children

    static member inline footer xs = Interop.createElement "footer" xs
    static member inline footer (children: #seq<XmlNode>) = Interop.reactElementWithChildren "footer" children

    static member inline form xs = Interop.createElement "form" xs
    static member inline form (children: #seq<XmlNode>) = Interop.reactElementWithChildren "form" children

    static member inline g xs = Interop.createElement "g" xs
    static member inline g (children: #seq<XmlNode>) = Interop.reactElementWithChildren "g" children

    static member inline h1 xs = Interop.createElement "h1" xs
    static member inline h1 (value: float) = Interop.reactElementWithChild "h1" value
    static member inline h1 (value: int) = Interop.reactElementWithChild "h1" value
    static member inline h1 (value: XmlNode) = Interop.reactElementWithChild "h1" value
    static member inline h1 (value: string) = Interop.reactElementWithChild "h1" value
    static member inline h1 (children: #seq<XmlNode>) = Interop.reactElementWithChildren "h1" children

    static member inline h2 xs = Interop.createElement "h2" xs
    static member inline h2 (value: float) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (value: int) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (value: XmlNode) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (value: string) =  Interop.reactElementWithChild "h2" value
    static member inline h2 (children: #seq<XmlNode>) = Interop.reactElementWithChildren "h2" children

    static member inline h3 xs = Interop.createElement "h3" xs
    static member inline h3 (value: float) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (value: int) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (value: XmlNode) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (value: string) =  Interop.reactElementWithChild "h3" value
    static member inline h3 (children: #seq<XmlNode>) = Interop.reactElementWithChildren "h3" children

    static member inline h4 xs = Interop.createElement "h4" xs
    static member inline h4 (value: float) = Interop.reactElementWithChild "h4" value
    static member inline h4 (value: int) = Interop.reactElementWithChild "h4" value
    static member inline h4 (value: XmlNode) = Interop.reactElementWithChild "h4" value
    static member inline h4 (value: string) = Interop.reactElementWithChild "h4" value
    static member inline h4 (children: #seq<XmlNode>) = Interop.reactElementWithChildren "h4" children

    static member inline h5 xs = Interop.createElement "h5" xs
    static member inline h5 (value: float) = Interop.reactElementWithChild "h5" value
    static member inline h5 (value: int) = Interop.reactElementWithChild "h5" value
    static member inline h5 (value: XmlNode) = Interop.reactElementWithChild "h5" value
    static member inline h5 (value: string) = Interop.reactElementWithChild "h5" value
    static member inline h5 (children: #seq<XmlNode>) = Interop.reactElementWithChildren "h5" children

    static member inline h6 xs = Interop.createElement "h6" xs
    static member inline h6 (value: float) = Interop.reactElementWithChild "h6" value
    static member inline h6 (value: int) = Interop.reactElementWithChild "h6" value
    static member inline h6 (value: XmlNode) = Interop.reactElementWithChild "h6" value
    static member inline h6 (value: string) = Interop.reactElementWithChild "h6" value
    static member inline h6 (children: #seq<XmlNode>) = Interop.reactElementWithChildren "h6" children

    static member inline head xs = Interop.createElement "head" xs
    static member inline head (children: #seq<XmlNode>) = Interop.reactElementWithChildren "head" children

    static member inline header xs = Interop.createElement "header" xs
    static member inline header (children: #seq<XmlNode>) = Interop.reactElementWithChildren "header" children

    static member inline hr xs = Interop.createElement "hr" xs

    static member inline html xs = Interop.createElement "html" xs
    static member inline html (children: #seq<XmlNode>) = Interop.reactElementWithChildren "html" children

    static member inline i xs = Interop.createElement "i" xs
    static member inline i (value: float) = Interop.reactElementWithChild "i" value
    static member inline i (value: int) = Interop.reactElementWithChild "i" value
    static member inline i (value: XmlNode) = Interop.reactElementWithChild "i" value
    static member inline i (value: string) = Interop.reactElementWithChild "i" value
    static member inline i (children: #seq<XmlNode>) = Interop.reactElementWithChildren "i" children

    static member inline iframe xs = Interop.createElement "iframe" xs

    static member inline img xs = Interop.createElement "img" xs

    static member inline input xs = Interop.createElement "input" xs

    static member inline ins xs = Interop.createElement "ins" xs
    static member inline ins (value: float) = Interop.reactElementWithChild "ins" value
    static member inline ins (value: int) = Interop.reactElementWithChild "ins" value
    static member inline ins (value: XmlNode) = Interop.reactElementWithChild "ins" value
    static member inline ins (value: string) = Interop.reactElementWithChild "ins" value
    static member inline ins (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ins" children

    static member inline kbd xs = Interop.createElement "kbd" xs
    static member inline kbd (value: float) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (value: int) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (value: XmlNode) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (value: string) = Interop.reactElementWithChild "kbd" value
    static member inline kbd (children: #seq<XmlNode>) = Interop.reactElementWithChildren "kbd" children

    static member inline label xs = Interop.createElement "label" xs
    static member inline label (children: #seq<XmlNode>) = Interop.reactElementWithChildren "label" children

    static member inline legend xs = Interop.createElement "legend" xs
    static member inline legend (value: float) = Interop.reactElementWithChild "legend" value
    static member inline legend (value: int) = Interop.reactElementWithChild "legend" value
    static member inline legend (value: XmlNode) = Interop.reactElementWithChild "legend" value
    static member inline legend (value: string) = Interop.reactElementWithChild "legend" value
    static member inline legend (children: #seq<XmlNode>) = Interop.reactElementWithChildren "legend" children

    static member inline li xs = Interop.createElement "li" xs
    static member inline li (value: float) = Interop.reactElementWithChild "li" value
    static member inline li (value: int) = Interop.reactElementWithChild "li" value
    static member inline li (value: XmlNode) = Interop.reactElementWithChild "li" value
    static member inline li (value: string) = Interop.reactElementWithChild "li" value
    static member inline li (children: #seq<XmlNode>) = Interop.reactElementWithChildren "li" children

    static member inline line xs = Interop.createElement "line" xs
    static member inline line (children: #seq<XmlNode>) = Interop.reactElementWithChildren "line" children

    static member inline linearGradient xs = Interop.createElement "linearGradient" xs
    static member inline linearGradient (children: #seq<XmlNode>) = Interop.reactElementWithChildren "linearGradient" children

    static member inline link xs = Interop.createElement "link" xs
    static member inline link (children: #seq<XmlNode>) = Interop.reactElementWithChildren "link" children

    static member inline listItem xs = Interop.createElement "li" xs
    static member inline listItem (value: float) = Interop.reactElementWithChild "li" value
    static member inline listItem (value: int) = Interop.reactElementWithChild "li" value
    static member inline listItem (value: XmlNode) = Interop.reactElementWithChild "li" value
    static member inline listItem (value: string) = Interop.reactElementWithChild "li" value
    static member inline listItem (children: #seq<XmlNode>) = Interop.reactElementWithChildren "li" children

    static member inline main xs = Interop.createElement "main" xs
    static member inline main (children: #seq<XmlNode>) = Interop.reactElementWithChildren "main" children

    static member inline map xs = Interop.createElement "map" xs
    static member inline map (children: #seq<XmlNode>) = Interop.reactElementWithChildren "map" children

    static member inline mark xs = Interop.createElement "mark" xs
    static member inline mark (value: float) = Interop.reactElementWithChild "mark" value
    static member inline mark (value: int) = Interop.reactElementWithChild "mark" value
    static member inline mark (value: XmlNode) = Interop.reactElementWithChild "mark" value
    static member inline mark (value: string) = Interop.reactElementWithChild "mark" value
    static member inline mark (children: #seq<XmlNode>) = Interop.reactElementWithChildren "mark" children

    static member inline meta xs = Interop.createElement "meta" xs

    static member inline meter xs = Interop.createElement "meter" xs
    static member inline meter (value: float) = Interop.reactElementWithChild "meter" value
    static member inline meter (value: int) = Interop.reactElementWithChild "meter" value
    static member inline meter (value: XmlNode) = Interop.reactElementWithChild "meter" value
    static member inline meter (value: string) = Interop.reactElementWithChild "meter" value
    static member inline meter (children: #seq<XmlNode>) = Interop.reactElementWithChildren "meter" children

    static member inline nav xs = Interop.createElement "nav" xs
    static member inline nav (children: #seq<XmlNode>) = Interop.reactElementWithChildren "nav" children

    /// The empty element, renders nothing on screen
    static member inline none : XmlNode = unbox null

    static member inline noscript xs = Interop.createElement "noscript" xs
    static member inline noscript (children: #seq<XmlNode>) = Interop.reactElementWithChildren "noscript" children

    static member inline object xs = Interop.createElement "object" xs
    static member inline object (children: #seq<XmlNode>) = Interop.reactElementWithChildren "object" children

    static member inline ol xs = Interop.createElement "ol" xs
    static member inline ol (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ol" children

    static member inline option xs = Interop.createElement "option" xs
    static member inline option (value: float) = Interop.reactElementWithChild "option" value
    static member inline option (value: int) = Interop.reactElementWithChild "option" value
    static member inline option (value: XmlNode) = Interop.reactElementWithChild "option" value
    static member inline option (value: string) = Interop.reactElementWithChild "option" value
    static member inline option (children: #seq<XmlNode>) = Interop.reactElementWithChildren "option" children

    static member inline optgroup xs = Interop.createElement "optgroup" xs
    static member inline optgroup (children: #seq<XmlNode>) = Interop.reactElementWithChildren "optgroup" children

    static member inline orderedList xs = Interop.createElement "ol" xs
    static member inline orderedList (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ol" children

    static member inline output xs = Interop.createElement "output" xs
    static member inline output (value: float) = Interop.reactElementWithChild "output" value
    static member inline output (value: int) = Interop.reactElementWithChild "output" value
    static member inline output (value: XmlNode) = Interop.reactElementWithChild "output" value
    static member inline output (value: string) = Interop.reactElementWithChild "output" value
    static member inline output (children: #seq<XmlNode>) = Interop.reactElementWithChildren "output" children

    static member inline p xs = Interop.createElement "p" xs
    static member inline p (value: float) = Interop.reactElementWithChild "p" value
    static member inline p (value: int) = Interop.reactElementWithChild "p" value
    static member inline p (value: XmlNode) = Interop.reactElementWithChild "p" value
    static member inline p (value: string) = Interop.reactElementWithChild "p" value
    static member inline p (children: #seq<XmlNode>) = Interop.reactElementWithChildren "p" children

    static member inline paragraph xs = Interop.createElement "p" xs
    static member inline paragraph (value: float) = Interop.reactElementWithChild "p" value
    static member inline paragraph (value: int) = Interop.reactElementWithChild "p" value
    static member inline paragraph (value: XmlNode) = Interop.reactElementWithChild "p" value
    static member inline paragraph (value: string) = Interop.reactElementWithChild "p" value
    static member inline paragraph (children: #seq<XmlNode>) = Interop.reactElementWithChildren "p" children

    static member inline param xs = Interop.createElement "param" xs

    static member inline path xs = Interop.createElement "path" xs
    static member inline path (children: #seq<XmlNode>) = Interop.reactElementWithChildren "path" children

    static member inline picture xs = Interop.createElement "picture" xs
    static member inline picture (children: #seq<XmlNode>) = Interop.reactElementWithChildren "picture" children

    static member inline polygon xs = Interop.createElement "polygon" xs
    static member inline polygon (children: #seq<XmlNode>) = Interop.reactElementWithChildren "polygon" children

    static member inline polyline xs = Interop.createElement "polyline" xs
    static member inline polyline (children: #seq<XmlNode>) = Interop.reactElementWithChildren "polyline" children

    static member inline pre xs = Interop.createElement "pre" xs
    static member inline pre (value: bool) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: float) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: int) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: XmlNode) = Interop.reactElementWithChild "pre" value
    static member inline pre (value: string) = Interop.reactElementWithChild "pre" value
    static member inline pre (children: #seq<XmlNode>) = Interop.reactElementWithChildren "pre" children

    static member inline progress xs = Interop.createElement "progress" xs
    static member inline progress (children: #seq<XmlNode>) = Interop.reactElementWithChildren "progress" children

    static member inline q xs = Interop.createElement "q" xs
    static member inline q (children: #seq<XmlNode>) = Interop.reactElementWithChildren "q" children

    static member inline radialGradient xs = Interop.createElement "radialGradient" xs
    static member inline radialGradient (children: #seq<XmlNode>) = Interop.reactElementWithChildren "radialGradient" children

    static member inline rb xs = Interop.createElement "rb" xs
    static member inline rb (value: float) = Interop.reactElementWithChild "rb" value
    static member inline rb (value: int) = Interop.reactElementWithChild "rb" value
    static member inline rb (value: XmlNode) = Interop.reactElementWithChild "rb" value
    static member inline rb (value: string) = Interop.reactElementWithChild "rb" value
    static member inline rb (children: #seq<XmlNode>) = Interop.reactElementWithChildren "rb" children

    static member inline rect xs = Interop.createElement "rect" xs
    static member inline rect (children: #seq<XmlNode>) = Interop.reactElementWithChildren "rect" children

    static member inline rp xs = Interop.createElement "rp" xs
    static member inline rp (value: float) = Interop.reactElementWithChild "rp" value
    static member inline rp (value: int) = Interop.reactElementWithChild "rp" value
    static member inline rp (value: XmlNode) = Interop.reactElementWithChild "rp" value
    static member inline rp (value: string) = Interop.reactElementWithChild "rp" value
    static member inline rp (children: #seq<XmlNode>) = Interop.reactElementWithChildren "rp" children

    static member inline rt xs = Interop.createElement "rt" xs
    static member inline rt (value: float) = Interop.reactElementWithChild "rt" value
    static member inline rt (value: int) = Interop.reactElementWithChild "rt" value
    static member inline rt (value: XmlNode) = Interop.reactElementWithChild "rt" value
    static member inline rt (value: string) = Interop.reactElementWithChild "rt" value
    static member inline rt (children: #seq<XmlNode>) = Interop.reactElementWithChildren "rt" children

    static member inline rtc xs = Interop.createElement "rtc" xs
    static member inline rtc (value: float) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (value: int) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (value: XmlNode) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (value: string) = Interop.reactElementWithChild "rtc" value
    static member inline rtc (children: #seq<XmlNode>) = Interop.reactElementWithChildren "rtc" children

    static member inline ruby xs = Interop.createElement "ruby" xs
    static member inline ruby (value: float) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (value: int) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (value: XmlNode) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (value: string) = Interop.reactElementWithChild "ruby" value
    static member inline ruby (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ruby" children

    static member inline s xs = Interop.createElement "s" xs
    static member inline s (value: float) = Interop.reactElementWithChild "s" value
    static member inline s (value: int) = Interop.reactElementWithChild "s" value
    static member inline s (value: XmlNode) = Interop.reactElementWithChild "s" value
    static member inline s (value: string) = Interop.reactElementWithChild "s" value
    static member inline s (children: #seq<XmlNode>) = Interop.reactElementWithChildren "s" children

    static member inline samp xs = Interop.createElement "samp" xs
    static member inline samp (value: float) = Interop.reactElementWithChild "samp" value
    static member inline samp (value: int) = Interop.reactElementWithChild "samp" value
    static member inline samp (value: XmlNode) = Interop.reactElementWithChild "samp" value
    static member inline samp (value: string) = Interop.reactElementWithChild "samp" value
    static member inline samp (children: #seq<XmlNode>) = Interop.reactElementWithChildren "samp" children

    static member inline script xs = Interop.createElement "script" xs
    static member inline script (children: #seq<XmlNode>) = Interop.reactElementWithChildren "script" children

    static member inline section xs = Interop.createElement "section" xs
    static member inline section (children: #seq<XmlNode>) = Interop.reactElementWithChildren "section" children

    static member inline select xs = Interop.createElement "select" xs
    static member inline select (children: #seq<XmlNode>) = Interop.reactElementWithChildren "select" children

    static member inline small xs = Interop.createElement "small" xs
    static member inline small (value: float) = Interop.reactElementWithChild "small" value
    static member inline small (value: int) = Interop.reactElementWithChild "small" value
    static member inline small (value: XmlNode) = Interop.reactElementWithChild "small" value
    static member inline small (value: string) = Interop.reactElementWithChild "small" value
    static member inline small (children: #seq<XmlNode>) = Interop.reactElementWithChildren "small" children

    static member inline source xs = Interop.createElement "source" xs

    static member inline span xs = Interop.createElement "span" xs
    static member inline span (value: float) = Interop.reactElementWithChild "span" value
    static member inline span (value: int) = Interop.reactElementWithChild "span" value
    static member inline span (value: XmlNode) = Interop.reactElementWithChild "span" value
    static member inline span (value: string) = Interop.reactElementWithChild "span" value
    static member inline span (children: #seq<XmlNode>) = Interop.reactElementWithChildren "span" children

    static member inline stop xs = Interop.createElement "stop" xs
    static member inline stop (children: #seq<XmlNode>) = Interop.reactElementWithChildren "stop" children

    static member inline strong xs = Interop.createElement "strong" xs
    static member inline strong (value: float) = Interop.reactElementWithChild "strong" value
    static member inline strong (value: int) = Interop.reactElementWithChild "strong" value
    static member inline strong (value: XmlNode) = Interop.reactElementWithChild "strong" value
    static member inline strong (value: string) = Interop.reactElementWithChild "strong" value
    static member inline strong (children: #seq<XmlNode>) = Interop.reactElementWithChildren "strong" children

    static member inline style xs = Interop.createElement "style" xs
    static member inline style (value: string) = Interop.reactElementWithChild "style" value

    static member inline sub xs = Interop.createElement "sub" xs
    static member inline sub (value: float) = Interop.reactElementWithChild "sub" value
    static member inline sub (value: int) = Interop.reactElementWithChild "sub" value
    static member inline sub (value: XmlNode) = Interop.reactElementWithChild "sub" value
    static member inline sub (value: string) = Interop.reactElementWithChild "sub" value
    static member inline sub (children: #seq<XmlNode>) = Interop.reactElementWithChildren "sub" children

    static member inline summary xs = Interop.createElement "summary" xs
    static member inline summary (value: float) = Interop.reactElementWithChild "summary" value
    static member inline summary (value: int) = Interop.reactElementWithChild "summary" value
    static member inline summary (value: XmlNode) = Interop.reactElementWithChild "summary" value
    static member inline summary (value: string) = Interop.reactElementWithChild "summary" value
    static member inline summary (children: #seq<XmlNode>) = Interop.reactElementWithChildren "summary" children

    static member inline sup xs = Interop.createElement "sup" xs
    static member inline sup (value: float) = Interop.reactElementWithChild "sup" value
    static member inline sup (value: int) = Interop.reactElementWithChild "sup" value
    static member inline sup (value: XmlNode) = Interop.reactElementWithChild "sup" value
    static member inline sup (value: string) = Interop.reactElementWithChild "sup" value
    static member inline sup (children: #seq<XmlNode>) = Interop.reactElementWithChildren "sup" children

    static member inline svg xs = Interop.createElement "svg" xs
    static member inline svg (children: #seq<XmlNode>) = Interop.reactElementWithChildren "svg" children

    static member inline table xs = Interop.createElement "table" xs

    static member inline tableBody xs = Interop.createElement "tbody" xs
    static member inline tableBody (children: #seq<XmlNode>) = Interop.reactElementWithChildren "tbody" children

    static member inline tableCell xs = Interop.createElement "td" xs

    static member inline tableHeader xs = Interop.createElement "th" xs
    static member inline tableHeader (children: #seq<XmlNode>) = Interop.reactElementWithChildren "th" children

    static member inline tableRow xs = Interop.createElement "tr" xs

    static member inline tbody xs = Interop.createElement "tbody" xs
    static member inline tbody (children: #seq<XmlNode>) = Interop.reactElementWithChildren "tbody" children

    static member inline td xs = Interop.createElement "td" xs
    static member inline td (value: float) = Interop.reactElementWithChild "td" value
    static member inline td (value: int) = Interop.reactElementWithChild "td" value
    static member inline td (value: XmlNode) = Interop.reactElementWithChild "td" value
    static member inline td (value: string) = Interop.reactElementWithChild "td" value
    static member inline td (children: #seq<XmlNode>) = Interop.reactElementWithChildren "td" children

    static member inline template xs = Interop.createElement "template" xs
    static member inline template (children: #seq<XmlNode>) = Interop.reactElementWithChildren "template" children

    static member inline text xs = Interop.createElement "text" xs
    static member inline text (value: float) : XmlNode = unbox value
    static member inline text (value: int) : XmlNode = unbox value
    static member inline text (value: string) : XmlNode = unbox value
    static member inline text (value: System.Guid) : XmlNode = unbox (string value)

    static member inline textarea xs = Interop.createElement "textarea" xs
    static member inline textarea (children: #seq<XmlNode>) = Interop.reactElementWithChildren "textarea" children

    static member inline tfoot xs = Interop.createElement "tfoot" xs
    static member inline tfoot (children: #seq<XmlNode>) = Interop.reactElementWithChildren "tfoot" children

    static member inline th xs = Interop.createElement "th" xs
    static member inline th (value: float) = Interop.reactElementWithChild "th" value
    static member inline th (value: int) = Interop.reactElementWithChild "th" value
    static member inline th (value: XmlNode) = Interop.reactElementWithChild "th" value
    static member inline th (value: string) = Interop.reactElementWithChild "th" value
    static member inline th (children: #seq<XmlNode>) = Interop.reactElementWithChildren "th" children

    static member inline thead xs = Interop.createElement "thead" xs
    static member inline thead (children: #seq<XmlNode>) = Interop.reactElementWithChildren "thead" children

    static member inline time xs = Interop.createElement "time" xs
    static member inline time (children: #seq<XmlNode>) = Interop.reactElementWithChildren "time" children

    static member inline title xs = Interop.createElement "title" xs
    static member inline title (value: float) = Interop.reactElementWithChild "title" value
    static member inline title (value: int) = Interop.reactElementWithChild "title" value
    static member inline title (value: XmlNode) = Interop.reactElementWithChild "title" value
    static member inline title (value: string) = Interop.reactElementWithChild "title" value
    static member inline title (children: #seq<XmlNode>) = Interop.reactElementWithChildren "title" children

    static member inline tr xs = Interop.createElement "tr" xs
    static member inline tr (children: #seq<XmlNode>) = Interop.reactElementWithChildren "tr" children

    static member inline track xs = Interop.createElement "track" xs

    static member inline u xs = Interop.createElement "u" xs
    static member inline u (value: float) = Interop.reactElementWithChild "u" value
    static member inline u (value: int) = Interop.reactElementWithChild "u" value
    static member inline u (value: XmlNode) = Interop.reactElementWithChild "u" value
    static member inline u (value: string) = Interop.reactElementWithChild "u" value
    static member inline u (children: #seq<XmlNode>) = Interop.reactElementWithChildren "u" children

    static member inline ul xs = Interop.createElement "ul" xs
    static member inline ul (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ul" children

    static member inline unorderedList xs = Interop.createElement "ul" xs
    static member inline unorderedList (children: #seq<XmlNode>) = Interop.reactElementWithChildren "ul" children

    static member inline var xs = Interop.createElement "var" xs
    static member inline var (value: float) = Interop.reactElementWithChild "var" value
    static member inline var (value: int) = Interop.reactElementWithChild "var" value
    static member inline var (value: XmlNode) = Interop.reactElementWithChild "var" value
    static member inline var (value: string) = Interop.reactElementWithChild "var" value
    static member inline var (children: #seq<XmlNode>) = Interop.reactElementWithChildren "var" children

    static member inline video xs = Interop.createElement "video" xs
    static member inline video (children: #seq<XmlNode>) = Interop.reactElementWithChildren "video" children

    static member inline wbr xs = Interop.createElement "wbr" xs
