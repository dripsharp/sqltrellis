// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ShowIndexStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationShowIndex() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SHOW INDEX FROM mydatabase")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}
}

public virtual void testValidationShowIndexNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SHOW INDEX FROM mydatabase")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.showIndex);
}
}

[Xunit.Fact]
public void __Upstream_e97f915c72bac342()
{
        try
        {
            this.testValidationShowIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8f082b957a39d4af()
{
        try
        {
            this.testValidationShowIndexNotAllowed();
        }
        finally
        {
        }
}
}
