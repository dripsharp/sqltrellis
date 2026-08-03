// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class WindowFunctionTest {
public virtual void testListAggOverIssue1652() {
string sqlString = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    LISTAGG (d.COL_TO_AGG, ' / ') WITHIN GROUP (ORDER BY d.COL_TO_AGG) OVER (PARTITION BY d.PART_COL) AS MY_LISTAGG\n"), "FROM cte_dummy_data d");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

public virtual void RedshiftRespectIgnoreNulls() {
string sqlString = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select venuestate, venueseats, venuename,\n", "first_value(venuename) ignore nulls\n"), "over(partition by venuestate\n"), "order by venueseats desc\n"), "rows between unbounded preceding and unbounded following) AS first\n"), "from (select * from venue where venuestate='CA')\n"), "order by venuestate;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

[Xunit.Fact]
public void __Upstream_baa39354859b0662()
{
        try
        {
            this.RedshiftRespectIgnoreNulls();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f09d3080e24fd86d()
{
        try
        {
            this.testListAggOverIssue1652();
        }
        finally
        {
        }
}
}
