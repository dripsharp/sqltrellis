// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class CreateViewTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testCreateView() {
string statement = "CREATE VIEW myview AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.False(createView.isOrReplace(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myview", createView.getView().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", ((global::DripSharp.SqlTrellis.Schema.Table)(((global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(createView.getSelect()!)).getFromItem()!)).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, createView.ToString(), null);
}

public virtual void testCreateView2() {
string stmt = "CREATE VIEW myview AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateView3() {
string stmt = "CREATE OR REPLACE VIEW myview AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateView4() {
string stmt = "CREATE OR REPLACE VIEW view2 AS SELECT a, b, c FROM testtab INNER JOIN testtab2 ON testtab.col1 = testtab2.col2";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateViewWithColumnNames1() {
string stmt = "CREATE OR REPLACE VIEW view1(col1, col2) AS SELECT a, b FROM testtab";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateView5() {
string statement = "CREATE VIEW myview AS (SELECT * FROM mytab)";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.False(createView.isOrReplace(), null);
global::DripSharp.Testing.JavaAssertions.Equal("myview", createView.getView().getName(), null);
global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect parenthesedSelect = (global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect)(createView.getSelect()!);
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(parenthesedSelect.getSelect()!);
global::DripSharp.SqlTrellis.Schema.Table table = (global::DripSharp.SqlTrellis.Schema.Table)(plainSelect.getFromItem()!);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", table.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, createView.ToString(), null);
}

public virtual void testCreateViewUnion() {
string stmt = "CREATE VIEW view1 AS (SELECT a, b FROM testtab) UNION (SELECT b, c FROM testtab2)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateMaterializedView() {
string stmt = "CREATE MATERIALIZED VIEW view1 AS SELECT a, b FROM testtab";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateForceView() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE FORCE VIEW view1 AS SELECT a, b FROM testtab");
}

public virtual void testCreateForceView1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE NO FORCE VIEW view1 AS SELECT a, b FROM testtab");
}

public virtual void testCreateForceView2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE OR REPLACE FORCE VIEW view1 AS SELECT a, b FROM testtab");
}

public virtual void testCreateForceView3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE OR REPLACE NO FORCE VIEW view1 AS SELECT a, b FROM testtab");
}

public virtual void testCreateSecureView() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SECURE VIEW myview AS SELECT * FROM mytable");
}

public virtual void testCreateVolatileView() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE VOLATILE VIEW myview AS SELECT * FROM mytable");
}

public virtual void testCreateTemporaryViewIssue604() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TEMPORARY VIEW myview AS SELECT * FROM mytable");
}

public virtual void testCreateTemporaryViewIssue604_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE TEMP VIEW myview AS SELECT * FROM mytable");
}

public virtual void testCreateTemporaryViewIssue665() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE VIEW foo(\"BAR\") AS WITH temp AS (SELECT temp_bar FROM foobar) SELECT bar FROM temp");
}

public virtual void testCreateWithReadOnlyViewIssue838() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE VIEW v14(c1, c2) AS SELECT c1, C2 FROM t1 WITH READ ONLY");
}

public virtual void testCreateViewAutoRefreshNone() {
string stmt = "CREATE VIEW myview AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(createView.getAutoRefresh(), global::DripSharp.SqlTrellis.Statement.Create.View.AutoRefreshOption.NONE, null);
}

public virtual void testCreateViewAutoRefreshYes() {
string stmt = "CREATE VIEW myview AUTO REFRESH YES AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(createView.getAutoRefresh(), global::DripSharp.SqlTrellis.Statement.Create.View.AutoRefreshOption.YES, null);
}

public virtual void testCreateViewAutoRefreshNo() {
string stmt = "CREATE VIEW myview AUTO REFRESH NO AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.Equal(createView.getAutoRefresh(), global::DripSharp.SqlTrellis.Statement.Create.View.AutoRefreshOption.NO, null);
}

public virtual void testCreateViewAutoFails() {
string stmt = "CREATE VIEW myview AUTO AS SELECT * FROM mytab";
global::System.Action throwingCallable = () => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.Testing.JavaAssertJ.ThrownBy(throwingCallable).IsInstanceOf(typeof(global::DripSharp.SqlTrellis.JSQLParserException)).HasRootCauseInstanceOf(typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).RootCause().HasMessageStartingWith("Encountered unexpected token");
}

public virtual void testCreateViewRefreshFails() {
string stmt = "CREATE VIEW myview REFRESH AS SELECT * FROM mytab";
global::System.Action throwingCallable = () => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.Testing.JavaAssertJ.ThrownBy(throwingCallable).IsInstanceOf(typeof(global::DripSharp.SqlTrellis.JSQLParserException)).HasRootCauseInstanceOf(typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).RootCause().HasMessageStartingWith("Encountered unexpected token");
}

public virtual void testCreateViewAutoRefreshFails() {
string stmt = "CREATE VIEW myview AUTO REFRESH AS SELECT * FROM mytab";
global::System.Action throwingCallable = () => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(stmt);
global::DripSharp.Testing.JavaAssertJ.ThrownBy(throwingCallable).IsInstanceOf(typeof(global::DripSharp.SqlTrellis.JSQLParserException)).HasRootCauseInstanceOf(typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).RootCause().HasMessageStartingWith("Encountered unexpected token");
}

public virtual void testCreateViewIfNotExists() {
string stmt = "CREATE VIEW myview IF NOT EXISTS AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.True(createView.isIfNotExists(), null);
}

public virtual void testCreateMaterializedViewIfNotExists() {
string stmt = "CREATE MATERIALIZED VIEW myview IF NOT EXISTS AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Create.View.CreateView createView = (global::DripSharp.SqlTrellis.Statement.Create.View.CreateView)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt)!);
global::DripSharp.Testing.JavaAssertions.True(createView.isMaterialized(), null);
global::DripSharp.Testing.JavaAssertions.True(createView.isIfNotExists(), null);
}

public virtual void testCreateViewWithColumnComment() {
string stmt = "CREATE VIEW v14(c1 COMMENT 'comment1', c2 COMMENT 'comment2') AS SELECT c1, C2 FROM t1 WITH READ ONLY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
string stmt2 = "CREATE VIEW v14(c1 COMMENT 'comment1', c2) AS SELECT c1, C2 FROM t1 WITH READ ONLY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt2);
string stmt3 = "CREATE VIEW v14(c1, c2) COMMENT = 'view' AS SELECT c1, C2 FROM t1 WITH READ ONLY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt3);
}

public virtual void testCreateViewWithTableComment1() {
string stmt = "CREATE VIEW v14(c1 COMMENT 'comment1', c2 COMMENT 'comment2') COMMENT 'view' AS SELECT c1, C2 FROM t1 WITH READ ONLY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

public virtual void testCreateViewWithTableComment2() {
string stmt = "CREATE VIEW v14(c1 COMMENT 'comment1', c2 COMMENT 'comment2') COMMENT = 'view' AS SELECT c1, C2 FROM t1 WITH READ ONLY";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(stmt);
}

[Xunit.Fact]
public void __Upstream_6ea34fb62b593f66()
{
        try
        {
            this.testCreateForceView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_41da37316b03b1a0()
{
        try
        {
            this.testCreateForceView1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e80c57485a9c04cc()
{
        try
        {
            this.testCreateForceView2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6d6d8b1cde054119()
{
        try
        {
            this.testCreateForceView3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c07d0e14029f32a6()
{
        try
        {
            this.testCreateMaterializedView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0b851b490f7e4f3b()
{
        try
        {
            this.testCreateMaterializedViewIfNotExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_abc073e37414c495()
{
        try
        {
            this.testCreateSecureView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8170ed94be789cd4()
{
        try
        {
            this.testCreateTemporaryViewIssue604();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8c60f731022b6ef()
{
        try
        {
            this.testCreateTemporaryViewIssue604_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_04f978208b3e9a33()
{
        try
        {
            this.testCreateTemporaryViewIssue665();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6c8a251ac62befc2()
{
        try
        {
            this.testCreateView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_471e5fd9327db242()
{
        try
        {
            this.testCreateView2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_318a9830d13b21e1()
{
        try
        {
            this.testCreateView3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b0a2c4f691476a6()
{
        try
        {
            this.testCreateView4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9028749d1626fcbb()
{
        try
        {
            this.testCreateView5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c837c380a52e3997()
{
        try
        {
            this.testCreateViewAutoFails();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39073baa2061c9a8()
{
        try
        {
            this.testCreateViewAutoRefreshFails();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9587ece110170416()
{
        try
        {
            this.testCreateViewAutoRefreshNo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ef5e7e1ca9312fa()
{
        try
        {
            this.testCreateViewAutoRefreshNone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cfb3c500b2f15e2e()
{
        try
        {
            this.testCreateViewAutoRefreshYes();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1d7f08b4ffe952b6()
{
        try
        {
            this.testCreateViewIfNotExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a83ea8a63b843a96()
{
        try
        {
            this.testCreateViewRefreshFails();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51e311958df7d543()
{
        try
        {
            this.testCreateViewUnion();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_87a9fb3e44533bda()
{
        try
        {
            this.testCreateViewWithColumnComment();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_463df03260ece056()
{
        try
        {
            this.testCreateViewWithColumnNames1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_35cec321505b574a()
{
        try
        {
            this.testCreateViewWithTableComment1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cac25010cd45ac14()
{
        try
        {
            this.testCreateViewWithTableComment2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8518b4d983ee954()
{
        try
        {
            this.testCreateVolatileView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6a12f17388ac3878()
{
        try
        {
            this.testCreateWithReadOnlyViewIssue838();
        }
        finally
        {
        }
}
}
