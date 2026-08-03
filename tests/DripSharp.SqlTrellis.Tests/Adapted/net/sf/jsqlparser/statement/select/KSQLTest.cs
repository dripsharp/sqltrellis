// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class KSQLTest {
public virtual void testKSQLWindowedJoin() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table1 t1\n"), "INNER JOIN table2 t2\n"), "WITHIN (5 HOURS)\n"), "ON t1.id = t2.id\n");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("table2", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isWindowJoin(), null);
global::DripSharp.Testing.JavaAssertions.Equal(5L, global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().getDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("HOURS", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().getTimeUnit().ToString(), null);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().isBeforeAfterWindow(), null);
}

public virtual void testKSQLBeforeAfterWindowedJoin() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table1 t1\n"), "INNER JOIN table2 t2\n"), "WITHIN (1 MINUTE, 5 MINUTES)\n"), "ON t1.id = t2.id\n");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(plainSelect.getJoins()), null);
global::DripSharp.Testing.JavaAssertions.Equal("table2", ((global::DripSharp.SqlTrellis.Schema.Table)(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getFromItem()!)).getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).isWindowJoin(), null);
global::DripSharp.Testing.JavaAssertions.Equal(1L, global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().getBeforeDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("MINUTE", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().getBeforeTimeUnit().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(5L, global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().getAfterDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("MINUTES", global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().getAfterTimeUnit().ToString(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(plainSelect.getJoins(), 0).getJoinWindow().isBeforeAfterWindow(), null);
}

public virtual void testKSQLHoppingWindows() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table1 t1\n"), "WINDOW HOPPING (SIZE 30 SECONDS, ADVANCE BY 10 MINUTES)\n"), "GROUP BY region.id\n");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.True(plainSelect.getKsqlWindow().isHoppingWindow(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.getKsqlWindow().isSessionWindow(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.getKsqlWindow().isTumblingWindow(), null);
global::DripSharp.Testing.JavaAssertions.Equal(30L, plainSelect.getKsqlWindow().getSizeDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SECONDS", plainSelect.getKsqlWindow().getSizeTimeUnit().ToString(), null);
global::DripSharp.Testing.JavaAssertions.Equal(10L, plainSelect.getKsqlWindow().getAdvanceDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("MINUTES", plainSelect.getKsqlWindow().getAdvanceTimeUnit().ToString(), null);
}

public virtual void testKSQLSessionWindows() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table1 t1\n"), "WINDOW SESSION (5 MINUTES)\n"), "GROUP BY region.id\n");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.True(plainSelect.getKsqlWindow().isSessionWindow(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.getKsqlWindow().isHoppingWindow(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.getKsqlWindow().isTumblingWindow(), null);
global::DripSharp.Testing.JavaAssertions.Equal(5L, plainSelect.getKsqlWindow().getSizeDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("MINUTES", plainSelect.getKsqlWindow().getSizeTimeUnit().ToString(), null);
}

public virtual void testKSQLTumblingWindows() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT *\n", "FROM table1 t1\n"), "WINDOW TUMBLING (SIZE 30 SECONDS)\n"), "GROUP BY region.id\n");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.True(plainSelect.getKsqlWindow().isTumblingWindow(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.getKsqlWindow().isSessionWindow(), null);
global::DripSharp.Testing.JavaAssertions.False(plainSelect.getKsqlWindow().isHoppingWindow(), null);
global::DripSharp.Testing.JavaAssertions.Equal(30L, plainSelect.getKsqlWindow().getSizeDuration(), null);
global::DripSharp.Testing.JavaAssertions.Equal("SECONDS", plainSelect.getKsqlWindow().getSizeTimeUnit().ToString(), null);
}

public virtual void testKSQLEmitChanges() {
string sql = "SELECT * FROM table1 t1 GROUP BY region.id EMIT CHANGES";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.True(plainSelect.isEmitChanges(), null);
}

public virtual void testKSQLEmitChangesWithLimit() {
string sql = "SELECT * FROM table1 t1 GROUP BY region.id EMIT CHANGES LIMIT 2";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect plainSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true)!);
global::DripSharp.Testing.JavaAssertions.True(plainSelect.isEmitChanges(), null);
}

[Xunit.Fact]
public void __Upstream_5ae848eec8b78926()
{
        try
        {
            this.testKSQLBeforeAfterWindowedJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d2f7ccab5cfc15fb()
{
        try
        {
            this.testKSQLEmitChanges();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cc3657b823465e55()
{
        try
        {
            this.testKSQLEmitChangesWithLimit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0fef12a4e6ab9ccd()
{
        try
        {
            this.testKSQLHoppingWindows();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8c3bb7c05de13c66()
{
        try
        {
            this.testKSQLSessionWindows();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_62842d4e6bb4c77b()
{
        try
        {
            this.testKSQLTumblingWindows();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5cff2c88700de28d()
{
        try
        {
            this.testKSQLWindowedJoin();
        }
        finally
        {
        }
}
}
