// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class StructTypeTest {
internal virtual void testStructTypeBigQuery() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT t, len, FORMAT('%T', LPAD(t, len)) AS LPAD FROM UNNEST([\n", "  STRUCT('abc' AS t, 5 AS len),\n"), "  ('abc', 2),\n"), "  ('\u4F8B\u5B50', 4)\n"), "])");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT STRUCT(1, t.str_col)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT STRUCT(1 AS a, 'abc' AS b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT STRUCT<x int64, y string>(1, t.str_col)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testStructTypeDuckDB() {
string sqlStr = "SELECT { t:'abc',len:5}";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT UNNEST({ t:'abc', len:5 })";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT * from (SELECT UNNEST([{ t:'abc', len:5 }]))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT * from (SELECT UNNEST([{ t:'abc', len:5 }, ('abc', 6) ], recursive => true))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testStructTypeConstructorDuckDB()
{
    string sqlStr = "SELECT { t:'abc',len:5}";
    var selectItems = global::DripSharp.Runtime.JavaCompat.ListOf<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>>(new global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>("abc", "t"), new global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>(5, "len"));
    var value = new global::DripSharp.SqlTrellis.Expression.StructType(global::DripSharp.SqlTrellis.Expression.StructType.Dialect.DUCKDB, selectItems);
    var select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().withSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>(value));
    global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, sqlStr, true);
}

internal virtual void testStructTypeWithArgumentsDuckDB() {
string sqlStr = "SELECT { t:'abc',len:5}::STRUCT( t VARCHAR, len INTEGER)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT t, len, LPAD(t, len, ' ') as padded from (\n", "select Unnest([\n"), "  { t:'abc', len: 5}::STRUCT(t VARCHAR, len INTEGER),\n"), "  { t:'abc', len: 5},\n"), "  ('abc', 2),\n"), "  ('\u4F8B\u5B50', 4)\n"), "], \"recursive\" => true))");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_4692d0fbd454834b()
{
        try
        {
            this.testStructTypeBigQuery();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_248cb7605b96132a()
{
        try
        {
            this.testStructTypeConstructorDuckDB();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ad32eddf635b40a1()
{
        try
        {
            this.testStructTypeDuckDB();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fc5728e28925e0df()
{
        try
        {
            this.testStructTypeWithArgumentsDuckDB();
        }
        finally
        {
        }
}
}
