// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class ParenthesedSelectTest {
internal virtual void testConstructFromItem() {
string sqlStr = "select winsales.* from winsales;";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
select.setFromItem(new global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect(select.getFromItem()));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, "select winsales.* from (select * from winsales) AS winsales;", true);
sqlStr = "select a.* from winsales AS a;";
select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
select.setFromItem(new global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect(select.getFromItem()));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(select, "select a.* from (select * from winsales AS a) AS a;", true);
}

[Xunit.Fact]
public void __Upstream_68f36c4ffbf44672()
{
        try
        {
            this.testConstructFromItem();
        }
        finally
        {
        }
}
}
