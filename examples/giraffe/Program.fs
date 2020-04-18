module examples.App

open System
open Giraffe

open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Microsoft.AspNetCore.Builder
open Microsoft.Extensions.Logging
open Microsoft.AspNetCore

open Feliz.Giraffe

// ---------------------------------
// Models
// ---------------------------------

type Message =
    {
        Text : string
    }

// ---------------------------------
// Views
// ---------------------------------

module Views =
    let layout (content: XmlNode list) =
        Html.html [
            Html.head [
                Html.title [ prop.text "examples" ]
                Html.link [
                    prop.rel  "stylesheet"
                    prop.type' "text/css"
                    prop.href "/main.css"
                ]
            ]
            Html.body [
                prop.style [ style.fontFamily("Arial, Helvetica, sans-serif"); style.color("#333") ]
                prop.children content
            ]
        ]

    let partial () =
        Html.h1 [
            prop.style [ style.fontSize(100); style.color("#137373") ]
            prop.text "examples"
        ]

    let index (model : Message) =
        [
            partial ()
            Html.p [ Html.text model.Text ]
        ] |> layout

// ---------------------------------
// Web app
// ---------------------------------

let indexHandler (name : string) =
    let greetings = sprintf "Hello %s, from Giraffe!" name
    let model     = { Text = greetings }
    let view      = Views.index model
    htmlView view

let webApp : HttpHandler =
    choose [
        GET >=>
            choose [
                route "/" >=> indexHandler "world"
                routef "/hello/%s" indexHandler
            ]
        setStatusCode 404 >=> text "Not Found" ]

type Startup() =
    member __.ConfigureServices (services : IServiceCollection) =
        // Register default Giraffe dependencies
        services.AddGiraffe() |> ignore

    member __.Configure (app: IApplicationBuilder) (env: IWebHostEnvironment) (loggerFactory: ILoggerFactory) =
        // Add Giraffe to the ASP.NET Core pipeline
        app.UseGiraffe webApp

let port = 8080
[<EntryPoint>]
let main _ =
    WebHost
        .CreateDefaultBuilder()
        .UseStartup<Startup>()
        .UseUrls("http://0.0.0.0:" + port.ToString () + "/")
        .Build()
        .Run()

    0