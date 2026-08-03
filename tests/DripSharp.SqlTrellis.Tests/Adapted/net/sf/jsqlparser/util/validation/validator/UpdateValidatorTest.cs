// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class UpdateValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationUpdate() {
string sql = "UPDATE tab1 SET ref = 5 WHERE id = 10;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.values());
}

public virtual void testValidationUpdateNotAllowed() {
string sql = "UPDATE tab1 SET ref = ? WHERE id = ?;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC), global::DripSharp.SqlTrellis.Parser.Feature.Feature.update);
}

public virtual void testUpdateWithFrom() {
string sql = "UPDATE table1 SET columna = 5 FROM table1 LEFT JOIN table2 ON col1 = col2";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

public virtual void testUpdateMultiTable() {
string sql = "UPDATE T1, T2 SET T1.C2 = T2.C2, T2.C3 = 'UPDATED' WHERE T1.C1 = T2.C1 AND T1.C2 < 10";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB);
}

public virtual void testUpdateWithSelect() {
string sql = "UPDATE mytable t1 SET (col1, col2, col3) = (SELECT a, b, c FROM mytable2 t2 WHERE t2.id = t1.id)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testUpdateWithReturningAll() {
string sql = "UPDATE tablename SET col = 'thing' WHERE id = 1 RETURNING *";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testUpdateWithReturningList() {
string sql = "UPDATE tablename SET col = 'thing' WHERE id = 1 RETURNING col_1, col_2, col_3";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testUpdateWithOrderByAndLimit() {
string sql = "UPDATE tablename SET col = 'thing' WHERE ref > 10 ORDER BY col LIMIT 10";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB);
}

[Xunit.Fact]
public void __Upstream_71b3e4f142635b54()
{
        try
        {
            this.testUpdateMultiTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3b2ada82351860a0()
{
        try
        {
            this.testUpdateWithFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_67e8ff9021b88857()
{
        try
        {
            this.testUpdateWithOrderByAndLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f67d1ff3a3e053da()
{
        try
        {
            this.testUpdateWithReturningAll();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_434e840ee4cfb3a5()
{
        try
        {
            this.testUpdateWithReturningList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1deb4b2e92733bd7()
{
        try
        {
            this.testUpdateWithSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d30b8c26a82d9d6()
{
        try
        {
            this.testValidationUpdate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6515031a07f1d771()
{
        try
        {
            this.testValidationUpdateNotAllowed();
        }
        finally
        {
        }
}
}
