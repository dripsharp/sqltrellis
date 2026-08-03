// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class LimitPipeOperatorTest {
internal virtual void testParseAndDeparse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'bananas' AS item, 5 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> ORDER BY item\n"), "|> LIMIT 1;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testParseAndDeparseWithOffset() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(\n", "  SELECT 'apples' AS item, 2 AS sales\n"), "  UNION ALL\n"), "  SELECT 'bananas' AS item, 5 AS sales\n"), "  UNION ALL\n"), "  SELECT 'carrots' AS item, 8 AS sales\n"), ")\n"), "|> ORDER BY item\n"), "|> LIMIT 1 OFFSET 2;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a3f343c86440957f()
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
public void __Upstream_6574f878d5b5e277()
{
        try
        {
            this.testParseAndDeparseWithOffset();
        }
        finally
        {
        }
}
}
