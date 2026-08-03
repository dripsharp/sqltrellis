// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create.Schema;

public class CreateSchemaTest {
public virtual void testSimpleCreateSchema() {
string statement = "CREATE SCHEMA myschema";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Schema.CreateSchema().withSchemaName("myschema"), statement);
}

public virtual void testSimpleCreateWithAuth() {
string statement = "CREATE SCHEMA myschema AUTHORIZATION myauth";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Schema.CreateSchema().withSchemaName("myschema").withAuthorization("myauth"), statement);
}

internal virtual void testIfNotExistsIssue2061() {
string sqlStr = "CREATE SCHEMA IF NOT EXISTS sales_kpi";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
}

[Xunit.Fact]
public void __Upstream_76c28413a6e5b402()
{
        try
        {
            this.testIfNotExistsIssue2061();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39c6239cd4ab8069()
{
        try
        {
            this.testSimpleCreateSchema();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ceaf08598d7a1388()
{
        try
        {
            this.testSimpleCreateWithAuth();
        }
        finally
        {
        }
}
}
