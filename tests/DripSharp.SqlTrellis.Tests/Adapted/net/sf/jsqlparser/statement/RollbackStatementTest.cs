// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class RollbackStatementTest {
public virtual void testObject() {
global::DripSharp.SqlTrellis.Statement.RollbackStatement rollbackStatement = new global::DripSharp.SqlTrellis.Statement.RollbackStatement().withUsingWorkKeyword(true).withUsingSavepointKeyword(true).withSavepointName("mySavePoint").withForceDistributedTransactionIdentifier("$ForceDistributedTransactionIdentifier");
global::DripSharp.Testing.JavaAssertions.True(rollbackStatement.isUsingSavepointKeyword(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mySavePoint", rollbackStatement.getSavepointName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("$ForceDistributedTransactionIdentifier", rollbackStatement.getForceDistributedTransactionIdentifier(), null);
}

[Xunit.Fact]
public void __Upstream_e304578a76f93ae4()
{
        try
        {
            this.testObject();
        }
        finally
        {
        }
}
}
