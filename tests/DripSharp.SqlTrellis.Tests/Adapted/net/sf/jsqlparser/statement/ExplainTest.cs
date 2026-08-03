// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ExplainTest {
public virtual void testDescribe() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN SELECT * FROM mytable");
}

public virtual void testAnalyze() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN ANALYZE SELECT * FROM mytable");
}

public virtual void testBuffers() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN BUFFERS SELECT * FROM mytable");
}

public virtual void testCosts() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN COSTS SELECT * FROM mytable");
}

public virtual void testFormat() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN FORMAT XML SELECT * FROM mytable");
}

public virtual void testVerbose() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN VERBOSE SELECT * FROM mytable");
}

public virtual void testMultiOptions_orderPreserved() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN VERBOSE ANALYZE BUFFERS COSTS SELECT * FROM mytable");
}

public virtual void getOption_returnsValues() {
global::DripSharp.SqlTrellis.Statement.ExplainStatement explain = (global::DripSharp.SqlTrellis.Statement.ExplainStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("EXPLAIN VERBOSE FORMAT JSON BUFFERS FALSE SELECT * FROM mytable")!);
global::DripSharp.Testing.JavaAssertJ.That(explain.getOption(global::DripSharp.SqlTrellis.Statement.ExplainStatement.OptionType.ANALYZE)).IsNull();
global::DripSharp.Testing.JavaAssertJ.That(explain.getOption(global::DripSharp.SqlTrellis.Statement.ExplainStatement.OptionType.VERBOSE)).IsNotNull();
global::DripSharp.SqlTrellis.Statement.ExplainStatement.Option format = explain.getOption(global::DripSharp.SqlTrellis.Statement.ExplainStatement.OptionType.FORMAT);
global::DripSharp.Testing.JavaAssertJ.That(format).IsNotNull().Extracting(((global::System.Func<global::DripSharp.SqlTrellis.Statement.ExplainStatement.Option, object>)((value0) => value0.getValue()))).IsEqualTo("JSON");
global::DripSharp.SqlTrellis.Statement.ExplainStatement.Option buffers = explain.getOption(global::DripSharp.SqlTrellis.Statement.ExplainStatement.OptionType.BUFFERS);
global::DripSharp.Testing.JavaAssertJ.That(buffers).IsNotNull().Extracting(((global::System.Func<global::DripSharp.SqlTrellis.Statement.ExplainStatement.Option, object>)((value0) => value0.getValue()))).IsEqualTo("FALSE");
explain = (global::DripSharp.SqlTrellis.Statement.ExplainStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("EXPLAIN SELECT * FROM mytable")!);
global::DripSharp.Testing.JavaAssertJ.That(explain.getOption(global::DripSharp.SqlTrellis.Statement.ExplainStatement.OptionType.ANALYZE)).IsNull();
}

[Xunit.Fact]
public void __Upstream_4cd6d6d54b30d7b6()
{
        try
        {
            this.getOption_returnsValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f2c89e8f0165a2c1()
{
        try
        {
            this.testAnalyze();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d7aec8573af89cc6()
{
        try
        {
            this.testBuffers();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f4263ef8774d2a7e()
{
        try
        {
            this.testCosts();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_16eb494c21d43c27()
{
        try
        {
            this.testDescribe();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_60e38eecc2ffdc37()
{
        try
        {
            this.testFormat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b66aa4cfdb8a59a5()
{
        try
        {
            this.testMultiOptions_orderPreserved();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a662cbd137f5a9a4()
{
        try
        {
            this.testVerbose();
        }
        finally
        {
        }
}
}
