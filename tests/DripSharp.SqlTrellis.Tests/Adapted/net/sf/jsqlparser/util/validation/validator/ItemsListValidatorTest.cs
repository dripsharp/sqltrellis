// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ItemsListValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationExpressionList() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("select coalesce(a, b, c) from tab", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testInsertMultiRowValue() {
string sql = "INSERT INTO mytable (col1, col2) VALUES (a, b), (d, e)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

[Xunit.Fact]
public void __Upstream_67ad642acb0d0182()
{
        try
        {
            this.testInsertMultiRowValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3dba63a30d2a3abb()
{
        try
        {
            this.testValidationExpressionList();
        }
        finally
        {
        }
}
}
