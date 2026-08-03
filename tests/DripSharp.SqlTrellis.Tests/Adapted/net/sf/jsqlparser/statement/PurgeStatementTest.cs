// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class PurgeStatementTest {
public virtual void testStatement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE TABLE testtable", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE TABLE cfe.testtable", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE INDEX testtable_idx1", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE INDEX cfe.testtable_idx1", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE RECYCLEBIN", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE DBA_RECYCLEBIN", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE TABLESPACE my_table_space", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("PURGE TABLESPACE my_table_space USER cfe", true);
}

public virtual void testStatementVisitorAdaptor() {
string sqlStr = "PURGE TABLE testtable";
((global::DripSharp.SqlTrellis.Statement.Statement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr))).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object>()));
}

public virtual void testTableNamesFinder() {
string sqlStr = "PURGE TABLE testtable";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
global::System.Collections.Generic.IList<string> tables = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>().getTableList(statement);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(tables), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(tables, "testtable"), null);
}

public virtual void testValidator() {
string sqlStr = "PURGE TABLE testtable";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testObjectAccess() {
string sqlStr = "PURGE TABLESPACE my_table_space USER cfe";
global::DripSharp.SqlTrellis.Statement.PurgeStatement purgeStatement = (global::DripSharp.SqlTrellis.Statement.PurgeStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
purgeStatement.setUserName("common");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.PurgeObjectType.TABLESPACE, purgeStatement.getPurgeObjectType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("my_table_space", purgeStatement.getObject(), null);
global::DripSharp.Testing.JavaAssertions.Equal("common", purgeStatement.getUserName(), null);
}

[Xunit.Fact]
public void __Upstream_7212822cfb02bfdb()
{
        try
        {
            this.testObjectAccess();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_12b3c4e9d73ed53f()
{
        try
        {
            this.testStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_75f3cb5fcbc823a1()
{
        try
        {
            this.testStatementVisitorAdaptor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_685d677824772682()
{
        try
        {
            this.testTableNamesFinder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_21814eac9da7ce5c()
{
        try
        {
            this.testValidator();
        }
        finally
        {
        }
}
}
