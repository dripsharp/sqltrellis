// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class BooleanValueTest {
public virtual void testTrueValue() {
global::DripSharp.SqlTrellis.Expression.BooleanValue value = new global::DripSharp.SqlTrellis.Expression.BooleanValue("true");
global::DripSharp.Testing.JavaAssertions.True(value.getValue(), null);
}

public virtual void testFalseValue() {
global::DripSharp.SqlTrellis.Expression.BooleanValue value = new global::DripSharp.SqlTrellis.Expression.BooleanValue("false");
global::DripSharp.Testing.JavaAssertions.False(value.getValue(), null);
}

public virtual void testWrongValueAsFalseLargeNumber() {
global::DripSharp.SqlTrellis.Expression.BooleanValue value = new global::DripSharp.SqlTrellis.Expression.BooleanValue("test");
global::DripSharp.Testing.JavaAssertions.False(value.getValue(), null);
}

public virtual void testNullStringValue() {
global::DripSharp.SqlTrellis.Expression.BooleanValue value = new global::DripSharp.SqlTrellis.Expression.BooleanValue((string)default!);
global::DripSharp.Testing.JavaAssertions.False(value.getValue(), null);
}

[Xunit.Fact]
public void __Upstream_058a2714c22cc483()
{
        try
        {
            this.testFalseValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_95049837a352706f()
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
public void __Upstream_f0f88ca7ea34cace()
{
        try
        {
            this.testTrueValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_015bda3d99e8d948()
{
        try
        {
            this.testWrongValueAsFalseLargeNumber();
        }
        finally
        {
        }
}
}
