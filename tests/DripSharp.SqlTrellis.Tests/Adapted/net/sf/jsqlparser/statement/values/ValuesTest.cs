// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Values;

public class ValuesTest {
public virtual void testRowConstructor() {
string sqlStr = "VALUES (1,2), (3,4)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testSelectRowConstructor() {
string sqlStr = "select * from values 1, 2, 3;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "select * from values (1, 2), (3, 4), (5,6);";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testDuplicateKey() {
string statement = "VALUES (1, 2, 'test')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Select.Values values = new global::DripSharp.SqlTrellis.Statement.Select.Values().addExpressions(new global::DripSharp.SqlTrellis.Expression.LongValue((long)(1)), new global::DripSharp.SqlTrellis.Expression.LongValue((long)(2)), new global::DripSharp.SqlTrellis.Expression.StringValue("test"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(values, statement);
}

public virtual void testComplexWithQueryIssue561() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("WITH split (word, str, hascomma) AS (VALUES ('', 'Auto,A,1234444', 1) UNION ALL SELECT substr(str, 0, CASE WHEN instr(str, ',') THEN instr(str, ',') ELSE length(str) + 1 END), ltrim(substr(str, instr(str, ',')), ','), instr(str, ',') FROM split WHERE hascomma) SELECT trim(word) FROM split WHERE word != ''", true);
}

public virtual void testObject()
{
    var valuesStatement = new global::DripSharp.SqlTrellis.Statement.Select.Values().addExpressions(new global::DripSharp.SqlTrellis.Expression.StringValue("1"), new global::DripSharp.SqlTrellis.Expression.StringValue("2"));
    valuesStatement.addExpressions(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.StringValue("3"), new global::DripSharp.SqlTrellis.Expression.StringValue("4")));
    ((global::DripSharp.SqlTrellis.Statement.Statement)valuesStatement).accept<object>(new global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object>());
}

public virtual void testValuesWithAliasWithoutAs() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT a, b, cume_dist() OVER (PARTITION BY a ORDER BY b) AS cume_dist\n", "    FROM VALUES ('A1', 2), ('A1', 1), ('A2', 3), ('A1', 1) tab(a, b);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_eebf1ac2c88021bb()
{
        try
        {
            this.testComplexWithQueryIssue561();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_763d93f040aeaa10()
{
        try
        {
            this.testDuplicateKey();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ab97073f05788b2()
{
        try
        {
            this.testObject();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cbf878eea6e0a12e()
{
        try
        {
            this.testRowConstructor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4ac15026374e3983()
{
        try
        {
            this.testSelectRowConstructor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_498519e478a805e1()
{
        try
        {
            this.testValuesWithAliasWithoutAs();
        }
        finally
        {
        }
}
}
