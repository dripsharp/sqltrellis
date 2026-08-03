// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class AlterValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testAlterTableAddColumn() {
string sql = "ALTER TABLE mytable ADD COLUMN mycolumn varchar (255)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableAddColumn_ColumnKeyWordImplicit() {
string sql = "ALTER TABLE mytable ADD mycolumn varchar (255)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKey() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKeyDeferrable() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id) DEFERRABLE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKeyNotDeferrable() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id) NOT DEFERRABLE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKeyValidate() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id) VALIDATE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKeyNoValidate() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id) NOVALIDATE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKeyDeferrableValidate() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id) DEFERRABLE VALIDATE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTablePrimaryKeyDeferrableDisableNoValidate() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE animals ADD PRIMARY KEY (id) DEFERRABLE DISABLE NOVALIDATE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableUniqueKey() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE `schema_migrations` ADD UNIQUE KEY `unique_schema_migrations` (`version`)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableForgeignKey() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id) ON DELETE CASCADE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableAddConstraint() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE RESOURCELINKTYPE ADD CONSTRAINT FK_RESOURCELINKTYPE_PARENTTYPE_PRIMARYKEY FOREIGN KEY (PARENTTYPE_PRIMARYKEY) REFERENCES RESOURCETYPE(PRIMARYKEY)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableAddConstraintWithConstraintState() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE RESOURCELINKTYPE ADD CONSTRAINT FK_RESOURCELINKTYPE_PARENTTYPE_PRIMARYKEY FOREIGN KEY (PARENTTYPE_PRIMARYKEY) REFERENCES RESOURCETYPE(PRIMARYKEY) DEFERRABLE DISABLE NOVALIDATE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableAddConstraintWithConstraintState2() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE RESOURCELINKTYPE ADD CONSTRAINT RESOURCELINKTYPE_PRIMARYKEY PRIMARY KEY (PRIMARYKEY) DEFERRABLE NOVALIDATE", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableAddUniqueConstraint() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE Persons ADD UNIQUE (ID)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableForgeignKey2() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableForgeignKey3() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id) ON DELETE RESTRICT", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableForgeignKey4() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE test ADD FOREIGN KEY (user_id) REFERENCES ra_user (id) ON DELETE SET NULL", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableDropColumn() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE test DROP COLUMN YYY", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testAlterTableAlterColumnDropNotNullIssue918() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("ALTER TABLE \"user_table_t\" ALTER COLUMN name DROP NOT NULL", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

[Xunit.Fact]
public void __Upstream_5bbe356da6c5b383()
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
public void __Upstream_8fedd7cb42730420()
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
public void __Upstream_8648e645f832ce78()
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
public void __Upstream_14546c7035a57c6e()
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
public void __Upstream_cb193f1f79008b3b()
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
public void __Upstream_2215c3c8f6885504()
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
public void __Upstream_fbdd6aefef70965c()
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
public void __Upstream_a8d235461a32eed7()
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
public void __Upstream_a5f197a464df8947()
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
public void __Upstream_6cc5003d703a8346()
{
        try
        {
            this.testAlterTableForgeignKey2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_52ce572d829154b7()
{
        try
        {
            this.testAlterTableForgeignKey3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_872395a15fbd7aaa()
{
        try
        {
            this.testAlterTableForgeignKey4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_77b1964a319b3ca6()
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
public void __Upstream_56227d7e123b7ec9()
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
public void __Upstream_5c0a03dd351aaab8()
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
public void __Upstream_922672b222d7d73f()
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
public void __Upstream_d89c1c5636ddbdf9()
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
public void __Upstream_29b0afb00c7347e2()
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
public void __Upstream_bed053c470f458a8()
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
public void __Upstream_fbe98161205d74b8()
{
        try
        {
            this.testAlterTableUniqueKey();
        }
        finally
        {
        }
}
}
