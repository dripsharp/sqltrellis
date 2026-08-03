// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class SavepointRollbackCommitTest {
public virtual void testSavepoint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SAVEPOINT banda_sal", true);
}

public virtual void testRollback() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK WORK", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK TO banda_sal", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK TO SAVEPOINT banda_sal", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK WORK TO banda_sal", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK WORK TO SAVEPOINT banda_sal", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK FORCE '25.32.87'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ROLLBACK WORK FORCE '25.32.87'", true);
}

public virtual void testCommit() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("COMMIT");
}

[Xunit.Fact]
public void __Upstream_829e728e66a7a7df()
{
        try
        {
            this.testCommit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10d0b5d675da9390()
{
        try
        {
            this.testRollback();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6f4f2b092df9722f()
{
        try
        {
            this.testSavepoint();
        }
        finally
        {
        }
}
}
