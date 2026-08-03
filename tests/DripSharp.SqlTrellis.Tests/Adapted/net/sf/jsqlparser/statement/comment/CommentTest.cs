// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Comment;

public class CommentTest {
public virtual void testCommentTable() {
string statement = "COMMENT ON TABLE table1 IS 'comment1'";
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = (global::DripSharp.SqlTrellis.Statement.Comment.Comment)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Schema.Table table = comment.getTable();
global::DripSharp.Testing.JavaAssertions.Equal("table1", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("comment1", comment.getComment().getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", comment), null);
}

public virtual void testCommentTable2() {
string statement = "COMMENT ON TABLE schema1.table1 IS 'comment1'";
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = (global::DripSharp.SqlTrellis.Statement.Comment.Comment)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Schema.Table table = comment.getTable();
global::DripSharp.Testing.JavaAssertions.Equal("schema1", table.getSchemaName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("table1", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("comment1", comment.getComment().getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", comment), null);
}

public virtual void testCommentTableDeparse() {
string statement = "COMMENT ON TABLE table1 IS 'comment1'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Comment.Comment c = new global::DripSharp.SqlTrellis.Statement.Comment.Comment().withTable(new global::DripSharp.SqlTrellis.Schema.Table("table1")).withComment(new global::DripSharp.SqlTrellis.Expression.StringValue("comment1"));
global::DripSharp.Testing.JavaAssertions.Equal("table1", c.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("comment1", c.getComment().getValue(), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(c, statement, false);
}

public virtual void testCommentColumn() {
string statement = "COMMENT ON COLUMN table1.column1 IS 'comment1'";
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = (global::DripSharp.SqlTrellis.Statement.Comment.Comment)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.SqlTrellis.Schema.Column column = comment.getColumn();
global::DripSharp.Testing.JavaAssertions.Equal("table1", column.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("column1", column.getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("comment1", comment.getComment().getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", comment), null);
global::DripSharp.SqlTrellis.Statement.Comment.Comment c = new global::DripSharp.SqlTrellis.Statement.Comment.Comment().withColumn(new global::DripSharp.SqlTrellis.Schema.Column(new global::DripSharp.SqlTrellis.Schema.Table("table1"), "column1")).withComment(new global::DripSharp.SqlTrellis.Expression.StringValue("comment1"));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(c, statement, false);
}

public virtual void testCommentColumnDeparse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("COMMENT ON COLUMN table1.column1 IS 'comment1'");
}

public virtual void testToString() {
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = new global::DripSharp.SqlTrellis.Statement.Comment.Comment();
global::DripSharp.Testing.JavaAssertions.Equal("COMMENT ON IS null", comment.ToString(), null);
}

public virtual void testCommentColumnDeparseIssue696() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("COMMENT ON COLUMN hotels.hotelid IS 'Primary key of the table'");
}

public virtual void testCommentTableColumnDiffersIssue984() {
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = (global::DripSharp.SqlTrellis.Statement.Comment.Comment)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("COMMENT ON COLUMN myTable.myColumn is 'Some comment'")!);
global::DripSharp.Testing.JavaAssertJ.That(comment.getTable()).IsNull();
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn().getColumnName()).IsEqualTo("myColumn");
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn().getTable().getFullyQualifiedName()).IsEqualTo("myTable");
}

public virtual void testCommentTableColumnDiffersIssue984_2() {
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = (global::DripSharp.SqlTrellis.Statement.Comment.Comment)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("COMMENT ON COLUMN mySchema.myTable.myColumn is 'Some comment'")!);
global::DripSharp.Testing.JavaAssertJ.That(comment.getTable()).IsNull();
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn().getColumnName()).IsEqualTo("myColumn");
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn().getTable().getFullyQualifiedName()).IsEqualTo("mySchema.myTable");
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn().getTable().getName()).IsEqualTo("myTable");
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn().getTable().getSchemaName()).IsEqualTo("mySchema");
}

public virtual void testCommentOnView() {
string statement = "COMMENT ON VIEW myschema.myView IS 'myComment'";
global::DripSharp.SqlTrellis.Statement.Comment.Comment comment = (global::DripSharp.SqlTrellis.Statement.Comment.Comment)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement)!);
global::DripSharp.Testing.JavaAssertJ.That(comment.getTable()).IsNull();
global::DripSharp.Testing.JavaAssertJ.That(comment.getColumn()).IsNull();
global::DripSharp.Testing.JavaAssertJ.That(comment.getView().getFullyQualifiedName()).IsEqualTo("myschema.myView");
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(comment, statement);
}

[Xunit.Fact]
public void __Upstream_2753b04631246d44()
{
        try
        {
            this.testCommentColumn();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_103f0f7a1523d487()
{
        try
        {
            this.testCommentColumnDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e9d6dfc548b76c7()
{
        try
        {
            this.testCommentColumnDeparseIssue696();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a7e0a65484b724c3()
{
        try
        {
            this.testCommentOnView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_afb51d55e85361d3()
{
        try
        {
            this.testCommentTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_64d5e6c74470e39a()
{
        try
        {
            this.testCommentTable2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_beceeff4edc3254c()
{
        try
        {
            this.testCommentTableColumnDiffersIssue984();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_625280e96519e13a()
{
        try
        {
            this.testCommentTableColumnDiffersIssue984_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ef1423fcc48e0c5e()
{
        try
        {
            this.testCommentTableDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_882d7093d1c99314()
{
        try
        {
            this.testToString();
        }
        finally
        {
        }
}
}
