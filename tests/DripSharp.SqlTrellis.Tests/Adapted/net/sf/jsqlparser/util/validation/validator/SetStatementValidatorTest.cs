// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class SetStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateSet() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SET statement_timeout = 0; SET deferred_name_resolution true;", "SET tester 5; SET v = 1, c = 3;", "SET standard_conforming_strings = on;SET statement_timeout = 0")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 2, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

[Xunit.Fact]
public void __Upstream_c6457359002b3b1d()
{
        try
        {
            this.testValidateSet();
        }
        finally
        {
        }
}
}
