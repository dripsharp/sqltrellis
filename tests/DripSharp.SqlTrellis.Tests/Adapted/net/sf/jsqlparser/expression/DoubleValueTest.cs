// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class DoubleValueTest {
public virtual void testNullValue() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => {
new global::DripSharp.SqlTrellis.Expression.DoubleValue((string)default!);
}, null);
}

public virtual void testEmptyValue() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => {
new global::DripSharp.SqlTrellis.Expression.DoubleValue("");
}, null);
}

public virtual void shouldSetStringValue() {
global::DripSharp.SqlTrellis.Expression.DoubleValue doubleValue = new global::DripSharp.SqlTrellis.Expression.DoubleValue("42");
doubleValue.setValue(43.0D);
global::DripSharp.Testing.JavaAssertions.Equal(43.0D, doubleValue.getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal("43.0", doubleValue.ToString(), null);
}

[Xunit.Fact]
public void __Upstream_7b857727ec0d9cc4()
{
        try
        {
            this.shouldSetStringValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d9858c31e3c447fc()
{
        try
        {
            this.testEmptyValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c43da1d134360d7()
{
        try
        {
            this.testNullValue();
        }
        finally
        {
        }
}
}
