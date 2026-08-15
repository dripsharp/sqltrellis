// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Test;

public class TestUtils {
private static readonly global::System.Text.RegularExpressions.Regex SQL_COMMENT_PATTERN = global::DripSharp.Runtime.JavaCompat.CompileRegex("(--.*$)|(/\\*.*?\\*/)", 8);

private static readonly global::System.Text.RegularExpressions.Regex SQL_SANITATION_PATTERN = global::DripSharp.Runtime.JavaCompat.CompileRegex("(\\s+)", 8);

private static readonly global::System.Text.RegularExpressions.Regex SQL_SANITATION_PATTERN2 = global::DripSharp.Runtime.JavaCompat.CompileRegex("\\s*([!/,()=+\\-*|\\]<>:\\[\\]\\{\\}])\\s*", 8);

public static global::DripSharp.SqlTrellis.Statement.Statement assertSqlCanBeParsedAndDeparsed(string statement) {
return global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
}

public static global::DripSharp.SqlTrellis.Statement.Statement assertSqlCanBeParsedAndDeparsed(string statement, bool laxDeparsingCheck) {
return global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, laxDeparsingCheck, (global::System.Action<global::DripSharp.SqlTrellis.Parser.CCJSqlParser>)default!);
}

public static global::DripSharp.SqlTrellis.Statement.Statement assertSqlCanBeParsedAndDeparsed(string statement, bool laxDeparsingCheck, global::System.Action<global::DripSharp.SqlTrellis.Parser.CCJSqlParser> consumer) {
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(statement, consumer);
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, laxDeparsingCheck);
return parsed;
}

public static void assertStatementCanBeDeparsedAs(global::DripSharp.SqlTrellis.Statement.Statement parsed, string statement) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(parsed, statement, false);
}

public static void assertStatementCanBeDeparsedAs(global::DripSharp.SqlTrellis.Statement.Statement parsed, string statement, bool laxDeparsingCheck) {
string sanitizedInputSqlStr = global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(global::DripSharp.Runtime.JavaCompat.StringValueOf(parsed), laxDeparsingCheck);
string sanitizedStatementStr = global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(statement, laxDeparsingCheck);
global::DripSharp.Testing.JavaAssertions.Equal(sanitizedStatementStr, sanitizedInputSqlStr, "Output from toString() does not match.");
bool exportToFile = global::DripSharp.Runtime.JavaCompat.ParseBoolean(global::DripSharp.Runtime.JavaCompat.Getenv("EXPORT_TEST_TO_FILE"));
if (exportToFile) {
global::DripSharp.SqlTrellis.Test.TestUtils.writeTestToFile(sanitizedInputSqlStr);
}
global::System.Text.StringBuilder builder = new global::System.Text.StringBuilder();
((global::DripSharp.SqlTrellis.Statement.Statement)(parsed)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<global::System.Text.StringBuilder>)(new global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser(builder)));
string sanitizedDeparsedStr = global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(builder.ToString(), laxDeparsingCheck);
global::DripSharp.Testing.JavaAssertions.Equal(sanitizedStatementStr, sanitizedDeparsedStr, "Output from Deparser does not match.");
}

private static void writeTestToFile(string sanitizedInputSqlStr) {
global::DripSharp.SqlTrellis.Tests.JavaStackTraceElement[] stackTrace = global::DripSharp.SqlTrellis.Tests.Support.CurrentStackTrace();
string testMethodName;
string testClassName;
int i = 1;
do {
testMethodName = global::DripSharp.SqlTrellis.Tests.Support.StackMethodName(stackTrace[i]);
testClassName = global::DripSharp.SqlTrellis.Tests.Support.StackClassName(stackTrace[i]);
i++;
} while ((global::DripSharp.Runtime.JavaCompat.Equals(testMethodName, "writeTestToFile") || global::DripSharp.Runtime.JavaCompat.StringStartsWith(testMethodName, "assert")));
if (!(global::DripSharp.Runtime.JavaCompat.Equals(testMethodName, "testRelObjectNameExt"))) {
int classNameSeparator = testClassName.LastIndexOf(".", global::System.StringComparison.Ordinal);
string simpleClassName = testClassName.Substring((classNameSeparator + 1));
string packageName = global::DripSharp.Runtime.JavaCompat.ReplaceOrdinal(global::DripSharp.Runtime.JavaCompat.StringSubstring(testClassName, 0, classNameSeparator), ".", global::DripSharp.SqlTrellis.Tests.Support.JavaSystemProperty("file.separator"));
global::System.IO.FileInfo file = global::DripSharp.SqlTrellis.Tests.Support.TestFile(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.SqlTrellis.Tests.Support.JavaSystemProperty("java.io.tmpdir"), global::DripSharp.SqlTrellis.Tests.Support.JavaSystemProperty("file.separator")), packageName));
global::DripSharp.SqlTrellis.Tests.Support.JavaMkdirs(file);
file = new global::System.IO.FileInfo(global::System.IO.Path.Combine(file.FullName, global::DripSharp.Runtime.JavaCompat.Concat(simpleClassName, ".sql")));
try {
using (global::System.IO.StreamWriter fileWriter = new global::System.IO.StreamWriter(file.FullName, true)) {
global::DripSharp.SqlTrellis.Tests.Support.WriteText(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- ", testMethodName), "\n"), fileWriter);
global::DripSharp.SqlTrellis.Tests.Support.WriteText(sanitizedInputSqlStr, fileWriter);
if (!(global::DripSharp.Runtime.JavaCompat.StringEndsWith(global::DripSharp.Runtime.JavaCompat.StringTrim(sanitizedInputSqlStr), ";"))) {
global::DripSharp.SqlTrellis.Tests.Support.WriteText("\n;", fileWriter);
}
global::DripSharp.SqlTrellis.Tests.Support.WriteText("\n\n", fileWriter);
}
} catch (global::System.IO.IOException ex) {
global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Test.TestUtils).FullName ?? typeof(global::DripSharp.SqlTrellis.Test.TestUtils).Name)).Log(global::DripSharp.Runtime.JavaLogLevel.Severe, "Writing SQL to file failed.", ex);
}
}
}

public static void assertDeparse(global::DripSharp.SqlTrellis.Statement.Statement stmt, string statement) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(stmt, statement, false);
}

public static void assertEqualsObjectTree(global::DripSharp.SqlTrellis.Statement.Statement parsed, global::DripSharp.SqlTrellis.Statement.Statement created) {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Test.TestUtils.toReflectionString(parsed), global::DripSharp.SqlTrellis.Test.TestUtils.toReflectionString(created), null);
}

public static string toReflectionString(global::DripSharp.SqlTrellis.Statement.Statement stmt) {
return global::DripSharp.SqlTrellis.Test.TestUtils.toReflectionString(stmt, false);
}

public static string toReflectionString(global::DripSharp.SqlTrellis.Statement.Statement stmt, bool includingASTNode) => global::DripSharp.SqlTrellis.Tests.Support.ReflectionToString(stmt, includingASTNode);

public static global::System.Collections.Generic.IList<T> asList<T>(params T[] obj) {
return new global::System.Collections.Generic.List<T>(global::DripSharp.Runtime.JavaCompat.Stream(global::DripSharp.Runtime.JavaCompat.StreamOf(obj)));
}

private sealed class ObjectTreeToStringStyle
{
    public static readonly ObjectTreeToStringStyle Instance = new(false);
    public static readonly ObjectTreeToStringStyle InstanceIncludingAst = new(true);
    private readonly bool includingAstNode;
    private ObjectTreeToStringStyle(bool includingAstNode) => this.includingAstNode = includingAstNode;
    public bool IsNotANode(global::System.Type clazz) => !typeof(global::DripSharp.SqlTrellis.Parser.Node).IsAssignableFrom(clazz);
    public bool IncludingAstNode => includingAstNode;
}

public static void assertDeparse(global::DripSharp.SqlTrellis.Statement.Statement stmt, string statement, bool laxDeparsingCheck) {
global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser deParser = new global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser(new global::System.Text.StringBuilder());
((global::DripSharp.SqlTrellis.Statement.Statement)(stmt)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<global::System.Text.StringBuilder>)(deParser));
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(statement, laxDeparsingCheck), global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(deParser.getBuilder().ToString(), laxDeparsingCheck), null);
}

public static string buildSqlString(string originalSql, bool laxDeparsingCheck) {
if (laxDeparsingCheck) {
string sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.RegexMatcher(global::DripSharp.SqlTrellis.Test.TestUtils.SQL_COMMENT_PATTERN, originalSql).ReplaceAll("");
sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.RegexMatcher(global::DripSharp.SqlTrellis.Test.TestUtils.SQL_SANITATION_PATTERN, sanitizedSqlStr).ReplaceAll(" ");
sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.RegexMatcher(global::DripSharp.SqlTrellis.Test.TestUtils.SQL_SANITATION_PATTERN2, sanitizedSqlStr).ReplaceAll("$1");
sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.StringTrim(sanitizedSqlStr).ToLowerInvariant();
if ((laxDeparsingCheck && global::DripSharp.Runtime.JavaCompat.StringEndsWith(sanitizedSqlStr, ";"))) {
sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.StringTrim(global::DripSharp.Runtime.JavaCompat.StringSubstring(sanitizedSqlStr, 0, (sanitizedSqlStr.Length - 1)));
}
if (global::DripSharp.Runtime.JavaCompat.StringEndsWith(sanitizedSqlStr, "/")) {
sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.StringSubstring(sanitizedSqlStr, 0, (sanitizedSqlStr.Length - 1));
} else {
if (global::DripSharp.Runtime.JavaCompat.StringEndsWith(sanitizedSqlStr, "go")) {
sanitizedSqlStr = global::DripSharp.Runtime.JavaCompat.StringSubstring(sanitizedSqlStr, 0, (sanitizedSqlStr.Length - 2));
}
}
return sanitizedSqlStr;
} else {
return global::DripSharp.Runtime.JavaCompat.RegexMatcher(global::DripSharp.SqlTrellis.Test.TestUtils.SQL_COMMENT_PATTERN, originalSql).ReplaceAll("");
}
}

public virtual void testBuildSqlString() {
global::DripSharp.Testing.JavaAssertions.Equal("select col from test", global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString("   SELECT   col FROM  \r\n \t  TEST \n", true), null);
global::DripSharp.Testing.JavaAssertions.Equal("select  col  from test", global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString("select  col  from test", false), null);
}

public static void assertExpressionCanBeDeparsedAs(global::DripSharp.SqlTrellis.Expression.Expression parsed, string expression) {
global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser();
global::System.Text.StringBuilder stringBuilder = new global::System.Text.StringBuilder();
expressionDeParser.setBuilder(stringBuilder);
global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser selectDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser(expressionDeParser, stringBuilder);
expressionDeParser.setSelectVisitor(selectDeParser);
parsed.accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal(expression, stringBuilder.ToString(), null);
}

public static void assertExpressionCanBeParsedAndDeparsed(string expressionStr, bool laxDeparsingCheck) {
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression(expressionStr);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(expressionStr, laxDeparsingCheck), global::DripSharp.SqlTrellis.Test.TestUtils.buildSqlString(global::DripSharp.Runtime.JavaCompat.StringValueOf(expression), laxDeparsingCheck), null);
}

public static void assertOracleHintExists(string sql, bool assertDeparser, params string[] hints) {
if (assertDeparser) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
if ((statement is global::DripSharp.SqlTrellis.Statement.Select.Select)) {
global::DripSharp.SqlTrellis.Statement.Select.Select stmt__385_20 = (global::DripSharp.SqlTrellis.Statement.Select.Select)(statement!);
if ((stmt__385_20 is global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)) {
global::DripSharp.SqlTrellis.Expression.OracleHint hint__387_28 = global::DripSharp.SqlTrellis.Expression.OracleHint.getHintFromSelectBody(stmt__385_20);
global::DripSharp.Testing.JavaAssertions.NotNull(hint__387_28, null);
global::DripSharp.Testing.JavaAssertions.Equal(hints[0], hint__387_28.getValue(), null);
} else {
if ((stmt__385_20 is global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)) {
global::DripSharp.SqlTrellis.Statement.Select.SetOperationList setOperationList = (global::DripSharp.SqlTrellis.Statement.Select.SetOperationList)(stmt__385_20!);
for (int i = 0; (i < global::DripSharp.Runtime.JavaCompat.CollectionCount(setOperationList.getSelects())); i++) {
global::DripSharp.SqlTrellis.Expression.OracleHint hint__393_32 = global::DripSharp.SqlTrellis.Expression.OracleHint.getHintFromSelectBody(global::DripSharp.Runtime.JavaCompat.ListGet(setOperationList.getSelects(), i));
if ((hints[i] == default!)) {
global::DripSharp.Testing.JavaAssertions.Null(hint__393_32, null);
} else {
global::DripSharp.Testing.JavaAssertions.NotNull(hint__393_32, null);
global::DripSharp.Testing.JavaAssertions.Equal(hints[i], hint__393_32.getValue(), null);
}
}
}
}
} else {
if ((statement is global::DripSharp.SqlTrellis.Statement.Update.Update)) {
global::DripSharp.SqlTrellis.Statement.Update.Update stmt__404_20 = (global::DripSharp.SqlTrellis.Statement.Update.Update)(statement!);
global::DripSharp.SqlTrellis.Expression.OracleHint hint__405_24 = stmt__404_20.getOracleHint();
global::DripSharp.Testing.JavaAssertions.NotNull(hint__405_24, null);
global::DripSharp.Testing.JavaAssertions.Equal(hints[0], hint__405_24.getValue(), null);
} else {
if ((statement is global::DripSharp.SqlTrellis.Statement.Insert.Insert)) {
global::DripSharp.SqlTrellis.Statement.Insert.Insert stmt__409_20 = (global::DripSharp.SqlTrellis.Statement.Insert.Insert)(statement!);
global::DripSharp.SqlTrellis.Expression.OracleHint hint__410_24 = stmt__409_20.getOracleHint();
global::DripSharp.Testing.JavaAssertions.NotNull(hint__410_24, null);
global::DripSharp.Testing.JavaAssertions.Equal(hints[0], hint__410_24.getValue(), null);
} else {
if ((statement is global::DripSharp.SqlTrellis.Statement.Delete.Delete)) {
global::DripSharp.SqlTrellis.Statement.Delete.Delete stmt__414_20 = (global::DripSharp.SqlTrellis.Statement.Delete.Delete)(statement!);
global::DripSharp.SqlTrellis.Expression.OracleHint hint__415_24 = stmt__414_20.getOracleHint();
global::DripSharp.Testing.JavaAssertions.NotNull(hint__415_24, null);
global::DripSharp.Testing.JavaAssertions.Equal(hints[0], hint__415_24.getValue(), null);
}
}
}
}
}

public static void assertUpdateMysqlHintExists(string sql, bool assertDeparser, string action, string qualifier, params string[] indexNames) {
if (assertDeparser) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Update.Update>(statement, null);
global::DripSharp.SqlTrellis.Statement.Update.Update updateStmt = (global::DripSharp.SqlTrellis.Statement.Update.Update)(statement!);
global::DripSharp.SqlTrellis.Expression.MySQLIndexHint indexHint = updateStmt.getTable().getIndexHint();
global::DripSharp.Testing.JavaAssertions.NotNull(indexHint, null);
global::DripSharp.Testing.JavaAssertions.Equal(indexHint.getAction(), action, null);
global::DripSharp.Testing.JavaAssertions.Equal(indexHint.getIndexQualifier(), qualifier, null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.ToObjectArray(indexHint.getIndexNames()), indexNames, null);
}

[Xunit.Fact]
public void __Upstream_0acbeee8da24fbb4()
{
        try
        {
            this.testBuildSqlString();
        }
        finally
        {
        }
}
}
