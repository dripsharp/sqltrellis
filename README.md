# SqlTrellis — JSqlParser for .NET

JSqlParser for .NET, mechanically translated by DripSharp as an independent project not affiliated with or endorsed by the JSqlParser project.

This is a generated publication repository. Durable source, translation, runtime, and test changes belong in [`dripsharp/dripsharp`](https://github.com/dripsharp/dripsharp) and must be regenerated; do not apply durable manual fixes to generated C# or generated tests here.

## Projects

- [`DripSharp.SqlTrellis`](src/DripSharp.SqlTrellis/DripSharp.SqlTrellis.csproj) — SqlTrellis — JSqlParser for .NET (`net10.0`, version `5.3.0-alpha.1`)

## Install

The first public packages are prereleases. Install the package you need from nuget.org:

```sh
dotnet add package DripSharp.SqlTrellis --version 5.3.0-alpha.1
```


## Build and test

From a clean checkout:

### `DripSharp.SqlTrellis.Tests`

```sh
dotnet restore tests/DripSharp.SqlTrellis.Tests/DripSharp.SqlTrellis.Tests.csproj
dotnet build tests/DripSharp.SqlTrellis.Tests/DripSharp.SqlTrellis.Tests.csproj --configuration Release --no-restore --no-incremental -warnaserror
dotnet test tests/DripSharp.SqlTrellis.Tests/DripSharp.SqlTrellis.Tests.csproj --configuration Release --no-restore --no-build
```

The shipped suites reference only this checkout. See [`tests/README.md`](tests/README.md) for its generated inventory and execution contract.

## Upstream

This generated family translates JSqlParser 5.3 at commit [`8a9479a05c75fcb73d0ed167a822b9b18ab7abaa`](https://github.com/JSQLParser/JSqlParser/tree/8a9479a05c75fcb73d0ed167a822b9b18ab7abaa). Upstream identity and attribution are preserved; this independent .NET translation is not developed, endorsed, or supported by the upstream project.

## License and notices

See [`LICENSE`](LICENSE) for the license and [`NOTICE`](NOTICE) for upstream attribution and the DripSharp translation notice.
