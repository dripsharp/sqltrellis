// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Deparser;

public class CreateViewDeParserTest {
public virtual void testUseExtrnalExpressionDeparser() {
global::System.Text.StringBuilder b = new global::System.Text.StringBuilder();
global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser selectDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser();
selectDeParser.setBuilder(b);
global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionDeParser = new Anonymous_37_49(selectDeParser, b);
selectDeParser.setExpressionVisitor(expressionDeParser);
global::DripSharp.SqlTrellis.Util.Deparser.CreateViewDeParser instance = new global::DripSharp.SqlTrellis.Util.Deparser.CreateViewDeParser(b, selectDeParser);
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView vc = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("CREATE VIEW test AS SELECT a, b FROM mytable")!);
instance.deParse(vc);
global::DripSharp.Testing.JavaAssertions.Equal("CREATE VIEW test AS SELECT a, b FROM mytable", vc.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("CREATE VIEW test AS SELECT \"a\", \"b\" FROM mytable", instance.getBuilder().ToString(), null);
}

private sealed class Anonymous_37_49 : global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser {
public Anonymous_37_49(global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder> baseArgument0, global::System.Text.StringBuilder baseArgument1) : base(baseArgument0, baseArgument1) {}

public override global::System.Text.StringBuilder visit<K>(global::DripSharp.SqlTrellis.Schema.Column tableColumn, K parameters) {
global::DripSharp.SqlTrellis.Schema.Table table = tableColumn.getTable();
string tableName = default!;
if ((table != default!)) {
if ((table.getAlias() != default!)) {
tableName = table.getAlias().getName();
} else {
tableName = table.getFullyQualifiedName();
}
}
if (((tableName! != default!) && !((tableName!.Length == 0)))) {
this.getBuilder().Append("\"").Append(tableName!).Append("\"").Append(".");
}
this.getBuilder().Append("\"").Append(tableColumn.getColumnName()).Append("\"");
return base.builder;
}
}

public virtual void testCreateViewASTNode() {
string sql = "CREATE VIEW test AS SELECT a, b FROM mytable";
global::System.Text.StringBuilder b = new global::System.Text.StringBuilder(sql);
global::DripSharp.SqlTrellis.Parser.SimpleNode node = (global::DripSharp.SqlTrellis.Parser.SimpleNode)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseAST(sql)!);
node.dump("*");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Parser.CCJSqlParserTreeConstantsStatics.JJTSTATEMENT, node.getId(), null);
node.jjtAccept(new Anonymous_79_24(b), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("CREATE VIEW test AS SELECT \"a\", \"b\" FROM mytable", b.ToString(), null);
}

private sealed class Anonymous_79_24 : global::DripSharp.SqlTrellis.Parser.CCJSqlParserDefaultVisitor {
private readonly global::System.Text.StringBuilder __capture_0;

public Anonymous_79_24(global::System.Text.StringBuilder __capture_0) {
this.__capture_0 = __capture_0;
this.idxDelta = 0;
}

internal int idxDelta;

public override object visit(global::DripSharp.SqlTrellis.Parser.SimpleNode node, object data) {
if ((global::DripSharp.SqlTrellis.Parser.CCJSqlParserTreeConstantsStatics.JJTCOLUMN == node.getId())) {
this.__capture_0.Insert(((node.jjtGetFirstToken().beginColumn - 1) + this.idxDelta), '"');
this.idxDelta++;
this.__capture_0.Insert((node.jjtGetLastToken().endColumn + this.idxDelta), '"');
this.idxDelta++;
}
return base.visit(node, data);
}
}

[Xunit.Fact]
public void __Upstream_e650bb059adaa3d0()
{
        try
        {
            this.testCreateViewASTNode();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a38dc88cb2b6e7ed()
{
        try
        {
            this.testUseExtrnalExpressionDeparser();
        }
        finally
        {
        }
}
}
