namespace Feliz.ViewEngine

open System

//fsharplint:disable

type React =
    /// <summary>
    /// Creates a React function component from a function that accepts a "props" object and renders a result.
    /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    /// </summary>
    /// <param name='render'>A render function that returns an element.</param>
    /// <param name='withKey'>A function to derive a component key from the props.</param>
    static member functionComponent(render: 'props -> ReactElement, ?withKey: 'props -> string) =
        render

    /// <summary>
    /// Creates a React function component from a function that accepts a "props" object and renders a result.
    /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    /// </summary>
    /// <param name='name'>The component name to display in the React dev tools.</param>
    /// <param name='render'>A render function that returns an element.</param>
    /// <param name='withKey'>A function to derive a component key from the props.</param>
    static member functionComponent(name: string, render: 'props -> ReactElement, ?withKey: 'props -> string) =
        render

    /// <summary>
    /// Creates a React function component from a function that accepts a "props" object and renders a result.
    /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    /// </summary>
    /// <param name='render'>A render function that returns a list of elements.</param>
    /// <param name='withKey'>A function to derive a component key from the props.</param>
    static member functionComponent(render: 'props -> #seq<ReactElement>, ?withKey: 'props -> string) =
        render

    /// <summary>
    /// Creates a React function component from a function that accepts a "props" object and renders a result.
    /// A component key can be provided in the props object, or a custom `withKey` function can be provided.
    /// </summary>
    /// <param name='render'>A render function that returns a list of elements.</param>
    /// <param name='name'>The component name to display in the React dev tools.</param>
    /// <param name='withKey'>A function to derive a component key from the props.</param>
    static member functionComponent(name: string, render: 'props -> #seq<ReactElement>, ?withKey: 'props -> string) =
        render
