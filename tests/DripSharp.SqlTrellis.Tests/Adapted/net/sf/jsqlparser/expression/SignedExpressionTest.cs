// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class SignedExpressionTest {
public virtual void testGetSign() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => new global::DripSharp.SqlTrellis.Expression.SignedExpression('*', global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a")), "must not work");
}

[Xunit.Fact]
public void __Upstream_27d995d7960dc1c9()
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
