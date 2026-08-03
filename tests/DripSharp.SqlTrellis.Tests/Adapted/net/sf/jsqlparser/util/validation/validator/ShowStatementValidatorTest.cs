// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ShowStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationShowTables() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SHOW mydatabase", "SHOW transaction_isolation")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}
}

public virtual void testValidationShowTablesNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SHOW mydatabase", "SHOW transaction_isolation")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.show);
}
}

[Xunit.Fact]
public void __Upstream_1281d987e26f2694()
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
public void __Upstream_9d468dc5e077209c()
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
