// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SelectTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testMultiPartTableNameWithServerNameAndDatabaseNameAndSchemaName() {
string statement = "SELECT columnName FROM [server-name\\server-instance].databaseName.schemaName.tableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, false, (parser) => parser.withSquareBracketQuotation(true));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Schema.Column().withColumnName("columnName")).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table().withDatabase(new global::DripSharp.SqlTrellis.Schema.Database("databaseName").withServer(new global::DripSharp.SqlTrellis.Schema.Server("[server-name\\server-instance]"))).withSchemaName("schemaName").withName("tableName")), statement);
}

public virtual void testMultiPartTableNameWithServerNameAndDatabaseName() {
string statement = "SELECT columnName FROM [server-name\\server-instance].databaseName..tableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, false, (parser) => parser.withSquareBracketQuotation(true));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Schema.Column().withColumnName("columnName")).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table().withDatabase(new global::DripSharp.SqlTrellis.Schema.Database("databaseName").withServer(new global::DripSharp.SqlTrellis.Schema.Server("[server-name\\server-instance]"))).withName("tableName")), statement);
}

public virtual void testMultiPartTableNameWithServerNameAndSchemaName() {
string statement = "SELECT columnName FROM [server-name\\server-instance]..schemaName.tableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, false, (parser) => parser.withSquareBracketQuotation(true));
}

public virtual void testMultiPartTableNameWithServerProblem() {
string statement = "SELECT * FROM LINK_100.htsac.dbo.t_transfer_num a";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testMultiPartTableNameWithServerName() {
string statement = "SELECT columnName FROM [server-name\\server-instance]...tableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, false, (parser) => parser.withSquareBracketQuotation(true));
}

public virtual void testMultiPartTableNameWithDatabaseNameAndSchemaName() {
string statement = "SELECT columnName FROM databaseName.schemaName.tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testMultiPartTableNameWithDatabaseName() {
string statement = "SELECT columnName FROM databaseName..tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testMultiPartTableNameWithSchemaName() {
string statement = "SELECT columnName FROM schemaName.tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testMultiPartTableNameWithColumnName() {
string statement = "SELECT columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testMultiPartColumnNameWithDatabaseNameAndSchemaNameAndTableName() {
string statement = "SELECT databaseName.schemaName.tableName.columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testMultiPartColumnNameWithDatabaseNameAndSchemaName() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT databaseName.schemaName..columnName FROM tableName");
}

public virtual void testMultiPartColumnNameWithDatabaseNameAndTableName() {
string statement = "SELECT databaseName..tableName.columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
this.checkMultipartIdentifier(select, "databaseName..tableName.columnName");
}

public virtual void testMultiPartColumnNameWithDatabaseName() {
string statement = "SELECT databaseName...columnName FROM tableName";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
this.parserManager.parse(new global::System.IO.StringReader(statement));
}, null);
}

public virtual void testMultiPartColumnNameWithSchemaNameAndTableName() {
string statement = "SELECT schemaName.tableName.columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
this.checkMultipartIdentifier(select, "schemaName.tableName.columnName");
}

public virtual void testMultiPartColumnNameWithSchemaName() {
string statement = "SELECT schemaName..columnName FROM tableName";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
this.parserManager.parse(new global::System.IO.StringReader(statement));
}, null);
}

public virtual void testMultiPartColumnNameWithTableName() {
string statement = "SELECT tableName.columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
this.checkMultipartIdentifier(select, "tableName.columnName");
}

public virtual void testMultiPartColumnName() {
string statement = "SELECT columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
this.checkMultipartIdentifier(select, "columnName");
}

internal virtual void checkMultipartIdentifier(global::DripSharp.SqlTrellis.Statement.Select.Select select, string fullColumnName) {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getSelectItems(), 0).getExpression();
global::DripSharp.Testing.JavaAssertions.True((expr is global::DripSharp.SqlTrellis.Schema.Column), null);
global::DripSharp.SqlTrellis.Schema.Column col = (global::DripSharp.SqlTrellis.Schema.Column)(expr!);
global::DripSharp.Testing.JavaAssertions.Equal("columnName", col.getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(fullColumnName, col.getFullyQualifiedName(), null);
}

public virtual void testAllColumnsFromTable() {
string statement = "SELECT tableName.* FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(select.getSelectItems(), 0).getExpression() is global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns), null);
global::DripSharp.SqlTrellis.Schema.Table t = new global::DripSharp.SqlTrellis.Schema.Table("tableName");
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns(t)).withFromItem(t), statement);
}

public virtual void testSimpleSigns() {
string statement = "SELECT +1, -1 FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testSimpleAdditionsAndSubtractionsWithSigns() {
string statement = "SELECT 1 - 1, 1 + 1, -1 - 1, -1 + 1, +1 + 1, +1 - 1 FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testOperationsWithSigns() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("1 - -1");
global::DripSharp.Testing.JavaAssertions.Equal("1 - -1", global::DripSharp.Runtime.JavaCompat.StringValueOf(expr), null);
global::DripSharp.Testing.JavaAssertions.True((expr is global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Subtraction), null);
global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Subtraction sub = (global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Subtraction)(expr!);
global::DripSharp.Testing.JavaAssertions.True((sub.getLeftExpression() is global::DripSharp.SqlTrellis.Expression.LongValue), null);
global::DripSharp.Testing.JavaAssertions.True((sub.getRightExpression() is global::DripSharp.SqlTrellis.Expression.SignedExpression), null);
global::DripSharp.SqlTrellis.Expression.SignedExpression sexpr = sub.getRightExpression<global::DripSharp.SqlTrellis.Expression.SignedExpression>(typeof(global::DripSharp.SqlTrellis.Expression.SignedExpression));
global::DripSharp.Testing.JavaAssertions.Equal('-', sexpr.getSign(), null);
global::DripSharp.Testing.JavaAssertions.Equal("1", sexpr.getExpression<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)).ToString(), null);
}

public virtual void testSignedColumns() {
string statement = "SELECT -columnName, +columnName, +(columnName), -(columnName) FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testSigns() {
string statement = "SELECT (-(1)), -(1), (-(columnName)), -(columnName), (-1), -1, (-columnName), -columnName FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testLimit() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 3, ?";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Expression.Expression offset = select.getLimit().getOffset();
global::DripSharp.SqlTrellis.Expression.Expression rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(offset!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.True((rowCount is global::DripSharp.SqlTrellis.Expression.JdbcParameter), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ? OFFSET 3";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Null(select.getLimit(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Equal("?", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getOffset().getOffset()), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat("(SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?) UNION ", "(SELECT * FROM mytable2 WHERE mytable2.col = 9 OFFSET ?) LIMIT 3, 4");
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setList = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = setList.getLimit().getOffset();
rowCount = setList.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(offset!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(4), ((global::DripSharp.SqlTrellis.Expression.LongValue)(rowCount!)).getValue(), null);
statement = global::DripSharp.Runtime.JavaCompat.Concat("(SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?) UNION ", "(SELECT * FROM mytable2 WHERE mytable2.col = 9 OFFSET ?) LIMIT 4 OFFSET 3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?) UNION ALL ", "(SELECT * FROM mytable2 WHERE mytable2.col = 9 OFFSET ?) UNION ALL "), "(SELECT * FROM mytable3 WHERE mytable4.col = 9 OFFSET ?) LIMIT 4 OFFSET 3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testLimit2() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 3, ?";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Expression.Expression offset = select.getLimit().getOffset();
global::DripSharp.SqlTrellis.Expression.Expression rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(offset!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).isUseFixedIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitNull(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ? OFFSET 3";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT NULL OFFSET 3";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Null(offset, null);
global::DripSharp.Testing.JavaAssertions.True((rowCount is global::DripSharp.SqlTrellis.Expression.NullValue), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3)), select.getOffset().getOffset(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
global::DripSharp.Testing.JavaAssertions.True(select.getLimit().isLimitNull(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ALL OFFSET 5";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Null(offset, null);
global::DripSharp.Testing.JavaAssertions.True((rowCount is global::DripSharp.SqlTrellis.Expression.AllValue), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(5)), select.getOffset().getOffset(), null);
global::DripSharp.Testing.JavaAssertions.True(select.getLimit().isLimitAll(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitNull(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 0 OFFSET 3";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Null(offset, null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(0), ((global::DripSharp.SqlTrellis.Expression.LongValue)(rowCount!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3)), select.getOffset().getOffset(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitNull(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Null(select.getLimit(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Equal("?", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getOffset().getOffset()), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat("(SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?) UNION ", "(SELECT * FROM mytable2 WHERE mytable2.col = 9 OFFSET ?) LIMIT 3, 4");
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setList = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(select!);
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(setList.getLimit().getOffset()!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(4), ((global::DripSharp.SqlTrellis.Expression.LongValue)(setList.getLimit().getRowCount()!)).getValue(), null);
statement = global::DripSharp.Runtime.JavaCompat.Concat("(SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?) UNION ", "(SELECT * FROM mytable2 WHERE mytable2.col = 9 OFFSET ?) LIMIT 4 OFFSET 3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?) UNION ALL ", "(SELECT * FROM mytable2 WHERE mytable2.col = 9 OFFSET ?) UNION ALL "), "(SELECT * FROM mytable3 WHERE mytable4.col = 9 OFFSET ?) LIMIT 4 OFFSET 3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testLimit3() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ?1, 2";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Expression.Expression offset = select.getLimit().getOffset();
global::DripSharp.SqlTrellis.Expression.Expression rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal(1, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(offset!)).getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(2), ((global::DripSharp.SqlTrellis.Expression.LongValue)(rowCount!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 1, ?2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal((long)(1), ((global::DripSharp.SqlTrellis.Expression.LongValue)(offset!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ?1, ?2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal(2, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(offset!)).getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 1, ?";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal((long)(1), ((global::DripSharp.SqlTrellis.Expression.LongValue)(offset!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).isUseFixedIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ?, ?";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.NotNull(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(offset!)).getIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(offset!)).isUseFixedIndex(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).isUseFixedIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ?1";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Null(offset, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.Unbox(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex()), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
}

public virtual void testLimit4() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT :some_name, 2";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Expression.Expression offset = select.getLimit().getOffset();
global::DripSharp.SqlTrellis.Expression.Expression rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal("some_name", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(offset!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(2), ((global::DripSharp.SqlTrellis.Expression.LongValue)(rowCount!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 1, :some_name";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal((long)(1), ((global::DripSharp.SqlTrellis.Expression.LongValue)(offset!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal("some_name", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(rowCount!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT :name1, :name2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal("name2", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(rowCount!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("name1", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(offset!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ?1, :name1";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal(1, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(offset!)).getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.Equal("name1", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(rowCount!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT :name1, ?1";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Equal(1, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(rowCount!)).getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.Equal("name1", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(offset!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT :param_name";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
offset = select.getLimit().getOffset();
rowCount = select.getLimit().getRowCount();
global::DripSharp.Testing.JavaAssertions.Null(offset, null);
global::DripSharp.Testing.JavaAssertions.Equal("param_name", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(rowCount!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getLimit().isLimitAll(), null);
}

public virtual void testLimitSqlServer1() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 ORDER BY mytable.id OFFSET 3 ROWS FETCH NEXT 5 ROWS ONLY";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Equal("3", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getOffset().getOffset()), null);
global::DripSharp.Testing.JavaAssertions.Equal("ROWS", select.getOffset().getOffsetParam(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getFetch(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getFetch().isFetchParamFirst(), null);
global::DripSharp.Testing.JavaAssertions.Equal("5", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getFetch().getExpression()), null);
global::DripSharp.Testing.JavaAssertJ.That(select.getFetch().getFetchParameters()).ContainsExactly("ROWS", "ONLY");
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testLimitSqlServer2() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 ORDER BY mytable.id OFFSET 3 ROW FETCH FIRST 5 ROW ONLY";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ROW", select.getOffset().getOffsetParam(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getFetch(), null);
global::DripSharp.Testing.JavaAssertions.True(select.getFetch().isFetchParamFirst(), null);
global::DripSharp.Testing.JavaAssertions.Equal("5", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getFetch().getExpression()), null);
global::DripSharp.Testing.JavaAssertJ.That(select.getFetch().getFetchParameters()).ContainsExactly("ROW", "ONLY");
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testLimitSqlServer3() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 ORDER BY mytable.id OFFSET 3 ROWS";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Null(select.getFetch(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ROWS", select.getOffset().getOffsetParam(), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3)), select.getOffset().getOffset(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testLimitSqlServer4() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 ORDER BY mytable.id FETCH NEXT 5 ROWS ONLY";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Null(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getFetch(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getFetch().isFetchParamFirst(), null);
global::DripSharp.Testing.JavaAssertions.Equal("5", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getFetch().getExpression()), null);
global::DripSharp.Testing.JavaAssertJ.That(select.getFetch().getFetchParameters()).ContainsExactly("ROWS", "ONLY");
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testLimitSqlServerJdbcParameters() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 ORDER BY mytable.id OFFSET ? ROWS FETCH NEXT ? ROWS ONLY";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ROWS", select.getOffset().getOffsetParam(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(select.getFetch(), null);
global::DripSharp.Testing.JavaAssertions.False(select.getFetch().isFetchParamFirst(), null);
global::DripSharp.Testing.JavaAssertions.Equal("?", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getFetch().getExpression()), null);
global::DripSharp.Testing.JavaAssertJ.That(select.getFetch().getFetchParameters()).ContainsExactly("ROWS", "ONLY");
global::DripSharp.Testing.JavaAssertions.Equal("?", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getOffset().getOffset()), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testLimitPR404() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ?1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE mytable.col = 9 LIMIT :param_name");
}

public virtual void testLimitOffsetIssue462() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable LIMIT ?1");
}

public virtual void testLimitOffsetIssue462_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable LIMIT ?1 OFFSET ?2");
}

public virtual void testLimitOffsetKeyWordAsNamedParameter() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable LIMIT :limit");
}

public virtual void testLimitOffsetKeyWordAsNamedParameter2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable LIMIT :limit OFFSET :offset");
}

public virtual void testTop() {
string statement = "SELECT TOP 3 * FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), select.getTop().getExpression<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)).getValue(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "select top 5 foo from bar";
select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal((long)(5), select.getTop().getExpression<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)).getValue(), null);
}

public virtual void testTopWithParenthesis() {
string firstColumnName = "alias.columnName1";
string secondColumnName = "alias.columnName2";
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT TOP (5) PERCENT ", firstColumnName), ", "), secondColumnName), " FROM schemaName.tableName alias ORDER BY "), secondColumnName), " DESC");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.Top top = selectBody.getTop();
global::DripSharp.Testing.JavaAssertions.Equal("5", global::DripSharp.Runtime.JavaCompat.StringValueOf(top.getExpression()), null);
global::DripSharp.Testing.JavaAssertions.True(top.hasParenthesis(), null);
global::DripSharp.Testing.JavaAssertions.True(top.isPercentage(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = selectBody.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems), null);
global::DripSharp.Testing.JavaAssertions.Equal(firstColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(secondColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testTopWithTies() {
string statement = "SELECT TOP (5) PERCENT WITH TIES columnName1, columnName2 FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.Top top = selectBody.getTop();
global::DripSharp.Testing.JavaAssertions.Equal("5", global::DripSharp.Runtime.JavaCompat.StringValueOf(top.getExpression()), null);
global::DripSharp.Testing.JavaAssertions.True(top.hasParenthesis(), null);
global::DripSharp.Testing.JavaAssertions.True(top.isPercentage(), null);
global::DripSharp.Testing.JavaAssertions.True(top.isWithTies(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testTopWithJdbcParameter() {
string statement = "SELECT TOP ?1 * FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(1, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getTop().getExpression()!)).getIndex()))), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "select top :name1 foo from bar";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("name1", ((global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getTop().getExpression()!)).getName(), null);
statement = "select top ? foo from bar";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.NotNull(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getTop().getExpression()!)).getIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(((global::DripSharp.SqlTrellis.Expression.JdbcParameter)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getTop().getExpression()!)).isUseFixedIndex(), null);
}

public virtual void testSkip() {
string firstColumnName = "alias.columnName1";
string secondColumnName = "alias.columnName2";
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT SKIP 5 ", firstColumnName), ", "), secondColumnName), " FROM schemaName.tableName alias ORDER BY "), secondColumnName), " DESC");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.Skip skip = selectBody.getSkip();
global::DripSharp.Testing.JavaAssertions.Equal((long)(5), (long)(global::DripSharp.Runtime.JavaCompat.Unbox((long)(skip.getRowCount()))), null);
global::DripSharp.Testing.JavaAssertions.Null(skip.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.Null(skip.getVariable(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = selectBody.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems), null);
global::DripSharp.Testing.JavaAssertions.Equal(firstColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(secondColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
string statement2 = "SELECT SKIP skipVar c1, c2 FROM t";
global::DripSharp.SqlTrellis.Statement.Select.Select select2 = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement2))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody2 = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select2!);
global::DripSharp.SqlTrellis.Statement.Select.Skip skip2 = selectBody2.getSkip();
global::DripSharp.Testing.JavaAssertions.Null(skip2.getRowCount(), null);
global::DripSharp.Testing.JavaAssertions.Null(skip2.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.Equal("skipVar", skip2.getVariable(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems2 = selectBody2.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("c1", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems2, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("c2", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems2, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select2, statement2);
}

public virtual void testFirst() {
string firstColumnName = "alias.columnName1";
string secondColumnName = "alias.columnName2";
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT FIRST 5 ", firstColumnName), ", "), secondColumnName), " FROM schemaName.tableName alias ORDER BY "), secondColumnName), " DESC");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.First limit = selectBody.getFirst();
global::DripSharp.Testing.JavaAssertions.Equal((long)(5), (long)(global::DripSharp.Runtime.JavaCompat.Unbox((long)(limit.getRowCount()))), null);
global::DripSharp.Testing.JavaAssertions.Null(limit.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Select.First.Keyword.FIRST, limit.getKeyword(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = selectBody.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems), null);
global::DripSharp.Testing.JavaAssertions.Equal(firstColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(secondColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
string statement2 = "SELECT FIRST firstVar c1, c2 FROM t";
global::DripSharp.SqlTrellis.Statement.Select.Select select2 = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement2))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody2 = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select2!);
global::DripSharp.SqlTrellis.Statement.Select.First first2 = selectBody2.getFirst();
global::DripSharp.Testing.JavaAssertions.Null(first2.getRowCount(), null);
global::DripSharp.Testing.JavaAssertions.Null(first2.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.Equal("firstVar", first2.getVariable(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems2 = selectBody2.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("c1", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems2, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("c2", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems2, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select2, statement2);
}

public virtual void testFirstWithKeywordLimit() {
string firstColumnName = "alias.columnName1";
string secondColumnName = "alias.columnName2";
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT LIMIT ? ", firstColumnName), ", "), secondColumnName), " FROM schemaName.tableName alias ORDER BY "), secondColumnName), " DESC");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.First limit = selectBody.getFirst();
global::DripSharp.Testing.JavaAssertions.Null(limit.getRowCount(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(limit.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(limit.getJdbcParameter().getIndex(), null);
global::DripSharp.Testing.JavaAssertions.False(limit.getJdbcParameter().isUseFixedIndex(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Select.First.Keyword.LIMIT, limit.getKeyword(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = selectBody.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems), null);
global::DripSharp.Testing.JavaAssertions.Equal(firstColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(secondColumnName, global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testSkipFirst() {
string statement = "SELECT SKIP ?1 FIRST f1 c1, c2 FROM t1";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.Skip skip = selectBody.getSkip();
global::DripSharp.Testing.JavaAssertions.NotNull(skip.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(skip.getJdbcParameter().getIndex(), null);
global::DripSharp.Testing.JavaAssertions.True(skip.getJdbcParameter().isUseFixedIndex(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, (int)(global::DripSharp.Runtime.JavaCompat.Unbox((int)(skip.getJdbcParameter().getIndex()))), null);
global::DripSharp.Testing.JavaAssertions.Null(skip.getVariable(), null);
global::DripSharp.SqlTrellis.Statement.Select.First first = selectBody.getFirst();
global::DripSharp.Testing.JavaAssertions.Null(first.getJdbcParameter(), null);
global::DripSharp.Testing.JavaAssertions.Null(first.getRowCount(), null);
global::DripSharp.Testing.JavaAssertions.Equal("f1", first.getVariable(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = selectBody.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(selectItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("c1", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("c2", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 1).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testSelectItems() {
string statement = "SELECT myid AS MYID, mycol, tab.*, schema.tab.*, mytab.mycol2, myschema.mytab.mycol, myschema.mytab.* FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = plainSelect.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal("MYID", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).getAlias().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 1).getExpression())).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 2).getExpression())).getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("schema", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 3).getExpression())).getTable().getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("schema.tab", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 3).getExpression())).getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab.mycol2", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 4).getExpression())).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytab.mycol", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 5).getExpression())).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytab", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns>(global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 6).getExpression())).getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT myid AS MYID, (SELECT MAX(ID) AS myid2 FROM mytable2) AS myalias FROM mytable WHERE mytable.col = 9";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("myalias", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getAlias().getName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT (myid + myid2) AS MYID FROM mytable WHERE mytable.col = 9";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("MYID", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getAlias().getName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testTimezoneExpression() {
string stmt = "SELECT creation_date AT TIME ZONE 'UTC'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTimezoneExpressionWithTwoTransformations() {
string stmt = "SELECT DATE(date1 AT TIME ZONE 'UTC' AT TIME ZONE 'australia/sydney') AS another_date";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTimezoneExpressionWithColumnBasedTimezone() {
string stmt = "SELECT 1 FROM tbl WHERE col AT TIME ZONE timezone_col < '2021-11-05 00:00:35'::date + INTERVAL '1 day' * 0";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testUnionWithOrderByAndLimitAndNoBrackets() {
string stmt = "SELECT id FROM table1 UNION SELECT id FROM table2 ORDER BY id ASC LIMIT 55";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testUnion() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM mytable WHERE mytable.col = 9 UNION ", "SELECT * FROM mytable3 WHERE mytable3.col = ? UNION "), "SELECT * FROM mytable2 LIMIT 3, 4");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setList = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(setList.getSelects()), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 0)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable3", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 1)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable2", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 2)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 2).getLimit().getOffset()!)).getValue(), null);
string statement2 = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM mytable WHERE mytable.col = 9 UNION ", "SELECT * FROM mytable3 WHERE mytable3.col = ? UNION "), "SELECT * FROM mytable2 ORDER BY COL DESC FETCH FIRST 1 ROWS ONLY WITH UR");
global::DripSharp.SqlTrellis.Statement.Select.Select select2 = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement2, true)!);
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setList2 = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(select2!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(setList2.getSelects()), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList2.getSelects(), 0)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable3", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList2.getSelects(), 1)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable2", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList2.getSelects(), 2)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(1), setList2.getFetch().getRowCount(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UR", setList2.getIsolation().getIsolation(), null);
}

public virtual void testUnion2() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM mytable WHERE mytable.col = 9 UNION ", "SELECT * FROM mytable3 WHERE mytable3.col = ? UNION "), "SELECT * FROM mytable2 LIMIT 3 OFFSET 4");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setList = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(setList.getSelects()), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 0)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable3", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 1)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable2", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 2)!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 2).getLimit().getRowCount()!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 2).getLimit().getOffset(), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(4)), global::DripSharp.Runtime.JavaCompat.ListGet(setList.getSelects(), 2).getOffset().getOffset(), null);
}

public virtual void testDistinct() {
string statement = "SELECT DISTINCT ON (myid) myid, mycol FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("myid", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getDistinct().getOnSelectItems(), 0).getExpression())).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getExpression())).getColumnName(), null);
}

public virtual void testIsDistinctFrom() {
string stmt = "SELECT name FROM tbl WHERE name IS DISTINCT FROM foo";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIsNotDistinctFrom() {
string stmt = "SELECT name FROM tbl WHERE name IS NOT DISTINCT FROM foo";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDistinctTop() {
string statement = "SELECT DISTINCT TOP 5 myid, mycol FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("myid", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression())).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getExpression())).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(plainSelect.getTop(), null);
}

public virtual void testDistinctTop2() {
string sqlStr = "SELECT TOP 5 DISTINCT myid, mycol FROM mytable WHERE mytable.col = 9";
global::DripSharp.Testing.JavaAssertions.DoesNotThrow(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
}, null);
}

public virtual void testDistinctWithFollowingBrackets() {
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT DISTINCT (phone), name FROM admin_user")!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.Distinct distinct = selectBody.getDistinct();
global::DripSharp.Testing.JavaAssertJ.That(distinct).IsNotNull().HasFieldOrPropertyWithValue("onSelectItems", (object)default!);
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.Runtime.JavaCompat.ListGet(selectBody.getSelectItems(), 0).ToString()).IsEqualTo("(phone)");
}

public virtual void testFrom() {
string statement = "SELECT * FROM mytable as mytable0, mytable1 alias_tab1, mytable2 as alias_tab2, (SELECT * FROM mytable3) AS mytable4 WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable0", plainSelect.getFromItem().getAlias().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("alias_tab1", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem().getAlias().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("alias_tab2", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 1).getFromItem().getAlias().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable4", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 2).getFromItem().getAlias().getName(), null);
}

public virtual void testJoin() {
string statement = "SELECT * FROM tab1 LEFT OUTER JOIN tab2 ON tab1.id = tab2.id";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab2", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab1.id", ((global::DripSharp.SqlTrellis.Schema.Column)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getOnExpression()!)).getLeftExpression()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isOuter(), null);
statement = "SELECT * FROM tab1 LEFT OUTER JOIN tab2 ON tab1.id = tab2.id INNER JOIN tab3";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab3", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 1).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 1).isOuter(), null);
statement = "SELECT * FROM tab1 LEFT OUTER JOIN tab2 ON tab1.id = tab2.id JOIN tab3";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab3", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 1).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 1).isOuter(), null);
statement = "SELECT * FROM tab1 LEFT OUTER JOIN tab2 ON tab1.id = tab2.id INNER JOIN tab3";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
statement = "SELECT * FROM TA2 LEFT OUTER JOIN O USING (col1, col2) WHERE D.OasSD = 'asdf' AND (kj >= 4 OR l < 'sdf')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
statement = "SELECT * FROM tab1 INNER JOIN tab2 USING (id, id2)";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab2", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isOuter(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getUsingColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("id2", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getUsingColumns(), 1).getFullyQualifiedName(), null);
statement = "SELECT * FROM tab1 RIGHT OUTER JOIN tab2 USING (id, id2)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT * FROM foo AS f LEFT OUTER JOIN (bar AS b RIGHT OUTER JOIN baz AS z ON f.id = z.id) ON f.id = b.id";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
statement = "SELECT * FROM foo AS f, OUTER bar AS b WHERE f.id = b.id";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isOuter(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isSimple(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem().getAlias().getName(), null);
}

public virtual void testFunctions() {
string statement = "SELECT MAX(id) AS max FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("max", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getAlias().getName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT substring(id, 2, 3), substring(id from 2 for 3), substring(id from 2), trim(BOTH ' ' from 'foo bar '), trim(LEADING ' ' from 'foo bar '), trim(TRAILING ' ' from 'foo bar '), trim(' ' from 'foo bar '), position('foo' in 'bar'), overlay('foo' placing 'bar' from 1), overlay('foo' placing 'bar' from 1 for 2) FROM my table";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement, true);
statement = "SELECT MAX(id), AVG(pro) AS myavg FROM mytable WHERE mytable.col = 9 GROUP BY pro";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("myavg", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getAlias().getName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT MAX(a, b, c), COUNT(*), D FROM tab1 GROUP BY D";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Expression.Function fun = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("MAX", fun.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(fun.getParameters(), 1))).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet((global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getExpression())).getParameters().getExpressions(), 0) is global::DripSharp.SqlTrellis.Statement.Select.AllColumns), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT {fn MAX(a, b, c)}, COUNT(*), D FROM tab1 GROUP BY D";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
fun = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression());
global::DripSharp.Testing.JavaAssertions.True(fun.isEscaped(), null);
global::DripSharp.Testing.JavaAssertions.Equal("MAX", fun.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(fun.getParameters().getExpressions(), 1))).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet((global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getExpression())).getParameters().getExpressions(), 0) is global::DripSharp.SqlTrellis.Statement.Select.AllColumns), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT ab.MAX(a, b, c), cd.COUNT(*), D FROM tab1 GROUP BY D";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
fun = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("ab.MAX", fun.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(fun.getParameters().getExpressions(), 1))).getFullyQualifiedName(), null);
fun = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 1).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("cd.COUNT", fun.getName(), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(fun.getParameters().getExpressions(), 0) is global::DripSharp.SqlTrellis.Statement.Select.AllColumns), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testEscapedFunctionsIssue647() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT {fn test(0)} AS COL");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT {fn concat(a, b)} AS COL");
}

public virtual void testEscapedFunctionsIssue753() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT { fn test(0)} AS COL");
global::DripSharp.Testing.JavaAssertions.Equal("SELECT {fn test(0)} AS COL", global::DripSharp.Runtime.JavaCompat.StringValueOf(stmt), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT fn FROM fn");
}

public virtual void testNamedParametersPR702() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT substring(id, 2, 3), substring(id from 2 for 3), substring(id from 2), trim(BOTH ' ' from 'foo bar '), trim(LEADING ' ' from 'foo bar '), trim(TRAILING ' ' from 'foo bar '), trim(' ' from 'foo bar '), position('foo' in 'bar'), overlay('foo' placing 'bar' from 1), overlay('foo' placing 'bar' from 1 for 2) FROM my table", true);
}

public virtual void testNamedParametersPR702_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT substring(id, 2, 3) FROM mytable");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT substring(id from 2 for 3) FROM mytable");
}

public virtual void testQuotedCastExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT col FROM test WHERE status = CASE WHEN anothercol = 5 THEN 'pending'::\"enum_test\" END");
}

public virtual void testWhere() {
string whereToString = "(1 + 2) * (1+2) > ?";
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed(whereToString, true);
string statement = "SELECT * FROM tab1 WHERE";
whereToString = "(a + b + c / d + e * f) * (a / b * (a + b)) > ?";
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed(whereToString, true);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(statement, " "), whereToString), true)!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getWhere() is global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThan), null);
global::DripSharp.Testing.JavaAssertions.True((((global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThan)(plainSelect.getWhere()!)).getLeftExpression() is global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Multiplication), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getWhere(), whereToString);
whereToString = "(7 * s + 9 / 3) NOT BETWEEN 3 AND ?";
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(statement, " "), whereToString), true)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getWhere(), whereToString);
whereToString = "a / b NOT IN (?, 's''adf', 234.2)";
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(statement, " "), whereToString), true)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getWhere(), whereToString);
whereToString = "NOT 0 = 0";
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(statement, " "), whereToString), true)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getWhere(), whereToString);
whereToString = "NOT (0 = 0)";
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(statement, " "), whereToString), true)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getWhere(), whereToString);
}

public virtual void testGroupBy() {
string statement = "SELECT * FROM tab1 WHERE a > 34 GROUP BY tab1.b";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getGroupBy().getGroupByExpressions()), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab1.b", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getGroupBy().getGroupByExpressions(), 0)!)).getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT * FROM tab1 WHERE a > 34 GROUP BY 2, 3";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getGroupBy().getGroupByExpressions()), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(2), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getGroupBy().getGroupByExpressions(), 0)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getGroupBy().getGroupByExpressions(), 1)!)).getValue(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testHaving() {
string statement = "SELECT MAX(tab1.b) FROM tab1 WHERE a > 34 GROUP BY tab1.b HAVING MAX(tab1.b) > 56";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getHaving() is global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThan), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT MAX(tab1.b) FROM tab1 WHERE a > 34 HAVING MAX(tab1.b) IN (56, 32, 3, ?)";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getHaving() is global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testExists() {
string statement = "SELECT * FROM tab1 WHERE ";
string where = "EXISTS (SELECT * FROM tab2)";
statement += where;
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(statement));
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.StringValueOf(parsed), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(parsed!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getWhere(), where);
}

public virtual void testNotExists() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tab1 WHERE NOT EXISTS (SELECT * FROM tab2)");
}

public virtual void testNotExistsIssue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t001 t WHERE NOT EXISTS (SELECT * FROM t002 t1 WHERE t.c1 = t1.c1 AND t.c2 = t1.c2 AND ('241' IN (t1.c3 || t1.c4)))");
}

public virtual void testOrderBy() {
string statement = "SELECT * FROM tab1 WHERE a > 34 GROUP BY tab1.b ORDER BY tab1.a DESC, tab1.b ASC";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getOrderByElements()), null);
global::DripSharp.Testing.JavaAssertions.Equal("tab1.a", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getOrderByElements(), 0).getExpression()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getOrderByElements(), 1).getExpression()!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getOrderByElements(), 1).isAsc(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getOrderByElements(), 0).isAsc(), null);
statement = "SELECT * FROM tab1 WHERE a > 34 GROUP BY tab1.b ORDER BY tab1.a, 2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getOrderByElements()), null);
global::DripSharp.Testing.JavaAssertions.Equal("a", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getOrderByElements(), 0).getExpression()!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(2), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getOrderByElements(), 1).getExpression()!)).getValue(), null);
}

public virtual void testOrderByNullsFirst() {
string statement = "SELECT a FROM tab1 ORDER BY a NULLS FIRST";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testOrderByWithComplexExpression() {
string statement = "SELECT col FROM tbl tbl_alias ORDER BY tbl_alias.id = 1 DESC";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testTimestamp() {
string statement = "SELECT * FROM tab1 WHERE a > {ts '2004-04-30 04:05:34.56'}";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("2004-04-30 04:05:34.56", (((global::DripSharp.SqlTrellis.Expression.TimestampValue)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThan)(plainSelect.getWhere()!)).getRightExpression()!)).getValue()).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testTime() {
string statement = "SELECT * FROM tab1 WHERE a > {t '04:05:34'}";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("04:05:34", (((global::DripSharp.SqlTrellis.Expression.TimeValue)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.GreaterThan)(plainSelect.getWhere()!)).getRightExpression()!)).getValue()).ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testBetweenDate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE col BETWEEN {d '2015-09-19'} AND {d '2015-09-24'}");
}

public virtual void testCase() {
string statement = "SELECT a, CASE b WHEN 1 THEN 2 END FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT a, (CASE WHEN (a > 2) THEN 3 END) AS b FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT a, (CASE WHEN a > 2 THEN 3 ELSE 4 END) AS b FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT a, (CASE b WHEN 1 THEN 2 WHEN 3 THEN 4 ELSE 5 END) FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT a, (CASE ", "WHEN b > 1 THEN 'BBB' "), "WHEN a = 3 THEN 'AAA' "), "END) FROM tab1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT a, (CASE ", "WHEN b > 1 THEN 'BBB' "), "WHEN a = 3 THEN 'AAA' "), "END) FROM tab1 "), "WHERE c = (CASE "), "WHEN d <> 3 THEN 5 "), "ELSE 10 "), "END)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT a, CASE a ", "WHEN 'b' THEN 'BBB' "), "WHEN 'a' THEN 'AAA' "), "END AS b FROM tab1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT a FROM tab1 WHERE CASE b WHEN 1 THEN 2 WHEN 3 THEN 4 ELSE 5 END > 34";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT a FROM tab1 WHERE CASE b WHEN 1 THEN 2 + 3 ELSE 4 END > 34";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT  a\n", "        , ( CASE\n"), "                    WHEN ( CASE\n"), "                                        WHEN 1\n"), "                                            THEN 10\n"), "                                        ELSE 20\n"), "                                    END ) > 15\n"), "                        THEN 'BBB'\n"), "                    WHEN (  SELECT c\n"), "                            FROM tab2\n"), "                            WHERE d = 2 ) = 3\n"), "                        THEN 'AAA'\n"), "                END )\n"), "FROM tab1\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
}

public virtual void testNestedCaseCondition() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN CASE WHEN 1 THEN 10 ELSE 20 END > 15 THEN 'BBB' END FROM tab1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (CASE WHEN (CASE a WHEN 1 THEN 10 ELSE 20 END) > 15 THEN 'BBB' END) FROM tab1");
}

public virtual void testIssue371SimplifiedCase() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE col + 4 WHEN 2 THEN 1 ELSE 0 END");
}

public virtual void testIssue371SimplifiedCase2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE col > 4 WHEN true THEN 1 ELSE 0 END");
}

public virtual void testIssue235SimplifiedCase3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN (CASE WHEN (CASE WHEN (1) THEN 0 END) THEN 0 END) THEN 0 END FROM a");
}

public virtual void testIssue235SimplifiedCase4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN (CASE WHEN (CASE WHEN (CASE WHEN (1) THEN 0 END) THEN 0 END) THEN 0 END) THEN 0 END FROM a");
}

public virtual void testIssue862CaseWhenConcat() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT c1, CASE c1 || c2 WHEN '091' THEN '2' ELSE '1' END AS c11 FROM T2");
}

public virtual void testExpressionsInCaseBeforeWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a FROM tbl1 LEFT JOIN tbl2 ON CASE tbl1.col1 WHEN tbl1.col1 = 1 THEN tbl1.col2 = tbl2.col2 ELSE tbl1.col3 = tbl2.col3 END");
}

public virtual void testExpressionsInIntervalExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT DATE_SUB(mydate, INTERVAL DAY(anotherdate) - 1 DAY) FROM tbl");
}

public virtual void testReplaceAsFunction() {
string statement = "SELECT REPLACE(a, 'b', c) FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(stmt!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getSelectItems()), null);
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression();
global::DripSharp.Testing.JavaAssertions.True((expression is global::DripSharp.SqlTrellis.Expression.Function), null);
global::DripSharp.SqlTrellis.Expression.Function func = (global::DripSharp.SqlTrellis.Expression.Function)(expression!);
global::DripSharp.Testing.JavaAssertions.Equal("REPLACE", func.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(func.getParameters().getExpressions()), null);
}

public virtual void testLike() {
string statement = "SELECT * FROM tab1 WHERE a LIKE 'test'";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("test", ((global::DripSharp.SqlTrellis.Expression.StringValue)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(plainSelect.getWhere()!)).getRightExpression()!)).getValue(), null);
statement = "SELECT * FROM tab1 WHERE a LIKE 'test' ESCAPE 'test2'";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("test", ((global::DripSharp.SqlTrellis.Expression.StringValue)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(plainSelect.getWhere()!)).getRightExpression()!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.StringValue("test2"), ((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(plainSelect.getWhere()!)).getEscape(), null);
}

public virtual void testNotLike() {
string statement = "SELECT * FROM tab1 WHERE a NOT LIKE 'test'";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal("test", ((global::DripSharp.SqlTrellis.Expression.StringValue)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(plainSelect.getWhere()!)).getRightExpression()!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.True(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(plainSelect.getWhere()!)).isNot(), null);
}

public virtual void testNotLikeWithNotBeforeExpression() {
string statement = "SELECT * FROM tab1 WHERE NOT a LIKE 'test'";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getWhere() is global::DripSharp.SqlTrellis.Expression.NotExpression), null);
global::DripSharp.SqlTrellis.Expression.NotExpression notExpr = (global::DripSharp.SqlTrellis.Expression.NotExpression)(plainSelect.getWhere()!);
global::DripSharp.Testing.JavaAssertions.Equal("test", ((global::DripSharp.SqlTrellis.Expression.StringValue)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(notExpr.getExpression()!)).getRightExpression()!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.False(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(notExpr.getExpression()!)).isNot(), null);
}

public virtual void testNotLikeIssue775() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mybatisplus WHERE id NOT LIKE ?");
}

public virtual void testIlike() {
string statement = "SELECT col1 FROM table1 WHERE col1 ILIKE '%hello%'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testSelectOrderHaving() {
string statement = "SELECT units, count(units) AS num FROM currency GROUP BY units HAVING count(units) > 1 ORDER BY num";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testDouble() {
string statement = "SELECT 1e2, * FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(100.0D, (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.DoubleValue>(global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getSelectItems(), 0).getExpression())).getValue(), null, (double)(0));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 1.e2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(100.0D, ((global::DripSharp.SqlTrellis.Expression.DoubleValue)(((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getWhere()!)).getRightExpression()!)).getValue(), null, (double)(0));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 1.2e2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(120.0D, ((global::DripSharp.SqlTrellis.Expression.DoubleValue)(((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getWhere()!)).getRightExpression()!)).getValue(), null, (double)(0));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
statement = "SELECT * FROM mytable WHERE mytable.col = 2e2";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(200.0D, ((global::DripSharp.SqlTrellis.Expression.DoubleValue)(((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getWhere()!)).getRightExpression()!)).getValue(), null, (double)(0));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testDouble2() {
string statement = "SELECT 1.e22 FROM mytable";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(1.0E22D, (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.DoubleValue>(global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getSelectItems(), 0).getExpression())).getValue(), null, (double)(0));
}

public virtual void testDouble3() {
string statement = "SELECT 1. FROM mytable";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(1.0D, (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.DoubleValue>(global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getSelectItems(), 0).getExpression())).getValue(), null, (double)(0));
}

public virtual void testDouble4() {
string statement = "SELECT 1.2e22 FROM mytable";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(1.2E22D, (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.DoubleValue>(global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)).getSelectItems(), 0).getExpression())).getValue(), null, (double)(0));
}

public virtual void testWith() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH DINFO (DEPTNO, AVGSALARY, EMPCOUNT) AS ", "(SELECT OTHERS.WORKDEPT, AVG(OTHERS.SALARY), COUNT(*) FROM EMPLOYEE AS OTHERS "), "GROUP BY OTHERS.WORKDEPT), DINFOMAX AS (SELECT MAX(AVGSALARY) AS AVGMAX FROM DINFO) "), "SELECT THIS_EMP.EMPNO, THIS_EMP.SALARY, DINFO.AVGSALARY, DINFO.EMPCOUNT, DINFOMAX.AVGMAX "), "FROM EMPLOYEE AS THIS_EMP INNER JOIN DINFO INNER JOIN DINFOMAX "), "WHERE THIS_EMP.JOB = 'SALESREP' AND THIS_EMP.WORKDEPT = DINFO.DEPTNO");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT OTHERS.WORKDEPT, AVG(OTHERS.SALARY), COUNT(*) FROM EMPLOYEE AS OTHERS GROUP BY OTHERS.WORKDEPT", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" DINFO", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT MAX(AVGSALARY) AS AVGMAX FROM DINFO", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" DINFOMAX", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

public virtual void testWithRecursive() {
string statement = "WITH RECURSIVE t (n) AS ((SELECT 1) UNION ALL (SELECT n + 1 FROM t WHERE n < 100)) SELECT sum(n) FROM t";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("((SELECT 1) UNION ALL (SELECT n + 1 FROM t WHERE n < 100))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" t", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).isRecursive(), null);
}

public virtual void testSelectAliasInQuotes() {
string statement = "SELECT mycolumn AS \"My Column Name\" FROM mytable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testSelectAliasWithoutAs() {
string statement = "SELECT mycolumn \"My Column Name\" FROM mytable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testSelectJoinWithComma() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("SELECT cb.Genus, cb.Species FROM Coleccion_de_Briofitas AS cb, unigeoestados AS es ", "WHERE es.nombre = \"Tamaulipas\" AND cb.the_geom = es.geom");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testDeparser() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT a.OWNERLASTNAME, a.OWNERFIRSTNAME ", "FROM ANTIQUEOWNERS AS a, ANTIQUES AS b "), "WHERE b.BUYERID = a.OWNERID AND b.ITEM = 'Chair'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT count(DISTINCT f + 4) FROM a";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
statement = "SELECT count(DISTINCT f, g, h) FROM a";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCount2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(ALL col1 + col2) FROM mytable");
}

public virtual void testCount3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(UNIQUE col) FROM mytable");
}

public virtual void testMysqlQuote() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT `a.OWNERLASTNAME`, `OWNERFIRSTNAME` ", "FROM `ANTIQUEOWNERS` AS a, ANTIQUES AS b "), "WHERE b.BUYERID = a.OWNERID AND b.ITEM = 'Chair'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testConcat() {
string statement = "SELECT a || b || c + 4 FROM t";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testConcatProblem2() {
string stmt = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT MAX(((((", "(SPA.SOORTAANLEVERPERIODE)::VARCHAR (2) || (VARCHAR(SPA.AANLEVERPERIODEJAAR))::VARCHAR (4)"), ") || TO_CHAR(SPA.AANLEVERPERIODEVOLGNR, 'FM09'::VARCHAR)"), ") || TO_CHAR((10000 - SPA.VERSCHIJNINGSVOLGNR), 'FM0999'::VARCHAR)"), ") || (SPA.GESLACHT)::VARCHAR (1))) AS GESLACHT_TMP FROM testtable");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_1() {
string stmt = "SELECT TO_CHAR(SPA.AANLEVERPERIODEVOLGNR, 'FM09'::VARCHAR) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_2() {
string stmt = "SELECT MAX((SPA.SOORTAANLEVERPERIODE)::VARCHAR (2) || (VARCHAR(SPA.AANLEVERPERIODEJAAR))::VARCHAR (4)) AS GESLACHT_TMP FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_3() {
string stmt = "SELECT TO_CHAR((10000 - SPA.VERSCHIJNINGSVOLGNR), 'FM0999'::VARCHAR) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_4() {
string stmt = "SELECT (SPA.GESLACHT)::VARCHAR (1) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_5() {
string stmt = "SELECT max((a || b) || c) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_5_1() {
string stmt = "SELECT (a || b) || c FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_5_2() {
string stmt = "SELECT (a + b) + c FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testConcatProblem2_6() {
string stmt = "SELECT max(a || b || c) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMatches() {
string statement = "SELECT * FROM team WHERE team.search_column @@ to_tsquery('new & york & yankees')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testGroupByExpression() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT col1, col2, col1 + col2, sum(col8)", " FROM table1 "), "GROUP BY col1, col2, col1 + col2");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testBitwise() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("SELECT col1 & 32, col2 ^ col1, col1 | col2", " FROM table1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testSelectFunction() {
string statement = "SELECT 1 + 2 AS sum";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testWeirdSelect() {
string sql = "select r.reviews_id, substring(rd.reviews_text, 100) as reviews_text, r.reviews_rating, r.date_added, r.customers_name from reviews r, reviews_description rd where r.products_id = '19' and r.reviews_id = rd.reviews_id and rd.languages_id = '1' and r.reviews_status = 1 order by r.reviews_id desc limit 0, 6";
this.parserManager.parse(new global::System.IO.StringReader(sql));
}

public virtual void testCast() {
string stmt = "SELECT CAST(a AS varchar) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT CAST(a AS varchar2) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastInCast() {
string stmt = "SELECT CAST(CAST(a AS numeric) AS varchar) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastInCast2() {
string stmt = "SELECT CAST('test' + CAST(assertEqual AS numeric) AS varchar) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem() {
string stmt = "SELECT CAST(col1 AS varchar (256)) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem2() {
string stmt = "SELECT col1::varchar FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTryCast() {
string stmt = "SELECT TRY_CAST(a AS varchar) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT CAST(a AS varchar2) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTryCastInTryCast() {
string stmt = "SELECT TRY_CAST(TRY_CAST(a AS numeric) AS varchar) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTryCastInTryCast2() {
string stmt = "SELECT TRY_CAST('test' + TRY_CAST(assertEqual AS numeric) AS varchar) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTryCastTypeProblem() {
string stmt = "SELECT TRY_CAST(col1 AS varchar (256)) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMySQLHintStraightJoin() {
string stmt = "SELECT col FROM tbl STRAIGHT_JOIN tbl2 ON tbl.id = tbl2.id";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testStraightJoinInSelect() {
string stmt = "SELECT STRAIGHT_JOIN col, col2 FROM tbl INNER JOIN tbl2 ON tbl.id = tbl2.id";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem3() {
string stmt = "SELECT col1::varchar (256) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem4() {
string stmt = "SELECT 5::varchar (256) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem5() {
string stmt = "SELECT 5.67::varchar (256) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem6() {
string stmt = "SELECT 'test'::character varying FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem7() {
string stmt = "SELECT CAST('test' AS character varying) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCastTypeProblem8() {
string stmt = "SELECT CAST('123' AS double precision) FROM tabelle1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCaseElseAddition() {
string stmt = "SELECT CASE WHEN 1 + 3 > 20 THEN 0 ELSE 1000 + 1 END AS d FROM dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testBrackets() {
string stmt = "SELECT table_a.name AS [Test] FROM table_a";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, false, (parser) => parser.withSquareBracketQuotation(true));
}

public virtual void testBrackets2() {
string stmt = "SELECT [a] FROM t";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, false, (parser) => parser.withSquareBracketQuotation(true));
}

public virtual void testIssue1595() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT [id] FROM [guest].[12tableName]", false, (parser) => parser.withSquareBracketQuotation(true));
}

public virtual void testBrackets3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM \"2016\"");
}

public virtual void testProblemSqlServer_Modulo_Proz() {
string stmt = "SELECT 5 % 2 FROM A";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlServer_Modulo_mod() {
string stmt = "SELECT mod(5, 2) FROM A";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlServer_Modulo() {
string stmt = "SELECT convert(varchar(255), DATEDIFF(month, year1, abc_datum) / 12) + ' year, ' + convert(varchar(255), DATEDIFF(month, year2, abc_datum) % 12) + ' month' FROM test_table";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIsNot() {
string stmt = "SELECT * FROM test WHERE a IS NOT NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIsNot2() {
string stmt = "SELECT * FROM test WHERE NOT a IS NULL";
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(stmt));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, "SELECT * FROM test WHERE NOT a IS NULL");
}

public virtual void testProblemSqlAnalytic() {
string stmt = "SELECT a, row_number() OVER (ORDER BY a) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic2() {
string stmt = "SELECT a, row_number() OVER (ORDER BY a, b) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic3() {
string stmt = "SELECT a, row_number() OVER (PARTITION BY c ORDER BY a, b) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic4EmptyOver() {
string stmt = "SELECT a, row_number() OVER () AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic5AggregateColumnValue() {
string stmt = "SELECT a, sum(b) OVER () AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic6AggregateColumnValue() {
string stmt = "SELECT a, sum(b + 5) OVER (ORDER BY a) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic7Count() {
string stmt = "SELECT count(*) OVER () AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic8Complex() {
string stmt = "SELECT ID, NAME, SALARY, SUM(SALARY) OVER () AS SUM_SAL, AVG(SALARY) OVER () AS AVG_SAL, MIN(SALARY) OVER () AS MIN_SAL, MAX(SALARY) OVER () AS MAX_SAL, COUNT(*) OVER () AS ROWS2 FROM STAFF WHERE ID < 60 ORDER BY ID";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic9CommaListPartition() {
string stmt = "SELECT a, row_number() OVER (PARTITION BY c, d ORDER BY a, b) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic10Lag() {
string stmt = "SELECT a, lag(a, 1) OVER (PARTITION BY c ORDER BY a, b) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlAnalytic11Lag() {
string stmt = "SELECT a, lag(a, 1, 0) OVER (PARTITION BY c ORDER BY a, b) AS n FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testAnalyticFunction12() {
string statement = "SELECT SUM(a) OVER (PARTITION BY b ORDER BY c) FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction13() {
string statement = "SELECT SUM(a) OVER () FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction14() {
string statement = "SELECT SUM(a) OVER (PARTITION BY b ) FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction15() {
string statement = "SELECT SUM(a) OVER (ORDER BY c) FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction16() {
string statement = "SELECT SUM(a) OVER (ORDER BY c NULLS FIRST) FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction17() {
string statement = "SELECT AVG(sal) OVER (PARTITION BY deptno ORDER BY sal ROWS BETWEEN 0 PRECEDING AND 0 PRECEDING) AS avg_of_current_sal FROM emp";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction18() {
string statement = "SELECT AVG(sal) OVER (PARTITION BY deptno ORDER BY sal RANGE CURRENT ROW) AS avg_of_current_sal FROM emp";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunctionProblem1() {
string statement = "SELECT last_value(s.revenue_hold) OVER (PARTITION BY s.id_d_insertion_order, s.id_d_product_ad_attr, trunc(s.date_id, 'mm') ORDER BY s.date_id) AS col FROM s";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunction19() {
string statement = "SELECT count(DISTINCT CASE WHEN client_organic_search_drop_flag = 1 THEN brand END) OVER (PARTITION BY client, category_1, category_2, category_3, category_4 ) AS client_brand_org_drop_count FROM sometable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunctionProblem1b() {
string statement = "SELECT last_value(s.revenue_hold) OVER (PARTITION BY s.id_d_insertion_order, s.id_d_product_ad_attr, trunc(s.date_id, 'mm') ORDER BY s.date_id ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) AS col FROM s";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testAnalyticFunctionIssue670() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT last_value(some_column IGNORE NULLS) OVER (PARTITION BY some_other_column_1, some_other_column_2 ORDER BY some_other_column_3 ROWS BETWEEN UNBOUNDED PRECEDING AND UNBOUNDED FOLLOWING) column_alias FROM some_table");
}

public virtual void testAnalyticFunctionFilterIssue866() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COUNT(*) FILTER (WHERE name = 'Raj') OVER (PARTITION BY name ) FROM table");
}

public virtual void testAnalyticPartitionBooleanExpressionIssue864() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COUNT(*) OVER (PARTITION BY (event = 'admit' OR event = 'family visit') ORDER BY day ROWS BETWEEN CURRENT ROW AND UNBOUNDED FOLLOWING) family_visits FROM patients");
}

public virtual void testAnalyticPartitionBooleanExpressionIssue864_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COUNT(*) OVER (PARTITION BY (event = 'admit' OR event = 'family visit') ) family_visits FROM patients");
}

public virtual void testAnalyticFunctionFilterIssue934() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COUNT(*) FILTER (WHERE name = 'Raj') FROM table");
}

public virtual void testFunctionLeft() {
string statement = "SELECT left(table1.col1, 4) FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testFunctionRight() {
string statement = "SELECT right(table1.col1, 4) FROM table1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testOneColumnFullTextSearchMySQL() {
string statement = "SELECT MATCH (col1) AGAINST ('test' IN NATURAL LANGUAGE MODE) relevance FROM tbl";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testSeveralColumnsFullTextSearchMySQL() {
string statement = "SELECT MATCH (col1,col2,col3) AGAINST ('test' IN NATURAL LANGUAGE MODE) relevance FROM tbl";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testFullTextSearchInDefaultMode() {
string statement = "SELECT col FROM tbl WHERE MATCH (col1,col2,col3) AGAINST ('test') ORDER BY col";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testIsTrue() {
string statement = "SELECT col FROM tbl WHERE col IS TRUE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testIsFalse() {
string statement = "SELECT col FROM tbl WHERE col IS FALSE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testIsNotTrue() {
string statement = "SELECT col FROM tbl WHERE col IS NOT TRUE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testIsNotFalse() {
string statement = "SELECT col FROM tbl WHERE col IS NOT FALSE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testIsUnknown() {
string statement = "SELECT col FROM tbl WHERE col IS UNKNOWN";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testIsNotUnknown() {
string statement = "SELECT col FROM tbl WHERE col IS NOT UNKNOWN";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testTSQLJoin() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a *= tabelle2.b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTSQLJoin2() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a =* tabelle2.b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleJoin() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a = tabelle2.b(+)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleJoin2() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a(+) = tabelle2.b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleJoin2_1(string value) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a", value), " = tabelle2.b"), true);
}

public virtual void testOracleJoin2_2(string value) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a = tabelle2.b", value), true);
}

public virtual void testOracleJoin3() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a(+) > tabelle2.b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleJoin3_1() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a > tabelle2.b(+)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleJoin4() {
string stmt = "SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a(+) = tabelle2.b AND tabelle1.b(+) IN ('A', 'B')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleJoinIssue318() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM TBL_A, TBL_B, TBL_C WHERE TBL_A.ID(+) = TBL_B.ID AND TBL_C.ROOM(+) = TBL_B.ROOM");
}

public virtual void testProblemSqlIntersect() {
string stmt = "(SELECT * FROM a) INTERSECT (SELECT * FROM b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT * FROM a INTERSECT SELECT * FROM b";
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(stmt));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, "SELECT * FROM a INTERSECT SELECT * FROM b");
}

public virtual void testIntegerDivOperator() {
string stmt = "SELECT col DIV 3";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemSqlExcept() {
string stmt = "(SELECT * FROM a) EXCEPT (SELECT * FROM b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT * FROM a EXCEPT SELECT * FROM b";
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(stmt));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, "SELECT * FROM a EXCEPT SELECT * FROM b");
}

public virtual void testProblemSqlMinus() {
string stmt = "(SELECT * FROM a) MINUS (SELECT * FROM b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT * FROM a MINUS SELECT * FROM b";
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(stmt));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, "SELECT * FROM a MINUS SELECT * FROM b");
}

public virtual void testProblemSqlCombinedSets() {
string stmt = "(SELECT * FROM a) INTERSECT (SELECT * FROM b) UNION (SELECT * FROM c)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testWithStatement() {
string stmt = "WITH test AS (SELECT mslink FROM feature) SELECT * FROM feature WHERE mslink IN (SELECT mslink FROM test)";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT mslink FROM feature", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" test", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testSubjoinWithJoins() {
string stmt = "SELECT COUNT(DISTINCT `tbl1`.`id`) FROM (`tbl1`, `tbl2`, `tbl3`)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testWithUnionProblem() {
string stmt = "WITH test AS ((SELECT mslink FROM tablea) UNION (SELECT mslink FROM tableb)) SELECT * FROM tablea WHERE mslink IN (SELECT mslink FROM test)";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("((SELECT mslink FROM tablea) UNION (SELECT mslink FROM tableb))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" test", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testWithUnionAllProblem() {
string stmt = "WITH test AS ((SELECT mslink FROM tablea) UNION ALL (SELECT mslink FROM tableb)) SELECT * FROM tablea WHERE mslink IN (SELECT mslink FROM test)";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("((SELECT mslink FROM tablea) UNION ALL (SELECT mslink FROM tableb))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" test", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testWithUnionProblem3() {
string stmt = "WITH test AS ((SELECT mslink, CAST(tablea.fname AS varchar) FROM tablea INNER JOIN tableb ON tablea.mslink = tableb.mslink AND tableb.deleted = 0 WHERE tablea.fname IS NULL AND 1 = 0) UNION ALL (SELECT mslink FROM tableb)) SELECT * FROM tablea WHERE mslink IN (SELECT mslink FROM test)";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("((SELECT mslink, CAST(tablea.fname AS varchar) FROM tablea INNER JOIN tableb ON tablea.mslink = tableb.mslink AND tableb.deleted = 0 WHERE tablea.fname IS NULL AND 1 = 0) UNION ALL (SELECT mslink FROM tableb))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" test", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testWithUnionProblem4() {
string stmt = "WITH hist AS ((SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, 0 AS level, CAST(gl.mslink AS VARCHAR) AS path, ae.feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 WHERE gl.parent IS NULL AND gl.mslink <> 0) UNION ALL (SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, hist.level + 1 AS level, CAST(hist.path + '.' + CAST(gl.mslink AS VARCHAR) AS VARCHAR) AS path, ae.feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 INNER JOIN hist ON gl.parent = hist.mslink WHERE gl.mslink <> 0)) SELECT mslink, space(level * 4) + txt AS txt, nr, feature, path FROM hist WHERE EXISTS (SELECT feature FROM tablec WHERE mslink = 0 AND ((feature IN (1, 2) AND hist.feature = 3) OR (feature IN (4) AND hist.feature = 2)))";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("((SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, 0 AS level, CAST(gl.mslink AS VARCHAR) AS path, ae.feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 WHERE gl.parent IS NULL AND gl.mslink <> 0) UNION ALL (SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, hist.level + 1 AS level, CAST(hist.path + '.' + CAST(gl.mslink AS VARCHAR) AS VARCHAR) AS path, ae.feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 INNER JOIN hist ON gl.parent = hist.mslink WHERE gl.mslink <> 0))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" hist", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testWithUnionProblem5() {
string stmt = "WITH hist AS ((SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, 0 AS level, CAST(gl.mslink AS VARCHAR) AS path, ae.feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 WHERE gl.parent IS NULL AND gl.mslink <> 0) UNION ALL (SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, hist.level + 1 AS level, CAST(hist.path + '.' + CAST(gl.mslink AS VARCHAR) AS VARCHAR) AS path, 5 AS feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 INNER JOIN hist ON gl.parent = hist.mslink WHERE gl.mslink <> 0)) SELECT * FROM hist";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("((SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, 0 AS level, CAST(gl.mslink AS VARCHAR) AS path, ae.feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 WHERE gl.parent IS NULL AND gl.mslink <> 0) UNION ALL (SELECT gl.mslink, ba.gl_name AS txt, ba.gl_nummer AS nr, hist.level + 1 AS level, CAST(hist.path + '.' + CAST(gl.mslink AS VARCHAR) AS VARCHAR) AS path, 5 AS feature FROM tablea AS gl INNER JOIN tableb AS ba ON gl.mslink = ba.gl_mslink INNER JOIN tablec AS ae ON gl.mslink = ae.mslink AND ae.deleted = 0 INNER JOIN hist ON gl.parent = hist.mslink WHERE gl.mslink <> 0))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" hist", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testExtractFrom1() {
string stmt = "SELECT EXTRACT(month FROM datecolumn) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testExtractFrom2() {
string stmt = "SELECT EXTRACT(year FROM now()) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testExtractFrom3() {
string stmt = "SELECT EXTRACT(year FROM (now() - 2)) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testExtractFrom4() {
string stmt = "SELECT EXTRACT(minutes FROM now() - '01:22:00') FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemFunction() {
string stmt = "SELECT test() FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(parsed!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression> item = global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0);
global::DripSharp.Testing.JavaAssertions.True((item.getExpression() is global::DripSharp.SqlTrellis.Expression.Function), null);
global::DripSharp.Testing.JavaAssertions.Equal("test", ((global::DripSharp.SqlTrellis.Expression.Function)(item.getExpression()!)).getName(), null);
}

public virtual void testProblemFunction2() {
string stmt = "SELECT sysdate FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testProblemFunction3() {
string stmt = "SELECT TRUNCATE(col) FROM testtable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testAdditionalLettersGerman() {
string stmt = "SELECT col\u00E4, col\u00F6, col\u00FC FROM testtable\u00E4\u00F6\u00FC";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT colA, col\u00D6, col\u00DC FROM testtable\u00C4\u00D6\u00DC";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT \u00C4col FROM testtable\u00C4\u00D6\u00DC";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
stmt = "SELECT \u00DFcol\u00DF FROM testtable\u00DF";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testAdditionalLettersSpanish() {
string stmt = "SELECT * FROM a\u00F1os";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiTableJoin() {
string stmt = "SELECT * FROM taba INNER JOIN tabb ON taba.a = tabb.a, tabc LEFT JOIN tabd ON tabc.c = tabd.c";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testTableCrossJoin() {
string stmt = "SELECT * FROM taba CROSS JOIN tabb";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testLateral1() {
string stmt = "SELECT O.ORDERID, O.CUSTNAME, OL.LINETOTAL FROM ORDERS AS O, LATERAL(SELECT SUM(NETAMT) AS LINETOTAL FROM ORDERLINES AS LINES WHERE LINES.ORDERID = O.ORDERID) AS OL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testLateralComplex1() {
string stmt = global::DripSharp.SqlTrellis.Tests.Support.ReadText(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SelectTest), "complex-lateral-select-request.txt"), global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(stmt))!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT O.ORDERID, O.CUSTNAME, OL.LINETOTAL, OC.ORDCHGTOTAL, OT.TAXTOTAL FROM ORDERS O, LATERAL(SELECT SUM(NETAMT) AS LINETOTAL FROM ORDERLINES LINES WHERE LINES.ORDERID = O.ORDERID) AS OL, LATERAL(SELECT SUM(CHGAMT) AS ORDCHGTOTAL FROM ORDERCHARGES CHARGES WHERE LINES.ORDERID = O.ORDERID) AS OC, LATERAL(SELECT SUM(TAXAMT) AS TAXTOTAL FROM ORDERTAXES TAXES WHERE TAXES.ORDERID = O.ORDERID) AS OT", select.ToString(), null);
}

public virtual void testValues() {
string stmt = "SELECT * FROM (VALUES (1, 2), (3, 4)) AS test";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testValues2() {
string stmt = "SELECT * FROM (VALUES 1, 2, 3, 4) AS test";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testValues3() {
string stmt = "SELECT * FROM (VALUES 1, 2, 3, 4) AS test(a)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testValues4() {
string stmt = "SELECT * FROM (VALUES (1, 2), (3, 4)) AS test(a, b)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testValues5() {
string stmt = "SELECT X, Y FROM (VALUES (0, 'a'), (1, 'b')) AS MY_TEMP_TABLE(X, Y)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testValues6BothVariants() {
string stmt = "SELECT I FROM (VALUES 1, 2, 3) AS MY_TEMP_TABLE(I) WHERE I IN (SELECT * FROM (VALUES 1, 2) AS TEST)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIntervalWithColumn() {
string stmt = "SELECT DATE_ADD(start_date, INTERVAL duration MINUTE) AS end_datetime FROM appointment";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIntervalWithFunction() {
string stmt = "SELECT DATE_ADD(start_date, INTERVAL COALESCE(duration, 21) MINUTE) AS end_datetime FROM appointment";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testInterval1() {
string stmt = "SELECT 5 + INTERVAL '3 days'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testInterval2() {
string stmt = "SELECT to_timestamp(to_char(now() - INTERVAL '45 MINUTE', 'YYYY-MM-DD-HH24:')) AS START_TIME FROM tab1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
global::DripSharp.SqlTrellis.Statement.Statement st = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(st!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getSelectItems()), null);
global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression> item = (global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0)!);
global::DripSharp.SqlTrellis.Expression.Function function = (global::DripSharp.SqlTrellis.Expression.Function)(item.getExpression()!);
global::DripSharp.Testing.JavaAssertions.Equal("to_timestamp", function.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(function.getParameters().getExpressions()), null);
global::DripSharp.SqlTrellis.Expression.Function func2 = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(global::DripSharp.Runtime.JavaCompat.ListGet(function.getParameters().getExpressions(), 0));
global::DripSharp.Testing.JavaAssertions.Equal("to_char", func2.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(func2.getParameters().getExpressions()), null);
global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Subtraction sub = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Subtraction>(global::DripSharp.Runtime.JavaCompat.ListGet(func2.getParameters().getExpressions(), 0));
global::DripSharp.Testing.JavaAssertions.True((sub.getRightExpression() is global::DripSharp.SqlTrellis.Expression.IntervalExpression), null);
global::DripSharp.SqlTrellis.Expression.IntervalExpression iexpr = (global::DripSharp.SqlTrellis.Expression.IntervalExpression)(sub.getRightExpression()!);
global::DripSharp.Testing.JavaAssertions.Equal("'45 MINUTE'", iexpr.getParameter(), null);
}

public virtual void testInterval3() {
string stmt = "SELECT 5 + INTERVAL '3' day";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testInterval4() {
string stmt = "SELECT '2008-12-31 23:59:59' + INTERVAL 1 SECOND";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testInterval5_Issue228() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ADDDATE(timeColumn1, INTERVAL 420 MINUTES) AS timeColumn1 FROM tbl");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ADDDATE(timeColumn1, INTERVAL -420 MINUTES) AS timeColumn1 FROM tbl");
}

public virtual void testMultiValueIn() {
string stmt = "SELECT * FROM mytable WHERE (a, b, c) IN (SELECT a, b, c FROM mytable2)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiValueIn2() {
string stmt = "SELECT * FROM mytable WHERE (trim(a), trim(b)) IN (SELECT a, b FROM mytable2)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true);
}

public virtual void testMultiValueIn3() {
string stmt = "SELECT * FROM mytable WHERE (SSN, SSM) IN (('11111111111111', '22222222222222'))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiValueIn_withAnd() {
string stmt = "SELECT * FROM mytable WHERE (SSN, SSM) IN (('11111111111111', '22222222222222')) AND 1 = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiValueIn4() {
string stmt = "SELECT * FROM mytable WHERE (a, b) IN ((1, 2), (3, 4), (5, 6), (7, 8))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void selectIsolationKeywordsAsAlias() {
string stmt = "SELECT col FROM tbl cs";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiValueInBinds() {
string stmt = "SELECT * FROM mytable WHERE (a, b) IN ((?, ?), (?, ?))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testUnionWithBracketsAndOrderBy() {
string stmt = "(SELECT a FROM tbl ORDER BY a) UNION DISTINCT (SELECT a FROM tbl ORDER BY a)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiValueNotInBinds() {
string stmt = "SELECT * FROM mytable WHERE (a, b) NOT IN ((?, ?), (?, ?))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testMultiValueIn_NTuples() {
string stmt = "SELECT * FROM mytable WHERE (a, b, c, d, e) IN ((1, 2, 3, 4, 5), (6, 7, 8, 9, 10), (11, 12, 13, 14, 15))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivot1() {
string stmt = "SELECT * FROM mytable PIVOT (count(a) FOR b IN ('val1'))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivot2() {
string stmt = "SELECT * FROM mytable PIVOT (count(a) FOR b IN (10, 20, 30))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivot3() {
string stmt = "SELECT * FROM mytable PIVOT (count(a) AS vals FOR b IN (10 AS d1, 20, 30 AS d3))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivot4() {
string stmt = "SELECT * FROM mytable PIVOT (count(a), sum(b) FOR b IN (10, 20, 30))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivot5() {
string stmt = "SELECT * FROM mytable PIVOT (count(a) FOR (b, c) IN ((10, 'a'), (20, 'b'), (30, 'c')))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

internal virtual void testPivotWithOrderBy() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "SELECT *\n"), "FROM (\n"), "       SELECT 'kale' AS product, 51 AS sales, 'Q1' AS quarter\n"), "     )\n"), "PIVOT(SUM(sales) FOR quarter IN ('Q1', 'Q2'))\n"), "ORDER BY 1\n"), ";");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testPivotXml1() {
string stmt = "SELECT * FROM mytable PIVOT XML (count(a) FOR b IN ('val1'))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivotXml2() {
string stmt = "SELECT * FROM mytable PIVOT XML (count(a) FOR b IN (SELECT vals FROM myothertable))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivotXml3() {
string stmt = "SELECT * FROM mytable PIVOT XML (count(a) FOR b IN (ANY))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivotXmlSubquery1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (SELECT times_purchased, state_code FROM customers t) PIVOT (count(state_code) FOR state_code IN ('NY', 'CT', 'NJ', 'FL', 'MO')) ORDER BY times_purchased");
}

public virtual void testPivotFunction() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT to_char((SELECT col1 FROM (SELECT times_purchased, state_code FROM customers t) PIVOT (count(state_code) FOR state_code IN ('NY', 'CT', 'NJ', 'FL', 'MO')) ORDER BY times_purchased)) FROM DUAL");
}

public virtual void testUnPivotWithAlias() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT simulation_id, un_piv_alias.signal, un_piv_alias.val AS value FROM", " (SELECT simulation_id,"), " convert(numeric(18, 2), sum(convert(int, init_on))) DosingOnStatus_TenMinutes_sim,"), " convert(numeric(18, 2), sum(CASE WHEN pump_status = 0 THEN 10 ELSE 0 END)) AS DosingOffDurationHour_Hour_sim"), " FROM ft_simulation_result"), " WHERE simulation_id = 210 AND data_timestamp BETWEEN convert(datetime, '2021-09-14', 120) AND convert(datetime, '2021-09-18', 120)"), " GROUP BY simulation_id) sim_data"), " UNPIVOT"), " ("), "val"), " FOR signal IN (DosingOnStatus_TenMinutes_sim, DosingOnDuration_Hour_sim)"), ") un_piv_alias"), true);
}

public virtual void testUnPivot() {
string stmt = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM sale_stats", " UNPIVOT ("), "quantity"), " FOR product_code IN (product_a AS 'A', product_b AS 'B', product_c AS 'C'))");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testUnPivotWithMultiColumn() {
string stmt = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM sale_stats", " UNPIVOT ("), "(quantity, rank)"), " FOR product_code IN ((product_a, product_1) AS 'A', (product_b, product_2) AS 'B', (product_c, product_3) AS 'C'))");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPivotWithAlias() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (SELECT * FROM mytable LEFT JOIN mytable2 ON Factor_ID = Id) f PIVOT (max(f.value) FOR f.factoryCode IN (ZD, COD, SW, PH))");
}

public virtual void testPivotWithAlias2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (SELECT * FROM mytable LEFT JOIN mytable2 ON Factor_ID = Id) f PIVOT (max(f.value) FOR f.factoryCode IN (ZD, COD, SW, PH)) d");
}

public virtual void testPivotWithAlias3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (SELECT * FROM mytable LEFT JOIN mytable2 ON Factor_ID = Id) PIVOT (max(f.value) FOR f.factoryCode IN (ZD, COD, SW, PH)) d");
}

public virtual void testPivotWithAlias4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM (", "SELECT a.Station_ID stationId, b.Factor_Code factoryCode, a.Value value"), " FROM T_Data_Real a"), " LEFT JOIN T_Bas_Factor b ON a.Factor_ID = b.Id"), ") f "), "PIVOT (max(f.value) FOR f.factoryCode IN (ZD, COD, SW, PH)) d"));
}

public virtual void testRegexpLike1() {
string stmt = "SELECT * FROM mytable WHERE REGEXP_LIKE(first_name, '^Ste(v|ph)en$')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testRegexpLike2() {
string stmt = "SELECT CASE WHEN REGEXP_LIKE(first_name, '^Ste(v|ph)en$') THEN 1 ELSE 2 END FROM mytable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testRegexpMySQL() {
string stmt = "SELECT * FROM mytable WHERE first_name REGEXP '^Ste(v|ph)en$'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testNotRegexpMySQLIssue887() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE first_name NOT REGEXP '^Ste(v|ph)en$'");
}

public virtual void testNotRegexpMySQLIssue887_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE NOT first_name REGEXP '^Ste(v|ph)en$'");
}

public virtual void testRegexpBinaryMySQL() {
string stmt = "SELECT * FROM mytable WHERE first_name REGEXP BINARY '^Ste(v|ph)en$'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testXorCondition() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE field = value XOR other_value");
}

public virtual void testRlike() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE first_name RLIKE '^Ste(v|ph)en$'");
}

public virtual void testRegexpLike() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE first_name REGEXP_LIKE '^Ste(v|ph)en$'");
}

public virtual void testBooleanFunction1() {
string stmt = "SELECT * FROM mytable WHERE test_func(col1)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testNamedParameter() {
string stmt = "SELECT * FROM mytable WHERE b = :param";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
global::DripSharp.SqlTrellis.Statement.Statement st = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(st!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Expression.Expression exp = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(plainSelect.getWhere()!)).getRightExpression();
global::DripSharp.Testing.JavaAssertions.True((exp is global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter), null);
global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter namedParameter = (global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(exp!);
global::DripSharp.Testing.JavaAssertions.Equal("param", namedParameter.getName(), null);
}

public virtual void testNamedParameter2() {
string stmt = "SELECT * FROM mytable WHERE a = :param OR a = :param2 AND b = :param3";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
global::DripSharp.SqlTrellis.Statement.Statement st = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(st!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Expression.Expression exp_l = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(plainSelect.getWhere()!)).getLeftExpression();
global::DripSharp.SqlTrellis.Expression.Expression exp_r = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(plainSelect.getWhere()!)).getRightExpression();
global::DripSharp.SqlTrellis.Expression.Expression exp_rl = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(exp_r!)).getLeftExpression();
global::DripSharp.SqlTrellis.Expression.Expression exp_rr = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(exp_r!)).getRightExpression();
global::DripSharp.SqlTrellis.Expression.Expression exp_param1 = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(exp_l!)).getRightExpression();
global::DripSharp.SqlTrellis.Expression.Expression exp_param2 = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(exp_rl!)).getRightExpression();
global::DripSharp.SqlTrellis.Expression.Expression exp_param3 = ((global::DripSharp.SqlTrellis.Expression.BinaryExpression)(exp_rr!)).getRightExpression();
global::DripSharp.Testing.JavaAssertions.True((exp_param1 is global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter), null);
global::DripSharp.Testing.JavaAssertions.True((exp_param2 is global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter), null);
global::DripSharp.Testing.JavaAssertions.True((exp_param3 is global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter), null);
global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter namedParameter1 = (global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(exp_param1!);
global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter namedParameter2 = (global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(exp_param2!);
global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter namedParameter3 = (global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)(exp_param3!);
global::DripSharp.Testing.JavaAssertions.Equal("param", namedParameter1.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("param2", namedParameter2.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("param3", namedParameter3.getName(), null);
}

public virtual void testNamedParameter3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t WHERE c = :from");
}

public virtual void testComplexUnion1() {
string stmt = "(SELECT 'abc-' || coalesce(mytab.a::varchar, '') AS a, mytab.b, mytab.c AS st, mytab.d, mytab.e FROM mytab WHERE mytab.del = 0) UNION (SELECT 'cde-' || coalesce(mytab2.a::varchar, '') AS a, mytab2.b, mytab2.bezeichnung AS c, 0 AS d, 0 AS e FROM mytab2 WHERE mytab2.del = 0)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleHierarchicalQuery() {
string stmt = "SELECT last_name, employee_id, manager_id FROM employees CONNECT BY employee_id = manager_id ORDER BY last_name";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleHierarchicalQuery2() {
string stmt = "SELECT employee_id, last_name, manager_id FROM employees CONNECT BY PRIOR employee_id = manager_id";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleHierarchicalQuery3() {
string stmt = "SELECT last_name, employee_id, manager_id, LEVEL FROM employees START WITH employee_id = 100 CONNECT BY PRIOR employee_id = manager_id ORDER SIBLINGS BY last_name";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleHierarchicalQuery4() {
string stmt = "SELECT last_name, employee_id, manager_id, LEVEL FROM employees CONNECT BY PRIOR employee_id = manager_id START WITH employee_id = 100 ORDER SIBLINGS BY last_name";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testOracleHierarchicalQueryIssue196() {
string stmt = "SELECT num1, num2, level FROM carol_tmp START WITH num2 = 1008 CONNECT BY num2 = PRIOR num1 ORDER BY level DESC";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPostgreSQLRegExpCaseSensitiveMatch() {
string stmt = "SELECT a, b FROM foo WHERE a ~ '[help].*'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPostgreSQLRegExpCaseSensitiveMatch2() {
string stmt = "SELECT a, b FROM foo WHERE a ~* '[help].*'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPostgreSQLRegExpCaseSensitiveMatch3() {
string stmt = "SELECT a, b FROM foo WHERE a !~ '[help].*'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testPostgreSQLRegExpCaseSensitiveMatch4() {
string stmt = "SELECT a, b FROM foo WHERE a !~* '[help].*'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testReservedKeyword() {
string statement = "SELECT cast, do, extract, first, following, last, materialized, nulls, partition, range, row, rows, siblings, value, xml FROM tableName";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testReservedKeyword2() {
string stmt = "SELECT open FROM tableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testReservedKeyword3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable1 t JOIN mytable2 AS \"prior\" ON t.id = \"prior\".id");
}

public virtual void testCharacterSetClause() {
string stmt = "SELECT DISTINCT CAST(`view0`.`nick2` AS CHAR (8000) CHARACTER SET utf8) AS `v0` FROM people `view0` WHERE `view0`.`nick2` IS NOT NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testNotEqualsTo() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo WHERE a != b");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo WHERE a <> b");
}

public virtual void testGeometryDistance() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo ORDER BY a <-> b");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo ORDER BY a <#> b");
}

public virtual void testJsonExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT data->'images'->'thumbnail'->'url' AS thumb FROM instagram");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM sales WHERE sale->'items'->>'description' = 'milk'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM sales WHERE sale->'items'->>'quantity' = 12::TEXT");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT SUM(CAST(sale->'items'->>'quantity' AS integer)) AS total_quantity_sold FROM sales");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT sale->>'items' FROM sales");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT json_typeof(sale->'items'), json_typeof(sale->'items'->'quantity') FROM sales");
foreach (string statement in new string[] { "SELECT doc->'site_name' FROM websites WHERE doc @> '{\"tags\":[{\"term\":\"paris\"}, {\"term\":\"food\"}]}'", "SELECT * FROM sales where sale ->'items' @> '[{\"count\":0}]'", "SELECT * FROM sales where sale ->'items' ? 'name'", "SELECT * FROM sales where sale ->'items' -# 'name'" }) {
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement, true);
}
}

public virtual void testJsonExpressionWithCastExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT id FROM tbl WHERE p.company::json->'info'->>'country' = 'test'");
}

public virtual void testJsonExpressionWithIntegerParameterIssue909() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select uc.\"id\", u.nickname, u.avatar, b.title, uc.images, uc.created_at as createdAt from library.ugc_comment uc INNER JOIN library.book b on (uc.books_id ->> 0)::INTEGER = b.\"id\" INNER JOIN library.users u ON uc.user_id = u.user_id where uc.id = 1", true);
}

public virtual void testSqlNoCache() {
string stmt = "SELECT SQL_NO_CACHE sales.date FROM sales";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testSqlCache() {
string stmt = "SELECT SQL_CACHE sales.date FROM sales";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testSelectInto1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * INTO user_copy FROM user");
}

public virtual void testSelectForUpdate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM user_table FOR UPDATE");
}

public virtual void testSelectForUpdate2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM emp WHERE empno = ? FOR UPDATE");
}

public virtual void testSelectJoin() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT pg_class.relname, pg_attribute.attname, pg_constraint.conname ", "FROM pg_constraint JOIN pg_class ON pg_class.oid = pg_constraint.conrelid"), " JOIN pg_attribute ON pg_attribute.attrelid = pg_constraint.conrelid"), " WHERE pg_constraint.contype = 'u' AND (pg_attribute.attnum = ANY(pg_constraint.conkey))"), " ORDER BY pg_constraint.conname"));
}

public virtual void testSelectJoin2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM pg_constraint WHERE pg_attribute.attnum = ANY(pg_constraint.conkey)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM pg_constraint WHERE pg_attribute.attnum = ALL(pg_constraint.conkey)");
}

public virtual void testAnyConditionSubSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT e1.empno, e1.sal FROM emp e1 WHERE e1.sal > ANY (SELECT e2.sal FROM emp e2 WHERE e2.deptno = 10)", true);
}

public virtual void testAllConditionSubSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT e1.empno, e1.sal FROM emp e1 WHERE e1.sal > ALL (SELECT e2.sal FROM emp e2 WHERE e2.deptno = 10)", true);
}

public virtual void testSelectOracleColl() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM the_table tt WHERE TT.COL1 = lines(idx).COL1");
}

public virtual void testSelectWithMaterializedWith() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("WITH tokens_with_supply AS MATERIALIZED (SELECT * FROM tokens) SELECT * FROM tokens_with_supply");
}

public virtual void testSelectInnerWith() {
string stmt = "SELECT * FROM (WITH actor AS (SELECT 'a' aid FROM DUAL) SELECT aid FROM actor)";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems1 = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Null(withItems1, null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(select.getPlainSelect().getFromItem()!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems2 = parenthesedSelect.getPlainSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT 'a' aid FROM DUAL)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" actor", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getAlias().ToString(), null);
}

public virtual void testSelectInnerWithAndUnionIssue1084_2() {
string stmt = "WITH actor AS (SELECT 'b' aid FROM DUAL) SELECT aid FROM actor UNION SELECT aid FROM actor2";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT 'b' aid FROM DUAL)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" actor", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testSelectWithinGroup() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT LISTAGG(col1, '##') WITHIN GROUP (ORDER BY col1) FROM table1");
}

public virtual void testSelectUserVariable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @col FROM t1");
}

public virtual void testSelectNumericBind() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a FROM b WHERE c = :1");
}

public virtual void testSelectBrackets() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT avg((123.250)::numeric)");
}

public virtual void testSelectBrackets2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (EXTRACT(epoch FROM age(d1, d2)) / 2)::numeric");
}

public virtual void testSelectBrackets3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT avg((EXTRACT(epoch FROM age(d1, d2)) / 2)::numeric)");
}

public virtual void testSelectBrackets4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (1 / 2)::numeric");
}

public virtual void testSelectForUpdateOfTable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT foo.*, bar.* FROM foo, bar WHERE foo.id = bar.foo_id FOR UPDATE OF foo");
}

public virtual void testSelectWithBrackets() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("(SELECT 1 FROM mytable)");
}

public virtual void testSelectWithBrackets2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("(SELECT 1)");
}

public virtual void testSelectWithoutFrom() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT footable.foocolumn");
}

public virtual void testSelectKeywordPercent() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT percent FROM MY_TABLE");
}

public virtual void testSelectJPQLPositionalParameter() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT email FROM users WHERE (type LIKE 'B') AND (username LIKE ?1)");
}

public virtual void testSelectKeep() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT col1, min(col2) KEEP (DENSE_RANK FIRST ORDER BY col3), col4 FROM table1 GROUP BY col5 ORDER BY col3");
}

public virtual void testSelectKeepOver() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT MIN(salary) KEEP (DENSE_RANK FIRST ORDER BY commission_pct) OVER (PARTITION BY department_id ) \"Worst\" FROM employees ORDER BY department_id, salary");
}

public virtual void testGroupConcat() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT student_name, GROUP_CONCAT(DISTINCT test_score ORDER BY test_score DESC SEPARATOR ' ') FROM student GROUP BY student_name");
}

public virtual void testRowConstructor1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t1 WHERE (col1, col2) = (SELECT col3, col4 FROM t2 WHERE id = 10)");
}

public virtual void testRowConstructor2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t1 WHERE ROW(col1, col2) = (SELECT col3, col4 FROM t2 WHERE id = 10)");
}

public virtual void testIssue154() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT d.id, d.uuid, d.name, d.amount, d.percentage, d.modified_time FROM discount d LEFT OUTER JOIN discount_category dc ON d.id = dc.discount_id WHERE merchant_id = ? AND deleted = ? AND dc.discount_id IS NULL AND modified_time < ? AND modified_time >= ? ORDER BY modified_time");
}

public virtual void testIssue154_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT r.id, r.uuid, r.name, r.system_role FROM role r WHERE r.merchant_id = ? AND r.deleted_time IS NULL ORDER BY r.id DESC");
}

public virtual void testIssue160_signedParameter() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT start_date WHERE start_date > DATEADD(HH, -?, GETDATE())");
}

public virtual void testIssue160_signedParameter2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE -? = 5");
}

public virtual void testIssue162_doubleUserVar() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @@SPID AS ID, SYSTEM_USER AS \"Login Name\", USER AS \"User Name\"");
}

public virtual void testIssue167_singleQuoteEscape(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testIssue167_singleQuoteEscape2(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testIssue77_singleQuoteEscape2() {
string sqlStr = "SELECT 'test\\'' FROM dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testIssue223_singleQuoteEscape() {
string sqlStr = "SELECT '\\'test\\''";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testOracleHint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("SELECT /*+ SOMEHINT */ * FROM mytable", true, "SOMEHINT");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("SELECT /*+ MORE HINTS POSSIBLE */ * FROM mytable", true, "MORE HINTS POSSIBLE");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("SELECT /*+   MORE\nHINTS\t\nPOSSIBLE  */ * FROM mytable", true, "MORE\nHINTS\t\nPOSSIBLE");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("SELECT /*+ leading(sn di md sh ot) cardinality(ot 1000) */ c, b FROM mytable", true, "leading(sn di md sh ot) cardinality(ot 1000)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT /*+ ORDERED INDEX (b, jl_br_balances_n1) USE_NL (j b) \n", "           USE_NL (glcc glf) USE_MERGE (gp gsb) */\n"), " b.application_id\n"), "FROM  jl_br_journals j,\n"), "      po_vendors p"), true, global::DripSharp.Runtime.JavaCompat.Concat("ORDERED INDEX (b, jl_br_balances_n1) USE_NL (j b) \n", "           USE_NL (glcc glf) USE_MERGE (gp gsb)"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT /*+ROWID(emp)*/ /*+ THIS IS NOT HINT! ***/ * \n", "FROM emp \n"), "WHERE rowid > 'AAAAtkAABAAAFNTAAA' AND empno = 155"), false, "ROWID(emp)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT /*+ INDEX(patients sex_index) use sex_index because there are few\n", "   male patients  */ name, height, weight\n"), "FROM patients\n"), "WHERE sex = 'm'"), true, "INDEX(patients sex_index) use sex_index because there are few\n   male patients");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT /*+INDEX_COMBINE(emp sal_bmi hiredate_bmi)*/ * \n", "FROM emp  \n"), "WHERE sal < 50000 AND hiredate < '01-JAN-1990'"), true, "INDEX_COMBINE(emp sal_bmi hiredate_bmi)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT --+ CLUSTER \n", "emp.ename, deptno\n"), "FROM emp, dept\n"), "WHERE deptno = 10 \n"), "AND emp.deptno = dept.deptno"), true, "CLUSTER");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("SELECT --+ CLUSTER \n --+ some other comment, not hint\n /* even more comments */ * from dual", false, "CLUSTER");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("(SELECT * from t1) UNION (select /*+ CLUSTER */ * from dual)", true, (string)default!, "CLUSTER");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("(SELECT * from t1) UNION (select /*+ CLUSTER */ * from dual) UNION (select * from dual)", true, (string)default!, "CLUSTER", (string)default!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists("(SELECT --+ HINT1 HINT2 HINT3\n * from t1) UNION (select /*+ HINT4 HINT5 */ * from dual)", true, "HINT1 HINT2 HINT3", "HINT4 HINT5");
}

public virtual void testOracleHintExpression() {
string statement = "SELECT --+ HINT\n * FROM tab1";
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(statement));
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.StringValueOf(parsed), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(parsed!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(plainSelect.getOracleHint(), "--+ HINT\n");
}

public virtual void testTableFunctionWithNoParams() {
string statement = "SELECT f2 FROM SOME_FUNCTION()";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getFromItem() is global::DripSharp.SqlTrellis.Statement.Select.TableFunction), null);
global::DripSharp.SqlTrellis.Statement.Select.TableFunction fromItem = (global::DripSharp.SqlTrellis.Statement.Select.TableFunction)(plainSelect.getFromItem()!);
global::DripSharp.SqlTrellis.Expression.Function function = fromItem.getFunction();
global::DripSharp.Testing.JavaAssertions.NotNull(function, null);
global::DripSharp.Testing.JavaAssertions.Equal("SOME_FUNCTION", function.getName(), null);
global::DripSharp.Testing.JavaAssertions.Null(function.getParameters(), null);
global::DripSharp.Testing.JavaAssertions.Null(fromItem.getAlias(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testTableFunctionWithParams() {
string statement = "SELECT f2 FROM SOME_FUNCTION(1, 'val')";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getFromItem() is global::DripSharp.SqlTrellis.Statement.Select.TableFunction), null);
global::DripSharp.SqlTrellis.Statement.Select.TableFunction fromItem = (global::DripSharp.SqlTrellis.Statement.Select.TableFunction)(plainSelect.getFromItem()!);
global::DripSharp.SqlTrellis.Expression.Function function = fromItem.getExpression();
global::DripSharp.Testing.JavaAssertions.NotNull(function, null);
global::DripSharp.Testing.JavaAssertions.Equal("SOME_FUNCTION", function.getName(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(function.getParameters(), null);
var expressions = global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(function.getParameters());
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(expressions), null);
global::DripSharp.SqlTrellis.Expression.Expression firstParam = global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 0);
global::DripSharp.Testing.JavaAssertions.NotNull(firstParam, null);
global::DripSharp.Testing.JavaAssertions.True((firstParam is global::DripSharp.SqlTrellis.Expression.LongValue), null);
global::DripSharp.Testing.JavaAssertions.Equal(1L, ((global::DripSharp.SqlTrellis.Expression.LongValue)(firstParam!)).getValue(), null);
global::DripSharp.SqlTrellis.Expression.Expression secondParam = global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 1);
global::DripSharp.Testing.JavaAssertions.NotNull(secondParam, null);
global::DripSharp.Testing.JavaAssertions.True((secondParam is global::DripSharp.SqlTrellis.Expression.StringValue), null);
global::DripSharp.Testing.JavaAssertions.Equal("val", ((global::DripSharp.SqlTrellis.Expression.StringValue)(secondParam!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Null(fromItem.getAlias(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testTableFunctionWithAlias() {
string statement = "SELECT f2 FROM SOME_FUNCTION() AS z";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.True((plainSelect.getFromItem() is global::DripSharp.SqlTrellis.Statement.Select.TableFunction), null);
global::DripSharp.SqlTrellis.Statement.Select.TableFunction fromItem = (global::DripSharp.SqlTrellis.Statement.Select.TableFunction)(plainSelect.getFromItem()!);
global::DripSharp.SqlTrellis.Expression.Function function = fromItem.getExpression();
global::DripSharp.Testing.JavaAssertions.NotNull(function, null);
global::DripSharp.Testing.JavaAssertions.Equal("SOME_FUNCTION", function.getName(), null);
global::DripSharp.Testing.JavaAssertions.Null(function.getParameters(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(fromItem.getAlias(), null);
global::DripSharp.Testing.JavaAssertions.Equal("z", fromItem.getAlias().getName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statement);
}

public virtual void testIssue151_tableFunction() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tables a LEFT JOIN getdata() b ON a.id = b.id");
}

public virtual void testIssue217_keywordSeparator() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT Separator");
}

public virtual void testIssue215_possibleEndlessParsing() {
string sqlStr = "SELECT (CASE WHEN ((value LIKE '%t1%') OR (value LIKE '%t2%')) THEN 't1s' WHEN ((((((((((((((((((((((((((((value LIKE '%t3%') OR (value LIKE '%t3%')) OR (value LIKE '%t3%')) OR (value LIKE '%t4%')) OR (value LIKE '%t4%')) OR (value LIKE '%t5%')) OR (value LIKE '%t6%')) OR (value LIKE '%t6%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t8%')) OR (value LIKE '%t8%')) OR (value LIKE '%CTO%')) OR (value LIKE '%cto%')) OR (value LIKE '%Cto%')) OR (value LIKE '%t9%')) OR (value LIKE '%t9%')) OR (value LIKE '%COO%')) OR (value LIKE '%coo%')) OR (value LIKE '%Coo%')) OR (value LIKE '%t10%')) OR (value LIKE '%t10%')) OR (value LIKE '%CIO%')) OR (value LIKE '%cio%')) OR (value LIKE '%Cio%')) OR (value LIKE '%t11%')) OR (value LIKE '%t11%')) THEN 't' WHEN ((((value LIKE '%t12%') OR (value LIKE '%t12%')) OR (value LIKE '%VP%')) OR (value LIKE '%vp%')) THEN 'Vice t12s' WHEN ((((((value LIKE '% IT %') OR (value LIKE '%t13%')) OR (value LIKE '%t13%')) OR (value LIKE '% it %')) OR (value LIKE '%tech%')) OR (value LIKE '%Tech%')) THEN 'IT' WHEN ((((value LIKE '%Analyst%') OR (value LIKE '%t14%')) OR (value LIKE '%Analytic%')) OR (value LIKE '%analytic%')) THEN 'Analysts' WHEN ((value LIKE '%Manager%') OR (value LIKE '%manager%')) THEN 't15' ELSE 'Other' END) FROM tab1";
global::DripSharp.SqlTrellis.Statement.Statement stmt2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withAllowComplexParsing(false).withTimeOut((long)(20000)));
}

public virtual void testIssue215_possibleEndlessParsing2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (CASE WHEN ((value LIKE '%t1%') OR (value LIKE '%t2%')) THEN 't1s' ELSE 'Other' END) FROM tab1");
}

public virtual void testIssue215_possibleEndlessParsing3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE ((((((((((((((((((((((((((((value LIKE '%t3%') OR (value LIKE '%t3%')) OR (value LIKE '%t3%')) OR (value LIKE '%t4%')) OR (value LIKE '%t4%')) OR (value LIKE '%t5%')) OR (value LIKE '%t6%')) OR (value LIKE '%t6%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t8%')) OR (value LIKE '%t8%')) OR (value LIKE '%CTO%')) OR (value LIKE '%cto%')) OR (value LIKE '%Cto%')) OR (value LIKE '%t9%')) OR (value LIKE '%t9%')) OR (value LIKE '%COO%')) OR (value LIKE '%coo%')) OR (value LIKE '%Coo%')) OR (value LIKE '%t10%')) OR (value LIKE '%t10%')) OR (value LIKE '%CIO%')) OR (value LIKE '%cio%')) OR (value LIKE '%Cio%')) OR (value LIKE '%t11%')) OR (value LIKE '%t11%'))");
}

public virtual void testIssue215_possibleEndlessParsing4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE ((value LIKE '%t3%') OR (value LIKE '%t3%'))");
}

public virtual void testIssue215_possibleEndlessParsing5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE ((((((value LIKE '%t3%') OR (value LIKE '%t3%')) OR (value LIKE '%t3%')) OR (value LIKE '%t4%')) OR (value LIKE '%t4%')) OR (value LIKE '%t5%'))");
}

public virtual void testIssue215_possibleEndlessParsing6() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE (((((((((((((value LIKE '%t3%') OR (value LIKE '%t3%')) OR (value LIKE '%t3%')) OR (value LIKE '%t4%')) OR (value LIKE '%t4%')) OR (value LIKE '%t5%')) OR (value LIKE '%t6%')) OR (value LIKE '%t6%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t8%')) OR (value LIKE '%t8%'))");
}

public virtual void testIssue215_possibleEndlessParsing7() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE (((((((((((((((((((((value LIKE '%t3%') OR (value LIKE '%t3%')) OR (value LIKE '%t3%')) OR (value LIKE '%t4%')) OR (value LIKE '%t4%')) OR (value LIKE '%t5%')) OR (value LIKE '%t6%')) OR (value LIKE '%t6%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t7%')) OR (value LIKE '%t8%')) OR (value LIKE '%t8%')) OR (value LIKE '%CTO%')) OR (value LIKE '%cto%')) OR (value LIKE '%Cto%')) OR (value LIKE '%t9%')) OR (value LIKE '%t9%')) OR (value LIKE '%COO%')) OR (value LIKE '%coo%')) OR (value LIKE '%Coo%'))");
}

public virtual void testIssue230_cascadeKeyword() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT t.cascade AS cas FROM t");
}

public virtual void testBooleanValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT col FROM t WHERE a");
}

public virtual void testBooleanValue2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT col FROM t WHERE 3 < 5 AND a");
}

public virtual void testNotWithoutParenthesisIssue234() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(*) FROM \"Persons\" WHERE NOT \"F_NAME\" = 'John'");
}

public virtual void testWhereIssue240_1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(*) FROM mytable WHERE 1");
}

public virtual void testWhereIssue240_0() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(*) FROM mytable WHERE 0");
}

public virtual void testCaseKeyword() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM Case");
}

public virtual void testCastToSignedInteger() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS SIGNED INTEGER) FROM contact WHERE contact_id = 20");
}

public virtual void testCastToSigned() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS SIGNED) FROM contact WHERE contact_id = 20");
}

public virtual void testWhereIssue240_notBoolean() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT count(*) FROM mytable WHERE 5");
}, null);
}

public virtual void testWhereIssue240_true() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(*) FROM mytable WHERE true");
}

public virtual void testWhereIssue240_false() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(*) FROM mytable WHERE false");
}

public virtual void testWhereIssue241KeywordEnd() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT l.end FROM lessons l");
}

public virtual void testSpeedTestIssue235() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tbl WHERE (ROUND((((((period_diff(date_format(tbl.CD, '%Y%m'), date_format(SUBTIME(CURRENT_TIMESTAMP(), 25200), '%Y%m')) + month(SUBTIME(CURRENT_TIMESTAMP(), 25200))) - MONTH('2012-02-01')) - 1) / 3) - ROUND((((month(SUBTIME(CURRENT_TIMESTAMP(),25200)) - MONTH('2012-02-01')) - 1) / 3)))) = -3)", true);
}

public virtual void testSpeedTestIssue235_2() {
string stmt = global::DripSharp.SqlTrellis.Tests.Support.ReadText(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SelectTest), "large-sql-issue-235.txt"), global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true);
}

public virtual void testCastVarCharMaxIssue245() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST('foo' AS NVARCHAR (MAX))");
}

public virtual void testNestedFunctionCallIssue253() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (replace_regex(replace_regex(replace_regex(get_json_string(a_column, 'value'), '\\n', ' '), '\\r', ' '), '\\\\', '\\\\\\\\')) FROM a_table WHERE b_column = 'value'");
}

public virtual void testEscapedBackslashIssue253() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT replace_regex('test', '\\\\', '\\\\\\\\')");
}

public virtual void testKeywordTableIssue261() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column_value FROM table(VARCHAR_LIST_TYPE())");
}

public virtual void testTopExpressionIssue243() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT TOP (? + 1) * FROM MyTable");
}

public virtual void testTopExpressionIssue243_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT TOP (CAST(? AS INT)) * FROM MyTable");
}

public virtual void testFunctionIssue284() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT NVL((SELECT 1 FROM DUAL), 1) AS A FROM TEST1");
}

public virtual void testFunctionDateTimeValues() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tab1 WHERE a > TIMESTAMP '2004-04-30 04:05:34.56'");
}

public virtual void testPR73() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT date_part('day', TIMESTAMP '2001-02-16 20:38:40')");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT EXTRACT(year FROM DATE '2001-02-16')");
}

public virtual void testUniqueInsteadOfDistinctIssue299() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT UNIQUE trunc(timez(ludate)+ 8/24) bus_dt, j.object j_name , timez(j.starttime) START_TIME , timez(j.endtime) END_TIME FROM TEST_1 j", true);
}

public virtual void testProblemSqlIssue265() {
string sqls = global::DripSharp.SqlTrellis.Tests.Support.ReadText(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SelectTest), "large-sql-with-issue-265.txt"), global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
global::DripSharp.SqlTrellis.Statement.Statements stmts = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqls);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(stmts.getStatements()), null);
}

public virtual void testProblemSqlIssue330() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COUNT(*) FROM C_Invoice WHERE IsSOTrx='Y' AND (Processed='N' OR Updated>(current_timestamp - CAST('90 days' AS interval))) AND C_Invoice.AD_Client_ID IN(0,1010016) AND C_Invoice.AD_Org_ID IN(0,1010053,1010095,1010094)", true);
}

public virtual void testProblemSqlIssue330_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST('90 days' AS interval)");
}

public virtual void testProblemKeywordCommitIssue341() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT id, commit FROM table1");
}

public virtual void testProblemSqlIssue352() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @rowNO from (SELECT @rowNO from dual) r", true);
}

public virtual void testProblemIsIssue331() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT C_DocType.C_DocType_ID,NULL,COALESCE(C_DocType_Trl.Name,C_DocType.Name) AS Name,C_DocType.IsActive FROM C_DocType LEFT JOIN C_DocType_TRL ON (C_DocType.C_DocType_ID=C_DocType_Trl.C_DocType_ID AND C_DocType_Trl.AD_Language='es_AR') WHERE C_DocType.AD_Client_ID=1010016 AND C_DocType.AD_Client_ID IN (0,1010016) AND C_DocType.c_doctype_id in ( select c_doctype2.c_doctype_id from c_doctype as c_doctype2 where substring( c_doctype2.printname,6, length(c_doctype2.printname) ) = ( select letra from c_letra_comprobante as clc where clc.c_letra_comprobante_id = 1010039) ) AND ( (1010094!=0 AND C_DocType.ad_org_id = 1010094) OR 1010094=0 ) ORDER BY 3 LIMIT 2000", true);
}

public virtual void testProblemIssue375() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select n.nspname, c.relname, a.attname, a.atttypid, t.typname, a.attnum, a.attlen, a.atttypmod, a.attnotnull, c.relhasrules, c.relkind, c.oid, pg_get_expr(d.adbin, d.adrelid), case t.typtype when 'd' then t.typbasetype else 0 end, t.typtypmod, c.relhasoids from (((pg_catalog.pg_class c inner join pg_catalog.pg_namespace n on n.oid = c.relnamespace and c.relname = 'business' and n.nspname = 'public') inner join pg_catalog.pg_attribute a on (not a.attisdropped) and a.attnum > 0 and a.attrelid = c.oid) inner join pg_catalog.pg_type t on t.oid = a.atttypid) left outer join pg_attrdef d on a.atthasdef and d.adrelid = a.attrelid and d.adnum = a.attnum order by n.nspname, c.relname, attnum", true);
}

public virtual void testProblemIssue375Simplified() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select * ", "from (((pg_catalog.pg_class c "), "   inner join pg_catalog.pg_namespace n "), "       on n.oid = c.relnamespace "), "           and c.relname = 'business' and n.nspname = 'public') "), "   inner join pg_catalog.pg_attribute a "), "       on (not a.attisdropped) "), "           and a.attnum > 0 and a.attrelid = c.oid) "), "   inner join pg_catalog.pg_type t "), "       on t.oid = a.atttypid) "), "   left outer join pg_attrdef d "), "       on a.atthasdef and d.adrelid = a.attrelid "), "           and d.adnum = a.attnum "), "order by n.nspname, c.relname, attnum"), true);
}

public virtual void testProblemIssue375Simplified2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from (pg_catalog.pg_class c inner join pg_catalog.pg_namespace n on n.oid = c.relnamespace and c.relname = 'business' and n.nspname = 'public') inner join pg_catalog.pg_attribute a on (not a.attisdropped) and a.attnum > 0 and a.attrelid = c.oid", true);
}

public virtual void testProblemInNotInProblemIssue379() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT rank FROM DBObjects WHERE rank NOT IN (0, 1)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT rank FROM DBObjects WHERE rank IN (0, 1)");
}

public virtual void testProblemLargeNumbersIssue390() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM student WHERE student_no = 20161114000000035001");
}

public virtual void testKeyWorkInsertIssue393() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT insert(\"aaaabbb\", 4, 4, \"****\")");
}

public virtual void testKeyWorkReplaceIssue393() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT replace(\"aaaabbb\", 4, 4, \"****\")");
}

public virtual void testForUpdateWaitParseDeparse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable FOR UPDATE WAIT 60");
}

public virtual void testForUpdateWaitWithTimeout() {
string statement = "SELECT * FROM mytable FOR UPDATE WAIT 60";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect ps = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Statement.Select.Wait wait = ps.getWait();
global::DripSharp.Testing.JavaAssertions.NotNull(wait, "wait should not be null");
long waitTime = wait.getTimeout();
global::DripSharp.Testing.JavaAssertions.Equal(waitTime, 60L, "wait time should be 60");
}

public virtual void testForUpdateNoWait() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable FOR UPDATE NOWAIT");
}

public virtual void testSubSelectFailsIssue394() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select aa.* , t.* from accenter.all aa, (select a.* from pacioli.emc_plan a) t", true);
}

public virtual void testSubSelectFailsIssue394_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from all", true);
}

public virtual void testMysqlIndexHints() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM testtable AS t0 USE INDEX (index1)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM testtable AS t0 IGNORE INDEX (index1)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM testtable AS t0 FORCE INDEX (index1)");
}

public virtual void testMysqlIndexHintsWithJoins() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM table0 t0 INNER JOIN table1 t1 USE INDEX (index1)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM table0 t0 INNER JOIN table1 t1 IGNORE INDEX (index1)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM table0 t0 INNER JOIN table1 t1 FORCE INDEX (index1)");
}

public virtual void testMysqlMultipleIndexHints() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM testtable AS t0 USE INDEX (index1,index2)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM testtable AS t0 IGNORE INDEX (index1,index2)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column FROM testtable AS t0 FORCE INDEX (index1,index2)");
}

public virtual void testSqlServerHints() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM TB_Sys_Pedido WITH (NOLOCK) WHERE ID_Pedido = :ID_Pedido");
}

public virtual void testSqlServerHintsWithIndexIssue915() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 FROM tableName1 WITH (INDEX (idx1), NOLOCK)");
}

public virtual void testSqlServerHintsWithIndexIssue915_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 FROM tableName1 AS t1 WITH (INDEX (idx1)) JOIN tableName2 AS t2 WITH (INDEX (idx2)) ON t1.id = t2.id");
}

public virtual void testProblemIssue435() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT if(z, 'a', 'b') AS business_type FROM mytable1");
}

public virtual void testProblemIssue437Index() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select count(id) from p_custom_data ignore index(pri) where tenant_id=28257 and entity_id=92609 and delete_flg=0 and ( (dbc_relation_2 = 52701) and (dbc_relation_2 in ( select id from a_order where tenant_id = 28257 and 1=1 ) ) ) order by id desc, id desc", true);
}

public virtual void testProblemIssue445() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT E.ID_NUMBER, row_number() OVER (PARTITION BY E.ID_NUMBER ORDER BY E.DEFINED_UPDATED DESC) rn FROM T_EMPLOYMENT E");
}

public virtual void testProblemIssue485Date() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tab WHERE tab.date = :date");
}

public virtual void testGroupByProblemIssue482() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT SUM(orderTotalValue) AS value, MONTH(invoiceDate) AS month, YEAR(invoiceDate) AS year FROM invoice.Invoices WHERE projectID = 1 GROUP BY MONTH(invoiceDate), YEAR(invoiceDate) ORDER BY YEAR(invoiceDate) DESC, MONTH(invoiceDate) DESC");
}

public virtual void testIssue512() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM #tab1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tab#tab1");
}

public virtual void testIssue512_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM $tab1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM #$tab#tab1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM #$tab1#");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM $#tab1#");
}

public virtual void testIssue514() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT listagg(c1, ';') WITHIN GROUP (PARTITION BY 1 ORDER BY 1) col FROM dual");
}

public virtual void testIssue508LeftRightBitwiseShift() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 << 1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 >> 1");
}

public virtual void testIssue522() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE mr.required_quantity - mr.quantity_issued WHEN 0 THEN NULL ELSE CASE SIGN(mr.required_quantity) WHEN -1 * SIGN(mr.quantity_issued) THEN mr.required_quantity - mr.quantity_issued ELSE CASE SIGN(ABS(mr.required_quantity) - ABS(mr.quantity_issued)) WHEN -1 THEN NULL ELSE mr.required_quantity - mr.quantity_issued END END END quantity_open FROM mytable", true);
}

public virtual void testIssue522_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT -1 * SIGN(mr.quantity_issued) FROM mytable");
}

public virtual void testIssue522_3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE SIGN(mr.required_quantity) WHEN -1 * SIGN(mr.quantity_issued) THEN mr.required_quantity - mr.quantity_issued  ELSE 5 END quantity_open FROM mytable", true);
}

public virtual void testIssue522_4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE a + b WHEN -1 * 5 THEN 1 ELSE CASE b + c WHEN -1 * 6 THEN 2 ELSE 3 END END");
}

public virtual void testIssue554() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT T.INDEX AS INDEX133_ FROM myTable T");
}

public virtual void testIssue567KeywordPrimary() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT primary, secondary FROM info");
}

public virtual void testIssue572TaskReplacement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT task_id AS \"Task Id\" FROM testtable");
}

public virtual void testIssue566LargeView() {
string stmt = global::DripSharp.SqlTrellis.Tests.Support.ReadText(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SelectTest), "large-sql-issue-566.txt"), global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true);
}

public virtual void testIssue566PostgreSQLEscaped() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT E'test'");
}

public virtual void testEscaped() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT _utf8'testvalue'");
}

public virtual void testIssue563MultiSubJoin() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT c FROM ((SELECT a FROM t) JOIN (SELECT b FROM t2) ON a = B JOIN (SELECT c FROM t3) ON b = c)");
}

public virtual void testIssue563MultiSubJoin_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT c FROM ((SELECT a FROM t))");
}

public virtual void testIssue582NumericConstants() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT x'009fd'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT X'009fd'");
}

public virtual void testIssue583CharacterLiteralAsAlias() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN T.ISC = 1 THEN T.EXTDESC WHEN T.b = 2 THEN '2' ELSE T.C END AS 'Test' FROM T");
}

public virtual void testIssue266KeywordTop() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @top");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @TOP");
}

public virtual void testIssue584MySQLValueListExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a, b FROM T WHERE (T.a, T.b) = (c, d)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a FROM T WHERE (T.a) = (SELECT b FROM T, c, d)");
}

public virtual void testIssue588NotNull() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE col1 ISNULL");
}

public virtual void testParenthesisAroundFromItem() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (mytable)");
}

public virtual void testParenthesisAroundFromItem2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (mytable myalias)");
}

public virtual void testParenthesisAroundFromItem3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (mytable) myalias");
}

public virtual void testJoinerExpressionIssue596() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM a JOIN (b JOIN c ON b.id = c.id) ON a.id = c.id");
}

public virtual void testProblemSqlIssue603() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN MAX(CAST(a.jobNum AS INTEGER)) IS NULL THEN '1000' ELSE MAX(CAST(a.jobNum AS INTEGER)) + 1 END FROM user_employee a");
}

public virtual void testProblemSqlIssue603_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(col1 AS UNSIGNED INTEGER) FROM mytable");
}

public virtual void testProblemSqlFuncParamIssue605() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT p.id, pt.name, array_to_string( array( select pc.name from product_category pc ), ',' ) AS categories FROM product p", true);
}

public virtual void testProblemSqlFuncParamIssue605_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT func(SELECT col1 FROM mytable)");
}

public virtual void testSqlContainIsNullFunctionShouldBeParsed() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT name, age, ISNULL(home, 'earn more money') FROM person");
}

public virtual void testNestedCast() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT acolumn::bit (64)::bigint FROM mytable");
}

public virtual void testAndOperator() {
string stmt = "SELECT name from customers where name = 'John' && lastname = 'Doh'";
global::DripSharp.SqlTrellis.Statement.Statement parsed = this.parserManager.parse(new global::System.IO.StringReader(stmt));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, "SELECT name FROM customers WHERE name = 'John' && lastname = 'Doh'");
}

public virtual void testNamedParametersIssue612() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a FROM b LIMIT 10 OFFSET :param");
}

public virtual void testMissingOffsetIssue620() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a, b FROM test OFFSET 0");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a, b FROM test LIMIT 1 OFFSET 0");
}

public virtual void testMultiPartNames1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a.b");
}

public virtual void testMultiPartNames2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a.b.*");
}

public virtual void testMultiPartNames3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a.*");
}

public virtual void testMultiPartNames4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a.b.c.d.e.f.g.h");
}

public virtual void testMultiPartNames5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM a.b.c.d.e.f.g.h");
}

public virtual void testMultiPartNamesIssue163() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT mymodel.name FROM com.myproject.MyModelClass AS mymodel");
}

public virtual void testMultiPartNamesIssue608() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @@sessions.tx_read_only");
}

public virtual void testMultiPartNamesForFunctionsIssue944() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT pg_catalog.now()");
}

public virtual void testSelContraction() {
string statementSrc = "SEL name, age FROM person";
string statementTgt = "SELECT name, age FROM person";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(statementSrc))!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, statementTgt);
}

public virtual void testMultiPartNamesIssue643() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT id, bid, pid, devnum, pointdesc, sysid, zone, sort FROM fault ORDER BY id DESC LIMIT ?, ?");
}

public virtual void testNotNotIssue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT VALUE1, VALUE2 FROM FOO WHERE NOT BAR LIKE '*%'");
}

public virtual void testCharNotParsedIssue718() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a FROM x WHERE a LIKE '%' + char(9) + '%'");
}

public virtual void testTrueFalseLiteral() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tbl WHERE true OR clm1 = 3");
}

public virtual void testTopKeyWord() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT top.date AS mycol1 FROM mytable top WHERE top.myid = :myid AND top.myid2 = 123");
}

public virtual void testTopKeyWord2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT top.date");
}

public virtual void testTopKeyWord3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable top");
}

public virtual void testNotProblem1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytab WHERE NOT v IN (1, 2, 3, 4, 5, 6, 7)");
}

public virtual void testNotProblem2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytab WHERE NOT func(5)");
}

public virtual void testCaseThenCondition() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE CASE WHEN a = 'c' THEN a IN (1, 2, 3) END = 1");
}

public virtual void testCaseThenCondition2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE CASE WHEN a = 'c' THEN a IN (1, 2, 3) END");
}

public virtual void testCaseThenCondition3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN a > 0 THEN b + a ELSE 0 END p FROM mytable");
}

public virtual void testCaseThenCondition4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM col WHERE CASE WHEN a = 'c' THEN a IN (SELECT id FROM mytable) END");
}

public virtual void testCaseThenCondition5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM col WHERE CASE WHEN a = 'c' THEN a IN (SELECT id FROM mytable) ELSE b IN (SELECT id FROM mytable) END");
}

public virtual void testOptimizeForIssue348() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM EMP ORDER BY SALARY DESC OPTIMIZE FOR 20 ROWS");
}

public virtual void testFuncConditionParameter() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT if(a < b)");
}

public virtual void testFuncConditionParameter2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT if(a < b, c)");
}

public virtual void testFuncConditionParameter3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT  cast( ( Max(  cast( Iif( Isnumeric( license_no ) = 1, license_no, 0 ) AS INT ) ) + 2 ) AS VARCHAR )\n", "FROM lcps.t_license\n"), "WHERE profession_id = 60\n"), "    AND license_type = 100\n"), "    AND Year( issue_date ) % 2 = CASE\n"), "                WHEN Year( issue_date ) % 2 = 0\n"), "                    THEN 0\n"), "                ELSE 1\n"), "            END\n"), "    AND Isnumeric( license_no ) = 1"), true);
}

public virtual void testFuncConditionParameter4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT IIF(isnumeric(license_no) = 1, license_no, 0) FROM mytable", true);
}

public virtual void testSqlContainIsNullFunctionShouldBeParsed3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT name, age FROM person WHERE NOT ISNULL(home, 'earn more money')");
}

public virtual void testForXmlPath() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT '|' + person_name FROM person JOIN person_group ON person.person_id = person_group.person_id WHERE person_group.group_id = 1 FOR XML PATH('')", true);
}

public virtual void testChainedFunctions() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT func('').func2('') AS foo FROM some_tables");
}

public virtual void testCollateExprIssue164() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT u.name COLLATE Latin1_General_CI_AS AS User FROM users u");
}

public virtual void testNotVariant() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ! (1 + 1)");
}

public virtual void testNotVariant2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ! 1 + 1");
}

public virtual void testNotVariant3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT NOT (1 + 1)");
}

public virtual void testNotVariant4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE NOT (1 = 1)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE ! (1 = 1)");
}

public virtual void testNotVariantIssue850() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE id = 1 AND ! (id = 1 AND id = 2)");
}

public virtual void testDateArithmentic() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + (1 DAY) FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + 1 DAY AS NEXT_DATE FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + 1 DAY NEXT_DATE FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE - 1 DAY + 1 YEAR - 1 MONTH FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN CURRENT_DATE BETWEEN (CURRENT_DATE - 1 DAY) AND ('2019-01-01') THEN 1 ELSE 0 END FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic6() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + HOURS_OFFSET HOUR AS NEXT_DATE FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic7() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + MINUTE_OFFSET MINUTE AS NEXT_DATE FROM SYSIBM.SYSDUMMY1");
}

public virtual void testDateArithmentic8() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + SECONDS_OFFSET SECOND AS NEXT_DATE FROM SYSIBM.SYSDUMMY1");
}

public virtual void testNotProblemIssue721() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM dual WHERE NOT regexp_like('a', '[\\w]+')");
}

public virtual void testIssue699() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT count(1) ", "FROM table_name "), "WHERE 1 = 1 "), "AN D uid = 1 "), "AND type IN (1, 2, 3) "), "AND time >= TIMESTAMP(DATE_SUB(CURDATE(),INTERVAL 2 DAY),'00:00:00') "), "AND time < TIMESTAMP(DATE_SUB(CURDATE(),INTERVAL (2 - 1) DAY),'00:00:00')");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testDateArithmentic9() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CURRENT_DATE + (RAND() * 12 MONTH) AS new_date FROM mytable");
}

public virtual void testDateArithmentic10() {
string sql = "select CURRENT_DATE + CASE WHEN CAST(RAND() * 3 AS INTEGER) = 1 THEN 100 ELSE 0 END DAY AS NEW_DATE from mytable";
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true), null);
}

public virtual void testDateArithmentic11() {
string sql = "select CURRENT_DATE + (dayofweek(MY_DUE_DATE) + 5) DAY FROM mytable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> list = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>>();
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(new Anonymous_4482_23(list)), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(list), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(list, 0), null);
var item = global::DripSharp.Runtime.JavaCompat.ListGet(list, 0);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition>(item.getExpression(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition add = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition>(item.getExpression());
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.IntervalExpression>(add.getRightExpression(), null);
}

private sealed class Anonymous_4482_23 : global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> __capture_0;

public Anonymous_4482_23(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect, S parameters) {
global::DripSharp.Runtime.JavaCompat.AddAll(this.__capture_0, plainSelect.getSelectItems());
return default!;
}
}

public virtual void testDateArithmentic12() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select CASE WHEN CAST(RAND() * 3 AS INTEGER) = 1 THEN NULL ELSE CURRENT_DATE + (month_offset MONTH) END FROM mytable", true);
}

public virtual void testDateArithmentic13() {
string sql = "SELECT INTERVAL 5 MONTH MONTH FROM mytable";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> list = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>>();
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(new Anonymous_4512_23(list)), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(list), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(list, 0), null);
var item = global::DripSharp.Runtime.JavaCompat.ListGet(list, 0);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.IntervalExpression>(item.getExpression(), null);
global::DripSharp.SqlTrellis.Expression.IntervalExpression interval = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.IntervalExpression>(item.getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("INTERVAL 5 MONTH", interval.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("MONTH", item.getAlias().getName(), null);
}

private sealed class Anonymous_4512_23 : global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> __capture_0;

public Anonymous_4512_23(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect, S parameters) {
global::DripSharp.Runtime.JavaCompat.AddAll(this.__capture_0, plainSelect.getSelectItems());
return default!;
}
}

public virtual void testRawStringExpressionIssue656(string prefix) {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select ", prefix), "'test' from foo");
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.NotNull(statement, null);
((global::DripSharp.SqlTrellis.Statement.Statement)(statement)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new Anonymous_4535_26(prefix)));
}

private sealed class Anonymous_4535_26 : global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object> {
private readonly string __capture_0;

public Anonymous_4535_26(string __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.Select select, S context) {
select.accept<object, S>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(new Anonymous_4538_31(this.__capture_0)), context);
return default!;
}

private sealed class Anonymous_4538_31 : global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> {
private readonly string __capture_0;

public Anonymous_4538_31(string __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<K>(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect, K context) {
var typedExpression = (global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0)!);
global::DripSharp.Testing.JavaAssertions.NotNull(typedExpression, null);
global::DripSharp.Testing.JavaAssertions.Null(typedExpression.getAlias(), null);
global::DripSharp.SqlTrellis.Expression.StringValue value = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.StringValue>(typedExpression.getExpression());
global::DripSharp.Testing.JavaAssertions.Equal(this.__capture_0.ToUpper(), value.getPrefix(), null);
global::DripSharp.Testing.JavaAssertions.Equal("test", value.getValue(), null);
return default!;
}
}
}

public virtual void testGroupingSets1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT COL_1, COL_2, COL_3, COL_4, COL_5, COL_6 FROM TABLE_1 ", "GROUP BY "), "GROUPING SETS ((COL_1, COL_2, COL_3, COL_4), (COL_5, COL_6))"));
}

public virtual void testGroupingSets2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COL_1 FROM TABLE_1 GROUP BY GROUPING SETS (COL_1)");
}

public virtual void testGroupingSets3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COL_1 FROM TABLE_1 GROUP BY GROUPING SETS (COL_1, ())");
}

public virtual void testLongQualifiedNamesIssue763() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT mongodb.test.test.intField, postgres.test.test.intField, postgres.test.test.datefield FROM mongodb.test.test JOIN postgres.postgres.test.test ON mongodb.test.test.intField = postgres.test.test.intField WHERE mongodb.test.test.intField = 123");
}

public virtual void testSubQueryAliasIssue754() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT C0 FROM T0 INNER JOIN T1 ON C1 = C0 INNER JOIN (SELECT W1 FROM T2) S1 ON S1.W1 = C0 ORDER BY C0");
}

public virtual void testSimilarToIssue789() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE (w_id SIMILAR TO '/foo/__/bar/(left|right)/[0-9]{4}-[0-9]{2}-[0-9]{2}(/[0-9]*)?')");
}

public virtual void testSimilarToIssue789_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE (w_id NOT SIMILAR TO '/foo/__/bar/(left|right)/[0-9]{4}-[0-9]{2}-[0-9]{2}(/[0-9]*)?')");
}

public virtual void testCaseWhenExpressionIssue262() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT X1, (CASE WHEN T.ID IS NULL THEN CASE P.WEIGHT * SUM(T.QTY) WHEN 0 THEN NULL ELSE P.WEIGHT END ELSE SUM(T.QTY) END) AS W FROM A LEFT JOIN T ON T.ID = ? RIGHT JOIN P ON P.ID = ?");
}

public virtual void testCaseWhenExpressionIssue200() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t1, t2 WHERE CASE WHEN t1.id = 1 THEN t2.name = 'Marry' WHEN t1.id = 2 THEN t2.age = 10 END");
}

public virtual void testKeywordDuplicate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT mytable.duplicate FROM mytable");
}

public virtual void testKeywordDuplicate2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE duplicate = 5");
}

public virtual void testEmptyDoubleQuotes() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE col = \"\"");
}

public virtual void testEmptyDoubleQuotes_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE col = \" \"");
}

public virtual void testInnerWithBlock() {
string stmt = "select 1 from (with mytable1 as (select 2 ) select 3 from mytable1 ) first";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems1 = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Null(withItems1, null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(select.getPlainSelect().getFromItem()!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems2 = parenthesedSelect.getPlainSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT 2)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" mytable1", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getAlias().ToString(), null);
}

public virtual void testArrayIssue648() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from a join b on a.id = b.id[1]", true);
}

public virtual void testArrayIssue638() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT PAYLOAD[0] FROM MYTABLE");
}

public virtual void testArrayIssue489() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT name[1] FROM MYTABLE");
}

public virtual void testArrayIssue377() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select 'yelp'::name as pktable_cat, n2.nspname as pktable_schem, c2.relname as pktable_name, a2.attname as pkcolumn_name, 'yelp'::name as fktable_cat, n1.nspname as fktable_schem, c1.relname as fktable_name, a1.attname as fkcolumn_name, i::int2 as key_seq, case ref.confupdtype when 'c' then 0::int2 when 'n' then 2::int2 when 'd' then 4::int2 when 'r' then 1::int2 else 3::int2 end as update_rule, case ref.confdeltype when 'c' then 0::int2 when 'n' then 2::int2 when 'd' then 4::int2 when 'r' then 1::int2 else 3::int2 end as delete_rule, ref.conname as fk_name, cn.conname as pk_name, case when ref.condeferrable then case when ref.condeferred then 5::int2 else 6::int2 end else 7::int2 end as deferrablity from ((((((( (select cn.oid, conrelid, conkey, confrelid, confkey, generate_series(array_lower(conkey, 1), array_upper(conkey, 1)) as i, confupdtype, confdeltype, conname, condeferrable, condeferred from pg_catalog.pg_constraint cn, pg_catalog.pg_class c, pg_catalog.pg_namespace n where contype = 'f' and conrelid = c.oid and relname = 'business' and n.oid = c.relnamespace and n.nspname = 'public' ) ref inner join pg_catalog.pg_class c1 on c1.oid = ref.conrelid) inner join pg_catalog.pg_namespace n1 on n1.oid = c1.relnamespace) inner join pg_catalog.pg_attribute a1 on a1.attrelid = c1.oid and a1.attnum = conkey[i]) inner join pg_catalog.pg_class c2 on c2.oid = ref.confrelid) inner join pg_catalog.pg_namespace n2 on n2.oid = c2.relnamespace) inner join pg_catalog.pg_attribute a2 on a2.attrelid = c2.oid and a2.attnum = confkey[i]) left outer join pg_catalog.pg_constraint cn on cn.conrelid = ref.confrelid and cn.contype = 'p') order by ref.oid, ref.i", true);
}

public virtual void testArrayIssue378() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select ta.attname, ia.attnum, ic.relname, n.nspname, tc.relname from pg_catalog.pg_attribute ta, pg_catalog.pg_attribute ia, pg_catalog.pg_class tc, pg_catalog.pg_index i, pg_catalog.pg_namespace n, pg_catalog.pg_class ic where tc.relname = 'business' and n.nspname = 'public' and tc.oid = i.indrelid and n.oid = tc.relnamespace and i.indisprimary = 't' and ia.attrelid = i.indexrelid and ta.attrelid = i.indrelid and ta.attnum = i.indkey[ia.attnum-1] and (not ta.attisdropped) and (not ia.attisdropped) and ic.oid = i.indexrelid order by ia.attnum", true);
}

public virtual void testArrayRange() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (arr[1:3])[1] FROM MYTABLE");
}

public virtual void testIssue842() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT a.id lendId, ", "a.lend_code                                            lendCode, "), "a.amount, "), "a.remaining_principal                                  remainingPrincipal, "), "a.interest_rate                                        interestRate, "), "date_add(a.lend_time, INTERVAL a.repayment_period DAY) lendEndTime, "), "a.lend_time                                            lendTime "), "FROM risk_lend a "), "WHERE a.loan_id = 1"), true);
}

public virtual void testIssue842_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT INTERVAL a.repayment_period DAY");
}

public virtual void testIssue848() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT IF(USER_ID > 10 AND SEX = 1, 1, 0)");
}

public virtual void testIssue848_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT IF(USER_ID > 10, 1, 0)");
}

public virtual void testIssue848_3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT c1, multiset(SELECT * FROM mytable WHERE cond = 10) FROM T1 WHERE cond2 = 20");
}

public virtual void testIssue848_4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select c1 from T1 where someFunc(select f1 from t2 where t2.id = T1.key) = 10", true);
}

public virtual void testMultiColumnAliasIssue849() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable AS mytab2(col1, col2)");
}

public virtual void testMultiColumnAliasIssue849_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM crosstab('select rowid, attribute, value from ct where attribute = ''att2'' or attribute = ''att3'' order by 1,2') AS ct(row_name text, category_1 text, category_2 text, category_3 text)");
}

public virtual void testTableStatementIssue1836() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("TABLE columns ORDER BY column_name LIMIT 10 OFFSET 10");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("TABLE columns ORDER BY column_name LIMIT 10");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("TABLE columns ORDER BY column_name");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("TABLE columns LIMIT 10 OFFSET 10");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("TABLE columns LIMIT 10");
}

public virtual void testLimitClauseDroppedIssue845() {
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM employee ORDER BY emp_id LIMIT 10 OFFSET 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * FROM employee ORDER BY emp_id OFFSET 2 LIMIT 10")), null);
}

public virtual void testLimitClauseDroppedIssue845_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM employee ORDER BY emp_id LIMIT 10 OFFSET 2");
}

public virtual void testChangeKeywordIssue859() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM CHANGE.TEST");
}

public virtual void testEndKeyword() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT end AS end_6 FROM mytable");
}

public virtual void testStartKeyword() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT c0_.start AS start_5 FROM mytable");
}

public virtual void testSizeKeywordIssue867() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT size FROM mytable");
}

public virtual void testPartitionByWithBracketsIssue865() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT subject_id, student_id, sum(mark) OVER (PARTITION BY subject_id, student_id ) FROM marks");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT subject_id, student_id, sum(mark) OVER (PARTITION BY (subject_id, student_id) ) FROM marks");
}

public virtual void testWithAsRecursiveIssue874() {
string stmt = "WITH rn AS (SELECT rownum rn FROM dual CONNECT BY level <= (SELECT max(cases) FROM t1)) SELECT pname FROM t1, rn WHERE rn <= cases ORDER BY pname";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT rownum rn FROM dual CONNECT BY level <= (SELECT max(cases) FROM t1))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" rn", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testSessionKeywordIssue876() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ID_COMPANY FROM SESSION.COMPANY");
}

public virtual void testWindowClauseWithoutOrderByIssue869() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT subject_id, student_id, mark, sum(mark) OVER (PARTITION BY (subject_id) ROWS BETWEEN UNBOUNDED PRECEDING AND CURRENT ROW) FROM marks");
}

public virtual void testKeywordSizeIssue880() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT b.pattern_size_id, b.pattern_id, b.variation, b.measure_remark, b.pake_name, b.ident_size, CONCAT( GROUP_CONCAT(a.size) ) AS 'title', CONCAT( '[', GROUP_CONCAT( '{\"patternSizeDetailId\":', a.pattern_size_detail_id, ',\"patternSizeId\":', a.pattern_size_id, ',\"size\":\"', a.size, '\",\"sizeValue\":', a.size_value SEPARATOR '},' ), '}]' ) AS 'designPatternSizeDetailJson' FROM design_pattern_size_detail a LEFT JOIN design_pattern_size b ON a.pattern_size_id = b.pattern_size_id WHERE b.pattern_id = 792679713905573986 GROUP BY b.pake_name,b.pattern_size_id", true);
}

public virtual void testKeywordCharacterIssue884() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT Character, Duration FROM actor");
}

public virtual void testCrossApplyIssue344() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select s.*, c.*, calc2.summary\n", "from student s\n"), "join class c on s.class_id = c.id\n"), "cross apply (\n"), "  select s.first_name + ' ' + s.last_name + ' (' + s.sex + ')' as student_full_name\n"), ") calc1\n"), "cross apply (\n"), "  select case c.some_styling_type when 'A' then c.name + ' - ' + calc1.student_full_name\n"), "            when 'B' then calc1.student_full_name + ' - ' + c.name\n"), "            else calc1.student_full_name end as summary\n"), ") calc2"), true);
}

public virtual void testOuterApplyIssue930() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable D OUTER APPLY (SELECT * FROM mytable2 E WHERE E.ColID = D.ColID) A");
}

public virtual void testWrongParseTreeIssue89() {
global::DripSharp.SqlTrellis.Statement.Select.Select unionQuery = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * FROM table1 UNION SELECT * FROM table2 ORDER BY col")!);
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList unionQueries = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(unionQuery!);
global::DripSharp.Testing.JavaAssertJ.That(unionQueries.getSelects()).Extracting(((global::System.Func<global::DripSharp.SqlTrellis.Statement.Select.Select, object>)((select) => (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!)))).AllSatisfy(((global::System.Action<global::DripSharp.SqlTrellis.Statement.Select.PlainSelect>)((ps) => global::DripSharp.Testing.JavaAssertions.Null(ps.getOrderByElements(), null))));
global::DripSharp.Testing.JavaAssertJ.That(unionQueries.getOrderByElements()).IsNotNull().HasSize(1).Extracting(((global::System.Func<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement, object>)((item) => item.ToString()))).Contains("col");
}

public virtual void testCaseWithComplexWhenExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT av.app_id, MAX(av.version_no) AS version_no\n", "FROM app_version av\n"), "JOIN app_version_policy avp ON av.id = avp.app_version_id\n"), "WHERE av.`status` = 1\n"), "AND CASE \n"), "WHEN avp.area IS NOT NULL\n"), "AND length(avp.area) > 0 THEN avp.area LIKE CONCAT('%,', '12', ',%')\n"), "OR avp.area LIKE CONCAT('%,', '13', ',%')\n"), "ELSE 1 = 1\n"), "END\n"), true);
}

public virtual void testOrderKeywordIssue932() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT order FROM tmp3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT tmp3.order FROM tmp3");
}

public virtual void testOrderKeywordIssue932_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT group FROM tmp3");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT tmp3.group FROM tmp3");
}

public virtual void testTableFunctionInExprIssue923() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE func(a) IN func(b)");
}

public virtual void testTableFunctionInExprIssue923_3() {
string stmt = global::DripSharp.SqlTrellis.Tests.Support.ReadText(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SelectTest), "large-sql-issue-923-2.txt"), global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true);
}

public virtual void testTableFunctionInExprIssue923_4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT MAX(CASE WHEN DUPLICATE_CLAIM_NUMBER IN  '1' THEN COALESCE(CLAIM_STATUS2,CLAIM_STATUS1) ELSE NULL END) AS DUPE_1_KINAL_CLAIM_STATUS", true);
}

public virtual void testTableFunctionInExprIssue923_5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN DUPLICATE_CLAIM_NUMBER IN  '1' THEN COALESCE(CLAIM_STATUS2,CLAIM_STATUS1) ELSE NULL END", true);
}

public virtual void testTableFunctionInExprIssue923_6() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE func(a) IN '1'");
}

public virtual void testKeyWordCreateIssue941() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT b.create FROM table b WHERE b.id = 1");
}

public virtual void testKeyWordCreateIssue941_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select f.select from `from` f", true);
}

public virtual void testCurrentIssue940() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT date(current) AS test_date FROM systables WHERE tabid = 1");
}

public virtual void testIssue1878() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM MY_TABLE1 FOR SHARE");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM MY_TABLE1 FOR NO KEY UPDATE");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM MY_TABLE1 FOR KEY SHARE");
}

public virtual void testIssue1878ViaJava() {
string expectedSQLStr = "SELECT * FROM MY_TABLE1 FOR SHARE";
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table().withName("MY_TABLE1");
global::DripSharp.SqlTrellis.Statement.Select.Select select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(table).withForMode(global::DripSharp.SqlTrellis.Statement.Select.ForMode.KEY_SHARE).withForMode(global::DripSharp.SqlTrellis.Statement.Select.ForMode.SHARE);
global::DripSharp.Testing.JavaAssertions.Equal(expectedSQLStr, select.ToString(), null);
}

public virtual void testKeyWordView() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ma.m_a_id, ma.anounsment, ma.max_view, ma.end_date, ma.view FROM member_anounsment as ma WHERE ( ( (ma.end_date > now() ) AND (ma.max_view >= ma.view) ) AND ( (ma.member_id='xxx') ) )", true);
}

public virtual void testPreserveAndOperator() {
string statement = "SELECT * FROM mytable WHERE 1 = 2 && 2 = 3";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("mytable")).withWhere(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression().withUseOperator(true).withLeftExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2)))))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3))))))), statement);
}

public virtual void testPreserveAndOperator_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE (field_1 && ?)");
}

public virtual void testCheckDateFunctionIssue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT DATEDIFF(NOW(), MIN(s.startTime))");
}

public virtual void testCheckDateFunctionIssue_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT DATE_SUB(NOW(), INTERVAL :days DAY)");
}

public virtual void testCheckDateFunctionIssue_3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT DATE_SUB(NOW(), INTERVAL 1 DAY)");
}

public virtual void testCheckColonVariable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE (col1, col2) IN ((:qp0, :qp1), (:qp2, :qp3))");
}

public virtual void testVariableAssignment() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @SELECTVariable = 2");
}

public virtual void testVariableAssignment2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @var = 1");
}

public virtual void testVariableAssignment3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT @varname := @varname + 1 AS counter");
}

public virtual void testKeyWordOfIssue1029() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT of.Full_Name_c AS FullName FROM comdb.Offer_c AS of");
}

public virtual void testKeyWordExceptIssue1026() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM xxx WHERE exclude = 1");
}

public virtual void testSelectConditionsIssue720And991() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT column IS NOT NULL FROM table");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 0 IS NULL");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 + 2");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 < 2");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 > 2");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 + 2 AS a, 3 < 4 AS b");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 < 2 AS a, 0 IS NULL AS b");
}

public virtual void testKeyWordExceptIssue1040() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT FORMAT(100000, 2)");
}

public virtual void testKeyWordExceptIssue1044() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT SP_ID FROM ST_PR WHERE INSTR(',' || SP_OFF || ',', ',' || ? || ',') > 0");
}

public virtual void testKeyWordExceptIssue1055() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT INTERVAL ? DAY");
}

public virtual void testKeyWordExceptIssue1055_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE A.end_time > now() AND A.end_time <= date_add(now(), INTERVAL ? DAY)");
}

public virtual void testIssue1062() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE temperature.timestamp <= @to AND temperature.timestamp >= @from");
}

public virtual void testIssue1062_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM mytable WHERE temperature.timestamp <= @until AND temperature.timestamp >= @from");
}

public virtual void testIssue1068() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT t2.c AS div");
}

public virtual void selectWithSingleIn() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 FROM dual WHERE a IN 1");
}

public virtual void testKeywordSequenceIssue1075() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT a.sequence FROM all_procedures a");
}

public virtual void testKeywordSequenceIssue1074() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t_user WITH (NOLOCK)");
}

public virtual void testContionItemsSelectedIssue1077() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 > 0");
}

public virtual void testExistsKeywordIssue1076() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT EXISTS (4)");
}

public virtual void testExistsKeywordIssue1076_1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT mycol, EXISTS (SELECT mycol FROM mytable) mycol2 FROM mytable");
}

public virtual void testFormatKeywordIssue1078() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT FORMAT(date, 'yyyy-MM') AS year_month FROM mine_table");
}

public virtual void testConditionalParametersForFunctions() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT myFunc(SELECT mycol FROM mytable)");
}

public virtual void testCreateTableWithParameterDefaultFalseIssue1088() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT p.*, rhp.house_id FROM rel_house_person rhp INNER JOIN person p ON rhp.person_id = p.if WHERE rhp.house_id IN (SELECT house_id FROM rel_house_person WHERE person_id = :personId AND current_occupant = :current) AND rhp.current_occupant = :currentOccupant");
}

public virtual void testMissingLimitKeywordIssue1006() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT id, name FROM test OFFSET 20 LIMIT 10");
global::DripSharp.Testing.JavaAssertions.Equal("SELECT id, name FROM test LIMIT 10 OFFSET 20", global::DripSharp.Runtime.JavaCompat.StringValueOf(stmt), null);
}

public virtual void testKeywordUnsignedIssue961() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COLUMN1, COLUMN2, CASE WHEN COLUMN1.DATA NOT IN ('1', '3') THEN CASE WHEN CAST(COLUMN2 AS UNSIGNED) IN ('1', '2', '3') THEN 'Q1' ELSE 'Q2' END END AS YEAR FROM TESTTABLE");
}

public virtual void testH2CaseWhenFunctionIssue1091() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASEWHEN(ID = 1, 'A', 'B') FROM mytable");
}

public virtual void testMultiPartTypesIssue992() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST('*' AS pg_catalog.text)");
}

public virtual void testSetOperationWithParenthesisIssue1094() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM ((SELECT A FROM tbl) UNION DISTINCT (SELECT B FROM tbl2)) AS union1");
}

public virtual void testSetOperationWithParenthesisIssue1094_2() {
string sqlStr = "SELECT * FROM (((SELECT A FROM tbl)) UNION DISTINCT (SELECT B FROM tbl2)) AS union1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testSetOperationWithParenthesisIssue1094_3() {
string sqlStr = "SELECT * FROM (((SELECT A FROM tbl)) UNION DISTINCT ((SELECT B FROM tbl2))) AS union1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testSetOperationWithParenthesisIssue1094_4() {
string sqlStr = "SELECT * FROM (((((SELECT A FROM tbl)))) UNION DISTINCT (((((((SELECT B FROM tbl2)))))))) AS union1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testSignedKeywordIssue1100() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT signed, unsigned FROM mytable");
}

public virtual void testSignedKeywordIssue995() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT leading FROM prd_reprint");
}

public virtual void testSelectTuple() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT hyperloglog_distinct((1, 2)) FROM t");
}

public virtual void testArrayDeclare() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ARRAY[1, f1], ARRAY[[1, 2], [3, f2 + 1]], ARRAY[]::text[] FROM t1");
}

public virtual void testColonDelimiterIssue1134() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * FROM stores_demo:informix.accounts");
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM stores_demo.informix.accounts", global::DripSharp.Runtime.JavaCompat.StringValueOf(stmt), null);
}

public virtual void testKeywordSkipIssue1136() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT skip");
}

public virtual void testKeywordAlgorithmIssue1137() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT algorithm FROM tablename");
}

public virtual void testKeywordAlgorithmIssue1138() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM in.tablename");
}

public virtual void testFunctionOrderBy() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT array_agg(DISTINCT s ORDER BY b)[1] FROM t");
}

public virtual void testProblematicDeparsingIssue1183() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ARRAY_AGG(NAME ORDER BY ID) FILTER (WHERE NAME IS NOT NULL)");
}

public virtual void testProblematicDeparsingIssue1183_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ARRAY_AGG(ID ORDER BY ID) OVER (ORDER BY ID)");
}

public virtual void testKeywordCostsIssue1185() {
string stmt = "WITH costs AS (SELECT * FROM MY_TABLE1 AS ALIAS_TABLE1) SELECT * FROM TESTSTMT";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT * FROM MY_TABLE1 AS ALIAS_TABLE1)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" costs", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testFunctionWithComplexParameters_Issue1190() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT to_char(a = '3') FROM dual", true);
}

public virtual void testConditionsWithExtraBrackets_Issue1194() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (col IS NULL) FROM tbl", true);
}

public virtual void testWithValueListWithExtraBrackets1135() {
string stmt = "with sample_data(day, value) as (values ((0, 13), (1, 12), (2, 15), (3, 4), (4, 8), (5, 16))) select day, value from sample_data";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES ((0, 13), (1, 12), (2, 15), (3, 4), (4, 8), (5, 16))", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getValues().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" sample_data", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

public virtual void testWithValueListWithOutExtraBrackets1135() {
string stmt1 = global::DripSharp.Runtime.JavaCompat.Concat("with sample_data(\"DAY\") as (values 0, 1, 2)\n", "           select \"DAY\" from sample_data");
global::DripSharp.SqlTrellis.Statement.Select.Select select1 = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt1, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems1 = select1.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems1), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES 0, 1, 2", global::DripSharp.Runtime.JavaCompat.ListGet(withItems1, 0).getSelect().getValues().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" sample_data", global::DripSharp.Runtime.JavaCompat.ListGet(withItems1, 0).getAlias().ToString(), null);
string stmt2 = "with sample_data(day, value) as (values (0, 13), (1, 12), (2, 15), (3, 4), (4, 8), (5, 16)) select day, value from sample_data";
global::DripSharp.SqlTrellis.Statement.Select.Select select2 = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems2 = select2.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES (0, 13), (1, 12), (2, 15), (3, 4), (4, 8), (5, 16)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getSelect().getValues().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" sample_data", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getAlias().ToString(), null);
}

public virtual void testWithInsideWithIssue1186() {
string stmt = "WITH TESTSTMT1 AS ( WITH TESTSTMT2 AS (SELECT * FROM MY_TABLE2) SELECT col1, col2 FROM TESTSTMT2) SELECT * FROM TESTSTMT";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal(" TESTSTMT1", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect()!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems2 = parenthesedSelect.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT * FROM MY_TABLE2)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" TESTSTMT2", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getAlias().ToString(), null);
}

public virtual void testKeywordSynonymIssue1211() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select businessDate as \"bd\", synonym as \"synonym\" from sc.tab", true);
}

public virtual void testGroupedByIssue1176() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select id_instrument, count(*)\n", "from cfe.instrument\n"), "group by (id_instrument)"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select count(*)\n", "from cfe.instrument\n"), "group by ()"), true);
}

public virtual void testGroupedByWithExtraBracketsIssue1210() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select a,b,c from table group by rollup((a,b,c))", true);
}

public virtual void testGroupedByWithExtraBracketsIssue1168() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select sum(a) as amount, b, c from TEST_TABLE group by rollup ((a,b),c)", true);
}

public virtual void testSelectRowElement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (t.tup).id, (tup).name FROM t WHERE (t.tup).id IN (1, 2, 3)");
}

public virtual void testSelectCastProblemIssue1248() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(t1.sign2 AS Nullable (char))");
}

public virtual void testSelectCastProblemIssue1248_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(t1.sign2 AS Nullable(decimal(30, 10)))");
}

public virtual void testMissingBracketsNestedInIssue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT COUNT(DISTINCT CASE WHEN room IN (11167, 12074, 4484, 4483, 6314, 11168, 10336, 16445, 13176, 13177, 13178) THEN uid END) AS uidCount from tableName", true);
}

public virtual void testAnyComparisionExpressionValuesList1232() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from foo where id != ALL(VALUES 1,2,3)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from foo where id != ALL(?::uid[])", true);
}

public virtual void testSelectAllOperatorIssue1140() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM table t0 WHERE t0.id != all(5)");
}

public virtual void testSelectAllOperatorIssue1140_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM table t0 WHERE t0.id != all(?::uuid[])");
}

public virtual void testDB2SpecialRegisterDateTimeIssue1249() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM test.abc WHERE col > CURRENT_TIME", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM test.abc WHERE col > CURRENT TIME", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM test.abc WHERE col > CURRENT_TIMESTAMP", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM test.abc WHERE col > CURRENT TIMESTAMP", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM test.abc WHERE col > CURRENT_DATE", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM test.abc WHERE col > CURRENT DATE", true);
}

public virtual void testKeywordFilterIssue1255() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT col1 AS filter FROM table");
}

public virtual void testConnectByRootIssue1255() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT last_name \"Employee\", CONNECT_BY_ROOT last_name \"Manager\",\n", "   LEVEL-1 \"Pathlen\", SYS_CONNECT_BY_PATH(last_name, '/') \"Path\"\n"), "   FROM employees\n"), "   WHERE LEVEL > 1 and department_id = 110\n"), "   CONNECT BY PRIOR employee_id = manager_id"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT name, SUM(salary) \"Total_Salary\" FROM (\n", "   SELECT CONNECT_BY_ROOT last_name as name, Salary\n"), "      FROM employees\n"), "      WHERE department_id = 110\n"), "      CONNECT BY PRIOR employee_id = manager_id)\n"), "      GROUP BY name"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT CONNECT_BY_ROOT last_name as name", ", salary "), "FROM employees "), "WHERE department_id = 110 "), "CONNECT BY PRIOR employee_id = manager_id"), true);
}

public virtual void testUnionLimitOrderByIssue1268() {
string sqlStr = "(SELECT __time FROM traffic_protocol_stat_log LIMIT 1) UNION ALL (SELECT __time FROM traffic_protocol_stat_log ORDER BY __time LIMIT 1)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testCastToRowConstructorIssue1267() {
string sqlStr = "SELECT CAST(ROW(dataid, value, calcMark) AS ROW(datapointid CHAR, value CHAR, calcMark CHAR)) AS datapoints";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testCollisionWithSpecialStringFunctionsIssue1284() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT test( a in (1) AND 2=2) ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select\n", "sum(if(column1 in('value1', 'value2'), 1, 0)) as tcp_logs,\n"), "sum(if(column1 in ('value1', 'value2') and column2 = 'value3', 1, 0)) as base_tcp_logs\n"), "from\n"), "table1\n"), "where\n"), "recv_time >= toDateTime('2021-07-20 00:00:00')\n"), "and recv_time < toDateTime('2021-07-21 00:00:00')"), true);
}

public virtual void testJoinWithTrailingOnExpressionIssue1302() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM TABLE1 tb1\n", "INNER JOIN TABLE2 tb2\n"), "INNER JOIN TABLE3 tb3\n"), "INNER JOIN TABLE4 tb4\n"), "ON (tb3.aaa = tb4.aaa)\n"), "ON (tb2.aaa = tb3.aaa)\n"), "ON (tb1.aaa = tb2.aaa)"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM\n"), "TABLE1 tbl1\n"), "    INNER JOIN TABLE2 tbl2\n"), "        INNER JOIN TABLE3 tbl3\n"), "        ON (tbl2.column1 = tbl3.column1)\n"), "    ON (tbl1.column2 = tbl2.column2)\n"), "WHERE\n"), "tbl1.column1 = 123"), true);
}

public virtual void testSimpleJoinOnExpressionIssue1229() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select t1.column1,t1.column2,t2.field1,t2.field2 from T_DT_ytb_01 t1 , T_DT_ytb_02 t2 on t1.column1 = t2.field1", true);
}

public virtual void testNestedCaseComplexExpressionIssue1306() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT CASE\n", "WHEN 'USD' = 'USD'\n"), "THEN 0\n"), "ELSE CASE\n"), "WHEN 'USD' = 'EURO'\n"), "THEN ( CASE\n"), "WHEN 'A' = 'B'\n"), "THEN 0\n"), "ELSE 1\n"), "END * 100 )\n"), "ELSE 2\n"), "END\n"), "END AS \"column1\"\n"), "FROM test_schema.table_name\n"), ""), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT CASE\n", "WHEN 'USD' = 'USD'\n"), "THEN 0\n"), "ELSE CASE\n"), "WHEN 'USD' = 'EURO'\n"), "THEN CASE\n"), "WHEN 'A' = 'B'\n"), "THEN 0\n"), "ELSE 1\n"), "END * 100 \n"), "ELSE 2\n"), "END\n"), "END AS \"column1\"\n"), "FROM test_schema.table_name\n"), ""), true);
}

public virtual void testGroupByComplexExpressionIssue1308() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select * \n", "from dual \n"), "group by case when 1=1 then 'X' else 'Y' end, column1"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select * \n", "from dual \n"), "group by (case when 1=1 then 'X' else 'Y' end, column1)"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select * \n", "from dual \n"), "group by (case when 1=1 then 'X' else 'Y' end), column1"), true);
}

public virtual void testReservedKeywordsMSSQLUseIndexIssue1325() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT col FROM table USE INDEX(primary)", true);
}

public virtual void testReservedKeywordsIssue1352() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT system from b1.system", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT query from query.query", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT fulltext from fulltext.fulltext", true);
}

public virtual void testGroupByWithAllTableColumns() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select c.post_id, p.* from posts p inner join comments c on c.post_id = p.post_id group by p.post_id, c.post_id, p.*;");
}

public virtual void testTableSpaceKeyword() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT DDF.tablespace                                  TABLESPACE_NAME\n", "         , maxtotal / 1024 / 1024                        \"MAX_MB\"\n"), "         , ( total - free ) / 1024 / 1024                \"USED_MB\"\n"), "         , ( maxtotal - ( total - free ) ) / 1024 / 1024 \"AVAILABLE_MB\"\n"), "         , total / 1024 / 1024                           \"ALLOCATED_MB\"\n"), "         , free / 1024 / 1024                            \"ALLOCATED_FREE_MB\"\n"), "         , ( ( total - free ) / maxtotal * 100 )         \"USED_PERC\"\n"), "         , cnt                                           \"FILE_COUNT\"\n"), "  FROM   (SELECT tablespace_name                  TABLESPACE\n"), "                 , SUM(bytes)                     TOTAL\n"), "                 , SUM(Greatest(maxbytes, bytes)) MAXTOTAL\n"), "                 , Count(*)                       CNT\n"), "          FROM   dba_data_files\n"), "          GROUP  BY tablespace_name) DDF\n"), "         , (SELECT tablespace_name TABLESPACE\n"), "                   , SUM(bytes)    FREE\n"), "                   , Max(bytes)    MAXF\n"), "            FROM   dba_free_space\n"), "            GROUP  BY tablespace_name) DFS\n"), "  WHERE  DDF.tablespace = DFS.tablespace\n"), "  ORDER  BY 1 DESC"), true);
}

public virtual void testTableSpecificAllColumnsIssue1346() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(*) from a", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT count(a.*) from a", true);
}

public virtual void testPostgresDollarQuotes_1372() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT UPPER($$some text$$) FROM a");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM a WHERE a.test = $$where text$$");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM a WHERE a.test = $$$$");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM a WHERE a.test = $$ $$");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT aa AS $$My Column Name$$ FROM a");
}

public virtual void testCanCallSubSelectOnWithItemEvenIfNotSetIssue1369() {
global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement> item = new global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>();
global::DripSharp.Testing.JavaAssertJ.That(item.getSelect()).IsNull();
}

public virtual void testCaseElseExpressionIssue1375() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM t1 WHERE CASE WHEN 1 = 1 THEN c1 = 'a' ELSE c2 = 'b' AND c4 = 'd' END", true);
}

public virtual void testComplexInExpressionIssue905() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table_a\n"), "WHERE other_id IN ( (   SELECT id\n"), "                        FROM table_b\n"), "                        WHERE name LIKE '%aa%' ), ( SELECT id\n"), "                                                    FROM table_b\n"), "                                                    WHERE name LIKE '%bb%' ) )\n"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM v.e\n"), "WHERE cid <> rid\n"), "    AND rid NOT IN (    ( SELECT DISTINCT\n"), "                                rid\n"), "                            FROM v.s )\n"), "                        UNION (\n"), "                            SELECT DISTINCT\n"), "                                rid\n"), "                            FROM v.p ) )\n"), "    AND \"timestamp\" <= 1298505600000\n"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table_a\n"), "WHERE ( a, b, c ) IN ( ( 1, 2, 3 ), ( 3, 4, 5 ) )\n"), true);
}

public virtual void testComplexInExpressionSimplyfied() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM dual\n"), "WHERE a IN ( ( SELECT id1), ( SELECT id2) )\n"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("a IN ( ( SELECT id1) UNION (SELECT id2) )\n", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM e\n"), "WHERE a IN ( ( SELECT id1) UNION (SELECT id2) )\n"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table_a\n"), "WHERE ( a, b, c ) IN ( ( 1, 2, 3 ), ( 3, 4, 5 ) )\n"), true);
}

public virtual void testLogicalExpressionSelectItemIssue1381() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ( 1 + 1 ) = ( 1 + 2 )", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ( 1 = 1 ) = ( 1 = 2 )", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ( ( 1 = 1 ) AND ( 1 = 2 ) )", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ( 1 = 1 ) AND ( 1 = 2 )", true);
}

public virtual void testKeywordAtIssue1414() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM table1 at");
}

public virtual void testIgnoreNullsForWindowFunctionsIssue1429() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT lag(mydata) IGNORE NULLS OVER (ORDER BY sortorder) AS previous_status FROM mytable");
}

public virtual void testPerformanceIssue1438() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "SELECT \t* FROM TABLE_1 t1\n"), "WHERE\n"), "\t(((t1.COL1 = 'VALUE2' )\n"), "\t\tAND (t1.CAL2 = 'VALUE2' ))\n"), "\t\tAND (((1 = 1 )\n"), "\t\t\tAND ((((((t1.id IN (940550 ,940600 ,940650 ,940700 ,940750 ,940800 ,940850 ,940900 ,940950 ,941000 ,941050 ,941100 ,941150 ,941200 ,941250 ,941300 ,941350 ,941400 ,941450 ,941500 ,941550 ,941600 ,941650 ,941700 ,941750 ,941800 ,941850 ,941900 ,941950 ,942000 ,942050 ,942100 ,942150 ,942200 ,942250 ,942300 ,942350 ,942400 ,942450 ,942500 ,942550 ,942600 ,942650 ,942700 ,942750 ,942800 ,942850 ,942900 ,942950 ,943000 ,943050 ,943100 ,943150 ,943200 ,943250 ,943300 ,943350 ,943400 ,943450 ,943500 ,943550 ,943600 ,943650 ,943700 ,943750 ,943800 ,943850 ,943900 ,943950 ,944000 ,944050 ,944100 ,944150 ,944200 ,944250 ,944300 ,944350 ,944400 ,944450 ,944500 ,944550 ,944600 ,944650 ,944700 ,944750 ,944800 ,944850 ,944900 ,944950 ,945000 ,945050 ,945100 ,945150 ,945200 ,945250 ,945300 ))\n"), "\t\t\t\tOR (t1.id IN (945350 ,945400 ,945450 ,945500 ,945550 ,945600 ,945650 ,945700 ,945750 ,945800 ,945850 ,945900 ,945950 ,946000 ,946050 ,946100 ,946150 ,946200 ,946250 ,946300 ,946350 ,946400 ,946450 ,946500 ,946550 ,946600 ,946650 ,946700 ,946750 ,946800 ,946850 ,946900 ,946950 ,947000 ,947050 ,947100 ,947150 ,947200 ,947250 ,947300 ,947350 ,947400 ,947450 ,947500 ,947550 ,947600 ,947650 ,947700 ,947750 ,947800 ,947850 ,947900 ,947950 ,948000 ,948050 ,948100 ,948150 ,948200 ,948250 ,948300 ,948350 ,948400 ,948450 ,948500 ,948550 ,948600 ,948650 ,948700 ,948750 ,948800 ,948850 ,948900 ,948950 ,949000 ,949050 ,949100 ,949150 ,949200 ,949250 ,949300 ,949350 ,949400 ,949450 ,949500 ,949550 ,949600 ,949650 ,949700 ,949750 ,949800 ,949850 ,949900 ,949950 ,950000 ,950050 ,950100 )))\n"), "\t\t\t\tOR (t1.id IN (950150 ,950200 ,950250 ,950300 ,950350 ,950400 ,950450 ,950500 ,950550 ,950600 ,950650 ,950700 ,950750 ,950800 ,950850 ,950900 ,950950 ,951000 ,951050 ,951100 ,951150 ,951200 ,951250 ,951300 ,951350 ,951400 ,951450 ,951500 ,951550 ,951600 ,951650 ,951700 ,951750 ,951800 ,951850 ,951900 ,951950 ,952000 ,952050 ,952100 ,952150 ,952200 ,952250 ,952300 ,952350 ,952400 ,952450 ,952500 ,952550 ,952600 ,952650 ,952700 ,952750 ,952800 ,952850 ,952900 ,952950 ,953000 ,953050 ,953100 ,953150 ,953200 ,953250 ,953300 ,953350 ,953400 ,953450 ,953500 ,953550 ,953600 ,953650 ,953700 )))\n"), "\t\t\t\tOR (t1.id IN (953750 ,953800 ,953850 ,953900 ,953950 ,954000 ,954050 ,954100 ,954150 ,954200 ,954250 ,954300 ,954350 ,954400 ,954450 ,954500 ,954550 ,954600 ,954650 ,954700 ,954750 ,954800 ,954850 ,954900 ,954950 ,955000 ,955050 ,955100 ,955150 ,955200 ,955250 ,955300 ,955350 ,955400 ,955450 ,955500 ,955550 ,955600 ,955650 ,955700 ,955750 ,955800 ,955850 ,955900 ,955950 ,956000 ,956050 ,956100 ,956150 ,956200 ,956250 ,956300 ,956350 ,956400 ,956450 ,956500 ,956550 ,956600 ,956650 ,956700 ,956750 ,956800 ,956850 ,956900 ,956950 ,957000 ,957050 ,957100 ,957150 ,957200 ,957250 ,957300 )))\n"), "\t\t\t\tOR (t1.id IN (944100, 944150, 944200, 944250, 944300, 944350, 944400, 944450, 944500, 944550, 944600, 944650, 944700, 944750, 944800, 944850, 944900, 944950, 945000 )))\n"), "\t\t\t\tOR (t1.id IN (957350 ,957400 ,957450 ,957500 ,957550 ,957600 ,957650 ,957700 ,957750 ,957800 ,957850 ,957900 ,957950 ,958000 ,958050 ,958100 ,958150 ,958200 ,958250 ,958300 ,958350 ,958400 ,958450 ,958500 ,958550 ,958600 ,958650 ,958700 ,958750 ,958800 ,958850 ,958900 ,958950 ,959000 ,959050 ,959100 ,959150 ,959200 ,959250 ,959300 ,959350 ,959400 ,959450 ,959500 ,959550 ,959600 ,959650 ,959700 ,959750 ,959800 ,959850 ,959900 ,959950 ,960000 ,960050 ,960100 ,960150 ,960200 ,960250 ,960300 ,960350 ,960400 ,960450 ,960500 ,960550 ,960600 ,960650 ,960700 ,960750 ,960800 ,960850 ,960900 ,960950 ,961000 ,961050 ,961100 ,961150 ,961200 ,961250 ,961300 ,961350 ,961400 ,961450 ,961500 ,961550 ,961600 ,961650 ,961700 ,961750 ,961800 ,961850 ,961900 ,961950 ,962000 ,962050 ,962100 ))))\n"), "\t\t\t\tOR (t1.id IN (962150 ,962200 ,962250 ,962300 ,962350 ,962400 ,962450 ,962500 ,962550 ,962600 ,962650 ,962700 ,962750 ,962800 ,962850 ,962900 ,962950 ,963000 ,963050 ,963100 ,963150 ,963200 ,963250 ,963300 ,963350 ,963400 ,963450 ,963500 ,963550 ,963600 ,963650 ,963700 ,963750 ,963800 ,963850 ,963900 ,963950 ,964000 ,964050 ,964100 ,964150 ,964200 ,964250 ,964300 ,964350 ,964400 ,964450 ,964500 ,964550 ,964600 ,964650 ,964700 ,964750 ,964800 ,964850 ,964900 ,964950 ,965000 ,965050 ,965100 ,965150 ,965200 ,965250 ,965300 ,965350 ,965400 ,965450 ,965500 ))))\n"), "\tAND t1.COL3 IN (\n"), "\t    SELECT\n"), "\t\t    t2.COL3\n"), "\t    FROM\n"), "\t\t    TABLE_6 t6,\n"), "\t\t    TABLE_1 t5,\n"), "\t\t    TABLE_4 t4,\n"), "\t\t    TABLE_3 t3,\n"), "\t\t    TABLE_1 t2\n"), "\t    WHERE\n"), "\t\t    (((((((t5.CAL3 = T6.id)\n"), "\t\t\t    AND (t5.CAL5 = t6.CAL5))\n"), "\t\t\t    AND (t5.CAL1 = t6.CAL1))\n"), "\t\t\t    AND (t3.CAL1 IN (108500)))\n"), "\t\t\t    AND (t5.id = t2.id))\n"), "\t\t\t    AND NOT ((t6.CAL6 IN ('VALUE'))))\n"), "\t\t\t    AND ((t2.id = t3.CAL2)\n"), "\t\t\t\t    AND (t4.id = t3.CAL3))))\n"), "ORDER BY\n"), "\tt1.id ASC"), true);
}

public virtual void testPerformanceIssue1397() {
string sqlStr = global::DripSharp.SqlTrellis.Tests.Support.ReadText(global::DripSharp.SqlTrellis.Tests.Support.ResourceUri(typeof(global::DripSharp.SqlTrellis.Statement.Select.SelectTest), "/net/sf/jsqlparser/statement/select/performanceIssue1397.sql"), global::System.Text.Encoding.Default);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testWithIsolation() {
string statement = "SELECT * FROM mytable WHERE mytable.col = 9 WITH ur";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
string isolation = select.getIsolation().getIsolation();
global::DripSharp.Testing.JavaAssertions.Equal("ur", isolation, null);
statement = "SELECT * FROM mytable WHERE mytable.col = 9 WITH Cs";
select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
isolation = select.getIsolation().getIsolation();
global::DripSharp.Testing.JavaAssertions.Equal("Cs", isolation, null);
}

public virtual void testLoclTimezone1471() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT TO_CHAR(CAST(SYSDATE AS TIMESTAMP WITH LOCAL TIME ZONE), 'HH:MI:SS AM TZD') FROM DUAL");
}

public virtual void testMissingLimitIssue1505() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("(SELECT * FROM mytable) LIMIT 1");
}

public virtual void testPostgresNaturalJoinIssue1559() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT t1.ID,t1.name, t2.DID, t2.name\n", "FROM table1 as t1\n"), "NATURAL RIGHT JOIN table2 as t2"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT t1.ID,t1.name, t2.DID, t2.name\n", "FROM table1 as t1\n"), "NATURAL RIGHT JOIN table2 as t2"), true);
}

public virtual void testNamedWindowDefinitionIssue1581() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT sum(salary) OVER w, avg(salary) OVER w FROM empsalary WINDOW w AS (PARTITION BY depname ORDER BY salary DESC)");
}

public virtual void testNamedWindowDefinitionIssue1581_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT sum(salary) OVER w1, avg(salary) OVER w2 FROM empsalary WINDOW w1 AS (PARTITION BY depname ORDER BY salary DESC), w2 AS (PARTITION BY depname2 ORDER BY salary2)");
}

public virtual void testTimestamptzDateTimeLiteral() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM table WHERE x >= TIMESTAMPTZ '2021-07-05 00:00:00+00'");
}

public virtual void testFunctionComplexExpressionParametersIssue1644() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT test(1=1, 'a', 'b')", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT if(instr('avc','a')=0, 'avc', 'aaa')", true);
}

public virtual void testOracleDBLink() {
string sqlStr = "SELECT * from tablename@dblink";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.SqlTrellis.Schema.Table table = (global::DripSharp.SqlTrellis.Schema.Table)(plainSelect.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.NotEqual("tablename@dblink", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("tablename", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("dblink", table.getDBLinkName(), null);
}

public virtual void testSelectStatementWithForUpdateAndSkipLockedTokens() {
string sql = "SELECT * FROM test FOR UPDATE SKIP LOCKED";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Same(plainSelect.getForMode(), global::DripSharp.SqlTrellis.Statement.Select.ForMode.UPDATE, null);
global::DripSharp.Testing.JavaAssertions.True(plainSelect.isSkipLocked(), null);
}

public virtual void testSelectStatementWithForUpdateButWithoutSkipLockedTokens() {
string sql = "SELECT * FROM test FOR UPDATE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Same(plainSelect.getForMode(), global::DripSharp.SqlTrellis.Statement.Select.ForMode.UPDATE, null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.isSkipLocked(), null);
}

public virtual void testSelectStatementWithoutForUpdateAndSkipLockedTokens() {
string sql = "SELECT * FROM test";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!);
global::DripSharp.Testing.JavaAssertions.Null(plainSelect.getForMode(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.isSkipLocked(), null);
}

public virtual void testSelectMultidimensionalArrayStatement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT f1, f2[1][1], f3[1][2][3] FROM test");
}

internal virtual void testSetOperationListWithBracketsIssue1737() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(SELECT z)\n", "         UNION ALL\n"), "         (SELECT z)\n"), "         ORDER BY z");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT z\n", "FROM (\n"), "         (SELECT z)\n"), "         UNION ALL\n"), "         (SELECT z)\n"), "         ORDER BY z\n"), "     )\n"), "ORDER BY z\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT z\n", "FROM (\n"), "         (SELECT z)\n"), "         UNION ALL\n"), "         (SELECT z)\n"), "         ORDER BY z\n"), "     )\n"), "GROUP BY z\n"), "ORDER BY z");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testNestedWithItems() {
string sqlStr = "with a as ( with b as ( with c as (select 1) select c.* from c) select b.* from b) select a.* from a";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect()!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems2 = parenthesedSelect.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems2), null);
global::DripSharp.Testing.JavaAssertions.Equal(" b", global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect2 = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(global::DripSharp.Runtime.JavaCompat.ListGet(withItems2, 0).getSelect()!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems3 = parenthesedSelect2.getSelect().getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems3), null);
global::DripSharp.Testing.JavaAssertions.Equal("(SELECT 1)", global::DripSharp.Runtime.JavaCompat.ListGet(withItems3, 0).getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" c", global::DripSharp.Runtime.JavaCompat.ListGet(withItems3, 0).getAlias().ToString(), null);
}

internal virtual void testSubSelectParsing() {
string sqlStr = "(SELECT id FROM table1 WHERE find_in_set(100, ancestors))";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression inExpression = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression();
inExpression.setLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("id"));
inExpression.setRightExpression(select);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat("id IN ", sqlStr), inExpression.ToString(), null);
}

internal virtual void testLateralView() {
string sqlStr1 = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM person\n", "    LATERAL VIEW EXPLODE(ARRAY(30, 60)) tableName AS c_age\n"), "    LATERAL VIEW EXPLODE(ARRAY(40, 80)) AS d_age");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr1, true)!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(select.getLateralViews()), null);
string sqlStr2 = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM person\n", "    LATERAL VIEW OUTER EXPLODE(ARRAY(30, 60)) AS c_age");
select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr2, true)!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(select.getLateralViews()), null);
global::DripSharp.SqlTrellis.Expression.Function function = new global::DripSharp.SqlTrellis.Expression.Function().withName("Explode").withParameters(new global::DripSharp.SqlTrellis.Expression.Function().withName("Array").withParameters(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(30)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(60))));
global::DripSharp.SqlTrellis.Statement.Select.LateralView lateralView1 = new global::DripSharp.SqlTrellis.Statement.Select.LateralView(true, function, (global::DripSharp.SqlTrellis.Expression.Alias)default!, new global::DripSharp.SqlTrellis.Expression.Alias("c_age", true));
select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("person")).addLateralView(lateralView1);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, sqlStr2, true);
global::DripSharp.SqlTrellis.Expression.Function function2 = new global::DripSharp.SqlTrellis.Expression.Function().withName("Explode").withParameters(new global::DripSharp.SqlTrellis.Expression.Function().withName("Array").withParameters(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(40)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(80))));
global::DripSharp.SqlTrellis.Statement.Select.LateralView lateralView2 = global::DripSharp.SqlTrellis.Tests.Support.DeepClone(lateralView1.withOuter(false).withTableAlias(new global::DripSharp.SqlTrellis.Expression.Alias("tableName"))).withOuter(false).withGeneratorFunction(function2).withTableAlias((global::DripSharp.SqlTrellis.Expression.Alias)default!).withColumnAlias(new global::DripSharp.SqlTrellis.Expression.Alias("d_age", true));
select.addLateralView(lateralView2);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, sqlStr1, true);
}

internal virtual void testOracleHavingBeforeGroupBy() {
string sqlStr = "SELECT id from a having count(*) > 1 group by id";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("count(*) > 1", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getHaving()), null);
global::DripSharp.Testing.JavaAssertions.Equal("GROUP BY id", select.getGroupBy().ToString(), null);
}

internal virtual void testParameterMultiPartName() {
string sqlStr = "SELECT 1 FROM dual WHERE a = :paramMap.aValue";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.Equal("paramMap.aValue", select.getWhere<global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo>(typeof(global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)).getRightExpression<global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter>(typeof(global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter)).getName(), null);
}

internal virtual void testInnerJoin() {
string sqlStr = "SELECT 1 from a inner join b on a.id=b.id";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Select.Join join = global::DripSharp.Runtime.JavaCompat.ListGet(select.getJoins(), 0);
global::DripSharp.Testing.JavaAssertions.True(join.isInnerJoin(), null);
global::DripSharp.Testing.JavaAssertions.True(join.withInner(false).isInnerJoin(), null);
global::DripSharp.Testing.JavaAssertions.False(join.withLeft(true).isInnerJoin(), null);
global::DripSharp.Testing.JavaAssertions.False(join.withRight(true).isInnerJoin(), null);
global::DripSharp.Testing.JavaAssertions.False(join.withInner(true).isRight(), null);
}

internal virtual void testArrayColumnsIssue1757() {
string sqlStr = "SELECT my_map['my_key'] FROM my_table WHERE id = 123";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT cast(my_map['my_key'] as int) FROM my_table WHERE id = 123";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testQualifyClauseIssue1805() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT i, p, o\n", "    FROM qt\n"), "    QUALIFY ROW_NUMBER() OVER (PARTITION BY p ORDER BY o) = 1");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testNotNullInFilter() {
string stmt = "SELECT count(*) FILTER (WHERE i NOTNULL) AS filtered FROM tasks";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testNotIsNullInFilter() {
string stmt = "SELECT count(*) FILTER (WHERE i NOT ISNULL) AS filtered FROM tasks";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

internal virtual void testBackSlashQuotationIssue1812() {
string sqlStr = "SELECT ('\\'', 'a')";
global::DripSharp.SqlTrellis.Statement.Statement stmt2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withBackslashEscapeCharacter(true));
sqlStr = "INSERT INTO recycle_record (a,f) VALUES ('\\'anything', 'abc');";
stmt2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withBackslashEscapeCharacter(true));
sqlStr = "INSERT INTO recycle_record (a,f) VALUES ('\\'','83653692186728700711687663398101');";
stmt2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withBackslashEscapeCharacter(true));
}

public virtual void testIssue1907() {
string stmt = "SELECT MAX(a, b, c), COUNT(*), D FROM tab1 GROUP BY D WITH ROLLUP";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
string stmt2 = "SELECT * FROM (SELECT year, person, SUM(amount) FROM rentals GROUP BY year, person) t1 ORDER BY year DESC WITH ROLLUP";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2);
}

public virtual void testIssue1908() {
string stmt = "SELECT * FROM ONLY sys_business_rule";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIssue1833() {
string stmt = "SELECT age, name, gender FROM user_info INTO TEMP user_temp WITH NO LOG";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

internal virtual void testGroupByWithHaving() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- GROUP BY\n", "SELECT  a\n"), "        , b\n"), "        , c\n"), "        , Sum( d )\n"), "FROM t\n"), "GROUP BY    a\n"), "            , b\n"), "            , c\n"), "HAVING Sum( d ) > 0\n"), "    AND Count( * ) > 1\n"), ";");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(stmt, null);
}

public virtual void testUnparenthesizedSubSelect(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withUnparenthesizedSubSelects(true));
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withUnparenthesizedSubSelects(false));
}, null);
}

public virtual void testPreferringClause(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
}

internal virtual void testInsertWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH inserted AS ( ", "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "   RETURNING y "), ") "), "SELECT y "), "  FROM inserted");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b RETURNING y", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testUpdateWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH updated AS ( ", "   UPDATE x "), "      SET foo = 1 "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "SELECT y "), "  FROM updated");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
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
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "SELECT y "), "  FROM deleted");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", delete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(delete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", delete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM deleted) "), "   RETURNING w "), ") "), "SELECT w "), "  FROM inserted");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
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
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH selection AS ( ", "   SELECT y "), "     FROM z "), "    WHERE foo = 'bar' "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM selection) "), "   RETURNING w "), ") "), "SELECT w "), "  FROM inserted");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = select.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect innerSelect = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect();
global::DripSharp.Testing.JavaAssertions.Equal("SELECT y FROM z WHERE foo = 'bar'", innerSelect.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" selection", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM selection)", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM selection) RETURNING w", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

public virtual void testSelectWithSkylineKeywords() {
string statement = "SELECT low, high, inverse, plus FROM mytable";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getPlainSelect().getFromItem()), null);
global::DripSharp.Testing.JavaAssertions.Equal("[low, high, inverse, plus]", global::DripSharp.Runtime.JavaCompat.StringValueOf(select.getPlainSelect().getSelectItems()), null);
}

public virtual void testSelectAllColumnsFromFunctionReturn() {
string sql = "SELECT (pg_stat_file('postgresql.conf')).*";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.NotNull(statement, null);
global::DripSharp.Testing.JavaAssertions.True((statement is global::DripSharp.SqlTrellis.Statement.Select.Select), null);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(statement!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select.getSelectBody()!);
global::DripSharp.Testing.JavaAssertions.NotNull(plainSelect, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getSelectItems()), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression() is global::DripSharp.SqlTrellis.Statement.Select.FunctionAllColumns), null);
global::DripSharp.Testing.JavaAssertions.Equal("(pg_stat_file('postgresql.conf')).*", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).ToString(), null);
}

public virtual void testSelectAllColumnsFromFunctionReturnWithMultipleParentheses() {
string sql = "SELECT ( ( ( pg_stat_file('postgresql.conf') ) )) . *";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.NotNull(statement, null);
global::DripSharp.Testing.JavaAssertions.True((statement is global::DripSharp.SqlTrellis.Statement.Select.Select), null);
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(statement!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select.getSelectBody()!);
global::DripSharp.Testing.JavaAssertions.NotNull(plainSelect, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getSelectItems()), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression() is global::DripSharp.SqlTrellis.Statement.Select.FunctionAllColumns), null);
global::DripSharp.Testing.JavaAssertions.Equal("(pg_stat_file('postgresql.conf')).*", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).ToString(), null);
}

[Xunit.Fact]
public void __Upstream_779a2a0191627e85()
{
        try
        {
            this.selectIsolationKeywordsAsAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4b67bf2839987352()
{
        try
        {
            this.selectWithSingleIn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dcaf5708f35fcfa9()
{
        try
        {
            this.testAdditionalLettersGerman();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e02cbd0c5dae32b()
{
        try
        {
            this.testAdditionalLettersSpanish();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7a57d91c6579a446()
{
        try
        {
            this.testAllColumnsFromTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5b4343f0b227ab07()
{
        try
        {
            this.testAllConditionSubSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f1ccffe42bc8c934()
{
        try
        {
            this.testAnalyticFunction12();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_82285f938bb3ca88()
{
        try
        {
            this.testAnalyticFunction13();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_da4a274bf5d8d644()
{
        try
        {
            this.testAnalyticFunction14();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cb3e23daf8683466()
{
        try
        {
            this.testAnalyticFunction15();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c774dc9f860a244d()
{
        try
        {
            this.testAnalyticFunction16();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_153def149b4439a1()
{
        try
        {
            this.testAnalyticFunction17();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1f1300f6a5598d7b()
{
        try
        {
            this.testAnalyticFunction18();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_53f43920173c41a9()
{
        try
        {
            this.testAnalyticFunction19();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_99acd8aa365b4954()
{
        try
        {
            this.testAnalyticFunctionFilterIssue866();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_def10d581d6ff59d()
{
        try
        {
            this.testAnalyticFunctionFilterIssue934();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_84da7223be587268()
{
        try
        {
            this.testAnalyticFunctionIssue670();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2fcc96b5af671d96()
{
        try
        {
            this.testAnalyticFunctionProblem1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4ce1efb1b7bb965c()
{
        try
        {
            this.testAnalyticFunctionProblem1b();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8d1ede55ed7787ef()
{
        try
        {
            this.testAnalyticPartitionBooleanExpressionIssue864();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab69accb06d7e5f9()
{
        try
        {
            this.testAnalyticPartitionBooleanExpressionIssue864_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_017752ca6fc29be1()
{
        try
        {
            this.testAndOperator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6cdb0723ab73eb08()
{
        try
        {
            this.testAnyComparisionExpressionValuesList1232();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2ed0478ae3f61f2()
{
        try
        {
            this.testAnyConditionSubSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81720679854c955d()
{
        try
        {
            this.testArrayColumnsIssue1757();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f31f73ec0fecc70c()
{
        try
        {
            this.testArrayDeclare();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_089c7b46d1672ff0()
{
        try
        {
            this.testArrayIssue377();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2e12554de21d3ae1()
{
        try
        {
            this.testArrayIssue378();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c4eebb8453a60e45()
{
        try
        {
            this.testArrayIssue489();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_947087cf9721a1f6()
{
        try
        {
            this.testArrayIssue638();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6b08a1bcb49b339c()
{
        try
        {
            this.testArrayIssue648();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_07713e6bf4658400()
{
        try
        {
            this.testArrayRange();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f1a3852a35e3795e()
{
        try
        {
            this.testBackSlashQuotationIssue1812();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6bc47fe46da5f172()
{
        try
        {
            this.testBetweenDate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2fc4187a0ce429b4()
{
        try
        {
            this.testBitwise();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b384181b0735b96e()
{
        try
        {
            this.testBooleanFunction1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c33038a03791d566()
{
        try
        {
            this.testBooleanValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8df876283751df4c()
{
        try
        {
            this.testBooleanValue2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39efbaf2444b4aa7()
{
        try
        {
            this.testBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_469c15880250e789()
{
        try
        {
            this.testBrackets2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_93b81de46bba7c41()
{
        try
        {
            this.testBrackets3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b2bdf3dbb0ee935c()
{
        try
        {
            this.testCanCallSubSelectOnWithItemEvenIfNotSetIssue1369();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c4bd5ca0c4a42145()
{
        try
        {
            this.testCase();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4f290059616997cd()
{
        try
        {
            this.testCaseElseAddition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8e7c675fbd16618a()
{
        try
        {
            this.testCaseElseExpressionIssue1375();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52961ecac66f7b79()
{
        try
        {
            this.testCaseKeyword();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_43cf8a896755162a()
{
        try
        {
            this.testCaseThenCondition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_00bcd1aeed0d974c()
{
        try
        {
            this.testCaseThenCondition2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_596cc7257cd0d03b()
{
        try
        {
            this.testCaseThenCondition3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bbb61fe24954cabb()
{
        try
        {
            this.testCaseThenCondition4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c481a7e7edf9e63()
{
        try
        {
            this.testCaseThenCondition5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_53939f65e6f8173f()
{
        try
        {
            this.testCaseWhenExpressionIssue200();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6c20d093adf4f2bc()
{
        try
        {
            this.testCaseWhenExpressionIssue262();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0882b55d025d6d20()
{
        try
        {
            this.testCaseWithComplexWhenExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab3a5d6cc07016fb()
{
        try
        {
            this.testCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10a0044a08274fd1()
{
        try
        {
            this.testCastInCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_90f14acf25f8384b()
{
        try
        {
            this.testCastInCast2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_31062a95f53ce76c()
{
        try
        {
            this.testCastToRowConstructorIssue1267();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b0d00dedf4c42537()
{
        try
        {
            this.testCastToSigned();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c043d98f22d3927e()
{
        try
        {
            this.testCastToSignedInteger();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9424d894043d245b()
{
        try
        {
            this.testCastTypeProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_766a8d3e48a0e7b7()
{
        try
        {
            this.testCastTypeProblem2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a389ef117a132f8()
{
        try
        {
            this.testCastTypeProblem3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a19b67f83d7df2cd()
{
        try
        {
            this.testCastTypeProblem4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a8ef5c257cfa1a5f()
{
        try
        {
            this.testCastTypeProblem5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_038558e25ecb4348()
{
        try
        {
            this.testCastTypeProblem6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4681628fdf48de3e()
{
        try
        {
            this.testCastTypeProblem7();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_71356accf86adbef()
{
        try
        {
            this.testCastTypeProblem8();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_833603433a197ad7()
{
        try
        {
            this.testCastVarCharMaxIssue245();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f00c2fe40bc0066f()
{
        try
        {
            this.testChainedFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3161c9a234c23637()
{
        try
        {
            this.testChangeKeywordIssue859();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7bf5bd7b7490fe21()
{
        try
        {
            this.testCharNotParsedIssue718();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c83f05bc77a2fc4f()
{
        try
        {
            this.testCharacterSetClause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_086bde37035b3d5b()
{
        try
        {
            this.testCheckColonVariable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_123907ffbd5b940f()
{
        try
        {
            this.testCheckDateFunctionIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9bef5806843f6f0d()
{
        try
        {
            this.testCheckDateFunctionIssue_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5a6fe8c58735501e()
{
        try
        {
            this.testCheckDateFunctionIssue_3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_93c2dca2afea899f()
{
        try
        {
            this.testCollateExprIssue164();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e513114ceb0c1d8()
{
        try
        {
            this.testCollisionWithSpecialStringFunctionsIssue1284();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6278e0a190eb0e95()
{
        try
        {
            this.testColonDelimiterIssue1134();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5a7a467b3b1f5a05()
{
        try
        {
            this.testComplexInExpressionIssue905();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f26c65fc18a5b7f3()
{
        try
        {
            this.testComplexInExpressionSimplyfied();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec60a3318b3e6014()
{
        try
        {
            this.testComplexUnion1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e429c8d350e4dce3()
{
        try
        {
            this.testConcat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f6b038b8d32b5170()
{
        try
        {
            this.testConcatProblem2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_69b2c4acf93cf5c4()
{
        try
        {
            this.testConcatProblem2_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9f48a64fdb4e18a1()
{
        try
        {
            this.testConcatProblem2_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ae3d731ebf579795()
{
        try
        {
            this.testConcatProblem2_3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_66137e137b005003()
{
        try
        {
            this.testConcatProblem2_4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ad4017a877c0177a()
{
        try
        {
            this.testConcatProblem2_5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_259317bc4ef7e650()
{
        try
        {
            this.testConcatProblem2_5_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_acb4c09df007f136()
{
        try
        {
            this.testConcatProblem2_5_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d93cf2db0f6a48ac()
{
        try
        {
            this.testConcatProblem2_6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_97ffdc02c2e08d45()
{
        try
        {
            this.testConditionalParametersForFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c4a47abe7fa145e()
{
        try
        {
            this.testConditionsWithExtraBrackets_Issue1194();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c61b9bc4528999ca()
{
        try
        {
            this.testConnectByRootIssue1255();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ff8d47d05c97ad44()
{
        try
        {
            this.testContionItemsSelectedIssue1077();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_36ef82d1d57e19c5()
{
        try
        {
            this.testCount2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_96613e4d64614be0()
{
        try
        {
            this.testCount3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52019b4ee457a4a8()
{
        try
        {
            this.testCreateTableWithParameterDefaultFalseIssue1088();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_521ca418e24f86f9()
{
        try
        {
            this.testCrossApplyIssue344();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d64f1cd1d8e1984()
{
        try
        {
            this.testCurrentIssue940();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_57aebf5be439de80()
{
        try
        {
            this.testDB2SpecialRegisterDateTimeIssue1249();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d0e214a1e31a1dfe()
{
        try
        {
            this.testDateArithmentic();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf0fe210a2d16e50()
{
        try
        {
            this.testDateArithmentic10();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c0708b60c2afe862()
{
        try
        {
            this.testDateArithmentic11();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8dfeb967ec6d72a7()
{
        try
        {
            this.testDateArithmentic12();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f41c4fca7b252894()
{
        try
        {
            this.testDateArithmentic13();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_27f042c3903073d9()
{
        try
        {
            this.testDateArithmentic2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_92b613e97203023c()
{
        try
        {
            this.testDateArithmentic3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a43657238ef3b134()
{
        try
        {
            this.testDateArithmentic4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c122b3e0cb47cf2a()
{
        try
        {
            this.testDateArithmentic5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab67bc1877487973()
{
        try
        {
            this.testDateArithmentic6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c62ad34ea0e9d825()
{
        try
        {
            this.testDateArithmentic7();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c078f4b0f9d03ab3()
{
        try
        {
            this.testDateArithmentic8();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f65a48bf506fa1f()
{
        try
        {
            this.testDateArithmentic9();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2519499576273375()
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
public void __Upstream_6a869c0c87c9db3e()
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
public void __Upstream_449462fd638fd054()
{
        try
        {
            this.testDeparser();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9b2583d2a5a2755()
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
public void __Upstream_0f893a94427cf52f()
{
        try
        {
            this.testDistinctTop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a671b35ba8f71acf()
{
        try
        {
            this.testDistinctTop2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a464e6bf7276567()
{
        try
        {
            this.testDistinctWithFollowingBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_509e5653c7bad9d0()
{
        try
        {
            this.testDouble();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5f9e12f5a4c38597()
{
        try
        {
            this.testDouble2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_89bd9ac94980e3f8()
{
        try
        {
            this.testDouble3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_02f3e8cb6c5dd704()
{
        try
        {
            this.testDouble4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2a9b512023b5f98c()
{
        try
        {
            this.testEmptyDoubleQuotes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_970182cfc6ea71eb()
{
        try
        {
            this.testEmptyDoubleQuotes_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8e52658282b25106()
{
        try
        {
            this.testEndKeyword();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9b6cafa206a6f329()
{
        try
        {
            this.testEscaped();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_daa950cd89151ac0()
{
        try
        {
            this.testEscapedBackslashIssue253();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4378829e142ccb42()
{
        try
        {
            this.testEscapedFunctionsIssue647();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aae54835ca0b57c4()
{
        try
        {
            this.testEscapedFunctionsIssue753();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e8c33b82ab104dd0()
{
        try
        {
            this.testExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_57d9f1732f482867()
{
        try
        {
            this.testExistsKeywordIssue1076();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ff6c9f0895b8a3c8()
{
        try
        {
            this.testExistsKeywordIssue1076_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9966e1ae2cec1bcd()
{
        try
        {
            this.testExpressionsInCaseBeforeWhen();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_e117295306da938b()
{
        try
        {
            this.testExpressionsInIntervalExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f383b4ed637faf68()
{
        try
        {
            this.testExtractFrom1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ffa64738325e9dce()
{
        try
        {
            this.testExtractFrom2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_637e06a55fadee23()
{
        try
        {
            this.testExtractFrom3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f20c5dccf283d23c()
{
        try
        {
            this.testExtractFrom4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fdfd8761e5a63267()
{
        try
        {
            this.testFirst();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f78013931c165f2a()
{
        try
        {
            this.testFirstWithKeywordLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_173915ceeef9ebec()
{
        try
        {
            this.testForUpdateNoWait();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_16e360e2101f63a0()
{
        try
        {
            this.testForUpdateWaitParseDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9fa681ba2cc77595()
{
        try
        {
            this.testForUpdateWaitWithTimeout();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_02af04baff7c9bfd()
{
        try
        {
            this.testForXmlPath();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_491734975c7c84ce()
{
        try
        {
            this.testFormatKeywordIssue1078();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_73ad1455d67bf237()
{
        try
        {
            this.testFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fcbd732a9905c479()
{
        try
        {
            this.testFullTextSearchInDefaultMode();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_699b3a604390f914()
{
        try
        {
            this.testFuncConditionParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2733a5060fe62a25()
{
        try
        {
            this.testFuncConditionParameter2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c44d2ad02f88e70b()
{
        try
        {
            this.testFuncConditionParameter3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51581c087af5edef()
{
        try
        {
            this.testFuncConditionParameter4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c7120d56c638849b()
{
        try
        {
            this.testFunctionComplexExpressionParametersIssue1644();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cd0a0ddddb758141()
{
        try
        {
            this.testFunctionDateTimeValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b3eebf356cf50467()
{
        try
        {
            this.testFunctionIssue284();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_77ff9bc6b84e64ee()
{
        try
        {
            this.testFunctionLeft();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7bbffbdbc8c43322()
{
        try
        {
            this.testFunctionOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dd76d6e4ecb33011()
{
        try
        {
            this.testFunctionRight();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1319de6ffc219c32()
{
        try
        {
            this.testFunctionWithComplexParameters_Issue1190();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ed37a4b7ad4f19f8()
{
        try
        {
            this.testFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ef2c3c504c087bf()
{
        try
        {
            this.testGeometryDistance();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5568d3cf62e2336e()
{
        try
        {
            this.testGroupBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_34f442eabe67bc8b()
{
        try
        {
            this.testGroupByComplexExpressionIssue1308();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fc85e52b3d6c414b()
{
        try
        {
            this.testGroupByExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_beba4cf4ed922277()
{
        try
        {
            this.testGroupByProblemIssue482();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_83b0388d3a18b419()
{
        try
        {
            this.testGroupByWithAllTableColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_afd554241a29947a()
{
        try
        {
            this.testGroupByWithHaving();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_991003fbee27f2bd()
{
        try
        {
            this.testGroupConcat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dcd05ce973faf2e5()
{
        try
        {
            this.testGroupedByIssue1176();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_854b06d666095964()
{
        try
        {
            this.testGroupedByWithExtraBracketsIssue1168();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_649070aaf0446817()
{
        try
        {
            this.testGroupedByWithExtraBracketsIssue1210();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dbe064a64b6da7d3()
{
        try
        {
            this.testGroupingSets1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_995d7c2a5b832a1f()
{
        try
        {
            this.testGroupingSets2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_772ae96f7924fdac()
{
        try
        {
            this.testGroupingSets3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_170c9acc37752473()
{
        try
        {
            this.testH2CaseWhenFunctionIssue1091();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fe4117427c351c38()
{
        try
        {
            this.testHaving();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f29fe277c66164eb()
{
        try
        {
            this.testIgnoreNullsForWindowFunctionsIssue1429();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_67fd4084b3ce8279()
{
        try
        {
            this.testIlike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c0bcc2d8b6b48d54()
{
        try
        {
            this.testInnerJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b2460076e370d59e()
{
        try
        {
            this.testInnerWithBlock();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1b473baf09408f51()
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
public void __Upstream_eb9eef5ea416dc2f()
{
        try
        {
            this.testIntegerDivOperator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_12eaae5465f6cb03()
{
        try
        {
            this.testInterval1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_496842473109e5fd()
{
        try
        {
            this.testInterval2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9abc8b5060512a30()
{
        try
        {
            this.testInterval3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f613371f0a1027d3()
{
        try
        {
            this.testInterval4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d38b62d74c1a88a9()
{
        try
        {
            this.testInterval5_Issue228();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0dd556c9206a01c1()
{
        try
        {
            this.testIntervalWithColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d225bf226d65ffdc()
{
        try
        {
            this.testIntervalWithFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3473b136c2a007dc()
{
        try
        {
            this.testIsDistinctFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_255aa3b307c0e2ed()
{
        try
        {
            this.testIsFalse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eaf29e18b87edec6()
{
        try
        {
            this.testIsNot();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab834eb62e34ddf7()
{
        try
        {
            this.testIsNot2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_64fa189422d7946f()
{
        try
        {
            this.testIsNotDistinctFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab0715abe12d94a3()
{
        try
        {
            this.testIsNotFalse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b8fc5c78ea55a0ca()
{
        try
        {
            this.testIsNotTrue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eaa3a468deb630c5()
{
        try
        {
            this.testIsNotUnknown();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_98fbaf9b2d60fc61()
{
        try
        {
            this.testIsTrue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6b97aab59b0e6106()
{
        try
        {
            this.testIsUnknown();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ae76e01877940ec4()
{
        try
        {
            this.testIssue1062();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5eeaca7d733b6340()
{
        try
        {
            this.testIssue1062_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_679912d8f5f566ba()
{
        try
        {
            this.testIssue1068();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ce455ed6760691af()
{
        try
        {
            this.testIssue151_tableFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8000eefeade8cc9b()
{
        try
        {
            this.testIssue154();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_871b04bd72cc32b8()
{
        try
        {
            this.testIssue154_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1b70ed2500e8aa9e()
{
        try
        {
            this.testIssue1595();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cfd2f14b98842c69()
{
        try
        {
            this.testIssue160_signedParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9af6f723488728df()
{
        try
        {
            this.testIssue160_signedParameter2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_389841184cc1595b()
{
        try
        {
            this.testIssue162_doubleUserVar();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("SELECT 'a'")]
[Xunit.InlineData("SELECT ''''")]
[Xunit.InlineData("SELECT '\\''")]
[Xunit.InlineData("SELECT 'ab''ab'")]
[Xunit.InlineData("SELECT 'ab\\'ab'")]
public void __Upstream_7ff157fd1c98d0a1(string sqlStr)
{
        try
        {
            this.testIssue167_singleQuoteEscape(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("SELECT '\\'\\''")]
[Xunit.InlineData("SELECT '\\\\\\''")]
public void __Upstream_1848d2af52ca686f(string sqlStr)
{
        try
        {
            this.testIssue167_singleQuoteEscape2(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3aaf2b5d3d65e23e()
{
        try
        {
            this.testIssue1833();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dcbe512035a6a100()
{
        try
        {
            this.testIssue1878();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7bb9f18e7de5d7bd()
{
        try
        {
            this.testIssue1878ViaJava();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a5881db004414efe()
{
        try
        {
            this.testIssue1907();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a9711f7facba6c0c()
{
        try
        {
            this.testIssue1908();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4fb5503c94d70fa0()
{
        try
        {
            this.testIssue215_possibleEndlessParsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5e34bbe92f6bbee2()
{
        try
        {
            this.testIssue215_possibleEndlessParsing2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_03f53504640142d4()
{
        try
        {
            this.testIssue215_possibleEndlessParsing3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44d090b3bb760fc0()
{
        try
        {
            this.testIssue215_possibleEndlessParsing4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aa128c9d454b67dc()
{
        try
        {
            this.testIssue215_possibleEndlessParsing5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6c9c80df316732ff()
{
        try
        {
            this.testIssue215_possibleEndlessParsing6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f1a7d4407622bce0()
{
        try
        {
            this.testIssue215_possibleEndlessParsing7();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c73483aaae7ecbb9()
{
        try
        {
            this.testIssue217_keywordSeparator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dbab597e6c598b1c()
{
        try
        {
            this.testIssue223_singleQuoteEscape();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e02b8d70e52dceb7()
{
        try
        {
            this.testIssue230_cascadeKeyword();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_077a03949b703d12()
{
        try
        {
            this.testIssue235SimplifiedCase3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_177f21d2bac28f8d()
{
        try
        {
            this.testIssue235SimplifiedCase4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b9993fb09740b3f()
{
        try
        {
            this.testIssue266KeywordTop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e845ef73f7493d3e()
{
        try
        {
            this.testIssue371SimplifiedCase();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c35986fd1e62406()
{
        try
        {
            this.testIssue371SimplifiedCase2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e9263ec01a93da15()
{
        try
        {
            this.testIssue508LeftRightBitwiseShift();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ff7a29e8f3f17286()
{
        try
        {
            this.testIssue512();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_26324a1fe2214067()
{
        try
        {
            this.testIssue512_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ccd34279d2c59493()
{
        try
        {
            this.testIssue514();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d78eda2326e22fb6()
{
        try
        {
            this.testIssue522();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b71065f084179113()
{
        try
        {
            this.testIssue522_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f7e91bcd7fa18c4d()
{
        try
        {
            this.testIssue522_3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_01f4aad68eb8d7c6()
{
        try
        {
            this.testIssue522_4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_abe07bea3927f54a()
{
        try
        {
            this.testIssue554();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2f57487f269618a2()
{
        try
        {
            this.testIssue563MultiSubJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3e7ec55fdc1b2a88()
{
        try
        {
            this.testIssue563MultiSubJoin_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_00561121c7627617()
{
        try
        {
            this.testIssue566LargeView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a40566dc0f38dba8()
{
        try
        {
            this.testIssue566PostgreSQLEscaped();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_794d3f80bb701c0c()
{
        try
        {
            this.testIssue567KeywordPrimary();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bd783eb75dc8b6ac()
{
        try
        {
            this.testIssue572TaskReplacement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_83acde0c71504b09()
{
        try
        {
            this.testIssue582NumericConstants();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f8a2545d5f185cc()
{
        try
        {
            this.testIssue583CharacterLiteralAsAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_22340e0eb26f9f92()
{
        try
        {
            this.testIssue584MySQLValueListExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c97e4b2c0c96a24a()
{
        try
        {
            this.testIssue588NotNull();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_173b8a1fdcc410c6()
{
        try
        {
            this.testIssue699();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4d07d06ce532df5c()
{
        try
        {
            this.testIssue77_singleQuoteEscape2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e4fbbe26256024fb()
{
        try
        {
            this.testIssue842();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0b47f4b7c8943ccc()
{
        try
        {
            this.testIssue842_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2925d2eace0e8717()
{
        try
        {
            this.testIssue848();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ac9abece7ff11c1()
{
        try
        {
            this.testIssue848_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8dde84d54baa7da5()
{
        try
        {
            this.testIssue848_3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ee1184e54eef522b()
{
        try
        {
            this.testIssue848_4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aa2dec739a34a70f()
{
        try
        {
            this.testIssue862CaseWhenConcat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aef3826d0b2dc022()
{
        try
        {
            this.testJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5e664dd96f99424d()
{
        try
        {
            this.testJoinWithTrailingOnExpressionIssue1302();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44ed504e1df3cefa()
{
        try
        {
            this.testJoinerExpressionIssue596();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f5d31df9e918d63()
{
        try
        {
            this.testJsonExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0add5bdccd883579()
{
        try
        {
            this.testJsonExpressionWithCastExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9b80bdb02b267f8e()
{
        try
        {
            this.testJsonExpressionWithIntegerParameterIssue909();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c3c0e9ffe84131a0()
{
        try
        {
            this.testKeyWordCreateIssue941();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_35a04f5ad0b64739()
{
        try
        {
            this.testKeyWordCreateIssue941_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_427e17c5e16b872d()
{
        try
        {
            this.testKeyWordExceptIssue1026();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bb9c39c0dca80fd4()
{
        try
        {
            this.testKeyWordExceptIssue1040();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bdb307da46c809c8()
{
        try
        {
            this.testKeyWordExceptIssue1044();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f74f4a9dd28b6670()
{
        try
        {
            this.testKeyWordExceptIssue1055();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_11857574b300d521()
{
        try
        {
            this.testKeyWordExceptIssue1055_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b7e147921af0a6db()
{
        try
        {
            this.testKeyWordOfIssue1029();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b14daff2182d8540()
{
        try
        {
            this.testKeyWordView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_960006041b985407()
{
        try
        {
            this.testKeyWorkInsertIssue393();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a0993110314906ff()
{
        try
        {
            this.testKeyWorkReplaceIssue393();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c90f50299a3e3ad7()
{
        try
        {
            this.testKeywordAlgorithmIssue1137();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fcb36d37cc0bbd0c()
{
        try
        {
            this.testKeywordAlgorithmIssue1138();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec98b9014c06dcef()
{
        try
        {
            this.testKeywordAtIssue1414();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_447a772ec282f169()
{
        try
        {
            this.testKeywordCharacterIssue884();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a6dd7feb3961378()
{
        try
        {
            this.testKeywordCostsIssue1185();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0c507d4bdeca7c18()
{
        try
        {
            this.testKeywordDuplicate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5943caa13676a959()
{
        try
        {
            this.testKeywordDuplicate2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81cf71ebf3371bbf()
{
        try
        {
            this.testKeywordFilterIssue1255();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_79619f804b5bca68()
{
        try
        {
            this.testKeywordSequenceIssue1074();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e1ad3b5387979570()
{
        try
        {
            this.testKeywordSequenceIssue1075();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_88e605947d184f00()
{
        try
        {
            this.testKeywordSizeIssue880();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_98c4bf616f46d966()
{
        try
        {
            this.testKeywordSkipIssue1136();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2619f1e83ec7b96a()
{
        try
        {
            this.testKeywordSynonymIssue1211();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_adb12acb68568e60()
{
        try
        {
            this.testKeywordTableIssue261();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6e9863fd5d26d74b()
{
        try
        {
            this.testKeywordUnsignedIssue961();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e6d9fa8c2c598b44()
{
        try
        {
            this.testLateral1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_62b9a21bc064e04b()
{
        try
        {
            this.testLateralComplex1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1f81273789a8c809()
{
        try
        {
            this.testLateralView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9b122b89d8435c68()
{
        try
        {
            this.testLike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4e69594aa96a7a2d()
{
        try
        {
            this.testLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c8f8161397926db()
{
        try
        {
            this.testLimit2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_159ed2beaeacf1c9()
{
        try
        {
            this.testLimit3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7ecac0071b701bbf()
{
        try
        {
            this.testLimit4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10c392e2c72d193a()
{
        try
        {
            this.testLimitClauseDroppedIssue845();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ffde93113049ae99()
{
        try
        {
            this.testLimitClauseDroppedIssue845_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3255f4337c0af641()
{
        try
        {
            this.testLimitOffsetIssue462();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2450ba18a78c40bf()
{
        try
        {
            this.testLimitOffsetIssue462_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fa9cde7716a14032()
{
        try
        {
            this.testLimitOffsetKeyWordAsNamedParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e9364a2cd0c031ed()
{
        try
        {
            this.testLimitOffsetKeyWordAsNamedParameter2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_217f671c6952c1d5()
{
        try
        {
            this.testLimitPR404();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aabef8921214df32()
{
        try
        {
            this.testLimitSqlServer1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_60d3a69e656ca7f2()
{
        try
        {
            this.testLimitSqlServer2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_541ab892d16cc99d()
{
        try
        {
            this.testLimitSqlServer3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2a18fe754b57a314()
{
        try
        {
            this.testLimitSqlServer4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ed3a0eacd7dd8cd1()
{
        try
        {
            this.testLimitSqlServerJdbcParameters();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_97accbd6547e585f()
{
        try
        {
            this.testLoclTimezone1471();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d83c527f9a13902a()
{
        try
        {
            this.testLogicalExpressionSelectItemIssue1381();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b3a2678a988dfed()
{
        try
        {
            this.testLongQualifiedNamesIssue763();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d71ffa80c2ebeaca()
{
        try
        {
            this.testMatches();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c1bd06a5aca2c438()
{
        try
        {
            this.testMissingBracketsNestedInIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d0277a387511f644()
{
        try
        {
            this.testMissingLimitIssue1505();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8d21a461dd8259f8()
{
        try
        {
            this.testMissingLimitKeywordIssue1006();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c4e86ed056690a76()
{
        try
        {
            this.testMissingOffsetIssue620();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_de43e120bf00742e()
{
        try
        {
            this.testMultiColumnAliasIssue849();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c165a1ffc4cf70be()
{
        try
        {
            this.testMultiColumnAliasIssue849_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec16605bdc5aa2a7()
{
        try
        {
            this.testMultiPartColumnName();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_891540f2b4d9a0c8()
{
        try
        {
            this.testMultiPartColumnNameWithDatabaseName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b778bb13b1fb2bbd()
{
        try
        {
            this.testMultiPartColumnNameWithDatabaseNameAndSchemaName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f37688399abb0059()
{
        try
        {
            this.testMultiPartColumnNameWithDatabaseNameAndSchemaNameAndTableName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dd6ed0525981e749()
{
        try
        {
            this.testMultiPartColumnNameWithDatabaseNameAndTableName();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_88a51a4e9e6c34e0()
{
        try
        {
            this.testMultiPartColumnNameWithSchemaName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2fb0f5c3cee9a911()
{
        try
        {
            this.testMultiPartColumnNameWithSchemaNameAndTableName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_15721875f9a64f4a()
{
        try
        {
            this.testMultiPartColumnNameWithTableName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_af5a5945aa7256e1()
{
        try
        {
            this.testMultiPartNames1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5391bd52f016cc92()
{
        try
        {
            this.testMultiPartNames2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6cdf1e5e24590ef1()
{
        try
        {
            this.testMultiPartNames3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0c3992fff3c77ae8()
{
        try
        {
            this.testMultiPartNames4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a80973200060a025()
{
        try
        {
            this.testMultiPartNames5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6905e4e047760233()
{
        try
        {
            this.testMultiPartNamesForFunctionsIssue944();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3e32dddf7cd3b686()
{
        try
        {
            this.testMultiPartNamesIssue163();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_059a3cc1a03683d0()
{
        try
        {
            this.testMultiPartNamesIssue608();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bc7735e1d6f7eafd()
{
        try
        {
            this.testMultiPartNamesIssue643();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_687bbbbe49654d97()
{
        try
        {
            this.testMultiPartTableNameWithColumnName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a7176c63b7ac64a2()
{
        try
        {
            this.testMultiPartTableNameWithDatabaseName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_766b4f137d9e4e80()
{
        try
        {
            this.testMultiPartTableNameWithDatabaseNameAndSchemaName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e0f5c5f2082374d9()
{
        try
        {
            this.testMultiPartTableNameWithSchemaName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f09c16d12f3b9081()
{
        try
        {
            this.testMultiPartTableNameWithServerName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_651680cdac91b995()
{
        try
        {
            this.testMultiPartTableNameWithServerNameAndDatabaseName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_68d44dce8b992051()
{
        try
        {
            this.testMultiPartTableNameWithServerNameAndDatabaseNameAndSchemaName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cd10e0ada6f3d80b()
{
        try
        {
            this.testMultiPartTableNameWithServerNameAndSchemaName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ad91b288af431be4()
{
        try
        {
            this.testMultiPartTableNameWithServerProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8f39b39c073d7ecb()
{
        try
        {
            this.testMultiPartTypesIssue992();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b689e1e0478b5c5e()
{
        try
        {
            this.testMultiTableJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d33aad5a52be6b56()
{
        try
        {
            this.testMultiValueIn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f319ed6c2ee9c9ad()
{
        try
        {
            this.testMultiValueIn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f91eb07e57b9ab6()
{
        try
        {
            this.testMultiValueIn3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8cb205401843f487()
{
        try
        {
            this.testMultiValueIn4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aff14a0798277156()
{
        try
        {
            this.testMultiValueInBinds();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9bcb40930bc1e367()
{
        try
        {
            this.testMultiValueIn_NTuples();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec4a548776e57898()
{
        try
        {
            this.testMultiValueIn_withAnd();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c57cf64e6cf1ee36()
{
        try
        {
            this.testMultiValueNotInBinds();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e9c9e683ab9039fd()
{
        try
        {
            this.testMySQLHintStraightJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0cc4ae82bbe7b8da()
{
        try
        {
            this.testMysqlIndexHints();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f59c6b0fd36698cd()
{
        try
        {
            this.testMysqlIndexHintsWithJoins();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b0a8c3860f4f414e()
{
        try
        {
            this.testMysqlMultipleIndexHints();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9c559e14cc52d78()
{
        try
        {
            this.testMysqlQuote();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5cbdd374b8216112()
{
        try
        {
            this.testNamedParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b03fe7f3e528ec74()
{
        try
        {
            this.testNamedParameter2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3a993e533d1cebb1()
{
        try
        {
            this.testNamedParameter3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_02e57f53e64d0dc6()
{
        try
        {
            this.testNamedParametersIssue612();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d6402e2e18d10c6b()
{
        try
        {
            this.testNamedParametersPR702();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2192bb2436660e5b()
{
        try
        {
            this.testNamedParametersPR702_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_34380e0cc66e1342()
{
        try
        {
            this.testNamedWindowDefinitionIssue1581();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c2bcd3dccbcc232()
{
        try
        {
            this.testNamedWindowDefinitionIssue1581_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_18f9b6f63a603298()
{
        try
        {
            this.testNestedCaseComplexExpressionIssue1306();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_91720320ff9d32e4()
{
        try
        {
            this.testNestedCaseCondition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7c90bff74a190d5e()
{
        try
        {
            this.testNestedCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7707d2d8cb0d954d()
{
        try
        {
            this.testNestedFunctionCallIssue253();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_14333148b8a198b7()
{
        try
        {
            this.testNestedWithItems();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0db2821a846dbaf9()
{
        try
        {
            this.testNotEqualsTo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0969a3bd7ebb47a1()
{
        try
        {
            this.testNotExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_31442698dae3ad91()
{
        try
        {
            this.testNotExistsIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9fb2b1c9114eeffa()
{
        try
        {
            this.testNotIsNullInFilter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_df4875df4b079ba7()
{
        try
        {
            this.testNotLike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ccd5e55434d018f()
{
        try
        {
            this.testNotLikeIssue775();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fbdd24934ae81590()
{
        try
        {
            this.testNotLikeWithNotBeforeExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8f77b9920968726()
{
        try
        {
            this.testNotNotIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44a2cef8c8df757c()
{
        try
        {
            this.testNotNullInFilter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52d00187520da718()
{
        try
        {
            this.testNotProblem1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f1505353caf56d98()
{
        try
        {
            this.testNotProblem2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_27a50ae071e22c2a()
{
        try
        {
            this.testNotProblemIssue721();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_671a170e4bd14a88()
{
        try
        {
            this.testNotRegexpMySQLIssue887();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_245014d2ca4cefb3()
{
        try
        {
            this.testNotRegexpMySQLIssue887_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_563bdfb7daaa2e72()
{
        try
        {
            this.testNotVariant();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_68c27c58d0de85b0()
{
        try
        {
            this.testNotVariant2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e18f6c33d9609b9d()
{
        try
        {
            this.testNotVariant3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_96ade5254f9e8c03()
{
        try
        {
            this.testNotVariant4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9843efb576b49c84()
{
        try
        {
            this.testNotVariantIssue850();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_77c633d3a710f299()
{
        try
        {
            this.testNotWithoutParenthesisIssue234();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_73fb06f2c37d5f20()
{
        try
        {
            this.testOneColumnFullTextSearchMySQL();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_207fcd49ee14ee5b()
{
        try
        {
            this.testOperationsWithSigns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7c330eacd65dc096()
{
        try
        {
            this.testOptimizeForIssue348();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2fcbaade306f57d1()
{
        try
        {
            this.testOracleDBLink();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_141619a1e428df72()
{
        try
        {
            this.testOracleHavingBeforeGroupBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ebc7891bca8da853()
{
        try
        {
            this.testOracleHierarchicalQuery();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_24338957707c0875()
{
        try
        {
            this.testOracleHierarchicalQuery2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_48dd8e9276924d0b()
{
        try
        {
            this.testOracleHierarchicalQuery3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_817d6e4555330387()
{
        try
        {
            this.testOracleHierarchicalQuery4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b086886008aa4178()
{
        try
        {
            this.testOracleHierarchicalQueryIssue196();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c1b6656dac89f878()
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
public void __Upstream_fcd0f2f163ab1e04()
{
        try
        {
            this.testOracleHintExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_699fb614609d4ff6()
{
        try
        {
            this.testOracleJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1505a52126e20f83()
{
        try
        {
            this.testOracleJoin2();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("(+)")]
[Xunit.InlineData("( +)")]
[Xunit.InlineData("(+ )")]
[Xunit.InlineData("( + )")]
[Xunit.InlineData(" (+) ")]
public void __Upstream_577fef4addb98820(string value)
{
        try
        {
            this.testOracleJoin2_1(value);
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("(+)")]
[Xunit.InlineData("( +)")]
[Xunit.InlineData("(+ )")]
[Xunit.InlineData("( + )")]
[Xunit.InlineData(" (+) ")]
public void __Upstream_c1d3100687f3653a(string value)
{
        try
        {
            this.testOracleJoin2_2(value);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7173a1e5bd505f80()
{
        try
        {
            this.testOracleJoin3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8bb85c3d70cd1542()
{
        try
        {
            this.testOracleJoin3_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8001d8ddd25070c1()
{
        try
        {
            this.testOracleJoin4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_845be600da0aef66()
{
        try
        {
            this.testOracleJoinIssue318();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ba88f872e36a2fe()
{
        try
        {
            this.testOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_63a441b6c76174f5()
{
        try
        {
            this.testOrderByNullsFirst();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_555d2ce7350804a1()
{
        try
        {
            this.testOrderByWithComplexExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f6cb37584e809f3()
{
        try
        {
            this.testOrderKeywordIssue932();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8a5f6a933decfbbe()
{
        try
        {
            this.testOrderKeywordIssue932_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6f4ccb72318065c4()
{
        try
        {
            this.testOuterApplyIssue930();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_93e21168327bae4e()
{
        try
        {
            this.testPR73();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b38f90ddb7087cd0()
{
        try
        {
            this.testParameterMultiPartName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_23e76c8f10ac2726()
{
        try
        {
            this.testParenthesisAroundFromItem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ae65f0165d826cb()
{
        try
        {
            this.testParenthesisAroundFromItem2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3437c77a83fc63db()
{
        try
        {
            this.testParenthesisAroundFromItem3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e676b2128b4f275()
{
        try
        {
            this.testPartitionByWithBracketsIssue865();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_75b62e0b120a8adb()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testPerformanceIssue1397(), 1000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9abd8a111ef72bb4()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testPerformanceIssue1438(), 1000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_689e1f5a48ab9415()
{
        try
        {
            this.testPivot1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3cc43c7b98a9a2cf()
{
        try
        {
            this.testPivot2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1d1ebc715c816792()
{
        try
        {
            this.testPivot3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_008dd1ae52c072b9()
{
        try
        {
            this.testPivot4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50648ec1368fb208()
{
        try
        {
            this.testPivot5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8d0900a60f6a3cbb()
{
        try
        {
            this.testPivotFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a0bc45547960eb5c()
{
        try
        {
            this.testPivotWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d639c552b0455427()
{
        try
        {
            this.testPivotWithAlias2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec6d374db04623ca()
{
        try
        {
            this.testPivotWithAlias3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5a3861364f05fa1d()
{
        try
        {
            this.testPivotWithAlias4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7dcc2b8f37791799()
{
        try
        {
            this.testPivotWithOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_76955b072e89e0f6()
{
        try
        {
            this.testPivotXml1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1da2f8dfffb8705c()
{
        try
        {
            this.testPivotXml2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b47cca8ebfe63a07()
{
        try
        {
            this.testPivotXml3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c32963b2d5cd082()
{
        try
        {
            this.testPivotXmlSubquery1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39a6986858ac6ee4()
{
        try
        {
            this.testPostgreSQLRegExpCaseSensitiveMatch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b6aa113f52f1253()
{
        try
        {
            this.testPostgreSQLRegExpCaseSensitiveMatch2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4be4fa5b21c7c07a()
{
        try
        {
            this.testPostgreSQLRegExpCaseSensitiveMatch3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c574ae0568b831db()
{
        try
        {
            this.testPostgreSQLRegExpCaseSensitiveMatch4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81a5475113fc4a89()
{
        try
        {
            this.testPostgresDollarQuotes_1372();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ca4ebbb99ad8b75f()
{
        try
        {
            this.testPostgresNaturalJoinIssue1559();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING HIGH mycolumn")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING LOW mycolumn")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING 1 = 1")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING (HIGH mycolumn)")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING INVERSE (HIGH mycolumn)")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING HIGH mycolumn1 PRIOR TO LOW mycolumn2")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING HIGH mycolumn1 PLUS LOW mycolumn2")]
[Xunit.InlineData("SELECT * FROM mytable PREFERRING HIGH mycolumn PARTITION BY mycolumn")]
public void __Upstream_e8303f59b06de07c(string sqlStr)
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
public void __Upstream_6eb7e34b9fb53d52()
{
        try
        {
            this.testPreserveAndOperator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7e7d2ac1206c7b84()
{
        try
        {
            this.testPreserveAndOperator_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_09fae3136b1bbfff()
{
        try
        {
            this.testProblemFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_76c5bb8b8cd0be05()
{
        try
        {
            this.testProblemFunction2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1468a2799162ad69()
{
        try
        {
            this.testProblemFunction3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a8a02a5b78a3d5d()
{
        try
        {
            this.testProblemInNotInProblemIssue379();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c92b962b025be5b()
{
        try
        {
            this.testProblemIsIssue331();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cb373f1ce304db2b()
{
        try
        {
            this.testProblemIssue375();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ad800cbc03ad78a()
{
        try
        {
            this.testProblemIssue375Simplified();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_561c94d1f552cfed()
{
        try
        {
            this.testProblemIssue375Simplified2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d5fc8e857f8236b0()
{
        try
        {
            this.testProblemIssue435();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9bc96606c38d3996()
{
        try
        {
            this.testProblemIssue437Index();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0ab7496fd743f822()
{
        try
        {
            this.testProblemIssue445();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2cf14f6e5dc34fd3()
{
        try
        {
            this.testProblemIssue485Date();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_269922a31340d4e8()
{
        try
        {
            this.testProblemKeywordCommitIssue341();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_852158cd09cfa828()
{
        try
        {
            this.testProblemLargeNumbersIssue390();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_596cad6fe6b65967()
{
        try
        {
            this.testProblemSqlAnalytic();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d8f99d266101e32d()
{
        try
        {
            this.testProblemSqlAnalytic10Lag();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4202b3e05da3aa2c()
{
        try
        {
            this.testProblemSqlAnalytic11Lag();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8cfb86168d5ba3df()
{
        try
        {
            this.testProblemSqlAnalytic2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a57ff3b9e1f343eb()
{
        try
        {
            this.testProblemSqlAnalytic3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7ab472f7796a353c()
{
        try
        {
            this.testProblemSqlAnalytic4EmptyOver();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0a1693ea1f52b996()
{
        try
        {
            this.testProblemSqlAnalytic5AggregateColumnValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9585c33cd7b7dc7d()
{
        try
        {
            this.testProblemSqlAnalytic6AggregateColumnValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2cfcc28e3b105918()
{
        try
        {
            this.testProblemSqlAnalytic7Count();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a2a3f29eb541ad22()
{
        try
        {
            this.testProblemSqlAnalytic8Complex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c690e34784cdd053()
{
        try
        {
            this.testProblemSqlAnalytic9CommaListPartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ed4955014c041922()
{
        try
        {
            this.testProblemSqlCombinedSets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6f23949c81ca0931()
{
        try
        {
            this.testProblemSqlExcept();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5bf6735f7384dcb()
{
        try
        {
            this.testProblemSqlFuncParamIssue605();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1b91a56238e13870()
{
        try
        {
            this.testProblemSqlFuncParamIssue605_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3e4c2fbeeab9eb4d()
{
        try
        {
            this.testProblemSqlIntersect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f06f807c0b76b7bb()
{
        try
        {
            this.testProblemSqlIssue265();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c63da34507a6c87()
{
        try
        {
            this.testProblemSqlIssue330();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4b54c80d9e7ffa9a()
{
        try
        {
            this.testProblemSqlIssue330_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_baf1d823ec65fc61()
{
        try
        {
            this.testProblemSqlIssue352();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_00edd7adc2074bc3()
{
        try
        {
            this.testProblemSqlIssue603();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_88aad262c2ba972b()
{
        try
        {
            this.testProblemSqlIssue603_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10075ed759092193()
{
        try
        {
            this.testProblemSqlMinus();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5d3975751aaf0fd0()
{
        try
        {
            this.testProblemSqlServer_Modulo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6d95e0ba9f8f2253()
{
        try
        {
            this.testProblemSqlServer_Modulo_Proz();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8a1803c2b0ddc40()
{
        try
        {
            this.testProblemSqlServer_Modulo_mod();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dcb76de80fc52a01()
{
        try
        {
            this.testProblematicDeparsingIssue1183();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_718e110c2a859a9b()
{
        try
        {
            this.testProblematicDeparsingIssue1183_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7df119365e931382()
{
        try
        {
            this.testQualifyClauseIssue1805();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_311ce0613bc46529()
{
        try
        {
            this.testQuotedCastExpression();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("u")]
[Xunit.InlineData("e")]
[Xunit.InlineData("n")]
[Xunit.InlineData("r")]
[Xunit.InlineData("b")]
[Xunit.InlineData("rb")]
public void __Upstream_feb99c58aca20ae2(string prefix)
{
        try
        {
            this.testRawStringExpressionIssue656(prefix);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_585cdb1ec1c2da66()
{
        try
        {
            this.testRegexpBinaryMySQL();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bd66dd66695d17a2()
{
        try
        {
            this.testRegexpLike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_771c283e1bb92abd()
{
        try
        {
            this.testRegexpLike1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d676d608dc7f105()
{
        try
        {
            this.testRegexpLike2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_397569fafa9d22a9()
{
        try
        {
            this.testRegexpMySQL();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_faea804ada8d0137()
{
        try
        {
            this.testReplaceAsFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2f969ca2ca5e66f1()
{
        try
        {
            this.testReservedKeyword();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_388bcde68b05737b()
{
        try
        {
            this.testReservedKeyword2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8b8c973bdb28ca5c()
{
        try
        {
            this.testReservedKeyword3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6c60ace267b43224()
{
        try
        {
            this.testReservedKeywordsIssue1352();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c68e8a78739328d4()
{
        try
        {
            this.testReservedKeywordsMSSQLUseIndexIssue1325();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f36a406c002e2228()
{
        try
        {
            this.testRlike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b1bd14d4f9787df5()
{
        try
        {
            this.testRowConstructor1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b64b4b79defd121e()
{
        try
        {
            this.testRowConstructor2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a9eb45d96fda8d6f()
{
        try
        {
            this.testSelContraction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_175a38368c0e9265()
{
        try
        {
            this.testSelectAliasInQuotes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_85b0cc944b716653()
{
        try
        {
            this.testSelectAliasWithoutAs();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_7bd745b128d06020()
{
        try
        {
            this.testSelectAllColumnsFromFunctionReturn();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_799bd0b299e03f45()
{
        try
        {
            this.testSelectAllColumnsFromFunctionReturnWithMultipleParentheses();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7c17abfc384a97b4()
{
        try
        {
            this.testSelectAllOperatorIssue1140();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51965a805e8341ae()
{
        try
        {
            this.testSelectAllOperatorIssue1140_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6d0bedd9afb5efc8()
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
public void __Upstream_b32b779ef89f37d3()
{
        try
        {
            this.testSelectBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dd99b68dbbb34aaf()
{
        try
        {
            this.testSelectBrackets2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9e4a7418c4e8896f()
{
        try
        {
            this.testSelectBrackets3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_62556fd5e3d93639()
{
        try
        {
            this.testSelectBrackets4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_14bf4d3da27f12e7()
{
        try
        {
            this.testSelectCastProblemIssue1248();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_7f38f9551d03e75e()
{
        try
        {
            this.testSelectCastProblemIssue1248_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_97003ab3d1339e60()
{
        try
        {
            this.testSelectConditionsIssue720And991();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c988a1dcc9d20b46()
{
        try
        {
            this.testSelectForUpdate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_92aab66d44c16fa3()
{
        try
        {
            this.testSelectForUpdate2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c83559224c8673dd()
{
        try
        {
            this.testSelectForUpdateOfTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d1e2329e354a523()
{
        try
        {
            this.testSelectFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b69fe9407517b0a6()
{
        try
        {
            this.testSelectInnerWith();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_79450bb0dc33cf5c()
{
        try
        {
            this.testSelectInnerWithAndUnionIssue1084_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_150540a539aa5615()
{
        try
        {
            this.testSelectInto1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9852bf7755abe0a()
{
        try
        {
            this.testSelectItems();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cf82c0f4416f9f2b()
{
        try
        {
            this.testSelectJPQLPositionalParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_05935f90c504beab()
{
        try
        {
            this.testSelectJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_613be12278c97090()
{
        try
        {
            this.testSelectJoin2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_14bc1419aaac88fb()
{
        try
        {
            this.testSelectJoinWithComma();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_faac8b5fb302a5a9()
{
        try
        {
            this.testSelectKeep();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_77d4fae72d896057()
{
        try
        {
            this.testSelectKeepOver();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_15e55b2fee8c7448()
{
        try
        {
            this.testSelectKeywordPercent();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4d0951d5e34e677e()
{
        try
        {
            this.testSelectMultidimensionalArrayStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e742960d9f8f1622()
{
        try
        {
            this.testSelectNumericBind();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d4c39318e91bcc22()
{
        try
        {
            this.testSelectOracleColl();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f6e8e523a90d28a6()
{
        try
        {
            this.testSelectOrderHaving();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39bc0fb0a214b4e4()
{
        try
        {
            this.testSelectRowElement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_460407a98bfe015b()
{
        try
        {
            this.testSelectStatementWithForUpdateAndSkipLockedTokens();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_20c17335d13bf641()
{
        try
        {
            this.testSelectStatementWithForUpdateButWithoutSkipLockedTokens();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8af5cb70a52eed4d()
{
        try
        {
            this.testSelectStatementWithoutForUpdateAndSkipLockedTokens();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_715b1d6308395e5a()
{
        try
        {
            this.testSelectTuple();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ea71bc39388a48f()
{
        try
        {
            this.testSelectUserVariable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_192dd282018bd844()
{
        try
        {
            this.testSelectWithBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_82c542e012dd0de1()
{
        try
        {
            this.testSelectWithBrackets2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3a7bca92be521cfd()
{
        try
        {
            this.testSelectWithMaterializedWith();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7034d6d21952406e()
{
        try
        {
            this.testSelectWithSkylineKeywords();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0acdd64dd0134db6()
{
        try
        {
            this.testSelectWithinGroup();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9fb88320e732ed0e()
{
        try
        {
            this.testSelectWithoutFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bd1d0509c88575f7()
{
        try
        {
            this.testSessionKeywordIssue876();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_445e023a9f0c81e3()
{
        try
        {
            this.testSetOperationListWithBracketsIssue1737();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_347590e6155b80ac()
{
        try
        {
            this.testSetOperationWithParenthesisIssue1094();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f1da04cede93dd03()
{
        try
        {
            this.testSetOperationWithParenthesisIssue1094_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_23991d6a6733ccee()
{
        try
        {
            this.testSetOperationWithParenthesisIssue1094_3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c9de6b389e62d56()
{
        try
        {
            this.testSetOperationWithParenthesisIssue1094_4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6b69e76c5a82b9b8()
{
        try
        {
            this.testSeveralColumnsFullTextSearchMySQL();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_62c544c11d74d3be()
{
        try
        {
            this.testSignedColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2fb2b9246b58ad5f()
{
        try
        {
            this.testSignedKeywordIssue1100();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5cec711e3cc9608()
{
        try
        {
            this.testSignedKeywordIssue995();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0ea305ad58ad2fd3()
{
        try
        {
            this.testSigns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c7bb27cd01d35b1()
{
        try
        {
            this.testSimilarToIssue789();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6aefbb34a726c831()
{
        try
        {
            this.testSimilarToIssue789_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_19fa86da21f96246()
{
        try
        {
            this.testSimpleAdditionsAndSubtractionsWithSigns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6e07ce35053782af()
{
        try
        {
            this.testSimpleJoinOnExpressionIssue1229();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2656175a225086c4()
{
        try
        {
            this.testSimpleSigns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51e1ce2200dfc695()
{
        try
        {
            this.testSizeKeywordIssue867();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ce1446916c2b3d78()
{
        try
        {
            this.testSkip();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b9029a2b23e9ad9()
{
        try
        {
            this.testSkipFirst();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_318a5bc01b9c08d2()
{
        try
        {
            this.testSpeedTestIssue235();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b88e7d70f470ca5e()
{
        try
        {
            this.testSpeedTestIssue235_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5232fc4aeef4dc8a()
{
        try
        {
            this.testSqlCache();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44d9e1398de64ec6()
{
        try
        {
            this.testSqlContainIsNullFunctionShouldBeParsed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_59285ea65f4fea0c()
{
        try
        {
            this.testSqlContainIsNullFunctionShouldBeParsed3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf15c0db94ab2f3e()
{
        try
        {
            this.testSqlNoCache();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_448bcd18fb8c1bfe()
{
        try
        {
            this.testSqlServerHints();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fb777ffeb3ba7f72()
{
        try
        {
            this.testSqlServerHintsWithIndexIssue915();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b7d4ea9780e7c53c()
{
        try
        {
            this.testSqlServerHintsWithIndexIssue915_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3fd4911e7ffab16e()
{
        try
        {
            this.testStartKeyword();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9577bf1d297df127()
{
        try
        {
            this.testStraightJoinInSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3539c87adb53fb9b()
{
        try
        {
            this.testSubQueryAliasIssue754();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8d6dc30cacfe0eae()
{
        try
        {
            this.testSubSelectFailsIssue394();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a3fc9a4f98992d57()
{
        try
        {
            this.testSubSelectFailsIssue394_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_09e7413bf0da3394()
{
        try
        {
            this.testSubSelectParsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e7d5a98a7bc516e7()
{
        try
        {
            this.testSubjoinWithJoins();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_11b7366136d0267e()
{
        try
        {
            this.testTSQLJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a09c0f9ea092d191()
{
        try
        {
            this.testTSQLJoin2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c90b4f9b1d27b72c()
{
        try
        {
            this.testTableCrossJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5912756f9b88b1bf()
{
        try
        {
            this.testTableFunctionInExprIssue923();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_748648c96f4f747e()
{
        try
        {
            this.testTableFunctionInExprIssue923_3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9fbf28d3d3de4d93()
{
        try
        {
            this.testTableFunctionInExprIssue923_4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0c6d324a56e839bc()
{
        try
        {
            this.testTableFunctionInExprIssue923_5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1370929bb4b6a0ad()
{
        try
        {
            this.testTableFunctionInExprIssue923_6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9f8f6ad52ff21c7e()
{
        try
        {
            this.testTableFunctionWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_45d5d692f1791363()
{
        try
        {
            this.testTableFunctionWithNoParams();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a671230590279c0()
{
        try
        {
            this.testTableFunctionWithParams();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_11be0f5af5bf25f1()
{
        try
        {
            this.testTableSpaceKeyword();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ac791f12104806a()
{
        try
        {
            this.testTableSpecificAllColumnsIssue1346();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10b63adcd7562a0f()
{
        try
        {
            this.testTableStatementIssue1836();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_737d77c1daa71147()
{
        try
        {
            this.testTime();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_905a807e853cdf63()
{
        try
        {
            this.testTimestamp();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0d48657e15ea5465()
{
        try
        {
            this.testTimestamptzDateTimeLiteral();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f1d112308f60d89a()
{
        try
        {
            this.testTimezoneExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c3834cf260181f18()
{
        try
        {
            this.testTimezoneExpressionWithColumnBasedTimezone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf4d207071c2d5f1()
{
        try
        {
            this.testTimezoneExpressionWithTwoTransformations();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_37fd85be6e456d1f()
{
        try
        {
            this.testTop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a9bcebdaca6d22bf()
{
        try
        {
            this.testTopExpressionIssue243();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_19acbe0752793c63()
{
        try
        {
            this.testTopExpressionIssue243_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_53bb485bf41c8604()
{
        try
        {
            this.testTopKeyWord();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_000e063d93383fe8()
{
        try
        {
            this.testTopKeyWord2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5748283cba08dd0e()
{
        try
        {
            this.testTopKeyWord3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_753b278a8dcca55e()
{
        try
        {
            this.testTopWithJdbcParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_006acecba7f927b2()
{
        try
        {
            this.testTopWithParenthesis();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8bddb6986a2a4a8b()
{
        try
        {
            this.testTopWithTies();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_efb9082798d614d1()
{
        try
        {
            this.testTrueFalseLiteral();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c01f0f8b7a41f0f7()
{
        try
        {
            this.testTryCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_55545a33854ba689()
{
        try
        {
            this.testTryCastInTryCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e02d79b6c3113964()
{
        try
        {
            this.testTryCastInTryCast2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e8286bbd8682d4e()
{
        try
        {
            this.testTryCastTypeProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a72653e552cb1569()
{
        try
        {
            this.testUnPivot();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b4cc40c9ecfcd76()
{
        try
        {
            this.testUnPivotWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4567308a9a4b3e1d()
{
        try
        {
            this.testUnPivotWithMultiColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d66f409eda87de1a()
{
        try
        {
            this.testUnion();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f4cb08a99f0653d7()
{
        try
        {
            this.testUnion2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_59f9eaa77c99c2f2()
{
        try
        {
            this.testUnionLimitOrderByIssue1268();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_19dc7aa5343dd276()
{
        try
        {
            this.testUnionWithBracketsAndOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf7bdef6cfb84652()
{
        try
        {
            this.testUnionWithOrderByAndLimitAndNoBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_718f8aaec8d875e3()
{
        try
        {
            this.testUniqueInsteadOfDistinctIssue299();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("SELECT SELECT 1")]
[Xunit.InlineData("SELECT 1 WHERE 1 = SELECT 1")]
[Xunit.InlineData("SELECT 1 WHERE 1 IN SELECT 1")]
[Xunit.InlineData("SELECT * FROM SELECT 1")]
[Xunit.InlineData("SELECT * FROM SELECT SELECT 1")]
[Xunit.InlineData("SELECT * FROM SELECT 1 WHERE 1 = SELECT 1")]
[Xunit.InlineData("SELECT * FROM SELECT 1 WHERE 1 IN SELECT 1")]
public void __Upstream_2e32f08f8090cd38(string sqlStr)
{
        try
        {
            this.testUnparenthesizedSubSelect(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c5183f846be0b70b()
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
public void __Upstream_0f75e91a5a6f63a1()
{
        try
        {
            this.testValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_32d382e035d29b17()
{
        try
        {
            this.testValues2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_11da119bd7f0cebe()
{
        try
        {
            this.testValues3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9c81266f9f18f4ed()
{
        try
        {
            this.testValues4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f07397aaba9dfb1()
{
        try
        {
            this.testValues5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d20263ab50377875()
{
        try
        {
            this.testValues6BothVariants();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fe3e6e3d1a47b5ee()
{
        try
        {
            this.testVariableAssignment();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3a60b836e394838b()
{
        try
        {
            this.testVariableAssignment2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3a57af5c1eff141d()
{
        try
        {
            this.testVariableAssignment3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d9defcc50e615e7c()
{
        try
        {
            this.testWeirdSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b135ca192b80c9b()
{
        try
        {
            this.testWhere();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ad30108dee9354b()
{
        try
        {
            this.testWhereIssue240_0();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_60c6caf818054c8a()
{
        try
        {
            this.testWhereIssue240_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3162491688544a0d()
{
        try
        {
            this.testWhereIssue240_false();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_3fcb56b07faf0cc5()
{
        try
        {
            this.testWhereIssue240_notBoolean();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_49dac8b5d1adc176()
{
        try
        {
            this.testWhereIssue240_true();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a4f32759b31fda03()
{
        try
        {
            this.testWhereIssue241KeywordEnd();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6edc3864962e9a47()
{
        try
        {
            this.testWindowClauseWithoutOrderByIssue869();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3b3ba464962cd8f4()
{
        try
        {
            this.testWith();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1543363f563a8796()
{
        try
        {
            this.testWithAsRecursiveIssue874();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ea827e48054a8b46()
{
        try
        {
            this.testWithInsideWithIssue1186();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d39a91312fcf12c9()
{
        try
        {
            this.testWithIsolation();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6345c26eb2d3d7a9()
{
        try
        {
            this.testWithRecursive();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d700c9d9ed13290c()
{
        try
        {
            this.testWithStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f2c95c7c29331a7()
{
        try
        {
            this.testWithUnionAllProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3121065c6b7d142f()
{
        try
        {
            this.testWithUnionProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ba530a4860c37556()
{
        try
        {
            this.testWithUnionProblem3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9795d8ae3cfd0e50()
{
        try
        {
            this.testWithUnionProblem4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b4ec1c6682321c69()
{
        try
        {
            this.testWithUnionProblem5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fec31097f300dae1()
{
        try
        {
            this.testWithValueListWithExtraBrackets1135();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8783349b6ae19ea0()
{
        try
        {
            this.testWithValueListWithOutExtraBrackets1135();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b7f77b994ab350b()
{
        try
        {
            this.testWrongParseTreeIssue89();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bfbc847edaa66a44()
{
        try
        {
            this.testXorCondition();
        }
        finally
        {
        }
}
}
