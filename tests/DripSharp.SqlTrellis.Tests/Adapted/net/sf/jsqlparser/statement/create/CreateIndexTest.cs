// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class CreateIndexTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testCreateIndex() {
string statement = "CREATE INDEX myindex ON mytab (mycol, mycol2)";
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(createIndex.getIndex().getColumnsNames()), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex", createIndex.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Null(createIndex.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", createIndex.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", global::DripSharp.Runtime.JavaCompat.ListGet(createIndex.getIndex().getColumnsNames(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", createIndex), null);
}

public virtual void testCreateIndex2() {
string statement = "CREATE mytype INDEX myindex ON mytab (mycol, mycol2)";
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(createIndex.getIndex().getColumnsNames()), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex", createIndex.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytype", createIndex.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", createIndex.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol2", global::DripSharp.Runtime.JavaCompat.ListGet(createIndex.getIndex().getColumnsNames(), 1), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", createIndex), null);
}

public virtual void testCreateIndex3() {
string statement = "CREATE mytype INDEX myindex ON mytab (mycol ASC, mycol2, mycol3)";
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(createIndex.getIndex().getColumnsNames()), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex", createIndex.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytype", createIndex.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", createIndex.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol3", global::DripSharp.Runtime.JavaCompat.ListGet(createIndex.getIndex().getColumnsNames(), 2), null);
}

public virtual void testCreateIndex4() {
string statement = "CREATE mytype INDEX myindex ON mytab (mycol ASC, mycol2 (75), mycol3)";
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(createIndex.getIndex().getColumnsNames()), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex", createIndex.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytype", createIndex.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", createIndex.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol3", global::DripSharp.Runtime.JavaCompat.ListGet(createIndex.getIndex().getColumnsNames(), 2), null);
}

public virtual void testCreateIndex5() {
string statement = "CREATE mytype INDEX myindex ON mytab (mycol ASC, mycol2 (75), mycol3) mymodifiers";
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(createIndex.getIndex().getColumnsNames()), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex", createIndex.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytype", createIndex.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", createIndex.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol3", global::DripSharp.Runtime.JavaCompat.ListGet(createIndex.getIndex().getColumnsNames(), 2), null);
}

public virtual void testCreateIndex6() {
string stmt = "CREATE INDEX myindex ON mytab (mycol, mycol2)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateIndex7() {
string statement = "CREATE INDEX myindex1 ON mytab USING GIST (mycol)";
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(createIndex.getIndex().getColumnsNames()), null);
global::DripSharp.Testing.JavaAssertions.Equal("myindex1", createIndex.getIndex().getName(), null);
global::DripSharp.Testing.JavaAssertions.Null(createIndex.getIndex().getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", createIndex.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mycol", global::DripSharp.Runtime.JavaCompat.ListGet(createIndex.getIndex().getColumnsNames(), 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("GIST", createIndex.getIndex().getUsing(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", createIndex), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
}

public virtual void testCreateIndexIssue633() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE INDEX idx_american_football_action_plays_1 ON american_football_action_plays USING btree (play_type)");
}

public virtual void testFullIndexNameIssue936() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE INDEX \"TS\".\"IDX\" ON \"TEST\" (\"ID\" ASC) TABLESPACE \"TS\"");
}

public virtual void testFullIndexNameIssue936_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE INDEX \"TS\".\"IDX\" ON \"TEST\" (\"ID\") TABLESPACE \"TS\"");
}

public virtual void testCreateIndexTrailingOptions() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE UNIQUE INDEX cfe.version_info_idx2\n", "    ON cfe.version_info ( major_version\n"), "                            , minor_version\n"), "                            , patch_level ) parallel compress nologging\n"), ";");
global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex createIndex = (global::DripSharp.SqlTrellis.Statement.Create.Index.CreateIndex)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::System.Collections.Generic.IList<string> tailParameters = createIndex.getTailParameters();
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(tailParameters), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListGet(tailParameters, 0), "parallel", null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListGet(tailParameters, 1), "compress", null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ListGet(tailParameters, 2), "nologging", null);
}

internal virtual void testIfNotExistsIssue1861() {
string sqlStr = "CREATE INDEX IF NOT EXISTS test_test_idx ON test.test USING btree (\"time\")";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testCreateIndexIssue1814() {
string sqlStr = "CREATE INDEX idx_operationlog_operatetime_regioncode USING BTREE ON operation_log (operate_time,region_biz_code)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_fb04f012c27cc74d()
{
        try
        {
            this.testCreateIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c5ae21095c031120()
{
        try
        {
            this.testCreateIndex2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_362bb68fedc04c06()
{
        try
        {
            this.testCreateIndex3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b5d53d440eeef47()
{
        try
        {
            this.testCreateIndex4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_23b3e2c97fd7937a()
{
        try
        {
            this.testCreateIndex5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9abb714e7693823()
{
        try
        {
            this.testCreateIndex6();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9b474f2d7dd5df40()
{
        try
        {
            this.testCreateIndex7();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2dc2111f76488d66()
{
        try
        {
            this.testCreateIndexIssue1814();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5eb006eabfd2dc2f()
{
        try
        {
            this.testCreateIndexIssue633();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_da06159641e092d8()
{
        try
        {
            this.testCreateIndexTrailingOptions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7eb0e7a56664e587()
{
        try
        {
            this.testFullIndexNameIssue936();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1bb19278a2fde4cf()
{
        try
        {
            this.testFullIndexNameIssue936_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_108bdae663357ab7()
{
        try
        {
            this.testIfNotExistsIssue1861();
        }
        finally
        {
        }
}
}
