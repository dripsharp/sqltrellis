// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser;

public class ParserKeywordsUtilsTest {
public static readonly global::System.Text.Encoding CHARSET_ENCODER = global::DripSharp.Runtime.JavaStandardCharsets.USASCII;

internal static readonly global::System.IO.FileInfo FILE = global::DripSharp.SqlTrellis.Tests.Support.TestFile("src/main/jjtree/net/sf/jsqlparser/parser/JSqlParserCC.jjt");

internal static readonly global::DripSharp.Runtime.JavaLogger LOGGER = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest).Name));

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcRStringLiteral literal) {
if ((global::DripSharp.Runtime.JavaCompat.CharsetCanEncode(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.CHARSET_ENCODER, literal.Image) && global::DripSharp.Runtime.JavaCompat.StringMatches(literal.Image, "\\w+"))) {
allKeywords.Add(literal.Image);
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, object o) {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRStringLiteral)) {
global::DripSharp.SqlTrellis.Tests.JavaCcRStringLiteral literal = (global::DripSharp.SqlTrellis.Tests.JavaCcRStringLiteral)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, literal);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRChoice)) {
global::DripSharp.SqlTrellis.Tests.JavaCcRChoice choice = (global::DripSharp.SqlTrellis.Tests.JavaCcRChoice)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, choice);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRSequence)) {
global::DripSharp.SqlTrellis.Tests.JavaCcRSequence sequence1 = (global::DripSharp.SqlTrellis.Tests.JavaCcRSequence)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, sequence1);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcROneOrMore)) {
global::DripSharp.SqlTrellis.Tests.JavaCcROneOrMore oneOrMore = (global::DripSharp.SqlTrellis.Tests.JavaCcROneOrMore)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, oneOrMore);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrMore)) {
global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrMore zeroOrMore = (global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrMore)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, zeroOrMore);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrOne)) {
global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrOne zeroOrOne__78_24 = (global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrOne)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, zeroOrOne__78_24);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRJustName)) {
global::DripSharp.SqlTrellis.Tests.JavaCcRJustName zeroOrOne__81_23 = (global::DripSharp.SqlTrellis.Tests.JavaCcRJustName)(o!);
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, zeroOrOne__81_23);
} else {
if ((o is global::DripSharp.SqlTrellis.Tests.JavaCcRCharacterList)) {} else {
throw new global::System.Runtime.Serialization.SerializationException(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("Unknown Type: ", (((object)(o)).GetType().FullName ?? ((object)(o)).GetType().Name)), " "), global::DripSharp.Runtime.JavaCompat.StringValueOf(o)));
}
}
}
}
}
}
}
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcRSequence sequence) {
foreach (object o in sequence.Units) {
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, o);
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcROneOrMore oneOrMore) {
foreach (global::DripSharp.SqlTrellis.Tests.JavaCcToken token in oneOrMore.LhsTokens) {
if (global::DripSharp.Runtime.JavaCompat.CharsetCanEncode(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.CHARSET_ENCODER, token.Image)) {
allKeywords.Add(token.Image);
}
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrMore oneOrMore) {
foreach (global::DripSharp.SqlTrellis.Tests.JavaCcToken token in oneOrMore.LhsTokens) {
if (global::DripSharp.Runtime.JavaCompat.CharsetCanEncode(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.CHARSET_ENCODER, token.Image)) {
allKeywords.Add(token.Image);
}
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcRZeroOrOne oneOrMore) {
foreach (global::DripSharp.SqlTrellis.Tests.JavaCcToken token in oneOrMore.LhsTokens) {
if (global::DripSharp.Runtime.JavaCompat.CharsetCanEncode(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.CHARSET_ENCODER, token.Image)) {
allKeywords.Add(token.Image);
}
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcRJustName oneOrMore) {
foreach (global::DripSharp.SqlTrellis.Tests.JavaCcToken token in oneOrMore.LhsTokens) {
if (global::DripSharp.Runtime.JavaCompat.CharsetCanEncode(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.CHARSET_ENCODER, token.Image)) {
allKeywords.Add(token.Image);
}
}
}

private static void addTokenImage(global::System.Collections.Generic.SortedSet<string> allKeywords, global::DripSharp.SqlTrellis.Tests.JavaCcRChoice choice) {
foreach (object o in choice.GetChoices()) {
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, o);
}
}

public static global::System.Collections.Generic.SortedSet<string> getAllKeywordsUsingJavaCC(global::System.IO.FileInfo file) {
global::System.Collections.Generic.SortedSet<string> allKeywords = global::DripSharp.Runtime.JavaCompat.NewSortedSet<string>();
global::DripSharp.Runtime.JavaPath jjtGrammar = new global::DripSharp.Runtime.JavaPath(file.FullName);
global::DripSharp.Runtime.JavaPath jjGrammarOutputDir = global::DripSharp.Runtime.JavaCompat.createTempDirectory("jjgrammer");
new global::DripSharp.SqlTrellis.Tests.JavaCcJjTree().Main(new string[] { "-JDK_VERSION=1.8", global::DripSharp.Runtime.JavaCompat.Concat("-OUTPUT_DIRECTORY=", jjGrammarOutputDir.ToString()!), jjtGrammar.ToString()! });
global::DripSharp.Runtime.JavaPath jjGrammarFile = global::DripSharp.Runtime.JavaCompat.PathResolve(jjGrammarOutputDir, "JSqlParserCC.jj");
global::DripSharp.SqlTrellis.Tests.JavaCcParser parser = new global::DripSharp.SqlTrellis.Tests.JavaCcParser(global::DripSharp.Runtime.JavaCompat.OpenFileInput(new global::System.IO.FileInfo(jjGrammarFile)));
parser.JavaccInput();
global::DripSharp.SqlTrellis.Tests.JavaCcErrors.ReInit();
global::DripSharp.SqlTrellis.Tests.JavaCcSemanticize.Start();
foreach (global::DripSharp.Runtime.JavaMapEntry<int, global::DripSharp.SqlTrellis.Tests.JavaCcRegularExpression> item in global::DripSharp.Runtime.JavaCompat.MapEntrySet(global::DripSharp.SqlTrellis.Tests.JavaCcGlobals.RexpsOfTokens)) {
global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.addTokenImage(allKeywords, item.Value);
}
if (global::DripSharp.Runtime.JavaCompat.FileExists(new global::System.IO.FileInfo(jjGrammarOutputDir))) {
global::DripSharp.Runtime.JavaCompat.FileDelete(new global::System.IO.FileInfo(jjGrammarOutputDir));
}
return allKeywords;
}

internal virtual void getAllKeywords() {
global::System.Collections.Generic.ISet<string> allKeywords = global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.getAllKeywordsUsingRegex(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.FILE);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.CollectionIsEmpty(allKeywords), "Keyword List must not be empty!");
}

internal virtual void getAllKeywordsUsingJavaCC() {
global::System.Collections.Generic.ISet<string> allKeywords = global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.getAllKeywordsUsingJavaCC(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.FILE);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.CollectionIsEmpty(allKeywords), "Keyword List must not be empty!");
}

internal virtual void compareKeywordLists() {
global::System.Collections.Generic.ISet<string> allRegexKeywords = global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtils.getAllKeywordsUsingRegex(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.FILE);
global::System.Collections.Generic.ISet<string> allJavaCCParserKeywords = global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.getAllKeywordsUsingJavaCC(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.FILE);
global::System.Collections.Generic.IList<string> exceptions = global::DripSharp.Runtime.JavaCompat.AsList<string>("0x");
foreach (string s__193_21 in allRegexKeywords) {
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.CollectionContains(exceptions, s__193_21) || global::DripSharp.Runtime.JavaCompat.CollectionContains(allJavaCCParserKeywords, s__193_21)), global::DripSharp.Runtime.JavaCompat.Concat("The Keywords from JavaCC do not contain Keyword: ", s__193_21));
}
foreach (string s__201_21 in allJavaCCParserKeywords) {
if (!((global::DripSharp.Runtime.JavaCompat.CollectionContains(exceptions, s__201_21) || global::DripSharp.Runtime.JavaCompat.CollectionContains(allRegexKeywords, s__201_21)))) {
(global::DripSharp.SqlTrellis.Parser.ParserKeywordsUtilsTest.LOGGER).Fine(global::DripSharp.Runtime.JavaCompat.Concat("Found Additional Keywords from Parser: ", s__201_21));
}
}
}

internal virtual void testBase64() {
string sqlStr = "SELECT base64('Spark SQL') AS b;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_c146e7fa3558f1c1()
{
        try
        {
            this.compareKeywordLists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_10a9570d74f705d0()
{
        try
        {
            this.getAllKeywords();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_afc3b7ec5b26dfc8()
{
        try
        {
            this.getAllKeywordsUsingJavaCC();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e69f12f6e675c726()
{
        try
        {
            this.testBase64();
        }
        finally
        {
        }
}
}
