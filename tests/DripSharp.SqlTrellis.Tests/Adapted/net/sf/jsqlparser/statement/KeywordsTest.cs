// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class KeywordsTest {
public static readonly global::DripSharp.Runtime.JavaLogger LOGGER = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Statement.KeywordsTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Statement.KeywordsTest).Name));

public static global::DripSharp.Runtime.JavaStream<string> keyWords() {
global::System.IO.FileInfo file = global::DripSharp.SqlTrellis.Tests.Support.TestFile("src/main/jjtree/net/sf/jsqlparser/parser/JSqlParserCC.jjt");
global::System.Collections.Generic.IList<string> keywords = new global::System.Collections.Generic.List<string>();
try {
global::DripSharp.Runtime.JavaCompat.AddAll(keywords, global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.getAllKeywordsUsingRegex(file));
foreach (string reserved in global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.getReservedKeywords(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.RESTRICTED_JSQLPARSER)) {
global::DripSharp.Runtime.JavaCompat.CollectionRemove(keywords, reserved);
}
} catch (global::System.Exception ex) when (ex is not global::System.TypeInitializationException) {
(global::DripSharp.SqlTrellis.Statement.KeywordsTest.LOGGER).Log(global::DripSharp.Runtime.JavaLogLevel.Severe, "Failed to generate the Keyword List", ex);
}
return global::DripSharp.Runtime.JavaCompat.Stream(keywords);
}

public virtual void testRelObjectNameWithoutValue(string keyword) {
string sqlStr = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("SELECT %1$s.%1$s AS %1$s from %1$s.%1$s AS %1$s", keyword);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testCombinedTokenKeywords() {
string sqlStr = "SELECT current_date(3)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_674407be1d0cca97()
{
    foreach (var value in keyWords())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<string>(row[0]) };
    }
}

[Xunit.Fact]
public void __Upstream_733ece8cfcf4685c()
{
        try
        {
            this.testCombinedTokenKeywords();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_674407be1d0cca97")]
public void __Upstream_d54f08e50ecbbc4e(string keyword)
{
        try
        {
            this.testRelObjectNameWithoutValue(keyword);
        }
        finally
        {
        }
}
}
