// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class GrantValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateGrant() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("GRANT SELECT ON t1 TO u", "GRANT SELECT, INSERT ON t1 TO u, u2", "GRANT role1 TO u, u2", "GRANT SELECT, INSERT, UPDATE, DELETE ON T1 TO ADMIN_ROLE", "GRANT ROLE_1 TO TEST_ROLE_1, TEST_ROLE_2")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testValidateGrantNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("GRANT SELECT ON t1 TO u", "GRANT SELECT, INSERT ON t1 TO u, u2", "GRANT role1 TO u, u2", "GRANT SELECT, INSERT, UPDATE, DELETE ON T1 TO ADMIN_ROLE", "GRANT ROLE_1 TO TEST_ROLE_1, TEST_ROLE_2")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.grant);
}
}

[Xunit.Fact]
public void __Upstream_b33951c1b89edd3a()
{
        try
        {
            this.testValidateGrant();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec2cc3b5a3aa58e5()
{
        try
        {
            this.testValidateGrantNotAllowed();
        }
        finally
        {
        }
}
}
