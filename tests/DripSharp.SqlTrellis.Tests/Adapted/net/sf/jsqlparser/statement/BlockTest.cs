// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class BlockTest {
public virtual void testGetStatements() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("begin\n", "select * from feature;\n"), "end;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testBlock2() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("begin\n", "update table1 set a = 'xx' where b = 'condition1';\n"), "update table1 set a = 'xx' where b = 'condition2';\n"), "end;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testBlock3() {
global::DripSharp.SqlTrellis.Statement.Statements stmts = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements("begin\nselect * from feature;\nend");
global::DripSharp.SqlTrellis.Statement.Block block = (global::DripSharp.SqlTrellis.Statement.Block)(global::DripSharp.Runtime.JavaCompat.ListGet(stmts.getStatements(), 0)!);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.ListIsEmpty(block.getStatements().getStatements()), null);
}

public virtual void testBlockToStringIsNullSafe() {
global::DripSharp.SqlTrellis.Statement.Block block = new global::DripSharp.SqlTrellis.Statement.Block();
block.setStatements((global::DripSharp.SqlTrellis.Statement.Statements)default!);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat("BEGIN\n", "END"), block.ToString(), null);
}

public virtual void testIfElseBlock() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("if (a=b) begin\n", "update table1 set a = 'xx' where b = 'condition1';\n"), "update table1 set a = 'xx' where b = 'condition2';\n"), "end");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
string sqlStr2 = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("if (a=b) begin\n", "update table1 set a = 'xx' where b = 'condition1';\n"), "update table1 set a = 'xx' where b = 'condition2';\n"), "end;\n"), "else begin\n"), "update table1 set a = 'xx' where b = 'condition1';\n"), "update table1 set a = 'xx' where b = 'condition2';\n"), "end;");
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr2);
foreach (global::DripSharp.SqlTrellis.Statement.Statement stm in statements.getStatements()) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(stm, sqlStr2, true);
}
}

[Xunit.Fact]
public void __Upstream_43c4beea7685aa03()
{
        try
        {
            this.testBlock2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c40b9ab03b321242()
{
        try
        {
            this.testBlock3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_29e611257b1ec9f0()
{
        try
        {
            this.testBlockToStringIsNullSafe();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1dace25a5b132427()
{
        try
        {
            this.testGetStatements();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3d6152e9f4bcaecb()
{
        try
        {
            this.testIfElseBlock();
        }
        finally
        {
        }
}
}
