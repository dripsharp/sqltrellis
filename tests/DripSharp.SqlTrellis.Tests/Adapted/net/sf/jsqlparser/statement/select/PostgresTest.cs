// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class PostgresTest {
public virtual void testExtractFunction() {
string sqlStr = "SELECT EXTRACT(HOUR FROM TIMESTAMP '2001-02-16 20:38:40')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT EXTRACT('HOUR' FROM TIMESTAMP '2001-02-16 20:38:40')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT EXTRACT('HOURS' FROM TIMESTAMP '2001-02-16 20:38:40')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testExtractFunctionIssue1582() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "select\n"), "  t0.operatienr\n"), "  , case\n"), "    when\n"), "        case when (t0.vc_begintijd_operatie is null or lpad((extract('hours' from t0.vc_begintijd_operatie::timestamp))::text,2,'0') ||':'|| lpad(extract('minutes' from t0.vc_begintijd_operatie::timestamp)::text,2,'0') = '00:00') then null\n"), "             else (greatest(((extract('hours' from (t0.vc_eindtijd_operatie::timestamp-t0.vc_begintijd_operatie::timestamp))*60 + extract('minutes' from (t0.vc_eindtijd_operatie::timestamp-t0.vc_begintijd_operatie::timestamp)))/60)::numeric(12,2),0))*60\n"), "    end = 0 then null\n"), "        else '25. Meer dan 4 uur'\n"), "    end\n"), "  as snijtijd_interval");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testJSonExpressionIssue1696() {
string sqlStr = "SELECT '{\"key\": \"value\"}'::json -> 'key' AS X";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
var selectExpressionItem = global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getSelectItems(), 0);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.StringValue("key"), selectExpressionItem.getExpression<global::DripSharp.SqlTrellis.Expression.JsonExpression>(typeof(global::DripSharp.SqlTrellis.Expression.JsonExpression)).getIdent(0).Key, null);
}

public virtual void testJSonOperatorIssue1571() {
string sqlStr = "select visit_hour,json_array_elements(into_sex_json)->>'name',json_array_elements(into_sex_json)->>'value' from period_market";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testPostgresQuotingIssue1335() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO \"table\"\"with\"\"quotes\" (\"column\"\"with\"\"quotes\")\n", "VALUES ('1'), ('2'), ('3');\n"), "\n"), "UPDATE \"table\"\"with\"\"quotes\" SET \"column\"\"with\"\"quotes\" = '1.0'  \n"), "WHERE \"column\"\"with\"\"quotes\" = '1';\n"), "\n"), "SELECT \"column\"\"with\"\"quotes\" FROM  \"table\"\"with\"\"quotes\"\n"), "WHERE \"column\"\"with\"\"quotes\" IS NOT NULL;");
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = statements.get<global::DripSharp.SqlTrellis.Statement.Insert.Insert>(typeof(global::DripSharp.SqlTrellis.Statement.Insert.Insert), 0);
global::DripSharp.Testing.JavaAssertions.Equal("\"table\"\"with\"\"quotes\"", insert.getTable().getFullyQualifiedName(), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = statements.get<global::DripSharp.SqlTrellis.Statement.Select.PlainSelect>(typeof(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect), 2);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression>> selectItems = select.getSelectItems();
global::DripSharp.Testing.JavaAssertions.Equal("\"column\"\"with\"\"quotes\"", global::DripSharp.Runtime.JavaCompat.ListGet(selectItems, 0).getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column)).getColumnName(), null);
}

internal virtual void testNextValueIssue1863() {
string sqlStr = "SELECT nextval('client_id_seq')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
}

internal virtual void testDollarQuotedText() {
string sqlStr = "SELECT $tag$This\nis\na\nselect\ntest\n$tag$ from dual where a=b";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect st = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Expression.StringValue stringValue = st.getSelectItem(0).getExpression<global::DripSharp.SqlTrellis.Expression.StringValue>(typeof(global::DripSharp.SqlTrellis.Expression.StringValue));
global::DripSharp.Testing.JavaAssertions.Equal("This\nis\na\nselect\ntest\n", stringValue.getValue(), null);
}

internal virtual void testQuotedIdentifier() {
string sqlStr = "SELECT \"This is a Test Column\" AS [Alias] from `This is a Test Table`";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect st = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Schema.Column column = st.getSelectItem(0).getExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column));
global::DripSharp.Testing.JavaAssertions.Equal("This is a Test Column", column.getUnquotedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\"This is a Test Column\"", column.getColumnName(), null);
global::DripSharp.SqlTrellis.Expression.Alias alias = st.getSelectItem(0).getAlias();
global::DripSharp.Testing.JavaAssertions.Equal("Alias", alias.getUnquotedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("[Alias]", alias.getName(), null);
global::DripSharp.SqlTrellis.Schema.Table table = st.getFromItem<global::DripSharp.SqlTrellis.Schema.Table>(typeof(global::DripSharp.SqlTrellis.Schema.Table));
global::DripSharp.Testing.JavaAssertions.Equal("This is a Test Table", table.getUnquotedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("`This is a Test Table`", table.getName(), null);
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_cbe9cd77f8828f1b()
{
        try
        {
            this.testDollarQuotedText();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_86e9806f263c3280()
{
        try
        {
            this.testExtractFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6490cc05ca695ff3()
{
        try
        {
            this.testExtractFunctionIssue1582();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_508b8ac874c27dcd()
{
        try
        {
            this.testJSonExpressionIssue1696();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2a3bc008e8b2dbb()
{
        try
        {
            this.testJSonOperatorIssue1571();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7636bffe7429798c()
{
        try
        {
            this.testNextValueIssue1863();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b49329ca1eddabc9()
{
        try
        {
            this.testPostgresQuotingIssue1335();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_d710ddafbb6670c7()
{
        try
        {
            this.testQuotedIdentifier();
        }
        finally
        {
        }
}
}
