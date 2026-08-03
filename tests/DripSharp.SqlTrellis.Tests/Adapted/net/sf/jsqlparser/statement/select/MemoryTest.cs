// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class MemoryTest {
public static void main(string[] args) {
global::System.GC.Collect();
global::DripSharp.Runtime.JavaCompat.@out.WriteLine((global::System.GC.GetGCMemoryInfo().TotalAvailableMemoryBytes - (global::System.GC.GetGCMemoryInfo().TotalAvailableMemoryBytes - global::System.GC.GetTotalMemory(false))));
global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager parserManager = new global::DripSharp.SqlTrellis.Parser.CCJSqlParserManager();
string longQuery = "select * from k where ID > 4";
global::System.IO.StringReader stringReader = new global::System.IO.StringReader(longQuery);
global::DripSharp.SqlTrellis.Statement.Statement statement = parserManager.parse(stringReader);
statement = default!;
parserManager = default!;
longQuery = default!;
global::System.GC.Collect();
global::DripSharp.Runtime.JavaCompat.@out.WriteLine((global::System.GC.GetGCMemoryInfo().TotalAvailableMemoryBytes - (global::System.GC.GetGCMemoryInfo().TotalAvailableMemoryBytes - global::System.GC.GetTotalMemory(false))));
}
}
