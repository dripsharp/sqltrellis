// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class IfElseStatementTest {
public virtual void testSimpleIfElseStatement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin;", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin; ELSE CREATE TABLE tOrigin (ID VARCHAR(40));", true);
}

public virtual void testIfElseStatements1() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin1; ELSE CREATE TABLE tOrigin1 (ID VARCHAR (40));\n", "IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin2; ELSE CREATE TABLE tOrigin2 (ID VARCHAR (40));\n"), "IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin3; ELSE CREATE TABLE tOrigin3 (ID VARCHAR (40));\n");
global::DripSharp.SqlTrellis.Statement.Statements result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(sqlStr, result.ToString(), null);
}

public virtual void testIfElseStatements2() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin1;\n", "CREATE TABLE tOrigin2 (ID VARCHAR (40));\n"), "IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin3; ELSE CREATE TABLE tOrigin3 (ID VARCHAR (40));\n");
global::DripSharp.SqlTrellis.Statement.Statements result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(sqlStr, result.ToString(), null);
}

public virtual void testObjectBuilder() {
global::DripSharp.SqlTrellis.Statement.Statement ifStatement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * from dual");
global::DripSharp.SqlTrellis.Statement.Statement elseStatement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SELECT * from dual");
global::DripSharp.SqlTrellis.Statement.IfElseStatement ifElseStatement = new global::DripSharp.SqlTrellis.Statement.IfElseStatement(new global::DripSharp.SqlTrellis.Expression.NotExpression(), ifStatement);
ifElseStatement.setUsingSemicolonForIfStatement(true);
ifElseStatement.setElseStatement(elseStatement);
ifElseStatement.setUsingSemicolonForElseStatement(true);
global::DripSharp.Testing.JavaAssertions.Equal(ifElseStatement.isUsingSemicolonForIfStatement(), ifElseStatement.isUsingSemicolonForElseStatement(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.StringValueOf(ifElseStatement.getIfStatement()), global::DripSharp.Runtime.JavaCompat.StringValueOf(ifElseStatement.getElseStatement()), null);
global::DripSharp.Testing.JavaAssertions.NotNull(ifElseStatement.getCondition(), null);
}

public virtual void testValidation() {
string sqlStr = "IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin1;";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.FeatureSetValidation>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DROP)), sqlStr);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
}

public virtual void testTableNames() {
string sql = "IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin1;";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::System.Collections.Generic.IList<string> tableList = tablesNamesFinder.getTableList(stmt);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(tableList), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(tableList, "tOrigin1"), null);
}

[Xunit.Fact]
public void __Upstream_af519463804f54f5()
{
        try
        {
            this.testIfElseStatements1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51c531235578a33b()
{
        try
        {
            this.testIfElseStatements2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_730de8578744d2ac()
{
        try
        {
            this.testObjectBuilder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b876b2681871315f()
{
        try
        {
            this.testSimpleIfElseStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c24b9b9b1f845f1c()
{
        try
        {
            this.testTableNames();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_30dfbb5b0984b2dc()
{
        try
        {
            this.testValidation();
        }
        finally
        {
        }
}
}
