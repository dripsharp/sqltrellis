// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ExpressionValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
private static readonly global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed EXPRESSIONS = global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.EXPRESSIONS);

public virtual void testAddition() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 1 + a", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testBitwiseAnd() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a & b", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testAndOr() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a AND b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a && b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a OR b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testBetween() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab WHERE a BETWEEN 1 AND 5", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testEquals() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a = b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a != b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a <> b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testParenthesis() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN ((a = b) OR b = c) AND (d <> a) AND d <> c THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testMatches() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM team WHERE team.search_column @@ to_tsquery('new & york & yankees')", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testNot() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN !a AND !b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testGreaterLower() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a > b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a >= b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a < b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT CASE WHEN a <= b THEN c ELSE d END", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testBitwiseLeftShift() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a << b", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testBitwiseOr() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a | b as a_or_b", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testBitwiseRightShift() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a >> b", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testBitwiseXor() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a ^ b as a_xor_b", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testConcat() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a || b FROM table", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testDivision() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a / b", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testJdbcParameter() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT ?, * FROM tab WHERE param = ?", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC));
}

public virtual void testJdbcNamedParameter() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT func (:param1, :param2) ", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC));
}

public virtual void testIntegerDivision() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 4 DIV 2", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testModulo() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 3 % 2", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testMultiplication() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 5 * 2", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testSignedExpression() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 5 * -2", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testSubtraction() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 5 - 3", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testIsNull() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE t.col IS NULL", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE t.col IS NOT NULL", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testIsUnknown() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE t.col IS UNKNOWN", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE t.col IS NOT UNKNOWN", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testLike() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE t.col LIKE '%search for%'", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE t.col NOT LIKE '%search for%'", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testExists() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tab t WHERE EXISTS (select 1 FROM tab2 t2 WHERE t2.id = t.id)", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testInterval() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT DATE_ADD(start_date, INTERVAL duration MINUTE) AS end_datetime FROM appointment", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT 5 + INTERVAL '3 days'", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testExtract() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT (EXTRACT(epoch FROM age(d1, d2)) / 2)::numeric", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testPostgreSQLRegExpCaseSensitiveMatch() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT a, b FROM foo WHERE a ~* '[help].*'", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testRlike() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM mytable WHERE first_name RLIKE '^Ste(v|ph)en$'", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testRegexpLike() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM mytable WHERE first_name REGEXP_LIKE '^Ste(v|ph)en$'", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testSimilarTo() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM mytable WHERE (w_id NOT SIMILAR TO '/foo/__/bar/(left|right)/[0-9]{4}-[0-9]{2}-[0-9]{2}(/[0-9]*)?')", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testOneColumnFullTextSearchMySQL() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT MATCH (col1) AGAINST ('test' IN NATURAL LANGUAGE MODE) relevance FROM tbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testAnalyticFunctionFilter() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT COUNT(*) FILTER (WHERE name = 'Raj') OVER (PARTITION BY name ) FROM table", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testAtTimeZoneExpression() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT DATE(date1 AT TIME ZONE 'UTC' AT TIME ZONE 'australia/sydney') AS another_date FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testJsonFunctionExpression() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT json_array(null on null) FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT json_array(null null on null) FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT json_array(null, null null on null) FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT json_object(null on null) FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT json_object() FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testJsonAggregartFunctionExpression() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT JSON_ARRAYAGG( a FORMAT JSON ABSENT ON NULL ) FILTER( WHERE name = 'Raj' ) OVER( PARTITION BY name ) FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT JSON_OBJECT( KEY 'foo' VALUE bar FORMAT JSON, 'foo':bar, 'foo':bar ABSENT ON NULL) FROM mytbl", 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.ExpressionValidatorTest.EXPRESSIONS);
}

public virtual void testConnectedByRootOperator() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT CONNECT_BY_ROOT last_name as name", ", salary "), "FROM employees "), "WHERE department_id = 110 "), "CONNECT BY PRIOR employee_id = manager_id"), 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

[Xunit.Fact]
public void __Upstream_415f5c4c04000fdd()
{
        try
        {
            this.testAddition();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b782789b086ba266()
{
        try
        {
            this.testAnalyticFunctionFilter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_63e8f696b32fff7f()
{
        try
        {
            this.testAndOr();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_61375066a64d0874()
{
        try
        {
            this.testAtTimeZoneExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f7b80880863c0db6()
{
        try
        {
            this.testBetween();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_732f73f339c6a473()
{
        try
        {
            this.testBitwiseAnd();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1d5643acc4d5c978()
{
        try
        {
            this.testBitwiseLeftShift();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0f77d5b8128710af()
{
        try
        {
            this.testBitwiseOr();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d62b9e675d01cf4c()
{
        try
        {
            this.testBitwiseRightShift();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c375515c78dbf1f3()
{
        try
        {
            this.testBitwiseXor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f447243b0ca8f1c0()
{
        try
        {
            this.testConcat();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4dee386f164997c7()
{
        try
        {
            this.testConnectedByRootOperator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_31ad7c3e0337173b()
{
        try
        {
            this.testDivision();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ccd1a9c3e3391985()
{
        try
        {
            this.testEquals();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f7e9c9119423ee78()
{
        try
        {
            this.testExists();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f0519d88ad46980f()
{
        try
        {
            this.testExtract();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_eee97d56b14b543e()
{
        try
        {
            this.testGreaterLower();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8033b81d489be3ca()
{
        try
        {
            this.testIntegerDivision();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1cb8fcfb971f7211()
{
        try
        {
            this.testInterval();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d6e0abacb1da8777()
{
        try
        {
            this.testIsNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_51cfa675c19f45ff()
{
        try
        {
            this.testIsUnknown();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d4a3780c6b6dad2f()
{
        try
        {
            this.testJdbcNamedParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aa72d818ef99c6ab()
{
        try
        {
            this.testJdbcParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_606f2b93910d3bd4()
{
        try
        {
            this.testJsonAggregartFunctionExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2973bf38db60670()
{
        try
        {
            this.testJsonFunctionExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a471e1e76d0beeba()
{
        try
        {
            this.testLike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_61b7afc8a3bc9a56()
{
        try
        {
            this.testMatches();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7f2d9f30edd200fc()
{
        try
        {
            this.testModulo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8fb9411c67710108()
{
        try
        {
            this.testMultiplication();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cba00a3f2033bf4a()
{
        try
        {
            this.testNot();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8334a06dfbedec96()
{
        try
        {
            this.testOneColumnFullTextSearchMySQL();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_734dc29a5ce4422c()
{
        try
        {
            this.testParenthesis();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d3fb902038aae5e8()
{
        try
        {
            this.testPostgreSQLRegExpCaseSensitiveMatch();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1bece13b7afbf3a6()
{
        try
        {
            this.testRegexpLike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b87fd2dde74a40dc()
{
        try
        {
            this.testRlike();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b658e624d8d50b55()
{
        try
        {
            this.testSignedExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ca005a3d75f40ba7()
{
        try
        {
            this.testSimilarTo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b6777742beac244()
{
        try
        {
            this.testSubtraction();
        }
        finally
        {
        }
}
}
