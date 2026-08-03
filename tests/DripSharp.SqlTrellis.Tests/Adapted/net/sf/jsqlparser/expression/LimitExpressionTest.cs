// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class LimitExpressionTest {
public virtual void testIssue933() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tmp3 LIMIT '2'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM tmp3 LIMIT (SELECT 2)", true);
}

public virtual void testIssue1373() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT 1 LIMIT 1+0", true);
}

public virtual void testIssue1376() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select 1 offset '0'", true);
}

public virtual void testMethods() {
string sqlStr = "SELECT * FROM tmp3 LIMIT 5 OFFSET 3";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.LongValue longValue = plainSelect.getLimit().getRowCount<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue));
global::DripSharp.Testing.JavaAssertions.NotNull(longValue, null);
global::DripSharp.Testing.JavaAssertions.Equal(longValue, longValue, null);
global::DripSharp.Testing.JavaAssertions.Null(plainSelect.getLimit().getOffset<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)), null);
global::DripSharp.Testing.JavaAssertions.NotNull(plainSelect.getOffset().getOffset<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)), null);
sqlStr = "SELECT * FROM tmp3 LIMIT ALL";
plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.AllValue allValue = plainSelect.getLimit().getRowCount<global::DripSharp.SqlTrellis.Expression.AllValue>(typeof(global::DripSharp.SqlTrellis.Expression.AllValue));
allValue.accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>()), (object)default!);
}

[Xunit.Fact]
public void __Upstream_ee50d5cc122c4e8f()
{
        try
        {
            this.testIssue1373();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4653040316549b47()
{
        try
        {
            this.testIssue1376();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_618d30080ba2c454()
{
        try
        {
            this.testIssue933();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5cd56b29f3a09f1c()
{
        try
        {
            this.testMethods();
        }
        finally
        {
        }
}
}
