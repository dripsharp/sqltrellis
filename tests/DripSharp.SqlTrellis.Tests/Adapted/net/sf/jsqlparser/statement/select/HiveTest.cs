// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class HiveTest {
public virtual void testLeftSemiJoin() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    Something\n"), "FROM\n"), "    Sometable\n"), "LEFT SEMI JOIN\n"), "    Othertable\n");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("Othertable", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isLeft(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isSemi(), null);
}

public virtual void testGroupByGroupingSets() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    C1, C2, C3, MAX(Value)\n"), "FROM\n"), "    Sometable\n"), "GROUP BY C1, C2, C3 GROUPING SETS ((C1, C2), (C1, C2, C3), ())");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testGroupSimplified() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    * \n"), "FROM\n"), "    Sometable\n"), "GROUP BY GROUPING SETS (())");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

[Xunit.Fact]
public void __Upstream_204fb0d374bddf4f()
{
        try
        {
            this.testGroupByGroupingSets();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f5d34ffe2773c32f()
{
        try
        {
            this.testGroupSimplified();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_506411e5d5d60420()
{
        try
        {
            this.testLeftSemiJoin();
        }
        finally
        {
        }
}
}
