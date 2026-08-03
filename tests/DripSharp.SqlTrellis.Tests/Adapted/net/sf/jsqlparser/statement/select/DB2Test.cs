// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class DB2Test {
internal virtual void testDB2SpecialRegister() {
string sqlStr = "SELECT * FROM TABLE1 where COL_WITH_TIMESTAMP <= CURRENT TIMESTAMP - CURRENT TIMEZONE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_7a17c96ca410abe6()
{
        try
        {
            this.testDB2SpecialRegister();
        }
        finally
        {
        }
}
}
