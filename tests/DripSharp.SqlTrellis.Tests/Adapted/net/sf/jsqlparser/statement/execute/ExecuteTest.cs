// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Execute;

public class ExecuteTest {
public virtual void testAcceptExecute() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXECUTE myproc 'a', 2, 'b'");
}

public virtual void testAcceptExec() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXEC myproc 'a', 2, 'b'");
}

public virtual void testAcceptCall() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CALL myproc 'a', 2, 'b'");
}

public virtual void testCallWithMultiname() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CALL BAR.FOO");
}

public virtual void testAcceptCallWithParenthesis() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CALL myproc ('a', 2, 'b')");
}

public virtual void testAcceptExecNamesParameters() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXEC procedure @param");
}

public virtual void testAcceptExecNamesParameters2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXEC procedure @param = 1");
}

public virtual void testAcceptExecNamesParameters3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXEC procedure @param = 'foo'");
}

public virtual void testAcceptExecNamesParameters4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXEC procedure @param = 'foo', @param2 = 'foo2'");
}

[Xunit.Fact]
public void __Upstream_890c78b4f30afad1()
{
        try
        {
            this.testAcceptCall();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1afc7fc86ac12c38()
{
        try
        {
            this.testAcceptCallWithParenthesis();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c73bfa9788bacf3e()
{
        try
        {
            this.testAcceptExec();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_63e5ece2f2dc908a()
{
        try
        {
            this.testAcceptExecNamesParameters();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4b3ec92699486913()
{
        try
        {
            this.testAcceptExecNamesParameters2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7570e9ed07eee17a()
{
        try
        {
            this.testAcceptExecNamesParameters3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_577f50df51ceb723()
{
        try
        {
            this.testAcceptExecNamesParameters4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b616bb111e0ae4d2()
{
        try
        {
            this.testAcceptExecute();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_220f2a92b074ea8b()
{
        try
        {
            this.testCallWithMultiname();
        }
        finally
        {
        }
}
}
