// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ShowTablesStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationShowTables() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SHOW TABLES", "SHOW EXTENDED FULL TABLES", "SHOW EXTENDED TABLES FROM db_name", "SHOW FULL TABLES IN db_name", "SHOW TABLES LIKE '%FOO%'", "SHOW TABLES WHERE table_name = 'FOO'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}
}

public virtual void testValidationShowTablesNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SHOW TABLES", "SHOW EXTENDED FULL TABLES", "SHOW EXTENDED TABLES FROM db_name", "SHOW FULL TABLES IN db_name", "SHOW TABLES LIKE '%FOO%'", "SHOW TABLES WHERE table_name = 'FOO'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.showTables);
}
}

[Xunit.Fact]
public void __Upstream_0ad1094643063817()
{
        try
        {
            this.testValidationShowTables();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_260514f9a9aec1c5()
{
        try
        {
            this.testValidationShowTablesNotAllowed();
        }
        finally
        {
        }
}
}
