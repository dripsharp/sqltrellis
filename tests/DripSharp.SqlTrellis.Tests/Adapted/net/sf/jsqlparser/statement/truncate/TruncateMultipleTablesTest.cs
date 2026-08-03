// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Truncate;

public class TruncateMultipleTablesTest {
private global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testTruncate2Tables() {
string statement = "TRUncATE TABLE myschema.mytab, myschema2.mytab2";
global::DripSharp.SqlTrellis.Statement.Truncate.Truncate truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("myschema2", truncate.getTable().getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema2.mytab2", truncate.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement.ToUpper(), truncate.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema2.mytab2", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 1).getFullyQualifiedName(), null);
statement = "TRUncATE   TABLE    mytab,     my2ndtab";
string toStringStatement = "TRUncATE TABLE mytab, my2ndtab";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("my2ndtab", truncate.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(toStringStatement.ToUpper(), truncate.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("my2ndtab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 1).getFullyQualifiedName(), null);
statement = "TRUNCATE TABLE mytab, my2ndtab CASCADE";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("my2ndtab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 1).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True(truncate.getCascade(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, truncate.ToString(), null);
}

public virtual void testTruncatePostgresqlWithoutTableNames() {
string statement = "TRUncATE myschema.mytab, myschema2.mytab2";
global::DripSharp.SqlTrellis.Statement.Truncate.Truncate truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("myschema2", truncate.getTable().getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema2.mytab2", truncate.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement.ToUpper(), truncate.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema.mytab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myschema2.mytab2", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 1).getFullyQualifiedName(), null);
statement = "TRUncATE      mytab,     my2ndtab";
string toStringStatement = "TRUncATE mytab, my2ndtab";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("my2ndtab", truncate.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(toStringStatement.ToUpper(), truncate.ToString().ToUpper(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("my2ndtab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 1).getFullyQualifiedName(), null);
statement = "TRUNCATE mytab, my2ndtab CASCADE";
truncate = (global::DripSharp.SqlTrellis.Statement.Truncate.Truncate)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 0).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("my2ndtab", global::DripSharp.Runtime.JavaCompat.ListGet(truncate.getTables(), 1).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True(truncate.getCascade(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, truncate.ToString(), null);
}

public virtual void testTruncateDeparse() {
string statement = "TRUNCATE TABLE foo, bar";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Truncate.Truncate().withTables(global::DripSharp.Runtime.JavaCompat.ListOf<global::DripSharp.SqlTrellis.Schema.Table>(new global::DripSharp.SqlTrellis.Schema.Table("foo"), new global::DripSharp.SqlTrellis.Schema.Table("bar"))).withTableToken(true), statement);
}

public virtual void testTruncateCascadeDeparse() {
string statement = "TRUNCATE TABLE foo, bar CASCADE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Truncate.Truncate().withTables(global::DripSharp.Runtime.JavaCompat.ListOf<global::DripSharp.SqlTrellis.Schema.Table>(new global::DripSharp.SqlTrellis.Schema.Table("foo"), new global::DripSharp.SqlTrellis.Schema.Table("bar"))).withTableToken(true).withCascade(true), statement);
}

public virtual void testTruncateDoesNotAllowOnlyWithMultipleTables() {
string statement = "TRUNCATE TABLE ONLY foo, bar";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => this.parserManager.parse(new global::System.IO.StringReader(statement)), null);
}

[Xunit.Fact]
public void __Upstream_e573c89e9e0a36cb()
{
        try
        {
            this.testTruncate2Tables();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d02dd8a148331627()
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
public void __Upstream_490798725f27243f()
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
public void __Upstream_334641de9a427909()
{
        try
        {
            this.testTruncateDoesNotAllowOnlyWithMultipleTables();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f736b69499b63419()
{
        try
        {
            this.testTruncatePostgresqlWithoutTableNames();
        }
        finally
        {
        }
}
}
