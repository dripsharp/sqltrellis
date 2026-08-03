// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class StatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateCreateSchema() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE SCHEMA my_schema", "CREATE SCHEMA myschema AUTHORIZATION myauth")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testValidateCreateSchemaNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE SCHEMA my_schema", "CREATE SCHEMA myschema AUTHORIZATION myauth")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.createSchema);
}
}

public virtual void testValidateDescNoErrors() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("DESC table_name", "EXPLAIN table_name")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}
}

public virtual void testValidateTruncate() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("TRUNCATE TABLE my_table", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidateCommit() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("COMMIT", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidateBlock() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("BEGIN UPDATE tab SET val = 1 WHERE col = 2; END;", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

public virtual void testValidateComment() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("COMMENT ON VIEW myschema.myView IS 'myComment'", "COMMENT ON COLUMN myTable.myColumn is 'Some comment'", "COMMENT ON TABLE table1 IS 'comment1'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

[Xunit.Fact]
public void __Upstream_5afe98015fb75ade()
{
        try
        {
            this.testValidateBlock();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9e606aa1ce957978()
{
        try
        {
            this.testValidateComment();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d11ff1a9f84c85e7()
{
        try
        {
            this.testValidateCommit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ba9581c5c1c7f50f()
{
        try
        {
            this.testValidateCreateSchema();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1ee8588d194c8e60()
{
        try
        {
            this.testValidateCreateSchemaNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6e41e721b4e841ff()
{
        try
        {
            this.testValidateDescNoErrors();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6bda9e395e67ded0()
{
        try
        {
            this.testValidateTruncate();
        }
        finally
        {
        }
}
}
