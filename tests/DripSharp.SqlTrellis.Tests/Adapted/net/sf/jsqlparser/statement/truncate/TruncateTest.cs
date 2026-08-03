// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Truncate;

public class TruncateTest {
private global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testTruncate() {
string statement = "TRUncATE TABLE myschema.mytab";
global::DripSharp.SqlTrellis.Statement.Truncate.Truncate truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("myschema", truncate.getTable().getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytab", truncate.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement.ToUpper(), truncate.ToString().ToUpper(), null);
statement = "TRUncATE   TABLE    mytab";
string toStringStatement = "TRUncATE TABLE mytab";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", truncate.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(toStringStatement.ToUpper(), truncate.ToString().ToUpper(), null);
statement = "TRUNCATE TABLE mytab CASCADE";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(statement, truncate.ToString(), null);
statement = "TRUNCATE TABLE ONLY mytab CASCADE";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(statement, truncate.ToString(), null);
}

public virtual void testTruncatePostgresqlWithoutTableName() {
string statement = "TRUncATE myschema.mytab";
global::DripSharp.SqlTrellis.Statement.Truncate.Truncate truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("myschema", truncate.getTable().getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytab", truncate.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("TRUNCATE MYSCHEMA.MYTAB", truncate.ToString().ToUpper(), null);
statement = "TRUncATE       mytab";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", truncate.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("TRUNCATE MYTAB", truncate.ToString().ToUpper(), null);
statement = "TRUNCATE  mytab CASCADE";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("TRUNCATE MYTAB CASCADE", truncate.ToString().ToUpper(), null);
}

public virtual void testTruncateDeparse() {
string statement = "TRUNCATE TABLE foo";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Truncate.Truncate().withTable(new global::DripSharp.SqlTrellis.Schema.Table("foo")).withTableToken(true), statement);
}

public virtual void testTruncateCascadeDeparse() {
string statement = "TRUNCATE TABLE foo CASCADE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Truncate.Truncate().withTable(new global::DripSharp.SqlTrellis.Schema.Table("foo")).withTableToken(true).withCascade(true), statement);
}

public virtual void testTruncateOnlyDeparse() {
string statement = "TRUNCATE TABLE ONLY foo";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Truncate.Truncate().withTable(new global::DripSharp.SqlTrellis.Schema.Table("foo")).withTableToken(true).withOnly(true), statement);
}

public virtual void testTruncateOnlyAndCascadeDeparse() {
string statement = "TRUNCATE ONLY foo CASCADE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Truncate.Truncate().withTable(new global::DripSharp.SqlTrellis.Schema.Table("foo")).withCascade(true).withOnly(true), statement);
}

public virtual void throwsParseWhenOnlyUsedWithMultipleTables() {
string statement = "TRUNCATE TABLE ONLY foo, bar";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => this.parserManager.parse(new global::System.IO.StringReader(statement)), null);
}

[Xunit.Fact]
public void __Upstream_1c028525dae3ea74()
{
        try
        {
            this.testTruncate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5b1765720b4b153()
{
        try
        {
            this.testTruncateCascadeDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_373e4a7e0a6ac22f()
{
        try
        {
            this.testTruncateDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b6d6b41e29c811d5()
{
        try
        {
            this.testTruncateOnlyAndCascadeDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b48a75cb5de8696()
{
        try
        {
            this.testTruncateOnlyDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9bb2481672e68305()
{
        try
        {
            this.testTruncatePostgresqlWithoutTableName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8543d11e4604071c()
{
        try
        {
            this.throwsParseWhenOnlyUsedWithMultipleTables();
        }
        finally
        {
        }
}
}
