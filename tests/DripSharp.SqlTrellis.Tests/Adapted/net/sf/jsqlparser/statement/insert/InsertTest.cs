// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Insert;

public class InsertTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testRegularInsert() {
string statement = "INSERT INTO mytable (col1, col2, col3) VALUES (?, 'sadfsd', 234)";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 2).getColumnName(), null);
global::DripSharp.SqlTrellis.Statement.Select.Values values = insert.getValues();
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(values.getExpressions()), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(values.getExpressions(), 0) is global::DripSharp.SqlTrellis.Expression.JdbcParameter), null);
global::DripSharp.Testing.JavaAssertions.Equal("sadfsd", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.StringValue>(global::DripSharp.Runtime.JavaCompat.ListGet(values.getExpressions(), 1))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(234), (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(values.getExpressions(), 2))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, insert.ToString(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressionList = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.JdbcParameter(), new global::DripSharp.SqlTrellis.Expression.StringValue("sadfsd"), new global::DripSharp.SqlTrellis.Expression.LongValue().withValue((long)(234)));
global::DripSharp.SqlTrellis.Statement.Select.Select select = new global::DripSharp.SqlTrellis.Statement.Select.Values().withExpressions(global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(expressionList));
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert2 = new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable")).withColumns(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Schema.Column>(new global::DripSharp.SqlTrellis.Schema.Column("col1"), new global::DripSharp.SqlTrellis.Schema.Column("col2"), new global::DripSharp.SqlTrellis.Schema.Column("col3"))).withSelect(select);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(insert2, statement);
statement = "INSERT INTO myschema.mytable VALUES (?, ?, 2.3)";
insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytable", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getValues().getExpressions()), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(insert.getValues().getExpressions(), 0) is global::DripSharp.SqlTrellis.Expression.JdbcParameter), null);
global::DripSharp.Testing.JavaAssertions.Equal(2.3D, (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.DoubleValue>(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getValues().getExpressions(), 2))).getValue(), null, 0.0D);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", insert), null);
}

public virtual void testInsertWithKeywordValue() {
string statement = "INSERT INTO mytable (col1) VALUE ('val1')";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'val1'", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getValues().getExpressions(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO mytable (col1) VALUES ('val1')", insert.ToString(), null);
}

public virtual void testInsertFromSelect() {
string statement = "INSERT INTO mytable (col1, col2, col3) SELECT * FROM mytable2";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 2).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Throws<global::System.Exception>(() => {
insert.getValues();
}, null);
global::DripSharp.Testing.JavaAssertions.NotNull(insert.getSelect(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable2", ((global::DripSharp.SqlTrellis.Schema.Table)(insert.getPlainSelect().getFromItem()!)).getName(), null);
string statementToString = "INSERT INTO mytable (col1, col2, col3) SELECT * FROM mytable2";
global::DripSharp.Testing.JavaAssertions.Equal(statementToString, global::DripSharp.Runtime.JavaCompat.Concat("", insert), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable")).addColumns(new global::DripSharp.SqlTrellis.Schema.Column("col1"), new global::DripSharp.SqlTrellis.Schema.Column("col2"), new global::DripSharp.SqlTrellis.Schema.Column("col3")).withSelect(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("mytable2"))), statement);
}

public virtual void testInsertFromSet() {
string statement = "INSERT INTO mytable SET col1 = 12, col2 = name1 * name2";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getSetUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getSetUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getSetUpdateSets(), 1).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("12", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getSetUpdateSets(), 0).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("name1 * name2", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getSetUpdateSets(), 1).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", insert), null);
}

public virtual void testInsertValuesWithDuplicateElimination() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO TEST (ID, COUNTER) VALUES (123, 0) ", "ON DUPLICATE KEY UPDATE COUNTER = COUNTER + 1");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("TEST", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("ID", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("COUNTER", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getColumns(), 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getValues().getExpressions()), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(123), (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getValues().getExpressions(), 0))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(0), (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getValues().getExpressions(), 1))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getDuplicateUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("COUNTER", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getDuplicateUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("COUNTER + 1", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getDuplicateUpdateSets(), 0).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.False(insert.isUseSelectBrackets(), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isUseDuplicate(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", insert), null);
}

public virtual void testInsertFromSetWithDuplicateElimination() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO mytable SET col1 = 122 ", "ON DUPLICATE KEY UPDATE col2 = col2 + 1, col3 = 'saint'");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getSetUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getSetUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("122", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getSetUpdateSets(), 0).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getDuplicateUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getDuplicateUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getDuplicateUpdateSets(), 1).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2 + 1", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getDuplicateUpdateSets(), 0).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("'saint'", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getDuplicateUpdateSets(), 1).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", insert), null);
}

public virtual void testInsertMultiRowValue() {
string statement = "INSERT INTO mytable (col1, col2) VALUES (a, b), (d, e)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> multiExpressionList = global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>().addExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Schema.Column("a"), new global::DripSharp.SqlTrellis.Schema.Column("b"))).addExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Schema.Column("d"), new global::DripSharp.SqlTrellis.Schema.Column("e"))));
global::DripSharp.SqlTrellis.Statement.Select.Select select = new global::DripSharp.SqlTrellis.Statement.Select.Values().withExpressions(multiExpressionList);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable")).withColumns(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Schema.Column>(new global::DripSharp.SqlTrellis.Schema.Column("col1"), new global::DripSharp.SqlTrellis.Schema.Column("col2"))).withSelect(select);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(insert, statement);
}

public virtual void testInsertMultiRowValueDifferent() {
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("INSERT INTO mytable (col1, col2) VALUES (a, b), (d, e, c)");
}, null);
}

public virtual void testOracleInsertMultiRowValue() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT ALL\n", "  INTO suppliers (supplier_id, supplier_name) VALUES (1000, 'IBM')\n"), "  INTO suppliers (supplier_id, supplier_name) VALUES (2000, 'Microsoft')\n"), "  INTO suppliers (supplier_id, supplier_name) VALUES (3000, 'Google')\n"), "SELECT * FROM dual;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testSimpleInsert() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO example (num, name, address, tel) VALUES (1, 'name', 'test ', '1234-1234')");
}

public virtual void testInsertWithReturning() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable (mycolumn) VALUES ('1') RETURNING id");
}

public virtual void testInsertWithReturning2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable (mycolumn) VALUES ('1') RETURNING *");
}

public virtual void testInsertWithReturning3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable (mycolumn) VALUES ('1') RETURNING id AS a1, id2 AS a2");
}

public virtual void testInsertSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable (mycolumn) SELECT mycolumn FROM mytable");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable (mycolumn) (SELECT mycolumn FROM mytable)");
}

public virtual void testInsertWithSelect() {
string sqlStr1 = "INSERT INTO mytable (mycolumn) WITH a AS (SELECT mycolumn FROM mytable) SELECT mycolumn FROM a";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert1 = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr1, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> insertWithItems1 = insert1.getWithItemsList();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> selectWithItems1 = insert1.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert1.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Null(insertWithItems1, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectWithItems1), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT mycolumn FROM mytable", global::DripSharp.Runtime.JavaCompat.ListGet(selectWithItems1, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(selectWithItems1, 0).getAlias().ToString(), null);
string sqlStr2 = "INSERT INTO mytable (mycolumn) (WITH a AS (SELECT mycolumn FROM mytable) SELECT mycolumn FROM a)";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert2 = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr2, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> insertWithItems2 = insert2.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert2.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Null(insertWithItems2, null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect select = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(insert2.getSelect()!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> selectWithItems2 = select.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectWithItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT mycolumn FROM mytable", global::DripSharp.Runtime.JavaCompat.ListGet(selectWithItems2, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(selectWithItems2, 0).getAlias().ToString(), null);
}

public virtual void testInsertWithKeywords() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO kvPair (value, key) VALUES (?, ?)");
}

public virtual void testHexValues() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO TABLE2 VALUES ('1', \"DSDD\", x'EFBFBDC7AB')");
}

public virtual void testHexValues2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO TABLE2 VALUES ('1', \"DSDD\", 0xEFBFBDC7AB)");
}

public virtual void testHexValues3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO TABLE2 VALUES ('1', \"DSDD\", 0xabcde)");
}

public virtual void testDuplicateKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO Users0 (UserId, Key, Value) VALUES (51311, 'T_211', 18) ON DUPLICATE KEY UPDATE Value = 18");
}

public virtual void testModifierIgnore() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT IGNORE INTO `AoQiSurvey_FlashVersion_Single` VALUES (302215163, 'WIN 16,0,0,235')");
}

public virtual void testModifierPriority1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT DELAYED INTO kvPair (value, key) VALUES (?, ?)");
}

public virtual void testModifierPriority2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT LOW_PRIORITY INTO kvPair (value, key) VALUES (?, ?)");
}

public virtual void testModifierPriority3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT HIGH_PRIORITY INTO kvPair (value, key) VALUES (?, ?)");
}

public virtual void testIssue223() {
string sqlStr = "INSERT INTO user VALUES (2001, '\\'Clark\\'', 'Kent')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testKeywordPrecisionIssue363() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO test (user_id, precision) VALUES (1, '111')");
}

public virtual void testWithDeparsingIssue406() {
string sqlStr = "insert into mytab3 (a,b,c) select a,b,c from mytab where exists(with t as (select * from mytab2) select * from t)";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> insertWithItems = insert.getWithItemsList();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> selectWithItems = insert.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("mytab3", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Null(insertWithItems, null);
global::DripSharp.Testing.JavaAssertions.Null(selectWithItems, null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExistsExpression exists = (global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExistsExpression)(insert.getPlainSelect().getWhere()!);
global::DripSharp.Testing.JavaAssertions.Equal("(WITH t AS (SELECT * FROM mytab2) SELECT * FROM t)", global::DripSharp.Runtime.JavaCompat.StringValueOf(exists.getRightExpression()), null);
}

public virtual void testInsertSetInDeparsing() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable SET col1 = 12, col2 = name1 * name2");
}

public virtual void testInsertValuesWithDuplicateEliminationInDeparsing() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO TEST (ID, COUNTER) VALUES (123, 0) ", "ON DUPLICATE KEY UPDATE COUNTER = COUNTER + 1"));
}

public virtual void testInsertSetWithDuplicateEliminationInDeparsing() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO mytable SET col1 = 122 ", "ON DUPLICATE KEY UPDATE col2 = col2 + 1, col3 = 'saint'"));
}

public virtual void testInsertTableWithAliasIssue526() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO account AS t (name, addr, phone) SELECT * FROM user");
}

public virtual void testInsertKeyWordEnableIssue592() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO T_USER (ID, EMAIL_VALIDATE, ENABLE, PASSWORD) VALUES (?, ?, ?, ?)");
}

public virtual void testInsertKeyWordIntervalIssue682() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO BILLING_TASKS (TIMEOUT, INTERVAL, RETRY_UPON_FAILURE, END_DATE, MAX_RETRY_COUNT, CONTINUOUS, NAME, LAST_RUN, START_TIME, NEXT_RUN, ID, UNIQUE_NAME, INTERVAL_TYPE) VALUES (?, ?, ?, ?, ?, ?, ?, NULL, ?, ?, ?, ?, ?)");
}

public virtual void testWithAtFront() {
string sqlStr = "WITH foo AS ( SELECT attr FROM bar ) INSERT INTO lalelu (attr) SELECT attr FROM foo";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> insertWithItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("lalelu", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(insertWithItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT attr FROM bar", global::DripSharp.Runtime.JavaCompat.ListGet(insertWithItems, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" foo", global::DripSharp.Runtime.JavaCompat.ListGet(insertWithItems, 0).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT attr FROM foo", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", global::DripSharp.Runtime.JavaCompat.StringValueOf(insert.getSelect().getPlainSelect().getFromItem()), null);
global::DripSharp.Testing.JavaAssertions.Equal("[attr]", global::DripSharp.Runtime.JavaCompat.StringValueOf(insert.getSelect().getPlainSelect().getSelectItems()), null);
}

public virtual void testNextVal() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO tracker (monitor_id, user_id, module_name, item_id, item_summary, team_id, date_modified, action, visible, id) VALUES (?, ?, ?, ?, ?, ?, to_date(?, 'YYYY-MM-DD HH24:MI:SS'), ?, ?, NEXTVAL FOR TRACKER_ID_SEQ)");
}

public virtual void testNextValueFor() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO tracker (monitor_id, user_id, module_name, item_id, item_summary, team_id, date_modified, action, visible, id) VALUES (?, ?, ?, ?, ?, ?, to_date(?, 'YYYY-MM-DD HH24:MI:SS'), ?, ?, NEXT VALUE FOR TRACKER_ID_SEQ)");
}

public virtual void testNextValIssue773() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO tableA (ID, c1, c2) SELECT hibernate_sequence.nextval, c1, c2 FROM tableB");
}

public virtual void testBackslashEscapingIssue827() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO my_table (my_column_1, my_column_2) VALUES ('my_value_1\\\\', 'my_value_2')");
}

public virtual void testDisableKeywordIssue945() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO SOMESCHEMA.TEST (DISABLE, TESTCOLUMN) VALUES (1, 1)");
}

public virtual void testWithListIssue282() {
string sqlStr = "WITH myctl AS (SELECT a, b FROM mytable) INSERT INTO mytable SELECT a, b FROM myctl";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> insertWithItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(insertWithItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a, b FROM mytable", global::DripSharp.Runtime.JavaCompat.ListGet(insertWithItems, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" myctl", global::DripSharp.Runtime.JavaCompat.ListGet(insertWithItems, 0).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a, b FROM myctl", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myctl", global::DripSharp.Runtime.JavaCompat.StringValueOf(insert.getSelect().getPlainSelect().getFromItem()), null);
global::DripSharp.Testing.JavaAssertions.Equal("[a, b]", global::DripSharp.Runtime.JavaCompat.StringValueOf(insert.getSelect().getPlainSelect().getSelectItems()), null);
}

public virtual void testOracleHint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("INSERT /*+ SOMEHINT */ INTO mytable VALUES (1, 2, 3)", true, "SOMEHINT");
}

public virtual void testInsertTableArrays4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO sal_emp\n", "    VALUES ('Carol',\n"), "    ARRAY[20000, 25000, 25000, 25000],\n"), "    ARRAY[['breakfast', 'consulting'], ['meeting', 'lunch']])"), true);
}

public virtual void testKeywordDefaultIssue1470() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("INSERT INTO mytable (col1, col2, col3) VALUES (?, 'sadfsd', default)");
}

public virtual void testInsertUnionSelectIssue1491() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("insert into table1 (tf1,tf2,tf2)\n", "select sf1,sf2,sf3 from s1\n"), "union\n"), "select rf1,rf2,rf2 from r1\n"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("insert into table1 (tf1,tf2,tf2)\n", "( select sf1,sf2,sf3 from s1\n"), "union\n"), "select rf1,rf2,rf2 from r1\n)"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("insert into table1 (tf1,tf2,tf2)\n", "(select sf1,sf2,sf3 from s1)"), "union "), "(select rf1,rf2,rf2 from r1)"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("insert into table1 (tf1,tf2,tf2)\n", "((select sf1,sf2,sf3 from s1)"), "union "), "(select rf1,rf2,rf2 from r1))"), true);
}

public virtual void testWithSelectFromDual() {
string sqlStr = "(with a as (select * from dual) select * from a)";
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = parenthesedSelect.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM dual", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("a", global::DripSharp.Runtime.JavaCompat.StringValueOf(parenthesedSelect.getPlainSelect().getFromItem()), null);
global::DripSharp.Testing.JavaAssertions.Equal("[*]", global::DripSharp.Runtime.JavaCompat.StringValueOf(parenthesedSelect.getPlainSelect().getSelectItems()), null);
}

public virtual void testInsertOutputClause() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO dbo.EmployeeSales (LastName, FirstName, CurrentSales)  \n", "  OUTPUT INSERTED.EmployeeID,\n"), "         INSERTED.LastName,   \n"), "         INSERTED.FirstName,   \n"), "         INSERTED.CurrentSales,\n"), "         INSERTED.ProjectedSales\n"), "  INTO @MyTableVar  \n"), "    SELECT c.LastName, c.FirstName, sp.SalesYTD  \n"), "    FROM Sales.SalesPerson AS sp  \n"), "    INNER JOIN Person.Person AS c  \n"), "        ON sp.BusinessEntityID = c.BusinessEntityID  \n"), "    WHERE sp.BusinessEntityID LIKE '2%'  \n"), "    ORDER BY c.LastName, c.FirstName"), true);
}

public virtual void testInsertOnConflictIssue1551() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO distributors (did, dname)\n", "    VALUES (5, 'Gizmo Transglobal'), (6, 'Associated Computing, Inc')\n"), "    ON CONFLICT (did) DO UPDATE SET dname = EXCLUDED.dname\n"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO distributors (did, dname) VALUES (7, 'Redline GmbH')\n", "    ON CONFLICT (did) DO NOTHING"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- Don't update existing distributors based in a certain ZIP code\n", "INSERT INTO distributors AS d (did, dname) VALUES (8, 'Anvil Distribution')\n"), "    ON CONFLICT (did) DO UPDATE\n"), "    SET dname = EXCLUDED.dname || ' (formerly ' || d.dname || ')'\n"), "    WHERE d.zipcode <> '21201'"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- Name a constraint directly in the statement (uses associated\n", "-- index to arbitrate taking the DO NOTHING action)\n"), "INSERT INTO distributors (did, dname) VALUES (9, 'Antwerp Design')\n"), "    ON CONFLICT ON CONSTRAINT distributors_pkey DO NOTHING"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- This statement could infer a partial unique index on \"did\"\n", "-- with a predicate of \"WHERE is_active\", but it could also\n"), "-- just use a regular unique constraint on \"did\"\n"), "INSERT INTO distributors (did, dname) VALUES (10, 'Conrad International')\n"), "    ON CONFLICT (did) WHERE is_active DO NOTHING"), true);
}

public virtual void insertOnConflictObjectsTest() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH a ( a, b , c ) \n", "AS (SELECT  1 , 2 , 3 )\n"), "insert into test\n"), "select * from a");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("test", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("[1, 2, 3]", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect().getSelectItems()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Expression.Expression whereExpression = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a=1", false);
global::DripSharp.SqlTrellis.Expression.Expression valueExpression = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("b/2", false);
global::DripSharp.SqlTrellis.Statement.Insert.InsertConflictTarget conflictTarget = new global::DripSharp.SqlTrellis.Statement.Insert.InsertConflictTarget("a", (global::DripSharp.SqlTrellis.Expression.Expression)default!, (global::DripSharp.SqlTrellis.Expression.Expression)default!, (string)default!);
insert.setConflictTarget(conflictTarget);
global::DripSharp.SqlTrellis.Statement.Insert.InsertConflictAction conflictAction = new global::DripSharp.SqlTrellis.Statement.Insert.InsertConflictAction(global::DripSharp.SqlTrellis.Statement.Insert.ConflictActionType.DO_NOTHING);
insert.setConflictAction(conflictAction);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(insert, global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(sqlStr, " ON CONFLICT "), conflictTarget), conflictAction), true);
conflictTarget = new global::DripSharp.SqlTrellis.Statement.Insert.InsertConflictTarget((string)default!, (global::DripSharp.SqlTrellis.Expression.Expression)default!, (global::DripSharp.SqlTrellis.Expression.Expression)default!, "testConstraint");
conflictTarget = conflictTarget.withWhereExpression(whereExpression);
global::DripSharp.Testing.JavaAssertions.NotNull(conflictTarget.withConstraintName("a").getConstraintName(), null);
conflictTarget.setIndexExpression(valueExpression);
global::DripSharp.Testing.JavaAssertions.NotNull(conflictTarget.getIndexExpression(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(conflictTarget.withIndexColumnName("b").getIndexColumnName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListIsEmpty(conflictTarget.withIndexExpression(valueExpression).getIndexColumnNames()), null);
global::DripSharp.Testing.JavaAssertions.NotNull(conflictTarget.withWhereExpression(whereExpression).getWhereExpression(), null);
conflictAction = new global::DripSharp.SqlTrellis.Statement.Insert.InsertConflictAction(global::DripSharp.SqlTrellis.Statement.Insert.ConflictActionType.DO_UPDATE);
conflictAction.addUpdateSet(new global::DripSharp.SqlTrellis.Schema.Column().withColumnName("a"), valueExpression);
global::DripSharp.SqlTrellis.Statement.Update.UpdateSet updateSet = new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet();
updateSet.add(new global::DripSharp.SqlTrellis.Schema.Column().withColumnName("b"));
updateSet.add(valueExpression);
conflictAction = conflictAction.addUpdateSet(updateSet);
global::DripSharp.Testing.JavaAssertions.NotNull(conflictAction.withWhereExpression(whereExpression).getWhereExpression(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Insert.ConflictActionType.DO_UPDATE, conflictAction.getConflictActionType(), null);
insert = insert.withConflictTarget(conflictTarget).withConflictAction(conflictAction);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(insert, global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(sqlStr, " ON CONFLICT "), conflictTarget), conflictAction), true);
}

internal virtual void testMultiColumnConflictTargetIssue1749() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO re_rule_mapping ( id, created_time, last_modified_time, rule_item_id, department_id, scene, operation )\n", "            VALUES\n"), "                ( '1', now( ), now( ), '1', '11', 'test', 'stop7' ),\n"), "                ( '2', now( ), now( ), '2', '22', 'test2', 'stop8' ) ON CONFLICT ( rule_item_id, department_id, scene ) \n"), "            DO UPDATE\n"), "            SET operation = excluded.operation");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testMultiColumnConflictTargetIssue955() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO tableName (id,xxx0,xxx1,xxx2,is_deleted,create_time,update_time) ", "VALUES (?, ?, ?, ?, ?, ?, ?) "), "on conflict(xxx0, xxx1) do update set xxx1=?, update_time=?");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testDefaultValues() {
string statement = "INSERT INTO mytable DEFAULT VALUES";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO MYTABLE DEFAULT VALUES", insert.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isOnlyDefaultValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable")).withOnlyDefaultValues(true), statement);
}

public virtual void testDefaultValuesWithAlias() {
string statement = "INSERT INTO mytable x DEFAULT VALUES";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO MYTABLE X DEFAULT VALUES", insert.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().getAlias().getName(), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isOnlyDefaultValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("x").withUseAs(false))).withOnlyDefaultValues(true), statement);
}

public virtual void testDefaultValuesWithAliasAndAs() {
string statement = "INSERT INTO mytable AS x DEFAULT VALUES";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO MYTABLE AS X DEFAULT VALUES", insert.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().getAlias().getName(), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isOnlyDefaultValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("x").withUseAs(true))).withOnlyDefaultValues(true), statement);
}

public virtual void throwsParseWhenDefaultKeywordUsedAsAlias() {
string statement = "INSERT INTO mytable default DEFAULT VALUES";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => this.parserManager.parse(new global::System.IO.StringReader(statement)), null);
}

internal virtual void testInsertWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH inserted AS ( ", "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "   RETURNING y "), ") "), "INSERT INTO z (blah) "), "SELECT y FROM inserted");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", insert.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert innerInsert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", innerInsert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b", innerInsert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", innerInsert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b RETURNING y", innerInsert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testUpdateWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH updated AS ( ", "   UPDATE x "), "      SET foo = 1 "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "INSERT INTO z (blah) "), "SELECT y FROM updated");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", insert.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Update.Update update = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getUpdate().getUpdate();
global::DripSharp.Testing.JavaAssertions.Equal("x", update.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumn(0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getValue(0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(update.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", update.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" updated", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "INSERT INTO z (blah) "), "SELECT y FROM deleted");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", insert.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", delete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(delete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", delete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM deleted) "), "   RETURNING w "), ") "), "INSERT INTO z (blah) "), "SELECT w FROM inserted");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", insert.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", delete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(delete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", delete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert innerInsert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", innerInsert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM deleted)", innerInsert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", innerInsert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM deleted) RETURNING w", innerInsert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

internal virtual void testSelectAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH selection AS ( ", "   SELECT y "), "     FROM z "), "    WHERE foo = 'bar' "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM selection) "), "   RETURNING w "), ") "), "INSERT INTO z (blah) "), "SELECT w FROM inserted");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", insert.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = insert.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect();
global::DripSharp.Testing.JavaAssertions.Equal("SELECT y FROM z WHERE foo = 'bar'", select.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" selection", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert innerInsert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", innerInsert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM selection)", innerInsert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", innerInsert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM selection) RETURNING w", innerInsert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

internal virtual void testInsertOverwrite() {
string sqlStr = "INSERT OVERWRITE TABLE t SELECT * FROM a";
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("t", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isOverwrite(), null);
sqlStr = "INSERT OVERWRITE TABLE t PARTITION (pt1, pt2) SELECT * FROM a";
insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("t", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getPartitions()), null);
global::DripSharp.Testing.JavaAssertions.Equal("pt1", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getPartitions(), 0).getColumn().getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getPartitions(), 0).getValue(), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isOverwrite(), null);
sqlStr = "INSERT OVERWRITE\nTABLE t PARTITION (pt1 = 'pt1', pt2 = 'pt2') SELECT * FROM a";
insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("t", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getPartitions()), null);
global::DripSharp.Testing.JavaAssertions.Equal("pt2", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getPartitions(), 1).getColumn().getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'pt2'", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getPartitions(), 1).getValue()), null);
global::DripSharp.Testing.JavaAssertions.True(insert.isOverwrite(), null);
sqlStr = "INSERT INTO\tTABLE t PARTITION (pt1 = 'pt1', pt2 = 'pt2') SELECT * FROM a";
insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("t", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(insert.getPartitions()), null);
global::DripSharp.Testing.JavaAssertions.Equal("pt1", global::DripSharp.Runtime.JavaCompat.ListGet(insert.getPartitions(), 0).getColumn().getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'pt1'", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(insert.getPartitions(), 0).getValue()), null);
global::DripSharp.Testing.JavaAssertions.False(insert.isOverwrite(), null);
}

public virtual void testOverridingSystemValueInsertsParse(string sqlStr) {
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, insert.isOverriding(), null);
}

public virtual void testOverridingSystemValueInsertsParseWithTableNamedOverriding(string sqlStr) {
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("overriding", insert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, insert.isOverriding(), null);
}

internal virtual void insertDemo() {
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("test")).withSelect(new global::DripSharp.SqlTrellis.Statement.Select.Values().addExpressions(new global::DripSharp.SqlTrellis.Expression.StringValue("A"), new global::DripSharp.SqlTrellis.Expression.StringValue("B")));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(insert, "INSERT INTO test VALUES ('A', 'B')");
}

[Xunit.Fact]
public void __Upstream_9fdb94525fddac27()
{
        try
        {
            this.insertDemo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_15873ac2be6eb825()
{
        try
        {
            this.insertOnConflictObjectsTest();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ae370f9723fc889d()
{
        try
        {
            this.testBackslashEscapingIssue827();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_69fe22501bbc5f65()
{
        try
        {
            this.testDefaultValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0613816a556366ea()
{
        try
        {
            this.testDefaultValuesWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52756c833d1faf2f()
{
        try
        {
            this.testDefaultValuesWithAliasAndAs();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b75cf1be626a97cd()
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
public void __Upstream_f6d656c0039a8203()
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
public void __Upstream_3287f08ecf8f3650()
{
        try
        {
            this.testDisableKeywordIssue945();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_56540fba6eeca844()
{
        try
        {
            this.testDuplicateKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ed8f9546fa2cd8e()
{
        try
        {
            this.testHexValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_216bbbc952e8d00b()
{
        try
        {
            this.testHexValues2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f48ea0b7d3f1b9b3()
{
        try
        {
            this.testHexValues3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cadf6128fc3e4068()
{
        try
        {
            this.testInsertFromSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e4590eb37842f056()
{
        try
        {
            this.testInsertFromSet();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_35f10c67efa92318()
{
        try
        {
            this.testInsertFromSetWithDuplicateElimination();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50e6d177dbabb28f()
{
        try
        {
            this.testInsertKeyWordEnableIssue592();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_490dc7ce0e35d51e()
{
        try
        {
            this.testInsertKeyWordIntervalIssue682();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_70bab752e268ae03()
{
        try
        {
            this.testInsertMultiRowValue();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_e5cda3c883bf7fc3()
{
        try
        {
            this.testInsertMultiRowValueDifferent();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_346b5edfcd6e0399()
{
        try
        {
            this.testInsertOnConflictIssue1551();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c3297ecac621c42()
{
        try
        {
            this.testInsertOutputClause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1468445f43ebdbb0()
{
        try
        {
            this.testInsertOverwrite();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2740195e13b13a04()
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
public void __Upstream_8e054f69e9336ba3()
{
        try
        {
            this.testInsertSetInDeparsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_851cbed118a1cd5a()
{
        try
        {
            this.testInsertSetWithDuplicateEliminationInDeparsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4985e44ab70e89ff()
{
        try
        {
            this.testInsertTableArrays4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4fb9ce7fd8984aa7()
{
        try
        {
            this.testInsertTableWithAliasIssue526();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ede60079d6513e7b()
{
        try
        {
            this.testInsertUnionSelectIssue1491();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8409d084e9caf955()
{
        try
        {
            this.testInsertValuesWithDuplicateElimination();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_002c70e73347a2b5()
{
        try
        {
            this.testInsertValuesWithDuplicateEliminationInDeparsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c4953497054bf634()
{
        try
        {
            this.testInsertWithKeywordValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_55b6f9db56fee002()
{
        try
        {
            this.testInsertWithKeywords();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_36a55a357662fd67()
{
        try
        {
            this.testInsertWithReturning();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_325558bc2bc34408()
{
        try
        {
            this.testInsertWithReturning2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf331c0a7471be81()
{
        try
        {
            this.testInsertWithReturning3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_64242905c9d06833()
{
        try
        {
            this.testInsertWithSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5d268533f51116b()
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
public void __Upstream_0284ce139d888794()
{
        try
        {
            this.testIssue223();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ef4710dd486352fa()
{
        try
        {
            this.testKeywordDefaultIssue1470();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ca3cb915dcafd0a()
{
        try
        {
            this.testKeywordPrecisionIssue363();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c096d761a93098ad()
{
        try
        {
            this.testModifierIgnore();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5fb0245c42f944b6()
{
        try
        {
            this.testModifierPriority1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8333769a0769d509()
{
        try
        {
            this.testModifierPriority2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5c992963964ce141()
{
        try
        {
            this.testModifierPriority3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2f222e1f270fde9c()
{
        try
        {
            this.testMultiColumnConflictTargetIssue1749();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3a878888a571d97c()
{
        try
        {
            this.testMultiColumnConflictTargetIssue955();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_33d62e9d1e35a7a1()
{
        try
        {
            this.testNextVal();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_04470f7c7b9837c1()
{
        try
        {
            this.testNextValIssue773();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4f925aa1f33e0c10()
{
        try
        {
            this.testNextValueFor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5545115fa204ca46()
{
        try
        {
            this.testOracleHint();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_214cbea86f2245ce()
{
        try
        {
            this.testOracleInsertMultiRowValue();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("INSERT INTO mytable (foo) OVERRIDING SYSTEM VALUE VALUES (1)")]
[Xunit.InlineData("INSERT INTO mytable (foo) OVERRIDING SYSTEM VALUE SELECT bar FROM b WHERE y = 1")]
[Xunit.InlineData("INSERT INTO mytable (foo) OVERRIDING SYSTEM VALUE VALUES (1) ON CONFLICT (foo) DO UPDATE SET foo = 2")]
[Xunit.InlineData("INSERT INTO mytable (foo) OVERRIDING SYSTEM VALUE SELECT bar FROM b WHERE y = 1 ON CONFLICT (foo) DO UPDATE SET foo = 2")]
[Xunit.InlineData("INSERT INTO mytable (foo) OVERRIDING SYSTEM VALUE VALUES (1) ON CONFLICT (foo) DO NOTHING")]
[Xunit.InlineData("INSERT INTO mytable (foo) OVERRIDING SYSTEM VALUE SELECT bar FROM b WHERE y = 1 ON CONFLICT (foo) DO NOTHING")]
public void __Upstream_01a6de0cc7472b6f(string sqlStr)
{
        try
        {
            this.testOverridingSystemValueInsertsParse(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("INSERT INTO overriding (foo) OVERRIDING SYSTEM VALUE VALUES (1)")]
[Xunit.InlineData("INSERT INTO overriding (foo) OVERRIDING SYSTEM VALUE SELECT bar FROM b WHERE y = 1")]
[Xunit.InlineData("INSERT INTO overriding (foo) OVERRIDING SYSTEM VALUE VALUES (1) ON CONFLICT (foo) DO UPDATE SET foo = 2")]
[Xunit.InlineData("INSERT INTO overriding (foo) OVERRIDING SYSTEM VALUE SELECT bar FROM b WHERE y = 1 ON CONFLICT (foo) DO UPDATE SET foo = 2")]
[Xunit.InlineData("INSERT INTO overriding (foo) OVERRIDING SYSTEM VALUE VALUES (1) ON CONFLICT (foo) DO NOTHING")]
[Xunit.InlineData("INSERT INTO overriding (foo) OVERRIDING SYSTEM VALUE SELECT bar FROM b WHERE y = 1 ON CONFLICT (foo) DO NOTHING")]
public void __Upstream_26db3f420f0d5b1d(string sqlStr)
{
        try
        {
            this.testOverridingSystemValueInsertsParseWithTableNamedOverriding(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3796f5dd3eca970f()
{
        try
        {
            this.testRegularInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b5b08c57260473f3()
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
public void __Upstream_3cf1ca1c1e728495()
{
        try
        {
            this.testSimpleInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c5b55cd7bd976d09()
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
public void __Upstream_65c59f1ec1f2a80f()
{
        try
        {
            this.testWithAtFront();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1603b99fde9034f3()
{
        try
        {
            this.testWithDeparsingIssue406();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_65bec8a2040d8dcf()
{
        try
        {
            this.testWithListIssue282();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7e08f60a439a1bf5()
{
        try
        {
            this.testWithSelectFromDual();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_750edb40ae285062()
{
        try
        {
            this.throwsParseWhenDefaultKeywordUsedAsAlias();
        }
        finally
        {
        }
}
}
