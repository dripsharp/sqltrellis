// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class MemberOfExpressionTest {
internal virtual void testMemberOf() {
string sqlStr = "SELECT 17 MEMBER OF ( cxr_post_id->'$.value' ) ";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT 17 MEMBER OF ( '[23, \"abc\", 17, \"ab\", 10]' ) ";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_afa2740076b5eb2a()
{
        try
        {
            this.testMemberOf();
        }
        finally
        {
        }
}
}
