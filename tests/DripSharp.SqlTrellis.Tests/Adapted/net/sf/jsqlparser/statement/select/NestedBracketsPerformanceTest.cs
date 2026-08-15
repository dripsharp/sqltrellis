// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class NestedBracketsPerformanceTest {
private static readonly global::DripSharp.Runtime.JavaLogger LOG = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Statement.Select.NestedBracketsPerformanceTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Statement.Select.NestedBracketsPerformanceTest).Name));

public virtual void testIssue766() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat('1','2'),'3'),'4'),'5'),'6'),'7'),'8'),'9'),'10'),'11'),'12'),'13'),'14'),'15'),'16'),'17'),'18'),'19'),'20'),'21'),col1 FROM tbl t1", true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIssue766_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT concat(concat(concat('1', '2'), '3'), '4'), col1 FROM tbl t1", true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIssue235() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CASE WHEN ( CASE WHEN ( CASE WHEN ( CASE WHEN ( 1 ) THEN 0 END ) THEN 0 END ) THEN 0 END ) THEN 0 END FROM a", true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testNestedCaseWhenWithoutBracketsIssue1162() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE VIEW VIEW_NAME1 AS\n", "SELECT CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE CASE WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT' ELSE '0' END END END END END END END END END END END END END END COLUMNALIAS\n"), "FROM TABLE1"), true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testNestedCaseWhenWithBracketsIssue1162() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE VIEW VIEW_NAME1 AS\n", "SELECT CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE\n"), "WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT'\n"), "ELSE (CASE WHEN WDGFLD.PORTTYPE = 1 THEN 'INPUT PORT' ELSE '0' END) END) END) END) END) END) END) END) END) END) END) END) END) END COLUMNALIAS\n"), "FROM TABLE1"), true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIssue496() {
global::DripSharp.Testing.JavaAssertions.ThrowsExactly<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select isNull(charLen(TEST_ID,0)+ isNull(charLen(TEST_DVC,0)+ isNull(charLen(TEST_NO,0)+ isNull(charLen(ATEST_ID,0)+ isNull(charLen(TESTNO,0)+ isNull(charLen(TEST_CTNT,0)+ isNull(charLen(TEST_MESG_CTNT,0)+ isNull(charLen(TEST_DTM,0)+ isNull(charLen(TEST_DTT,0)+ isNull(charLen(TEST_ADTT,0)+ isNull(charLen(TEST_TCD,0)+ isNull(charLen(TEST_PD,0)+ isNull(charLen(TEST_VAL,0)+ isNull(charLen(TEST_YN,0)+ isNull(charLen(TEST_DTACM,0)+ isNull(charLen(TEST_MST,0) from test_info_m", true, (parser) => parser.withTimeOut((long)(6000)));
}, null);
}

public virtual void testIssue856() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT ", this.buildRecursiveBracketExpression("if(month(today()) = 3, sum(\"Table5\".\"Month 002\"), $1)", "0", 3)), " FROM mytbl");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testRecursiveBracketExpressionIssue1019() {
global::DripSharp.Testing.JavaAssertions.Equal("IF(1=1, 1, 2)", this.buildRecursiveBracketExpression("IF(1=1, $1, 2)", "1", 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("IF(1=1, IF(1=1, 1, 2), 2)", this.buildRecursiveBracketExpression("IF(1=1, $1, 2)", "1", 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("IF(1=1, IF(1=1, IF(1=1, 1, 2), 2), 2)", this.buildRecursiveBracketExpression("IF(1=1, $1, 2)", "1", 2), null);
}

public virtual void testRecursiveBracketExpressionIssue1019_2() {
this.doIncreaseOfParseTimeTesting("IF(1=1, $1, 2)", "1", 10);
}

public virtual void testIssue1013() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT ((((((((((((((((tblA)))))))))))))))) FROM mytable", true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIssue1013_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM ((((((((((((((((tblA))))))))))))))))", true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIssue1013_3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM (((tblA)))", true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIssue1013_4() {
global::System.Text.StringBuilder s = new global::System.Text.StringBuilder("tblA");
for (int i = 1; (i < 100); i++) {
s = new global::System.Text.StringBuilder(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("(", s), ")"));
}
string sql = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM ", s);
(global::DripSharp.SqlTrellis.Statement.Select.NestedBracketsPerformanceTest.LOG).Info(global::DripSharp.Runtime.JavaCompat.Concat("testing ", sql));
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testIncreaseOfParseTime() {
this.doIncreaseOfParseTimeTesting("concat($1,'B')", "'A'", 50);
}

private void doIncreaseOfParseTimeTesting(string template, string finalExpression, int maxDepth) {
long oldDurationTime = 2000;
int countProblematic = 0;
for (int i = 0; (i < maxDepth); i++) {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT ", this.buildRecursiveBracketExpression(template, finalExpression, i)), " FROM mytbl");
long startTime = global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true, (parser) => parser.withTimeOut((long)(12000)));
long durationTime = (global::System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - startTime);
if ((i > 0)) {
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("old duration ", oldDurationTime), " new duration time "), durationTime), " for "), sql));
}
if (((oldDurationTime * 10) < durationTime)) {
countProblematic++;
}
if ((countProblematic > 5)) {
global::DripSharp.Testing.JavaAssertions.Fail("Assertion failed.");
}
oldDurationTime = global::System.Math.Max(durationTime, (long)(1));
}
}

public virtual void testRecursiveBracketExpression() {
global::DripSharp.Testing.JavaAssertions.Equal("concat('A','B')", this.buildRecursiveBracketExpression("concat($1,'B')", "'A'", 0), null);
global::DripSharp.Testing.JavaAssertions.Equal("concat(concat('A','B'),'B')", this.buildRecursiveBracketExpression("concat($1,'B')", "'A'", 1), null);
global::DripSharp.Testing.JavaAssertions.Equal("concat(concat(concat('A','B'),'B'),'B')", this.buildRecursiveBracketExpression("concat($1,'B')", "'A'", 2), null);
}

private string buildRecursiveBracketExpression(string template, string finalExpression, int depth) {
if ((depth == 0)) {
return global::DripSharp.Runtime.JavaCompat.ReplaceOrdinal(template, "$1", finalExpression);
}
return global::DripSharp.Runtime.JavaCompat.ReplaceOrdinal(template, "$1", this.buildRecursiveBracketExpression(template, finalExpression, (depth - 1)));
}

public virtual void testIssue1103() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT\n", "ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(\n"), "ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(\n"), "ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(\n"), "ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(ROUND(0\n"), ",0),0),0),0),0),0),0),0)\n"), ",0),0),0),0),0),0),0),0)\n"), ",0),0),0),0),0),0),0),0)\n"), ",0),0),0),0),0),0),0),0)"), true, (parser) => parser.withTimeOut((long)(60000)));
}

public virtual void testDeepFunctionParameters() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT  a.*\n", "        , To_Char( a.eingangsdat, 'MM.YY' ) AS eingmonat\n"), "        , ( SELECT Trim( b.atext )\n"), "            FROM masseinheiten x\n"), "                , a_lmt b\n"), "            WHERE x.a_text_id = b.a_text_id\n"), "                AND b.sprach_kz = sprache\n"), "                AND x.masseinh_id = a.masseinh_id ) AS reklamengesonst_bez\n"), "        , ( SELECT Trim( name ) || ' ' || Trim( vorname ) AS eingangerfasser_name\n"), "            FROM personal\n"), "            WHERE mandanten_id = m_personal\n"), "                AND personal_id = eingangerfasser ) AS eingangerfasser_name\n"), "        , Nvl( (    SELECT Max( change_date )\n"), "                    FROM besch_statusaenderung\n"), "                    WHERE beschwerden_id = a.beschwerden_id\n"), "                        AND beschstatus_id = 9\n"), "                        AND Nvl( inaktiv, 'F' ) != 'T' ), sysdate ) AS abschlussdatum\n"), "        , a.sachstand\n"), "        , a.bewertung\n"), "        , a.massnahmen\n"), "        , ( Decode( Nvl( (  SELECT Max( Trunc( change_date ) ) - Trunc( a.adate )\n"), "                            FROM besch_statusaenderung\n"), "                            WHERE beschwerden_id = a.beschwerden_id\n"), "                                AND beschstatus_id = 9\n"), "                                AND Nvl( inaktiv, 'F' ) != 'T' ), - 1 )\n"), "                    , - 1, Trunc( sysdate ) - Trunc( a.adate ) - (  SELECT Count()\n"), "                                                                    FROM firmenkalender\n"), "                                                                    WHERE firma_id = firmen_id\n"), "                                                                        AND Nvl( b_verkauf, 'F' ) = 'T'\n"), "                                                                        AND kal_datum BETWEEN Trunc( a.adate )\n"), "                                                                                             AND Trunc( sysdate ) )\n"), "                    , Nvl( (    SELECT Max( Trunc( change_date ) ) - Trunc( a.adate )\n"), "                                FROM besch_statusaenderung\n"), "                                WHERE beschwerden_id = a.beschwerden_id\n"), "                                    AND beschstatus_id = 9\n"), "                                    AND Nvl( inaktiv, 'F' ) != 'T' ), - 1 )\n"), "                             - (    SELECT Count()\n"), "                                    FROM firmenkalender\n"), "                                    WHERE firma_id = firmen_id\n"), "                                        AND Nvl( b_verkauf, 'F' ) = 'T'\n"), "                                        AND kal_datum BETWEEN Trunc( a.adate )\n"), "                                                             AND (  SELECT Max( Trunc( change_date ) )\n"), "                                                                    FROM besch_statusaenderung\n"), "                                                                    WHERE beschwerden_id = a.beschwerden_id\n"), "                                                                        AND beschstatus_id = 9\n"), "                                                                        AND Nvl( inaktiv, 'F' ) != 'T' ) ) ) + 1 ) AS laufzeit\n"), "        , Nvl( (    SELECT grenzwert\n"), "                    FROM beschfehler\n"), "                    WHERE beschfehler_id = a.beschwkat_id ), 0 ) AS grenzwert\n"), "        , Nvl( (    SELECT warnwert\n"), "                    FROM beschfehler\n"), "                    WHERE beschfehler_id = a.beschwkat_id ), 0 ) AS warnwert\n"), "        , a.beschstatus_id AS pruef_status\n"), "        , ( CASE\n"), "                    WHEN ( ( Decode( Nvl( ( SELECT Max( Trunc( change_date ) ) - Trunc( a.adate )\n"), "                                            FROM besch_statusaenderung\n"), "                                            WHERE beschwerden_id = a.beschwerden_id\n"), "                                                AND beschstatus_id = 9\n"), "                                                AND Nvl( inaktiv, 'F' ) != 'T' ), - 1 )\n"), "                                        , - 1, Trunc( sysdate ) - Trunc( a.adate ) - (  SELECT Count()\n"), "                                                                                        FROM firmenkalender\n"), "                                                                                        WHERE firma_id = firmen_id\n"), "                                                                                            AND Nvl( b_verkauf, 'F' ) = 'T'\n"), "                                                                                            AND kal_datum BETWEEN Trunc( a.adate )\n"), "                                                                                                                 AND Trunc( sysdate ) )\n"), "                                        , Nvl( (    SELECT Max( Trunc( change_date ) ) - Trunc( a.adate )\n"), "                                                    FROM besch_statusaenderung\n"), "                                                    WHERE beschwerden_id = a.beschwerden_id\n"), "                                                        AND beschstatus_id = 9\n"), "                                                        AND Nvl( inaktiv, 'F' ) != 'T' ), - 1 )\n"), "                                                 - (    SELECT Count()\n"), "                                                        FROM firmenkalender\n"), "                                                        WHERE firma_id = firmen_id\n"), "                                                            AND Nvl( b_verkauf, 'F' ) = 'T'\n"), "                                                            AND kal_datum BETWEEN Trunc( a.adate )\n"), "                                                                                 AND (  SELECT Max( Trunc( change_date ) )\n"), "                                                                                        FROM besch_statusaenderung\n"), "                                                                                        WHERE beschwerden_id = a.beschwerden_id\n"), "                                                                                            AND beschstatus_id = 9\n"), "                                                                                            AND Nvl( inaktiv, 'F' ) != 'T' ) ) ) + 1 ) - Nvl( ( SELECT grenzwert\n"), "                                                                                                                                                FROM beschfehler\n"), "                                                                                                                                                WHERE beschfehler_id = a.beschwkat_id ), 0 ) ) < 0\n"), "                        THEN 0\n"), "                    ELSE ( ( Decode( Nvl( ( SELECT Max( Trunc( change_date ) ) - Trunc( a.adate )\n"), "                                            FROM besch_statusaenderung\n"), "                                            WHERE beschwerden_id = a.beschwerden_id\n"), "                                                AND beschstatus_id = 9\n"), "                                                AND Nvl( inaktiv, 'F' ) != 'T' ), - 1 )\n"), "                                        , - 1, Trunc( sysdate ) - Trunc( a.adate ) - (  SELECT Count()\n"), "                                                                                        FROM firmenkalender\n"), "                                                                                        WHERE firma_id = firmen_id\n"), "                                                                                            AND Nvl( b_verkauf, 'F' ) = 'T'\n"), "                                                                                            AND kal_datum BETWEEN Trunc( a.adate )\n"), "                                                                                                                 AND Trunc( sysdate ) )\n"), "                                        , Nvl( (    SELECT Max( Trunc( change_date ) ) - Trunc( a.adate )\n"), "                                                    FROM besch_statusaenderung\n"), "                                                    WHERE beschwerden_id = a.beschwerden_id\n"), "                                                        AND beschstatus_id = 9\n"), "                                                        AND Nvl( inaktiv, 'F' ) != 'T' ), - 1 )\n"), "                                                 - (    SELECT Count( * )\n"), "                                                        FROM firmenkalender\n"), "                                                        WHERE firma_id = firmen_id\n"), "                                                            AND Nvl( b_verkauf, 'F' ) = 'T'\n"), "                                                            AND kal_datum BETWEEN Trunc( a.adate )\n"), "                                                                                 AND (  SELECT Max( Trunc( change_date ) )\n"), "                                                                                        FROM besch_statusaenderung\n"), "                                                                                        WHERE beschwerden_id = a.beschwerden_id\n"), "                                                                                            AND beschstatus_id = 9\n"), "                                                                                            AND Nvl( inaktiv, 'F' ) != 'T' ) ) ) + 1 ) - Nvl( ( SELECT grenzwert\n"), "                                                                                                                                                FROM beschfehler\n"), "                                                                                                                                                WHERE beschfehler_id = a.beschwkat_id ), 0 ) )\n"), "                END ) AS grenz_ueber\n"), "FROM beschwerden a\n"), "WHERE a.mandanten_id = m_beschwerde\n"), "    AND a.rec_status <> '9'\n"), "    AND EXISTS (    SELECT 1\n"), "                    FROM besch_statusaenderung\n"), "                    WHERE beschwerden_id = a.beschwerden_id )\n"), "    AND Nvl( (  SELECT grenzwert\n"), "                FROM beschfehler\n"), "                WHERE beschfehler_id = a.beschwkat_id ), 0 ) > 0\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withTimeOut((long)(60000)));
}

internal virtual void testIssue1983() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("INSERT INTO\n", "C01_INDIV_TELBK_CUST_INFO_H_T2 (PARTY_ID, PARTY_SIGN_STAT_CD, SIGN_TM, CLOSE_TM)\n"), "SELECT\n"), "A1.PARTY_ID,\n"), "A1.PARTY_SIGN_STAT_CD,\n"), "CAST(\n"), "(\n"), "CASE\n"), "WHEN A1.SIGN_TM IS NULL\n"), "OR A1.SIGN_TM = '' THEN CAST(\n"), "CAST(\n"), "CAST('ATkkIVQJZm' AS DATE FORMAT 'YYYYMMDD') AS DATE\n"), ") || ' 00:00:00' AS TIMESTAMP\n"), ")\n"), "WHEN CHARACTERS (TRIM(A1.SIGN_TM)) <> 19\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 1, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 1, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 2, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 2, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 3, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 3, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 4, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 4, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 6, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 6, 1) > '1'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 7, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 7, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 9, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 9, 1) > '3'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 10, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 10, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 1, 4) = '0000'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 6, 2) = '00'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 9, 2) = '00'\n"), "OR SUBSTR (TRIM(A1.SIGN_TM), 1, 1) = '0' THEN CAST(\n"), "CAST(\n"), "CAST('cDXtwdFyky' AS DATE FORMAT 'YYYYMMDD') AS DATE\n"), ") || ' 00:00:00' AS TIMESTAMP\n"), ")\n"), "ELSE (\n"), "CASE\n"), "WHEN (\n"), "CAST(SUBSTR (TRIM(A1.SIGN_TM), 9, 2) AS INTEGER) < 29\n"), "AND SUBSTR (TRIM(A1.SIGN_TM), 6, 2) = '02'\n"), ")\n"), "OR (\n"), "CAST(SUBSTR (TRIM(A1.SIGN_TM), 9, 2) AS INTEGER) < 31\n"), "AND SUBSTR (TRIM(A1.SIGN_TM), 6, 2) <> '02'\n"), "AND SUBSTR (TRIM(A1.SIGN_TM), 6, 2) <= 12\n"), ")\n"), "OR (\n"), "CAST(SUBSTR (TRIM(A1.SIGN_TM), 9, 2) AS INTEGER) = 31\n"), "AND SUBSTR (TRIM(A1.SIGN_TM), 6, 2) IN ('01', '03', '05', '07', '08', '10', '12')\n"), ") THEN CAST(A1.SIGN_TM AS TIMESTAMP)\n"), "WHEN SUBSTR (TRIM(A1.SIGN_TM), 6, 2) || SUBSTR (TRIM(A1.SIGN_TM), 9, 2) = '0229'\n"), "AND (\n"), "CAST(SUBSTR (TRIM(A1.SIGN_TM), 1, 4) AS INTEGER) MOD 400 = 0\n"), "OR (\n"), "CAST(SUBSTR (TRIM(A1.SIGN_TM), 1, 4) AS INTEGER) MOD 4 = 0\n"), "AND CAST(SUBSTR (TRIM(A1.SIGN_TM), 1, 4) AS INTEGER) MOD 100 <> 0\n"), ")\n"), ") THEN CAST(A1.SIGN_TM AS TIMESTAMP)\n"), "ELSE CAST(\n"), "CAST(\n"), "CAST('cDXtwdFyky' AS DATE FORMAT 'YYYYMMDD') AS DATE\n"), ") || ' 00:00:00' AS TIMESTAMP\n"), ")\n"), "END\n"), ")\n"), "END\n"), ") AS DATE FORMAT 'YYYYMMDD'\n"), "),\n"), "CAST(\n"), "(\n"), "CASE\n"), "WHEN A1.CLOSE_TM IS NULL\n"), "OR A1.CLOSE_TM = '' THEN CAST(\n"), "CAST(\n"), "CAST('ATkkIVQJZm' AS DATE FORMAT 'YYYYMMDD') AS DATE\n"), ") || ' 00:00:00' AS TIMESTAMP\n"), ")\n"), "WHEN CHARACTERS (TRIM(A1.CLOSE_TM)) <> 19\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 1, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 1, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 2, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 2, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 3, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 3, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 4, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 4, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 6, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 6, 1) > '1'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 7, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 7, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 9, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 9, 1) > '3'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 10, 1) < '0'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 10, 1) > '9'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 1, 4) = '0000'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 6, 2) = '00'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 9, 2) = '00'\n"), "OR SUBSTR (TRIM(A1.CLOSE_TM), 1, 1) = '0' THEN CAST(\n"), "CAST(\n"), "CAST('cDXtwdFyky' AS DATE FORMAT 'YYYYMMDD') AS DATE\n"), ") || ' 00:00:00' AS TIMESTAMP\n"), ")\n"), "ELSE (\n"), "CASE\n"), "WHEN (\n"), "CAST(SUBSTR (TRIM(A1.CLOSE_TM), 9, 2) AS INTEGER) < 29\n"), "AND SUBSTR (TRIM(A1.CLOSE_TM), 6, 2) = '02'\n"), ")\n"), "OR (\n"), "CAST(SUBSTR (TRIM(A1.CLOSE_TM), 9, 2) AS INTEGER) < 31\n"), "AND SUBSTR (TRIM(A1.CLOSE_TM), 6, 2) <> '02'\n"), "AND SUBSTR (TRIM(A1.CLOSE_TM), 6, 2) <= 12\n"), ")\n"), "OR (\n"), "CAST(SUBSTR (TRIM(A1.CLOSE_TM), 9, 2) AS INTEGER) = 31\n"), "AND SUBSTR (TRIM(A1.CLOSE_TM), 6, 2) IN ('01', '03', '05', '07', '08', '10', '12')\n"), ") THEN CAST(A1.CLOSE_TM AS TIMESTAMP)\n"), "WHEN SUBSTR (TRIM(A1.CLOSE_TM), 6, 2) || SUBSTR (TRIM(A1.CLOSE_TM), 9, 2) = '0229'\n"), "AND (\n"), "CAST(SUBSTR (TRIM(A1.CLOSE_TM), 1, 4) AS INTEGER) MOD 400 = 0\n"), "OR (\n"), "CAST(SUBSTR (TRIM(A1.CLOSE_TM), 1, 4) AS INTEGER) MOD 4 = 0\n"), "AND CAST(SUBSTR (TRIM(A1.CLOSE_TM), 1, 4) AS INTEGER) MOD 100 <> 0\n"), ")\n"), ") THEN CAST(A1.CLOSE_TM AS TIMESTAMP)\n"), "ELSE CAST(\n"), "CAST(\n"), "CAST('cDXtwdFyky' AS DATE FORMAT 'YYYYMMDD') AS DATE\n"), ") || ' 00:00:00' AS TIMESTAMP\n"), ")\n"), "END\n"), ")\n"), "END\n"), ") AS DATE FORMAT 'YYYYMMDD'\n"), ")\n"), "FROM\n"), "T01_PTY_SIGN_H_T1 A1\n"), "WHERE\n"), "A1.PARTY_SIGN_TYPE_CD = 'CD_021'\n"), "AND A1.ST_DT <= CAST('LDBCGtCIyo' AS DATE FORMAT 'YYYYMMDD')\n"), "AND A1.END_DT > CAST('LDBCGtCIyo' AS DATE FORMAT 'YYYYMMDD')\n"), "GROUP BY\n"), "1,\n"), "2,\n"), "3,\n"), "4");
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withTimeOut((long)(60000)));
}

internal virtual void testIssue2140() {
string sqlStr = "(((IIF((CASE WHEN 1 = 2 THEN 'a' ELSE 'b') = 'b'), 2, 3)))";
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression(sqlStr, true, (parser) => parser.withTimeOut((long)(10000)));
}

[Xunit.Fact]
public void __Upstream_78e46ee26fe19534()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testDeepFunctionParameters(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_999875315518c038()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIncreaseOfParseTime(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_457301d36627035e()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue1013(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6dfa7c820e2ea827()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue1013_2(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c46b399a2197b719()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue1013_3(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9ad153c3ce7c4060()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue1013_4(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ceeae6da2c7fb3b3()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue1103(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_14b186c16d508c9d()
{
        try
        {
            this.testIssue1983();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_d6bd4a07ae46b043()
{
        try
        {
            this.testIssue2140();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_68ae03e0c22903f7()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue235(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_58ca9763d2054399()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue496(), 10000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f03e11d122b13eb8()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue766(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab60b5b2dfdeea8a()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue766_2(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4ca4fee0682e0304()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testIssue856(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2a1520679180568a()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testNestedCaseWhenWithBracketsIssue1162(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b5c6a0e33464b624()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testNestedCaseWhenWithoutBracketsIssue1162(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f415e49c00368add()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testRecursiveBracketExpression(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b1f3a2b39b1431cf()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testRecursiveBracketExpressionIssue1019(), 2000000);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bfa94d4f707b82af()
{
        try
        {
            global::DripSharp.SqlTrellis.Tests.Support.RunWithTimeout(() => this.testRecursiveBracketExpressionIssue1019_2(), 2000000);
        }
        finally
        {
        }
}
}
