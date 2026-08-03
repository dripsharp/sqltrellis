// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class BigQueryTest {
internal virtual void testTrailingComma() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH\n", "  Products AS (\n"), "    SELECT 'shirt' AS product_type, 't-shirt' AS product_name, 3 AS product_count UNION ALL\n"), "    SELECT 'shirt', 't-shirt', 8 UNION ALL\n"), "    SELECT 'shirt', 'polo', 25 UNION ALL\n"), "    SELECT 'pants', 'jeans', 6\n"), "  )\n"), "SELECT\n"), "  product_type,\n"), "  product_name,\n"), "  SUM(product_count) AS product_sum,\n"), "  GROUPING(product_type) AS product_type_agg,\n"), "  GROUPING(product_name) AS product_name_agg,\n"), "FROM Products\n"), "GROUP BY GROUPING SETS(product_type, product_name, ())\n"), "ORDER BY product_name, product_type");
}

internal virtual void testAggregateFunctionIgnoreNulls() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT ARRAY_AGG(x IGNORE NULLS) AS array_agg\n", "FROM UNNEST([NULL, 1, -2, 3, -2, 1, NULL]) AS x");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testAggregateFunctionLimit() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT ARRAY_AGG(x LIMIT 5) AS array_agg\n", "FROM UNNEST([2, 1, -2, 3, -2, 1, 2]) AS x;\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testAny() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "  fruit,\n"), "  ANY_VALUE(fruit) OVER (ORDER BY LENGTH(fruit) ROWS BETWEEN 1 PRECEDING AND CURRENT ROW) AS any_value\n"), "FROM UNNEST(['apple', 'banana', 'pear']) as fruit;\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testAggregateFunctionHaving() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH\n", "  Store AS (\n"), "    SELECT 20 AS sold, \"apples\" AS fruit\n"), "    UNION ALL\n"), "    SELECT 30 AS sold, \"pears\" AS fruit\n"), "    UNION ALL\n"), "    SELECT 30 AS sold, \"bananas\" AS fruit\n"), "    UNION ALL\n"), "    SELECT 10 AS sold, \"oranges\" AS fruit\n"), "  )\n"), "SELECT ANY_VALUE(fruit HAVING MAX sold) AS a_highest_selling_fruit FROM Store;\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testAsStruct() {
string sqlStr = "SELECT ARRAY(SELECT AS STRUCT 1 a, 2 b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testAsValue() {
string sqlStr = "SELECT AS VALUE STRUCT(1 AS a, 2 AS b) xyz";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testTimeSeriesFunction() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("with raw_data as (\n", "    select timestamp('2024-12-01') zetime\n"), "    union all \n"), "    select timestamp('2024-12-04')\n"), "  )\n"), "select zetime from GAP_FILL(\n"), "  TABLE raw_data,\n"), "  ts_column => 'zetime',\n"), "  bucket_width => INTERVAL 4 HOUR\n"), ")");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.SqlTrellis.Statement.Select.TableFunction function = select.getFromItem<global::DripSharp.SqlTrellis.Statement.Select.TableFunction>(typeof(global::DripSharp.SqlTrellis.Statement.Select.TableFunction));
global::DripSharp.Testing.JavaAssertions.Equal("TABLE", function.getFunction().getExtraKeyword(), null);
}

[Xunit.Fact]
public void __Upstream_4ac9f7cab7c75e99()
{
        try
        {
            this.testAggregateFunctionHaving();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b1d3bf0b321bafc8()
{
        try
        {
            this.testAggregateFunctionIgnoreNulls();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0ed1b5e1d075ace9()
{
        try
        {
            this.testAggregateFunctionLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5190d6bd93f3e2b7()
{
        try
        {
            this.testAny();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_169801d0589ea77f()
{
        try
        {
            this.testAsStruct();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b6c864c8cee3200()
{
        try
        {
            this.testAsValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_19348c3a077487b4()
{
        try
        {
            this.testTimeSeriesFunction();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_9c2fa08832ff1b5b()
{
        try
        {
            this.testTrailingComma();
        }
        finally
        {
        }
}
}
