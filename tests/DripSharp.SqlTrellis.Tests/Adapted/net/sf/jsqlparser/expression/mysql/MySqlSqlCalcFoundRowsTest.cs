// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Mysql;

public class MySqlSqlCalcFoundRowsTest {
public virtual void testPossibleParsingWithSqlCalcFoundRowsHint() {
global::DripSharp.SqlTrellis.Expression.Mysql.MySqlSqlCalcFoundRowRef @ref = new global::DripSharp.SqlTrellis.Expression.Mysql.MySqlSqlCalcFoundRowRef(false);
string sqlCalcFoundRowsContainingSql = "SELECT SQL_CALC_FOUND_ROWS * FROM TABLE";
string generalSql = "SELECT * FROM TABLE";
this.accept(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlCalcFoundRowsContainingSql), @ref);
global::DripSharp.Testing.JavaAssertions.True(@ref.sqlCalcFoundRows, null);
this.accept(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(generalSql), @ref);
global::DripSharp.Testing.JavaAssertions.False(@ref.sqlCalcFoundRows, null);
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlCalcFoundRowsContainingSql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(generalSql);
global::DripSharp.SqlTrellis.Statement.Select.Select created = new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withMySqlSqlCalcFoundRows(true).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("TABLE"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, sqlCalcFoundRowsContainingSql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

private void accept(global::DripSharp.SqlTrellis.Statement.Statement statement, global::DripSharp.SqlTrellis.Expression.Mysql.MySqlSqlCalcFoundRowRef @ref) {
global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> selectVisitorAdapter = new Anonymous_55_59(@ref);
((global::DripSharp.SqlTrellis.Statement.Statement)(statement)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new Anonymous_63_26(selectVisitorAdapter)));
}

private sealed class Anonymous_55_59 : global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> {
private readonly global::DripSharp.SqlTrellis.Expression.Mysql.MySqlSqlCalcFoundRowRef __capture_0;

public Anonymous_55_59(global::DripSharp.SqlTrellis.Expression.Mysql.MySqlSqlCalcFoundRowRef __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect, S parameters) {
this.__capture_0.sqlCalcFoundRows = plainSelect.getMySqlSqlCalcFoundRows();
return default!;
}
}

private sealed class Anonymous_63_26 : global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object> {
private readonly global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> __capture_0;

public Anonymous_63_26(global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.Select select, S context) {
select.accept<object, S>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(this.__capture_0), context);
return default!;
}
}

[Xunit.Fact]
public void __Upstream_5da2959c611d8b55()
{
        try
        {
            this.testPossibleParsingWithSqlCalcFoundRowsHint();
        }
        finally
        {
        }
}
}
