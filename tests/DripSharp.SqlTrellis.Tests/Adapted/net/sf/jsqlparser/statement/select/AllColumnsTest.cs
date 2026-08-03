// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class AllColumnsTest {
internal virtual void testBigQuerySyntax() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * EXCEPT(order_id) REPLACE(\"widget\" AS item_name), \"more\" as more_fields\n", "FROM orders");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDuckDBQuerySyntax() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * EXCLUDE(order_id) REPLACE(\"widget\" AS item_name), \"more\" as more_fields\n", "FROM orders");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_38945b29012ae2e6()
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
public void __Upstream_a5c0365900430522()
{
        try
        {
            this.testDuckDBQuerySyntax();
        }
        finally
        {
        }
}
}
