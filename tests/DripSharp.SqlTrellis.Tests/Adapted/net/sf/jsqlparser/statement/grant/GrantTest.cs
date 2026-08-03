// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Grant;

public class GrantTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testGrantPrivilege() {
string statement = "GRANT SELECT ON t1 TO u";
global::DripSharp.SqlTrellis.Statement.Grant.Grant grant = (global::DripSharp.SqlTrellis.Statement.Grant.Grant)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("t1", grant.getObjectName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(grant.getPrivileges()), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT", global::DripSharp.Runtime.JavaCompat.ListGet(grant.getPrivileges(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(grant.getUsers()), null);
global::DripSharp.Testing.JavaAssertions.Equal("u", global::DripSharp.Runtime.JavaCompat.ListGet(grant.getUsers(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, grant.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal((object)default!, grant.getRole(), null);
global::DripSharp.SqlTrellis.Statement.Grant.Grant created = new global::DripSharp.SqlTrellis.Statement.Grant.Grant().addPrivileges("SELECT").withObjectName("t1").addUsers("u");
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(grant, created);
}

public virtual void testGrantPrivileges() {
string statement = "GRANT SELECT, INSERT ON t1 TO u, u2";
global::DripSharp.SqlTrellis.Statement.Grant.Grant grant = (global::DripSharp.SqlTrellis.Statement.Grant.Grant)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("t1", grant.getObjectName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(grant.getPrivileges()), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, global::DripSharp.Runtime.JavaCompat.Any(global::DripSharp.Runtime.JavaCompat.Stream(grant.getPrivileges()), (s) => global::DripSharp.Runtime.JavaCompat.Equals(s, "SELECT")), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, global::DripSharp.Runtime.JavaCompat.Any(global::DripSharp.Runtime.JavaCompat.Stream(grant.getPrivileges()), (s) => global::DripSharp.Runtime.JavaCompat.Equals(s, "INSERT")), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(grant.getUsers()), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, global::DripSharp.Runtime.JavaCompat.Any(global::DripSharp.Runtime.JavaCompat.Stream(grant.getUsers()), (s) => global::DripSharp.Runtime.JavaCompat.Equals(s, "u")), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, global::DripSharp.Runtime.JavaCompat.Any(global::DripSharp.Runtime.JavaCompat.Stream(grant.getUsers()), (s) => global::DripSharp.Runtime.JavaCompat.Equals(s, "u2")), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, grant.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal((object)default!, grant.getRole(), null);
global::DripSharp.SqlTrellis.Statement.Grant.Grant created = new global::DripSharp.SqlTrellis.Statement.Grant.Grant().addPrivileges(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("SELECT", "INSERT")).withObjectName("t1").addUsers(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("u", "u2"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(grant, created);
}

public virtual void testGrantRole() {
string statement = "GRANT role1 TO u, u2";
global::DripSharp.SqlTrellis.Statement.Grant.Grant grant = (global::DripSharp.SqlTrellis.Statement.Grant.Grant)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal((object)default!, grant.getObjectName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((object)default!, grant.getPrivileges(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(grant.getUsers()), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, global::DripSharp.Runtime.JavaCompat.Any(global::DripSharp.Runtime.JavaCompat.Stream(grant.getUsers()), (s) => global::DripSharp.Runtime.JavaCompat.Equals(s, "u")), null);
global::DripSharp.Testing.JavaAssertions.Equal(true, global::DripSharp.Runtime.JavaCompat.Any(global::DripSharp.Runtime.JavaCompat.Stream(grant.getUsers()), (s) => global::DripSharp.Runtime.JavaCompat.Equals(s, "u2")), null);
global::DripSharp.Testing.JavaAssertions.Equal("role1", grant.getRole(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, grant.ToString(), null);
global::DripSharp.SqlTrellis.Statement.Grant.Grant created = new global::DripSharp.SqlTrellis.Statement.Grant.Grant().withRole("role1").addUsers(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("u", "u2"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(grant, created);
}

public virtual void testGrantQueryWithPrivileges() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("GRANT SELECT, INSERT, UPDATE, DELETE ON T1 TO ADMIN_ROLE");
}

public virtual void testGrantQueryWithRole() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("GRANT ROLE_1 TO TEST_ROLE_1, TEST_ROLE_2");
}

public virtual void testGrantSchemaParsingIssue1080() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("GRANT SELECT ON schema_name.table_name TO XYZ");
}

internal virtual void testPublicKeywordIssue2230() {
string sqlStr = "grant select on da380_now to public;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_34c98b8091d92ad7()
{
        try
        {
            this.testGrantPrivilege();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e1beff1879076261()
{
        try
        {
            this.testGrantPrivileges();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0371165c8113530f()
{
        try
        {
            this.testGrantQueryWithPrivileges();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9bc4f6f557344b49()
{
        try
        {
            this.testGrantQueryWithRole();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ac661447851904d()
{
        try
        {
            this.testGrantRole();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1bd1342fc47ff1c1()
{
        try
        {
            this.testGrantSchemaParsingIssue1080();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_87a16898b8192524()
{
        try
        {
            this.testPublicKeywordIssue2230();
        }
        finally
        {
        }
}
}
