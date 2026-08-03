// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class UnPivotPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'kale' as product, 55 AS Q1, 45 AS Q2\n"), "  UNION ALL\n"), "  SELECT 'apple', 8, 10\n"), ")\n"), "|> UNPIVOT(sales FOR quarter IN (Q1, Q2));");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_bbf1f669583ce6bb()
{
        try
        {
            this.testParseAndDeparse();
        }
        finally
        {
        }
}
}
