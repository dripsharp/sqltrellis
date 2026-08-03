// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class SetPipeOperatorTest {
internal virtual void parseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 1 AS x, 11 AS y\n"), "  UNION ALL\n"), "  SELECT 2 AS x, 22 AS y\n"), ")\n"), "|> SET x = x * x, y = 3;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_39d8abc7e818ac74()
{
        try
        {
            this.parseAndDeparse();
        }
        finally
        {
        }
}
}
