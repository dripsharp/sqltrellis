// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Simpleparsing;

public class CCJSqlParserManagerTest {
public virtual void testParse() {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();
global::System.IO.TextReader @in = global::DripSharp.Runtime.JavaCompat.NewInputStreamReader(global::DripSharp.Runtime.JavaCompat.RequireNonNull(global::DripSharp.SqlTrellis.Tests.Support.ResourceStream(typeof(global::DripSharp.SqlTrellis.Statement.Create.CreateTableTest), "/simple_parsing.txt")));
string statement = "";
while (true) {
try {
statement = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getStatement(@in);
if ((statement == default!)) {
break;
}
parserManager.parse(new global::System.IO.StringReader(statement));
} catch (global::DripSharp.SqlTrellis.JSQLParserException e) {
throw new global::DripSharp.SqlTrellis.Test.TestException(global::DripSharp.Runtime.JavaCompat.Concat("impossible to parse statement: ", statement), e);
}
}
}

public static string getStatement(global::System.IO.TextReader @in) {
global::System.Text.StringBuilder buf = new global::System.Text.StringBuilder();
string line;
while (((line = global::DripSharp.SqlTrellis.Statement.Simpleparsing.CCJSqlParserManagerTest.getLine(@in)) != default!)) {
if ((line.Length == 0)) {
break;
}
buf.Append(line);
buf.Append("\n");
}
if ((buf.Length > 0)) {
return buf.ToString();
} else {
return default!;
}
}

public static string getLine(global::System.IO.TextReader @in) {
string line;
while (true) {
line = @in.ReadLine();
if ((line != default!)) {
if (((line.Length < 2) || !((((int)(line[0]) == (int)('/')) && ((int)(line[1]) == (int)('/')))))) {
break;
}
} else {
break;
}
}
return line;
}

[Xunit.Fact]
public void __Upstream_6c45ccd60fe77c61()
{
        try
        {
            this.testParse();
        }
        finally
        {
        }
}
}
