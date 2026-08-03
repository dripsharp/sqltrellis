// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class MergeValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateMerge() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("MERGE INTO a USING dual ON (col3 = ? AND col1 = ? AND col2 = ?) WHEN NOT MATCHED THEN INSERT (col1, col2, col3, col4) VALUES (?, ?, ?, ?) WHEN MATCHED THEN UPDATE SET col4 = col4 + ?", "MERGE INTO a USING dual ON (col3 = ? AND col1 = ? AND col2 = ?) WHEN MATCHED THEN UPDATE SET col4 = col4 + ? WHEN NOT MATCHED THEN INSERT (col1, col2, col3, col4) VALUES (?, ?, ?, ?)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

public virtual void testValidateMergeNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("MERGE INTO a USING dual ON (col3 = ? AND col1 = ? AND col2 = ?) WHEN NOT MATCHED THEN INSERT (col1, col2, col3, col4) VALUES (?, ?, ?, ?) WHEN MATCHED THEN UPDATE SET col4 = col4 + ?", "MERGE INTO a USING dual ON (col3 = ? AND col1 = ? AND col2 = ?) WHEN MATCHED THEN UPDATE SET col4 = col4 + ? WHEN NOT MATCHED THEN INSERT (col1, col2, col3, col4) VALUES (?, ?, ?, ?)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC), global::DripSharp.SqlTrellis.Parser.Feature.Feature.merge);
}
}

[Xunit.Fact]
public void __Upstream_a4aca2d449a239ec()
{
        try
        {
            this.testValidateMerge();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9cbf7600e35f6285()
{
        try
        {
            this.testValidateMergeNotAllowed();
        }
        finally
        {
        }
}
}
