module Benchmarks.WebSharper.SqlProvider.Data

open System
open FSharp.Data.Sql

type Db = SqlDataProvider<DatabaseVendor    = Common.DatabaseProviderTypes.POSTGRESQL, 
                          ConnectionString  = "Host=127.0.0.1;Port=5432;Database=hello_world;Username=benchmarkdbuser;Password=benchmarkdbpass;Pooling=true;MinPoolSize=5;MaxPoolSize=20",
                          ResolutionPath    = "packages/Npgsql/lib/net45/",
                          UseOptionTypes    = true>
