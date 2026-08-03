// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class HexValueTest {
internal virtual void testHexCode() {
string sqlString = "SELECT 0xF001, X'00A1', X'C3BC'";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlString)!);
global::DripSharp.SqlTrellis.Expression.HexValue hex1 = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.HexValue>(select.getSelectItem(0).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("F001", hex1.getDigits(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(61441), hex1.getLong(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(61441), hex1.getLongValue().getValue(), null);
global::DripSharp.SqlTrellis.Expression.HexValue hex2 = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.HexValue>(select.getSelectItem(1).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("00A1", hex2.getDigits(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(161), hex2.getLong(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(161), hex2.getLongValue().getValue(), null);
global::DripSharp.SqlTrellis.Expression.HexValue hex3 = global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.HexValue>(select.getSelectItem(2).getExpression());
global::DripSharp.Testing.JavaAssertions.Equal("C3BC", hex3.getDigits(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'\u00FC'", hex3.getStringValue().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\u00FC", hex3.getStringValue().getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'\\xC3\\xBC'", hex3.getBlob().ToString(), null);
}

[Xunit.Fact]
public void __Upstream_797396e7dcb26d4e()
{
        try
        {
            this.testHexCode();
        }
        finally
        {
        }
}
}
