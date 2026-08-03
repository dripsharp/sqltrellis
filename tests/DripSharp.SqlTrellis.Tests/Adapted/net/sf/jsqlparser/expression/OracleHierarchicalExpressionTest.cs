// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class OracleHierarchicalExpressionTest {
internal virtual void testIssue2231() {
string sqlString = "select name from product where level > 1 start with 1 = 1 or 1 = 2 connect by nextversion = prior activeversion";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

[Xunit.Fact]
public void __Upstream_314b7244429ae2e8()
{
        try
        {
            this.testIssue2231();
        }
        finally
        {
        }
}
}
