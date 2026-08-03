// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Alter;

public class RenameTableStatementTest {
public virtual void testStatement() {
string sqlStr = "RENAME oldTableName TO newTableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "RENAME TABLE old_table TO backup_table, new_table TO old_table";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "RENAME TABLE IF EXISTS old_table WAIT 20 TO backup_table, new_table TO old_table";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "RENAME TABLE IF EXISTS old_table NOWAIT TO backup_table, new_table TO old_table";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testStatementVisitorAdaptor() {
string sqlStr = "RENAME oldTableName TO newTableName";
((global::DripSharp.SqlTrellis.Statement.Statement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr))).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object>()));
}

public virtual void testTableNamesFinder() {
string sqlStr = "RENAME oldTableName TO newTableName";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
global::System.Collections.Generic.IList<string> tables = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>().getTableList(statement);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(tables), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(tables, "oldTableName"), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(tables, "newTableName"), null);
}

public virtual void testValidator() {
string sqlStr = "RENAME oldTableName TO newTableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
sqlStr = "ALTER TABLE public.oldTableName RENAME TO newTableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
sqlStr = "ALTER TABLE IF EXISTS public.oldTableName RENAME TO newTableName";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}

public virtual void testObjectAccess() {
global::DripSharp.SqlTrellis.Schema.Table oldTable = new global::DripSharp.SqlTrellis.Schema.Table("oldTableName");
global::DripSharp.SqlTrellis.Schema.Table newTable = new global::DripSharp.SqlTrellis.Schema.Table("newTableName");
global::DripSharp.SqlTrellis.Statement.Alter.RenameTableStatement renameTableStatement = new global::DripSharp.SqlTrellis.Statement.Alter.RenameTableStatement(oldTable, newTable);
renameTableStatement.withUsingTableKeyword(true).setUsingTableKeyword(false);
renameTableStatement.withUsingIfExistsKeyword(true).setUsingIfExistsKeyword(false);
renameTableStatement.withWaitDirective("NOWAIT").setWaitDirective("WAIT 20");
global::DripSharp.Testing.JavaAssertions.False(renameTableStatement.isTableNamesEmpty(), null);
global::DripSharp.Testing.JavaAssertions.True((renameTableStatement.getTableNamesSize() > 0), null);
global::DripSharp.Testing.JavaAssertions.False(renameTableStatement.isUsingTableKeyword(), null);
global::DripSharp.Testing.JavaAssertions.False(renameTableStatement.isUsingIfExistsKeyword(), null);
global::DripSharp.Testing.JavaAssertions.Equal("WAIT 20", renameTableStatement.getWaitDirective(), null);
}

[Xunit.Fact]
public void __Upstream_1c99d793b57ac7ea()
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
public void __Upstream_19270661a0b713f2()
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
public void __Upstream_8bb36b29c7790447()
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
public void __Upstream_6d1bfac3d222b472()
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
public void __Upstream_25da1798417a333c()
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
