// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class TableFunctionTest {
internal virtual void testLateralFlat() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH t AS (\n", "  SELECT \n"), "    'ABC' AS dim, \n"), "    ARRAY_CONSTRUCT('item1', 'item2', 'item3') AS user_items\n"), ")\n"), "SELECT DIM, count(value) as COUNT_\n"), "FROM t a,\n"), "LATERAL FLATTEN(input => a.user_items) b\n"), "group by 1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testTableFunctionWithNamedParameterWhereNameIsOuterKeyword() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO db.schema.target\n", "     (Name, FriendParent)\n"), " SELECT\n"), "     i.DATA_VALUE:Name AS Name,\n"), "     f1.Value:Parent:Name AS FriendParent\n"), " FROM\n"), "     db.schema.source AS i,\n"), "     lateral flatten(input => i.DATA_VALUE:Friends, outer => true) AS f1;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testTableFunctionWithSupportedWithClauses(string withClause) {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM UNNEST(ARRAY[1, 2, 3]) WITH ", withClause), " AS t(a, b)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_4d259681d27a41d5()
{
        try
        {
            this.testLateralFlat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bef719bc3196ee87()
{
        try
        {
            this.testTableFunctionWithNamedParameterWhereNameIsOuterKeyword();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("OFFSET")]
[Xunit.InlineData("ORDINALITY")]
public void __Upstream_a28389c70aa8a82c(string withClause)
{
        try
        {
            this.testTableFunctionWithSupportedWithClauses(withClause);
        }
        finally
        {
        }
}
}
