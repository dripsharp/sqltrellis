// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class StatementsTest {
public virtual void testStatements() {
string sqlStr = "select * from mytable; select * from mytable2;";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM mytable;\nSELECT * FROM mytable2;\n", statements.ToString(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
}

public virtual void testStatementsProblem() {
string sqls = ";;select * from mytable;;select * from mytable2;;;";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqls);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM mytable;\nSELECT * FROM mytable2;\n", statements.ToString(), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
}

public virtual void testStatementsErrorRecovery() {
string sqlStr = "select * from mytable; select from;";
global::DripSharp.SqlTrellis.Parser.CCJSqlParser parser = new global::DripSharp.SqlTrellis.Parser.CCJSqlParser(new global::DripSharp.SqlTrellis.Parser.StringProvider(sqlStr));
parser.setErrorRecovery(true);
global::DripSharp.SqlTrellis.Statement.Statements parseStatements = parser.Statements();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(parseStatements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(parseStatements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(parseStatements, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(parser.getParseErrors()), null);
}

public virtual void testStatementsErrorRecovery2() {
string sqls = "select * from1 table;";
global::DripSharp.SqlTrellis.Parser.CCJSqlParser parser = new global::DripSharp.SqlTrellis.Parser.CCJSqlParser(new global::DripSharp.SqlTrellis.Parser.StringProvider(sqls));
parser.setErrorRecovery(true);
global::DripSharp.SqlTrellis.Statement.Statements parseStatements = parser.Statements();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(parseStatements), null);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(parseStatements, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(parser.getParseErrors()), null);
}

public virtual void testStatementsErrorRecovery3() {
global::DripSharp.SqlTrellis.Parser.CCJSqlParser parser = new global::DripSharp.SqlTrellis.Parser.CCJSqlParser("select * from mytable; select from; select * from mytable2");
global::DripSharp.SqlTrellis.Statement.Statements statements = parser.withErrorRecovery().Statements();
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 2), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(parser.getParseErrors()), null);
}

public virtual void testStatementsErrorRecovery4() {
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements("select * from mytable; select from; select * from mytable2; select 4 from dual;", (parser) => parser.withUnsupportedStatements());
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 2), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 3), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), "select from", true);
}

[Xunit.Fact]
public void __Upstream_97fa9e2f1ee5ea9a()
{
        try
        {
            this.testStatements();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_67effbc6d18d38b4()
{
        try
        {
            this.testStatementsErrorRecovery();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58a1b477ac8d7f91()
{
        try
        {
            this.testStatementsErrorRecovery2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_33bb2d7eb39a45e5()
{
        try
        {
            this.testStatementsErrorRecovery3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_64a2ab5818f341b6()
{
        try
        {
            this.testStatementsErrorRecovery4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_38b57d55549d166a()
{
        try
        {
            this.testStatementsProblem();
        }
        finally
        {
        }
}
}
