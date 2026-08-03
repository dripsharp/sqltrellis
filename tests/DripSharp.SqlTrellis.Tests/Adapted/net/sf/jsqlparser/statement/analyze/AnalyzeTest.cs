// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Analyze;

public class AnalyzeTest {
private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testAnalyze() {
string statement = "ANALYZE mytab";
global::DripSharp.SqlTrellis.Statement.Analyze.Analyze parsed = (global::DripSharp.SqlTrellis.Statement.Analyze.Analyze)(this.parserManager.parse(new global::System.IO.StringReader(statement))!);
global::DripSharp.Testing.JavaAssertions.Equal("mytab", parsed.getTable().getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(statement, global::DripSharp.Runtime.JavaCompat.Concat("", parsed), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Analyze.Analyze().withTable(new global::DripSharp.SqlTrellis.Schema.Table("mytab")), statement);
}

public virtual void testAnalyze2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ANALYZE mytable");
}

[Xunit.Fact]
public void __Upstream_f005a3b0354ae315()
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
public void __Upstream_6ada3d2cbd29ac8e()
{
        try
        {
            this.testAnalyze2();
        }
        finally
        {
        }
}
}
