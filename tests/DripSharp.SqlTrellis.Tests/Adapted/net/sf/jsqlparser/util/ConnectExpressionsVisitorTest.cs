// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class ConnectExpressionsVisitorTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testVisit_PlainSelect_concat() {
string sql = "select a,b,c from test";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(sql))!);
global::DripSharp.SqlTrellis.Util.ConnectExpressionsVisitor<object> instance = new Anonymous_32_52();
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(instance), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a || b || c AS expr FROM test", select.ToString(), null);
}

private sealed class Anonymous_32_52 : global::DripSharp.SqlTrellis.Util.ConnectExpressionsVisitor<object> {
public Anonymous_32_52() {}

protected internal override global::DripSharp.SqlTrellis.Expression.BinaryExpression createBinaryExpression() {
return new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Concat();
}
}

public virtual void testVisit_PlainSelect_addition() {
string sql = "select a,b,c from test";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(sql))!);
global::DripSharp.SqlTrellis.Util.ConnectExpressionsVisitor<object> instance = new Anonymous_47_52("testexpr");
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(instance), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a + b + c AS testexpr FROM test", select.ToString(), null);
}

private sealed class Anonymous_47_52 : global::DripSharp.SqlTrellis.Util.ConnectExpressionsVisitor<object> {
public Anonymous_47_52(string baseArgument0) : base(baseArgument0) {}

protected internal override global::DripSharp.SqlTrellis.Expression.BinaryExpression createBinaryExpression() {
return new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition();
}
}

[Xunit.Fact]
public void __Upstream_58224531792d4233()
{
        try
        {
            this.testVisit_PlainSelect_addition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5d6ee32afc236b6()
{
        try
        {
            this.testVisit_PlainSelect_concat();
        }
        finally
        {
        }
}
}
