// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Alter;

public class AlterTest {
public virtual void testAlterTableAddColumn() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable ADD COLUMN mycolumn varchar (255)");
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExp = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.NotNull(alterExp, null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> colDataTypes = alterExp.getColDataTypeList();
global::DripSharp.Testing.JavaAssertions.Equal("mycolumn", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("varchar (255)", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 0).getColDataType().ToString(), null);
}

public virtual void testAlterTableAddColumnsWhitespace() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE test_catalog.test20241014.tt ADD COLUMNS (apples string, bees int)");
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("test_catalog.test20241014.tt", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExp = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.NotNull(alterExp, null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> colDataTypes = alterExp.getColDataTypeList();
global::DripSharp.Testing.JavaAssertions.Equal("apples", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("string", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 0).getColDataType().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bees", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("int", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 1).getColDataType().ToString(), null);
}

public virtual void testAlterTableAddColumn_ColumnKeyWordImplicit() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable ADD mycolumn varchar (255)");
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExp = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.NotNull(alterExp, null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> colDataTypes = alterExp.getColDataTypeList();
global::DripSharp.Testing.JavaAssertions.Equal("mycolumn", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("varchar (255)", global::DripSharp.Runtime.JavaCompat.ListGet(colDataTypes, 0).getColDataType().ToString(), null);
}

public virtual void testAlterTableBackBrackets() {
string sql = "ALTER TABLE tablename add column (field  string comment 'aaaaa')";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql)!);
global::DripSharp.Testing.JavaAssertions.Equal("tablename", alter.getTable().ToString(), null);
string sql2 = "ALTER TABLE tablename add column (field  string comment 'aaaaa', field2 string comment 'bbbbb');";
global::DripSharp.SqlTrellis.Statement.Statement statement2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql2);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter2 = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(statement2!);
global::DripSharp.Testing.JavaAssertions.Equal("tablename", alter2.getTable().ToString(), null);
}

public virtual void testAlterTableIssue1815() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE cers_record_10 RENAME INDEX idx_cers_record_1_gmtcreate TO idx_cers_record_10_gmtcreate");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE cers_record_10 RENAME KEY k_cers_record_1_gmtcreate TO k_cers_record_10_gmtcreate");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE cers_record_10 RENAME CONSTRAINT cst_cers_record_1_gmtcreate TO cst_cers_record_10_gmtcreate");
}

public virtual void testAlterTablePrimaryKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id)");
}

public virtual void testAlterTablePrimaryKeyDeferrable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id) DEFERRABLE");
}

public virtual void testAlterTablePrimaryKeyNotDeferrable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id) NOT DEFERRABLE");
}

public virtual void testAlterTablePrimaryKeyValidate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id) VALIDATE");
}

public virtual void testAlterTablePrimaryKeyNoValidate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id) NOVALIDATE");
}

public virtual void testAlterTablePrimaryKeyDeferrableValidate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id) DEFERRABLE VALIDATE");
}

public virtual void testAlterTablePrimaryKeyDeferrableDisableNoValidate() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD PRIMARY KEY (id) DEFERRABLE DISABLE NOVALIDATE");
}

public virtual void testAlterTableUniqueKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE `schema_migrations` ADD UNIQUE KEY `unique_schema_migrations` (`version`)");
}

public virtual void testAlterTableForgeignKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id) ON DELETE CASCADE");
}

public virtual void testAlterTableAddConstraint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE RESOURCELINKTYPE ADD CONSTRAINT FK_RESOURCELINKTYPE_PARENTTYPE_PRIMARYKEY FOREIGN KEY (PARENTTYPE_PRIMARYKEY) REFERENCES RESOURCETYPE(PRIMARYKEY)");
}

public virtual void testAlterTableAddConstraintWithConstraintState() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE RESOURCELINKTYPE ADD CONSTRAINT FK_RESOURCELINKTYPE_PARENTTYPE_PRIMARYKEY FOREIGN KEY (PARENTTYPE_PRIMARYKEY) REFERENCES RESOURCETYPE(PRIMARYKEY) DEFERRABLE DISABLE NOVALIDATE");
}

public virtual void testAlterTableAddConstraintWithConstraintState2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE RESOURCELINKTYPE ADD CONSTRAINT RESOURCELINKTYPE_PRIMARYKEY PRIMARY KEY (PRIMARYKEY) DEFERRABLE NOVALIDATE");
}

public virtual void testAlterTableAddUniqueConstraint() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE Persons ADD UNIQUE (ID)");
}

public virtual void testAlterTableForeignKey2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id)");
}

public virtual void testAlterTableForeignKey3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id) ON DELETE RESTRICT");
}

public virtual void testAlterTableForeignKey4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id) ON DELETE SET NULL");
}

public virtual void testAlterTableForeignWithFkSchema() {
string FK_SCHEMA_NAME = "my_schema";
string FK_TABLE_NAME = "ra_user";
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ", FK_SCHEMA_NAME), "."), FK_TABLE_NAME), " (id) ON DELETE SET NULL");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(alterExpression.getFkSourceSchema(), FK_SCHEMA_NAME, null);
global::DripSharp.Testing.JavaAssertions.Equal(alterExpression.getFkSourceTable(), FK_TABLE_NAME, null);
}

public virtual void testAlterTableDropKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE ANV_ALERT_ACKNOWLEDGE_TYPE DROP KEY ALERT_ACKNOWLEDGE_TYPE_ID_NUK_1");
}

public virtual void testAlterTableDropColumn() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test DROP COLUMN YYY");
}

public virtual void testAlterTableDropColumn2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable DROP COLUMN col1, DROP COLUMN col2");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable DROP COLUMN col1, DROP COLUMN col2");
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col2Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 1);
global::DripSharp.Testing.JavaAssertions.Equal("col1", col1Exp.getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", col2Exp.getColumnName(), null);
}

public virtual void testAlterTableDropConstraint() {
string sql = "ALTER TABLE test DROP CONSTRAINT YYY";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!)).getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(alterExpression.getConstraintName(), "YYY", null);
}

public virtual void testAlterTableDropConstraintIfExists() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE Persons DROP CONSTRAINT IF EXISTS UC_Person");
}

public virtual void testAlterTablePK() {
string sql = "ALTER TABLE `Author` ADD CONSTRAINT `AuthorPK` PRIMARY KEY (`ID`)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!)).getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Null(alterExpression.getConstraintName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getIndex().getColumnsNames(), 0), "`ID`", null);
}

public virtual void testAlterTableFK() {
string sql = "ALTER TABLE `Novels` ADD FOREIGN KEY (AuthorID) REFERENCES Author (ID)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(((global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!)).getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpression.getFkColumns()), 1, null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getFkColumns(), 0), "AuthorID", null);
global::DripSharp.Testing.JavaAssertions.Equal(alterExpression.getFkSourceTable(), "Author", null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpression.getFkSourceColumns()), 1, null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getFkSourceColumns(), 0), "ID", null);
}

public virtual void testAlterTableCheckConstraint() {
string statement = "ALTER TABLE `Author` ADD CONSTRAINT name_not_empty CHECK (`NAME` <> '')";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Alter.Alter created = new global::DripSharp.SqlTrellis.Statement.Alter.Alter().withTable(new global::DripSharp.SqlTrellis.Schema.Table("`Author`")).addAlterExpressions(global::DripSharp.Runtime.JavaCompat.SetOf<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression>(new global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression().withOperation(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD).withIndex(((global::DripSharp.SqlTrellis.Statement.Create.Table.CheckConstraint)(new global::DripSharp.SqlTrellis.Statement.Create.Table.CheckConstraint().withName("name_not_empty"))).withExpression(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.NotEqualsTo)(((global::DripSharp.SqlTrellis.Expression.Operators.Relational.NotEqualsTo)(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.NotEqualsTo().withLeftExpression(new global::DripSharp.SqlTrellis.Schema.Column("`NAME`")))).withRightExpression(new global::DripSharp.SqlTrellis.Expression.StringValue())))))));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testAlterTableAddColumn2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals ADD (col1 integer, col2 integer)");
}

public virtual void testAlterTableAddColumn3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN mycolumn varchar (255)");
}

public virtual void testAlterTableAddColumn4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 varchar (255), ADD COLUMN col2 integer");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable ADD COLUMN col1 varchar (255), ADD COLUMN col2 integer");
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col2Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 1);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> col1DataTypes = col1Exp.getColDataTypeList();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> col2DataTypes = col2Exp.getColDataTypeList();
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(col1DataTypes, 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(col2DataTypes, 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("varchar (255)", global::DripSharp.Runtime.JavaCompat.ListGet(col1DataTypes, 0).getColDataType().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("integer", global::DripSharp.Runtime.JavaCompat.ListGet(col2DataTypes, 0).getColDataType().ToString(), null);
}

public virtual void testAlterTableAddColumn5() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable ADD col1 timestamp (3)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, "ALTER TABLE mytable ADD col1 timestamp (3)");
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> col1DataTypes = col1Exp.getColDataTypeList();
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(col1DataTypes, 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("timestamp (3)", global::DripSharp.Runtime.JavaCompat.ListGet(col1DataTypes, 0).getColDataType().ToString(), null);
global::DripSharp.Testing.JavaAssertions.False(col1Exp.hasColumn(), null);
}

public virtual void testAlterTableAddColumn6() {
string sql = "ALTER TABLE mytable ADD COLUMN col1 timestamp (3) not null";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::DripSharp.Testing.JavaAssertions.Equal("not", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(col1Exp.getColDataTypeList(), 0).getColumnSpecs(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("null", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(col1Exp.getColDataTypeList(), 0).getColumnSpecs(), 1), null);
global::DripSharp.Testing.JavaAssertions.True(col1Exp.hasColumn(), null);
}

public virtual void testAlterTableModifyColumn1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE animals MODIFY (col1 integer, col2 number (8, 2))");
}

public virtual void testAlterTableModifyColumn2() {
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable modify col1 timestamp (6)")!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(alter, "ALTER TABLE mytable MODIFY col1 timestamp (6)");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.MODIFY, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.False(alterExpression.hasColumn(), null);
}

public virtual void testAlterTableModifyColumn3() {
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable modify col1 NULL")!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(alter, "ALTER TABLE mytable MODIFY col1 NULL");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.MODIFY, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.False(alterExpression.hasColumn(), null);
}

public virtual void testAlterTableModifyColumn4() {
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable modify col1 DEFAULT 0")!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(alter, "ALTER TABLE mytable MODIFY col1 DEFAULT 0");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.MODIFY, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.False(alterExpression.hasColumn(), null);
}

public virtual void testAlterTableAlterColumn() {
string sql = "ALTER TABLE table_name ALTER COLUMN column_name_1 TYPE TIMESTAMP, ALTER COLUMN column_name_2 TYPE BOOLEAN";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.True(alterExpression.hasColumn(), null);
}

public virtual void testAlterTableChangeColumn1() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE tb_test CHANGE COLUMN c1 c2 INT (10)");
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.CHANGE, global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("c1", global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getColOldName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("COLUMN", global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getOptionalSpecifier(), null);
}

public virtual void testAlterTableChangeColumn2() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE tb_test CHANGE c1 c2 INT (10)");
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.CHANGE, global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("c1", global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getColOldName(), null);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getOptionalSpecifier(), null);
}

public virtual void testAlterTableChangeColumn3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE tb_test CHANGE COLUMN c1 c2 INT (10)");
}

public virtual void testAlterTableChangeColumn4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE tb_test CHANGE c1 c2 INT (10)");
}

public virtual void testAlterTableAddColumnWithZone() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 timestamp with time zone");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 timestamp without time zone");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 date with time zone");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 date without time zone");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE mytable ADD COLUMN col1 timestamp with time zone");
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType> col1DataTypes = col1Exp.getColDataTypeList();
global::DripSharp.Testing.JavaAssertions.Equal("timestamp with time zone", global::DripSharp.Runtime.JavaCompat.ListGet(col1DataTypes, 0).getColDataType().ToString(), null);
}

public virtual void testAlterTableAddColumnKeywordTypes() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 xml");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 interval");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE mytable ADD COLUMN col1 bit varying");
}

public virtual void testDropColumnRestrictIssue510() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE TABLE1 DROP COLUMN NewColumn CASCADE");
}

public virtual void testDropColumnRestrictIssue551() {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE table1 DROP NewColumn");
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, "ALTER TABLE table1 DROP NewColumn");
}

public virtual void testAddConstraintKeyIssue320() {
string tableName = "table1";
string columnName1 = "col1";
string columnName2 = "col2";
string columnName3 = "col3";
string columnName4 = "col4";
string constraintName1 = "table1_constraint_1";
string constraintName2 = "table1_constraint_2";
foreach (string constraintType in global::DripSharp.Runtime.JavaCompat.AsList<string>("UNIQUE KEY", "KEY")) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE ", tableName), " ADD CONSTRAINT "), constraintName1), " "), constraintType), " ("), columnName1), ")"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE ", tableName), " ADD CONSTRAINT "), constraintName1), " "), constraintType), " ("), columnName1), ", "), columnName2), ")"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE ", tableName), " ADD CONSTRAINT "), constraintName1), " "), constraintType), " ("), columnName1), ", "), columnName2), "), ADD CONSTRAINT "), constraintName2), " "), constraintType), " ("), columnName3), ", "), columnName4), ")"));
}
}

public virtual void testIssue633() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE team_phases ADD CONSTRAINT team_phases_id_key UNIQUE (id)");
}

public virtual void testIssue679() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE tb_session_status ADD INDEX idx_user_id_name (user_id, user_name(10)), ADD INDEX idx_user_name (user_name)");
}

public virtual void testAlterTableColumnCommentIssue1926() {
string statement = "ALTER TABLE `student` ADD INDEX `idx_age` (`age`) USING BTREE COMMENT 'index age'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
string stmt2 = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE `student` ADD INDEX `idx_name` (`name`) COMMENT 'index name', ", "ADD INDEX `idx_age` (`age`) USING BTREE COMMENT 'index age'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2);
}

public virtual void testAlterTableIndex586() {
global::DripSharp.SqlTrellis.Statement.Statement result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE biz_add_fee DROP INDEX operation_time, ", "ADD UNIQUE INDEX operation_time (`operation_time`, `warehouse_code`, `customerid`, `fees_type`, `external_no`) "), "USING BTREE, ALGORITHM = INPLACE"));
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE biz_add_fee DROP INDEX operation_time, ", "ADD UNIQUE INDEX operation_time (`operation_time`, `warehouse_code`, `customerid`, `fees_type`, `external_no`) "), "USING BTREE, ALGORITHM = INPLACE"), global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testIssue259() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE feature_v2 ADD COLUMN third_user_id int (10) unsigned DEFAULT '0' COMMENT '\u7B2C\u4E09\u65B9\u7528\u6237id' after kdt_id");
}

public virtual void testIssue633_2() {
string statement = "CREATE INDEX idx_american_football_action_plays_1 ON american_football_action_plays USING btree (play_type)";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex created = new global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex().withTable(new global::DripSharp.SqlTrellis.Schema.Table("american_football_action_plays")).withIndex(new global::DripSharp.SqlTrellis.Statement.Create.Table.Index().withName("idx_american_football_action_plays_1").addColumns(new global::DripSharp.SqlTrellis.Statement.Create.Table.Index.ColumnParams("play_type", (global::System.Collections.Generic.IList<string>)default!)).withUsing("btree"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testAlterOnlyIssue928() {
string statement = "ALTER TABLE ONLY categories ADD CONSTRAINT pk_categories PRIMARY KEY (category_id)";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Alter.Alter created = new global::DripSharp.SqlTrellis.Statement.Alter.Alter().withUseOnly(true).withTable(new global::DripSharp.SqlTrellis.Schema.Table("categories")).addAlterExpressions(new global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression().withOperation(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD).withIndex(((global::DripSharp.SqlTrellis.Statement.Create.Table.NamedConstraint)(((global::DripSharp.SqlTrellis.Statement.Create.Table.NamedConstraint)(((global::DripSharp.SqlTrellis.Statement.Create.Table.NamedConstraint)(new global::DripSharp.SqlTrellis.Statement.Create.Table.NamedConstraint().withName(global::DripSharp.Runtime.JavaCompat.ListOf<string>("pk_categories")))).withType("PRIMARY KEY"))).addColumns(new global::DripSharp.SqlTrellis.Statement.Create.Table.Index.ColumnParams("category_id"))))));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testAlterConstraintWithoutFKSourceColumnsIssue929() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE orders ADD CONSTRAINT fk_orders_customers FOREIGN KEY (customer_id) REFERENCES customers");
}

public virtual void testAlterTableAlterColumnDropNotNullIssue918() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE \"user_table_t\" ALTER COLUMN name DROP NOT NULL");
}

public virtual void testAlterTableRenameColumn() {
string sql = "ALTER TABLE \"test_table\" RENAME COLUMN \"test_column\" TO \"test_c\"";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression expression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getOperation(), global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.RENAME, null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getColOldName(), "\"test_column\"", null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getColumnName(), "\"test_c\"", null);
sql = "ALTER TABLE \"test_table\" RENAME \"test_column\" TO \"test_c\"";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableRenameColumn2() {
string sql = "ALTER TABLE test_table RENAME COLUMN name TO full_name";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression expression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getOperation(), global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.RENAME, null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getColOldName(), "name", null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getColumnName(), "full_name", null);
}

public virtual void testAlterTableForeignKeyIssue981() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE atconfigpro ", "ADD CONSTRAINT atconfigpro_atconfignow_id_foreign FOREIGN KEY (atconfignow_id) REFERENCES atconfignow(id) ON DELETE CASCADE, "), "ADD CONSTRAINT atconfigpro_attariff_id_foreign FOREIGN KEY (attariff_id) REFERENCES attariff(id) ON DELETE CASCADE"));
}

public virtual void testAlterTableForeignKeyIssue981_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE atconfigpro ", "ADD CONSTRAINT atconfigpro_atconfignow_id_foreign FOREIGN KEY (atconfignow_id) REFERENCES atconfignow(id) ON DELETE CASCADE"));
}

public virtual void testAlterTableTableCommentIssue984() {
string statement = "ALTER TABLE texto_fichero COMMENT 'This is a sample comment'";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Alter.Alter created = new global::DripSharp.SqlTrellis.Statement.Alter.Alter().withTable(new global::DripSharp.SqlTrellis.Schema.Table("texto_fichero")).addAlterExpressions(new global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression().withOperation(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.COMMENT).withCommentText("'This is a sample comment'"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testAlterTableColumnCommentIssue984() {
string statement = "ALTER TABLE texto_fichero MODIFY id COMMENT 'some comment'";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Alter.Alter created = new global::DripSharp.SqlTrellis.Statement.Alter.Alter().withTable(new global::DripSharp.SqlTrellis.Schema.Table("texto_fichero")).addAlterExpressions(new global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression().withOperation(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.MODIFY).withColumnName("id").withCommentText("'some comment'"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testAlterOnUpdateCascade() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE CASCADE");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE CASCADE");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
}

public virtual void testAlterOnUpdateSetNull() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE SET NULL");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE SET NULL");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
}

public virtual void testAlterOnUpdateRestrict() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE RESTRICT");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.RESTRICT, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE RESTRICT");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.RESTRICT, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
}

public virtual void testAlterOnUpdateSetDefault() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE SET DEFAULT");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_DEFAULT, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE SET DEFAULT");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_DEFAULT, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
}

public virtual void testAlterOnUpdateNoAction() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE NO ACTION");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.NO_ACTION, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON UPDATE NO ACTION");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.NO_ACTION, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
}

public virtual void testAlterOnDeleteSetDefault() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON DELETE SET DEFAULT");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_DEFAULT);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON DELETE SET DEFAULT");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_DEFAULT);
}

public virtual void testAlterOnDeleteNoAction() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab(id) ON DELETE NO ACTION");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.NO_ACTION);
statement = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab(id) ON DELETE NO ACTION");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.NO_ACTION);
}

public virtual void testOnUpdateOnDeleteOrOnDeleteOnUpdate() {
string onUpdateOnDelete = "ON UPDATE CASCADE ON DELETE SET NULL";
string onDeleteonUpdate = "ON UPDATE CASCADE ON DELETE SET NULL";
string constraint = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD CONSTRAINT fk_mytab FOREIGN KEY (col) ", "REFERENCES reftab (id) ");
string fk = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE mytab ADD FOREIGN KEY (col) ", "REFERENCES reftab (id) ");
string statement = global::DripSharp.Runtime.JavaCompat.Concat(constraint, onUpdateOnDelete);
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL);
statement = global::DripSharp.Runtime.JavaCompat.Concat(constraint, onDeleteonUpdate);
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL);
statement = global::DripSharp.Runtime.JavaCompat.Concat(fk, onUpdateOnDelete);
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL);
statement = global::DripSharp.Runtime.JavaCompat.Concat(fk, onDeleteonUpdate);
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL);
}

public virtual void testIssue985_1() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE texto_fichero ", "ADD CONSTRAINT texto_fichero_fichero_id_foreign FOREIGN KEY (fichero_id) "), "REFERENCES fichero (id) ON DELETE SET DEFAULT ON UPDATE CASCADE, "), "ADD CONSTRAINT texto_fichero_texto_id_foreign FOREIGN KEY (texto_id) "), "REFERENCES texto(id) ON DELETE SET DEFAULT ON UPDATE CASCADE");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_DEFAULT);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE texto_fichero ", "ADD FOREIGN KEY (fichero_id) "), "REFERENCES fichero (id) ON DELETE SET DEFAULT ON UPDATE CASCADE, "), "ADD FOREIGN KEY (texto_id) "), "REFERENCES texto(id) ON DELETE SET DEFAULT ON UPDATE CASCADE");
parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialAction(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_DEFAULT);
}

public virtual void testIssue985_2() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE texto ", "ADD CONSTRAINT texto_autor_id_foreign FOREIGN KEY (autor_id) "), "REFERENCES users (id) ON UPDATE CASCADE, "), "ADD CONSTRAINT texto_tipotexto_id_foreign FOREIGN KEY (tipotexto_id) "), "REFERENCES tipotexto(id) ON UPDATE CASCADE");
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, true);
this.assertReferentialActionOnConstraint(parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, (global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action)default!);
}

public virtual void testAlterTableDefaultValueTrueIssue926() {
global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("ALTER TABLE my_table ADD some_column BOOLEAN DEFAULT FALSE")!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, "ALTER TABLE my_table ADD some_column BOOLEAN DEFAULT FALSE");
}

private void assertReferentialActionOnConstraint(global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action onUpdate, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action onDelete) {
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(parsed.getAlterExpressions(), 0);
global::DripSharp.SqlTrellis.Statement.Create.Table.ForeignKeyIndex index = (global::DripSharp.SqlTrellis.Statement.Create.Table.ForeignKeyIndex)(alterExpression.getIndex()!);
index.setOnDeleteReferenceOption(index.getOnDeleteReferenceOption());
if ((onDelete != default!)) {
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Statement.ReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.DELETE, onDelete), index.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.DELETE), null);
} else {
global::DripSharp.Testing.JavaAssertions.Null(index.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.DELETE), null);
}
index.setOnUpdateReferenceOption(index.getOnUpdateReferenceOption());
if ((onUpdate != default!)) {
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Statement.ReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.UPDATE, onUpdate), index.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.UPDATE), null);
} else {
global::DripSharp.Testing.JavaAssertions.Null(index.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.UPDATE), null);
}
}

private void assertReferentialAction(global::DripSharp.SqlTrellis.Statement.Alter.Alter parsed, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action onUpdate, global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action onDelete) {
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(parsed.getAlterExpressions(), 0);
if ((onDelete != default!)) {
global::DripSharp.SqlTrellis.Statement.ReferentialAction actual = alterExpression.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.DELETE);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Statement.ReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.DELETE, onDelete), actual, null);
if (global::DripSharp.Runtime.JavaCompat.Equals(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.CASCADE, actual.getAction())) {
alterExpression.setOnDeleteCascade(alterExpression.isOnDeleteCascade());
}
if (global::DripSharp.Runtime.JavaCompat.Equals(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.RESTRICT, actual.getAction())) {
alterExpression.setOnDeleteRestrict(alterExpression.isOnDeleteRestrict());
}
if (global::DripSharp.Runtime.JavaCompat.Equals(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Action.SET_NULL, actual.getAction())) {
alterExpression.setOnDeleteSetNull(alterExpression.isOnDeleteSetNull());
}
} else {
global::DripSharp.Testing.JavaAssertions.Null(alterExpression.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.DELETE), null);
}
if ((onUpdate != default!)) {
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Statement.ReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.UPDATE, onUpdate), alterExpression.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.UPDATE), null);
} else {
global::DripSharp.Testing.JavaAssertions.Null(alterExpression.getReferentialAction(global::DripSharp.SqlTrellis.Statement.ReferentialAction.Type.UPDATE), null);
}
}

public virtual void testRowFormatKeywordIssue1033() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE basic_test_case ", "ADD COLUMN display_name varchar(512) NOT NULL DEFAULT '' AFTER name"), ", ADD KEY test_case_status (test_case_status)"), ", add KEY display_name (display_name), ROW_FORMAT=DYNAMIC"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE t1 MOVE TABLESPACE users", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test_tab MOVE PARTITION test_tab_q2 COMPRESS", true);
}

public virtual void testAlterTableDropConstraintsIssue1342() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a DROP PRIMARY KEY", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a DROP UNIQUE (b, c, d)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a DROP FOREIGN KEY (b, c, d)", true);
}

public virtual void testAlterTableChangeColumnDropNotNull() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a MODIFY COLUMN b DROP NOT NULL", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a MODIFY (COLUMN b DROP NOT NULL, COLUMN c DROP NOT NULL)", true);
}

public virtual void testAlterTableChangeColumnDropDefault() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a MODIFY COLUMN b DROP DEFAULT", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a MODIFY (COLUMN b DROP DEFAULT, COLUMN c DROP DEFAULT)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a MODIFY (COLUMN b DROP NOT NULL, COLUMN b DROP DEFAULT)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE a MODIFY (COLUMN b DROP DEFAULT, COLUMN b DROP NOT NULL)", true);
}

public virtual void testAlterTableDropColumnIfExists() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test DROP COLUMN IF EXISTS name");
}

public virtual void testAlterTableCommentIssue1935() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE table_name COMMENT = 'New table comment'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE table_name COMMENT 'New table comment'");
}

public virtual void testAlterTableDropMultipleColumnsIfExists() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test DROP COLUMN IF EXISTS name, DROP COLUMN IF EXISTS surname");
}

public virtual void testAlterTableAddIndexWithComment1906() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE `student` ADD KEY `idx_name` (`name`) COMMENT 'name'");
}

public virtual void testAlterTableAddIndexWithComment2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE team_phases ADD CONSTRAINT team_phases_id_key UNIQUE (id) COMMENT 'name'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE team_phases ADD CONSTRAINT team_phases_id_key UNIQUE KEY (c1, c2) COMMENT 'name'");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE team_phases ADD CONSTRAINT team_phases_id_key PRIMARY KEY (id) COMMENT 'name'");
}

public virtual void testAlterTableDropMultipleColumnsIfExistsWithParams() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER TABLE test DROP COLUMN IF EXISTS name CASCADE, DROP COLUMN IF EXISTS surname CASCADE");
}

public virtual void testAlterTableAddColumnSpanner7() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE ORDER_PATIENT ADD COLUMN FIRST_NAME_UPPERCASE STRING(MAX)", " AS (UPPER(FIRST_NAME)) STORED");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql, true);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.StringEndsWith(global::DripSharp.Runtime.JavaCompat.ListGet(col1Exp.getColDataTypeList(), 0).ToString(), " STORED"), null);
global::DripSharp.Testing.JavaAssertions.True(col1Exp.hasColumn(), null);
}

public virtual void testAlterTableAddColumnSpanner8() {
string sql = "ALTER TABLE ORDER_PATIENT ADD COLUMN NAMES ARRAY<STRING(MAX)>";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql, true);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::DripSharp.Testing.JavaAssertions.True(col1Exp.hasColumn(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(col1Exp.getColDataTypeList(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(col1Exp.getColDataTypeList()), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType type = global::DripSharp.Runtime.JavaCompat.ListGet(col1Exp.getColDataTypeList(), 0);
global::DripSharp.Testing.JavaAssertions.Equal("NAMES", type.getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ARRAY<STRING (MAX)>", type.getColDataType().ToString(), null);
}

public virtual void testAlterColumnSetCommitTimestamp1() {
string sql = "ALTER TABLE FOCUS_PATIENT ALTER COLUMN UPDATE_DATE_TIME_GMT SET OPTIONS (allow_commit_timestamp=true)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(stmt, sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExps = alter.getAlterExpressions();
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression col1Exp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExps, 0);
global::DripSharp.Testing.JavaAssertions.True(col1Exp.hasColumn(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(col1Exp.getColDataTypeList(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(col1Exp.getColDataTypeList()), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression.ColumnDataType type = global::DripSharp.Runtime.JavaCompat.ListGet(col1Exp.getColDataTypeList(), 0);
global::DripSharp.Testing.JavaAssertions.Equal("UPDATE_DATE_TIME_GMT", type.getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UPDATE_DATE_TIME_GMT SET OPTIONS (allow_commit_timestamp=true)", type.ToString(), null);
}

public virtual void testIssue1890() {
string stmt = "ALTER TABLE xdmiddle.ft_mid_sop_sms_send_list_daily TRUNCATE PARTITION sum_date";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIssue1875() {
string stmt = "ALTER TABLE IF EXISTS usercenter.dict_surgeries ADD COLUMN IF NOT EXISTS operation_grade_id int8 NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testIssue2027() {
string sql = "ALTER TABLE `foo_bar` ADD COLUMN `baz` text";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
string sqlText = "ALTER TABLE `foo_bar` ADD COLUMN `baz` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlText);
string sqlTinyText = "ALTER TABLE `foo_bar` ADD COLUMN `baz` tinytext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlTinyText);
string sqlMediumText = "ALTER TABLE `foo_bar` ADD COLUMN `baz` mediumtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlMediumText);
string sqlLongText = "ALTER TABLE `foo_bar` ADD COLUMN `baz` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NULL";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlLongText);
}

public virtual void testAlterTableCollate() {
string sql = "ALTER TABLE tbl_name COLLATE collation_name";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression expression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getOperation(), global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.COLLATE, null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getCollation(), "collation_name", null);
global::DripSharp.Testing.JavaAssertions.False(expression.isDefaultCollateSpecified(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
sql = "ALTER TABLE tbl_name COLLATE = collation_name";
alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
expression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getOperation(), global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.COLLATE, null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getCollation(), "collation_name", null);
global::DripSharp.Testing.JavaAssertions.False(expression.isDefaultCollateSpecified(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
sql = "ALTER TABLE tbl_name DEFAULT COLLATE collation_name";
alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
expression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getOperation(), global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.COLLATE, null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getCollation(), "collation_name", null);
global::DripSharp.Testing.JavaAssertions.True(expression.isDefaultCollateSpecified(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
sql = "ALTER TABLE tbl_name DEFAULT COLLATE = collation_name";
alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
expression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getOperation(), global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.COLLATE, null);
global::DripSharp.Testing.JavaAssertions.Equal(expression.getCollation(), "collation_name", null);
global::DripSharp.Testing.JavaAssertions.True(expression.isDefaultCollateSpecified(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testIssue2090LockNone() {
string sql = "ALTER TABLE sbtest1 MODIFY COLUMN pad_3 VARCHAR(20) DEFAULT NULL, ALGORITHM=INPLACE, LOCK=NONE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("sbtest1", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression lockExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 2);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.LOCK, lockExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("NONE", lockExp.getLockOption(), null);
}

public virtual void testIssue2090LockExclusive() {
string sql = "ALTER TABLE sbtest1 MODIFY COLUMN pad_3 VARCHAR(20) DEFAULT NULL, ALGORITHM=INPLACE, LOCK=EXCLUSIVE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("sbtest1", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression lockExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 2);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.LOCK, lockExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("EXCLUSIVE", lockExp.getLockOption(), null);
}

public virtual void testIssue2089(string sql, string expectedCharacterSet, string expectedCollation) {
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), global::DripSharp.Runtime.JavaCompat.Concat("Expected instance of Alter but got: ", ((object)(stmt)).GetType().Name));
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("test_table", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, global::DripSharp.Runtime.JavaCompat.Concat("Alter expressions should not be null for SQL: ", sql));
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), global::DripSharp.Runtime.JavaCompat.Concat("Expected 1 alter expression for SQL: ", sql));
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression convertExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.CONVERT, convertExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(expectedCharacterSet, convertExp.getCharacterSet(), global::DripSharp.Runtime.JavaCompat.Concat("CHARACTER SET mismatch for SQL: ", sql));
global::DripSharp.Testing.JavaAssertions.Equal(expectedCollation, convertExp.getCollation(), global::DripSharp.Runtime.JavaCompat.Concat("COLLATE mismatch for SQL: ", sql));
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

private static global::DripSharp.Runtime.JavaStream<object[]> provideMySQLConvertTestCases() {
return global::DripSharp.Runtime.JavaCompat.Stream<object[]>(global::DripSharp.Runtime.JavaCompat.StreamOf<object[]>(new object[] { "ALTER TABLE test_table CONVERT TO CHARACTER SET utf8mb4", "utf8mb4", (object[])default! }, new object[] { "ALTER TABLE test_table CONVERT TO CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci", "utf8mb4", "utf8mb4_general_ci" }, new object[] { "ALTER TABLE test_table DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci", "utf8mb4", "utf8mb4_general_ci" }, new object[] { "ALTER TABLE test_table DEFAULT CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci", "utf8mb4", "utf8mb4_general_ci" }, new object[] { "ALTER TABLE test_table CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci", "utf8mb4", "utf8mb4_general_ci" }, new object[] { "ALTER TABLE test_table CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci", "utf8mb4", "utf8mb4_general_ci" }, new object[] { "ALTER TABLE test_table DEFAULT CHARACTER SET utf8mb4", "utf8mb4", (object[])default! }, new object[] { "ALTER TABLE test_table DEFAULT CHARACTER SET = utf8mb4", "utf8mb4", (object[])default! }));
}

public virtual void testIssue2106AlterTableAddPartition1() {
string sql = "ALTER TABLE t1 ADD PARTITION (PARTITION p3 VALUES LESS THAN (2002));";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD_PARTITION, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitionDefinitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitionDefinitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitionDefinitions), null);
global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition partitionDef = global::DripSharp.Runtime.JavaCompat.ListGet(partitionDefinitions, 0);
global::DripSharp.Testing.JavaAssertions.Equal("p3", partitionDef.getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", partitionDef.getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("2002"), partitionDef.getValues(), null);
}

public virtual void testIssue2106AlterTableAddPartition2() {
string sql = "ALTER TABLE mtk_seat_state_hist ADD PARTITION (PARTITION SEAT_HIST_202004 VALUES LESS THAN ('2020-05-01'), PARTITION SEAT_HIST_202005 VALUES LESS THAN ('2020-06-01'), PARTITION SEAT_HIST_202006 VALUES LESS THAN ('2020-07-01'));";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD_PARTITION, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("SEAT_HIST_202004", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("'2020-05-01'"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SEAT_HIST_202005", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("'2020-06-01'"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SEAT_HIST_202006", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 2).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 2).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("'2020-07-01'"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 2).getValues(), null);
}

public virtual void testIssue2106AlterTableAddPartition3() {
string sql = "ALTER TABLE employees ADD PARTITION (PARTITION p5 VALUES LESS THAN (2010), PARTITION p6 VALUES LESS THAN MAXVALUE);";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD_PARTITION, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("p5", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("2010"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p6", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("MAXVALUE"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getValues(), null);
}

public virtual void testIssue2106AlterTableAddPartitionCodeTransaction() {
string sql = "ALTER TABLE `code_transaction` ADD PARTITION (PARTITION p202108 VALUES LESS THAN ('20210901') ENGINE = InnoDB);";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD_PARTITION, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202108", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("'20210901'"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("InnoDB", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getStorageEngine(), null);
}

public virtual void testIssue2106AlterTableDropPartition() {
string sql = "ALTER TABLE dkpg_payment_details DROP PARTITION p202007, p202008, p202009, p202010";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.DROP_PARTITION, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<string> partitionNames = partitionExp.getPartitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitionNames, null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitionNames), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202007", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202008", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202009", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 2), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202010", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 3), null);
}

public virtual void testIssue2106AlterTableTruncatePartition() {
string sql = "ALTER TABLE dkpg_payments TRUNCATE PARTITION p201701, p201707, p201801, p201807";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.TRUNCATE_PARTITION, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<string> partitionNames = partitionExp.getPartitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitionNames, null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitionNames), null);
global::DripSharp.Testing.JavaAssertions.Equal("p201701", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("p201707", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("p201801", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 2), null);
global::DripSharp.Testing.JavaAssertions.Equal("p201807", global::DripSharp.Runtime.JavaCompat.ListGet(partitionNames, 3), null);
}

public virtual void testIssue2114AlterTableEncryption() {
string sql = "ALTER TABLE confidential_data ENCRYPTION = 'Y'";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression encryptionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.SET_TABLE_OPTION, encryptionExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(encryptionExp.getTableOption(), "ENCRYPTION = 'Y'", null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testIssue2114AlterTableEncryptionWithoutEqual() {
string sql = "ALTER TABLE confidential_data ENCRYPTION 'N'";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression encryptionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.SET_TABLE_OPTION, encryptionExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(encryptionExp.getTableOption(), "ENCRYPTION 'N'", null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testIssue2114AlterTableAutoIncrement() {
string sql = "ALTER TABLE tt AUTO_INCREMENT = 101";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression autoIncrementExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.SET_TABLE_OPTION, autoIncrementExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(autoIncrementExp.getTableOption(), "AUTO_INCREMENT = 101", null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testIssue2114AlterTableEngine() {
string sql = "ALTER TABLE city2 ENGINE = InnoDB";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.True((stmt is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression engineExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ENGINE, engineExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(engineExp.getEngineOption(), "InnoDB", null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testIssue2118AlterTableForceAndEngine() {
string sql1 = "ALTER TABLE my_table FORCE";
global::DripSharp.SqlTrellis.Statement.Statement stmt1 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql1);
global::DripSharp.Testing.JavaAssertions.True((stmt1 is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter1 = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt1!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions1 = alter1.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions1, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions1), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression forceExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions1, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.FORCE, forceExp.getOperation(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql1);
string sql2 = "ALTER TABLE tbl_name FORCE, ENGINE=InnoDB, ALGORITHM=INPLACE, LOCK=NONE";
global::DripSharp.SqlTrellis.Statement.Statement stmt2 = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql2);
global::DripSharp.Testing.JavaAssertions.True((stmt2 is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter2 = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt2!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions2 = alter2.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions2, null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions2), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression forceExp2 = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions2, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.FORCE, forceExp2.getOperation(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression engineExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions2, 1);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ENGINE, engineExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(engineExp.getEngineOption(), "InnoDB", null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression algorithmExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions2, 2);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALGORITHM, algorithmExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INPLACE", algorithmExp.getAlgorithmOption(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression lockExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions2, 3);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.LOCK, lockExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("NONE", lockExp.getLockOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql2);
}

public virtual void testDiscardTablespace() {
string sql = "ALTER TABLE employees DISCARD TABLESPACE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("employees", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("DISCARD_TABLESPACE", global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getOperation().ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testImportTablespace() {
string sql = "ALTER TABLE employees IMPORT TABLESPACE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("employees", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("IMPORT_TABLESPACE", global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0).getOperation().ToString(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableKeys() {
string sqlDisable = "ALTER TABLE tbl_name DISABLE KEYS";
global::DripSharp.SqlTrellis.Statement.Statement stmtDisable = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlDisable);
global::DripSharp.Testing.JavaAssertions.True((stmtDisable is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alterDisable = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmtDisable!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alterDisable.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpDisable = global::DripSharp.Runtime.JavaCompat.ListGet(alterDisable.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.DISABLE_KEYS, alterExpDisable.getOperation(), null);
string sqlEnable = "ALTER TABLE tbl_name ENABLE KEYS";
global::DripSharp.SqlTrellis.Statement.Statement stmtEnable = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlEnable);
global::DripSharp.Testing.JavaAssertions.True((stmtEnable is global::DripSharp.SqlTrellis.Statement.Alter.Alter), null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alterEnable = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmtEnable!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alterEnable.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpEnable = global::DripSharp.Runtime.JavaCompat.ListGet(alterEnable.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ENABLE_KEYS, alterExpEnable.getOperation(), null);
}

public virtual void testAlterTablePartitionByRangeColumns() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE `payment_lock` ", "PARTITION BY RANGE COLUMNS(`created_at`) ("), "PARTITION p20210217 VALUES LESS THAN ('20210218') ENGINE = InnoDB, "), "PARTITION p20210218 VALUES LESS THAN ('20210219') ENGINE = InnoDB);");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("`payment_lock`", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.PARTITION_BY, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("p20210217", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("'20210218'"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p20210218", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("'20210219'"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTablePartitionByRangeUnixTimestamp() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE `test`.`pipeline_service_metadata_history` ", "PARTITION BY RANGE (FLOOR(UNIX_TIMESTAMP(requested_at))) ("), "PARTITION p202104 VALUES LESS THAN (UNIX_TIMESTAMP('2021-05-01 00:00:00')) ENGINE = InnoDB, "), "PARTITION p202105 VALUES LESS THAN (UNIX_TIMESTAMP('2021-06-01 00:00:00')) ENGINE = InnoDB);");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("`test`.`pipeline_service_metadata_history`", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.PARTITION_BY, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202104", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("UNIX_TIMESTAMP('2021-05-01 00:00:00')"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202105", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("UNIX_TIMESTAMP('2021-06-01 00:00:00')"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTablePartitionByRangeUnixTimestamp2() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE MP_MNEWS.PUR_MNEWS_CONTS ", "PARTITION BY RANGE (UNIX_TIMESTAMP(REG_DATE_TS)) ("), "PARTITION p202007 VALUES LESS THAN (1596207600) ENGINE = InnoDB, "), "PARTITION p202008 VALUES LESS THAN (1598886000) ENGINE = InnoDB, "), "PARTITION p202009 VALUES LESS THAN (1601478000) ENGINE = InnoDB);");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("MP_MNEWS.PUR_MNEWS_CONTS", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression partitionExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.PARTITION_BY, partitionExp.getOperation(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition> partitions = partitionExp.getPartitionDefinitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202007", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("1596207600"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202008", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("1598886000"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1).getValues(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p202009", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 2).getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 2).getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("1601478000"), global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 2).getValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableDiscardPartitionTablespace() {
string sql = "ALTER TABLE tbl_name DISCARD PARTITION p1 TABLESPACE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.DISCARD_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("TABLESPACE", alterExpression.getTableOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableDiscardAllPartitionTablespace() {
string sql = "ALTER TABLE tbl_name DISCARD PARTITION ALL TABLESPACE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.DISCARD_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ALL", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("TABLESPACE", alterExpression.getTableOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableImportMultiplePartitionsTablespace() {
string sql = "ALTER TABLE tbl_name IMPORT PARTITION p1, p2 TABLESPACE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.IMPORT_PARTITION, alterExpression.getOperation(), null);
global::System.Collections.Generic.IList<string> partitions = alterExpression.getPartitions();
global::DripSharp.Testing.JavaAssertions.NotNull(partitions, null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(partitions), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("p2", global::DripSharp.Runtime.JavaCompat.ListGet(partitions, 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("TABLESPACE", alterExpression.getTableOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableTruncatePartition() {
string sql = "ALTER TABLE tbl_name TRUNCATE PARTITION p1";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.TRUNCATE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableCoalescePartition() {
string sql = "ALTER TABLE tbl_name COALESCE PARTITION 2";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.COALESCE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, alterExpression.getCoalescePartitionNumber(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableReorganizePartition() {
string sql = "ALTER TABLE tbl_name REORGANIZE PARTITION p1 INTO (PARTITION p2 VALUES LESS THAN (100))";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.REORGANIZE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Statement.Create.Table.PartitionDefinition partitionDef = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitionDefinitions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal("p2", partitionDef.getPartitionName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VALUES LESS THAN", partitionDef.getPartitionOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("100"), partitionDef.getValues(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableExchangePartition() {
string sql = "ALTER TABLE tbl_name EXCHANGE PARTITION p1 WITH TABLE tbl_name2";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.EXCHANGE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name2", alterExpression.getExchangePartitionTableName(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableExchangePartitionWithValidation() {
string sql = "ALTER TABLE tbl_name EXCHANGE PARTITION p1 WITH TABLE tbl_name2 WITH VALIDATION";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.EXCHANGE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name2", alterExpression.getExchangePartitionTableName(), null);
global::DripSharp.Testing.JavaAssertions.True(alterExpression.isExchangePartitionWithValidation(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAnalyzePartition() {
string sql = "ALTER TABLE tbl_name ANALYZE PARTITION p1";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ANALYZE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableCheckPartition() {
string sql = "ALTER TABLE tbl_name CHECK PARTITION p1";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.CHECK_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableOptimizePartition() {
string sql = "ALTER TABLE tbl_name OPTIMIZE PARTITION p1";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.OPTIMIZE_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableRebuildPartition() {
string sql = "ALTER TABLE tbl_name REBUILD PARTITION p1";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.REBUILD_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableRepairPartition() {
string sql = "ALTER TABLE tbl_name REPAIR PARTITION p1";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.REPAIR_PARTITION, alterExpression.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("p1", global::DripSharp.Runtime.JavaCompat.ListGet(alterExpression.getPartitions(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableRemovePartitioning() {
string sql = "ALTER TABLE tbl_name REMOVE PARTITIONING";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alter.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExpression = global::DripSharp.Runtime.JavaCompat.ListGet(alter.getAlterExpressions(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.REMOVE_PARTITIONING, alterExpression.getOperation(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableKeyBlockSizeAlgorithmLock() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE dw_rpt ", "KEY_BLOCK_SIZE = 8, "), "ALGORITHM = INPLACE, "), "LOCK = NONE");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("dw_rpt", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression keyBlockSizeExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.KEY_BLOCK_SIZE, keyBlockSizeExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(8, keyBlockSizeExp.getKeyBlockSize(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression algorithmExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 1);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALGORITHM, algorithmExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INPLACE", algorithmExp.getAlgorithmOption(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression lockExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 2);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.LOCK, lockExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("NONE", lockExp.getLockOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddFullTextIndex() {
string sql = "ALTER TABLE yum_table_myisam ADD FULLTEXT (name)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("yum_table_myisam", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression indexExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, indexExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("FULLTEXT", indexExp.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("name", global::DripSharp.Runtime.JavaCompat.ListGet(indexExp.getIndex().getColumnsNames(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddSpatialIndex() {
string sql = "ALTER TABLE places ADD SPATIAL KEY sp_idx_location(location)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("places", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression indexExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, indexExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SPATIAL", indexExp.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("sp_idx_location", indexExp.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("location", global::DripSharp.Runtime.JavaCompat.ListGet(indexExp.getIndex().getColumnsNames(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddFullTextIndexWithOptions() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE my_table ADD FULLTEXT my_idx(col1, col2) ", "KEY_BLOCK_SIZE = 8 WITH PARSER ngram COMMENT 'fulltext' INVISIBLE");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("my_table", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression indexExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, indexExp.getOperation(), null);
global::DripSharp.SqlTrellis.Statement.Create.Table.Index index = indexExp.getIndex();
global::DripSharp.Testing.JavaAssertions.NotNull(index, null);
global::DripSharp.Testing.JavaAssertions.Equal("FULLTEXT", index.getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("my_idx", index.getName(), null);
global::System.Collections.Generic.IList<string> columnNames = index.getColumnsNames();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(columnNames), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(columnNames, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(columnNames, 1), null);
global::System.Collections.Generic.IList<string> indexSpec = index.getIndexSpec();
global::DripSharp.Testing.JavaAssertions.NotNull(indexSpec, null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(indexSpec), null);
global::DripSharp.Testing.JavaAssertions.Equal("KEY_BLOCK_SIZE = 8", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("WITH PARSER ngram", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("COMMENT 'fulltext'", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 2), null);
global::DripSharp.Testing.JavaAssertions.Equal("INVISIBLE", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 3), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddUnnamedIndex() {
string sql = "ALTER TABLE employees ADD INDEX (name1, name2)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("employees", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression indexExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, indexExp.getOperation(), null);
global::DripSharp.SqlTrellis.Statement.Create.Table.Index index = indexExp.getIndex();
global::DripSharp.Testing.JavaAssertions.NotNull(index, null);
global::DripSharp.Testing.JavaAssertions.Null(index.getName(), null);
global::System.Collections.Generic.IList<string> columnNames = index.getColumnsNames();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(columnNames), null);
global::DripSharp.Testing.JavaAssertions.Equal("name1", global::DripSharp.Runtime.JavaCompat.ListGet(columnNames, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("name2", global::DripSharp.Runtime.JavaCompat.ListGet(columnNames, 1), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddIndexWithOptions() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat("ALTER TABLE employees ADD INDEX idx_lastname (last_name) ", "USING BTREE KEY_BLOCK_SIZE = 16 COMMENT 'Performance tuning' VISIBLE");
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("employees", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression indexExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, indexExp.getOperation(), null);
global::DripSharp.SqlTrellis.Statement.Create.Table.Index index = indexExp.getIndex();
global::DripSharp.Testing.JavaAssertions.NotNull(index, null);
global::DripSharp.Testing.JavaAssertions.Equal("INDEX", index.getIndexKeyword(), null);
global::DripSharp.Testing.JavaAssertions.Equal("idx_lastname", index.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("last_name", global::DripSharp.Runtime.JavaCompat.ListGet(index.getColumnsNames(), 0), null);
global::System.Collections.Generic.IList<string> indexSpec = index.getIndexSpec();
global::DripSharp.Testing.JavaAssertions.NotNull(indexSpec, null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.Runtime.JavaCompat.CollectionCount(indexSpec), null);
global::DripSharp.Testing.JavaAssertions.Equal("USING BTREE", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("KEY_BLOCK_SIZE = 16", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("COMMENT 'Performance tuning'", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 2), null);
global::DripSharp.Testing.JavaAssertions.Equal("VISIBLE", global::DripSharp.Runtime.JavaCompat.ListGet(indexSpec, 3), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddIndex_UsingBeforeColumns() {
string sql = "ALTER TABLE t ADD INDEX idx_name USING BTREE (col)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("t", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression expr = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, expr.getOperation(), null);
global::DripSharp.SqlTrellis.Statement.Create.Table.Index index = expr.getIndex();
global::DripSharp.Testing.JavaAssertions.Equal("idx_name", index.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INDEX", index.getIndexKeyword(), null);
global::DripSharp.Testing.JavaAssertions.Equal("BTREE", index.getUsing(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>("col"), index.getColumnsNames(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableSetDefaultWithAlgorithm() {
string sql = "ALTER TABLE t2 ALTER COLUMN b SET DEFAULT 100, ALGORITHM = INSTANT";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertions.Equal("t2", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression setDefaultExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, setDefaultExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", global::DripSharp.Runtime.JavaCompat.ListGet(setDefaultExp.getColumnSetDefaultList(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("100", global::DripSharp.Runtime.JavaCompat.ListGet(setDefaultExp.getColumnSetDefaultList(), 0).getDefaultValue(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression algorithmExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 1);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALGORITHM, algorithmExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSTANT", algorithmExp.getAlgorithmOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableDropDefaultWithAlgorithm() {
string sql = "ALTER TABLE t2 ALTER COLUMN b DROP DEFAULT, ALGORITHM = INSTANT";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertions.Equal("t2", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression dropDefaultExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, dropDefaultExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("b", global::DripSharp.Runtime.JavaCompat.ListGet(dropDefaultExp.getColumnDropDefaultList(), 0).getColumnName(), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression algorithmExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 1);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALGORITHM, algorithmExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSTANT", algorithmExp.getAlgorithmOption(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableColumnSetInvisible() {
string sql = "ALTER TABLE tbl ALTER COLUMN ts SET INVISIBLE";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression setInvisibleExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, setInvisibleExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ts", global::DripSharp.Runtime.JavaCompat.ListGet(setInvisibleExp.getColumnSetVisibilityList(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(setInvisibleExp.getColumnSetVisibilityList(), 0).isVisible(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableSetInvisible() {
string sql = "ALTER TABLE tbl ALTER ts SET INVISIBLE";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression setInvisibleExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, setInvisibleExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ts", global::DripSharp.Runtime.JavaCompat.ListGet(setInvisibleExp.getColumnSetVisibilityList(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(setInvisibleExp.getColumnSetVisibilityList(), 0).isVisible(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterIndexVisibility() {
string sql = "ALTER TABLE tbl_name ALTER INDEX idx_name VISIBLE";
global::DripSharp.SqlTrellis.Statement.Alter.Alter alterVisible = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::DripSharp.Testing.JavaAssertions.Equal("tbl_name", alterVisible.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressionsVisible = alterVisible.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressionsVisible, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressionsVisible), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression visibleExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressionsVisible, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, visibleExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("idx_name", visibleExp.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("VISIBLE", global::DripSharp.Runtime.JavaCompat.ListGet(visibleExp.getIndex().getIndexSpec(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAlterConstraintEnforced() {
string sql = "ALTER TABLE employees ALTER CONSTRAINT chk_salary ENFORCED";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("employees", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterConstraintExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, alterConstraintExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("CONSTRAINT", alterConstraintExp.getConstraintType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("chk_salary", alterConstraintExp.getConstraintSymbol(), null);
global::DripSharp.Testing.JavaAssertions.True(alterConstraintExp.isEnforced(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAlterCheckNotEnforced() {
string sql = "ALTER TABLE employees ALTER CHECK chk_salary NOT ENFORCED";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("employees", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterCheckExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, alterCheckExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("CHECK", alterCheckExp.getConstraintType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("chk_salary", alterCheckExp.getConstraintSymbol(), null);
global::DripSharp.Testing.JavaAssertions.False(alterCheckExp.isEnforced(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddConstraintUniqueKey() {
string sql = "ALTER TABLE sbtest1 ADD CONSTRAINT UNIQUE KEY ux_c3 (c3)";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("sbtest1", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, alterExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UNIQUE KEY", alterExp.getConstraintType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ux_c3", alterExp.getConstraintSymbol(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAlterIndexInvisible() {
string sql = "ALTER TABLE sbtest1 ALTER INDEX c4 INVISIBLE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("sbtest1", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ALTER, alterExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("c4", alterExp.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INVISIBLE", global::DripSharp.Runtime.JavaCompat.ListGet(alterExp.getIndex().getIndexSpec(), 0), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public virtual void testAlterTableAddIndexInvisible() {
string sql = "ALTER TABLE t1 ADD INDEX k_idx (k) INVISIBLE";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Alter.Alter>(stmt, null);
global::DripSharp.SqlTrellis.Statement.Alter.Alter alter = (global::DripSharp.SqlTrellis.Statement.Alter.Alter)(stmt!);
global::DripSharp.Testing.JavaAssertions.Equal("t1", alter.getTable().getFullyQualifiedName(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression> alterExpressions = alter.getAlterExpressions();
global::DripSharp.Testing.JavaAssertions.NotNull(alterExpressions, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterExpressions), null);
global::DripSharp.SqlTrellis.Statement.Alter.AlterExpression alterExp = global::DripSharp.Runtime.JavaCompat.ListGet(alterExpressions, 0);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterOperation.ADD, alterExp.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(alterExp.getIndex(), null);
global::DripSharp.Testing.JavaAssertions.Equal("k_idx", alterExp.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INDEX", alterExp.getIndex().getIndexKeyword(), null);
global::System.Collections.Generic.IList<string> columnNames = alterExp.getIndex().getColumnsNames();
global::DripSharp.Testing.JavaAssertions.NotNull(columnNames, null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(columnNames), null);
global::DripSharp.Testing.JavaAssertions.Equal("k", global::DripSharp.Runtime.JavaCompat.ListGet(columnNames, 0), null);
global::System.Collections.Generic.IList<string> indexSpec = alterExp.getIndex().getIndexSpec();
global::DripSharp.Testing.JavaAssertions.NotNull(indexSpec, null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(indexSpec, "INVISIBLE"), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql);
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_150079a174a007f5()
{
    foreach (var value in provideMySQLConvertTestCases())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<string>(row[0]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<string>(row[1]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<string>(row[2]) };
    }
}

[Xunit.Fact]
public void __Upstream_90c3a5010ef08117()
{
        try
        {
            this.testAddConstraintKeyIssue320();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_265bc9b65c71428e()
{
        try
        {
            this.testAlterColumnSetCommitTimestamp1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3280055cae2c7ee7()
{
        try
        {
            this.testAlterConstraintWithoutFKSourceColumnsIssue929();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b855a73b088a53c()
{
        try
        {
            this.testAlterIndexVisibility();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6efcc1dc6b2dfe70()
{
        try
        {
            this.testAlterOnDeleteNoAction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dddf8dc232933320()
{
        try
        {
            this.testAlterOnDeleteSetDefault();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_21cb67ac18756093()
{
        try
        {
            this.testAlterOnUpdateCascade();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_76e8924d3125e510()
{
        try
        {
            this.testAlterOnUpdateNoAction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e0af190f9fd86403()
{
        try
        {
            this.testAlterOnUpdateRestrict();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_86a2aba934fc8c13()
{
        try
        {
            this.testAlterOnUpdateSetDefault();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2a72dd308f7d3aa()
{
        try
        {
            this.testAlterOnUpdateSetNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_76888ca40aef68e4()
{
        try
        {
            this.testAlterOnlyIssue928();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_856e04365a837baa()
{
        try
        {
            this.testAlterTableAddColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d8a2dba0843fd61()
{
        try
        {
            this.testAlterTableAddColumn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_980bfcad22b47b29()
{
        try
        {
            this.testAlterTableAddColumn3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d10662b0d033721d()
{
        try
        {
            this.testAlterTableAddColumn4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_75baa1b4fa85a2ac()
{
        try
        {
            this.testAlterTableAddColumn5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b1f796c9051dfca7()
{
        try
        {
            this.testAlterTableAddColumn6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_880a568903bfe045()
{
        try
        {
            this.testAlterTableAddColumnKeywordTypes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ba4010c52de15d0()
{
        try
        {
            this.testAlterTableAddColumnSpanner7();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_84c1e133d8330df9()
{
        try
        {
            this.testAlterTableAddColumnSpanner8();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cfa5cc4e50bfc8ba()
{
        try
        {
            this.testAlterTableAddColumnWithZone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_55b599cc605ae92b()
{
        try
        {
            this.testAlterTableAddColumn_ColumnKeyWordImplicit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b428d9354e49a192()
{
        try
        {
            this.testAlterTableAddColumnsWhitespace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_81f37abd00638de5()
{
        try
        {
            this.testAlterTableAddConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d779aba65c2404ac()
{
        try
        {
            this.testAlterTableAddConstraintUniqueKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c5a56c452de9b9c4()
{
        try
        {
            this.testAlterTableAddConstraintWithConstraintState();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c60adb5af8120054()
{
        try
        {
            this.testAlterTableAddConstraintWithConstraintState2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f8e40643c5de2e2a()
{
        try
        {
            this.testAlterTableAddFullTextIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6bd2fdfa1dcbe3bd()
{
        try
        {
            this.testAlterTableAddFullTextIndexWithOptions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9acc355155c5ff83()
{
        try
        {
            this.testAlterTableAddIndexInvisible();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_152a04092a71da0c()
{
        try
        {
            this.testAlterTableAddIndexWithComment1906();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ed7a4122f3f2a80d()
{
        try
        {
            this.testAlterTableAddIndexWithComment2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1ad48d324492a002()
{
        try
        {
            this.testAlterTableAddIndexWithOptions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_34cbdc183ddca9b1()
{
        try
        {
            this.testAlterTableAddIndex_UsingBeforeColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_268f2d3c3d4c4ecb()
{
        try
        {
            this.testAlterTableAddSpatialIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e81873ddc6148fc8()
{
        try
        {
            this.testAlterTableAddUniqueConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_15d5ce54cc6acfed()
{
        try
        {
            this.testAlterTableAddUnnamedIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6322c9407b0706df()
{
        try
        {
            this.testAlterTableAlterCheckNotEnforced();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dedf19b1ebc1566b()
{
        try
        {
            this.testAlterTableAlterColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e7ab8e2ad167692c()
{
        try
        {
            this.testAlterTableAlterColumnDropNotNullIssue918();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3815c06543732042()
{
        try
        {
            this.testAlterTableAlterConstraintEnforced();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6fd5124e09f7d3ef()
{
        try
        {
            this.testAlterTableAlterIndexInvisible();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7729602ecd6f32f3()
{
        try
        {
            this.testAlterTableAnalyzePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3ecd0f3b725a57cf()
{
        try
        {
            this.testAlterTableBackBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_702a4c1a311bcaa1()
{
        try
        {
            this.testAlterTableChangeColumn1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_30ee80c89242f6ce()
{
        try
        {
            this.testAlterTableChangeColumn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50543b8159c57d2a()
{
        try
        {
            this.testAlterTableChangeColumn3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_069c616cacecfc05()
{
        try
        {
            this.testAlterTableChangeColumn4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a4497314edc46d2()
{
        try
        {
            this.testAlterTableChangeColumnDropDefault();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5e614422beeb6da()
{
        try
        {
            this.testAlterTableChangeColumnDropNotNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4cc4bdd8cf62f13a()
{
        try
        {
            this.testAlterTableCheckConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_31cd3a13e748f0f1()
{
        try
        {
            this.testAlterTableCheckPartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_738a82962dd0acd3()
{
        try
        {
            this.testAlterTableCoalescePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8b689fb6bf18c68()
{
        try
        {
            this.testAlterTableCollate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_56371756359c1e23()
{
        try
        {
            this.testAlterTableColumnCommentIssue1926();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_54b2f1e75b872679()
{
        try
        {
            this.testAlterTableColumnCommentIssue984();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_27ef85fb006bae4d()
{
        try
        {
            this.testAlterTableColumnSetInvisible();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c755336a99547912()
{
        try
        {
            this.testAlterTableCommentIssue1935();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d10a2b08c0ae4105()
{
        try
        {
            this.testAlterTableDefaultValueTrueIssue926();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0aef11717addf4a8()
{
        try
        {
            this.testAlterTableDiscardAllPartitionTablespace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_85da3902828c7574()
{
        try
        {
            this.testAlterTableDiscardPartitionTablespace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f9bc8652b345ca95()
{
        try
        {
            this.testAlterTableDropColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f4b8051da66c8af6()
{
        try
        {
            this.testAlterTableDropColumn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_362021251d10786b()
{
        try
        {
            this.testAlterTableDropColumnIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_05b0519ffab83ae1()
{
        try
        {
            this.testAlterTableDropConstraint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_df9497d38b99a3f4()
{
        try
        {
            this.testAlterTableDropConstraintIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_130a084fc6961376()
{
        try
        {
            this.testAlterTableDropConstraintsIssue1342();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fa62035fdfbbd5e8()
{
        try
        {
            this.testAlterTableDropDefaultWithAlgorithm();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1734996b1e8d963b()
{
        try
        {
            this.testAlterTableDropKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_914256436a6e7c0b()
{
        try
        {
            this.testAlterTableDropMultipleColumnsIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_616d8c48752b5e12()
{
        try
        {
            this.testAlterTableDropMultipleColumnsIfExistsWithParams();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_60cfa9b3cdc0680b()
{
        try
        {
            this.testAlterTableExchangePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_244a97ce379a494f()
{
        try
        {
            this.testAlterTableExchangePartitionWithValidation();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_37ba0ec383e58b91()
{
        try
        {
            this.testAlterTableFK();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4e5fe50b1da01094()
{
        try
        {
            this.testAlterTableForeignKey2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f106cb22981d9fd7()
{
        try
        {
            this.testAlterTableForeignKey3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cb58dd809bd7c0e0()
{
        try
        {
            this.testAlterTableForeignKey4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_617b803eb6cad8e8()
{
        try
        {
            this.testAlterTableForeignKeyIssue981();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dd070aa9525be9b0()
{
        try
        {
            this.testAlterTableForeignKeyIssue981_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_06566a699959df0d()
{
        try
        {
            this.testAlterTableForeignWithFkSchema();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_216d97164858be33()
{
        try
        {
            this.testAlterTableForgeignKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f267ad5490b7861a()
{
        try
        {
            this.testAlterTableImportMultiplePartitionsTablespace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c20c7f0eda0f0eb()
{
        try
        {
            this.testAlterTableIndex586();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3944cfb0b1e64db1()
{
        try
        {
            this.testAlterTableIssue1815();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c50cad7a6680051()
{
        try
        {
            this.testAlterTableKeyBlockSizeAlgorithmLock();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d0166e1d2b5fac09()
{
        try
        {
            this.testAlterTableKeys();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d2d813a75d7f56ae()
{
        try
        {
            this.testAlterTableModifyColumn1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a2b545e35f98dbf3()
{
        try
        {
            this.testAlterTableModifyColumn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_629b9fe9de242b9b()
{
        try
        {
            this.testAlterTableModifyColumn3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_da6ae4ec2ff87e3b()
{
        try
        {
            this.testAlterTableModifyColumn4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a6d82163ca0a7de3()
{
        try
        {
            this.testAlterTableOptimizePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5d393ea5e4894ec3()
{
        try
        {
            this.testAlterTablePK();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a7b04d125b6455e()
{
        try
        {
            this.testAlterTablePartitionByRangeColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_73efbfb869d0ef4b()
{
        try
        {
            this.testAlterTablePartitionByRangeUnixTimestamp();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9db57b92a8b42f24()
{
        try
        {
            this.testAlterTablePartitionByRangeUnixTimestamp2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ca51c678c40db98()
{
        try
        {
            this.testAlterTablePrimaryKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a2e8cb567ade208()
{
        try
        {
            this.testAlterTablePrimaryKeyDeferrable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cd3075316b4645e1()
{
        try
        {
            this.testAlterTablePrimaryKeyDeferrableDisableNoValidate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7344d3be0230ce9a()
{
        try
        {
            this.testAlterTablePrimaryKeyDeferrableValidate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_06011503d17518d6()
{
        try
        {
            this.testAlterTablePrimaryKeyNoValidate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a0315958c2bff68()
{
        try
        {
            this.testAlterTablePrimaryKeyNotDeferrable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eed6eacd70b3385a()
{
        try
        {
            this.testAlterTablePrimaryKeyValidate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0538d359d65c7fed()
{
        try
        {
            this.testAlterTableRebuildPartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f691c1b0a49c0ceb()
{
        try
        {
            this.testAlterTableRemovePartitioning();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7a5cb3476a68a25d()
{
        try
        {
            this.testAlterTableRenameColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c5de33a5d8b7936()
{
        try
        {
            this.testAlterTableRenameColumn2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0253504386a7105e()
{
        try
        {
            this.testAlterTableReorganizePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e8dc679eedb2ced1()
{
        try
        {
            this.testAlterTableRepairPartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_17181342062a6afe()
{
        try
        {
            this.testAlterTableSetDefaultWithAlgorithm();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ad0a57889db197a7()
{
        try
        {
            this.testAlterTableSetInvisible();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_101e23cb0d5f8468()
{
        try
        {
            this.testAlterTableTableCommentIssue984();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_70c0a043fb3f4d64()
{
        try
        {
            this.testAlterTableTruncatePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_36043870554e8e4e()
{
        try
        {
            this.testAlterTableUniqueKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_915792fcd959b018()
{
        try
        {
            this.testDiscardTablespace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0fce819fb3b6e576()
{
        try
        {
            this.testDropColumnRestrictIssue510();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f7cf2df529a28a3f()
{
        try
        {
            this.testDropColumnRestrictIssue551();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c5e76d4d3e151f54()
{
        try
        {
            this.testImportTablespace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_48363df28c8998dc()
{
        try
        {
            this.testIssue1875();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0ab74ecef26d2587()
{
        try
        {
            this.testIssue1890();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_05afe3bb50ca4207()
{
        try
        {
            this.testIssue2027();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_150079a174a007f5")]
public void __Upstream_9651bf7533414c04(string sql, string expectedCharacterSet, string expectedCollation)
{
        try
        {
            this.testIssue2089(sql, expectedCharacterSet, expectedCollation);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec160eb697c0a91c()
{
        try
        {
            this.testIssue2090LockExclusive();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_85a4d4d16c733ef8()
{
        try
        {
            this.testIssue2090LockNone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_53de62f964a37482()
{
        try
        {
            this.testIssue2106AlterTableAddPartition1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fd4245b080c8adf6()
{
        try
        {
            this.testIssue2106AlterTableAddPartition2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8047bc050c41d121()
{
        try
        {
            this.testIssue2106AlterTableAddPartition3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2d176a838b40f70()
{
        try
        {
            this.testIssue2106AlterTableAddPartitionCodeTransaction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_05a06e68f188c743()
{
        try
        {
            this.testIssue2106AlterTableDropPartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_44d8c0e1deb4ed67()
{
        try
        {
            this.testIssue2106AlterTableTruncatePartition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fca2a7030b80a655()
{
        try
        {
            this.testIssue2114AlterTableAutoIncrement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1de8219a8641f57a()
{
        try
        {
            this.testIssue2114AlterTableEncryption();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_974637c129170a44()
{
        try
        {
            this.testIssue2114AlterTableEncryptionWithoutEqual();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_456b80b25d9d85cb()
{
        try
        {
            this.testIssue2114AlterTableEngine();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bf20d867ff0e70ed()
{
        try
        {
            this.testIssue2118AlterTableForceAndEngine();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_136c8df2094c8322()
{
        try
        {
            this.testIssue259();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_689bd2298b7e5381()
{
        try
        {
            this.testIssue633();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a5bc4f534d0f82fe()
{
        try
        {
            this.testIssue633_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_350537956b051e4a()
{
        try
        {
            this.testIssue679();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_59b2ebe5033c28ba()
{
        try
        {
            this.testIssue985_1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7ee9ca116d99c0c5()
{
        try
        {
            this.testIssue985_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8c36b8054442faf1()
{
        try
        {
            this.testOnUpdateOnDeleteOrOnDeleteOnUpdate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2cebdda0727e8db6()
{
        try
        {
            this.testRowFormatKeywordIssue1033();
        }
        finally
        {
        }
}
}
