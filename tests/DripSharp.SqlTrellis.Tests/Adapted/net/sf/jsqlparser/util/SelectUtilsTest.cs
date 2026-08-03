// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class SelectUtilsTest {
public virtual void testAddExpr() {
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select a from mytable")!);
global::DripSharp.SqlTrellis.Util.SelectUtils.addExpression(select, new global::DripSharp.SqlTrellis.Schema.Column("b"));
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a, b FROM mytable", select.ToString(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition add = new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition();
add.setLeftExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(5)));
add.setRightExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(6)));
global::DripSharp.SqlTrellis.Util.SelectUtils.addExpression(select, add);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a, b, 5 + 6 FROM mytable", select.ToString(), null);
}

public virtual void testAddJoin() {
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select a from mytable")!);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo equalsTo = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo();
equalsTo.setLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a"));
equalsTo.setRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b"));
global::DripSharp.SqlTrellis.Statement.Select.Join addJoin = global::DripSharp.SqlTrellis.Util.SelectUtils.addJoin(select, new global::DripSharp.SqlTrellis.Schema.Table("mytable2"), equalsTo);
addJoin.setLeft(true);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a FROM mytable LEFT JOIN mytable2 ON a = b", select.ToString(), null);
}

public virtual void testBuildSelectFromTableAndExpressions() {
global::DripSharp.SqlTrellis.Statement.Select.Select select = global::DripSharp.SqlTrellis.Util.SelectUtils.buildSelectFromTableAndExpressions(new global::DripSharp.SqlTrellis.Schema.Table("mytable"), new global::DripSharp.SqlTrellis.Schema.Column("a"), new global::DripSharp.SqlTrellis.Schema.Column("b"));
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a, b FROM mytable", select.ToString(), null);
}

public virtual void testBuildSelectFromTable() {
global::DripSharp.SqlTrellis.Statement.Select.Select select = global::DripSharp.SqlTrellis.Util.SelectUtils.buildSelectFromTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable"));
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM mytable", select.ToString(), null);
}

public virtual void testBuildSelectFromTableAndParsedExpression() {
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Util.SelectUtils.buildSelectFromTableAndExpressions(new global::DripSharp.SqlTrellis.Schema.Table("mytable"), "a+b", "test")!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a + b, test FROM mytable", select.ToString(), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(select.getSelectItems(), 0).getExpression() is global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition), null);
}

public virtual void testBuildSelectFromTableWithGroupBy() {
global::DripSharp.SqlTrellis.Statement.Select.Select select = global::DripSharp.SqlTrellis.Util.SelectUtils.buildSelectFromTable(new global::DripSharp.SqlTrellis.Schema.Table("mytable"));
global::DripSharp.SqlTrellis.Util.SelectUtils.addGroupBy(select, new global::DripSharp.SqlTrellis.Schema.Column("b"));
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM mytable GROUP BY b", select.ToString(), null);
}

public virtual void testTableAliasIssue311()
{
    var table1 = new global::DripSharp.SqlTrellis.Schema.Table("mytable1");
    table1.setAlias(new global::DripSharp.SqlTrellis.Expression.Alias("tab1"));
    var table2 = new global::DripSharp.SqlTrellis.Schema.Table("mytable2");
    table2.setAlias(new global::DripSharp.SqlTrellis.Expression.Alias("tab2"));
    var columns = global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Schema.Column(table1, "col1"), new global::DripSharp.SqlTrellis.Schema.Column(table1, "col2"), new global::DripSharp.SqlTrellis.Schema.Column(table1, "col3"), new global::DripSharp.SqlTrellis.Schema.Column(table2, "b1"), new global::DripSharp.SqlTrellis.Schema.Column(table2, "b2"));
    var select = global::DripSharp.SqlTrellis.Util.SelectUtils.buildSelectFromTableAndExpressions(table1, global::System.Linq.Enumerable.ToArray(columns));
    var equalsTo = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo();
    equalsTo.setLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column(table1, "col1"));
    equalsTo.setRightExpression(new global::DripSharp.SqlTrellis.Schema.Column(table2, "b1"));
    var addJoin = global::DripSharp.SqlTrellis.Util.SelectUtils.addJoin(select, table2, equalsTo);
    addJoin.setLeft(true);
    global::DripSharp.Testing.JavaAssertions.Equal("SELECT tab1.col1, tab1.col2, tab1.col3, tab2.b1, tab2.b2 FROM mytable1 AS tab1 LEFT JOIN mytable2 AS tab2 ON tab1.col1 = tab2.b1", select.ToString(), null);
}

public virtual void testTableAliasIssue311_2() {
global::DripSharp.SqlTrellis.Schema.Table table1 = new global::DripSharp.SqlTrellis.Schema.Table("mytable1");
table1.setAlias(new global::DripSharp.SqlTrellis.Expression.Alias("tab1"));
global::DripSharp.SqlTrellis.Schema.Column col = new global::DripSharp.SqlTrellis.Schema.Column(table1, "col1");
global::DripSharp.Testing.JavaAssertions.Equal("tab1.col1", col.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytable.col1", col.getFullyQualifiedName(), null);
}

[Xunit.Fact]
public void __Upstream_7845177bdb163187()
{
        try
        {
            this.testAddExpr();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7f835f43be086272()
{
        try
        {
            this.testAddJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_45e1f7aea1811f38()
{
        try
        {
            this.testBuildSelectFromTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58a5a2a57767defa()
{
        try
        {
            this.testBuildSelectFromTableAndExpressions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c7f3deb4bb8dc554()
{
        try
        {
            this.testBuildSelectFromTableAndParsedExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f094c39813cfc610()
{
        try
        {
            this.testBuildSelectFromTableWithGroupBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c3c865748fc8a626()
{
        try
        {
            this.testTableAliasIssue311();
        }
        finally
        {
        }
}
}
