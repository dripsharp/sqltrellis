// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class TrimFunctionTest {
internal virtual void testTrim() {
string functionStr = "Trim( BOTH 'x' FROM 'xTomxx' )";
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("select ", functionStr);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Expression.TrimFunction trimFunction = new global::DripSharp.SqlTrellis.Expression.TrimFunction().withTrimSpecification(global::DripSharp.SqlTrellis.Expression.TrimFunction.TrimSpecification.BOTH).withExpression(new global::DripSharp.SqlTrellis.Expression.StringValue("x")).withUsingFromKeyword(true).withFromExpression(new global::DripSharp.SqlTrellis.Expression.StringValue("xTomxx"));
global::DripSharp.Testing.JavaAssertions.Equal(functionStr, trimFunction.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(functionStr.Replace(" FROM", ",", global::System.StringComparison.Ordinal), trimFunction.withUsingFromKeyword(false).ToString(), null);
sqlStr = "select trim(BOTH from unnest(string_to_array(initcap(bbbbb),';')))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_fb8fcbf234a02abd()
{
        try
        {
            this.testTrim();
        }
        finally
        {
        }
}
}
