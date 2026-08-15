// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Builder;

public class JSQLParserFluentModelTests {
public virtual void testParseAndBuild() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM tab1 AS t1 ", "JOIN tab2 t2 ON t1.ref = t2.id WHERE (t1.col1 = ? OR t1.col2 = ?) AND t1.col3 IN ('A')");
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Schema.Table t1 = new global::DripSharp.SqlTrellis.Schema.Table("tab1").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t1").withUseAs(true));
global::DripSharp.SqlTrellis.Schema.Table t2 = new global::DripSharp.SqlTrellis.Schema.Table("tab2").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t2", false));
global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression where = ((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression>(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression().withLeftExpression(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "col1"))))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.JdbcParameter().withIndex(1))))))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "col2")), new global::DripSharp.SqlTrellis.Expression.JdbcParameter().withIndex(2))))))))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "col3"))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.StringValue>(new global::DripSharp.SqlTrellis.Expression.StringValue("A"))))));
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(t1).addJoins(new global::DripSharp.SqlTrellis.Statement.Select.Join().withRightItem(t2).withOnExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "ref")), new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t2", "id"))))).withWhere(where);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(select, statement);
}

public virtual void testParseAndBuildForXOR() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM tab1 AS t1 JOIN tab2 t2 ON t1.ref = t2.id ", "WHERE (t1.col1 XOR t2.col2) AND t1.col3 IN ('B', 'C') XOR t2.col4");
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Schema.Table t1 = new global::DripSharp.SqlTrellis.Schema.Table("tab1").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t1", true));
global::DripSharp.SqlTrellis.Schema.Table t2 = new global::DripSharp.SqlTrellis.Schema.Table("tab2").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t2", false));
global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression where = ((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression().withLeftExpression(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression>(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "col1"))))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t2", "col2"))))))))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.InExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "col3"))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.StringValue>(new global::DripSharp.SqlTrellis.Expression.StringValue("B"), new global::DripSharp.SqlTrellis.Expression.StringValue("C"))))))))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t2", "col4")))));
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(t1).addJoins(new global::DripSharp.SqlTrellis.Statement.Select.Join().withRightItem(t2).withOnExpression(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo(new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t1", "ref")), new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("t2", "id"))))).withWhere(where);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(select, statement);
}

public virtual void testParseAndBuildForXORComplexCondition() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM tab1 AS t1 WHERE ", "a AND b OR c XOR d");
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Schema.Table t1 = new global::DripSharp.SqlTrellis.Schema.Table("tab1").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t1", true));
global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression where = ((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression().withLeftExpression(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.OrExpression().withLeftExpression(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b"))))))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("c"))))))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("d"))));
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(t1).withWhere(where);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(select, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(select, parsed);
}

public virtual void testParseAndBuildForXORs() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM tab1 AS t1 WHERE ", "a XOR b XOR c");
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Schema.Table t1 = new global::DripSharp.SqlTrellis.Schema.Table("tab1").withAlias(new global::DripSharp.SqlTrellis.Expression.Alias("t1", true));
global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression where = ((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression().withLeftExpression(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(((global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression)(new global::DripSharp.SqlTrellis.Expression.Operators.Conditional.XorExpression().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b"))))))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("c"))));
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(t1).withWhere(where);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(select, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(select, parsed);
}

[Xunit.Fact]
public void __Upstream_62cdc1692f7dc4cf()
{
        try
        {
            this.testParseAndBuild();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a760f404568dc052()
{
        try
        {
            this.testParseAndBuildForXOR();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_71c9b4cee7ec034e()
{
        try
        {
            this.testParseAndBuildForXORComplexCondition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_445413a5cb1bdf76()
{
        try
        {
            this.testParseAndBuildForXORs();
        }
        finally
        {
        }
}
}
