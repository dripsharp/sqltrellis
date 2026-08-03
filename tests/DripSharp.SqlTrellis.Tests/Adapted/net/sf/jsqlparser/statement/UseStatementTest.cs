// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class UseStatementTest {
public virtual void testUseSchema() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("USE SCHEMA myschema");
}

public virtual void testSimpleUse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("USE mydatabase");
}

[Xunit.Fact]
public void __Upstream_17a82bbd89fc32e6()
{
        try
        {
            this.testSimpleUse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9192d02ce9673da5()
{
        try
        {
            this.testUseSchema();
        }
        finally
        {
        }
}
}
