// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class ExtendPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM (\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> EXTEND item IN ('carrots', 'oranges') AS is_orange;");
global::DripSharp.SqlTrellis.Statement.Piped.FromQuery fromQuery = (global::DripSharp.SqlTrellis.Statement.Piped.FromQuery)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
}

internal virtual void testParseAndDeparseWithoutFromKeyword() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> EXTEND item IN ('carrots', 'oranges') AS is_orange;");
global::DripSharp.SqlTrellis.Statement.Piped.FromQuery fromQuery = (global::DripSharp.SqlTrellis.Statement.Piped.FromQuery)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
}

[Xunit.Fact]
public void __Upstream_b0fdc8cfcd111ddf()
{
        try
        {
            this.testParseAndDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_62bd22da9964136b()
{
        try
        {
            this.testParseAndDeparseWithoutFromKeyword();
        }
        finally
        {
        }
}
}
