module Benchmarks.WebSharper.SqlProvider.Worlds.Data

open Benchmarks.WebSharper.SqlProvider.Data
open Benchmarks.WebSharper.SqlProvider.Worlds.Types
open System

(* ********************************************* PRIVATE ************************************************ *)
let private next (random: Random) = random.Next(1, 10000)

let private singleQueryFromWorld (dataContext: Db.dataContext) id = 
    query {
       for row in dataContext.``[PUBLIC].[WORLD]`` do  
       where (row.ID = id)
       select { id = row.ID; randomNumber = row.RANDOMNUMBER }
    } |> Seq.head


let private singleRandomQueryFromWorld (dataContext: Db.dataContext) (random: Random) =
    next random |> singleQueryFromWorld dataContext


let private updateSingleWorldRecord (dataContext: Db.dataContext) id update = 
    let record = query {
                   for row in dataContext.``[PUBLIC].[WORLD]`` do  
                   where (row.ID = id)
                 } |> Seq.head

    let oldRandom = record.RANDOMNUMBER    // Make sure record is actually fetched
    if update <> oldRandom then            // SQLProvider doesn't like it if we update unchanged rows.
        record.RANDOMNUMBER <- update
        dataContext.SubmitUpdates()
    { id = id; randomNumber = update }


let private updateRandomWorldRecordWithRandomValue (dataContext: Db.dataContext) (random: Random) = 
    let key: int = next random
    next random |> updateSingleWorldRecord dataContext key 


(* ********************************************* PUBLIC ************************************************ *)
let worldWithId (id: int): World =  id |> singleQueryFromWorld (Db.GetDataContext())

let worldForRandomId (random: Random): World =  next random |> singleQueryFromWorld (Db.GetDataContext())

let multipleRandomWorlds (random: Random) (numberOfQueries: int): Async<array<World>> = 
        Async.Parallel [ for i in 1..numberOfQueries -> 
                                        async { 
                                                return random |> singleRandomQueryFromWorld (Db.GetDataContext()) 
                                        }]

let updateWorldWithId (id: int) (update: int): World = updateSingleWorldRecord (Db.GetDataContext()) id update

let updateMultipleRandomWorldsWithRandomValues (random: Random) (numberOfQueries: int): Async<array<World>> =
        Async.Parallel [ for i in 1..numberOfQueries -> 
                                        async { 
                                                return random |> updateRandomWorldRecordWithRandomValue (Db.GetDataContext()) 
                                        }]