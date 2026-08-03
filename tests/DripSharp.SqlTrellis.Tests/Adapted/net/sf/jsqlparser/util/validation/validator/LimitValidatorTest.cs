// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class LimitValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationLimitOffset() {
string sql = "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 3, ?";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}

public virtual void testValidationLimitAndOffset() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SELECT * FROM mytable WHERE mytable.col = 9 LIMIT 3", "SELECT * FROM mytable WHERE mytable.col = 9 LIMIT ? OFFSET 3", "SELECT * FROM mytable WHERE mytable.col = 9 OFFSET ?")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

[Xunit.Fact]
public void __Upstream_b4521fe51beb64a1()
{
        try
        {
            this.testValidationLimitAndOffset();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c20902aeb265828()
{
        try
        {
            this.testValidationLimitOffset();
        }
        finally
        {
        }
}
}
