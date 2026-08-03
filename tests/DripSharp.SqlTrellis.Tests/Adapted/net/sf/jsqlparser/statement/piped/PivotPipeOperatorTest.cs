// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class PivotPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT \"kale\" AS product, 51 AS sales, \"Q1\" AS quarter\n"), "  UNION ALL\n"), "  SELECT \"kale\" AS product, 4 AS sales, \"Q1\" AS quarter\n"), "  UNION ALL\n"), "  SELECT \"kale\" AS product, 45 AS sales, \"Q2\" AS quarter\n"), "  UNION ALL\n"), "  SELECT \"apple\" AS product, 8 AS sales, \"Q1\" AS quarter\n"), "  UNION ALL\n"), "  SELECT \"apple\" AS product, 10 AS sales, \"Q2\" AS quarter\n"), ")\n"), "|> PIVOT(SUM(sales) FOR quarter IN (\"Q1\", \"Q2\"));");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_1908a1d2ca6288e4()
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
