// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class SafeCastExpressionTest {
public virtual void testSafeCast() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("SAFE_CAST(ROW(dataid, value, calcMark) AS ROW(datapointid CHAR, value CHAR, calcMark CHAR))", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("SAFE_CAST(ROW(dataid, value, calcMark) AS testcol)", true);
}

[Xunit.Fact]
public void __Upstream_fae37aded8e7759b()
{
        try
        {
            this.testSafeCast();
        }
        finally
        {
        }
}
}
