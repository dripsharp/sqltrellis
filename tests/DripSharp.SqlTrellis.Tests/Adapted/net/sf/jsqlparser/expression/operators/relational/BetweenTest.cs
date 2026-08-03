// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class BetweenTest {
internal virtual void testBetweenWithAdditionIssue1948() {
string sqlStr = "select col FROM tbl WHERE start_time BETWEEN 1706024185 AND MyFunc() - 734400";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_3e1feac4ee60947c()
{
        try
        {
            this.testBetweenWithAdditionIssue1948();
        }
        finally
        {
        }
}
}
