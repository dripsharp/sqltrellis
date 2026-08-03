// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class ExpressionPrecedenceTest {
public virtual void testGetSign() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("1&2||3");
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Concat>(expr, null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseAnd>(((global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Concat)(expr!)).getLeftExpression(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.LongValue>(((global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Concat)(expr!)).getRightExpression(), null);
}

[Xunit.Fact]
public void __Upstream_f7833fad1eb4dbb7()
{
        try
        {
            this.testGetSign();
        }
        finally
        {
        }
}
}
