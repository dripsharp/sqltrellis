// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class InterpretExpressionTest {
public virtual void testInterpret() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("INTERPRET(1 AS INTEGER)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("INTERPRET(SUBSTRING(ENTRY_DATA, 1, 4) AS INTEGER)", true);
}

[Xunit.Fact]
public void __Upstream_0361d1b9602f4776()
{
        try
        {
            this.testInterpret();
        }
        finally
        {
        }
}
}
