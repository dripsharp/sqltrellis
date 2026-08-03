// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class DeleteValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationDelete() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat("DELETE FROM tab1 WHERE ref IN (SELECT id FROM tab2 WHERE criteria = ?); ", "DELETE FROM tab2 t2 WHERE t2.criteria = ?;");
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 2, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationDeleteNotAllowed() {
string sql = "DELETE FROM tab2 t2 WHERE t2.criteria = ?;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC), global::DripSharp.SqlTrellis.Parser.Feature.Feature.delete);
}

public virtual void testValidationDeleteSupportedAndNotSupported() {
string sql = "DELETE a1, a2 FROM t1 AS a1 INNER JOIN t2 AS a2 WHERE a1.id = a2.id;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.Version>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2), global::DripSharp.SqlTrellis.Parser.Feature.Feature.deleteTables, global::DripSharp.SqlTrellis.Parser.Feature.Feature.deleteJoin);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}

public virtual void testValidationDeleteLimitOrderBy() {
string sql = "DELETE FROM table t WHERE t.criteria > 5 ORDER BY t.criteria LIMIT 1;";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}

[Xunit.Fact]
public void __Upstream_e5fddc2d781f1de3()
{
        try
        {
            this.testValidationDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7cef4c33d963399c()
{
        try
        {
            this.testValidationDeleteLimitOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b90bc79b5479b34c()
{
        try
        {
            this.testValidationDeleteNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f08e2107ba8097cb()
{
        try
        {
            this.testValidationDeleteSupportedAndNotSupported();
        }
        finally
        {
        }
}
}
