# Generated test suites

These test suites are generated from the authoritative `dripsharp/dripsharp` target contract. Do not apply durable manual fixes in a generated product repository.

From a clean sqltrellis product-repository checkout:

### `DripSharp.SqlTrellis.Tests`

```sh
dotnet restore tests/DripSharp.SqlTrellis.Tests/DripSharp.SqlTrellis.Tests.csproj
dotnet build tests/DripSharp.SqlTrellis.Tests/DripSharp.SqlTrellis.Tests.csproj --configuration Release --no-restore --no-incremental -warnaserror
dotnet test tests/DripSharp.SqlTrellis.Tests/DripSharp.SqlTrellis.Tests.csproj --configuration Release --no-restore --no-build
```

The project references only paths within this checkout. Its test host permits major-version roll-forward so a later .NET runtime can exercise an earlier-targeted product family. `SHA256SUMS` inventories every generated test file except the inventory itself.
Each declared strategy records whether its output is shipped or validation-only; validation-only project paths are excluded from publication by the target contract.
