// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators;

public class XorTest {
internal virtual void testXorIssue1980() {
string sqlStr = "SELECT a or b from c";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a0a6700bcdc78202()
{
        try
        {
            this.testXorIssue1980();
        }
        finally
        {
        }
}
}
