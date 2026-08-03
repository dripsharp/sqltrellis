// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Deparser;

public class StatementDeParserTest {
private global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionDeParser = null!;

private global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser selectDeParser = null!;

private global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser statementDeParser = null!;

private global::DripSharp.SqlTrellis.Util.Deparser.TableStatementDeParser tableStatementDeParser = null!;

public virtual void setUp() {
this.tableStatementDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.TableStatementDeParser(this.expressionDeParser, new global::System.Text.StringBuilder());
this.statementDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser(this.expressionDeParser, this.selectDeParser, new global::System.Text.StringBuilder());
}

public virtual void shouldUseProvidedDeparsersWhenDeParsingDelete() {
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = new global::DripSharp.SqlTrellis.Statement.Delete.Delete();
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table();
global::DripSharp.SqlTrellis.Expression.Expression where = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement> orderByElements = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement1 = new global::DripSharp.SqlTrellis.Statement.Select.OrderByElement();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement2 = new global::DripSharp.SqlTrellis.Statement.Select.OrderByElement();
global::DripSharp.SqlTrellis.Expression.Expression orderByElement1Expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression orderByElement2Expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
delete.setTable(table);
delete.setWhere(where);
delete.setOrderByElements(orderByElements);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement1);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement2);
orderByElement1.setExpression(orderByElement1Expression);
orderByElement2.setExpression(orderByElement2Expression);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(delete);
global::DripSharp.Testing.JavaMockito.Then(where).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(orderByElement1Expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(orderByElement2Expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeparsersWhenDeParsingInsert() {
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = new global::DripSharp.SqlTrellis.Statement.Insert.Insert();
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Update.UpdateSet> duplicateUpdateSets = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Update.UpdateSet>();
global::DripSharp.SqlTrellis.Schema.Column duplicateUpdateColumn1 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Expression.Expression duplicateUpdateExpression1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.Runtime.JavaCompat.Add(duplicateUpdateSets, new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet(duplicateUpdateColumn1, duplicateUpdateExpression1));
global::DripSharp.SqlTrellis.Schema.Column duplicateUpdateColumn2 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Expression.Expression duplicateUpdateExpression2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.Runtime.JavaCompat.Add(duplicateUpdateSets, new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet(duplicateUpdateColumn2, duplicateUpdateExpression2));
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.PlainSelect>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItemsList = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>>();
global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement> withItem1 = global::DripSharp.Testing.JavaMockito.Spy<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>>(new global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>());
global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement> withItem2 = global::DripSharp.Testing.JavaMockito.Spy<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>>(new global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>());
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect withItem1SubSelect = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect>();
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect withItem2SubSelect = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect>();
select.setWithItemsList(withItemsList);
insert.setSelect(select);
insert.setTable(table);
insert.withDuplicateUpdateSets(duplicateUpdateSets);
global::DripSharp.Runtime.JavaCompat.Add(withItemsList, withItem1);
global::DripSharp.Runtime.JavaCompat.Add(withItemsList, withItem2);
withItem1.setSelect(withItem1SubSelect);
withItem2.setSelect(withItem2SubSelect);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(insert.withWithItemsList(withItemsList));
global::DripSharp.Testing.JavaMockito.Then(withItem1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(this.selectDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(withItem2).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(this.selectDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(select).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(this.selectDeParser!)), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(duplicateUpdateExpression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(duplicateUpdateExpression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeParsersWhenDeParsingUpdateNotUsingSelect() {
global::DripSharp.SqlTrellis.Statement.Update.Update update = new global::DripSharp.SqlTrellis.Statement.Update.Update();
global::DripSharp.SqlTrellis.Expression.Expression where = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement> orderByElements = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Schema.Column column1 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Schema.Column column2 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Expression.Expression expression1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression expression2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement1 = new global::DripSharp.SqlTrellis.Statement.Select.OrderByElement();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement2 = new global::DripSharp.SqlTrellis.Statement.Select.OrderByElement();
global::DripSharp.SqlTrellis.Expression.Expression orderByElement1Expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression orderByElement2Expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
update.setWhere(where);
update.setOrderByElements(orderByElements);
update.addUpdateSet(column1, expression1);
update.addUpdateSet(column2, expression2);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement1);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement2);
orderByElement1.setExpression(orderByElement1Expression);
orderByElement2.setExpression(orderByElement2Expression);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(update);
global::DripSharp.Testing.JavaMockito.Then(this.expressionDeParser).Should().visit<object>(column1, (object)default!);
global::DripSharp.Testing.JavaMockito.Then(this.expressionDeParser).Should().visit<object>(column2, (object)default!);
global::DripSharp.Testing.JavaMockito.Then(expression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(expression2).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(where).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(orderByElement1Expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(orderByElement2Expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeParsersWhenDeParsingUpdateUsingSelect() {
global::DripSharp.SqlTrellis.Statement.Update.Update update = new global::DripSharp.SqlTrellis.Statement.Update.Update();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Schema.Column> columns = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Schema.Column>();
global::DripSharp.SqlTrellis.Expression.Expression where = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement> orderByElements = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Schema.Column column1 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Schema.Column column2 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement1 = new global::DripSharp.SqlTrellis.Statement.Select.OrderByElement();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement2 = new global::DripSharp.SqlTrellis.Statement.Select.OrderByElement();
global::DripSharp.SqlTrellis.Expression.Expression orderByElement1Expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression orderByElement2Expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
update.setWhere(where);
update.setOrderByElements(orderByElements);
global::DripSharp.SqlTrellis.Statement.Update.UpdateSet updateSet = new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet();
updateSet.add(column1);
updateSet.add(column2);
update.addUpdateSet(updateSet);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement1);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement2);
orderByElement1.setExpression(orderByElement1Expression);
orderByElement2.setExpression(orderByElement2Expression);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(update);
global::DripSharp.Testing.JavaMockito.Then(this.expressionDeParser).Should().visit<object>(column1, (object)default!);
global::DripSharp.Testing.JavaMockito.Then(this.expressionDeParser).Should().visit<object>(column2, (object)default!);
global::DripSharp.Testing.JavaMockito.Then(where).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(orderByElement1Expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(orderByElement2Expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeParserWhenDeParsingExecute() {
global::DripSharp.SqlTrellis.Statement.Execute.Execute execute = new global::DripSharp.SqlTrellis.Statement.Execute.Execute();
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression expression1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression expression2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
execute.setExprList(expressions);
global::DripSharp.Runtime.JavaCompat.Add(expressions, expression1);
global::DripSharp.Runtime.JavaCompat.Add(expressions, expression2);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(execute);
global::DripSharp.Testing.JavaMockito.Then(expression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(expression2).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeParserWhenDeParsingSetStatement() {
string name = "name";
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.Runtime.JavaCompat.Add(expressions, expression);
global::DripSharp.SqlTrellis.Statement.SetStatement setStatement = new global::DripSharp.SqlTrellis.Statement.SetStatement(name, global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(expressions));
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(setStatement);
global::DripSharp.Testing.JavaMockito.Then(expression).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeparsersWhenDeParsingUpsertWithExpressionList() {
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert upsert = new global::DripSharp.SqlTrellis.Statement.Upsert.Upsert();
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Schema.Column> duplicateUpdateColumns = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Schema.Column>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Expression.Expression> duplicateUpdateExpressionList = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Schema.Column duplicateUpdateColumn1 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Schema.Column duplicateUpdateColumn2 = new global::DripSharp.SqlTrellis.Schema.Column();
global::DripSharp.SqlTrellis.Expression.Expression duplicateUpdateExpression1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression duplicateUpdateExpression2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.PlainSelect>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItemsList = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>>();
global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement> withItem1 = global::DripSharp.Testing.JavaMockito.Spy<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>>(new global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>());
global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement> withItem2 = global::DripSharp.Testing.JavaMockito.Spy<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>>(new global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>());
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect withItem1SubSelect = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect>();
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect withItem2SubSelect = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect>();
select.setWithItemsList(withItemsList);
upsert.setSelect(select);
upsert.setTable(table);
upsert.setDuplicateUpdateSets(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Statement.Update.UpdateSet>(new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet(duplicateUpdateColumn1, duplicateUpdateExpression1), new global::DripSharp.SqlTrellis.Statement.Update.UpdateSet(duplicateUpdateColumn2, duplicateUpdateExpression2)));
global::DripSharp.Runtime.JavaCompat.Add(withItemsList, withItem1);
global::DripSharp.Runtime.JavaCompat.Add(withItemsList, withItem2);
withItem1.setSelect(withItem1SubSelect);
withItem2.setSelect(withItem2SubSelect);
((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(this.statementDeParser)).visit(upsert);
global::DripSharp.Testing.JavaMockito.Then(select).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(this.selectDeParser!)), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(duplicateUpdateExpression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Then(duplicateUpdateExpression1).Should().accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
}

public virtual void shouldUseProvidedDeparsersWhenDeParsingIfThenStatement() {
string sqlStr = "IF OBJECT_ID('tOrigin', 'U') IS NOT NULL DROP TABLE tOrigin1";
global::DripSharp.SqlTrellis.Statement.IfElseStatement ifElseStatement = (global::DripSharp.SqlTrellis.Statement.IfElseStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
this.statementDeParser.deParse(ifElseStatement);
}

public virtual void testIssue1500AllColumns() {
string sqlStr = "select count(*) from some_table";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
selectBody.accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(new global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser()), (object)default!);
}

public virtual void testIssue1836() {
string sqlStr = "TABLE columns ORDER BY column_name LIMIT 10 OFFSET 10;";
global::DripSharp.SqlTrellis.Statement.Select.TableStatement tableStatement = (global::DripSharp.SqlTrellis.Statement.Select.TableStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
tableStatement.accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(this.tableStatementDeParser), (object)default!);
}

public virtual void testIssue1500AllTableColumns() {
string sqlStr = "select count(a.*) from some_table a";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect selectBody = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
selectBody.accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>)(new global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser()), (object)default!);
}

public virtual void testIssue1608DeparseValueList() {
string providedSql = "INSERT INTO example (num, name, address, tel) VALUES (1, 'name', 'test ', '1234-1234')";
string expectedSql = "INSERT INTO example (num, name, address, tel) VALUES (?, ?, ?, ?)";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(providedSql);
global::System.Text.StringBuilder builder = new global::System.Text.StringBuilder();
global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionDeParser = new Anonymous_355_49();
global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser selectDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser(expressionDeParser, builder);
expressionDeParser.setSelectVisitor(selectDeParser);
expressionDeParser.setBuilder(builder);
global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser statementDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser(expressionDeParser, selectDeParser, builder);
((global::DripSharp.SqlTrellis.Statement.Statement)(statement)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<global::System.Text.StringBuilder>)(statementDeParser));
global::DripSharp.Testing.JavaAssertions.Equal(expectedSql, builder.ToString(), null);
}

private sealed class Anonymous_355_49 : global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser {
public Anonymous_355_49() {}

public override global::System.Text.StringBuilder visit<K>(global::DripSharp.SqlTrellis.Expression.StringValue stringValue, K parameters) {
base.builder.Append("?");
return default!;
}

public override global::System.Text.StringBuilder visit<K>(global::DripSharp.SqlTrellis.Expression.LongValue longValue, K parameters) {
base.builder.Append("?");
return default!;
}
}

[Xunit.Fact]
public void __Upstream_af48f6fd33a9507d()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeParserWhenDeParsingExecute();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39d1e2a56dec218c()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeParserWhenDeParsingSetStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_15da84c105518574()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeParsersWhenDeParsingUpdateNotUsingSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8d4eea94037b9727()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeParsersWhenDeParsingUpdateUsingSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_041dfc60dc282551()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeparsersWhenDeParsingDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9e24bab7cd77f4b2()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeparsersWhenDeParsingIfThenStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_25bd0000bcc086d3()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeparsersWhenDeParsingInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5720537406afa7a0()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.shouldUseProvidedDeparsersWhenDeParsingUpsertWithExpressionList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e1f9d2918206b9ec()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.testIssue1500AllColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5c35fb8262773193()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.testIssue1500AllTableColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_91434db91ae64076()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.testIssue1608DeparseValueList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4f371ab15e0efac2()
{
        this.expressionDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser>();
        this.selectDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser>();
        this.setUp();
        try
        {
            this.testIssue1836();
        }
        finally
        {
        }
}
}
