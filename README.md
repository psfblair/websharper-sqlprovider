# WebSharper + SQLProvider Benchmark

This project is intended for use as one of the frameworks in the TechEmpower Frameworks
Benchmark (http://www.techempower.com/benchmarks/). It uses WebSharper Warp with the
FSharp.Data.SqlProvider type provider, with PostgreSQL as the back-end database.

### Note on working with the type provider: 

Note that for the IDE to find the file--both for IntelliSense autocompletion and for
compilation--the ResolutionPath parameter has to be set to point to the directory
containing the libraries for Postgres (Npgsql.dll and Mono.Security.dll). This project 
assumes these libraries are under the NuGet packages directory hierarchy.

Note also that for working with the type provider, the project references must include 
`System` and `System.Data`.

If you're still having problems, note the following (from the project GitHub page):

    Database vendors other than MS SQL Server use dynamic assembly loading. This may cause 
    some security problems depending on your system's configuration and which version of the 
    .NET framework you are using. If you encounter problems loading dynamic assemblies, they 
    can likely be resolved by applying the following element (`<loadFromRemoteSources>`) into 
    the configuration files of  fsi.exe, devenv.exe and your program or the program using your 
    library : http://msdn.microsoft.com/en-us/library/dd409252(VS.100).aspx

This doesn't seem to be an issue developing in Mono with .NET 4.5.

Here are some other things you might try:

1. In Xamarin Studio, setting the location of the dlls in `Preferences -> Build -> Assembly Folders (Custom folders where Xamarin should look for assemblies and packages)`

2. Using the `gacutil` to put the assemblies into the GAC
