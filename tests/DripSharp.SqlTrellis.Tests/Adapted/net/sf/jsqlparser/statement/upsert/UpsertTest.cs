// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Upsert;

public class UpsertTest {
internal global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testUpsert() {
string statement = "UPSERT INTO TEST (NAME, ID) VALUES ('foo', 123)";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert upsert = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("TEST", upsert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(upsert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("NAME", global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("ID", global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getColumns(), 1).getColumnName(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = upsert.getValues().getExpressions();
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(expressions), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", ((global::DripSharp.SqlTrellis.Expression.StringValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 0)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(123), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 1)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Null(upsert.getDuplicateUpdateSets(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", upsert), null);
}

public virtual void testUpsertDuplicate() {
string statement = "UPSERT INTO TEST (ID, COUNTER) VALUES (123, 0) ON DUPLICATE KEY UPDATE COUNTER = COUNTER + 1";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert upsert = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("TEST", upsert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(upsert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("ID", global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("COUNTER", global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getColumns(), 1).getColumnName(), null);
var expressions = global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(upsert.getValues().getExpressions());
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(expressions), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(123), (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 0))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(0), (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 1))).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(upsert.getDuplicateUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("COUNTER", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getDuplicateUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("COUNTER + 1", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getDuplicateUpdateSets(), 0).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", upsert), null);
}

public virtual void testUpsertSelect() {
string statement = "UPSERT INTO test.targetTable (col1, col2) SELECT * FROM test.sourceTable";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert upsert = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("test.targetTable", upsert.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(upsert.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getColumns(), 1).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Null(upsert.getExpressions(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(upsert.getSelect(), null);
global::DripSharp.Testing.JavaAssertions.Equal("test.sourceTable", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(upsert.getSelect()!)).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Null(upsert.getDuplicateUpdateSets(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", upsert), null);
}

public virtual void testUpsertN() {
string statement = "UPSERT INTO TEST VALUES ('foo', 'bar', 3)";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert upsert = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("TEST", upsert.getTable().getName(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = upsert.getValues().getExpressions();
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(expressions), null);
global::DripSharp.Testing.JavaAssertions.Equal("foo", ((global::DripSharp.SqlTrellis.Expression.StringValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 0)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal("bar", ((global::DripSharp.SqlTrellis.Expression.StringValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 1)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(3), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 2)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.Null(upsert.getDuplicateUpdateSets(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", upsert), null);
}

public virtual void testUpsertMultiRowValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO mytable (col1, col2) VALUES (a, b), (d, e)", true);
}

public virtual void testUpsertMultiRowValueDifferent() {
try {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO mytable (col1, col2) VALUES (a, b), (d, e, c)");
} catch (global::System.Exception e) when (e is not global::System.TypeInitializationException) {
return;
}
global::DripSharp.Testing.JavaAssertions.Fail("Assertion failed.");
}

public virtual void testSimpleUpsert() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO example (num, name, address, tel) VALUES (1, 'name', 'test ', '1234-1234')", true);
}

public virtual void testUpsertHasSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO mytable (mycolumn) SELECT mycolumn FROM mytable", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO mytable (mycolumn) (SELECT mycolumn FROM mytable)", true);
}

public virtual void testUpsertWithSelect() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO mytable (mycolumn) WITH a AS (SELECT mycolumn FROM mytable) SELECT mycolumn FROM a", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO mytable (mycolumn) (WITH a AS (SELECT mycolumn FROM mytable) SELECT mycolumn FROM a)", true);
}

public virtual void testUpsertWithKeywords() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO kvPair (value, key) VALUES (?, ?)", true);
}

public virtual void testHexValues() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO TABLE2 VALUES ('1', \"DSDD\", x'EFBFBDC7AB')");
}

public virtual void testHexValues2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO TABLE2 VALUES ('1', \"DSDD\", 0xEFBFBDC7AB)");
}

public virtual void testHexValues3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO TABLE2 VALUES ('1', \"DSDD\", 0xabcde)");
}

public virtual void testDuplicateKey() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("UPSERT INTO Users0 (UserId, Key, Value) VALUES (51311, 'T_211', 18) ON DUPLICATE KEY UPDATE Value = 18", true);
}

[Xunit.Fact]
public void __Upstream_fef262dc42f9e95f()
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
public void __Upstream_f3803a7665b8b54c()
{
        try
        {
            this.testHexValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_66e25291c8dd9985()
{
        try
        {
            this.testHexValues2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_614f78b7b1d70800()
{
        try
        {
            this.testHexValues3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_627607909ae2d995()
{
        try
        {
            this.testSimpleUpsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5661a929b2d5a3d8()
{
        try
        {
            this.testUpsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d4c3c0cb1039be15()
{
        try
        {
            this.testUpsertDuplicate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3461c794ccb55234()
{
        try
        {
            this.testUpsertHasSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eb175bb870a6a5f5()
{
        try
        {
            this.testUpsertMultiRowValue();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_6fb4f4ea2255746d()
{
        try
        {
            this.testUpsertMultiRowValueDifferent();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d96615657f66e67b()
{
        try
        {
            this.testUpsertN();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eeba80cf1c449453()
{
        try
        {
            this.testUpsertSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_82f8d4c1c08622dd()
{
        try
        {
            this.testUpsertWithKeywords();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d40264bfafb3c1d5()
{
        try
        {
            this.testUpsertWithSelect();
        }
        finally
        {
        }
}
}
