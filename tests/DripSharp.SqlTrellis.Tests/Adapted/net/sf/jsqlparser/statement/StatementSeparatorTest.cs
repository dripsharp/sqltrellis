// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class StatementSeparatorTest {
internal virtual void testDoubleNewLine() {
string sqlStr = "SELECT * FROM DUAL\n\n\nSELECT * FROM DUAL\n\n\n\nSELECT * FROM dual\n\n\n\n\nSELECT * FROM dual";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testNewLineSlash() {
string sqlStr = "SELECT * FROM DUAL\n\n\nSELECT * FROM DUAL\n/\nSELECT * FROM dual\n/\n\nSELECT * FROM dual";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testNewLineGo() {
string sqlStr = "SELECT * FROM DUAL\n\n\nSELECT * FROM DUAL\nGO\nSELECT * FROM dual\ngo\n\nSELECT * FROM dual\ngo";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testNewLineNotGoIssue() {
string sqlStr = "select name,\ngoods from test_table";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testOracleBlock() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("BEGIN\n", "\n"), "SELECT * FROM TABLE;\n"), "\n"), "END\n"), "/\n");
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testMSSQLBlock() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("create view MyView1 as\n", "select Id,Name from table1\n"), "go\n"), "create view MyView2 as\n"), "select Id,Name from table1\n"), "go");
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testSOQLIncludes() {
string sqlStr = "select name,\ngoods from test_table where option includes ('option1', 'option2')";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testSOQLExcludes() {
string sqlStr = "select name,\ngoods from test_table where option excludes ('option1', 'option2')";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_82f29e9b9364c973()
{
        try
        {
            this.testDoubleNewLine();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5e0ebeb83215f7dc()
{
        try
        {
            this.testMSSQLBlock();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9eaf14bd76ab72f9()
{
        try
        {
            this.testNewLineGo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5d9d35a1e42fbd98()
{
        try
        {
            this.testNewLineNotGoIssue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5e80d76769d1071c()
{
        try
        {
            this.testNewLineSlash();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ab7e9c8dd77dfad()
{
        try
        {
            this.testOracleBlock();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_241a29ff9593d59d()
{
        try
        {
            this.testSOQLExcludes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e6c63b10d0e5f50()
{
        try
        {
            this.testSOQLIncludes();
        }
        finally
        {
        }
}
}
