// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class RefreshMaterializedViewStatementTest {
public virtual void testSimpleUse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("REFRESH MATERIALIZED VIEW my_view");
}

[Xunit.Fact]
public void __Upstream_ef907a6589a149ac()
{
        try
        {
            this.testSimpleUse();
        }
        finally
        {
        }
}
}
