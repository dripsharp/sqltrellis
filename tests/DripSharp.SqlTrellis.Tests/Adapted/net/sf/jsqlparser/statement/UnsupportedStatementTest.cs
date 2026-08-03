// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class UnsupportedStatementTest {
public virtual void testSingleUnsupportedStatement() {
string sqlStr = "this is an unsupported statement";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withUnsupportedStatements(true));
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withUnsupportedStatements(false));
}, null);
}

public virtual void testUnsupportedStatementsFirstInBlock() {
string sqlStr = "This is an unsupported statement; Select * from dual; Select * from dual;";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(true));
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 2), null);
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(false));
}, null);
}

public virtual void testUnsupportedStatementsMiddleInBlock() {
string sqlStr = "Select * from dual; This is an unsupported statement; Select * from dual;";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(true).withErrorRecovery(true));
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 2), null);
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(false));
}, null);
}

public virtual void testTwoUnsupportedStatementsMiddleInBlock() {
string sqlStr = "Select * from dual; This is an unsupported statement; Some more rubbish; Select * from dual;";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(true).withErrorRecovery(true));
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 2), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.Select>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 3), null);
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(false));
}, null);
}

public virtual void testCaptureRestIssue1993() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("Select 1; ALTER TABLE \"inter\".\"inter_user_rec\" \n", "  OWNER TO \"postgres\"; select 2; select 3;");
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withErrorRecovery(false));
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testAlter() {
string sqlStr = "ALTER INDEX idx_t_fa RENAME TO idx_t_fb";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(statement, null);
}

internal virtual void testRefresh() {
string sqlStr = "REFRESH MATERIALIZED VIEW CONCURRENTLY my_view WITH NO DATA";
global::DripSharp.SqlTrellis.Statement.Statements statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(statement, 0) is global::DripSharp.SqlTrellis.Statement.UnsupportedStatement), null);
}

internal virtual void testCreate() {
string sqlStr = "create trigger stud_marks before INSERT on Student for each row set Student.total = Student.subj1 + Student.subj2, Student.per = Student.total * 60 / 100";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.Testing.JavaAssertions.True((statement is global::DripSharp.SqlTrellis.Statement.UnsupportedStatement), null);
sqlStr = "create domain TNOTIFICATION_ACTION as ENUM ('ADD', 'CHANGE', 'DEL')";
statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.Testing.JavaAssertions.True((statement is global::DripSharp.SqlTrellis.Statement.UnsupportedStatement), null);
}

internal virtual void testFunctions() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE OR REPLACE FUNCTION func_example(foo integer)\n", "RETURNS integer AS $$\n"), "BEGIN\n"), "  RETURN foo + 1;\n"), "END\n"), "$$ LANGUAGE plpgsql;\n"), "\n"), "CREATE OR REPLACE FUNCTION func_example2(IN foo integer, OUT bar integer)\n"), "AS $$\n"), "BEGIN\n"), "    SELECT foo + 1 INTO bar;\n"), "END\n"), "$$ LANGUAGE plpgsql;");
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
}

internal virtual void testSQLServerSetStatementIssue1984() {
string sqlStr = "SET IDENTITY_INSERT tb_inter_d2v_transfer on";
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withUnsupportedStatements(true));
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), sqlStr, true);
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withUnsupportedStatements(true));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(statement, null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(statement, sqlStr, true);
}

internal virtual void testInformixSetStatementIssue1945() {
string sqlStr = "set isolation to dirty read;";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withUnsupportedStatements(true));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(statement, null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(statement, sqlStr, true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("set isolation to dirty read;", true, (parser) => parser.withUnsupportedStatements());
}

internal virtual void testRedshiftSetStatementIssue1708() {
global::DripSharp.SqlTrellis.Statement.Statement st = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET x TO y;", true, (parser) => parser.withUnsupportedStatements());
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(st, null);
}

[Xunit.Fact]
public void __Upstream_52ef90f7db0dc7d3()
{
        try
        {
            this.testAlter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e20d71fdc64d239f()
{
        try
        {
            this.testCaptureRestIssue1993();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6849de9fbeb91814()
{
        try
        {
            this.testCreate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e610a48a573bc342()
{
        try
        {
            this.testFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_549fc806a5967bf6()
{
        try
        {
            this.testInformixSetStatementIssue1945();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3662eac07d6ab95a()
{
        try
        {
            this.testRedshiftSetStatementIssue1708();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6284ff0727b328d1()
{
        try
        {
            this.testRefresh();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ce4ae0ee52ec9d94()
{
        try
        {
            this.testSQLServerSetStatementIssue1984();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aee19426ab5abb8a()
{
        try
        {
            this.testSingleUnsupportedStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_145a2d906ae44245()
{
        try
        {
            this.testTwoUnsupportedStatementsMiddleInBlock();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_6b82117ec3aaea63()
{
        try
        {
            this.testUnsupportedStatementsFirstInBlock();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8eb968a6655bfe33()
{
        try
        {
            this.testUnsupportedStatementsMiddleInBlock();
        }
        finally
        {
        }
}
}
