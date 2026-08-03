// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class SelectPipeOperatorTest {
internal virtual void testRename() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT 1 AS x, 2 AS y, 3 AS z\n", "|> AS t\n"), "|> RENAME y AS renamed_y\n"), "|> SELECT *, t.y AS t_y;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDistinct() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM orders\n", "|> WHERE order_date >= '2024-01-01'\n"), "|> SELECT DISTINCT customer_id \n"), "|> INNER JOIN customers USING(customer_id)\n"), "|> SELECT *;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_fb81a779ddecc4ea()
{
        try
        {
            this.testDistinct();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9eed832e3f640d0d()
{
        try
        {
            this.testRename();
        }
        finally
        {
        }
}
}
