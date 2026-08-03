// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class CreateTableValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationCreateTable() {
string sql = "CREATE TABLE tab1 (id NUMERIC(10), val VARCHAR(30));";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationDropNotAllowed() {
string sql = "CREATE TABLE tab1 (id NUMERIC(10), val VARCHAR(30));";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.createTable);
}

public virtual void testValidationCreateTableWithIndex() {
string sql = "CREATE TABLE test_descending_indexes (c1 INT, c2 INT, INDEX idx1 (c1 ASC, c2 DESC))";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationCreateTableWithIndex2() {
string sql = "CREATE TABLE TABLE1 (COLUMN1 VARCHAR2 (15), COLUMN2 VARCHAR2 (15), CONSTRAINT P_PK PRIMARY KEY (COLUMN1) USING INDEX TABLESPACE \"T_INDEX\") TABLESPACE \"T_SPACE\"";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationCreateTableFromSelect() {
string sql = "CREATE TABLE public.sales1 AS (SELECT * FROM public.sales)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationCreateTableForeignKeyPrimaryKey() {
string sql = "CREATE TABLE test (id INT UNSIGNED NOT NULL AUTO_INCREMENT, string VARCHAR (20), user_id INT UNSIGNED, PRIMARY KEY (id), FOREIGN KEY (user_id) REFERENCES ra_user(id))";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationRowMovementOption() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE TABLE test (startdate DATE) ENABLE ROW MOVEMENT", "CREATE TABLE test (startdate DATE) DISABLE ROW MOVEMENT", "CREATE TABLE test (startdate DATE) DISABLE ROW MOVEMENT AS SELECT 1 FROM dual")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}
}

[Xunit.Fact]
public void __Upstream_aa191ba22e9d899e()
{
        try
        {
            this.testValidationCreateTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d2492f544ca75dff()
{
        try
        {
            this.testValidationCreateTableForeignKeyPrimaryKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a98c687528bb5396()
{
        try
        {
            this.testValidationCreateTableFromSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e809c021d6582697()
{
        try
        {
            this.testValidationCreateTableWithIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_536253e185a709d8()
{
        try
        {
            this.testValidationCreateTableWithIndex2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cea6e6b6f7249c7c()
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
public void __Upstream_4f1e7fccabbe34b9()
{
        try
        {
            this.testValidationRowMovementOption();
        }
        finally
        {
        }
}
}
