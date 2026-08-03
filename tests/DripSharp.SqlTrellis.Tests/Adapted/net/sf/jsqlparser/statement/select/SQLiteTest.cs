// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SQLiteTest {
internal virtual void testInsertOrReplaceUpsert() {
string sqlString = "INSERT OR REPLACE INTO kjobLocks VALUES (?, ?, ?)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

[Xunit.Fact]
public void __Upstream_b2c73ecc3fb9490b()
{
        try
        {
            this.testInsertOrReplaceUpsert();
        }
        finally
        {
        }
}
}
