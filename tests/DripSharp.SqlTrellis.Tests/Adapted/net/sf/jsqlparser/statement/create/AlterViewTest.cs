// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class AlterViewTest {
public virtual void testAlterView() {
string statement = "ALTER VIEW myview AS SELECT * FROM mytab";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Create.View.AlterView created = new global::DripSharp.SqlTrellis.Statement.Create.View.AlterView().withView(new global::DripSharp.SqlTrellis.Schema.Table("myview")).withSelect(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItem(new global::DripSharp.SqlTrellis.Statement.Select.AllColumns()).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("mytab")));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testReplaceView() {
string statement = "REPLACE VIEW myview(a, b) AS SELECT a, b FROM mytab";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Create.View.AlterView alterView = new global::DripSharp.SqlTrellis.Statement.Create.View.AlterView().withUseReplace(true).addColumnNames("a").addColumnNames(global::DripSharp.Runtime.JavaCompat.SetOf<string>("b")).withView(new global::DripSharp.SqlTrellis.Schema.Table("myview")).withSelect(new global::DripSharp.SqlTrellis.Statement.Select.PlainSelect().addSelectItems(new global::DripSharp.SqlTrellis.Schema.Column("a"), new global::DripSharp.SqlTrellis.Schema.Column("b")).withFromItem(new global::DripSharp.SqlTrellis.Schema.Table("mytab")));
global::DripSharp.Testing.JavaAssertions.True((alterView.getSelectBody<global::DripSharp.SqlTrellis.Statement.Select.PlainSelect>(typeof(global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)) is global::DripSharp.SqlTrellis.Statement.Select.PlainSelect), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(alterView, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, alterView);
}

[Xunit.Fact]
public void __Upstream_74d71436d97e3303()
{
        try
        {
            this.testAlterView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dae0602f08b42c03()
{
        try
        {
            this.testReplaceView();
        }
        finally
        {
        }
}
}
