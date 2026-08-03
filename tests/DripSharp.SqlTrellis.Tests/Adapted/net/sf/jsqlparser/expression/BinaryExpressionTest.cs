// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class BinaryExpressionTest {
internal virtual void testAddition() {
global::DripSharp.SqlTrellis.Expression.Expression addition = global::DripSharp.SqlTrellis.Expression.BinaryExpression.add(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)));
global::DripSharp.Testing.JavaAssertions.Equal("1 + 1", global::DripSharp.Runtime.JavaCompat.StringValueOf(addition), null);
}

[Xunit.Fact]
public void __Upstream_c1e677d79e2c4f43()
{
        try
        {
            this.testAddition();
        }
        finally
        {
        }
}
}
