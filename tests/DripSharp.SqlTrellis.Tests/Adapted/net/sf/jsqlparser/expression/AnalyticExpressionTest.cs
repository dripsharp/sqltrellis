// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class AnalyticExpressionTest {
internal virtual void testRedshiftApproximate() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select top 10 date.caldate,\n", "count(totalprice), sum(totalprice),\n"), "approximate percentile_disc(0.5) \n"), "within group (order by totalprice)\n"), "from listing\n"), "join date on listing.dateid = date.dateid\n"), "group by date.caldate\n"), "order by 3 desc;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "select approximate count(distinct pricepaid) from sales;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDatabricks() {
string sqlStr = "SELECT any_value(col) IGNORE NULLS FROM test;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT any_value(col) IGNORE NULLS FROM VALUES (NULL), (5), (20) AS tab(col);";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_0347c1562d4cfce7()
{
        try
        {
            this.testDatabricks();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_baa2864dbd6120f6()
{
        try
        {
            this.testRedshiftApproximate();
        }
        finally
        {
        }
}
}
