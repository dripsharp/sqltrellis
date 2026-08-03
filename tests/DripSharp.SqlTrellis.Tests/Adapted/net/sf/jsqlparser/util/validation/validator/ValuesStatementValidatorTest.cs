// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ValuesStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateValuesStatement() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("WITH w (col1, col2, col3) AS (VALUES ('Header1', 'Header2', 'Header3') UNION ALL SELECT a, b, c FROM tab) SELECT * FROM w", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

[Xunit.Fact]
public void __Upstream_91e6dfbd32e27ec6()
{
        try
        {
            this.testValidateValuesStatement();
        }
        finally
        {
        }
}
}
