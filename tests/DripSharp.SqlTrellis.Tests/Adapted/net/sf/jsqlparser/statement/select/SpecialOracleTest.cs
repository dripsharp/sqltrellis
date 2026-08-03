// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SpecialOracleTest {
private static readonly global::System.IO.FileInfo SQLS_DIR = (global::DripSharp.Runtime.JavaCompat.FileIsDirectory(global::DripSharp.SqlTrellis.Tests.Support.TestFile("target/test-classes/net/sf/jsqlparser/statement/select/oracle-tests")) ? global::DripSharp.SqlTrellis.Tests.Support.TestFile("target/test-classes/net/sf/jsqlparser/statement/select/oracle-tests") : global::DripSharp.SqlTrellis.Tests.Support.TestFile("build/resources/test/net/sf/jsqlparser/statement/select/oracle-tests"));

private static readonly global::System.IO.FileInfo SQL_SOURCE_DIR = global::DripSharp.SqlTrellis.Tests.Support.TestFile("src/test/resources/net/sf/jsqlparser/statement/select/oracle-tests");

private static readonly global::DripSharp.Runtime.JavaLogger LOG = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest).Name));

private readonly global::System.Collections.Generic.IList<string> EXPECTED_SUCCESSES = global::DripSharp.Runtime.JavaCompat.AsList<string>("aggregate01.sql", "analytic_query04.sql", "analytic_query05.sql", "analytic_query06.sql", "analytic_query08.sql", "analytic_query09.sql", "analytic_query10.sql", "bindvar01.sql", "bindvar02.sql", "bindvar05.sql", "case_when01.sql", "case_when02.sql", "case_when03.sql", "case_when04.sql", "case_when05.sql", "cast_multiset01.sql", "cast_multiset02.sql", "cast_multiset03.sql", "cast_multiset04.sql", "cast_multiset05.sql", "cast_multiset06.sql", "cast_multiset07.sql", "cast_multiset08.sql", "cast_multiset10.sql", "cast_multiset11.sql", "cast_multiset12.sql", "cast_multiset16.sql", "cast_multiset17.sql", "cast_multiset18.sql", "cast_multiset19.sql", "cast_multiset20.sql", "cast_multiset21.sql", "cast_multiset22.sql", "cast_multiset23.sql", "cast_multiset24.sql", "cast_multiset25.sql", "cast_multiset26.sql", "cast_multiset27.sql", "cast_multiset28.sql", "cast_multiset29.sql", "cast_multiset30.sql", "cast_multiset31.sql", "cast_multiset32.sql", "cast_multiset33.sql", "cast_multiset35.sql", "cast_multiset36.sql", "cast_multiset40.sql", "cast_multiset41.sql", "cast_multiset42.sql", "cast_multiset43.sql", "columns01.sql", "condition01.sql", "condition02.sql", "condition03.sql", "condition04.sql", "condition05.sql", "condition07.sql", "condition08.sql", "condition09.sql", "condition10.sql", "condition12.sql", "condition14.sql", "condition15.sql", "condition19.sql", "condition20.sql", "connect_by01.sql", "connect_by02.sql", "connect_by03.sql", "connect_by04.sql", "connect_by05.sql", "connect_by06.sql", "connect_by07.sql", "connect_by08.sql", "connect_by09.sql", "connect_by10.sql", "datetime01.sql", "datetime02.sql", "datetime04.sql", "datetime05.sql", "datetime06.sql", "dblink01.sql", "for_update01.sql", "for_update02.sql", "for_update03.sql", "function04.sql", "function05.sql", "for_update04.sql", "for_update05.sql", "for_update06.sql", "function01.sql", "function02.sql", "function03.sql", "function06.sql", "groupby01.sql", "groupby02.sql", "groupby03.sql", "groupby04.sql", "groupby05.sql", "groupby06.sql", "groupby08.sql", "groupby09.sql", "groupby10.sql", "groupby11.sql", "groupby12.sql", "groupby13.sql", "groupby14.sql", "groupby15.sql", "groupby16.sql", "groupby17.sql", "groupby19.sql", "groupby20.sql", "groupby21.sql", "groupby22.sql", "groupby23.sql", "insert02.sql", "insert11.sql", "insert12.sql", "interval02.sql", "interval04.sql", "interval05.sql", "join01.sql", "join02.sql", "join03.sql", "join04.sql", "join06.sql", "join07.sql", "join08.sql", "join09.sql", "join10.sql", "join11.sql", "join12.sql", "join13.sql", "join14.sql", "join15.sql", "join16.sql", "join17.sql", "join18.sql", "join19.sql", "join20.sql", "join21.sql", "keywordasidentifier01.sql", "keywordasidentifier02.sql", "keywordasidentifier03.sql", "keywordasidentifier04.sql", "keywordasidentifier05.sql", "lexer02.sql", "lexer03.sql", "lexer04.sql", "lexer05.sql", "like01.sql", "merge01.sql", "merge02.sql", "merge03.sql", "merge04.sql", "object_access01.sql", "order_by01.sql", "order_by02.sql", "order_by03.sql", "order_by04.sql", "order_by05.sql", "order_by06.sql", "pivot01.sql", "pivot02.sql", "pivot03.sql", "pivot04.sql", "pivot05.sql", "pivot06.sql", "pivot07.sql", "pivot07_Parenthesis.sql", "pivot08.sql", "pivot09.sql", "pivot11.sql", "pivot12.sql", "query_factoring01.sql", "query_factoring02.sql", "query_factoring03.sql", "query_factoring06.sql", "query_factoring07.sql", "query_factoring08.sql", "query_factoring09.sql", "query_factoring11.sql", "query_factoring12.sql", "set01.sql", "set02.sql", "simple02.sql", "simple03.sql", "simple04.sql", "simple05.sql", "simple06.sql", "simple07.sql", "simple08.sql", "simple09.sql", "simple10.sql", "simple11.sql", "simple12.sql", "simple13.sql", "union01.sql", "union02.sql", "union03.sql", "union04.sql", "union05.sql", "union06.sql", "union07.sql", "union08.sql", "union09.sql", "union10.sql", "xmltable02.sql");

public virtual void testAllSqlsParseDeparse() {
int count = 0;
int success = 0;
global::System.IO.FileInfo[] sqlTestFiles = global::DripSharp.Runtime.JavaCompat.FileListFiles(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.SQLS_DIR);
bool foundUnexpectedFailures = false;
global::DripSharp.Runtime.JavaCompat.Assert(() => (sqlTestFiles != default!));
foreach (global::System.IO.FileInfo file in sqlTestFiles) {
if (global::DripSharp.Runtime.JavaCompat.FileIsFile(file)) {
count++;
string sql = global::DripSharp.SqlTrellis.Tests.Support.ReadFileText(file, global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
try {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
success++;
this.recordSuccessOnSourceFile(file);
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
string message = global::DripSharp.Runtime.JavaCompat.ExceptionMessage(ex);
if (global::DripSharp.Runtime.JavaCompat.StringStartsWith(message, ((typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).FullName ?? (typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).Name))) {
message = message.Substring((((typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).FullName ?? (typeof(global::DripSharp.SqlTrellis.Parser.ParseException)).Name).Length + 2));
}
int pos = global::DripSharp.Runtime.JavaCompat.StringIndexOf(message, (int)('\n'));
if ((pos > 0)) {
message = global::DripSharp.Runtime.JavaCompat.StringSubstring(message, 0, pos);
}
if ((global::DripSharp.Runtime.JavaCompat.StringContains(sql, "@SUCCESSFULLY_PARSED_AND_DEPARSED") || global::DripSharp.Runtime.JavaCompat.CollectionContains(this.EXPECTED_SUCCESSES, file.Name))) {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Severe, global::DripSharp.Runtime.JavaCompat.Concat("UNEXPECTED PARSING FAILURE: {0}\n\t", message), file.Name);
foundUnexpectedFailures = true;
} else {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Fine, "EXPECTED PARSING FAILURE: {0}", file.Name);
}
this.recordFailureOnSourceFile(file, message);
} catch (global::System.Exception ex) when (ex is not global::System.TypeInitializationException && ex is not global::Xunit.Sdk.XunitException) {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Severe, global::DripSharp.Runtime.JavaCompat.Concat("UNEXPECTED EXCEPTION: {0}\n\t", global::DripSharp.Runtime.JavaCompat.ExceptionMessage(ex)), file.Name);
foundUnexpectedFailures = true;
} catch (global::Xunit.Sdk.XunitException ex) {
if ((global::DripSharp.Runtime.JavaCompat.StringContains(sql, "@SUCCESSFULLY_PARSED_AND_DEPARSED") || global::DripSharp.Runtime.JavaCompat.CollectionContains(this.EXPECTED_SUCCESSES, file.Name))) {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Severe, global::DripSharp.Runtime.JavaCompat.Concat("UNEXPECTED DE-PARSING FAILURE: {0}\n", ex.ToString()), file.Name);
foundUnexpectedFailures = true;
} else {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Fine, "EXPECTED DE-PARSING FAILURE: {0}", file.Name);
}
this.recordFailureOnSourceFile(file, global::DripSharp.SqlTrellis.Tests.Support.AssertionActual(ex).GetStringRepresentation());
}
}
}
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Info, "tested {0} files. got {1} correct parse results, expected {2}", new object[] { count, success, global::DripSharp.Runtime.JavaCompat.CollectionCount(this.EXPECTED_SUCCESSES) });
global::DripSharp.Testing.JavaAssertions.True((success >= global::DripSharp.Runtime.JavaCompat.CollectionCount(this.EXPECTED_SUCCESSES)), null);
global::DripSharp.Testing.JavaAssertions.False(foundUnexpectedFailures, "Found Testcases failing unexpectedly.");
}

public virtual void debugSpecificSql() {
global::System.IO.FileInfo[] sqlTestFiles = global::DripSharp.SqlTrellis.Tests.Support.ListFiles(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.SQLS_DIR, (dir, name) => {
return global::DripSharp.Runtime.JavaCompat.Equals("pivot04.sql", name);
});
global::DripSharp.Runtime.JavaCompat.Assert(() => (sqlTestFiles != default!));
foreach (global::System.IO.FileInfo file in sqlTestFiles) {
if (global::DripSharp.Runtime.JavaCompat.FileIsFile(file)) {
string sql = global::DripSharp.SqlTrellis.Tests.Support.ReadFileText(file, global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}
}
}

public virtual void recordSuccessOnSourceFile(global::System.IO.FileInfo file) {
global::System.IO.FileInfo sourceFile = new global::System.IO.FileInfo(global::System.IO.Path.Combine((global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.SQL_SOURCE_DIR).FullName, file.Name));
string sourceSql = global::DripSharp.SqlTrellis.Tests.Support.ReadFileText(sourceFile, global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
if (!(global::DripSharp.Runtime.JavaCompat.StringContains(sourceSql, "@SUCCESSFULLY_PARSED_AND_DEPARSED"))) {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Info, "NEW SUCCESS: {0}", file.Name);
if ((global::DripSharp.Runtime.JavaCompat.FileExists(sourceFile) && global::DripSharp.Runtime.JavaCompat.FileCanWrite(sourceFile))) {
using (global::System.IO.StreamWriter writer = new global::System.IO.StreamWriter(sourceFile.FullName, true)) {
global::DripSharp.Runtime.JavaCompat.WriterAppend(global::DripSharp.Runtime.JavaCompat.WriterAppend(writer, "\n--@SUCCESSFULLY_PARSED_AND_DEPARSED first on "), global::DripSharp.SqlTrellis.Tests.Support.DefaultDateTimeFormat().Format(global::System.DateTimeOffset.Now));
}
}
} else {
if (global::DripSharp.Runtime.JavaCompat.CollectionContains(this.EXPECTED_SUCCESSES, file.Name)) {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Fine, "EXPECTED SUCCESS: {0}", file.Name);
} else {
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Warning, "UNRECORDED SUCCESS: {0}, please add to the EXPECTED_SUCCESSES List in SpecialOracleTest.java", file.Name);
}
}
}

public virtual void recordFailureOnSourceFile(global::System.IO.FileInfo file, string message) {
global::System.IO.FileInfo sourceFile = new global::System.IO.FileInfo(global::System.IO.Path.Combine((global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.SQL_SOURCE_DIR).FullName, file.Name));
string sourceSql = global::DripSharp.SqlTrellis.Tests.Support.ReadFileText(sourceFile, global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
if ((!(global::DripSharp.Runtime.JavaCompat.StringContains(sourceSql, global::DripSharp.Runtime.JavaCompat.Concat("@FAILURE: ", message))) && global::DripSharp.Runtime.JavaCompat.FileCanWrite(sourceFile))) {
using (global::System.IO.StreamWriter writer = new global::System.IO.StreamWriter(sourceFile.FullName, true)) {
global::DripSharp.Runtime.JavaCompat.WriterAppend(global::DripSharp.Runtime.JavaCompat.WriterAppend(global::DripSharp.Runtime.JavaCompat.WriterAppend(global::DripSharp.Runtime.JavaCompat.WriterAppend(writer, "\n--@FAILURE: "), message), " recorded first on "), global::DripSharp.SqlTrellis.Tests.Support.DefaultDateTimeFormat().Format(global::System.DateTimeOffset.Now));
}
}
}

public virtual void testAllSqlsOnlyParse() {
global::System.IO.FileInfo[] sqlTestFiles = global::DripSharp.Runtime.JavaCompat.FileListFiles(new global::System.IO.FileInfo(global::System.IO.Path.Combine((global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.SQLS_DIR).FullName, "only-parse-test")));
global::System.Collections.Generic.IList<string> regressionFiles = new global::System.Collections.Generic.List<string>();
global::DripSharp.Runtime.JavaCompat.Assert(() => (sqlTestFiles != default!));
foreach (global::System.IO.FileInfo file in sqlTestFiles) {
string sql = global::DripSharp.SqlTrellis.Tests.Support.ReadFileText(file, global::DripSharp.Runtime.JavaStandardCharsets.UTF8);
try {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Fine, "EXPECTED SUCCESS: {0}", file.Name);
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
global::DripSharp.Runtime.JavaCompat.Add(regressionFiles, file.Name);
string message = global::DripSharp.Runtime.JavaCompat.ExceptionMessage(ex);
int pos = global::DripSharp.Runtime.JavaCompat.StringIndexOf(message, (int)('\n'));
if ((pos > 0)) {
message = global::DripSharp.Runtime.JavaCompat.StringSubstring(message, 0, pos);
}
global::DripSharp.SqlTrellis.Tests.Support.LogFormatted(global::DripSharp.SqlTrellis.Statement.Select.SpecialOracleTest.LOG, global::DripSharp.Runtime.JavaLogLevel.Severe, global::DripSharp.Runtime.JavaCompat.Concat("UNEXPECTED PARSING FAILURE: {0}\n\t", message), file.Name);
}
}
global::DripSharp.Testing.JavaAssertJ.That(regressionFiles).DescribedAs("All files should parse successfully, a regression was detected!").IsEmpty();
}

public virtual void testOperatorsWithSpaces() {
string sql;
sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    Something\n"), "FROM\n"), "    Sometable\n"), "WHERE\n"), "    Somefield >= Somevalue\n"), "    AND Somefield <= Somevalue\n"), "    AND Somefield <> Somevalue\n"), "    AND Somefield != Somevalue\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    Something\n"), "FROM\n"), "    Sometable\n"), "WHERE\n"), "    Somefield > = Somevalue\n"), "    AND Somefield < = Somevalue\n"), "    AND Somefield < > Somevalue\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "    Something\n"), "FROM\n"), "    Sometable\n"), "WHERE\n"), "    Somefield > \t = Somevalue\n"), "    AND Somefield <   = Somevalue\n"), "    AND Somefield <\t\t> Somevalue\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

[Xunit.Fact]
public void __Upstream_114f82cf645e2a6c()
{
        try
        {
            this.debugSpecificSql();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0657430f5c3438c4()
{
        try
        {
            this.testAllSqlsOnlyParse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9765c06c64b9c396()
{
        try
        {
            this.testAllSqlsParseDeparse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_114aec631183845c()
{
        try
        {
            this.testOperatorsWithSpaces();
        }
        finally
        {
        }
}
}
