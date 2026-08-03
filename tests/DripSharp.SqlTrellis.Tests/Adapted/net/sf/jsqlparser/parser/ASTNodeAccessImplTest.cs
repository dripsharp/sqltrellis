// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser;

public class ASTNodeAccessImplTest {
internal virtual void testGetParent() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select listagg(sellerid)\n", "within group (order by sellerid)\n"), "over() AS list from winsales;");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.AnalyticExpression expression = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.AnalyticExpression>(select.getSelectItem(0).getExpression());
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>>(expression.getParent(), null);
global::DripSharp.Testing.JavaAssertions.Equal(select, expression.getParent<global::DripSharp.SqlTrellis.Statement.Select.Select>(typeof(global::DripSharp.SqlTrellis.Statement.Select.Select)), null);
}

internal virtual void testGetWherePositionIssue1339() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select listagg(sellerid)\n", "within group (order by sellerid)\n"), "over() AS list from winsales\n"), "WHERE a=b\n"), "ORDER BY 1;");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.Expression whereExpression = select.getWhere();
global::DripSharp.SqlTrellis.Parser.SimpleNode node = whereExpression.getASTNode();
if ((node != default!)) {
global::DripSharp.SqlTrellis.Parser.Token token = node.jjtGetFirstToken();
global::DripSharp.Testing.JavaAssertions.Equal(4, token.beginLine, null);
global::DripSharp.Testing.JavaAssertions.Equal(7, token.beginColumn, null);
} else {
throw new global::System.Exception("Node not found.");
}
}

[Xunit.Fact]
public void __Upstream_0afecbd279a3e9f0()
{
        try
        {
            this.testGetParent();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fbe47b7b1b48cab8()
{
        try
        {
            this.testGetWherePositionIssue1339();
        }
        finally
        {
        }
}
}
