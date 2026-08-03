// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class IsUnknownExpressionTest {
public virtual void testIsUnknownExpression(string sqlStr) {
global::DripSharp.Testing.JavaAssertions.DoesNotThrow(() => global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr), null);
}

internal virtual void testStringConstructor() {
global::DripSharp.SqlTrellis.Schema.Column column = new global::DripSharp.SqlTrellis.Schema.Column("x");
global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsUnknownExpression defaultIsUnknownExpression = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsUnknownExpression().withLeftExpression(column);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(defaultIsUnknownExpression, "x IS UNKNOWN");
global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsUnknownExpression isUnknownExpression = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsUnknownExpression().withLeftExpression(column).withNot(false);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(isUnknownExpression, "x IS UNKNOWN");
global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsUnknownExpression isNotUnknownExpression = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsUnknownExpression().withLeftExpression(column).withNot(true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(isNotUnknownExpression, "x IS NOT UNKNOWN");
}

[Xunit.Theory]
[Xunit.InlineData("SELECT * FROM mytable WHERE 1 IS UNKNOWN")]
[Xunit.InlineData("SELECT * FROM mytable WHERE 1 IS NOT UNKNOWN")]
public void __Upstream_e7db47489499a73d(string sqlStr)
{
        try
        {
            this.testIsUnknownExpression(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e2ef50805cd4073()
{
        try
        {
            this.testStringConstructor();
        }
        finally
        {
        }
}
}
