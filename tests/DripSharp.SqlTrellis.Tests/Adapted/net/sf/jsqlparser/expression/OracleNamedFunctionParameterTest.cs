// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class OracleNamedFunctionParameterTest {
public virtual void testExpression() {
string sqlStr = "select r.*, test.numeric_function ( p_1 => r.param1, p_2 => r.param2 ) as resultaat2";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("exec dbms_stats.gather_schema_stats(\n", "      ownname          => 'COMMON', \n"), "      estimate_percent => dbms_stats.auto_sample_size, \n"), "      method_opt       => 'for all columns size auto', \n"), "      degree           => DBMS_STATS.DEFAULT_DEGREE,\n"), "      cascade          => DBMS_STATS.AUTO_CASCADE,\n"), "      options          => 'GATHER AUTO'\n"), "   )");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testExpressionVisitorAdaptor() {
string sqlStr = "select r.*, test.numeric_function ( p_1 => r.param1, p_2 => r.param2 ) as resultaat2";
((global::DripSharp.SqlTrellis.Statement.Statement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr))).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object>()));
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("p_1 => r.param1").accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object>()), (object)default!);
}

public virtual void testTableNamesFinder() {
string sqlStr = "select r.*, test.numeric_function ( p_1 => r.param1, p_2 => r.param2 ) as resultaat2 from test_table";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
global::System.Collections.Generic.IList<string> tables = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>().getTableList(statement);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(tables), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.CollectionContains(tables, "test_table"), null);
}

public virtual void testValidator() {
string sqlStr = "select r.*, test.numeric_function ( p_1 => r.param1, p_2 => r.param2 ) as resultaat2";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

[Xunit.Fact]
public void __Upstream_4536c59425c71bde()
{
        try
        {
            this.testExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9a5d0dfa32882349()
{
        try
        {
            this.testExpressionVisitorAdaptor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_02b7d5ce52072fac()
{
        try
        {
            this.testTableNamesFinder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_657d65bcb901d7a2()
{
        try
        {
            this.testValidator();
        }
        finally
        {
        }
}
}
