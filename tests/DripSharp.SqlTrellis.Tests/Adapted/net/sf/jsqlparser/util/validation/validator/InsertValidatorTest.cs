// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class InsertValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationInsert() {
string sql = "INSERT INTO tab1 (a, b) VALUES (5, 'val')";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.values());
}

public virtual void testValidationInsertNotAllowed() {
string sql = "INSERT INTO tab1 (a, b, c) VALUES (5, 'val', ?)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC), global::DripSharp.SqlTrellis.Parser.Feature.Feature.insertValues, global::DripSharp.SqlTrellis.Parser.Feature.Feature.insertFromSelect, global::DripSharp.SqlTrellis.Parser.Feature.Feature.__field_values, global::DripSharp.SqlTrellis.Parser.Feature.Feature.insert);
}

public virtual void testValidationInsertSelect() {
string sql = "INSERT INTO tab1 (a, b, c) SELECT col1, col2, ? FROM tab2 WHERE col3 = ?";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testInsertWithReturning() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("INSERT INTO mytable (mycolumn) VALUES ('1') RETURNING id", "INSERT INTO mytable (mycolumn) VALUES ('1') RETURNING id AS a1, id2 AS a2")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB);
}
}

public virtual void testInsertWithReturningAll() {
string sql = "INSERT INTO mytable (mycolumn) VALUES ('1') RETURNING *";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}

public virtual void testDuplicateKey() {
string sql = "INSERT INTO Users0 (UserId, Key, Value) VALUES (51311, 'T_211', 18) ON DUPLICATE KEY UPDATE Value = 18";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}

public virtual void testInsertSetInDeparsing() {
string sql = "INSERT INTO mytable SET col1 = 12, col2 = name1 * name2;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}

public virtual void testInsertMultiRowValue() {
string sql = "INSERT INTO mytable (col1, col2) VALUES (a, b), (d, e)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

[Xunit.Fact]
public void __Upstream_d72e8c121eb487a9()
{
        try
        {
            this.testDuplicateKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b099a3f5ebb9a4ff()
{
        try
        {
            this.testInsertMultiRowValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f5e14fd82396969()
{
        try
        {
            this.testInsertSetInDeparsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a560d88a4da47abd()
{
        try
        {
            this.testInsertWithReturning();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3490af8a57ecb633()
{
        try
        {
            this.testInsertWithReturningAll();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_abe802b0cada36bf()
{
        try
        {
            this.testValidationInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_428d59d63a0ea125()
{
        try
        {
            this.testValidationInsertNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ca4983dcf11b121d()
{
        try
        {
            this.testValidationInsertSelect();
        }
        finally
        {
        }
}
}
