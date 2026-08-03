// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class AliasTest {
internal virtual void testUDTF() {
string sqlStr = "select udtf_1(words) as (a1, a2) from tab";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testLateralViewMultipleColumns() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT k, v \n", "FROM table \n"), "LATERAL VIEW EXPLODE(a) exploded_data AS k, v;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_efde72d5e36e38b7()
{
        try
        {
            this.testLateralViewMultipleColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_46b47c2711212117()
{
        try
        {
            this.testUDTF();
        }
        finally
        {
        }
}
}
