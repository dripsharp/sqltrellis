// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class LongValueTest {
public virtual void testSimpleNumber() {
global::DripSharp.SqlTrellis.Expression.LongValue value = new global::DripSharp.SqlTrellis.Expression.LongValue("123");
global::DripSharp.Testing.JavaAssertions.Equal("123", value.getStringValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(123L, value.getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.BigIntegerParse("123"), value.getBigIntegerValue(), null);
}

public virtual void testLargeNumber() {
string largeNumber = "20161114000000035001";
global::DripSharp.SqlTrellis.Expression.LongValue value = new global::DripSharp.SqlTrellis.Expression.LongValue(largeNumber);
global::DripSharp.Testing.JavaAssertions.Equal(largeNumber, value.getStringValue(), null);
try {
value.getValue();
global::DripSharp.Testing.JavaAssertions.Fail("Assertion failed.");
} catch (global::System.Exception e) when (e is not global::System.TypeInitializationException) {}
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.BigIntegerParse(largeNumber), value.getBigIntegerValue(), null);
}

public virtual void testNullStringValue() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => {
new global::DripSharp.SqlTrellis.Expression.LongValue((string)default!);
}, null);
}

public virtual void testEmptyStringValue() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => {
new global::DripSharp.SqlTrellis.Expression.LongValue("");
}, null);
}

[Xunit.Fact]
public void __Upstream_900f1589bcea447b()
{
        try
        {
            this.testEmptyStringValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9a790961996393da()
{
        try
        {
            this.testLargeNumber();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7a88b001fc703dd3()
{
        try
        {
            this.testNullStringValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a0446fd73b9e209d()
{
        try
        {
            this.testSimpleNumber();
        }
        finally
        {
        }
}
}
