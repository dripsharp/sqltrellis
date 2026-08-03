// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class JoinPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM (\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'bananas' AS item, 5 AS sales\n"), ")\n"), "|> AS produce_sales\n"), "|> LEFT JOIN\n"), "     (\n"), "       SELECT \"apples\" AS item, 123 AS id\n"), "     ) AS produce_data\n"), "   ON produce_sales.item = produce_data.item\n"), "|> SELECT produce_sales.item, sales, id;");
global::DripSharp.SqlTrellis.Statement.Piped.FromQuery fromQuery = (global::DripSharp.SqlTrellis.Statement.Piped.FromQuery)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Piped.AsPipeOperator>(fromQuery.get(0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Piped.JoinPipeOperator>(fromQuery.get(1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Piped.SelectPipeOperator>(fromQuery.get(2), null);
}

[Xunit.Fact]
public void __Upstream_dfc8b3c2bf708624()
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
