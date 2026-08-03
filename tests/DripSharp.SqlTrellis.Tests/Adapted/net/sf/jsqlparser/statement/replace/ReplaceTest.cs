// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Replace;

public class ReplaceTest {
public virtual void testReplaceSyntax1() {
string statement = "REPLACE mytable SET col1='as', col2=?, col3=565";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert upsert = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", upsert.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(upsert.getUpdateSets()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getUpdateSets(), 0).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getUpdateSets(), 1).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getUpdateSets(), 2).getColumns(), 0).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'as'", global::DripSharp.Runtime.JavaCompat.StringValueOf(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getUpdateSets(), 0).getValues(), 0)), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getUpdateSets(), 1).getValues(), 0) is global::DripSharp.SqlTrellis.Expression.JdbcParameter), null);
global::DripSharp.Testing.JavaAssertions.Equal(565L, (global::DripSharp.Runtime.JavaCompat.CastReference<global::DripSharp.SqlTrellis.Expression.LongValue>(global::DripSharp.Runtime.JavaCompat.ListGet(global::DripSharp.Runtime.JavaCompat.ListGet(upsert.getUpdateSets(), 2).getValues(), 0))).getValue(), null);
}

public virtual void testReplaceSyntax2() {
string statement = "REPLACE mytable (col1, col2, col3) VALUES ('as', ?, 565)";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert replace = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", replace.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(replace.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(replace.getColumns(), 0)!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(replace.getColumns(), 1)!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(replace.getColumns(), 2)!)).getColumnName(), null);
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> expressions = (global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>)(((global::DripSharp.SqlTrellis.Statement.Select.Values)(replace.getSelect()!)).getExpressions()!);
global::DripSharp.Testing.JavaAssertions.Equal("as", ((global::DripSharp.SqlTrellis.Expression.StringValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 0)!)).getValue(), null);
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 1) is global::DripSharp.SqlTrellis.Expression.JdbcParameter), null);
global::DripSharp.Testing.JavaAssertions.Equal((long)(565), ((global::DripSharp.SqlTrellis.Expression.LongValue)(global::DripSharp.Runtime.JavaCompat.ListGet(expressions, 2)!)).getValue(), null);
}

public virtual void testReplaceSyntax3() {
string statement = "REPLACE mytable (col1, col2, col3) SELECT * FROM mytable3";
global::DripSharp.SqlTrellis.Statement.Upsert.Upsert replace = (global::DripSharp.SqlTrellis.Statement.Upsert.Upsert)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true)!);
global::DripSharp.Testing.JavaAssertions.Equal("mytable", replace.getTable().getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(replace.getColumns()), null);
global::DripSharp.Testing.JavaAssertions.Equal("col1", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(replace.getColumns(), 0)!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col2", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(replace.getColumns(), 1)!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("col3", ((global::DripSharp.SqlTrellis.Schema.Column)(global::DripSharp.Runtime.JavaCompat.ListGet(replace.getColumns(), 2)!)).getColumnName(), null);
global::DripSharp.Testing.JavaAssertions.NotNull(replace.getSelect(), null);
}

public virtual void testProblemReplaceParseDeparse() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("REPLACE a_table (ID, A, B) SELECT A_ID, A, B FROM b_table", true);
}

public virtual void testProblemMissingIntoIssue389() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("REPLACE INTO mytable (key, data) VALUES (1, \"aaa\")", true);
}

public virtual void testMultipleValues() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("REPLACE INTO mytable (col1, col2, col3) VALUES (1, \"aaa\", now()), (2, \"bbb\", now())", true);
}

[Xunit.Fact]
public void __Upstream_a01e7d6cc996c5c2()
{
        try
        {
            this.testMultipleValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d8ab94403d52c372()
{
        try
        {
            this.testProblemMissingIntoIssue389();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e751c41cda90828()
{
        try
        {
            this.testProblemReplaceParseDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2ff976d1a8bbaadb()
{
        try
        {
            this.testReplaceSyntax1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec0ba209e7636615()
{
        try
        {
            this.testReplaceSyntax2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f8d58e3a44fbd230()
{
        try
        {
            this.testReplaceSyntax3();
        }
        finally
        {
        }
}
}
