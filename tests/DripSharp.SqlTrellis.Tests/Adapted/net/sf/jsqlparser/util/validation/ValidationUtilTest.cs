// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation;

public class ValidationUtilTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testMap() {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.AsList<string>("col2", "col1"), global::DripSharp.SqlTrellis.Util.Validation.ValidationUtil.map<global::DripSharp.SqlTrellis.Schema.Column>(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Schema.Column>(new global::DripSharp.SqlTrellis.Schema.Column("col2"), new global::DripSharp.SqlTrellis.Schema.Column("col1")), (value0) => value0.getColumnName()), null);
}

[Xunit.Fact]
public void __Upstream_71fb34928dffa30e()
{
        try
        {
            this.testMap();
        }
        finally
        {
        }
}
}
