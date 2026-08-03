// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class JdbcNamedParameterTest {
internal virtual void testDoubleColon() {
string sqlStr = "select :test";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(select.getSelectItems(), 0).getExpression() is global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter), null);
}

internal virtual void testAmpersand() {
string sqlStr = "select &test, 'a & b', a & b";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(select.getSelectItems(), 0).getExpression() is global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(select.getSelectItems(), 2).getExpression() is global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.BitwiseAnd), null);
}

internal virtual void testIssue1785() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("select * from all_tables\n", "where owner = &myowner");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1970() {
string sqlStr = "SELECT a from tbl where col = $2";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo where = (global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo)(select.getWhere()!);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.JdbcParameter>(where.getRightExpression(), null);
global::DripSharp.SqlTrellis.Expression.JdbcParameter p = (global::DripSharp.SqlTrellis.Expression.JdbcParameter)(where.getRightExpression()!);
global::DripSharp.Testing.JavaAssertions.Equal(2, p.getIndex(), null);
}

[Xunit.Fact]
public void __Upstream_ceb2709b466c401b()
{
        try
        {
            this.testAmpersand();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2e1a72cd516b1aba()
{
        try
        {
            this.testDoubleColon();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3abf8c22aa51b511()
{
        try
        {
            this.testIssue1785();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f6d8bfad54255f88()
{
        try
        {
            this.testIssue1970();
        }
        finally
        {
        }
}
}
