// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class OrderByValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testOrderBy() {
string sql = "SELECT * FROM tab ORDER BY a ASC, b DESC, c";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testOrderByNullOrdering() {
string sql = "SELECT * FROM tab ORDER BY a ASC NULLS FIRST, b DESC NULLS LAST";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

[Xunit.Fact]
public void __Upstream_8b0bee3e8d933928()
{
        try
        {
            this.testOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9ee302e3e0ca5e3b()
{
        try
        {
            this.testOrderByNullOrdering();
        }
        finally
        {
        }
}
}
