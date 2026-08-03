// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ConditionalKeywordsTest {
public static readonly global::DripSharp.Runtime.JavaLogger LOGGER = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Statement.ConditionalKeywordsTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Statement.ConditionalKeywordsTest).Name));

public static global::DripSharp.Runtime.JavaStream<string> keyWords() {
global::System.IO.FileInfo file = global::DripSharp.SqlTrellis.Tests.Support.TestFile("src/main/jjtree/net/sf/jsqlparser/parser/JSqlParserCC.jjt");
global::System.Collections.Generic.IList<string> keywords = new global::System.Collections.Generic.List<string>();
try {
try {
global::DripSharp.Runtime.JavaCompat.AddAll(keywords, global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.getAllKeywordsUsingRegex(file));
foreach (string reserved in global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.getReservedKeywords((global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.RESTRICTED_JSQLPARSER | global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.RESTRICTED_ALIAS))) {
global::DripSharp.Runtime.JavaCompat.CollectionRemove(keywords, reserved);
}
} catch (global::System.Exception ex) when (ex is not global::System.TypeInitializationException) {
(global::DripSharp.SqlTrellis.Statement.ConditionalKeywordsTest.LOGGER).Log(global::DripSharp.Runtime.JavaLogLevel.Severe, "Failed to generate the Keyword List", ex);
}
} catch (global::System.Exception ex) when (ex is not global::System.TypeInitializationException) {
(global::DripSharp.SqlTrellis.Statement.ConditionalKeywordsTest.LOGGER).Log(global::DripSharp.Runtime.JavaLogLevel.Severe, "Failed to generate the Keyword List", ex);
}
return global::DripSharp.Runtime.JavaCompat.Stream(keywords);
}

public virtual void testRelObjectNameExt(string keyword) {
string sqlStr = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("SELECT %1$s.%1$s.%1$s \"%1$s\" from %1$s \"%1$s\" ORDER BY %1$s ", keyword);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_31518671df7b8934()
{
    foreach (var value in keyWords())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<string>(row[0]) };
    }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_31518671df7b8934")]
public void __Upstream_4931d38beba96cc6(string keyword)
{
        try
        {
            this.testRelObjectNameExt(keyword);
        }
        finally
        {
        }
}
}
