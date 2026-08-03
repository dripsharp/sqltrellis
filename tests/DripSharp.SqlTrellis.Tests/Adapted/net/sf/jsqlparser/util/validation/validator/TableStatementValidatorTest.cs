// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class TableStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationSelectAllowed() {
string sql = "TABLE columns ORDER BY column_name LIMIT 10 OFFSET 10";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.MySqlVersion.V8_0);
}

public virtual void testValidationSelectNotAllowed() {
string sql = "TABLE columns ORDER BY column_name LIMIT 10 OFFSET 10";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DDL, global::DripSharp.SqlTrellis.Parser.Feature.Feature.select, global::DripSharp.SqlTrellis.Parser.Feature.Feature.tableStatement);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.Version>(global::DripSharp.SqlTrellis.Util.Validation.Feature.PostgresqlVersion.V14), global::DripSharp.SqlTrellis.Parser.Feature.Feature.tableStatement);
}

[Xunit.Fact]
public void __Upstream_e918259d89e7c39d()
{
        try
        {
            this.testValidationSelectAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4be1c7a6ba66a483()
{
        try
        {
            this.testValidationSelectNotAllowed();
        }
        finally
        {
        }
}
}
