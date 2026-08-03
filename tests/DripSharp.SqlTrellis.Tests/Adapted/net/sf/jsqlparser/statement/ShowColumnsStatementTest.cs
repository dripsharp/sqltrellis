// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ShowColumnsStatementTest {
public virtual void testSimpleUse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW COLUMNS FROM mydatabase");
}

[Xunit.Fact]
public void __Upstream_ce00b4e8a3959eb3()
{
        try
        {
            this.testSimpleUse();
        }
        finally
        {
        }
}
}
