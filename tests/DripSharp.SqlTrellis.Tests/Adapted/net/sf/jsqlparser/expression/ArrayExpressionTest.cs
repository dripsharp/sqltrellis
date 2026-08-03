// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class ArrayExpressionTest {
internal virtual void testColumnArrayExpression() {
string sqlStr = "SELECT a[2+1] AS a";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
var selectItem = select.getSelectItem(0);
global::DripSharp.SqlTrellis.Schema.Column column = selectItem.getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.ArrayConstructor>(column.getArrayConstructor(), null);
}

[Xunit.Fact]
public void __Upstream_167b2964a186fe03()
{
        try
        {
            this.testColumnArrayExpression();
        }
        finally
        {
        }
}
}
