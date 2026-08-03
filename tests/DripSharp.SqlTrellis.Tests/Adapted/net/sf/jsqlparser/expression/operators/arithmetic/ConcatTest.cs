// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Arithmetic;

public class ConcatTest {
internal virtual void concatTest() {
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.concat(new global::DripSharp.SqlTrellis.Expression.StringValue("A"), new global::DripSharp.SqlTrellis.Expression.StringValue("B"), new global::DripSharp.SqlTrellis.Expression.StringValue("C"));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Concat>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("'A' || 'B' || 'C'", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.concat(new global::DripSharp.SqlTrellis.Expression.StringValue("A"));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.StringValue>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("'A'", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.concat();
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.NullValue>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("NULL", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
}

internal virtual void addTest() {
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.add(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3)));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("1 + 2 + 3", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.add(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.LongValue>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.add();
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.NullValue>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("NULL", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
}

internal virtual void multiplyTest() {
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.multiply(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3)));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("1 + 2 + 3", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.multiply(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.LongValue>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
expression = global::DripSharp.SqlTrellis.Expression.BinaryExpression.multiply();
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.NullValue>(expression, null);
global::DripSharp.Testing.JavaAssertions.Equal("NULL", global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), null);
}

[Xunit.Fact]
public void __Upstream_f88f0d473e589406()
{
        try
        {
            this.concatTest();
        }
        finally
        {
        }
}
}
