// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ResetStatementTest {
public virtual void tesResetTZ() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("RESET Time Zone");
}

public virtual void tesResetAll() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("RESET ALL");
}

public virtual void testObject() {
global::DripSharp.SqlTrellis.Statement.ResetStatement resetStatement = new global::DripSharp.SqlTrellis.Statement.ResetStatement();
global::DripSharp.Testing.JavaAssertions.NotNull(resetStatement.getName(), null);
resetStatement.add("something");
resetStatement.setName("somethingElse");
global::DripSharp.Testing.JavaAssertions.Equal("somethingElse", resetStatement.getName(), null);
}

[Xunit.Fact]
public void __Upstream_49403cbfdd10436a()
{
        try
        {
            this.tesResetAll();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_856d64e012fd4845()
{
        try
        {
            this.tesResetTZ();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4101d9c596a4b6a4()
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
