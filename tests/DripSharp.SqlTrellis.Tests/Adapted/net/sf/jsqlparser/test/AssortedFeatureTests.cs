// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Test;

public class AssortedFeatureTests {
internal class ReplaceColumnAndLongValues : global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser {
public override global::System.Text.StringBuilder visit<K>(global::DripSharp.SqlTrellis.Expression.StringValue stringValue, K parameters) {
this.getBuilder().Append("?");
return default!;
}

public override global::System.Text.StringBuilder visit<K>(global::DripSharp.SqlTrellis.Expression.LongValue longValue, K parameters) {
this.getBuilder().Append("?");
return default!;
}
}

public static string cleanStatement(string sql) {
global::System.Text.StringBuilder buffer = new global::System.Text.StringBuilder();
global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expr = new global::DripSharp.SqlTrellis.Test.AssortedFeatureTests.ReplaceColumnAndLongValues();
global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser selectDeparser = new global::DripSharp.SqlTrellis.Util.Deparser.SelectDeParser(expr, buffer);
expr.setSelectVisitor(selectDeparser);
expr.setBuilder(buffer);
global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser stmtDeparser = new global::DripSharp.SqlTrellis.Util.Deparser.StatementDeParser(expr, selectDeparser, buffer);
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
((global::DripSharp.SqlTrellis.Statement.Statement)(stmt)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<global::System.Text.StringBuilder>)(stmtDeparser));
return stmtDeparser.getBuilder().ToString();
}

public virtual void testIssue1608() {
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.SqlTrellis.Test.AssortedFeatureTests.cleanStatement("SELECT 'abc', 5 FROM mytable WHERE col='test'"));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.SqlTrellis.Test.AssortedFeatureTests.cleanStatement("UPDATE table1 A SET A.columna = 'XXX' WHERE A.cod_table = 'YYY'"));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.SqlTrellis.Test.AssortedFeatureTests.cleanStatement("INSERT INTO example (num, name, address, tel) VALUES (1, 'name', 'test ', '1234-1234')"));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.SqlTrellis.Test.AssortedFeatureTests.cleanStatement("DELETE FROM table1 where col=5 and col2=4"));
}

[Xunit.Fact]
public void __Upstream_884ad7ba4d4e67de()
{
        try
        {
            this.testIssue1608();
        }
        finally
        {
        }
}
}
