// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser;

public class CCJSqlParserUtilTest {
private const string INVALID_SQL = "SELECT * FROM TABLE_1 t1\nWHERE\n(((t1.COL1 = 'VALUE2' )\nAND (t1.CAL2 = 'VALUE2' ))\nAND (((1 = 1 )\nAND ((((((t1.id IN (940550 ,940600 ,940650 ,940700 ,940750 ,940800 ,940850 ,940900 ,940950 ,941000 ,941050 ,941100 ,941150 ,941200 ,941250 ,941300 ,941350 ,941400 ,941450 ,941500 ,941550 ,941600 ,941650 ,941700 ,941750 ,941800 ,941850 ,941900 ,941950 ,942000 ,942050 ,942100 ,942150 ,942200 ,942250 ,942300 ,942350 ,942400 ,942450 ,942500 ,942550 ,942600 ,942650 ,942700 ,942750 ,942800 ,942850 ,942900 ,942950 ,943000 ,943050 ,943100 ,943150 ,943200 ,943250 ,943300 ,943350 ,943400 ,943450 ,943500 ,943550 ,943600 ,943650 ,943700 ,943750 ,943800 ,943850 ,943900 ,943950 ,944000 ,944050 ,944100 ,944150 ,944200 ,944250 ,944300 ,944350 ,944400 ,944450 ,944500 ,944550 ,944600 ,944650 ,944700 ,944750 ,944800 ,944850 ,944900 ,944950 ,945000 ,945050 ,945100 ,945150 ,945200 ,945250 ,945300 ))\nOR (t1.id IN (945350 ,945400 ,945450 ,945500 ,945550 ,945600 ,945650 ,945700 ,945750 ,945800 ,945850 ,945900 ,945950 ,946000 ,946050 ,946100 ,946150 ,946200 ,946250 ,946300 ,946350 ,946400 ,946450 ,946500 ,946550 ,946600 ,946650 ,946700 ,946750 ,946800 ,946850 ,946900 ,946950 ,947000 ,947050 ,947100 ,947150 ,947200 ,947250 ,947300 ,947350 ,947400 ,947450 ,947500 ,947550 ,947600 ,947650 ,947700 ,947750 ,947800 ,947850 ,947900 ,947950 ,948000 ,948050 ,948100 ,948150 ,948200 ,948250 ,948300 ,948350 ,948400 ,948450 ,948500 ,948550 ,948600 ,948650 ,948700 ,948750 ,948800 ,948850 ,948900 ,948950 ,949000 ,949050 ,949100 ,949150 ,949200 ,949250 ,949300 ,949350 ,949400 ,949450 ,949500 ,949550 ,949600 ,949650 ,949700 ,949750 ,949800 ,949850 ,949900 ,949950 ,950000 ,950050 ,950100 )))\nOR (t1.id IN (950150 ,950200 ,950250 ,950300 ,950350 ,950400 ,950450 ,950500 ,950550 ,950600 ,950650 ,950700 ,950750 ,950800 ,950850 ,950900 ,950950 ,951000 ,951050 ,951100 ,951150 ,951200 ,951250 ,951300 ,951350 ,951400 ,951450 ,951500 ,951550 ,951600 ,951650 ,951700 ,951750 ,951800 ,951850 ,951900 ,951950 ,952000 ,952050 ,952100 ,952150 ,952200 ,952250 ,952300 ,952350 ,952400 ,952450 ,952500 ,952550 ,952600 ,952650 ,952700 ,952750 ,952800 ,952850 ,952900 ,952950 ,953000 ,953050 ,953100 ,953150 ,953200 ,953250 ,953300 ,953350 ,953400 ,953450 ,953500 ,953550 ,953600 ,953650 ,953700 )))\nOR (t1.id IN (953750 ,953800 ,953850 ,953900 ,953950 ,954000 ,954050 ,954100 ,954150 ,954200 ,954250 ,954300 ,954350 ,954400 ,954450 ,954500 ,954550 ,954600 ,954650 ,954700 ,954750 ,954800 ,954850 ,954900 ,954950 ,955000 ,955050 ,955100 ,955150 ,955200 ,955250 ,955300 ,955350 ,955400 ,955450 ,955500 ,955550 ,955600 ,955650 ,955700 ,955750 ,955800 ,955850 ,955900 ,955950 ,956000 ,956050 ,956100 ,956150 ,956200 ,956250 ,956300 ,956350 ,956400 ,956450 ,956500 ,956550 ,956600 ,956650 ,956700 ,956750 ,956800 ,956850 ,956900 ,956950 ,957000 ,957050 ,957100 ,957150 ,957200 ,957250 ,957300 )))\nOR (t1.id IN (944100, 944150, 944200, 944250, 944300, 944350, 944400, 944450, 944500, 944550, 944600, 944650, 944700, 944750, 944800, 944850, 944900, 944950, 945000 )))\nOR (t1.id IN (957350 ,957400 ,957450 ,957500 ,957550 ,957600 ,957650 ,957700 ,957750 ,957800 ,957850 ,957900 ,957950 ,958000 ,958050 ,958100 ,958150 ,958200 ,958250 ,958300 ,958350 ,958400 ,958450 ,958500 ,958550 ,958600 ,958650 ,958700 ,958750 ,958800 ,958850 ,958900 ,958950 ,959000 ,959050 ,959100 ,959150 ,959200 ,959250 ,959300 ,959350 ,959400 ,959450 ,959500 ,959550 ,959600 ,959650 ,959700 ,959750 ,959800 ,959850 ,959900 ,959950 ,960000 ,960050 ,960100 ,960150 ,960200 ,960250 ,960300 ,960350 ,960400 ,960450 ,960500 ,960550 ,960600 ,960650 ,960700 ,960750 ,960800 ,960850 ,960900 ,960950 ,961000 ,961050 ,961100 ,961150 ,961200 ,961250 ,961300 ,961350 ,961400 ,961450 ,961500 ,961550 ,961600 ,961650 ,961700 ,961750 ,961800 ,961850 ,961900 ,961950 ,962000 ,962050 ,962100 ))))\nOR (t1.id IN (962150 ,962200 ,962250 ,962300 ,962350 ,962400 ,962450 ,962500 ,962550 ,962600 ,962650 ,962700 ,962750 ,962800 ,962850 ,962900 ,962950 ,963000 ,963050 ,963100 ,963150 ,963200 ,963250 ,963300 ,963350 ,963400 ,963450 ,963500 ,963550 ,963600 ,963650 ,963700 ,963750 ,963800 ,963850 ,963900 ,963950 ,964000 ,964050 ,964100 ,964150 ,964200 ,964250 ,964300 ,964350 ,964400 ,964450 ,964500 ,964550 ,964600 ,964650 ,964700 ,964750 ,964800 ,964850 ,964900 ,964950 ,965000 ,965050 ,965100 ,965150 ,965200 ,965250 ,965300 ,965350 ,965400 ,965450 ,965500 ))))\nAND t1.COL3 IN (\n    SELECT\n    t2.COL3\n    FROM\n    TABLE_6 t6,\n    TABLE_1 t5,\n    TABLE_4 t4,\n    TABLE_3 t3,\n    TABLE_1 t2\n    WHERE\n    (((((((t5.CAL3 = T6.id)\n    AND (t5.CAL5 = t6.CAL5))\n    AND (t5.CAL1 = t6.CAL1))\n    AND (t3.CAL1 IN (108500)))\n    AND (t5.id = t2.id))\n    AND NOT ((t6.CAL6 IN ('VALUE'))))\n    AND ((t2.id = t3.CAL2)\n    AND (t4.id = t3.CAL3))))\n )) \nORDER BY\nt1.id ASC";

public virtual void testParseExpression() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a+b");
global::DripSharp.Testing.JavaAssertions.Equal("a + b", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
global::DripSharp.Testing.JavaAssertions.True((result is global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition), null);
global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition add = (global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Addition)(result!);
global::DripSharp.Testing.JavaAssertions.True((add.getLeftExpression() is global::DripSharp.SqlTrellis.Schema.Column), null);
global::DripSharp.Testing.JavaAssertions.True((add.getRightExpression() is global::DripSharp.SqlTrellis.Schema.Column), null);
}

public virtual void testParseExpression2() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("2*(a+6.0)");
global::DripSharp.Testing.JavaAssertions.Equal("2 * (a + 6.0)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
global::DripSharp.Testing.JavaAssertions.True((result is global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Multiplication), null);
global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Multiplication mult = (global::DripSharp.SqlTrellis.Expression.Operators.Arithmetic.Multiplication)(result!);
global::DripSharp.Testing.JavaAssertions.True((mult.getLeftExpression() is global::DripSharp.SqlTrellis.Expression.LongValue), null);
global::DripSharp.Testing.JavaAssertions.True((mult.getRightExpression() is global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>), null);
}

public virtual void testParseExpressionNonPartial() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a+", false), null);
}

public virtual void testParseExpressionFromStringFail() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("whatever$"), null);
}

public virtual void testParseExpressionFromRaderFail() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(new global::System.IO.StringReader("whatever$")), null);
}

public virtual void testParseExpressionNonPartial2() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a+", true);
global::DripSharp.Testing.JavaAssertions.Equal("a", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseCondExpression() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("a+b>5 and c<3");
global::DripSharp.Testing.JavaAssertions.Equal("a + b > 5 AND c < 3", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseCondExpressionFail() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(";"), null);
}

public virtual void testParseFromStreamFail() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.Runtime.JavaCompat.NewMemoryStream(global::DripSharp.Runtime.JavaCompat.StringGetBytes("BLA", global::DripSharp.Runtime.JavaStandardCharsets.UTF8))), null);
}

public virtual void testParseFromStreamWithEncodingFail() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.Runtime.JavaCompat.NewMemoryStream(global::DripSharp.Runtime.JavaCompat.StringGetBytes("BLA", global::DripSharp.Runtime.JavaStandardCharsets.UTF8)), global::DripSharp.Runtime.JavaCompat.CharsetName(global::DripSharp.Runtime.JavaStandardCharsets.UTF8)), null);
}

public virtual void testParseCondExpressionNonPartial() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("x=92 and y=29", false);
global::DripSharp.Testing.JavaAssertions.Equal("x = 92 AND y = 29", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseCondExpressionNonPartial2() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("x=92 lasd y=29", false), null);
}

public virtual void testParseCondExpressionPartial2() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("x=92 lasd y=29", true);
global::DripSharp.Testing.JavaAssertions.Equal("x = 92", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseCondExpressionIssue471() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("(SSN,SSM) IN ('11111111111111', '22222222222222')");
global::DripSharp.Testing.JavaAssertions.Equal("(SSN, SSM) IN ('11111111111111', '22222222222222')", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseStatementsIssue691() {
global::DripSharp.SqlTrellis.Statement.Statements result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select * from dual;\n", "\n"), "select\n"), "*\n"), "from\n"), "dual;\n"), "\n"), "select *\n"), "from dual;"));
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM dual;\n", "SELECT * FROM dual;\n"), "SELECT * FROM dual;\n"), result.ToString(), null);
}

public virtual void testStreamStatementsIssue777() {
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Statement> list = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Statement>();
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.streamStatements(new Anonymous_206_43(list), global::DripSharp.Runtime.JavaCompat.NewMemoryStream(global::DripSharp.Runtime.JavaCompat.StringGetBytes(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select * from dual;\n", "select\n"), "*\n"), "from\n"), "dual;\n"), "\n"), "-- some comment\n"), "select *\n"), "from dual;"), global::DripSharp.Runtime.JavaStandardCharsets.UTF8)), "UTF-8");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.CollectionCount(list), 3, null);
}

private sealed class Anonymous_206_43 : global::DripSharp.SqlTrellis.Parser.StatementListener {
private readonly global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Statement> __capture_0;

public Anonymous_206_43(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Statement> __capture_0) {
this.__capture_0 = __capture_0;
}

public void accept(global::DripSharp.SqlTrellis.Statement.Statement statement) {
global::DripSharp.Runtime.JavaCompat.Add(this.__capture_0, statement);
}
}

public virtual void testParseStatementsFail() {
string sqlStr = "select * from dual;WHATEVER!!";
global::DripSharp.Testing.JavaAssertions.DoesNotThrow(() => {
global::DripSharp.SqlTrellis.Statement.Statements statements = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(sqlStr, (parser) => parser.withErrorRecovery(true).withUnsupportedStatements(true));
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(statements), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.Select.PlainSelect>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 0), null);
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Statement.UnsupportedStatement>(global::DripSharp.Runtime.JavaCompat.ListGet(statements, 1), null);
}, null);
}

public virtual void testParseASTFail() {
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseAST("select * from dual;WHATEVER!!"), null);
}

public virtual void testParseStatementsIssue691_2() {
global::DripSharp.SqlTrellis.Statement.Statements result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(global::DripSharp.Runtime.JavaCompat.Concat("select * from dual;\n", "---test"));
global::DripSharp.Testing.JavaAssertions.Equal("SELECT * FROM dual;\n", result.ToString(), null);
}

public virtual void testParseStatementIssue742() {
global::DripSharp.SqlTrellis.Statement.Statements result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatements(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE `table_name` (\n", "  `id` bigint(20) NOT NULL AUTO_INCREMENT,\n"), "  `another_column_id` bigint(20) NOT NULL COMMENT 'column id as sent by SYSTEM',\n"), "  PRIMARY KEY (`id`),\n"), "  UNIQUE KEY `uk_another_column_id` (`another_column_id`)\n"), ")"));
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE `table_name` (`id` bigint (20) NOT NULL AUTO_INCREMENT, `another_column_id` ", "bigint (20) NOT NULL COMMENT 'column id as sent by SYSTEM', PRIMARY KEY (`id`), UNIQUE KEY `uk_another_column_id` "), "(`another_column_id`));\n"), result.ToString(), null);
}

public virtual void testParseExpressionIssue982() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("tab.col");
global::DripSharp.Testing.JavaAssertions.Equal("tab.col", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseExpressionWithBracketsIssue1159() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("[travel_data].[travel_id]", false, (parser) => parser.withSquareBracketQuotation(true));
global::DripSharp.Testing.JavaAssertions.Equal("[travel_data].[travel_id]", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseExpressionWithBracketsIssue1159_2() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("[travel_data].[travel_id]", false, (parser) => parser.withSquareBracketQuotation(true));
global::DripSharp.Testing.JavaAssertions.Equal("[travel_data].[travel_id]", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testNestingDepth() {
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.getNestingDepth("SELECT concat(concat('A','B'),'B') FROM mytbl"), null);
global::DripSharp.Testing.JavaAssertions.Equal(20, global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.getNestingDepth("concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat(concat('A','B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B'),'B') FROM mytbl"), null);
global::DripSharp.Testing.JavaAssertions.Equal(4, global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.getNestingDepth(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "-- MERGE 1\n"), "MERGE INTO cfe.impairment imp\n"), "    USING ( WITH x AS (\n"), "                    SELECT  a.id_instrument\n"), "                            , a.id_currency\n"), "                            , a.id_instrument_type\n"), "                            , b.id_portfolio\n"), "                            , c.attribute_value product_code\n"), "                            , t.valid_date\n"), "                            , t.ccf\n"), "                    FROM cfe.instrument a\n"), "                        INNER JOIN cfe.impairment b\n"), "                            ON a.id_instrument = b.id_instrument\n"), "                        LEFT JOIN cfe.instrument_attribute c\n"), "                            ON a.id_instrument = c.id_instrument\n"), "                                AND c.id_attribute = 'product'\n"), "                        INNER JOIN cfe.ext_ccf t\n"), "                            ON ( a.id_currency LIKE t.id_currency )\n"), "                                AND ( a.id_instrument_type LIKE t.id_instrument_type )\n"), "                                AND ( b.id_portfolio LIKE t.id_portfolio\n"), "                                        OR ( b.id_portfolio IS NULL\n"), "                                                AND t.id_portfolio = '%' ) )\n"), "                                AND ( c.attribute_value LIKE t.product_code\n"), "                                        OR ( c.attribute_value IS NULL\n"), "                                                AND t.product_code = '%' ) ) )\n"), "SELECT /*+ PARALLEL */ *\n"), "            FROM x x1\n"), "            WHERE x1.valid_date = ( SELECT max\n"), "                                    FROM x\n"), "                                    WHERE id_instrument = x1.id_instrument ) ) s\n"), "        ON ( imp.id_instrument = s.id_instrument )\n"), "WHEN MATCHED THEN\n"), "    UPDATE SET  imp.ccf = s.ccf\n"), ";")), null);
}

public virtual void testParseStatementIssue1250() {
global::DripSharp.SqlTrellis.Statement.Statement result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("Select test.* from (Select * from sch.PERSON_TABLE // root test\n) as test");
global::DripSharp.Testing.JavaAssertions.Equal("SELECT test.* FROM (SELECT * FROM sch.PERSON_TABLE) AS test", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testCondExpressionIssue1482() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("test_table_enum.f1_enum IN ('TEST2'::test.test_enum)", false);
global::DripSharp.Testing.JavaAssertions.Equal("test_table_enum.f1_enum IN ('TEST2'::test.test_enum)", global::DripSharp.Runtime.JavaCompat.StringValueOf(expr), null);
}

public virtual void testTableStatementIssue1836() {
global::DripSharp.SqlTrellis.Statement.Select.TableStatement expr = (global::DripSharp.SqlTrellis.Statement.Select.TableStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("TABLE columns ORDER BY column_name LIMIT 10 OFFSET 10")!);
global::DripSharp.Testing.JavaAssertions.Equal("TABLE columns ORDER BY column_name LIMIT 10 OFFSET 10", expr.ToString(), null);
}

public virtual void testCondExpressionIssue1482_2() {
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression("test_table_enum.f1_enum IN ('TEST2'::test.\"test_enum\")", false);
global::DripSharp.Testing.JavaAssertions.Equal("test_table_enum.f1_enum IN ('TEST2'::test.\"test_enum\")", global::DripSharp.Runtime.JavaCompat.StringValueOf(expr), null);
}

public virtual void testParserInterruptedByTimeout() {
global::DripSharp.SqlTrellis.Test.MemoryLeakVerifier verifier = new global::DripSharp.SqlTrellis.Test.MemoryLeakVerifier();
int parallelThreads = (global::System.Environment.ProcessorCount + 1);
global::DripSharp.Runtime.JavaExecutorService executorService = new global::DripSharp.Runtime.JavaExecutorService(parallelThreads);
global::DripSharp.Runtime.JavaExecutorService timeOutService = new global::DripSharp.Runtime.JavaExecutorService(1);
for (int i = 0; (i < parallelThreads); i++) {
executorService.Submit(() => {
try {
global::DripSharp.SqlTrellis.Parser.CCJSqlParser parser = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.newParser(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtilTest.INVALID_SQL).withAllowComplexParsing(true);
verifier.addObject(parser);
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseStatement(parser, timeOutService);
} catch (global::DripSharp.SqlTrellis.JSQLParserException) {}
});
}
timeOutService.ShutdownNow();
executorService.Shutdown();
global::DripSharp.Testing.JavaAssertions.DoesNotThrow(() => {
executorService.AwaitTermination((long)(20), global::DripSharp.Runtime.JavaTimeUnit.SECONDS);
}, null);
verifier.assertGarbageCollected();
}

public virtual void testTimeOutIssue1582() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "select\n"), "  t0.operatienr\n"), "  , case\n"), "        when\n"), "            case when (t0.vc_begintijd_operatie is null or lpad((extract('hours' into t0.vc_begintijd_operatie::timestamp))::text,2,'0') ||':'|| lpad(extract('minutes' from t0.vc_begintijd_operatie::timestamp)::text,2,'0') = '00:00') then null\n"), "                 else (greatest(((extract('hours' into (t0.vc_eindtijd_operatie::timestamp-t0.vc_begintijd_operatie::timestamp))*60 + extract('minutes' from (t0.vc_eindtijd_operatie::timestamp-t0.vc_begintijd_operatie::timestamp)))/60)::numeric(12,2),0))*60\n"), "        end = 0 then null\n"), "            else '25. Meer dan 4 uur'\n"), "        end\n"), "      as snijtijd_interval");
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
try {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.GetCause(ex)! is global::System.TimeoutException), null);
global::System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw(ex);
throw new global::System.InvalidOperationException("unreachable");
}
}, null);
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
try {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => {
parser.withTimeOut((long)(60000));
parser.withAllowComplexParsing(false);
});
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
global::DripSharp.Testing.JavaAssertions.False((global::DripSharp.Runtime.JavaCompat.GetCause(ex)! is global::System.TimeoutException), null);
global::System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw(ex);
throw new global::System.InvalidOperationException("unreachable");
}
}, null);
}

internal virtual void testComplexIssue1792() {
global::DripSharp.Runtime.JavaExecutorService executorService = new global::DripSharp.Runtime.JavaExecutorService();
(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.LOGGER).SetLevel(global::DripSharp.Runtime.JavaLogLevel.All);
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
try {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtilTest.INVALID_SQL, executorService, (parser) => {
parser.withTimeOut((long)(10000));
parser.withAllowComplexParsing(false);
});
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
global::DripSharp.Testing.JavaAssertions.False((global::DripSharp.Runtime.JavaCompat.GetCause(ex)! is global::System.TimeoutException), null);
global::System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw(ex);
throw new global::System.InvalidOperationException("unreachable");
}
}, null);
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
try {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtilTest.INVALID_SQL, executorService, (parser) => {
parser.withTimeOut((long)(1000));
parser.withAllowComplexParsing(true);
});
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
global::DripSharp.Testing.JavaAssertions.True((global::DripSharp.Runtime.JavaCompat.GetCause(ex)! is global::System.TimeoutException), null);
global::System.Runtime.ExceptionServices.ExceptionDispatchInfo.Throw(ex);
throw new global::System.InvalidOperationException("unreachable");
}
}, null);
executorService.ShutdownNow();
(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.LOGGER).SetLevel(global::DripSharp.Runtime.JavaLogLevel.Off);
}

internal virtual void testUnbalancedPosition() {
string sqlStr = "SELECT * from ( test ";
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select\n", " concat('{','\"dffs\":\"',if(dffs is null,'',cast(dffs as string),'\",\"djr\":\"',if(djr is null,'',cast(djr as string),'\",\"djrq\":\"',if(djrq is null,'',cast(djrq as string),'\",\"thjssj\":\"',if(thjssj is null,'',cast(thjssj as string),'\",\"thkssj\":\"',if(thkssj is null,'',cast(thkssj as string),'\",\"sjc\":\"',if(sjc is null,'',cast(sjc as string),'\",\"ldhm\":\"',if(ldhm is null,'',cast(ldhm as string),'\",\"lxdh\":\"',if(lxdh is null,'',cast(lxdh as string),'\",\"md\":\"',if(md is null,'',cast(md as string),'\",\"nr\":\"',if(nr is null,'',cast(nr as string),'\",\"nrfl\":\"',if(nrfl is null,'',cast(nrfl as string),'\",\"nrwjid\":\"',if(nrwjid is null,'',cast(nrwjid as string),'\",\"sfbm\":\"',if(sfbm is null,'',cast(sfbm as string),'\",\"sjly\":\"',if(sjly is null,'',cast(sjly as string),'\",\"wtsd\":\"',if(wtsd is null,'',cast(wtsd as string),'\",\"xb\":\"',if(xb is null,'',cast(xb as string),'\",\"xfjbh\":\"',if(xfjbh is null,'',cast(xfjbh as string),'\",\"xfjid\":\"',if(xfjid is null,'',cast(xfjid as string),'\",\"xm\":\"',if(xm is null,'',cast(xm as string),'\",\"zhut\":\"',if(zhut is null,'',cast(zhut as string),'\",\"zt\":\"',if(zt is null,'',cast(zt as string),'\"}')\n"), " from tab");
global::DripSharp.Testing.JavaAssertions.Equal(1122, global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.getUnbalancedPosition(sqlStr), null);
}

internal virtual void testParseEmpty() {
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(""), null);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse((string)default!), null);
}

internal virtual void testSingleStatementWithEmptyLines() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("update shop_info set title=?,\n", "\n"), "\n"), "\n"), "content='abc\n"), "\n"), "\n"), "\n"), "def'\n"), "where id=?");
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.sanitizeSingleSql(sqlStr));
global::DripSharp.SqlTrellis.Test.TestUtils.assertStatementCanBeDeparsedAs(statement, global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("update shop_info set title=?,\n", "content='abc\n"), "\n"), "\n"), "\n"), "def'\n"), "where id=?"), true);
}

[Xunit.Fact]
public void __Upstream_098627dcc745ce7c()
{
        try
        {
            this.testComplexIssue1792();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_808166b33210e542()
{
        try
        {
            this.testCondExpressionIssue1482();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9985e9e2910b31b9()
{
        try
        {
            this.testCondExpressionIssue1482_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_942bc6edc2e3241c()
{
        try
        {
            this.testNestingDepth();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_03dc3deab9cd71e6()
{
        try
        {
            this.testParseASTFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_01ac03296251076b()
{
        try
        {
            this.testParseCondExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5605a81e605925fd()
{
        try
        {
            this.testParseCondExpressionFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cf9c9a81b47be954()
{
        try
        {
            this.testParseCondExpressionIssue471();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4c5239acecdc7359()
{
        try
        {
            this.testParseCondExpressionNonPartial();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_11e60f8aee4d118c()
{
        try
        {
            this.testParseCondExpressionNonPartial2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7deb825b9ced7efd()
{
        try
        {
            this.testParseCondExpressionPartial2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_88cd821f9b9ed292()
{
        try
        {
            this.testParseEmpty();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_17cb723c7128241b()
{
        try
        {
            this.testParseExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_32edeffca57ee73a()
{
        try
        {
            this.testParseExpression2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fade8e17452e62da()
{
        try
        {
            this.testParseExpressionFromRaderFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a250753b9ea39c14()
{
        try
        {
            this.testParseExpressionFromStringFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7f12fd6272158876()
{
        try
        {
            this.testParseExpressionIssue982();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5b48f7cb4ac96248()
{
        try
        {
            this.testParseExpressionNonPartial();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e56c1466fab8229f()
{
        try
        {
            this.testParseExpressionNonPartial2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b6d32e31094d229a()
{
        try
        {
            this.testParseExpressionWithBracketsIssue1159();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39fb9ddb93fae799()
{
        try
        {
            this.testParseExpressionWithBracketsIssue1159_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4ab764697d286191()
{
        try
        {
            this.testParseFromStreamFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c1227965b8b077b()
{
        try
        {
            this.testParseFromStreamWithEncodingFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_74aa3ad14098b519()
{
        try
        {
            this.testParseStatementIssue1250();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_003d9a570714409f()
{
        try
        {
            this.testParseStatementIssue742();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2a95324efb059801()
{
        try
        {
            this.testParseStatementsFail();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f8fa58e1d78edf5f()
{
        try
        {
            this.testParseStatementsIssue691();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0684dcba80e017d8()
{
        try
        {
            this.testParseStatementsIssue691_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0c92a71876351af2()
{
        try
        {
            this.testParserInterruptedByTimeout();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_236fed5ad4ee539d()
{
        try
        {
            this.testSingleStatementWithEmptyLines();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3ef2c597feb85d8c()
{
        try
        {
            this.testStreamStatementsIssue777();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ad50f40d09ee36ee()
{
        try
        {
            this.testTableStatementIssue1836();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c12936b31dc8dc99()
{
        try
        {
            this.testTimeOutIssue1582();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_41ec7d2fe90cce84()
{
        try
        {
            this.testUnbalancedPosition();
        }
        finally
        {
        }
}
}
