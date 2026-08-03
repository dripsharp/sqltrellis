// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class OverlapsConditionTest {
public virtual void testOverlapsCondition() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("(t1.start, t1.end) overlaps (t2.start, t2.end)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where (start_one, end_one) overlaps (start_two, end_two)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from t1 left join t2 on (t1.start, t1.end) overlaps (t2.start, t2.end)", true);
}

[Xunit.Fact]
public void __Upstream_13c883537aecfeb3()
{
        try
        {
            this.testOverlapsCondition();
        }
        finally
        {
        }
}
}
