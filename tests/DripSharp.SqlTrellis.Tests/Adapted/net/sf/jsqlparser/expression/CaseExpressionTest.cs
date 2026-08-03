// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class CaseExpressionTest {
public virtual void testSimpleCase() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseBinaryAndWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN true & false THEN 1 ELSE 2 END", true);
}

public virtual void testCaseBinaryOrWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN true | false THEN 1 ELSE 2 END", true);
}

public virtual void testCaseExclamationWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN !true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseNotWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN NOT true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseAndWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN true AND false THEN 1 ELSE 2 END", true);
}

public virtual void testCaseOrWhen() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true WHEN true OR false THEN 1 ELSE 2 END", true);
}

public virtual void testCaseExclamationSwitch() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE !true WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseNotSwitch() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE NOT true WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseBinaryAndSwitch() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true & false WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseBinaryOrSwitch() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true | false WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseAndSwitch() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true AND false WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testCaseOrSwitch() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CASE true OR false WHEN true THEN 1 ELSE 2 END", true);
}

public virtual void testInnerCaseWithConcatInElsePart() {
string query = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT \n", "CASE \n"), "   WHEN 1 = 1 \n"), "   THEN \n"), "       CASE \n"), "           WHEN 2 = 2 \n"), "           THEN '2a' \n"), "           ELSE \n"), "               CASE \n"), "                   WHEN 1 = 1 \n"), "                   THEN \n"), "                       CASE \n"), "                           WHEN 2 = 2 \n"), "                           THEN '2a' \n"), "                           ELSE '' \n"), "                       END \n"), "                   ELSE 'b' \n"), "               END || 'z'\n"), "       END \n"), "   ELSE 'b' \n"), "END AS tmp\n"), "FROM test_table");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(query, true);
}

public virtual void testCaseInsideBrackets() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT ( CASE\n", "            WHEN something\n"), "                THEN CASE\n"), "                     WHEN something2\n"), "                         THEN 1\n"), "                     ELSE 0\n"), "                     END + 1\n"), "            ELSE 0\n"), "        END ) + 1 \n"), "FROM test");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "(CASE WHEN FIELD_A=0 THEN FIELD_B\n"), "WHEN FIELD_C >FIELD_D  THEN (CASE WHEN FIELD_A>0 THEN\n"), "(FIELD_B)/(FIELD_A/(DATEDIFF(DAY,:started,:end)+1))\n"), "ELSE 0 END)-FIELD_D ELSE 0 END)*FIELD_A/(DATEDIFF(DAY,:started,:end)+1)  AS UNNECESSARY_COMPLEX_EXPRESSION\n"), "FROM TEST");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testPerformanceIssue1889() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT ", "SUM(SUM(CASE\n"), "               WHEN IssueDeadline IS NULL THEN 'Indeterminate'\n"), "               WHEN IssueDeadline < CONVERT(DATETIME, CONVERT(DATE, COALESCE(IssueClosedOn, CONVERT(DATETIME, CONVERT(DATE, GETDATE()), 121)))) THEN 'PastDue'\n"), "               WHEN (IssueDeadline>=CONVERT(DATETIME, CONVERT(DATE, GETDATE()), 121)\n"), "                     AND IssueDeadline<=CONVERT(DATETIME, CONVERT(DATE, GETDATE()+3), 121)) THEN 'Alert'\n"), "               ELSE 'OnTime'\n"), "           END = 'PastDue'))\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testFormatClause() {
string sqlStr = "SELECT CAST('18-12-03' AS DATE FORMAT 'YY-MM-DD') AS string_to_date";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_3cde1b1f402e552d()
{
        try
        {
            this.testCaseAndSwitch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4bec2a10c38de39a()
{
        try
        {
            this.testCaseAndWhen();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6a99fa4268bc3979()
{
        try
        {
            this.testCaseBinaryAndSwitch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a9d5bb0e893d95c3()
{
        try
        {
            this.testCaseBinaryAndWhen();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_49c4411f16c03dce()
{
        try
        {
            this.testCaseBinaryOrSwitch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6908db6e879ffca4()
{
        try
        {
            this.testCaseBinaryOrWhen();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c62414ca34bf8da4()
{
        try
        {
            this.testCaseExclamationSwitch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a82ce99b9f2c3629()
{
        try
        {
            this.testCaseExclamationWhen();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f0b73f3b62d3fff()
{
        try
        {
            this.testCaseInsideBrackets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e66bf9001b4a7655()
{
        try
        {
            this.testCaseNotSwitch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1b65bf5fef4a19f5()
{
        try
        {
            this.testCaseNotWhen();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_72b8cd0a12be0ed1()
{
        try
        {
            this.testCaseOrSwitch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_894290c79adaaa6d()
{
        try
        {
            this.testCaseOrWhen();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f5a8d7b97d20523b()
{
        try
        {
            this.testFormatClause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cdb0f37c961c70d3()
{
        try
        {
            this.testInnerCaseWithConcatInElsePart();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_608ae101cfa2641d()
{
        try
        {
            this.testPerformanceIssue1889();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_378eedb6a6442387()
{
        try
        {
            this.testSimpleCase();
        }
        finally
        {
        }
}
}
