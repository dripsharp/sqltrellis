// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class TimeValueTest {
public virtual void testNullValue() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => {
new global::DripSharp.SqlTrellis.Expression.TimeValue((string)default!);
}, null);
}

public virtual void testEmptyValue() {
global::DripSharp.Testing.JavaAssertions.Throws<global::System.ArgumentException>(() => {
new global::DripSharp.SqlTrellis.Expression.TimeValue("");
}, null);
}

[Xunit.Fact]
public void __Upstream_d74f51933c4bec47()
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
public void __Upstream_6668adc91c71a606()
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
