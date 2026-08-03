// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class GroupByValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationSelectGroupBy() {
string sql = "SELECT MAX(a, b, c), COUNT(*), D FROM tab1 GROUP BY D";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationHaving() {
string sql = "SELECT MAX(tab1.b) FROM tab1 WHERE a > 34 GROUP BY tab1.b HAVING MAX(tab1.b) > 56";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testGroupingSets() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SELECT COL_1, COL_2, COL_3, COL_4, COL_5, COL_6 FROM TABLE_1 GROUP BY GROUPING SETS ((COL_1, COL_2, COL_3, COL_4), (COL_5, COL_6))", "SELECT COL_1 FROM TABLE_1 GROUP BY GROUPING SETS (COL_1)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

[Xunit.Fact]
public void __Upstream_2b67223a3c87ef0d()
{
        try
        {
            this.testGroupingSets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7a549999d8653ebd()
{
        try
        {
            this.testValidationHaving();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_be1718069adccb4c()
{
        try
        {
            this.testValidationSelectGroupBy();
        }
        finally
        {
        }
}
}
