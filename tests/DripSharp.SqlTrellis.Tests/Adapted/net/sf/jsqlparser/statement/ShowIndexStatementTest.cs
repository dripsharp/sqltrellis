// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ShowIndexStatementTest {
public virtual void testSimpleUse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW INDEX FROM mydatabase");
}

[Xunit.Fact]
public void __Upstream_82f3bd91eec03c81()
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
