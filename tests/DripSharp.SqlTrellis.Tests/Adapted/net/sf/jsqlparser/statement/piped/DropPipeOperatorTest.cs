// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class DropPipeOperatorTest {
internal virtual void testParseAndDeParseWithoutFromKeyword() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT 'apples' AS item, 2 AS sales, 'fruit' AS category\n", "|> DROP sales, category;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testParseAndDeParse() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("FROM (SELECT 1 AS x, 2 AS y) AS t\n", "|> DROP x\n"), "|> SELECT t.x AS original_x, y;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a09d0ee781096bf8()
{
        try
        {
            this.testParseAndDeParse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c4362ccd2ed5baff()
{
        try
        {
            this.testParseAndDeParseWithoutFromKeyword();
        }
        finally
        {
        }
}
}
