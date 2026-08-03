// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class ExtractExpressionTest {
internal virtual void testRegularFunctionCall() {
string sqlStr = "select extract(engine_full, '''(.*?)''')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_02a2740f9b4db1ef()
{
        try
        {
            this.testRegularFunctionCall();
        }
        finally
        {
        }
}
}
