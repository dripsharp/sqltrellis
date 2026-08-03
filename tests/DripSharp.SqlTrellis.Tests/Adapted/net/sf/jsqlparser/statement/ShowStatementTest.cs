// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ShowStatementTest {
public virtual void testSimpleUse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW mydatabase");
}

public virtual void testSimpleUse2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW transaction_isolation");
}

internal virtual void testShowIndexesFromTable() {
string sqlStr = "show indexes from my_table";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testShowCreateTable() {
string sqlStr = "show create table my_table";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
global::DripSharp.Testing.JavaAssertions.True((statement is global::DripSharp.SqlTrellis.Statement.UnsupportedStatement), null);
}

[Xunit.Fact]
public void __Upstream_5c59dd15b5cf4b8e()
{
        try
        {
            this.testShowCreateTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e343d9299290a731()
{
        try
        {
            this.testShowIndexesFromTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_47917a655feb67be()
{
        try
        {
            this.testSimpleUse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_42e224925d05a95d()
{
        try
        {
            this.testSimpleUse2();
        }
        finally
        {
        }
}
}
