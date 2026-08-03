// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class DuckDBTest {
internal virtual void testFileTable() {
string sqlStr = "SELECT * FROM '/tmp/test.parquet'";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.SqlTrellis.Schema.Table table = (global::DripSharp.SqlTrellis.Schema.Table)(select.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Equal("'/tmp/test.parquet'", table.getName(), null);
}

[Xunit.Fact]
public void __Upstream_9ab1641e6cbd6bc5()
{
        try
        {
            this.testFileTable();
        }
        finally
        {
        }
}
}
