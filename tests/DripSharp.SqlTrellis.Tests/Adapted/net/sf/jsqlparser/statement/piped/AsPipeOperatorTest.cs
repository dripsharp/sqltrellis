// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class AsPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT '000123' AS id, 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT '000456' AS id, 'bananas' AS item, 5 AS sales\n"), ") AS sales_table\n"), "|> AGGREGATE SUM(sales) AS total_sales GROUP BY id, item\n"), "|> AS t1\n"), "|> JOIN (SELECT 456 AS id, 'yellow' AS color) AS t2\n"), "   ON CAST(t1.id AS INT64) = t2.id\n"), "|> SELECT t2.id, total_sales, color;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_300bcb41554f73e8()
{
        try
        {
            this.testParseAndDeparse();
        }
        finally
        {
        }
}
}
