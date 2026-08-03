// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class TableSamplePipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("FROM LargeTable\n", "|> TABLESAMPLE SYSTEM (1.0 PERCENT);\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_b4022e3e03076bd0()
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
