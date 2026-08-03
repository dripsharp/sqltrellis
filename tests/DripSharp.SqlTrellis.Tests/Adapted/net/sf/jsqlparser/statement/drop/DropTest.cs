// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Drop;

public class DropTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testDrop() {
string statement = "DROP TABLE mytab";
global::DripSharp.SqlTrellis.Statement.Drop.Drop parsed = (global::DripSharp.SqlTrellis.Statement.Drop.Drop)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("TABLE", parsed.getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", parsed.getName().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", parsed), null);
global::DripSharp.SqlTrellis.Statement.Drop.Drop created = new global::DripSharp.SqlTrellis.Statement.Drop.Drop().withType("TABLE").withName(new global::DripSharp.SqlTrellis.Schema.Table("mytab"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDropIndex() {
string statement = "DROP INDEX myindex CASCADE";
global::DripSharp.SqlTrellis.Statement.Drop.Drop parsed = (global::DripSharp.SqlTrellis.Statement.Drop.Drop)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("INDEX", parsed.getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex", parsed.getName().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("CASCADE", global::DripSharp.Runtime.JavaCompat.ListGet(parsed.getParameters(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", parsed), null);
global::DripSharp.SqlTrellis.Statement.Drop.Drop created = new global::DripSharp.SqlTrellis.Statement.Drop.Drop().withType("INDEX").withName(new global::DripSharp.SqlTrellis.Schema.Table("myindex")).addParameters("CASCADE");
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDropIndexOnTable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP INDEX idx ON abc");
}

public virtual void testDrop2() {
global::DripSharp.SqlTrellis.Statement.Drop.Drop drop = (global::DripSharp.SqlTrellis.Statement.Drop.Drop)(this.parserManager.parse(new global::System.IO.StringReader("DROP TABLE \"testtable\""))!);
global::DripSharp.Testing.JavaAssertions.Equal("TABLE", drop.getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\"testtable\"", drop.getName().getFullyQualifiedName(), null);
}

public virtual void testDropIfExists() {
string statement = "DROP TABLE IF EXISTS my_table";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Drop.Drop created = new global::DripSharp.SqlTrellis.Statement.Drop.Drop().withType("TABLE").withIfExists(true).withName(new global::DripSharp.SqlTrellis.Schema.Table("my_table"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDropRestrictIssue510() {
string statement = "DROP TABLE TABLE2 RESTRICT";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Drop.Drop created = new global::DripSharp.SqlTrellis.Statement.Drop.Drop().withType("TABLE").withName(new global::DripSharp.SqlTrellis.Schema.Table("TABLE2")).addParameters(global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("RESTRICT"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDropViewIssue545() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP VIEW myview");
}

public virtual void testDropViewIssue545_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP VIEW IF EXISTS myview");
}

public virtual void testDropMaterializedView() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP MATERIALIZED VIEW myview");
}

public virtual void testDropSchemaIssue855() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP SCHEMA myschema");
}

public virtual void testDropSequence() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP SEQUENCE mysequence");
}

public virtual void testOracleMultiColumnDrop() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE foo DROP (bar, baz) CASCADE");
}

public virtual void testUniqueFunctionDrop() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP FUNCTION myFunc");
}

public virtual void testZeroArgDropFunction() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP FUNCTION myFunc()");
}

public virtual void testDropFunctionWithSimpleType() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP FUNCTION myFunc(integer, varchar)");
}

public virtual void testDropFunctionWithNameAndType() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP FUNCTION myFunc(amount integer, name varchar)");
}

public virtual void testDropFunctionWithNameAndParameterizedType() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DROP FUNCTION myFunc(amount integer, name varchar(255))");
}

internal virtual void dropTemporaryTableTestIssue1712() {
string sqlStr = "drop temporary table if exists tmp_MwYT8N0z";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a00eb006f3dbcb8f()
{
        try
        {
            this.dropTemporaryTableTestIssue1712();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec1ee3f921d43c96()
{
        try
        {
            this.testDrop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec495b24ebf163d7()
{
        try
        {
            this.testDrop2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b247f0b2d249123()
{
        try
        {
            this.testDropFunctionWithNameAndParameterizedType();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_23b7d98b5c9d6560()
{
        try
        {
            this.testDropFunctionWithNameAndType();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_05a7897eb00f8817()
{
        try
        {
            this.testDropFunctionWithSimpleType();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_627637119b69470a()
{
        try
        {
            this.testDropIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_583bec1e78e90ed1()
{
        try
        {
            this.testDropIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44860d7372327bfd()
{
        try
        {
            this.testDropIndexOnTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c25ac24e6d940934()
{
        try
        {
            this.testDropMaterializedView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_caf539492c5bb381()
{
        try
        {
            this.testDropRestrictIssue510();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3368dfdf52ea7eb2()
{
        try
        {
            this.testDropSchemaIssue855();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5c4cdd27cf6bf423()
{
        try
        {
            this.testDropSequence();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_17df94d78064a11b()
{
        try
        {
            this.testDropViewIssue545();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9d9589ae693468c0()
{
        try
        {
            this.testDropViewIssue545_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51daf0ce24dc8ecc()
{
        try
        {
            this.testOracleMultiColumnDrop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_97bb58b8dafd0b15()
{
        try
        {
            this.testUniqueFunctionDrop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_658c571c448b1809()
{
        try
        {
            this.testZeroArgDropFunction();
        }
        finally
        {
        }
}
}
