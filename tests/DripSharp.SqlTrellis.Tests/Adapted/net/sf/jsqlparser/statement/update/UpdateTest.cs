// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Update;

public class UpdateTest {
private static readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager PARSER_MANAGER = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testUpdate() {
string statement = "UPDATE mytable set col1='as', col2=?, col3=565 Where o >= 3";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Statement.Update.UpdateTest.PARSER_MANAGER.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", update.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(update.getUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 2).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("as", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.StringValue>(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getValues(), 0))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getValues(), 0) is global::DripSharp.SqlTrellis.Expression.JdbcParameter), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(565), (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 2).getValues(), 0))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.True((update.getWhere() is global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThanEquals), null);
}

public virtual void testUpdateWAlias() {
string statement = "UPDATE table1 A SET A.columna = 'XXX' WHERE A.cod_table = 'YYY'";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Statement.Update.UpdateTest.PARSER_MANAGER.parse(new global::System.IO.StringReader(statement))!);
}

public virtual void testUpdateWithDeparser() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE table1 AS A SET A.columna = 'XXX' WHERE A.cod_table = 'YYY'");
}

public virtual void testUpdateWithFrom() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE table1 SET columna = 5 FROM table1 LEFT JOIN table2 ON col1 = col2");
}

public virtual void testUpdateMultiTable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE T1, T2 SET T1.C2 = T2.C2, T2.C3 = 'UPDATED' WHERE T1.C1 = T2.C1 AND T1.C2 < 10");
}

public virtual void testUpdateWithSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE NATION SET (N_NATIONKEY) = (SELECT ? FROM SYSIBM.SYSDUMMY1)");
}

public virtual void testUpdateWithSelect2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE mytable SET (col1, col2, col3) = (SELECT a, b, c FROM mytable2)");
}

public virtual void testUpdateIssue167_SingleQuotes() {
string sqlStr = "UPDATE tablename SET NAME = 'Customer 2', ADDRESS = 'Address \\' ddad2', AUTH_KEY = 'samplekey' WHERE ID = 2";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testUpdateWithLimit() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 LIMIT 10");
}

public virtual void testUpdateWithOrderBy() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 ORDER BY col");
}

public virtual void testUpdateWithOrderByAndLimit() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 ORDER BY col LIMIT 10");
}

public virtual void testUpdateWithReturningAll() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 ORDER BY col LIMIT 10 RETURNING *");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 RETURNING *");
}

public virtual void testUpdateWithReturningList() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 ORDER BY col LIMIT 10 RETURNING col_1, col_2, col_3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 RETURNING col_1, col_2, col_3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 ORDER BY col LIMIT 10 RETURNING col_1 AS Bar, col_2 AS Baz, col_3 AS Foo");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 RETURNING col_1 AS Bar, col_2 AS Baz, col_3 AS Foo");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = 'thing' WHERE id = 1 RETURNING ABS(col_1) AS Bar, ABS(col_2), col_3 AS Foo");
}

public virtual void testUpdateDoesNotAllowLimitOffset() {
string statement = "UPDATE table1 A SET A.columna = 'XXX' WHERE A.cod_table = 'YYY' LIMIT 3,4";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Statement.Update.UpdateTest.PARSER_MANAGER.parse(new global::System.IO.StringReader(statement)), null);
}

public virtual void testUpdateWithFunctions() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tablename SET col = SUBSTRING(col2, 1, 2)");
}

public virtual void testUpdateIssue508LeftShift() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE user SET num = 1 << 1 WHERE id = 1");
}

public virtual void testUpdateIssue338() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE mytable SET status = (status & ~1)");
}

public virtual void testUpdateIssue338_1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE mytable SET status = (status & 1)");
}

public virtual void testUpdateIssue338_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE mytable SET status = (status + 1)");
}

public virtual void testUpdateIssue826() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("update message_topic inner join message_topic_config on\n", " message_topic.id=message_topic_config.topic_id \n"), "set message_topic_config.enable_flag='N', \n"), "message_topic_config.updated_by='test', \n"), "message_topic_config.update_at='2019-07-16' \n"), "where message_topic.name='test' \n"), "AND message_topic_config.enable_flag='Y'"), true);
}

public virtual void testUpdateIssue750() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("update a,(select * from c) b set a.id=b.id where a.id=b.id", true);
}

public virtual void testUpdateIssue962Validate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE tbl_user_card SET validate = '1', identityCodeFlag = 1 WHERE id = 9150000293816");
}

public virtual void testUpdateVariableAssignment() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPDATE transaction_id SET latest_id_wallet = (@cur_id_wallet := latest_id_wallet) + 1");
}

public virtual void testOracleHint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("UPDATE /*+ SOMEHINT */ mytable set col1='as', col2=?, col3=565 Where o >= 3", true, "SOMEHINT");
}

public virtual void testMysqlHint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertUpdateMysqlHintExists("UPDATE demo FORCE INDEX (idx_demo) SET col1 = NULL WHERE col2 = 1", true, "FORCE", "INDEX", "idx_demo");
}

public virtual void testWith() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "WITH a\n"), "     AS (SELECT 1 id_instrument_ref)\n"), "     , b\n"), "       AS (SELECT 1 id_instrument_ref)\n"), "UPDATE cfe.instrument_ref\n"), "SET id_instrument=null\n"), "WHERE  id_instrument_ref = (SELECT id_instrument_ref\n"), "                            FROM   a)");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = update.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("cfe.instrument_ref", update.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT 1 id_instrument_ref", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT 1 id_instrument_ref", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" b", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(update.getUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("id_instrument", global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumn(0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("NULL", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getValue(0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("id_instrument_ref = (SELECT id_instrument_ref FROM a)", global::DripSharp.Runtime.JavaCompat.StringValueOf(update.getWhere()), null);
}

public virtual void testUpdateSetsIssue1316() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("update test\n", "set (a, b) = (select '1', '2')");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("update test\n", "set a = '1'"), "    , b = '2'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("update test\n", "set (a, b) = ('1', '2')");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("update test\n", "set (a, b) = (values ('1', '2'))");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("update test\n", "set (a, b) = (1, (select 2))");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE prpjpaymentbill b\n", "SET (   b.packagecode\n"), "        , b.packageremark\n"), "        , b.agentcode ) =   (   SELECT  p.payrefreason\n"), "                                        , p.classcode\n"), "                                        , p.riskcode\n"), "                                FROM prpjcommbill p\n"), "                                WHERE p.policertiid = 'SDDH200937010330006366' ) -- this is supposed to be UpdateSet 1\n"), "     , b.payrefnotype = '05' -- this is supposed to be UpdateSet 2\n"), "     , b.packageunit = '4101170402' -- this is supposed to be UpdateSet 3\n"), "WHERE b.payrefno = 'B370202091026000005'");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(update.getUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getValues()), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getValues()), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 2).getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 2).getValues()), null);
}

public virtual void testUpdateLowPriority() {
string stmt = "UPDATE LOW_PRIORITY table1 A SET A.columna = 'XXX'";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(update.getModifierPriority(), global::DripSharp.SqlTrellis.Statement.Update.UpdateModifierPriority.LOW_PRIORITY, null);
}

public virtual void testUpdateIgnoreModifier() {
string stmt = "UPDATE IGNORE table1 A SET A.columna = 'XXX'";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.True(update.isModifierIgnore(), null);
string stmt2 = "UPDATE table1 A SET A.columna = 'XXX'";
global::DripSharp.SqlTrellis.Statement.Update.Update update2 = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2)!);
global::DripSharp.Testing.JavaAssertions.False(update2.isModifierIgnore(), null);
}

public virtual void testUpdateMultipleModifiers() {
string stmt = "UPDATE LOW_PRIORITY IGNORE table1 A SET A.columna = 'XXX'";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(update.getModifierPriority(), global::DripSharp.SqlTrellis.Statement.Update.UpdateModifierPriority.LOW_PRIORITY, null);
global::DripSharp.Testing.JavaAssertions.True(update.isModifierIgnore(), null);
}

public virtual void testUpdateOutputClause() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE /* TOP (10) */ HumanResources.Employee  \n", "SET VacationHours = VacationHours * 1.25,  \n"), "    ModifiedDate = GETDATE()   \n"), "OUTPUT inserted.BusinessEntityID,  \n"), "       deleted.VacationHours,  \n"), "       inserted.VacationHours,  \n"), "       inserted.ModifiedDate  \n"), "INTO @MyTableVar"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE Production.WorkOrder  \n", "SET ScrapReasonID = 4  \n"), "OUTPUT deleted.ScrapReasonID,  \n"), "       inserted.ScrapReasonID,   \n"), "       inserted.WorkOrderID,  \n"), "       inserted.ProductID,  \n"), "       p.Name  \n"), "    INTO @MyTestVar  \n"), "FROM Production.WorkOrder AS wo  \n"), "    INNER JOIN Production.Product AS p   \n"), "    ON wo.ProductID = p.ProductID   \n"), "    AND wo.ScrapReasonID= 16  \n"), "    AND p.ProductID = 733"), true);
}

public virtual void testUpdateSetsIssue1590() {
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("update mytable set a=5 where b = 2")!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(update.getUpdateSets()), null);
update.addColumns(new global::DripSharp.SqlTrellis.Schema.Column("y"));
update.addExpressions(new global::DripSharp.SqlTrellis.Expression.DoubleValue("6"));
global::DripSharp.Testing.JavaAssertions.Equal("UPDATE mytable SET (a, y) = (5, 6) WHERE b = 2", update.ToString(), null);
}

internal virtual void testArrayColumnsIssue1083() {
string sqlStr = "SELECT listes[(SELECT cardinality(listes))]";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "update utilisateur set listes[0] = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "update utilisateur set listes[(select cardinality(listes))] = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "update utilisateur set listes[0:3] = (1,2,3,4)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1910() {
global::DripSharp.SqlTrellis.Statement.Update.Update update = new global::DripSharp.SqlTrellis.Statement.Update.Update();
update.setTable(new global::DripSharp.SqlTrellis.Schema.Table("sys_dept"));
global::DripSharp.SqlTrellis.Statement.Update.UpdateSet updateSet = new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet(new global::DripSharp.SqlTrellis.Schema.Column("deleted"), new global::DripSharp.SqlTrellis.Expression.LongValue(1L));
update.addUpdateSet(updateSet);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(update, "UPDATE sys_dept SET deleted = 1", true);
updateSet.add(new global::DripSharp.SqlTrellis.Schema.Column("created"), new global::DripSharp.SqlTrellis.Expression.LongValue(2L));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(update, "UPDATE sys_dept SET (deleted, created) = (1,2)", true);
}

internal virtual void testInsertWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH inserted AS ( ", "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "   RETURNING y "), ") "), "   UPDATE z "), "      SET foo = 1 "), "    WHERE y IN (SELECT y FROM inserted) ");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", update.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = update.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b RETURNING y", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testUpdateWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH updated AS ( ", "   UPDATE x "), "      SET foo = 1 "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "   UPDATE z "), "      SET foo = 1 "), "    WHERE y IN (SELECT y FROM inserted) ");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", update.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = update.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Update.Update innerUpdate = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getUpdate().getUpdate();
global::DripSharp.Testing.JavaAssertions.Equal("x", innerUpdate.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", global::DripSharp.Runtime.JavaCompat.ListGet(innerUpdate.getUpdateSets(), 0).getColumn(0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(innerUpdate.getUpdateSets(), 0).getValue(0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(innerUpdate.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", innerUpdate.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" updated", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "   UPDATE z "), "      SET foo = 1 "), "    WHERE y IN (SELECT y FROM inserted) ");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", update.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = update.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", delete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(delete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", delete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM deleted) "), "   RETURNING w "), ") "), "   UPDATE z "), "      SET foo = 1 "), "    WHERE y IN (SELECT y FROM inserted) ");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", update.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = update.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", delete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(delete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", delete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM deleted)", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM deleted) RETURNING w", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

internal virtual void testSelectAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH selection AS ( ", "   SELECT y "), "     FROM z "), "    WHERE foo = 'bar' "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM selection) "), "   RETURNING w "), ") "), "   UPDATE z "), "      SET foo = 1 "), "    WHERE y IN (SELECT y FROM inserted) ");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", update.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = update.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect();
global::DripSharp.Testing.JavaAssertions.Equal("SELECT y FROM z WHERE foo = 'bar'", select.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" selection", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM selection)", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM selection) RETURNING w", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

public virtual void testPreferringClause(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
}

public virtual void testUpdateWithBoolean() {
string statement = "UPDATE mytable set col1='as', col2=true Where o >= 3";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Statement.Update.UpdateTest.PARSER_MANAGER.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", update.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(update.getUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("as", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.StringValue>(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getValues(), 0))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.BooleanValue>(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getValues(), 0), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.BooleanValue>(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getValues(), 0))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThanEquals>(update.getWhere(), null);
}

public virtual void testUpdateWithSkylineKeywords() {
string statement = "UPDATE mytable SET low = 1, high = 2, inverse = 3, plus = 4 WHERE id = 6";
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Statement.Update.UpdateTest.PARSER_MANAGER.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", update.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(update.getUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("low", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("high", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 1).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("inverse", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 2).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("plus", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 3).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo>(update.getWhere(), null);
}

[Xunit.Fact]
public void __Upstream_47e2b93443374079()
{
        try
        {
            this.testArrayColumnsIssue1083();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dd7562a67525a4ec()
{
        try
        {
            this.testDeleteAndInsertWithin2Ctes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_602eec09f4d6a4fb()
{
        try
        {
            this.testDeleteWithinCte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10ace39bfcc101ec()
{
        try
        {
            this.testInsertWithinCte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6acdc7825305e668()
{
        try
        {
            this.testIssue1910();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50374fe409837547()
{
        try
        {
            this.testMysqlHint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_958d645902a02b7c()
{
        try
        {
            this.testOracleHint();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING HIGH mycolumn")]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING LOW mycolumn")]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING 1 = 1")]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING (HIGH mycolumn)")]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING INVERSE (HIGH mycolumn)")]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING HIGH mycolumn1 PRIOR TO LOW mycolumn2")]
[Xunit.InlineData("UPDATE mytable SET mycolumn1 = mycolumn2 PREFERRING HIGH mycolumn1 PLUS LOW mycolumn2")]
public void __Upstream_9d2c81a3a559f4e0(string sqlStr)
{
        try
        {
            this.testPreferringClause(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_03d214d3ad0bd8b8()
{
        try
        {
            this.testSelectAndInsertWithin2Ctes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ffa4e3587217bcf()
{
        try
        {
            this.testUpdate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81856dce7f3d9daf()
{
        try
        {
            this.testUpdateDoesNotAllowLimitOffset();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f372b8097cf086bd()
{
        try
        {
            this.testUpdateIgnoreModifier();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b3149347d3cc7faf()
{
        try
        {
            this.testUpdateIssue167_SingleQuotes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9f28c88e41bb2adb()
{
        try
        {
            this.testUpdateIssue338();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_930d43202ec76ac5()
{
        try
        {
            this.testUpdateIssue338_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4ea1bec7cf4c1f38()
{
        try
        {
            this.testUpdateIssue338_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_856c2760e817a572()
{
        try
        {
            this.testUpdateIssue508LeftShift();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_920f339a986e65a6()
{
        try
        {
            this.testUpdateIssue750();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_56fa150940402a32()
{
        try
        {
            this.testUpdateIssue826();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7c23dfc83ecd619d()
{
        try
        {
            this.testUpdateIssue962Validate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9934f9030382ea62()
{
        try
        {
            this.testUpdateLowPriority();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b89df2c3a02ce11d()
{
        try
        {
            this.testUpdateMultiTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c0354c69f5ca3556()
{
        try
        {
            this.testUpdateMultipleModifiers();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_79d9332425782bb3()
{
        try
        {
            this.testUpdateOutputClause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b659502817be1b97()
{
        try
        {
            this.testUpdateSetsIssue1316();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a4c06deaf2777f0()
{
        try
        {
            this.testUpdateSetsIssue1590();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cd73779f670bf543()
{
        try
        {
            this.testUpdateVariableAssignment();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ac6f1655bb56f5f()
{
        try
        {
            this.testUpdateWAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6fc8beaa45b1ff8b()
{
        try
        {
            this.testUpdateWithBoolean();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9cc093c450458f54()
{
        try
        {
            this.testUpdateWithDeparser();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8efd565d7f2ff3fc()
{
        try
        {
            this.testUpdateWithFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b75e8c93568c4c08()
{
        try
        {
            this.testUpdateWithFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bd4208545bf2d2b0()
{
        try
        {
            this.testUpdateWithLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c086c364feeb5e71()
{
        try
        {
            this.testUpdateWithOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8221bda74d4754d2()
{
        try
        {
            this.testUpdateWithOrderByAndLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_09002267b207e675()
{
        try
        {
            this.testUpdateWithReturningAll();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4fead369b58ca1e7()
{
        try
        {
            this.testUpdateWithReturningList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4deccc94a7e85eb8()
{
        try
        {
            this.testUpdateWithSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6c43964b50cab19b()
{
        try
        {
            this.testUpdateWithSelect2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a1a1a39ee75042ae()
{
        try
        {
            this.testUpdateWithSkylineKeywords();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_04e34ed2f112ef37()
{
        try
        {
            this.testUpdateWithinCte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_db683ebf7334b2a4()
{
        try
        {
            this.testWith();
        }
        finally
        {
        }
}
}
