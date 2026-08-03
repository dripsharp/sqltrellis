// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class FetchTest {
internal virtual void testParser() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT table_schema \n", "FROM information_schema.tables \n"), "fetch next :variable rows only");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void getExpression() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT table_schema \n", "FROM information_schema.tables \n"), "fetch next (SELECT 1 FROM DUAL) rows only");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.SqlTrellis.Statement.Select.Fetch fetch = plainSelect.getFetch();
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.ParenthesedSelect>(fetch.getExpression(), null);
}

internal virtual void testFetchWithoutExpressionIssue1859() {
string sqlStr = "select 1 from test.dual fetch first row only";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_e71d5e38db041147()
{
        try
        {
            this.getExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9b81926c75d811b()
{
        try
        {
            this.testFetchWithoutExpressionIssue1859();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_60620ded3c2783df()
{
        try
        {
            this.testParser();
        }
        finally
        {
        }
}
}
