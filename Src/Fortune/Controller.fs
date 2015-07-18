﻿module Benchmarks.WebSharper.SqlProvider.Fortune

open Benchmarks.WebSharper.SqlProvider.Fortunes.Types
open Benchmarks.WebSharper.SqlProvider.Fortunes.Data
open Benchmarks.WebSharper.SqlProvider.Fortunes.View

open WebSharper
open WebSharper.Sitelets
open WebSharper.Sitelets.Content
open System

let private additionalFortune = { id = 0; message = "Additional fortune added at request time." }

//Would like this to be private but want to test it
let internal fortunes = seq { yield additionalFortune }
                        |> Seq.append allFortunes
                        |> Seq.sortBy (fun fortune -> fortune.message)

let fortuneContent context = async { return fortunePageContentFor fortunes }
