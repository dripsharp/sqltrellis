// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class IntervalExpressionTest {
internal virtual void testExtractExpressionIssue2172() {
string sqlStr = "select INTERVAL Extract( DAY from Now()) - 1 DAY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT UNIX_TIMESTAMP(date_sub(date_sub(date_format(now(),'%y-%m-%d'),interval extract(day from now())-1 day),interval 1 month))*1000";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_5a79f8b616d59e64()
{
        try
        {
            this.testExtractExpressionIssue2172();
        }
        finally
        {
        }
}
}
