// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SampleClauseTest {
internal virtual void standardTestIssue1593(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void standardOracleIssue1826() {
string sqlStr = "SELECT * from table_name SAMPLE(99)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDuckDB() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM (SELECT * FROM addresses)\n"), "USING SAMPLE SYSTEM (10 PERCENT);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testBigQuery() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM (SELECT * FROM addresses)\n"), "TABLESAMPLE SYSTEM (10 PERCENT);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Theory]
[Xunit.InlineData("SELECT * from table_name SAMPLE(99)")]
[Xunit.InlineData("SELECT * from table_name SAMPLE(99.1)")]
[Xunit.InlineData("SELECT * from table_name SAMPLE BLOCK (99)")]
[Xunit.InlineData("SELECT * from table_name SAMPLE BLOCK (99.1)")]
[Xunit.InlineData("SELECT * from table_name SAMPLE BLOCK (99) SEED (10) ")]
[Xunit.InlineData("SELECT * from table_name SAMPLE BLOCK (99.1) SEED (10.1)")]
public void __Upstream_6b6d15167420d3a3(object __upstreamArgument0)
{
        try
        {
            this.standardOracleIssue1826();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("SELECT * FROM fact_halllogin_detail TABLESAMPLE BERNOULLI (10) where dt>=20220710 limit 10")]
[Xunit.InlineData("SELECT * FROM fact_halllogin_detail TABLESAMPLE BERNOULLI (10.1) where dt>=20220710 limit 10")]
[Xunit.InlineData("SELECT * FROM fact_halllogin_detail TABLESAMPLE SYSTEM (10) where dt>=20220710 limit 10")]
[Xunit.InlineData("SELECT * FROM fact_halllogin_detail TABLESAMPLE SYSTEM (10) REPEATABLE (10) where dt>=20220710 limit 10")]
[Xunit.InlineData("SELECT * FROM fact_halllogin_detail TABLESAMPLE SYSTEM (10.0) REPEATABLE (10.1) where dt>=20220710 limit 10")]
public void __Upstream_47b79f58461ae36e(string sqlStr)
{
        try
        {
            this.standardTestIssue1593(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7ea85780ac379116()
{
        try
        {
            this.testBigQuery();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dbfb7e4f32f80663()
{
        try
        {
            this.testDuckDB();
        }
        finally
        {
        }
}
}
