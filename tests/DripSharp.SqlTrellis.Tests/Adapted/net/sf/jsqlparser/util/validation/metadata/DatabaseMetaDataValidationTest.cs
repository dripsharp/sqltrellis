// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Metadata;

public class DatabaseMetaDataValidationTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
private global::System.Data.Common.DbConnection connection = null!;

private string databaseName = null!;

public virtual void setupDatabase() {
this.databaseName = global::DripSharp.Runtime.JavaCompat.Concat("testdb_", global::System.Math.Abs(global::System.Guid.NewGuid().GetHashCode()));
this.connection = global::DripSharp.SqlTrellis.Tests.Support.OpenH2Connection(global::DripSharp.Runtime.JavaCompat.Concat("jdbc:h2:mem:", this.databaseName));
global::DripSharp.SqlTrellis.Tests.Support.Execute(global::DripSharp.Runtime.JavaCompat.PrepareStatement(this.connection, "CREATE TABLE mytable (id bigint, ref bigint, description varchar(100), active boolean);"));
global::DripSharp.SqlTrellis.Tests.Support.Execute(global::DripSharp.Runtime.JavaCompat.PrepareStatement(this.connection, "CREATE TABLE mysecondtable (id bigint, description varchar(100), active boolean);"));
global::DripSharp.SqlTrellis.Tests.Support.Execute(global::DripSharp.Runtime.JavaCompat.PrepareStatement(this.connection, "CREATE VIEW myview AS SELECT * FROM mytable"));
}

public virtual void testValidationAlterTable() {
string sql = "ALTER TABLE mytable ADD price numeric(10,5) not null";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
global::DripSharp.SqlTrellis.Tests.Support.Execute(global::DripSharp.Runtime.JavaCompat.PrepareStatement(this.connection, sql));
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateMetadata(sql, 1, 1, meta.clearCache(), false, "price");
}

public virtual void testValidationAlterTableAlterColumn() {
string sql = "ALTER TABLE mytable ALTER COLUMN description SET NOT NULL";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationMetadataInsert() {
string sql = "INSERT INTO mytable (id, description, active) VALUES (1, 'test', 1)";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationMetadataSelectWithColumnsAndAlias() {
string sql = "SELECT * FROM mytable t JOIN mysecondtable t2 WHERE t.ref = t2.id AND t.id = ?";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationMetadataUpdate() {
string sql = "UPDATE mytable t SET t.ref = 2 WHERE t.id = 1";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationMetadataDelete() {
string sql = "DELETE FROM mytable t WHERE t.id = 1 and ref = 2";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationMetadataDeleteError() {
string sql = "DELETE FROM mytable t WHERE t.id = 1 and x.ref = 2";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateMetadata(sql, 1, 1, meta, true, "x.ref");
}

public virtual void testValidationMetadataSelectWithColumns() {
string sql = "SELECT * FROM mytable JOIN mysecondtable WHERE mytable.ref = mysecondtable.id AND mysecondtable.id = ?";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationMetadataSelectWithoutColumns() {
string sql = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("SELECT * FROM %s.public.mytable", this.databaseName);
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
sql = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("SELECT * FROM public.mytable", this.databaseName);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta.clearCache());
sql = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("SELECT public.mytable.id FROM mytable", this.databaseName);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta.clearCache());
}

public virtual void testValidationDropView3Parts() {
string sql = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("DROP VIEW %s.public.myview", this.databaseName);
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE, false);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationDropView2Parts() {
string sql = "DROP VIEW public.myview";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE, false);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

public virtual void testValidationDropViewDoesNotExist() {
string sql = "DROP VIEW public.anotherView";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE, false);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateMetadata(sql, 1, 1, meta, true, global::DripSharp.Runtime.JavaCompat.JavaStringFormat("public.anotherView", this.databaseName));
}

public virtual void testValidationMetadataSelectWithColumnsAndAlias2() {
string sql = "select my.id from mytable as my";
global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability meta = new global::DripSharp.SqlTrellis.Util.Validation.Metadata.JdbcDatabaseMetaDataCapability(this.connection, global::DripSharp.SqlTrellis.Util.Validation.Metadata.NamesLookup.UPPERCASE);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, meta);
}

[Xunit.Fact]
public void __Upstream_12c185399982a52f()
{
        this.setupDatabase();
        try
        {
            this.testValidationAlterTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_26997c3f65489e62()
{
        this.setupDatabase();
        try
        {
            this.testValidationAlterTableAlterColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8a46dd056bc871d()
{
        this.setupDatabase();
        try
        {
            this.testValidationDropView2Parts();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d0131a8ed4d3475e()
{
        this.setupDatabase();
        try
        {
            this.testValidationDropView3Parts();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8048dbc802a25493()
{
        this.setupDatabase();
        try
        {
            this.testValidationDropViewDoesNotExist();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7f68b0f7bf3406b9()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a8f5acbbcec972d3()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataDeleteError();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_893a0e2a19d066a8()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1ab0b874a8f50d2f()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataSelectWithColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ddea9c50a918b31f()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataSelectWithColumnsAndAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7c26553382234390()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataSelectWithColumnsAndAlias2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_45fe9b700eef020d()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataSelectWithoutColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_185c17b61b386a77()
{
        this.setupDatabase();
        try
        {
            this.testValidationMetadataUpdate();
        }
        finally
        {
        }
}
}
