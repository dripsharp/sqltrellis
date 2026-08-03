// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Delete;

public class DeleteTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testDelete() {
string statement = "DELETE FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", delete.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", delete), null);
}

public virtual void testDeleteWhereProblem1() {
string stmt = "DELETE FROM tablename WHERE a = 1 AND b = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDeleteWithLimit() {
string stmt = "DELETE FROM tablename WHERE a = 1 AND b = 1 LIMIT 5";
global::DripSharp.SqlTrellis.Statement.Delete.Delete parsed = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression where = parsed.getWhere<global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression>(typeof(global::DripSharp.SqlTrellis.Expression.Operators.Conditional.AndExpression));
global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo left = where.getLeftExpression<global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo>(typeof(global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo));
global::DripSharp.Testing.JavaAssertions.Equal("a", left.getLeftExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column)).getColumnName(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo right = where.getRightExpression<global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo>(typeof(global::DripSharp.SqlTrellis.Expression.Operators.Relational.EqualsTo));
global::DripSharp.Testing.JavaAssertions.Equal("b", right.getLeftExpression<global::DripSharp.SqlTrellis.Schema.Column>(typeof(global::DripSharp.SqlTrellis.Schema.Column)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(5), parsed.getLimit().getRowCount<global::DripSharp.SqlTrellis.Expression.LongValue>(typeof(global::DripSharp.SqlTrellis.Expression.LongValue)).getValue(), null);
}

public virtual void testDeleteDoesNotAllowLimitOffset() {
string statement = "DELETE FROM table1 WHERE A.cod_table = 'YYY' LIMIT 3,4";
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => this.parserManager.parse(new global::System.IO.StringReader(statement)), null);
}

public virtual void testDeleteWithOrderBy() {
string stmt = "DELETE FROM tablename WHERE a = 1 AND b = 1 ORDER BY col";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDeleteWithOrderByAndLimit() {
string stmt = "DELETE FROM tablename WHERE a = 1 AND b = 1 ORDER BY col LIMIT 10";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDeleteFromTableUsingInnerJoinToAnotherTable() {
string stmt = "DELETE Table1 FROM Table1 INNER JOIN Table2 ON Table1.ID = Table2.ID";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDeleteFromTableUsingLeftJoinToAnotherTable() {
string stmt = "DELETE g FROM Table1 AS g LEFT JOIN Table2 ON Table1.ID = Table2.ID";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDeleteFromTableUsingInnerJoinToAnotherTableWithAlias() {
string stmt = "DELETE gc FROM guide_category AS gc LEFT JOIN guide AS g ON g.id_guide = gc.id_guide WHERE g.title IS NULL LIMIT 5";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testDeleteMultiTableIssue878() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DELETE table1, table2 FROM table1, table2");
}

public virtual void testOracleHint() {
string sql = "DELETE /*+ SOMEHINT */ FROM mytable WHERE mytable.col = 9";
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(sql, true, "SOMEHINT");
}

public virtual void testWith() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "WITH a\n"), "     AS (SELECT 1 id_instrument_ref)\n"), "     , b\n"), "       AS (SELECT 1 id_instrument_ref)\n"), "DELETE FROM cfe.instrument_ref\n"), "WHERE  id_instrument_ref = (SELECT id_instrument_ref\n"), "                            FROM   a)");
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = delete.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal("cfe.instrument_ref", delete.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression> selectItem1 = global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect().getSelectItems(), 0);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(selectItem1.getExpression()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" id_instrument_ref", selectItem1.getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" a", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Select.SelectItem<global::DripSharp.SqlTrellis.Expression.Expression> selectItem2 = global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getSelect().getPlainSelect().getSelectItems(), 0);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(selectItem2.getExpression()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" id_instrument_ref", selectItem2.getAlias().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" b", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

public virtual void testNoFrom() {
string statement = "DELETE A WHERE Z = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testNoFromWithSchema() {
string statement = "DELETE A.B WHERE Z = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testUsing() {
string statement = "DELETE A USING B.C D WHERE D.Z = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testDeleteLowPriority() {
string stmt = "DELETE LOW_PRIORITY FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(delete.getModifierPriority(), global::DripSharp.SqlTrellis.Statement.Delete.DeleteModifierPriority.LOW_PRIORITY, null);
}

public virtual void testDeleteQuickModifier() {
string stmt = "DELETE QUICK FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.True(delete.isModifierQuick(), null);
string stmt2 = "DELETE FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete2 = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2)!);
global::DripSharp.Testing.JavaAssertions.False(delete2.isModifierQuick(), null);
}

public virtual void testDeleteIgnoreModifier() {
string stmt = "DELETE IGNORE FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.True(delete.isModifierIgnore(), null);
string stmt2 = "DELETE FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete2 = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2)!);
global::DripSharp.Testing.JavaAssertions.False(delete2.isModifierIgnore(), null);
}

public virtual void testDeleteMultipleModifiers() {
string stmt = "DELETE LOW_PRIORITY QUICK FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(delete.getModifierPriority(), global::DripSharp.SqlTrellis.Statement.Delete.DeleteModifierPriority.LOW_PRIORITY, null);
global::DripSharp.Testing.JavaAssertions.True(delete.isModifierQuick(), null);
string stmt2 = "DELETE LOW_PRIORITY QUICK IGNORE FROM tablename";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete2 = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2)!);
global::DripSharp.Testing.JavaAssertions.Equal(delete2.getModifierPriority(), global::DripSharp.SqlTrellis.Statement.Delete.DeleteModifierPriority.LOW_PRIORITY, null);
global::DripSharp.Testing.JavaAssertions.True(delete2.isModifierIgnore(), null);
global::DripSharp.Testing.JavaAssertions.True(delete2.isModifierQuick(), null);
}

public virtual void testDeleteReturningIssue1527() {
string statement = "delete from t returning *";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("delete from products\n", "  WHERE price <= 99.99\n"), "  RETURNING name, price AS new_price");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
}

public virtual void testDeleteOutputClause() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DELETE Sales.ShoppingCartItem OUTPUT DELETED.* FROM Sales", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DELETE Sales.ShoppingCartItem OUTPUT Sales.ShoppingCartItem FROM Sales", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("DELETE Production.ProductProductPhoto  \n", "OUTPUT DELETED.ProductID,  \n"), "       p.Name,  \n"), "       p.ProductModelID,  \n"), "       DELETED.ProductPhotoID  \n"), "    INTO @MyTableVar  \n"), "FROM Production.ProductProductPhoto AS ph  \n"), "JOIN Production.Product as p   \n"), "    ON ph.ProductID = p.ProductID   \n"), "    WHERE p.ProductModelID BETWEEN 120 and 130"), true);
}

internal virtual void testInsertWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH inserted AS ( ", "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "   RETURNING y "), ") "), "DELETE "), "  FROM z"), " WHERE y IN (SELECT y FROM inserted)");
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", delete.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = delete.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b RETURNING y", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testUpdateWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH updated AS ( ", "   UPDATE x "), "      SET foo = 1 "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "DELETE "), "  FROM z"), " WHERE y IN (SELECT y FROM updated)");
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", delete.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = delete.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Update.Update update = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getUpdate().getUpdate();
global::DripSharp.Testing.JavaAssertions.Equal("x", update.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getColumn(0).ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("1", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(update.getUpdateSets(), 0).getValue(0)), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(update.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", update.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" updated", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteWithinCte() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), "DELETE "), "  FROM z"), " WHERE y IN (SELECT y FROM deleted)");
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", delete.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = delete.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete innerDelete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", innerDelete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(innerDelete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", innerDelete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
}

internal virtual void testDeleteAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH deleted AS ( ", "   DELETE FROM x "), "    WHERE bar = 2 "), "   RETURNING y "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM deleted) "), "   RETURNING w "), ") "), "DELETE "), "  FROM z"), " WHERE w IN (SELECT w FROM inserted)");
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", delete.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = delete.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Delete.Delete innerDelete = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getDelete().getDelete();
global::DripSharp.Testing.JavaAssertions.Equal("x", innerDelete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar = 2", global::DripSharp.Runtime.JavaCompat.StringValueOf(innerDelete.getWhere()), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING y", innerDelete.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" deleted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM deleted)", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM deleted) RETURNING w", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

internal virtual void testSelectAndInsertWithin2Ctes() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH selection AS ( ", "   SELECT y "), "     FROM z "), "    WHERE foo = 'bar' "), ") "), ", inserted AS ( "), "   INSERT INTO x (foo) "), "   SELECT bar FROM b "), "    WHERE y IN (SELECT y FROM selection) "), "   RETURNING w "), ") "), "DELETE "), "  FROM z"), " WHERE w IN (SELECT w FROM inserted)");
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal("z", delete.getTable().ToString(), null);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.WithItem<global::DripSharp.SqlTrellis.Statement.ParenthesedStatement>> withItems = delete.getWithItemsList();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(withItems), null);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect innerSelect = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getSelect().getPlainSelect();
global::DripSharp.Testing.JavaAssertions.Equal("SELECT y FROM z WHERE foo = 'bar'", innerSelect.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" selection", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 0).getAlias().ToString(), null);
global::DripSharp.SqlTrellis.Statement.Insert.Insert insert = global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getInsert().getInsert();
global::DripSharp.Testing.JavaAssertions.Equal("x", insert.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT bar FROM b WHERE y IN (SELECT y FROM selection)", insert.getSelect().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" RETURNING w", insert.getReturningClause().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSERT INTO x (foo) SELECT bar FROM b WHERE y IN (SELECT y FROM selection) RETURNING w", insert.ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(" inserted", global::DripSharp.Runtime.JavaCompat.ListGet(withItems, 1).getAlias().ToString(), null);
}

public virtual void testPreferringClause(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
}

public virtual void testDeleteWithSkylineKeywords() {
string statement = "DELETE FROM mytable WHERE low = 1 AND high = 2 AND inverse = 3 AND plus = 4";
global::DripSharp.SqlTrellis.Statement.Delete.Delete delete = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", delete.getTable().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal("low = 1 AND high = 2 AND inverse = 3 AND plus = 4", global::DripSharp.Runtime.JavaCompat.StringValueOf(delete.getWhere()), null);
}

[Xunit.Fact]
public void __Upstream_36cb86697bcfb4ed()
{
        try
        {
            this.testDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ceffb8522aa3a2f6()
{
        try
        {
            this.testDeleteAndInsertWithin2Ctes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_443137fcc38b868c()
{
        try
        {
            this.testDeleteDoesNotAllowLimitOffset();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b1a0f03a807056f7()
{
        try
        {
            this.testDeleteFromTableUsingInnerJoinToAnotherTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c09aa697b2ec6a9()
{
        try
        {
            this.testDeleteFromTableUsingInnerJoinToAnotherTableWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eaef8333c7af29d1()
{
        try
        {
            this.testDeleteFromTableUsingLeftJoinToAnotherTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9c8b577f8b5987dd()
{
        try
        {
            this.testDeleteIgnoreModifier();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4bd4d52c6dc57945()
{
        try
        {
            this.testDeleteLowPriority();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_22b0be80ce20a1fd()
{
        try
        {
            this.testDeleteMultiTableIssue878();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_74e5a14e3ed05d85()
{
        try
        {
            this.testDeleteMultipleModifiers();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b324e6eb7f1f6ba5()
{
        try
        {
            this.testDeleteOutputClause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_641d73c1519fa86e()
{
        try
        {
            this.testDeleteQuickModifier();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b92c662538b79d8a()
{
        try
        {
            this.testDeleteReturningIssue1527();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_55098110396b2e7c()
{
        try
        {
            this.testDeleteWhereProblem1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4f97a0379dd1e830()
{
        try
        {
            this.testDeleteWithLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1d33d2ed0e4d5440()
{
        try
        {
            this.testDeleteWithOrderBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_66d3c6bd0f154bbc()
{
        try
        {
            this.testDeleteWithOrderByAndLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b2b0fd88bca04c63()
{
        try
        {
            this.testDeleteWithSkylineKeywords();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f3794bcc8ed94058()
{
        try
        {
            this.testDeleteWithinCte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8aa02fb681e5e282()
{
        try
        {
            this.testInsertWithinCte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0fe9e6d9ec1ea9ca()
{
        try
        {
            this.testNoFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_626ab59a6f0fffd3()
{
        try
        {
            this.testNoFromWithSchema();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dc6d470ef8198b80()
{
        try
        {
            this.testOracleHint();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.InlineData("DELETE FROM mytable PREFERRING HIGH mycolumn")]
[Xunit.InlineData("DELETE FROM mytable PREFERRING LOW mycolumn")]
[Xunit.InlineData("DELETE FROM mytable PREFERRING 1 = 1")]
[Xunit.InlineData("DELETE FROM mytable PREFERRING (HIGH mycolumn)")]
[Xunit.InlineData("DELETE FROM mytable PREFERRING INVERSE (HIGH mycolumn)")]
[Xunit.InlineData("DELETE FROM mytable PREFERRING HIGH mycolumn1 PRIOR TO LOW mycolumn2")]
[Xunit.InlineData("DELETE FROM mytable PREFERRING HIGH mycolumn1 PLUS LOW mycolumn2")]
public void __Upstream_6c634f1a3ccc7d46(string sqlStr)
{
        try
        {
            this.testPreferringClause(sqlStr);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8e6eaac4ddbe5369()
{
        try
        {
            this.testSelectAndInsertWithin2Ctes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a126749921e44d3b()
{
        try
        {
            this.testUpdateWithinCte();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ccffdaa9adb69b25()
{
        try
        {
            this.testUsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_38187fc153c75d79()
{
        try
        {
            this.testWith();
        }
        finally
        {
        }
}
}
