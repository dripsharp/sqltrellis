// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class UpsertValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationExecuteNotSupported() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("UPSERT INTO TEST (NAME, ID) VALUES ('foo', 123)", "UPSERT INTO TEST (ID, COUNTER) VALUES (123, 0) ON DUPLICATE KEY UPDATE COUNTER = COUNTER + 1", "UPSERT INTO test.targetTable (col1, col2) SELECT * FROM test.sourceTable", "UPSERT INTO mytable (mycolumn) WITH a AS (SELECT mycolumn FROM mytable) SELECT mycolumn FROM a")) {
foreach (global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType type in global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, type, global::DripSharp.SqlTrellis.Parser.Feature.Feature.upsert);
}
}
}

public virtual void testValidationExecuteNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("UPSERT INTO TEST (NAME, ID) VALUES ('foo', 123)", "UPSERT INTO TEST (ID, COUNTER) VALUES (123, 0) ON DUPLICATE KEY UPDATE COUNTER = COUNTER + 1")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DDL, global::DripSharp.SqlTrellis.Parser.Feature.Feature.upsert, global::DripSharp.SqlTrellis.Parser.Feature.Feature.__field_values);
}
}

[Xunit.Fact]
public void __Upstream_eff1197d702220a5()
{
        try
        {
            this.testValidationExecuteNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_496feb37c2bed8c1()
{
        try
        {
            this.testValidationExecuteNotSupported();
        }
        finally
        {
        }
}
}
