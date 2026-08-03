// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class AllTableColumnsTest {
internal virtual void testBigQuerySyntax() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT orders.* EXCEPT (order_id) REPLACE (\"widget\" AS item_name), \"more\" as more_fields\n", "FROM orders");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDuckDBSyntax() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT orders.* EXCLUDE (order_id)\n", "FROM orders");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_8e7c32019d38fe5b()
{
        try
        {
            this.testBigQuerySyntax();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bba3edf3f356152e()
{
        try
        {
            this.testDuckDBSyntax();
        }
        finally
        {
        }
}
}
