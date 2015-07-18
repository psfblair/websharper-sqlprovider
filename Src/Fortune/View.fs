﻿module Benchmarks.WebSharper.SqlProvider.Fortunes.View

open Benchmarks.WebSharper.SqlProvider.Fortunes.Types

open WebSharper
open WebSharper.Sitelets
open WebSharper.Sitelets.Content
open WebSharper.Html.Server

//TODO This must be (UTF-8) with minimum template starting with !<!DOCTYPE html>
let private tableRowFor (fortune: Fortune): Element =
    let idString = fortune.id.ToString()
    TR [ 
        TD [Text idString]
        TD [Text fortune.message] 
    ]

let private fortunePageBodyFor (fortunes: seq<Fortune>): Element =
    let headerRow = TR [ TH [Text "id"] ; TH [Text "message"] ]
    let bodyRows = fortunes |> Seq.map tableRowFor |> Seq.toList
    Table (headerRow :: bodyRows)

let fortunePageContentFor (fortunes: seq<Fortune>) = 
    { Page.Default with 
        Title = Some "Fortunes" 
        Body = [ fortunePageBodyFor fortunes ]
    }
