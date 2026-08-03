// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class CallPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM input_table\n", "|> CALL tvf1(arg1)\n"), "|> CALL tvf2(arg2, arg3);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_f9ca421d288c0171()
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
