// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class InExpressionTest {
internal virtual void testOracleInWithoutBrackets() {
string sqlStr = "select 1 from dual where a in 1 ";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testOracleInWithBrackets() {
string sqlStr = "select 1 from dual where a in (1) ";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_14a27034fe45f951()
{
        try
        {
            this.testOracleInWithBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4ca5edb241b4fda5()
{
        try
        {
            this.testOracleInWithoutBrackets();
        }
        finally
        {
        }
}
}
