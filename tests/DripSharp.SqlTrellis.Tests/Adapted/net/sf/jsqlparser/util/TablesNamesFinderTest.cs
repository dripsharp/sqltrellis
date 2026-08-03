// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class TablesNamesFinderTest {
public virtual void testGetTables() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM MY_TABLE1, MY_TABLE2, (SELECT * FROM MY_TABLE3) LEFT OUTER JOIN MY_TABLE4 ", " WHERE ID = (SELECT MAX(ID) FROM MY_TABLE5) AND ID2 IN (SELECT * FROM MY_TABLE6)");
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2", "MY_TABLE3", "MY_TABLE4", "MY_TABLE5", "MY_TABLE6");
}

public virtual void testGetTablesWithAlias() {
string sqlStr = "SELECT * FROM MY_TABLE1 as ALIAS_TABLE1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testGetTablesWithXor() {
string sqlStr = "SELECT * FROM MY_TABLE1 WHERE true XOR false";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testGetTablesWithStmt() {
string sqlStr = "WITH TESTSTMT as (SELECT * FROM MY_TABLE1 as ALIAS_TABLE1) SELECT * FROM TESTSTMT";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testGetTablesWithLateral() {
string sqlStr = "SELECT * FROM MY_TABLE1, LATERAL(select a from MY_TABLE2) as AL";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2");
}

public virtual void testGetTablesFromDelete() {
string sqlStr = "DELETE FROM MY_TABLE1 as AL WHERE a = (SELECT a from MY_TABLE2)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2");
}

public virtual void testGetTablesFromDelete2() {
string sqlStr = "DELETE FROM MY_TABLE1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testGetTablesFromTruncate() {
string sqlStr = "TRUNCATE TABLE MY_TABLE1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testGetTablesFromDeleteWithJoin() {
string sqlStr = "DELETE t1, t2 FROM MY_TABLE1 t1 JOIN MY_TABLE2 t2 ON t1.id = t2.id";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2");
}

public virtual void testGetTablesFromInsert() {
string sqlStr = "INSERT INTO MY_TABLE1 (a) VALUES ((SELECT a from MY_TABLE2 WHERE a = 1))";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2");
}

public virtual void testGetTablesFromInsertValues() {
string sqlStr = "INSERT INTO MY_TABLE1 (a) VALUES (5)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testGetTablesFromReplace() {
string sqlStr = "REPLACE INTO MY_TABLE1 (a) VALUES ((SELECT a from MY_TABLE2 WHERE a = 1))";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2");
}

public virtual void testGetTablesFromUpdate() {
string sqlStr = "UPDATE MY_TABLE1 SET a = (SELECT a from MY_TABLE2 WHERE a = 1)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2");
}

public virtual void testGetTablesFromUpdate2() {
string sqlStr = "UPDATE MY_TABLE1 SET a = 5 WHERE 0 < (SELECT COUNT(b) FROM MY_TABLE3)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE3");
}

public virtual void testGetTablesFromUpdate3() {
string sqlStr = "UPDATE MY_TABLE1 SET a = 5 FROM MY_TABLE1 INNER JOIN MY_TABLE2 on MY_TABLE1.C = MY_TABLE2.D WHERE 0 < (SELECT COUNT(b) FROM MY_TABLE3)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1", "MY_TABLE2", "MY_TABLE3");
}

public virtual void testCmplxSelectProblem() {
string sqlStr = "SELECT cid, (SELECT name FROM tbl0 WHERE tbl0.id = cid) AS name, original_id AS bc_id FROM tbl WHERE crid = ? AND user_id is null START WITH ID = (SELECT original_id FROM tbl2 WHERE USER_ID = ?) CONNECT BY prior parent_id = id AND rownum = 1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("tbl0", "tbl", "tbl2");
}

public virtual void testInsertSelect() {
string sqlStr = "INSERT INTO mytable (mycolumn) SELECT mycolumn FROM mytable2";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("mytable", "mytable2");
}

public virtual void testCreateTableSelect() {
string sqlStr = "CREATE TABLE mytable AS SELECT mycolumn FROM mytable2";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("mytable", "mytable2");
}

public virtual void testCreateViewSelect() {
string sqlStr = "CREATE VIEW mytable AS SELECT mycolumn FROM mytable2";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("mytable", "mytable2");
}

public virtual void testInsertSubSelect() {
string sqlStr = "INSERT INTO Customers (CustomerName, Country) SELECT SupplierName, Country FROM Suppliers WHERE Country='Germany'";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("Customers", "Suppliers");
}

public virtual void testExpr() {
string exprStr = "mycol in (select col2 from mytable)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesInExpression(exprStr)).ContainsExactlyInAnyOrder("mytable");
}

public virtual void testOracleHint() {
string sql = "select --+ HINT\ncol2 from mytable";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Expression.OracleHint[] holder = new global::DripSharp.SqlTrellis.Expression.OracleHint[1];
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new Anonymous_188_53(holder);
tablesNamesFinder.getTables((global::DripSharp.SqlTrellis.Statement.Statement)(select!));
global::DripSharp.Testing.JavaAssertions.Null(holder[0], null);
}

private sealed class Anonymous_188_53 : global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> {
private readonly global::DripSharp.SqlTrellis.Expression.OracleHint[] __capture_0;

public Anonymous_188_53(global::DripSharp.SqlTrellis.Expression.OracleHint[] __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<K>(global::DripSharp.SqlTrellis.Expression.OracleHint hint, K parameters) {
base.visit<K>(hint, parameters);
this.__capture_0[0] = hint;
return default!;
}
}

public virtual void testGetTablesIssue194() {
string sql = "SELECT 1";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::System.Collections.Generic.ISet<string> tableList = tablesNamesFinder.getTables(statement);
global::DripSharp.Testing.JavaAssertions.Equal(0, tableList.Count, null);
}

public virtual void testGetTablesIssue284() {
string sqlStr = "SELECT NVL( (SELECT 1 FROM DUAL), 1) AS A FROM TEST1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("DUAL", "TEST1");
}

public virtual void testUpdateGetTablesIssue295() {
string sqlStr = "UPDATE component SET col = 0 WHERE (component_id,ver_num) IN (SELECT component_id,ver_num FROM component_temp)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("component", "component_temp");
}

public virtual void testGetTablesForMerge() {
string sqlStr = "MERGE INTO employees e  USING hr_records h  ON (e.id = h.emp_id) WHEN MATCHED THEN  UPDATE SET e.address = h.address  WHEN NOT MATCHED THEN    INSERT (id, address) VALUES (h.emp_id, h.address);";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("employees", "hr_records");
}

public virtual void testgetTablesForMergeUsingQuery() {
string sqlStr = "MERGE INTO employees e USING (SELECT * FROM hr_records WHERE start_date > ADD_MONTHS(SYSDATE, -1)) h  ON (e.id = h.emp_id)  WHEN MATCHED THEN  UPDATE SET e.address = h.address WHEN NOT MATCHED THEN INSERT (id, address) VALUES (h.emp_id, h.address)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("employees", "hr_records");
}

public virtual void testUpsertValues() {
string sqlStr = "UPSERT INTO MY_TABLE1 (a) VALUES (5)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("MY_TABLE1");
}

public virtual void testUpsertSelect() {
string sqlStr = "UPSERT INTO mytable (mycolumn) SELECT mycolumn FROM mytable2";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("mytable", "mytable2");
}

public virtual void testCaseWhenSubSelect() {
string sqlStr = "select case (select count(*) from mytable2) when 1 then 0 else -1 end";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("mytable2");
}

public virtual void testCaseWhenSubSelect2() {
string sqlStr = "select case when (select count(*) from mytable2) = 1 then 0 else -1 end";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("mytable2");
}

public virtual void testCaseWhenSubSelect3() {
string sqlStr = "select case when 1 = 2 then 0 else (select count(*) from mytable2) end";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("mytable2");
}

public virtual void testExpressionIssue515() {
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> finder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::System.Collections.Generic.ISet<string> tableList = finder.getTables(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("SOME_TABLE.COLUMN = 'A'"));
global::DripSharp.Testing.JavaAssertions.Equal(1, tableList.Count, null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(tableList, "SOME_TABLE"), null);
}

public virtual void testSelectHavingSubquery() {
string sqlStr = "SELECT * FROM TABLE1 GROUP BY COL1 HAVING SUM(COL2) > (SELECT COUNT(*) FROM TABLE2)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("TABLE1", "TABLE2");
}

public virtual void testMySQLValueListExpression() {
string sqlStr = "SELECT * FROM TABLE1 WHERE (a, b) = (c, d)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("TABLE1");
}

public virtual void testSkippedSchemaIssue600() {
string sqlStr = "delete from schema.table where id = 1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("schema.table");
}

public virtual void testCommentTable() {
string sqlStr = "comment on table schema.table is 'comment1'";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("schema.table");
}

public virtual void testCommentColumn() {
string sqlStr = "comment on column schema.table.column1 is 'comment1'";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactly("schema.table");
}

public virtual void testCommentColumn2() {
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = new global::DripSharp.SqlTrellis.Statement.Comment.Comment();
comment.setColumn(new global::DripSharp.SqlTrellis.Schema.Column());
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> finder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::System.Collections.Generic.ISet<string> tableList = finder.getTables(comment);
global::DripSharp.Testing.JavaAssertions.Equal(0, tableList.Count, null);
}

public virtual void testDescribe() {
global::DripSharp.SqlTrellis.Statement.DescribeStatement describe = new global::DripSharp.SqlTrellis.Statement.DescribeStatement(new global::DripSharp.SqlTrellis.Schema.Table("foo", "product"));
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> finder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::System.Collections.Generic.ISet<string> tableList = finder.getTables(describe);
global::DripSharp.Testing.JavaAssertions.Equal(1, tableList.Count, null);
global::DripSharp.Testing.JavaAssertJ.That(tableList).Contains("foo.product");
}

public virtual void testBetween() {
string exprStr = "mycol BETWEEN (select col2 from mytable) AND (select col3 from mytable2)";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesInExpression(exprStr)).ContainsExactlyInAnyOrder("mytable", "mytable2");
}

public virtual void testRemoteLink() {
string sqlStr = "select * from table1@remote";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("table1@remote");
}

public virtual void testCreateSequence_throwsException() {
string sql = "CREATE SEQUENCE my_seq";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::DripSharp.Testing.JavaAssertJ.ThrownBy(() => tablesNamesFinder.getTables(stmt)).IsInstanceOf(typeof(global::System.NotSupportedException)).HasMessage("Finding tables from CreateSequence is not supported");
}

public virtual void testAlterSequence_throwsException() {
string sql = "ALTER SEQUENCE my_seq";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::DripSharp.Testing.JavaAssertJ.ThrownBy(() => tablesNamesFinder.getTables(stmt)).IsInstanceOf(typeof(global::System.NotSupportedException)).HasMessage("Finding tables from AlterSequence is not supported");
}

public virtual void testCreateSynonym_throwsException() {
string sql = "CREATE SYNONYM foo FOR bar";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::DripSharp.Testing.JavaAssertJ.ThrownBy(() => tablesNamesFinder.getTables(stmt)).IsInstanceOf(typeof(global::System.NotSupportedException)).HasMessage("Finding tables from CreateSynonym is not supported");
}

public virtual void testNPEIssue1009() {
string sqlStr = " SELECT * FROM (SELECT * FROM biz_fund_info WHERE tenant_code = ? AND ((ta_code, manager_code) IN ((?, ?)) OR department_type IN (?)))";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("biz_fund_info");
}

public virtual void testAtTimeZoneExpression() {
string sqlStr = "SELECT DATE(date1 AT TIME ZONE 'UTC' AT TIME ZONE 'australia/sydney') AS another_date FROM mytbl";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("mytbl");
}

public virtual void testUsing() {
string sqlStr = "DELETE A USING B.C D WHERE D.Z = 1";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("A", "B.C");
}

public virtual void testJsonFunction() {
string sqlStr = "SELECT JSON_ARRAY(  1, 2, 3 ) FROM mytbl";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("mytbl");
}

public virtual void testJsonAggregateFunction() {
string sqlStr = "SELECT JSON_ARRAYAGG( (SELECT * from dual) FORMAT JSON) FROM mytbl";
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("dual", "mytbl");
}

public virtual void testConnectedByRootOperator() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT CONNECT_BY_ROOT last_name as name", ", salary "), "FROM employees "), "WHERE department_id = 110 "), "CONNECT BY PRIOR employee_id = manager_id");
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr)).ContainsExactlyInAnyOrder("employees");
}

internal virtual void testJoinSubSelect() {
string sqlStr = "select * from A left join B on A.id=B.id and A.age = (select age from C)";
global::System.Collections.Generic.ISet<string> tableNames = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tableNames).ContainsExactlyInAnyOrder("A", "B", "C");
string exprStr = "A.id=B.id and A.age = (select age from C)";
tableNames = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesInExpression(exprStr);
global::DripSharp.Testing.JavaAssertJ.That(tableNames).ContainsExactlyInAnyOrder("A", "B", "C");
}

internal virtual void testRefreshMaterializedView() {
string sqlStr1 = "REFRESH MATERIALIZED VIEW CONCURRENTLY my_view WITH DATA";
global::System.Collections.Generic.ISet<string> tableNames1 = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr1);
global::DripSharp.Testing.JavaAssertJ.That(tableNames1).ContainsExactlyInAnyOrder("my_view");
string sqlStr2 = "REFRESH MATERIALIZED VIEW CONCURRENTLY my_view";
global::System.Collections.Generic.ISet<string> tableNames2 = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr2);
global::DripSharp.Testing.JavaAssertJ.That(tableNames2).ContainsExactlyInAnyOrder("my_view");
string sqlStr3 = "REFRESH MATERIALIZED VIEW my_view";
global::System.Collections.Generic.ISet<string> tableNames3 = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr3);
global::DripSharp.Testing.JavaAssertJ.That(tableNames3).ContainsExactlyInAnyOrder("my_view");
string sqlStr4 = "REFRESH MATERIALIZED VIEW my_view WITH DATA";
global::System.Collections.Generic.ISet<string> tableNames4 = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr4);
global::DripSharp.Testing.JavaAssertJ.That(tableNames4).ContainsExactlyInAnyOrder("my_view");
string sqlStr5 = "REFRESH MATERIALIZED VIEW my_view WITH NO DATA";
global::System.Collections.Generic.ISet<string> tableNames5 = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr5);
global::DripSharp.Testing.JavaAssertJ.That(tableNames5).ContainsExactlyInAnyOrder("my_view");
string sqlStr6 = "REFRESH MATERIALIZED VIEW CONCURRENTLY my_view WITH NO DATA";
global::System.Collections.Generic.ISet<string> tableNames6 = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr6);
global::DripSharp.Testing.JavaAssertJ.That(tableNames6).IsEmpty();
}

internal virtual void testFromParenthesesJoin() {
string sqlStr = "select * from (t1 left join  t2 on t1.id = t2.id) t_select";
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactly("t1", "t2");
}

internal virtual void testOtherSources() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH Datetimes AS (\n", "  SELECT DATETIME '2005-01-03 12:34:56' as datetime UNION ALL\n"), "  SELECT DATETIME '2007-12-31' UNION ALL\n"), "  SELECT DATETIME '2009-01-01' UNION ALL\n"), "  SELECT DATETIME '2009-12-31' UNION ALL\n"), "  SELECT DATETIME '2017-01-02' UNION ALL\n"), "  SELECT DATETIME '2017-05-26'\n"), ")\n"), "SELECT\n"), "  datetime,\n"), "  EXTRACT(ISOYEAR FROM datetime) AS isoyear,\n"), "  EXTRACT(WEEK FROM datetime) AS isoweek,\n"), "  EXTRACT(YEAR FROM datetime) AS year,\n"), "  /*APPROXIMATION: WEEK*/ EXTRACT(WEEK FROM datetime) AS week\n"), "FROM Datetimes\n"), "ORDER BY datetime\n"), ";");
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactly("Datetimes");
}

internal virtual void testSubqueryAliasesIssue1987() {
string sqlStr = "select * from (select * from a) as a1, b;";
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "a1");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b");
global::DripSharp.Testing.JavaAssertJ.That(tables).DoesNotContain("a1");
sqlStr = "select * from b, (select * from a) as a1";
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a1", "a", "b");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b");
global::DripSharp.Testing.JavaAssertJ.That(tables).DoesNotContain("a1");
sqlStr = "SELECT * FROM b, (SELECT * FROM a) as a1 WHERE b.id IN ( SELECT id FROM a1 )";
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a1", "a", "b");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b");
global::DripSharp.Testing.JavaAssertJ.That(tables).DoesNotContain("a1");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select (a_alias.col1), b_alias.col2\n", "from b b_alias, a as a_alias, c join b on c.id = b.id\n"), "where b_alias.id = a_alias.id and c.id = b_alias.id");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("with\n", "temp1 as (( select * from b )),\n"), "temp2 as ( select (((temp1_alias1.id))) from temp1 temp1_alias1 )\n"), "select a_alias.col1, temp1_alias2.col2\n"), "from temp1 temp1_alias2, a as a_alias, temp2 join c c_alias on c_alias.id = temp2.id\n"), "where c.id = temp1_alias2.id");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select a.id, (select max(val) from e) as maxval\n", "from a, (select * from b, (select * from c) c_alias) as bc_nested\n"), "            where a.id in ( select id from bc_nested join (select * from d) d_alias on bc_nested.id = d_alias.id ) \n"), "            and a.max > (select max(val) from bc_nested, f) and a.desc like 'abc'");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c", "d", "e", "f");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(" select (select max(val) from e) as maxval, id\n", "            from  (select * from b, (select * from c) c_alias) as bc_nested, a\n"), "            where a.max > (select max(val) from bc_nested, f) and \n"), "            a.id in ( select id from (select * from d) d_alias join bc_nested on bc_nested.id = d_alias.id )");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c", "d", "e", "f");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select a.id, bc_nested.id\n", "            from (select * from b, (select * from c) c_alias) as bc_nested, a\n"), "            where a.id in (((\n"), "               select id from d join \n"), "                   (select * from bc_nested join \n"), "                       (select * from e) e_alias on bc_nested.id = e_alias.id\n"), "                   ) bc_nested_alias \n"), "                   on bc_nested_alias.id = d.id\n"), "            )))");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c", "d", "e");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select id\n", "from (select * from c, (select * from b) b_alias) as bc_nested, a\n"), "where a.id in (\n"), "select id from (select * from d \n"), "join (select * from e) e_alias on d.id = e_alias.id) bc_nested_alias\n"), "join bc_nested on bc_nested_alias.id = bc_nested.id\n"), ")");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c", "d", "e");
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("with\n", "    temp1 as (\n"), "        select a1.id as id, b.content as content from a a1\n"), "        join b on a1.id = b.id\n"), "    ),\n"), "    temp2 as (\n"), "        select b.id as id, b.value as value from b, c cross join temp1 where\n"), "        b.id = c.id and b.value = \"b.value\"\n"), "    )\n"), "select temp1.id, ( select tid from d where cid = 29974 ) as tid \n"), "from ( select tid from e, (select * from f) where cid = 29974) e_alias, temp1 cross join temp2\n"), "where exist ( select * from e, e_alias where e.test = dtest.test ) and temp1.max = (select max(column_1) from g)");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("a", "b", "c", "d", "e", "f", "g");
}

internal virtual void testSubqueryAliasesIssue2035() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM (SELECT * FROM A) AS A \n", "JOIN B ON A.a = B.a \n"), "JOIN C ON A.a = C.a;");
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("A", "B", "C");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("B", "C");
}

internal virtual void testTableRenamingIssue2028() {
global::System.Collections.Generic.IList<string> IGNORE_SCHEMAS = global::DripSharp.Runtime.JavaCompat.AsList<string>("mysql", "information_schema", "performance_schema");
string prefix = "test_";
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE table_1 a\n", "SET a.a1 = (    SELECT b1\n"), "                FROM table_2 b\n"), "                WHERE b.xx = 'xx' )\n"), "    , a.a2 = (  SELECT b2\n"), "                FROM table_2 b\n"), "                WHERE b.yy = 'yy' )\n"), ";");
string expected = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE test_table_1 a\n", "SET a.a1 = (    SELECT b1\n"), "                FROM test_table_2 b\n"), "                WHERE b.xx = 'xx' )\n"), "    , a.a2 = (  SELECT b2\n"), "                FROM test_table_2 b\n"), "                WHERE b.yy = 'yy' )\n"), ";");
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> finder = new Anonymous_618_42(IGNORE_SCHEMAS, prefix);
finder.init(false);
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
((global::DripSharp.SqlTrellis.Statement.Statement)(statement)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(finder));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(statement, expected, true);
}

private sealed class Anonymous_618_42 : global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> {
private readonly global::System.Collections.Generic.IList<string> __capture_0;

private readonly string __capture_1;

public Anonymous_618_42(global::System.Collections.Generic.IList<string> __capture_0, string __capture_1) {
this.__capture_0 = __capture_0;
this.__capture_1 = __capture_1;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Schema.Table table, S context) {
string schemaName = table.getSchemaName();
if (((schemaName != default!) && global::DripSharp.Runtime.JavaCompat.CollectionContains(this.__capture_0, schemaName.ToLowerInvariant()))) {
return base.visit(table, context);
}
string originTableName = table.getName();
table.setName(global::DripSharp.Runtime.JavaCompat.Concat(this.__capture_1, originTableName));
if (global::DripSharp.Runtime.JavaCompat.StringStartsWith(originTableName, "`")) {
table.setName(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("`", this.__capture_1), originTableName.Replace("`", "", global::System.StringComparison.Ordinal)), "`"));
}
return base.visit(table, context);
}
}

internal virtual void testAlterTableIssue2062() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE the_cool_db.the_table\n", "    ADD test VARCHAR (40)\n"), ";");
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("the_cool_db.the_table");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("the_cool_db.the_table");
}

internal virtual void testInsertTableIssue() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO  the_cool_db.the_table\n", "    VALUES ( 'something' ) \n"), ";");
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTablesOrOtherSources(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("the_cool_db.the_table");
tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("the_cool_db.the_table");
}

internal virtual void testIssue2183() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "\tsubscriber_id,\n"), "\tsum(1) OVER (PARTITION BY subscriber_id\n"), "ORDER BY\n"), "\tstat_time ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW ) AS stop_id\n"), "FROM\n"), "\t(\n"), "\tSELECT\n"), "\t\tsubscriber_id,\n"), "\t\tstat_time\n"), "\tFROM\n"), "\t\tlocation_subscriber AS mid2 WINDOW w AS (PARTITION BY subscriber_id\n"), "\tORDER BY\n"), "\t\tstat_time ROWS BETWEEN 1 PRECEDING AND 1 PRECEDING ) )");
global::System.Collections.Generic.ISet<string> tables = global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>.findTables(sqlStr);
global::DripSharp.Testing.JavaAssertJ.That(tables).ContainsExactlyInAnyOrder("location_subscriber");
}

[Xunit.Fact]
public void __Upstream_b2d7530791154660()
{
        try
        {
            this.testAlterSequence_throwsException();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6b86d9964c2e0c01()
{
        try
        {
            this.testAlterTableIssue2062();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ff7d46bc87b8d81c()
{
        try
        {
            this.testAtTimeZoneExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f2611481a5e11150()
{
        try
        {
            this.testBetween();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_349af036e0d5f58e()
{
        try
        {
            this.testCaseWhenSubSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8a9fc5f7e3ce6ea4()
{
        try
        {
            this.testCaseWhenSubSelect2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cde63e3645599164()
{
        try
        {
            this.testCaseWhenSubSelect3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c2ea6559641419c()
{
        try
        {
            this.testCmplxSelectProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e0bace88115d43db()
{
        try
        {
            this.testCommentColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_42b6c88da39779a9()
{
        try
        {
            this.testCommentColumn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c9725c33c9bf42fd()
{
        try
        {
            this.testCommentTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_951355de1bfc0be3()
{
        try
        {
            this.testConnectedByRootOperator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_14d1b2906d245fd9()
{
        try
        {
            this.testCreateSequence_throwsException();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3a3465616ac86be9()
{
        try
        {
            this.testCreateSynonym_throwsException();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e6311a4993b7d496()
{
        try
        {
            this.testCreateTableSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_753126e2142cde1c()
{
        try
        {
            this.testCreateViewSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d8fc9e2595a9339()
{
        try
        {
            this.testDescribe();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a5e464b11b80dbe8()
{
        try
        {
            this.testExpr();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9f04cb256c74b6a()
{
        try
        {
            this.testExpressionIssue515();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_29cf671da62d0e23()
{
        try
        {
            this.testFromParenthesesJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf653eb362d3a5a7()
{
        try
        {
            this.testGetTables();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_110d4fcbdc9ffd55()
{
        try
        {
            this.testGetTablesForMerge();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d267fa011833219()
{
        try
        {
            this.testGetTablesFromDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5865aa7387f95de6()
{
        try
        {
            this.testGetTablesFromDelete2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cf843be79784d3a2()
{
        try
        {
            this.testGetTablesFromDeleteWithJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ca18d486b51c1e3c()
{
        try
        {
            this.testGetTablesFromInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c0ed09056ff05952()
{
        try
        {
            this.testGetTablesFromInsertValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7e2f213dcb296736()
{
        try
        {
            this.testGetTablesFromReplace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5503c06d85cc588a()
{
        try
        {
            this.testGetTablesFromTruncate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_173b7b61ff9161fe()
{
        try
        {
            this.testGetTablesFromUpdate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_829922c962953e14()
{
        try
        {
            this.testGetTablesFromUpdate2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_075f5bc7659959c2()
{
        try
        {
            this.testGetTablesFromUpdate3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_929a7ce828b5bbbe()
{
        try
        {
            this.testGetTablesIssue194();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c6652379bf80d90d()
{
        try
        {
            this.testGetTablesIssue284();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d91143848a7bdde4()
{
        try
        {
            this.testGetTablesWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2eafdfd5d2e5a172()
{
        try
        {
            this.testGetTablesWithLateral();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_21f82594f4739c72()
{
        try
        {
            this.testGetTablesWithStmt();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cd2b71b8dd974433()
{
        try
        {
            this.testGetTablesWithXor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_67989811704d3cb0()
{
        try
        {
            this.testInsertSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7388ce4e5a7fd77a()
{
        try
        {
            this.testInsertSubSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2881a962510ef62()
{
        try
        {
            this.testInsertTableIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52dd572163aaa67f()
{
        try
        {
            this.testIssue2183();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a18b1bbaac660394()
{
        try
        {
            this.testJoinSubSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e9a95aee37d35766()
{
        try
        {
            this.testJsonAggregateFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1f46e1368397f9f5()
{
        try
        {
            this.testJsonFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_20597a7a6e6f3305()
{
        try
        {
            this.testMySQLValueListExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c811bf56639c537()
{
        try
        {
            this.testNPEIssue1009();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_61cd20ee443a4f5e()
{
        try
        {
            this.testOracleHint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58b19f0f463406aa()
{
        try
        {
            this.testOtherSources();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_23d49c15c5c36a8f()
{
        try
        {
            this.testRefreshMaterializedView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f0154bd4c4b8a367()
{
        try
        {
            this.testRemoteLink();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b4091a4efae5c211()
{
        try
        {
            this.testSelectHavingSubquery();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b084426f3605d3a0()
{
        try
        {
            this.testSkippedSchemaIssue600();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d6da8d8b17904b89()
{
        try
        {
            this.testSubqueryAliasesIssue1987();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58d6217abd897558()
{
        try
        {
            this.testSubqueryAliasesIssue2035();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_97c7cb7cf8712ce2()
{
        try
        {
            this.testTableRenamingIssue2028();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_08e95d5b240f93a3()
{
        try
        {
            this.testUpdateGetTablesIssue295();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f7fade10cffa239d()
{
        try
        {
            this.testUpsertSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c17b40c62320002f()
{
        try
        {
            this.testUpsertValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d2d0b690187e7642()
{
        try
        {
            this.testUsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cf77c49d276339ec()
{
        try
        {
            this.testgetTablesForMergeUsingQuery();
        }
        finally
        {
        }
}
}
