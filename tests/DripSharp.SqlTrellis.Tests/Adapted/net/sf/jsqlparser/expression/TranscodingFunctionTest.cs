// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class TranscodingFunctionTest {
internal virtual void testTranscoding() {
string functionStr = "CONVERT( 'abc' USING utf8mb4 )";
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT ", functionStr);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.SqlTrellis.Expression.TranscodingFunction transcodingFunction = new global::DripSharp.SqlTrellis.Expression.TranscodingFunction().withExpression(new global::DripSharp.SqlTrellis.Expression.StringValue("abc")).withTranscodingName("utf8mb4");
global::DripSharp.Testing.JavaAssertions.Equal(functionStr, transcodingFunction.ToString(), null);
}

internal virtual void testIssue644() {
string sqlStr = "SELECT CONVERT(int, a) FROM A";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue688() {
string sqlStr = "select * from a order by convert(a.name using gbk) desc";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1257() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT id,name,version,identity,type,desc,enable,content\n", "FROM tbl_template\n"), "WHERE (name like ?)\n"), "ORDER BY convert(name using GBK) ASC");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testUnPivotWithAlias() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT cast(1 as Decimal(18,2))", true);
global::DripSharp.SqlTrellis.Statement.Statement st = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT Convert( Decimal(18,2) , 1 )", true);
}

[Xunit.Fact]
public void __Upstream_b81c6b91db7025f3()
{
        try
        {
            this.testIssue1257();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6e5aa43b8d4a4da0()
{
        try
        {
            this.testIssue644();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7ba424b2d425f4b9()
{
        try
        {
            this.testIssue688();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_384e31d32285bc6e()
{
        try
        {
            this.testTranscoding();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_306aa8eb6e2da9cc()
{
        try
        {
            this.testUnPivotWithAlias();
        }
        finally
        {
        }
}
}
