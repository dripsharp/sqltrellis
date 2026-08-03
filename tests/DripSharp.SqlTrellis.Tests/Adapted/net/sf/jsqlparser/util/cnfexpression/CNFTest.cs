// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Cnfexpression;

public class CNFTest {
public virtual void test1() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("NOT ((1.2 < 2.3 OR 3.5 = 4.6) AND (1.1 <> 2.5 OR 8.0 >= 7.2))");
global::DripSharp.SqlTrellis.Expression.Expression expected = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat("(NOT 1.2 < 2.3 OR NOT 1.1 <> 2.5) AND (NOT 1.2 < 2.3 OR NOT 8.0 >= 7.2) AND", " (NOT 3.5 = 4.6 OR NOT 1.1 <> 2.5) AND (NOT 3.5 = 4.6 OR NOT 8.0 >= 7.2)"));
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.StringValueOf(expected), global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void test2() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat("((NOT (NOT 1.1 >= 2.3 OR 3.3 < 4.5)) OR ", "(S.A LIKE '\"%%%\"' AND S.B = '\"orz\"'))"));
global::DripSharp.SqlTrellis.Expression.Expression expected = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("(1.1 >= 2.3 OR S.A LIKE '\"%%%\"') AND (1.1 >= 2.3 OR S.B = '\"orz\"') AND (NOT 3.3 < 4.5 OR S.A LIKE '\"%%%\"') AND (NOT 3.3 < 4.5 OR S.B = '\"orz\"')");
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.StringValueOf(expected), global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void test3() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(3.0 >= 4.0 AND 5.0 <= 6.0) OR ", "(((7.0 < 8.0 AND 9.0 > 10.0) AND 11.0 = 12.0) OR "), "NOT (13.0 <> 14.0 OR (15.0 = 16.0 AND (17.0 = 18.0 OR 19.0 > 20.0))))"));
global::DripSharp.SqlTrellis.Expression.Expression expected = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(3.0 >= 4.0 OR 7.0 < 8.0 OR NOT 13.0 <> 14.0) AND ", "(3.0 >= 4.0 OR 7.0 < 8.0 OR NOT 15.0 = 16.0 OR NOT 17.0 = 18.0) AND "), "(3.0 >= 4.0 OR 7.0 < 8.0 OR NOT 15.0 = 16.0 OR NOT 19.0 > 20.0) AND "), "(3.0 >= 4.0 OR 9.0 > 10.0 OR NOT 13.0 <> 14.0) AND "), "(3.0 >= 4.0 OR 9.0 > 10.0 OR NOT 15.0 = 16.0 OR NOT 17.0 = 18.0) AND "), "(3.0 >= 4.0 OR 9.0 > 10.0 OR NOT 15.0 = 16.0 OR NOT 19.0 > 20.0) AND "), "(3.0 >= 4.0 OR 11.0 = 12.0 OR NOT 13.0 <> 14.0) AND "), "(3.0 >= 4.0 OR 11.0 = 12.0 OR NOT 15.0 = 16.0 OR NOT 17.0 = 18.0) AND "), "(3.0 >= 4.0 OR 11.0 = 12.0 OR NOT 15.0 = 16.0 OR NOT 19.0 > 20.0) AND "), "(5.0 <= 6.0 OR 7.0 < 8.0 OR NOT 13.0 <> 14.0) AND "), "(5.0 <= 6.0 OR 7.0 < 8.0 OR NOT 15.0 = 16.0 OR NOT 17.0 = 18.0) AND "), "(5.0 <= 6.0 OR 7.0 < 8.0 OR NOT 15.0 = 16.0 OR NOT 19.0 > 20.0) AND "), "(5.0 <= 6.0 OR 9.0 > 10.0 OR NOT 13.0 <> 14.0) AND "), "(5.0 <= 6.0 OR 9.0 > 10.0 OR NOT 15.0 = 16.0 OR NOT 17.0 = 18.0) AND "), "(5.0 <= 6.0 OR 9.0 > 10.0 OR NOT 15.0 = 16.0 OR NOT 19.0 > 20.0) AND "), "(5.0 <= 6.0 OR 11.0 = 12.0 OR NOT 13.0 <> 14.0) AND "), "(5.0 <= 6.0 OR 11.0 = 12.0 OR NOT 15.0 = 16.0 OR NOT 17.0 = 18.0) AND "), "(5.0 <= 6.0 OR 11.0 = 12.0 OR NOT 15.0 = 16.0 OR NOT 19.0 > 20.0)"));
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.StringValueOf(expected), global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void test4() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("NOT S.D > {d '2017-03-25'}");
global::DripSharp.SqlTrellis.Expression.Expression expected = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("NOT S.D > {d '2017-03-25'}");
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.StringValueOf(expected), global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void test5() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat("NOT ((NOT (S.A > 3.5 AND S.B < 4)) OR ", "(S.C LIKE '\"%%\"' OR S.D = {t '12:04:34'}))"));
global::DripSharp.SqlTrellis.Expression.Expression expected = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("S.A > 3.5 AND S.B < 4 AND NOT S.C LIKE '\"%%\"' AND NOT S.D = {t '12:04:34'}");
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.StringValueOf(expected), global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testStackOverflowIssue1576() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("((3.0 >= 4.0 AND 5.0 <= 6.0) OR ", "(7.0 < 8.0 AND 9.0 > 10.0) OR "), "(11.0 = 11.0 AND 19.0 > 20.0) OR "), "(17.0 = 14.0 AND 19.0 > 17.0) OR "), "(17.0 = 18.0 AND 20.0 > 20.0) OR "), "(17.0 = 16.0 AND 19.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0) OR "), "(17.0 = 22.0 AND 19.0 > 20.0) OR "), "(18.0 = 18.0 AND 22.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0) OR "), "(18.0 = 18.0 AND 22.0 > 20.0) OR "), "(18.0 = 19.0 AND 22.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0))"));
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertJ.That(result).AsString().HasSize(3448827);
}

public virtual void testStackOverflowIssue1576_veryLarge() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("((3.0 >= 4.0 AND 5.0 <= 6.0) OR ", "(7.0 < 8.0 AND 9.0 > 10.0) OR "), "(11.0 = 11.0 AND 19.0 > 20.0) OR "), "(17.0 = 14.0 AND 19.0 > 17.0) OR "), "(17.0 = 18.0 AND 20.0 > 20.0) OR "), "(17.0 = 16.0 AND 19.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0) OR "), "(17.0 = 22.0 AND 19.0 > 20.0) OR "), "(18.0 = 18.0 AND 22.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0) OR "), "(18.0 = 18.0 AND 22.0 > 20.0) OR "), "(18.0 = 19.0 AND 22.0 > 20.0) OR "), "(117.0 = 22.0 AND 19.0 > 20.0) OR "), "(118.0 = 18.0 AND 22.0 > 20.0) OR "), "(117.0 = 18.0 AND 19.0 > 20.0) OR "), "(17.0 = 18.0 AND 19.0 > 20.0))"));
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertJ.That(result).AsString().HasSize(33685499);
}

public virtual void testStackOverflowIssue1576_2() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("((3.0 >= 4.0 AND 5.0 <= 6.0) OR ", "(7.0 < 8.0 AND 9.0 > 10.0) OR "), "(11.0 = 11.0 AND 19.0 > 20.0) OR "), "(17.0 = 14.0 AND 19.0 > 17.0) OR "), "(17.0 = 18.0 AND 20.0 > 20.0) OR "), "(17.0 = 16.0 AND 19.0 > 20.0))"));
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Util.Cnfexpression.CNFConverter.convertToCNF(expr);
global::DripSharp.Testing.JavaAssertJ.That(result).AsString().IsEqualTo("(3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (3.0 >= 4.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 7.0 < 8.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 11.0 = 11.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 17.0 = 14.0 OR 20.0 > 20.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 17.0 = 18.0 OR 19.0 > 20.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 17.0 = 16.0) AND (5.0 <= 6.0 OR 9.0 > 10.0 OR 19.0 > 20.0 OR 19.0 > 17.0 OR 20.0 > 20.0 OR 19.0 > 20.0)");
}

[Xunit.Fact]
public void __Upstream_8084b990fad1f7ab()
{
        try
        {
            this.test1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bdec67d05f9dc651()
{
        try
        {
            this.test2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2a4e86c361e0d988()
{
        try
        {
            this.test3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_facb16d33e14a759()
{
        try
        {
            this.test4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_771fd9b4589fbef6()
{
        try
        {
            this.test5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3398f99d15e03b37()
{
        try
        {
            this.testStackOverflowIssue1576();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8c43d735233fb4fb()
{
        try
        {
            this.testStackOverflowIssue1576_2();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_cf02ee92dd2728bc()
{
        try
        {
            this.testStackOverflowIssue1576_veryLarge();
        }
        finally
        {
        }
}
}
