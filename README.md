# WebSharper + SQLProvider Benchmark

This project is intended for use as one of the frameworks in the TechEmpower Frameworks
Benchmark (http://www.techempower.com/benchmarks/). It uses WebSharper Warp with the
FSharp.Data.SqlProvider type provider, with PostgreSQL as the back-end database.

## Note on working with the type provider: 
With this provider, using database vendors other than MS SQL Server requires dynamic assembly 
loading. This may cause security issues depending on your system configuration and .NET version. 
Some of these problems can be resolved by applying the <loadFromRemoteSources> element into the 
configuration files of fsi.exe, devenv.exe and the executable. See: 
http://msdn.microsoft.com/en-us/library/dd409252(VS.100).aspx

This project was built using Xamarin Studio on Mono/OS X. Up until now, successful builds with the 
type provider has required that the Npgsql and Mono.Security DLLs reside at the root level of
the project. For IntelliSense, the libraries had to be copied into the
/Applications/Xamarin Studio.app/Contents/Resources/lib/monodevelop/bin directory.

The following alternative approaches didn't work:
1. In Xamarin Studio, setting the location of the dlls in Preferences -> Build -> Assembly Folders (Custom folders where Xamarin should look for assemblies and packages)
2. Using the gacutil to put the assemblies into the GAC
3. Placing the <loadFromRemoteSources> element in the config files of the IDE (XamarinStudio.exe.config) in Xamarin Studio.app/Contents/Resources/lib/monodevelop/bin/XamarinStudio.exe.config
4. Calling System.Reflection.Assembly.UnsafeLoadFrom from inside the code before the type provider is invoked.

Note also that for working with the type provider, the project references must include System and System.Data.
