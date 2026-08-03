// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class ExpressionDelimiterTest {
public virtual void testColumnWithDifferentDelimiters() {
string statement = "SELECT mytable.mycolumn:parent:child FROM mytable";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect parsed = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.JsonExpression>(parsed.getSelectItem(0).getExpression(), null);
}

public virtual void testColumnWithEmptyNameParts() {
string statement = "SELECT mytable.:.child FROM mytable";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect parsed = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::DripSharp.SqlTrellis.Schema.Column column = parsed.getSelectItem(0).getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.Testing.JavaAssertions.Equal(".", column.getTableDelimiter(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListOf<string>(":", "."), column.getTable().getNamePartDelimiters(), null);
}

[Xunit.Fact]
public void __Upstream_043539f510f81157()
{
        try
        {
            this.testColumnWithDifferentDelimiters();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_eaa3610a288921d3()
{
        try
        {
            this.testColumnWithEmptyNameParts();
        }
        finally
        {
        }
}
}
