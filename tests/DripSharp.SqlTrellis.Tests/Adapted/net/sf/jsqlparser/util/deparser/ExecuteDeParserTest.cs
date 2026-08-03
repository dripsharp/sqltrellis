// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Deparser;

public class ExecuteDeParserTest {
private global::DripSharp.SqlTrellis.Util.Deparser.ExecuteDeParser executeDeParser = null!;

private global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionVisitor = null!;

private global::System.Text.StringBuilder buffer = null!;

public virtual void setUp() {
this.buffer = new global::System.Text.StringBuilder();
this.expressionVisitor = new global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser();
this.expressionVisitor.setBuilder(this.buffer);
this.executeDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.ExecuteDeParser(this.expressionVisitor, this.buffer);
}

public virtual void shouldDeParseExecute() {
global::DripSharp.SqlTrellis.Statement.Execute.Execute execute = new global::DripSharp.SqlTrellis.Statement.Execute.Execute();
string name = "name";
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.Runtime.JavaCompat.Add(expressions, new global::DripSharp.SqlTrellis.Expression.JdbcParameter());
global::DripSharp.Runtime.JavaCompat.Add(expressions, new global::DripSharp.SqlTrellis.Expression.JdbcParameter());
execute.withName(name).withExecType(global::DripSharp.SqlTrellis.Statement.Execute.Execute.ExecType.EXECUTE).withExprList(expressions);
this.executeDeParser.deParse(execute);
string actual = this.buffer.ToString();
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("EXECUTE ", name), " (?, ?)"), actual, null);
}

public virtual void shouldUseProvidedExpressionVisitorWhenDeParsingExecute() {
global::DripSharp.SqlTrellis.Statement.Execute.Execute execute = new global::DripSharp.SqlTrellis.Statement.Execute.Execute();
string name = "name";
global::DripSharp.SqlTrellis.Expression.Expression expression1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression expression2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.Runtime.JavaCompat.Add(expressions, expression1);
global::DripSharp.Runtime.JavaCompat.Add(expressions, expression2);
var exprList = global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>().addExpressions(expressions));
execute.withName(name).withExprList(exprList);
this.executeDeParser.deParse(execute);
global::DripSharp.Testing.JavaMockito.Then(expression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionVisitor), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(expression2).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionVisitor), (object)default!);
}

[Xunit.Fact]
public void __Upstream_7cd08481a12824d9()
{
        this.setUp();
        try
        {
            this.shouldDeParseExecute();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4988af800cd20164()
{
        this.setUp();
        try
        {
            this.shouldUseProvidedExpressionVisitorWhenDeParsingExecute();
        }
        finally
        {
        }
}
}
