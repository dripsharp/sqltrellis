// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class FromQueryTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM Produce\n", "|> WHERE\n"), "    item != 'bananas'\n"), "    AND category IN ('fruit', 'nut')\n"), "|> AGGREGATE COUNT(*) AS num_items, SUM(sales) AS total_sales\n"), "   GROUP BY item\n"), "|> ORDER BY item DESC;");
global::DripSharp.SqlTrellis.Statement.Piped.FromQuery fromQuery = (global::DripSharp.SqlTrellis.Statement.Piped.FromQuery)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Piped.WherePipeOperator>(fromQuery.get(0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Piped.AggregatePipeOperator>(fromQuery.get(1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Piped.OrderByPipeOperator>(fromQuery.get(2), null);
}

internal virtual void testParseAndDeparseJoin() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM Produce INNER JOIN Price USING(id_product) \n", "|> WHERE\n"), "    item != 'bananas'\n"), "    AND category IN ('fruit', 'nut')\n"), "|> AGGREGATE COUNT(*) AS num_items, SUM(sales) AS total_sales\n"), "   GROUP BY item\n"), "|> ORDER BY item DESC;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testParseAndDeparseWithIssue73() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("with client_info as (\n", "  with client as (\n"), "    select 1 as client_id\n"), "    |> UNION ALL\n"), "      (select 2),\n"), "      (select 3)\n"), "  ), basket as (\n"), "    select 1 as basket_id, 1 as client_id\n"), "    |> UNION ALL\n"), "      (select 2, 2)\n"), "  ), basket_item as (\n"), "    select 1 as item_id, 1 as basket_id\n"), "    |> UNION ALL\n"), "      (select 2, 1),\n"), "      (select 3, 1),\n"), "      (select 4, 2)\n"), "  ), item as (\n"), "    select 1 as item_id, 'milk' as name\n"), "    |> UNION ALL\n"), "      (select 2, \"chocolate\"),\n"), "      (select 3, \"donut\"),\n"), "      (select 4, \"croissant\")\n"), "  ), wrapper as (\n"), "    FROM client c\n"), "    |> aggregate count(i.item_id) as bought_item\n"), "       group by c.client_id, i.item_id, i.name\n"), "    |> aggregate array_agg((select as struct item_id, name, bought_item)) as items_info\n"), "       group by client_id\n"), "  )\n"), "  select * from wrapper\n"), ")\n"), "select * from client_info");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testParseAndDeparseWithJoinIssue72() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("with client as (\n", "  select 1 as client_id\n"), "  |> UNION ALL\n"), "    (select 2),\n"), "    (select 3)\n"), "), basket as (\n"), "  select 1 as basket_id, 1 as client_id\n"), "  |> UNION ALL\n"), "    (select 2, 2)\n"), "), basket_item as (\n"), "  select 1 as item_id, 1 as basket_id\n"), "  |> UNION ALL\n"), "    (select 2, 1),\n"), "    (select 3, 1),\n"), "    (select 4, 2)\n"), "), item as (\n"), "  select 1 as item_id, 'milk' as name\n"), "  |> UNION ALL\n"), "    (select 2, \"chocolate\"),\n"), "    (select 3, \"donut\"),\n"), "    (select 4, \"croissant\")\n"), ")\n"), "FROM client c\n"), "  left join basket b using(client_id)\n"), "  left join basket_item bi using(basket_id)\n"), "  left join item i on i.item_id = bi.item_id\n"), "|> aggregate count(i.item_id) as bought_item\n"), "   group by c.client_id, i.item_id, i.name\n"), "|> aggregate array_agg((select as struct item_id, name, bought_item)) as items_info\n"), "   group by client_id");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testParseAndDeparseIssue74() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM\n", "  Produce AS p1\n"), "  JOIN Produce AS p2\n"), "    USING (item)\n"), "|> WHERE item = 'bananas'\n"), "|> SELECT p1.item, p2.sales;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> EXTEND item IN ('carrots', 'oranges') AS is_orange;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'bananas' AS item, 5 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> EXTEND SUM(sales) OVER() AS total_sales;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 1 AS x, 11 AS y\n"), "  UNION ALL\n"), "  SELECT 2 AS x, 22 AS y\n"), ")\n"), "|> SET x = x * x, y = 3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT \"000123\" AS id, \"apples\" AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT \"000456\" AS id, \"bananas\" AS item, 5 AS sales\n"), ") AS sales_table\n"), "|> AGGREGATE SUM(sales) AS total_sales GROUP BY id, item\n"), "-- The sales_table alias is now out of scope. We must introduce a new one.\n"), "|> AS t1\n"), "|> JOIN (SELECT 456 AS id, \"yellow\" AS color) AS t2\n"), "   ON CAST(t1.id AS INT64) = t2.id\n"), "|> SELECT t2.id, total_sales, color;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'bananas' AS item, 5 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> WHERE sales >= 3;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM Produce\n", "|> AGGREGATE SUM(sales) AS total_sales ASC\n"), "   GROUP BY item, category DESC;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM UNNEST(ARRAY<INT64>[1, 2, 3]) AS number\n", "|> UNION ALL (SELECT 1);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH\n", "  NumbersTable AS (\n"), "    SELECT 1 AS one_digit, 10 AS two_digit\n"), "    UNION ALL\n"), "    SELECT 2, 20\n"), "    UNION ALL\n"), "    SELECT 3, 30\n"), "  )\n"), "SELECT one_digit, two_digit FROM NumbersTable\n"), "|> INTERSECT ALL BY NAME\n"), "    (SELECT 10 AS two_digit, 1 AS one_digit);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testParseAndDeparseNestedWithIssue2168() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("with b as (\n", "    with a as (select 1)\n"), "    from a )\n"), "from b\n"), ";");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_766aca4dd67f8aa8()
{
        try
        {
            this.testParseAndDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b381a8d47c01af6f()
{
        try
        {
            this.testParseAndDeparseIssue74();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6f78351c633659c7()
{
        try
        {
            this.testParseAndDeparseJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_632c6ed37c182ee4()
{
        try
        {
            this.testParseAndDeparseNestedWithIssue2168();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_85dd831247db9131()
{
        try
        {
            this.testParseAndDeparseWithIssue73();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d5b3a18c766b4bdc()
{
        try
        {
            this.testParseAndDeparseWithJoinIssue72();
        }
        finally
        {
        }
}
}
