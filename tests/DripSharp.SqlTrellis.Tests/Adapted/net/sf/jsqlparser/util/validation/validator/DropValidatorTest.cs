// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class DropValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationDrop() {
string sql = "DROP TABLE tab1; DROP TABLE tab2;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 2, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationDropNotAllowed() {
string sql = "DROP VIEW myview";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.drop, global::DripSharp.SqlTrellis.Parser.Feature.Feature.dropView);
}

public virtual void testValidationDropIfExists() {
string sql = "DROP TABLE IF EXISTS tab2;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidationDropIndexIfExists() {
string sql = "DROP INDEX IF EXISTS idx_tab2_id;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidationDropViewIfExists() {
string sql = "DROP VIEW IF EXISTS myview;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidationDropSchemaIfExists() {
string sql = "DROP SCHEMA IF EXISTS myschema;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidationDropSequenceIfExists() {
string sql = "DROP SEQUENCE IF EXISTS mysequence;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Parser.Feature.Feature.dropSequence);
}

[Xunit.Fact]
public void __Upstream_b048b975cf598162()
{
        try
        {
            this.testValidationDrop();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_33fa535c8b2bf9fd()
{
        try
        {
            this.testValidationDropIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_85928a3ed6acca99()
{
        try
        {
            this.testValidationDropIndexIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_303961def535c930()
{
        try
        {
            this.testValidationDropNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_588e2e46070798dd()
{
        try
        {
            this.testValidationDropSchemaIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_36302669eb13e809()
{
        try
        {
            this.testValidationDropSequenceIfExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c6560ba573722bfe()
{
        try
        {
            this.testValidationDropViewIfExists();
        }
        finally
        {
        }
}
}
