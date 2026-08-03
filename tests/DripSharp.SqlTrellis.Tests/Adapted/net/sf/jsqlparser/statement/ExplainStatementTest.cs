// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ExplainStatementTest {
internal virtual void testDuckDBSummarizeTable() {
string sqlStr = "SUMMARIZE cfe.test;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDuckDBSummarizeSelect() {
string sqlStr = "SUMMARIZE SELECT * FROM cfe.test;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testOracleExplainPlan() {
string sqlStr = "EXPLAIN PLAN SELECT * FROM cfe.test;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testH2ExplainPlanFor() {
string sqlStr = "EXPLAIN PLAN FOR SELECT * FROM cfe.test;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testH2ExplainAnalyze() {
string sqlStr = "EXPLAIN ANALYZE SELECT * FROM cfe.test;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_41497487c7a690ce()
{
        try
        {
            this.testDuckDBSummarizeSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c7057e9752655e11()
{
        try
        {
            this.testDuckDBSummarizeTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_da5b4631120bcae0()
{
        try
        {
            this.testH2ExplainAnalyze();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c1bac964204ecc3()
{
        try
        {
            this.testH2ExplainPlanFor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3bbda23b5e58da89()
{
        try
        {
            this.testOracleExplainPlan();
        }
        finally
        {
        }
}
}
