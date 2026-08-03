// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class ExpressionVisitorAdapterTest {
public virtual void testInExpressionProblem() {
global::System.Collections.Generic.IList<object> exprList = new global::System.Collections.Generic.List<object>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select * from foo where x in (?,?,?)")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_46_22(exprList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 1), null);
}

private sealed class Anonymous_46_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<object> __capture_0;

public Anonymous_46_22(global::System.Collections.Generic.IList<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression expr, S parameters) {
base.visit(expr, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getLeftExpression());
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getRightExpression());
return default!;
}
}

public virtual void testInExpression() {
global::System.Collections.Generic.IList<object> exprList = new global::System.Collections.Generic.List<object>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select * from foo where (a,b) in (select a,b from foo2)")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_67_22(exprList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 1), null);
}

private sealed class Anonymous_67_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<object> __capture_0;

public Anonymous_67_22(global::System.Collections.Generic.IList<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression expr, S parameters) {
base.visit(expr, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getLeftExpression());
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getRightExpression());
return default!;
}
}

public virtual void testXorExpression() {
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Expression.Expression> exprList = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * FROM table WHERE foo XOR bar")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_88_22(exprList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(exprList), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 0)!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 1)!)).getColumnName(), null);
}

private sealed class Anonymous_88_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Expression.Expression> __capture_0;

public Anonymous_88_22(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Expression.Expression> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression expr, S parameters) {
base.visit(expr, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getLeftExpression());
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getRightExpression());
return default!;
}
}

public virtual void testOracleHintExpressions() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapterTest.testOracleHintExpression("select --+ MYHINT \n * from foo", "MYHINT", true);
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapterTest.testOracleHintExpression("select /*+ MYHINT */ * from foo", "MYHINT", false);
}

public static void testOracleHintExpression(string sql, string hint, bool singleLine) {
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Expression.OracleHint[] holder = new global::DripSharp.SqlTrellis.Expression.OracleHint[1];
global::DripSharp.Testing.JavaAssertions.NotNull(plainSelect.getOracleHint(), null);
plainSelect.getOracleHint().accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_117_44(holder)), (object)default!);
global::DripSharp.Testing.JavaAssertions.NotNull(holder[0], null);
global::DripSharp.Testing.JavaAssertions.Equal(singleLine, holder[0].isSingleLine(), null);
global::DripSharp.Testing.JavaAssertions.Equal(hint, holder[0].getValue(), null);
}

private sealed class Anonymous_117_44 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::DripSharp.SqlTrellis.Expression.OracleHint[] __capture_0;

public Anonymous_117_44(global::DripSharp.SqlTrellis.Expression.OracleHint[] __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Expression.OracleHint hint, S parameters) {
base.visit(hint, parameters);
this.__capture_0[0] = hint;
return default!;
}
}

public virtual void testCurrentTimestampExpression() {
global::System.Collections.Generic.IList<string> columnList = new global::System.Collections.Generic.List<string>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select * from foo where bar < CURRENT_TIMESTAMP")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_138_22(columnList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(columnList), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar", global::DripSharp.Runtime.JavaCompat.ListGet(columnList, 0), null);
}

private sealed class Anonymous_138_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<string> __capture_0;

public Anonymous_138_22(global::System.Collections.Generic.IList<string> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Schema.Column column, S parameters) {
base.visit(column, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, column.getColumnName());
return default!;
}
}

public virtual void testCurrentDateExpression() {
global::System.Collections.Generic.IList<string> columnList = new global::System.Collections.Generic.List<string>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select * from foo where bar < CURRENT_DATE")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_158_22(columnList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(columnList), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar", global::DripSharp.Runtime.JavaCompat.ListGet(columnList, 0), null);
}

private sealed class Anonymous_158_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<string> __capture_0;

public Anonymous_158_22(global::System.Collections.Generic.IList<string> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Schema.Column column, S parameters) {
base.visit(column, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, column.getColumnName());
return default!;
}
}

public virtual void testSubSelectExpressionProblem() {
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * FROM t1 WHERE EXISTS (SELECT * FROM t2 WHERE t2.col2 = t1.col1)")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
adapter.setSelectVisitor(new global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object>());
try {
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
} catch (global::System.NullReferenceException) {
global::DripSharp.Testing.JavaAssertions.Fail("Assertion failed.");
}
}

public virtual void testCaseWithoutElse() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("CASE WHEN 1 then 0 END");
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
expr.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testCaseWithoutElse2() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("CASE WHEN 1 then 0 ELSE -1 END");
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
expr.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testCaseWithoutElse3() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("CASE 3+4 WHEN 1 then 0 END");
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
expr.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testAnalyticFunctionWithoutExpression502() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("row_number() over (order by c)");
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
expr.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testAtTimeZoneExpression() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("DATE(date1 AT TIME ZONE 'UTC' AT TIME ZONE 'australia/sydney')");
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
expr.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testJsonFunction() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("JSON_OBJECT( KEY 'foo' VALUE bar, KEY 'foo' VALUE bar)").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("JSON_ARRAY( (SELECT * from dual) )").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testJsonAggregateFunction() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("JSON_OBJECTAGG( KEY foo VALUE bar NULL ON NULL WITH UNIQUE KEYS ) FILTER( WHERE name = 'Raj' ) OVER( PARTITION BY name )").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("JSON_ARRAYAGG( a FORMAT JSON ABSENT ON NULL ) FILTER( WHERE name = 'Raj' ) OVER( PARTITION BY name )").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testConnectedByRootExpression() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("CONNECT_BY_ROOT last_name as name").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testRowConstructor() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("CAST(ROW(dataid, value, calcMark) AS ROW(datapointid CHAR, value CHAR, calcMark CHAR))").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testAllTableColumns() {
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select a.* from foo a")!);
global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns[] holder = new global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns[1];
global::DripSharp.SqlTrellis.Expression.Expression from = global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0).getExpression();
from.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_261_21(holder)), (object)default!);
global::DripSharp.Testing.JavaAssertions.NotNull(holder[0], null);
global::DripSharp.Testing.JavaAssertions.Equal("a.*", holder[0].ToString(), null);
}

private sealed class Anonymous_261_21 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns[] __capture_0;

public Anonymous_261_21(global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns[] __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.AllTableColumns all, S parameters) {
this.__capture_0[0] = all;
return default!;
}
}

public virtual void testAnalyticExpressionWithPartialWindowElement() {
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("SUM(\"Spent\") OVER (PARTITION BY \"ID\" ORDER BY \"Name\" ASC ROWS BETWEEN CURRENT ROW AND UNBOUNDED FOLLOWING)");
expression.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

public virtual void testIncludesExpression() {
global::System.Collections.Generic.IList<object> exprList = new global::System.Collections.Generic.List<object>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select id from foo where b includes ('A', 'B')")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_289_22(exprList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 1), null);
}

private sealed class Anonymous_289_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<object> __capture_0;

public Anonymous_289_22(global::System.Collections.Generic.IList<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Expression.Operators.Relational.IncludesExpression expr, S parameters) {
base.visit(expr, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getLeftExpression());
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getRightExpression());
return default!;
}
}

public virtual void testExcludesExpression() {
global::System.Collections.Generic.IList<object> exprList = new global::System.Collections.Generic.List<object>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select id from foo where b Excludes ('A', 'B')")!);
global::DripSharp.SqlTrellis.Expression.Expression where = plainSelect.getWhere();
where.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_310_22(exprList)), (object)default!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>>(global::DripSharp.Runtime.JavaCompat.ListGet(exprList, 1), null);
}

private sealed class Anonymous_310_22 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::System.Collections.Generic.IList<object> __capture_0;

public Anonymous_310_22(global::System.Collections.Generic.IList<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExcludesExpression expr, S parameters) {
base.visit(expr, parameters);
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getLeftExpression());
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, expr.getRightExpression());
return default!;
}
}

public virtual void testIntervalWithNoExpression() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("INTERVAL 1 DAY");
global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> adapter = new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>();
expr.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(adapter), (object)default!);
}

[Xunit.Fact]
public void __Upstream_57a5f0abae294978()
{
        try
        {
            this.testAllTableColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dc2933c7e0c10d0e()
{
        try
        {
            this.testAnalyticExpressionWithPartialWindowElement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d39912df8d7e494d()
{
        try
        {
            this.testAnalyticFunctionWithoutExpression502();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ca19abae16d78ba9()
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
public void __Upstream_103587c8f0c073b6()
{
        try
        {
            this.testCaseWithoutElse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_529806bd3e3904b5()
{
        try
        {
            this.testCaseWithoutElse2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d679af78517862f2()
{
        try
        {
            this.testCaseWithoutElse3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b6d76b4b55578340()
{
        try
        {
            this.testConnectedByRootExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e4f8b3a37ba5c42b()
{
        try
        {
            this.testCurrentDateExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eb855a9cabf51d10()
{
        try
        {
            this.testCurrentTimestampExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9786f275d5e79128()
{
        try
        {
            this.testExcludesExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4389c81fcc110c44()
{
        try
        {
            this.testInExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8c6fa51b72f9b1cc()
{
        try
        {
            this.testInExpressionProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_884438369680115f()
{
        try
        {
            this.testIncludesExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5b615d3f5c97e5b9()
{
        try
        {
            this.testIntervalWithNoExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5bb544c44d24c428()
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
public void __Upstream_1bbd75f0a50c5352()
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
public void __Upstream_6354b4f84a742399()
{
        try
        {
            this.testOracleHintExpressions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_20bac77ffe1edfab()
{
        try
        {
            this.testRowConstructor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e7d39957c7414d3e()
{
        try
        {
            this.testSubSelectExpressionProblem();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_763923a09fb3dab0()
{
        try
        {
            this.testXorExpression();
        }
        finally
        {
        }
}
}
