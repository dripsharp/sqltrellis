// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ReplaceValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateReplace() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("REPLACE mytable SET col1='as', col2=?, col3=565", "REPLACE mytable (col1, col2, col3) VALUES ('as', ?, 565)", "REPLACE mytable (col1, col2, col3) SELECT * FROM mytable3")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}
}

public virtual void testValidateReplaceNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("REPLACE mytable SET col1='as', col2=?, col3=565", "REPLACE mytable (col1, col2, col3) VALUES ('as', ?, 565)", "REPLACE mytable (col1, col2, col3) SELECT * FROM mytable3")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC).add(global::DripSharp.SqlTrellis.Parser.Feature.Feature.__field_values), global::DripSharp.SqlTrellis.Parser.Feature.Feature.upsert);
}
}

[Xunit.Fact]
public void __Upstream_3388a3ff7d18f98e()
{
        try
        {
            this.testValidateReplace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aaf38c9c208f78df()
{
        try
        {
            this.testValidateReplaceNotAllowed();
        }
        finally
        {
        }
}
}
