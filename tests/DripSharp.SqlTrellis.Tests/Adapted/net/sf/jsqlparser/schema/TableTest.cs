// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Schema;

public class TableTest {
public virtual void tableIndexException() {
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table().withName("bla").withDatabase(new global::DripSharp.SqlTrellis.Schema.Database(new global::DripSharp.SqlTrellis.Schema.Server("server", "instance"), "db"));
global::DripSharp.Testing.JavaAssertions.Equal("[server\\instance].db..bla", table.ToString(), null);
}

public virtual void tableSetDatabase() {
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table();
table.setName("testtable");
global::DripSharp.SqlTrellis.Schema.Database database = new global::DripSharp.SqlTrellis.Schema.Database("default");
table.setDatabase(database);
global::DripSharp.Testing.JavaAssertions.Equal("default..testtable", table.ToString(), null);
}

public virtual void tableSetDatabaseIssue812() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM MY_TABLE1 as T1, MY_TABLE2, (SELECT * FROM MY_DB.TABLE3) LEFT OUTER JOIN MY_TABLE4 ", " WHERE ID = (SELECT MAX(ID) FROM MY_TABLE5) AND ID2 IN (SELECT * FROM MY_TABLE6)");
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql)!);
global::System.Text.StringBuilder buffer = new global::System.Text.StringBuilder();
global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser();
global::DripSharp.SqlTrellis.Schema.Database database = new global::DripSharp.SqlTrellis.Schema.Database("default");
global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser deparser = new Anonymous_59_35(expressionDeParser, buffer, database);
deparser.visit<object>((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(select!), (object)default!);
}

private sealed class Anonymous_59_35 : global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser {
private readonly global::DripSharp.SqlTrellis.Schema.Database __capture_0;

public Anonymous_59_35(global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder> baseArgument0, global::System.Text.StringBuilder baseArgument1, global::DripSharp.SqlTrellis.Schema.Database __capture_0) : base(baseArgument0, baseArgument1) {
this.__capture_0 = __capture_0;
}

public override global::System.Text.StringBuilder visit<S>(global::DripSharp.SqlTrellis.Schema.Table tableName, S parameters) {
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(tableName);
tableName.setDatabase(this.__capture_0);
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(tableName.getDatabase());
return default!;
}
}

public virtual void testTableRemoveNameParts() {
global::DripSharp.SqlTrellis.Schema.Table table = new global::DripSharp.SqlTrellis.Schema.Table("link", "DICTIONARY");
global::DripSharp.Testing.JavaAssertJ.That(table.getFullyQualifiedName()).IsEqualTo("link.DICTIONARY");
table.setSchemaName((string)default!);
global::DripSharp.Testing.JavaAssertJ.That(table.getFullyQualifiedName()).IsEqualTo("DICTIONARY");
}

public virtual void testConstructorDelimitersInappropriateSize() {
global::DripSharp.Testing.JavaAssertJ.ThrownBy(() => new global::DripSharp.SqlTrellis.Schema.Table(global::DripSharp.Runtime.JavaCompat.ListOf<string>("a", "b", "c"), global::DripSharp.Runtime.JavaCompat.ListOf<string>("too", "many", "delimiters"))).IsInstanceOf(typeof(global::System.ArgumentException)).HasMessageContaining("the length of the delimiters list must be 1 less than nameParts");
}

internal virtual void testBigQueryFullQuotedName() {
string sqlStr = "select * from `d.s.t`";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.SqlTrellis.Schema.Table table = (global::DripSharp.SqlTrellis.Schema.Table)(select.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Equal("\"d\"", table.getCatalogName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\"s\"", table.getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\"t\"", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("d", table.getUnquotedDatabaseName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("s", table.getUnquotedSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("t", table.getUnquotedName(), null);
sqlStr = "select * from `s.t`";
select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
table = (global::DripSharp.SqlTrellis.Schema.Table)(select.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Null(table.getCatalogName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\"s\"", table.getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("\"t\"", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Null(table.getUnquotedDatabaseName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("s", table.getUnquotedSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("t", table.getUnquotedName(), null);
}

[Xunit.Fact]
public void __Upstream_e13f8cf4d34ecee6()
{
        try
        {
            this.tableIndexException();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8b2ec7bd71ee3e2e()
{
        try
        {
            this.tableSetDatabase();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_823acf5482f31ebb()
{
        try
        {
            this.tableSetDatabaseIssue812();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0a6f76c83b1bdb0c()
{
        try
        {
            this.testBigQueryFullQuotedName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cdb1d784053df9d6()
{
        try
        {
            this.testConstructorDelimitersInappropriateSize();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4d29630a53cbfbc3()
{
        try
        {
            this.testTableRemoveNameParts();
        }
        finally
        {
        }
}
}
