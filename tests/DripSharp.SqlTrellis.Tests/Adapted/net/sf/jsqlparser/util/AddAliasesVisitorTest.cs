// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class AddAliasesVisitorTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testVisit_PlainSelect() {
string sql = "select a,b,c from test";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(sql))!);
global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object> instance = new global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object>();
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(instance), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a AS A1, b AS A2, c AS A3 FROM test", select.ToString(), null);
}

public virtual void testVisit_PlainSelect_duplicates() {
string sql = "select a,b as a1,c from test";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(sql))!);
global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object> instance = new global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object>();
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(instance), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT a AS A2, b AS a1, c AS A3 FROM test", select.ToString(), null);
}

public virtual void testVisit_PlainSelect_expression() {
string sql = "select 3+4 from test";
global::DripSharp.SqlTrellis.Statement.Select.Select select = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(sql))!);
global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object> instance = new global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object>();
select.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(instance), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT 3 + 4 AS A1 FROM test", select.ToString(), null);
}

public virtual void testVisit_SetOperationList() {
string sql = "select 3+4 from test union select 7+8 from test2";
global::DripSharp.SqlTrellis.Statement.Select.Select setOpList = (global::DripSharp.SqlTrellis.Statement.Select.Select)(this.parserManager.parse(new global::System.IO.StringReader(sql))!);
global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object> instance = new global::DripSharp.SqlTrellis.Util.AddAliasesVisitor<object>();
setOpList.accept<object, object>((global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<object>)(instance), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("SELECT 3 + 4 AS A1 FROM test UNION SELECT 7 + 8 AS A1 FROM test2", setOpList.ToString(), null);
}

[Xunit.Fact]
public void __Upstream_4d7f2262d4e9ea8f()
{
        try
        {
            this.testVisit_PlainSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b5ae27a4ccbb3ceb()
{
        try
        {
            this.testVisit_PlainSelect_duplicates();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f272eb3ab3fdcb87()
{
        try
        {
            this.testVisit_PlainSelect_expression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d5c560225041eb5()
{
        try
        {
            this.testVisit_SetOperationList();
        }
        finally
        {
        }
}
}
