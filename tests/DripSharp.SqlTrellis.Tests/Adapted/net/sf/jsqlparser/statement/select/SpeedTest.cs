// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SpeedTest {
private const int NUM_REPS_500 = 500;

private readonly global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();

public virtual void testSpeed() {
global::System.IO.TextReader @in = global::DripSharp.Runtime.JavaCompat.NewInputStreamReader(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SpeedTest), "/simple_parsing.txt"));
global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest d;
global::System.Collections.Generic.IList<string> statementsList = new global::System.Collections.Generic.List<string>();
while (true) {
string statement__45_20 = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getStatement(@in);
if ((statement__45_20 == default!)) {
break;
}
global::DripSharp.Runtime.JavaCompat.Add(statementsList, statement__45_20);
}
@in.Dispose();
@in = global::DripSharp.Runtime.JavaCompat.NewInputStreamReader(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Select.SpeedTest), "/RUBiS-select-requests.txt"));
while (true) {
string line = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
if ((line == default!)) {
break;
}
if ((line.Length == 0)) {
continue;
}
if (!(global::DripSharp.Runtime.JavaCompat.Equals(line, "#begin"))) {
break;
}
line = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
global::System.Text.StringBuilder buf = new global::System.Text.StringBuilder(line);
while (true) {
line = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
if (global::DripSharp.Runtime.JavaCompat.Equals(line, "#end")) {
break;
}
buf.Append("\n");
buf.Append(line);
}
if (!(global::DripSharp.Runtime.JavaCompat.Equals(global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in), "true"))) {
continue;
}
global::DripSharp.Runtime.JavaCompat.Add(statementsList, buf.ToString());
string cols = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
string tables = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
string whereCols = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
string type = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in);
}
@in.Dispose();
string statement__92_16;
int numTests = 0;
global::DripSharp.SqlTrellis.Statement.Statement parsedStm = this.parserManager.parse(new global::System.IO.StringReader((statement__92_16 = global::DripSharp.Runtime.JavaCompat.ListGet(statementsList, 0))));
global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object> tablesNamesFinder = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.Select> parsedSelects = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.Select>((global::DripSharp.SqlTrellis.Statement.Select.SpeedTest.NUM_REPS_500 * global::DripSharp.Runtime.JavaCompat.CollectionCount(statementsList)));
long time = global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
for (int i = 0; (i < global::DripSharp.SqlTrellis.Statement.Select.SpeedTest.NUM_REPS_500); i++) {
try {
foreach (string s in statementsList) {
statement__92_16 = s;
parsedStm = this.parserManager.parse(new global::System.IO.StringReader(statement__92_16));
numTests++;
if ((parsedStm is global::DripSharp.SqlTrellis.Statement.Select.Select)) {
global::DripSharp.Runtime.JavaCompat.Add(parsedSelects, (global::DripSharp.SqlTrellis.Statement.Select.Select)(parsedStm!));
}
}
} catch (global::DripSharp.SqlTrellis.JSQLParserException e) {
throw new global::DripSharp.SqlTrellis.Test.TestException(global::DripSharp.Runtime.JavaCompat.Concat("impossible to parse statement: ", statement__92_16), e);
}
}
long elapsedTime = (global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - time);
long statementsPerSecond = ((numTests * 1000L) / elapsedTime);
global::DripSharp.Runtime.JavaDecimalFormat df = new global::DripSharp.Runtime.JavaDecimalFormat();
df.SetMaximumFractionDigits(7);
df.SetMinimumFractionDigits(4);
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(numTests, " statements parsed in "), elapsedTime), " milliseconds"));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(" (", statementsPerSecond), " statements per second,  "), df.Format(((double)(1.0D) / statementsPerSecond))), " seconds per statement )"));
numTests = 0;
time = global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
foreach (global::DripSharp.SqlTrellis.Statement.Select.Select select in parsedSelects) {
if ((select != default!)) {
numTests++;
tablesNamesFinder.getTableList((global::DripSharp.SqlTrellis.Statement.Statement)(select!));
}
}
elapsedTime = (global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - time);
statementsPerSecond = ((numTests * 1000L) / elapsedTime);
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(numTests, " select scans for table name executed in "), elapsedTime), " milliseconds"));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(" (", statementsPerSecond), " select scans for table name per second,  "), df.Format(((double)(1.0D) / statementsPerSecond))), " seconds per select scans for table name)"));
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_eb0a01e515293912()
{
        try
        {
            this.testSpeed();
        }
        finally
        {
        }
}
}
