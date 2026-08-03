// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Arithmetic;

public class ArithmethicTests {
public virtual void testAddition() {
global::DripSharp.Testing.JavaAssertions.Equal("1 + a", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1))).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).ToString(), null);
}

public virtual void testBitwiseAnd() {
global::DripSharp.Testing.JavaAssertions.Equal("a & b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseAnd().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testBitwiseLeftShift() {
global::DripSharp.Testing.JavaAssertions.Equal("a << b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseLeftShift().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testBitwiseOr() {
global::DripSharp.Testing.JavaAssertions.Equal("a | b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseOr().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testBitwiseRightShift() {
global::DripSharp.Testing.JavaAssertions.Equal("a >> b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseRightShift().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testBitwiseXor() {
global::DripSharp.Testing.JavaAssertions.Equal("a ^ b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseXor().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testConcat() {
global::DripSharp.Testing.JavaAssertions.Equal("a || b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Concat().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testDivision() {
global::DripSharp.Testing.JavaAssertions.Equal("a / b", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Division().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("a")).withRightExpression(new global::DripSharp.SqlTrellis.Schema.Column("b")).ToString(), null);
}

public virtual void testIntegerDivision() {
global::DripSharp.Testing.JavaAssertions.Equal("4 DIV 2", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.IntegerDivision().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(4))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2))).ToString(), null);
}

public virtual void testModulo() {
global::DripSharp.Testing.JavaAssertions.Equal("3 % 2", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Modulo().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2))).ToString(), null);
}

public virtual void testMultiplication() {
global::DripSharp.Testing.JavaAssertions.Equal("5 * 2", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Multiplication().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(5))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2))).ToString(), null);
}

public virtual void testSubtraction() {
global::DripSharp.Testing.JavaAssertions.Equal("5 - 3", new global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Subtraction().withLeftExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(5))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(3))).ToString(), null);
}

[Xunit.Fact]
public void __Upstream_4a46efe2391d83cc()
{
        try
        {
            this.testAddition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2e5f794445abe79a()
{
        try
        {
            this.testBitwiseAnd();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f2e50dbce9154e67()
{
        try
        {
            this.testBitwiseLeftShift();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_01ca2a75bb2aa2e6()
{
        try
        {
            this.testBitwiseOr();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f34dc1b626af3f56()
{
        try
        {
            this.testBitwiseRightShift();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_266ea8c3350858a4()
{
        try
        {
            this.testBitwiseXor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_08b5d46afacea587()
{
        try
        {
            this.testConcat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5f5cf02a00ea8eb3()
{
        try
        {
            this.testDivision();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ce3f687a7c1e97b8()
{
        try
        {
            this.testIntegerDivision();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_19be2ec7a60c531e()
{
        try
        {
            this.testModulo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_72d0ca38fb8b30df()
{
        try
        {
            this.testMultiplication();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d13cd0496c268dba()
{
        try
        {
            this.testSubtraction();
        }
        finally
        {
        }
}
}
