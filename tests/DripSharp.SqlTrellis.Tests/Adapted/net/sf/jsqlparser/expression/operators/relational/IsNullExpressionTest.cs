// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class IsNullExpressionTest {
internal virtual void testNotNullExpression() {
string sqlStr = "select * from mytable where 1 notnull";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testStringConstructor() {
global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsNullExpression isNullExpression = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.IsNullExpression("x", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(isNullExpression, "x IS NOT NULL");
}

[Xunit.Fact]
public void __Upstream_fb09891749847e04()
{
        try
        {
            this.testNotNullExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b8e2c49e3c35c4dd()
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
