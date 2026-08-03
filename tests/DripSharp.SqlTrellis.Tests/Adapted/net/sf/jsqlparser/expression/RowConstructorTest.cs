// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class RowConstructorTest {
public virtual void testRowConstructor() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("ROW(dataid, value, calcMark)", true);
}

[Xunit.Fact]
public void __Upstream_05deb186bd380722()
{
        try
        {
            this.testRowConstructor();
        }
        finally
        {
        }
}
}
