// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Test;

public class HowToUseSample {
internal virtual void writeSQL() {
string expectedSQLStr = "SELECT 1 FROM dual t WHERE a = b";
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table().withName("dual").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t", false));
global::DripSharp.SqlTrellis.Schema.Column columnA = new global::DripSharp.SqlTrellis.Schema.Column().withColumnName("a");
global::DripSharp.SqlTrellis.Schema.Column columnB = new global::DripSharp.SqlTrellis.Schema.Column().withColumnName("b");
global::DripSharp.SqlTrellis.Expression.Expression whereExpression = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo().withLeftExpression(columnA).withRightExpression(columnB);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1))).withFromItem(table).withWhere(whereExpression);
global::DripSharp.Testing.JavaAssertions.Equal(expectedSQLStr, select.ToString(), null);
global::System.Text.StringBuilder builder = new global::System.Text.StringBuilder();
global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser deParser = new global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser(builder);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(deParser)).visit(select);
global::DripSharp.Testing.JavaAssertions.Equal(expectedSQLStr, builder.ToString(), null);
}

public virtual void howToParseStatementDeprecated() {
string sqlStr = "select 1 from dual where a=b";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
if ((statement is global::DripSharp.SqlTrellis.Statement.Select.Select)) {
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(statement!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select.getSelectBody()!);
global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression> selectItem = (global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0)!);
global::DripSharp.SqlTrellis.Schema.Table table = (global::DripSharp.SqlTrellis.Schema.Table)(plainSelect.getFromItem()!);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo equalsTo = (global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)(plainSelect.getWhere()!);
global::DripSharp.SqlTrellis.Schema.Column a = (global::DripSharp.SqlTrellis.Schema.Column)(equalsTo.getLeftExpression()!);
global::DripSharp.SqlTrellis.Schema.Column b = (global::DripSharp.SqlTrellis.Schema.Column)(equalsTo.getRightExpression()!);
}
}

public virtual void howToParseStatement() {
string sqlStr = "select 1 from dual where a=b";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
var selectItem = global::DripSharp.Runtime.JavaCompat.ListGet(select.getSelectItems(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), selectItem.getExpression(), null);
global::DripSharp.SqlTrellis.Schema.Table table = (global::DripSharp.SqlTrellis.Schema.Table)(select.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Equal("dual", table.getName(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo equalsTo = (global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)(select.getWhere()!);
global::DripSharp.SqlTrellis.Schema.Column a = (global::DripSharp.SqlTrellis.Schema.Column)(equalsTo.getLeftExpression()!);
global::DripSharp.SqlTrellis.Schema.Column b = (global::DripSharp.SqlTrellis.Schema.Column)(equalsTo.getRightExpression()!);
global::DripSharp.Testing.JavaAssertions.Equal("a", a.getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", b.getColumnName(), null);
}

public virtual void howToUseVisitors() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> expressionVisitorAdapter = new Anonymous_142_17();
global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> selectVisitorAdapter = new Anonymous_157_59(expressionVisitorAdapter);
global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object> statementVisitor = new Anonymous_165_58(selectVisitorAdapter);
string sqlStr = "select 1 from dual where a=b";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
((global::DripSharp.SqlTrellis.Statement.Statement)(stmt)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(statementVisitor));
}

private sealed class Anonymous_142_17 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
public Anonymous_142_17() {}

public override object visit<K>(global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo equalsTo, K context) {
equalsTo.getLeftExpression().accept<object, K>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(this), context);
equalsTo.getRightExpression().accept<object, K>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(this), context);
return default!;
}

public override object visit<K>(global::DripSharp.SqlTrellis.Schema.Column column, K context) {
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat("Found a Column ", column.getColumnName()));
return default!;
}
}

private sealed class Anonymous_157_59 : global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> {
private readonly global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> __capture_0;

public Anonymous_157_59(global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<K>(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect, K context) {
return plainSelect.getWhere().accept<object, K>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(this.__capture_0), context);
}
}

private sealed class Anonymous_165_58 : global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object> {
private readonly global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> __capture_0;

public Anonymous_165_58(global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<K>(global::DripSharp.SqlTrellis.Statement.Select.Select select, K context) {
return select.accept<object, K>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(this.__capture_0), context);
}
}

public virtual void howToUseFeatures() {
string sqlStr = "select 1 from [sample_table] where [a]=[b]";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withSquareBracketQuotation(true));
global::DripSharp.SqlTrellis.Statement.Statement stmt1 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withSquareBracketQuotation(true).withTimeOut((long)(6000)));
global::DripSharp.SqlTrellis.Statement.Statement stmt2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withSquareBracketQuotation(true).withAllowComplexParsing(true).withTimeOut((long)(6000)));
}

public virtual void showBracketHandling() {
string sqlStr = " ( (values(1,2), (3,4)) UNION (values((1,2), (3,4))) )";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
string reflectionString = global::DripSharp.SqlTrellis.Test.TestUtils.toReflectionString(statement);
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(reflectionString);
}

internal virtual void migrationTest1() {
string sqlStr = "VALUES ( 1, 2, 3 )";
global::DripSharp.SqlTrellis.Statement.Select.Values values = (global::DripSharp.SqlTrellis.Statement.Select.Values)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(values.getExpressions()), null);
}

internal virtual void migrationTest2() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "        FROM ( VALUES 1, 2, 3 )");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedFromItem fromItem = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedFromItem)(select.getFromItem()!);
global::DripSharp.SqlTrellis.Statement.Select.Values values = (global::DripSharp.SqlTrellis.Statement.Select.Values)(fromItem.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(values.getExpressions()), null);
}

internal virtual void migrationTest3() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE test\n", "        SET (   a\n"), "                , b\n"), "                , c ) = ( VALUES 1, 2, 3 )");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Update.UpdateSet updateSet = global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect subSelect = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect>(global::DripSharp.Runtime.JavaCompat.ListGet(updateSet.getValues(), 0));
global::DripSharp.SqlTrellis.Statement.Select.Values values = (global::DripSharp.SqlTrellis.Statement.Select.Values)(subSelect.getSelect()!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(values.getExpressions()), null);
}

internal virtual void migrationTest4() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO test\n", "        VALUES ( 1, 2, 3 )\n"), "        ;");
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Select.Values values = (global::DripSharp.SqlTrellis.Statement.Select.Values)(insert.getSelect()!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(values.getExpressions()), null);
}

internal virtual void migrationTest5() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT Function( a, b, c )\n", "        FROM dual\n"), "        GROUP BY    a\n"), "                    , b\n"), "                    , c");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.Function function = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Function>(select.getSelectItem(0).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(function.getParameters()), null);
var groupByExpressions = global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(select.getGroupBy().getGroupByExpressionList());
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(groupByExpressions), null);
}

internal virtual void migrationTest6() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "    SELECT *\n"), "    FROM (  SELECT 1 )\n"), "    UNION ALL\n"), "    SELECT *\n"), "    FROM ( VALUES 1, 2, 3 )\n"), "    UNION ALL\n"), "    VALUES ( 1, 2, 3 ) )");
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setOperationList = parenthesedSelect.getSetOperationList();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select1 = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(setOperationList.getSelect(0)!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect subSelect1 = ((global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(select1.getFromItem()!)).getPlainSelect();
global::DripSharp.Testing.JavaAssertions.Equal(1L, subSelect1.getSelectItem(0).getExpression<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)).getValue(), null);
global::DripSharp.SqlTrellis.Statement.Select.Values values = (global::DripSharp.SqlTrellis.Statement.Select.Values)(setOperationList.getSelect(2)!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(values.getExpressions()), null);
}

internal virtual void migrationTest7() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM a\n"), "  INNER JOIN (  b\n"), "                  LEFT JOIN c\n"), "                    ON b.d = c.d )\n"), "    ON a.e = b.e");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Schema.Table aTable = (global::DripSharp.SqlTrellis.Schema.Table)(select.getFromItem()!);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedFromItem fromItem = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedFromItem)(select.getJoin(0).getFromItem()!);
global::DripSharp.SqlTrellis.Schema.Table bTable = (global::DripSharp.SqlTrellis.Schema.Table)(fromItem.getFromItem()!);
global::DripSharp.SqlTrellis.Statement.Select.Join join = fromItem.getJoin(0);
global::DripSharp.SqlTrellis.Schema.Table cTable = (global::DripSharp.SqlTrellis.Schema.Table)(join.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Equal("c", cTable.getName(), null);
}

internal virtual void migrationTest8() {
string sqlStr = "SELECT ( ( 1, 2, 3 ), ( 4, 5, 6 ), ( 7, 8, 9 ) )";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
var expressionList = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>>(select.getSelectItem(0).getExpression());
var expressionList1 = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(expressionList, 0));
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(expressionList1), null);
}

internal virtual void migrationTest9() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("UPDATE a\n", "SET (   a\n"), "        , b\n"), "        , c ) = (   1\n"), "                    , 2\n"), "                    , 3 )\n"), "    , d = 4");
global::DripSharp.SqlTrellis.Statement.Update.Update update = (global::DripSharp.SqlTrellis.Statement.Update.Update)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Statement.Update.UpdateSet updateSet1 = update.getUpdateSet(0);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(updateSet1.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(updateSet1.getValues()), null);
global::DripSharp.SqlTrellis.Statement.Update.UpdateSet updateSet2 = update.getUpdateSet(1);
global::DripSharp.Testing.JavaAssertions.Equal("d", updateSet2.getColumn(0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(4L, ((global::DripSharp.SqlTrellis.Expression.LongValue)(updateSet2.getValue(0)!)).getValue(), null);
}

internal virtual void migrationTest10() {
string sqlStr = "INSERT INTO target SELECT * FROM source";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("source"));
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("target")).withSelect(select);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(insert, sqlStr);
}

internal virtual void migrationTest11() {
string sqlStr = "INSERT INTO target VALUES (1, 2, 3)";
global::DripSharp.SqlTrellis.Statement.Select.Values values = new global::DripSharp.SqlTrellis.Statement.Select.Values().addExpressions(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3)));
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = new global::DripSharp.SqlTrellis.Statement.Insert.Insert().withTable(new global::DripSharp.SqlTrellis.Schema.Table("target")).withSelect(values);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(insert, sqlStr);
}

internal virtual void testComplexParsingOnly() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT  e.id\n", "        , e.code\n"), "        , e.review_type\n"), "        , e.review_object\n"), "        , e.review_first_datetime AS reviewfirsttime\n"), "        , e.review_latest_datetime AS reviewnewtime\n"), "        , e.risk_event\n"), "        , e.risk_detail\n"), "        , e.risk_grade\n"), "        , e.risk_status\n"), "        , If( e.deal_type IS NULL\n"), "            OR e.deal_type = '', '--', e.deal_type ) AS dealtype\n"), "        , e.deal_result\n"), "        , If( e.deal_remark IS NULL\n"), "            OR e.deal_remark = '', '--', e.deal_remark ) AS dealremark\n"), "        , e.is_deleted\n"), "        , e.review_object_id\n"), "        , e.archive_id\n"), "        , e.feature AS featurename\n"), "        , Ifnull( ( SELECT real_name\n"), "                    FROM bladex.blade_user\n"), "                    WHERE id = e.review_first_user ), ( SELECT DISTINCT\n"), "                                                            real_name\n"), "                                                        FROM app_sys.asys_uniapp_rn_auth\n"), "                                                        WHERE uniapp_user_id = e.review_first_user\n"), "                                                            AND is_disable = 0 ) ) AS reviewfirstuser\n"), "        , Ifnull( ( SELECT real_name\n"), "                    FROM bladex.blade_user\n"), "                    WHERE id = e.review_latest_user ), (    SELECT DISTINCT\n"), "                                                                real_name\n"), "                                                            FROM app_sys.asys_uniapp_rn_auth\n"), "                                                            WHERE uniapp_user_id = e.review_latest_user\n"), "                                                                AND is_disable = 0 ) ) AS reviewnewuser\n"), "        , If( ( SELECT real_name\n"), "                FROM bladex.blade_user\n"), "                WHERE id = e.deal_user ) IS NOT NULL\n"), "            AND e.deal_user != - 9999, (    SELECT real_name\n"), "                                            FROM bladex.blade_user\n"), "                                            WHERE id = e.deal_user ), '--' ) AS dealuser\n"), "        , CASE\n"), "                WHEN 'COMPANY'\n"), "                    THEN Concat( (  SELECT ar.customer_name\n"), "                                    FROM mtp_cs.mtp_rsk_cust_archive ar\n"), "                                    WHERE ar.is_deleted = 0\n"), "                                        AND ar.id = e.archive_id ), If( (   SELECT alias\n"), "                                                                            FROM web_crm.wcrm_customer\n"), "                                                                            WHERE id = e.customer_id ) = ''\n"), "                OR (    SELECT alias\n"), "                        FROM web_crm.wcrm_customer\n"), "                        WHERE id = e.customer_id ) IS NULL, ' ', Concat( '\uFF08', ( SELECT alias\n"), "                                                                                FROM web_crm.wcrm_customer\n"), "                                                                                WHERE id = e.customer_id ), '\uFF09' ) ) )\n"), "                WHEN 'EMPLOYEE'\n"), "                    THEN (  SELECT Concat( auth.real_name, ' ', auth.phone )\n"), "                            FROM app_sys.asys_uniapp_rn_auth auth\n"), "                            WHERE auth.is_disable = 0\n"), "                                AND auth.uniapp_user_id = e.uniapp_user_id )\n"), "                WHEN 'DEAL'\n"), "                    THEN (  SELECT DISTINCT\n"), "                                Concat( batch.code, '-', detail.line_seq\n"), "                                        , ' ', Ifnull( (    SELECT DISTINCT\n"), "                                                                auth.real_name\n"), "                                                            FROM app_sys.asys_uniapp_rn_auth auth\n"), "                                                            WHERE auth.uniapp_user_id = e.uniapp_user_id\n"), "                                                                AND auth.is_disable = 0 ), ' ' ) )\n"), "                            FROM web_pym.wpym_payment_batch_detail detail\n"), "                                LEFT JOIN web_pym.wpym_payment_batch batch\n"), "                                    ON detail.payment_batch_id = batch.id\n"), "                            WHERE detail.id = e.review_object_id )\n"), "                WHEN 'TASK'\n"), "                    THEN (  SELECT code\n"), "                            FROM web_tm.wtm_task task\n"), "                            WHERE e.review_object_id = task.id )\n"), "                ELSE NULL\n"), "            END AS reviewobjectname\n"), "        , CASE\n"), "                WHEN 4\n"), "                    THEN 'HIGH_LEVEL'\n"), "                WHEN 3\n"), "                    THEN 'MEDIUM_LEVEL'\n"), "                WHEN 2\n"), "                    THEN 'LOW_LEVEL'\n"), "                ELSE 'HEALTHY'\n"), "            END AS risklevel\n"), "FROM mtp_cs.mtp_rsk_event e\n"), "WHERE e.is_deleted = 0\n"), "ORDER BY e.review_latest_datetime DESC\n"), "LIMIT 30\n"), ";");
long startMillis = global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
global::DripSharp.Runtime.JavaExecutorService executorService = new global::DripSharp.Runtime.JavaExecutorService(1);
for (int i = 1; (i < 1); i++) {
global::DripSharp.SqlTrellis.Parser.CCJSqlParser parser = new global::DripSharp.SqlTrellis.Parser.CCJSqlParser(sqlStr).withSquareBracketQuotation(false).withAllowComplexParsing(true).withBackslashEscapeCharacter(false);
global::DripSharp.Runtime.JavaFuture<global::DripSharp.SqlTrellis.Statement.Statements> future = executorService.Submit(() => {
return parser.Statements();
});
try {
future.Get((long)(6000), global::DripSharp.Runtime.JavaTimeUnit.MILLISECONDS);
long endMillis = global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat("Time to parse [ms]: ", ((endMillis - startMillis) / i)));
} catch (global::System.Exception ex2) when (ex2 is global::System.TimeoutException or global::System.Threading.ThreadInterruptedException) {
parser.interrupted = true;
future.Cancel(true);
throw new global::DripSharp.SqlTrellis.JSQLParserException("Failed to within reasonable time ", ex2);
} catch (global::System.AggregateException e) {
if ((global::DripSharp.Runtime.JavaCompat.GetCause(e)! is global::DripSharp.SqlTrellis.Parser.ParseException)) {
global::DripSharp.SqlTrellis.Parser.ParseException parseException = (global::DripSharp.SqlTrellis.Parser.ParseException)(global::DripSharp.Runtime.JavaCompat.GetCause(e)!);
global::DripSharp.SqlTrellis.Parser.Token token = parseException.currentToken.next;
throw new global::DripSharp.SqlTrellis.JSQLParserException(global::DripSharp.Runtime.JavaCompat.Concat("Failed to parse statement at Token ", token.image));
}
}
}
executorService.Shutdown();
}

[Xunit.Fact]
public void __Upstream_5d2cba21daa9642b()
{
        try
        {
            this.howToParseStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f7c8ff28814a3a8()
{
        try
        {
            this.howToParseStatementDeprecated();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8c6039cf4f74576c()
{
        try
        {
            this.howToUseFeatures();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c1bef8ed2ec46d1a()
{
        try
        {
            this.howToUseVisitors();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52b264f48e1212b1()
{
        try
        {
            this.migrationTest1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9b511d30f6e6dd81()
{
        try
        {
            this.migrationTest10();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44ea7cf5a9f99891()
{
        try
        {
            this.migrationTest11();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_17d33f74ce9e12a1()
{
        try
        {
            this.migrationTest2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9c9a207c35972ef()
{
        try
        {
            this.migrationTest3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4293179576866d9b()
{
        try
        {
            this.migrationTest4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bb770e9131ce6d6f()
{
        try
        {
            this.migrationTest5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b3474d52bcb67512()
{
        try
        {
            this.migrationTest6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_147bd1c5f51dbf9b()
{
        try
        {
            this.migrationTest7();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d468ae9da9011d1a()
{
        try
        {
            this.migrationTest8();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9930c7e989cc86b()
{
        try
        {
            this.migrationTest9();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52f8a6dd2921384e()
{
        try
        {
            this.showBracketHandling();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_91817ea109b779dc()
{
        try
        {
            this.testComplexParsingOnly();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2d1375f4749ac717()
{
        try
        {
            this.writeSQL();
        }
        finally
        {
        }
}
}
