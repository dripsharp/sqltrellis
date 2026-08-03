// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class ClickHouseTest {
public virtual void testGlobalJoin() {
string sql = "SELECT a.*,b.* from lineorder_all as a  global left join supplier_all as b on a.LOLINENUMBER=b.SSUPPKEY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testFunctionWithAttributesIssue1742() {
string sql = "SELECT f1(arguments).f2.f3 from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
sql = "SELECT f1(arguments).f2(arguments).f3.f4 from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
sql = "SELECT schemaName.f1(arguments).f2(arguments).f3.f4 from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testGlobalIn() {
string sql = "SELECT lo_linenumber,lo_orderkey from lo_linenumber where lo_linenumber global in (1,2,3)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testGlobalKeywordIssue1883() {
string sqlStr = "select a.* from  a global join  b on a.name = b.name ";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(select.getJoins(), 0).isGlobal(), null);
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("select a.* from  a global");
}, "Fail when restricted keyword GLOBAL is used as an Alias.");
}

[Xunit.Fact]
public void __Upstream_b809905259f60206()
{
        try
        {
            this.testFunctionWithAttributesIssue1742();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a66d04573dece3c2()
{
        try
        {
            this.testGlobalIn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7166e9ddcbfd480f()
{
        try
        {
            this.testGlobalJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a6c6d6b7994dd6c()
{
        try
        {
            this.testGlobalKeywordIssue1883();
        }
        finally
        {
        }
}
}
