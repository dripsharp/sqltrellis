// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class AlterViewValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateAlterView() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("ALTER VIEW myview AS SELECT * FROM mytab")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

public virtual void testValidateAlterViewNotSupported() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("REPLACE VIEW myview(a, b) AS SELECT a, b FROM mytab")) {
foreach (global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType type in global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER)) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, type, global::DripSharp.SqlTrellis.Parser.Feature.Feature.alterViewReplace);
}
}
}

public virtual void testValidateAlterViewNotAllowed() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed("ALTER VIEW myview AS SELECT * FROM mytab", 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.CREATE.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT), global::DripSharp.SqlTrellis.Parser.Feature.Feature.alterView);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed("REPLACE VIEW myview(a, b) AS SELECT a, b FROM mytab", 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.CREATE.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT), global::DripSharp.SqlTrellis.Parser.Feature.Feature.alterView, global::DripSharp.SqlTrellis.Parser.Feature.Feature.alterViewReplace);
}

[Xunit.Fact]
public void __Upstream_785c51aff370893c()
{
        try
        {
            this.testValidateAlterView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2340c97ea1956c44()
{
        try
        {
            this.testValidateAlterViewNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_25de2d7d0684eb8d()
{
        try
        {
            this.testValidateAlterViewNotSupported();
        }
        finally
        {
        }
}
}
