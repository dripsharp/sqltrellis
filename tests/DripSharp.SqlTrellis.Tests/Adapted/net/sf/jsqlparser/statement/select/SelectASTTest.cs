// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SelectASTTest {
public virtual void testSelectASTColumn() {
string sql = "SELECT  a,  b FROM  mytable  order by   b,  c";
global::System.Text.StringBuilder b = new global::System.Text.StringBuilder(sql);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
foreach (global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression> item__39_25 in plainSelect.getSelectItems()) {
var sei = (global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>)(item__39_25!);
global::DripSharp.SqlTrellis.Schema.Column c__41_20 = sei.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__42_24 = c__41_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__42_24, null);
(b)[(astNode__42_24.jjtGetFirstToken().beginColumn - 1)] = '*';
}
foreach (global::DripSharp.SqlTrellis.Statement.Select.OrderByElement item__46_29 in plainSelect.getOrderByElements()) {
global::DripSharp.SqlTrellis.Schema.Column c__47_20 = item__46_29.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__48_24 = c__47_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__48_24, null);
(b)[(astNode__48_24.jjtGetFirstToken().beginColumn - 1)] = '#';
}
global::DripSharp.Testing.JavaAssertions.Equal("SELECT  *,  * FROM  mytable  order by   #,  #", b.ToString(), null);
}

public virtual void testSelectASTNode() {
string sql = "SELECT  a,  b FROM  mytable  order by   b,  c";
global::DripSharp.SqlTrellis.Parser.SimpleNode node = (global::DripSharp.SqlTrellis.Parser.SimpleNode)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseAST(sql)!);
node.dump("*");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Parser.CCJSqlParserTreeConstants.JJTSTATEMENT, node.getId(), null);
}

private global::DripSharp.SqlTrellis.Parser.Token subSelectStart = null!;

private global::DripSharp.SqlTrellis.Parser.Token subSelectEnd = null!;

public virtual void testSelectASTColumnLF() {
string sql = "SELECT  a,  b FROM  mytable \n order by   b,  c";
global::System.Text.StringBuilder b = new global::System.Text.StringBuilder(sql);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
foreach (var item__96_28 in plainSelect.getSelectItems()) {
global::DripSharp.SqlTrellis.Schema.Column c__97_20 = item__96_28.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__98_24 = c__97_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__98_24, null);
(b)[(astNode__98_24.jjtGetFirstToken().absoluteBegin - 1)] = '*';
}
foreach (global::DripSharp.SqlTrellis.Statement.Select.OrderByElement item__102_29 in plainSelect.getOrderByElements()) {
global::DripSharp.SqlTrellis.Schema.Column c__103_20 = item__102_29.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__104_24 = c__103_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__104_24, null);
(b)[(astNode__104_24.jjtGetFirstToken().absoluteBegin - 1)] = '#';
}
global::DripSharp.Testing.JavaAssertions.Equal("SELECT  *,  * FROM  mytable \n order by   #,  #", b.ToString(), null);
}

public virtual void testSelectASTCommentLF() {
string sql = "SELECT  /* testcomment */ \n a,  b FROM  -- testcomment2 \n mytable \n order by   b,  c";
global::System.Text.StringBuilder b = new global::System.Text.StringBuilder(sql);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
foreach (var item__117_28 in plainSelect.getSelectItems()) {
global::DripSharp.SqlTrellis.Schema.Column c__118_20 = item__117_28.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__119_24 = c__118_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__119_24, null);
(b)[(astNode__119_24.jjtGetFirstToken().absoluteBegin - 1)] = '*';
}
foreach (global::DripSharp.SqlTrellis.Statement.Select.OrderByElement item__123_29 in plainSelect.getOrderByElements()) {
global::DripSharp.SqlTrellis.Schema.Column c__124_20 = item__123_29.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__125_24 = c__124_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__125_24, null);
(b)[(astNode__125_24.jjtGetFirstToken().absoluteBegin - 1)] = '#';
}
global::DripSharp.Testing.JavaAssertions.Equal("SELECT  /* testcomment */ \n *,  * FROM  -- testcomment2 \n mytable \n order by   #,  #", b.ToString(), null);
}

public virtual void testSelectASTCommentCRLF() {
string sql = "SELECT  /* testcomment */ \r\n a,  b FROM  -- testcomment2 \r\n mytable \r\n order by   b,  c";
global::System.Text.StringBuilder b = new global::System.Text.StringBuilder(sql);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
foreach (var item__140_28 in plainSelect.getSelectItems()) {
global::DripSharp.SqlTrellis.Schema.Column c__141_20 = item__140_28.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__142_24 = c__141_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__142_24, null);
(b)[(astNode__142_24.jjtGetFirstToken().absoluteBegin - 1)] = '*';
}
foreach (global::DripSharp.SqlTrellis.Statement.Select.OrderByElement item__146_29 in plainSelect.getOrderByElements()) {
global::DripSharp.SqlTrellis.Schema.Column c__147_20 = item__146_29.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.SqlTrellis.Parser.SimpleNode astNode__148_24 = c__147_20.getASTNode();
global::DripSharp.Testing.JavaAssertions.NotNull(astNode__148_24, null);
(b)[(astNode__148_24.jjtGetFirstToken().absoluteBegin - 1)] = '#';
}
global::DripSharp.Testing.JavaAssertions.Equal("SELECT  /* testcomment */ \r\n *,  * FROM  -- testcomment2 \r\n mytable \r\n order by   #,  #", b.ToString(), null);
}

public virtual void testDetectInExpressions() {
string sql = "SELECT * FROM  mytable WHERE a IN (1,2,3,4,5,6,7)";
global::DripSharp.SqlTrellis.Parser.SimpleNode node = (global::DripSharp.SqlTrellis.Parser.SimpleNode)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseAST(sql)!);
node.dump("*");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Parser.CCJSqlParserTreeConstants.JJTSTATEMENT, node.getId(), null);
node.jjtAccept(new Anonymous_163_24(this), (object)default!);
global::DripSharp.Testing.JavaAssertions.NotNull(this.subSelectStart, null);
global::DripSharp.Testing.JavaAssertions.NotNull(this.subSelectEnd, null);
global::DripSharp.Testing.JavaAssertions.Equal(32, this.subSelectStart.beginColumn, null);
global::DripSharp.Testing.JavaAssertions.Equal(49, this.subSelectEnd.endColumn, null);
}

private sealed class Anonymous_163_24 : global::DripSharp.SqlTrellis.Parser.CCJSqlParserDefaultVisitor {
private readonly global::DripSharp.SqlTrellis.Statement.Select.SelectASTTest __outer;

public Anonymous_163_24(global::DripSharp.SqlTrellis.Statement.Select.SelectASTTest __outer) {
this.__outer = __outer;
}

public override object visit(global::DripSharp.SqlTrellis.Parser.SimpleNode node, object data) {
if ((node.getId() == global::DripSharp.SqlTrellis.Parser.CCJSqlParserTreeConstants.JJTINEXPRESSION)) {
this.__outer.subSelectStart = node.jjtGetFirstToken();
this.__outer.subSelectEnd = node.jjtGetLastToken();
return base.visit(node, data);
} else {
return base.visit(node, data);
}
}
}

public virtual void testSelectASTExtractWithCommentsIssue1580() {
string sql = "SELECT  /* testcomment */ \r\n a,  b FROM  -- testcomment2 \r\n mytable \r\n order by   b,  c";
global::DripSharp.SqlTrellis.Parser.SimpleNode root = (global::DripSharp.SqlTrellis.Parser.SimpleNode)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseAST(sql)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Parser.Token> comments = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Parser.Token>();
root.jjtAccept(new Anonymous_189_24(comments), (object)default!);
global::DripSharp.Testing.JavaAssertJ.That(comments).Extracting(((global::System.Func<global::DripSharp.SqlTrellis.Parser.Token, object>)((token) => token.image))).ContainsExactly("/* testcomment */", "-- testcomment2 ");
}

private sealed class Anonymous_189_24 : global::DripSharp.SqlTrellis.Parser.CCJSqlParserDefaultVisitor {
private readonly global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Parser.Token> __capture_0;

public Anonymous_189_24(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Parser.Token> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit(global::DripSharp.SqlTrellis.Parser.SimpleNode node, object data) {
if ((node.jjtGetFirstToken().specialToken != default!)) {
if (!global::DripSharp.Runtime.JavaCompat.CollectionContains(this.__capture_0, node.jjtGetFirstToken().specialToken)) {
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, node.jjtGetFirstToken().specialToken);
}
}
return base.visit(node, data);
}
}

public virtual void testSelectASTExtractWithCommentsIssue1580_2() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("/* I want this comment */\n", "SELECT order_detail_id, quantity\n"), "/* But ignore this one safely */\n"), "FROM order_details;");
global::DripSharp.SqlTrellis.Parser.SimpleNode root = (global::DripSharp.SqlTrellis.Parser.SimpleNode)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseAST(sql)!);
global::DripSharp.Testing.JavaAssertJ.That(root.jjtGetFirstToken().specialToken.image).IsEqualTo("/* I want this comment */");
}

[Xunit.Fact]
public void __Upstream_dc00bacb90ab62c4()
{
        try
        {
            this.testDetectInExpressions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3581d51af211f2d1()
{
        try
        {
            this.testSelectASTColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9ab9d52b011d0a1e()
{
        try
        {
            this.testSelectASTColumnLF();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_835417bb15f349d4()
{
        try
        {
            this.testSelectASTCommentCRLF();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cf763d06e773f46d()
{
        try
        {
            this.testSelectASTCommentLF();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e7cc29fb06d0a8d9()
{
        try
        {
            this.testSelectASTExtractWithCommentsIssue1580();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ddba8480d1384dc4()
{
        try
        {
            this.testSelectASTExtractWithCommentsIssue1580_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b988de836c123e27()
{
        try
        {
            this.testSelectASTNode();
        }
        finally
        {
        }
}
}
