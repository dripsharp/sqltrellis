// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class FunctionTest {
internal virtual void testNestedFunctions() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select cust_gender, count(*) as cnt, round(avg(age)) as avg_age\n", "   from mining_data_apply_v\n"), "   where prediction(dt_sh_clas_sample cost model\n"), "      using cust_marital_status, education, household_size) = 1\n"), "   group by cust_gender\n"), "   order by cust_gender");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testCallFunction() {
string sqlStr = "call dbms_scheduler.auto_purge ( ) ";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testChainedFunctions() {
string sqlStr = "select f1(a1=1).f2 = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "select f1(a1=1).f2(b).f2 = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDatetimeParameter() {
string sqlStr = "SELECT DATE(DATETIME '2016-12-25 23:59:59')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testFunctionArrayParameter() {
string sqlStr = "select unnest(ARRAY[1,2,3], nested >= true) as a";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testSubSelectArrayWithoutKeywordParameter() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "  email,\n"), "  REGEXP_CONTAINS(email, r'@[a-zA-Z0-9-]+\\.[a-zA-Z0-9-.]+') AS is_valid\n"), "FROM\n"), "  (SELECT\n"), "    ['foo@example.com', 'bar@example.org', 'www.example.net']\n"), "    AS addresses),\n"), "  UNNEST(addresses) AS email");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testSubSelectParameterWithoutParentheses() {
string sqlStr = "SELECT COALESCE(SELECT mycolumn FROM mytable, 0)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withUnparenthesizedSubSelects(true));
}

internal virtual void testSimpleFunctionIssue2059() {
string sqlStr = "select count(*) from zzz";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => {
parser.withAllowComplexParsing(false);
});
}

internal virtual void testListAggOnOverflow(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_c3454bd5b9d02b98()
{
        try
        {
            this.testCallFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ac614e100a46e712()
{
        try
        {
            this.testChainedFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_70073dcfd1bf81bd()
{
        try
        {
            this.testDatetimeParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dc95a33e3934b84f()
{
        try
        {
            this.testFunctionArrayParameter();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("select LISTAGG(field, ',' on overflow truncate '...') from dual")]
[Xunit.InlineData("select LISTAGG(field, ',' on overflow truncate '...' with count) from dual")]
[Xunit.InlineData("select LISTAGG(field, ',' on overflow truncate '...' without count) from dual")]
[Xunit.InlineData("select LISTAGG(field, ',' on overflow error) from dual")]
[Xunit.InlineData("SELECT department, \n       LISTAGG(name, ', ' ON OVERFLOW TRUNCATE '... (truncated)' WITH COUNT) WITHIN GROUP (ORDER BY name)\n       AS employee_names\nFROM employees\nGROUP BY department;")]
public void __Upstream_c7d5642e0eb19ed2(string sqlStr)
{
        try
        {
            this.testListAggOnOverflow(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_76dbbf510b3702fc()
{
        try
        {
            this.testNestedFunctions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab9fca9d63f8289b()
{
        try
        {
            this.testSimpleFunctionIssue2059();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_535d4ee5894f12c4()
{
        try
        {
            this.testSubSelectArrayWithoutKeywordParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0732c1cc7de5d3d9()
{
        try
        {
            this.testSubSelectParameterWithoutParentheses();
        }
        finally
        {
        }
}
}
