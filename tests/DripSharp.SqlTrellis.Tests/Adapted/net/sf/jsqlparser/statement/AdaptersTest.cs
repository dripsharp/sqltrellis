// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class AdaptersTest {
public virtual void testAdapters() {
string sql = "SELECT * FROM MYTABLE WHERE COLUMN_A = :paramA AND COLUMN_B <> :paramB";
global::DripSharp.SqlTrellis.Statement.Statement stmnt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> @params = new global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>>();
((global::DripSharp.SqlTrellis.Statement.Statement)(stmnt)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new Anonymous_39_22(@params)));
global::DripSharp.Testing.JavaAssertions.Equal(2, @params.Count, null);
global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string> param2 = @params.Pop();
global::DripSharp.Testing.JavaAssertions.Equal("COLUMN_B", param2.getLeft(), null);
global::DripSharp.Testing.JavaAssertions.Equal("paramB", param2.getRight(), null);
global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string> param1 = @params.Pop();
global::DripSharp.Testing.JavaAssertions.Equal("COLUMN_A", param1.getLeft(), null);
global::DripSharp.Testing.JavaAssertions.Equal("paramA", param1.getRight(), null);
}

private sealed class Anonymous_39_22 : global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object> {
private readonly global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> __capture_0;

public Anonymous_39_22(global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<S>(global::DripSharp.SqlTrellis.Statement.Select.Select select, S context) {
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(new Anonymous_42_31(this.__capture_0)), (object)default!);
return default!;
}

private sealed class Anonymous_42_31 : global::DripSharp.SqlTrellis.Statement.Select.SelectVisitorAdapter<object> {
private readonly global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> __capture_0;

public Anonymous_42_31(global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> __capture_0) {
this.__capture_0 = __capture_0;
}

public override object visit<K>(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect, K context) {
plainSelect.getWhere().accept<object, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<object>)(new Anonymous_45_55(this.__capture_0)), (object)default!);
return default!;
}

private sealed class Anonymous_45_55 : global::DripSharp.SqlTrellis.Expression.ExpressionVisitorAdapter<object> {
private readonly global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> __capture_0;

public Anonymous_45_55(global::DripSharp.Runtime.JavaStack<global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>> __capture_0) {
this.__capture_0 = __capture_0;
}

protected internal override object visitBinaryExpression<J>(global::DripSharp.SqlTrellis.Expression.BinaryExpression expr, J context) {
if (!((expr is global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression))) {
this.__capture_0.Push(new global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>((string)default!, (string)default!));
}
return base.visitBinaryExpression<J>(expr, context);
}

public override object visit<J>(global::DripSharp.SqlTrellis.Schema.Column column, J context) {
this.__capture_0.Push(new global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>(column.getColumnName(), this.__capture_0.Pop().getRight()));
return default!;
}

public override object visit<J>(global::DripSharp.SqlTrellis.Expression.JdbcNamedParameter parameter, J context) {
this.__capture_0.Push(new global::DripSharp.SqlTrellis.Statement.AdaptersTest.Pair<string, string>(this.__capture_0.Pop().getLeft(), parameter.getName()));
return default!;
}
}
}
}

internal class Pair<L, R> {
internal readonly L left = default!;

internal readonly R right = default!;

internal Pair(object left, object right)
{
    this.left = global::DripSharp.Runtime.JavaCompat.CastReference<L>(left);
    this.right = global::DripSharp.Runtime.JavaCompat.CastReference<R>(right);
}

public virtual L getLeft() {
return this.left;
}

public virtual R getRight() {
return this.right;
}

public virtual bool isEmpty() {
return ((this.left is null) && (this.right is null));
}

public virtual bool isFull() {
return ((this.left is not null) && (this.right is not null));
}

public override string ToString() {
string sb = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("Pair{", "left="), this.left), ", right="), this.right), '}');
return sb;
}
}

[Xunit.Fact]
public void __Upstream_5f25f0788e0f3abc()
{
        try
        {
            this.testAdapters();
        }
        finally
        {
        }
}
}
