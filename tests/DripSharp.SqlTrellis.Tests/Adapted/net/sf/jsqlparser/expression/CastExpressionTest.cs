// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class CastExpressionTest {
public virtual void testCastToRowConstructorIssue1267() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CAST(ROW(dataid, value, calcMark) AS ROW(datapointid CHAR, value CHAR, calcMark CHAR))", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("CAST(ROW(dataid, value, calcMark) AS testcol)", true);
}

internal virtual void testDataKeywordIssue1969() {
string sqlStr = "SELECT * FROM myschema.myfunction('test'::data.text_not_null)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testImplicitCast() {
string sqlStr = "SELECT UUID '4ac7a9e9-607c-4c8a-84f3-843f0191e3fd'";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True((select.getSelectItem(0).getExpression() is global::DripSharp.SqlTrellis.Expression.CastExpression), null);
sqlStr = "SELECT DECIMAL(5,3) '3.2'";
select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True((select.getSelectItem(0).getExpression() is global::DripSharp.SqlTrellis.Expression.CastExpression), null);
}

internal virtual void testImplicitCastTimestampIssue1364() {
string sqlStr = "SELECT TIMESTAMP WITH TIME ZONE '2004-10-19 10:23:54+02'";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True((select.getSelectItem(0).getExpression() is global::DripSharp.SqlTrellis.Expression.CastExpression), null);
}

internal virtual void testImplicitCastDoublePrecisionIssue1344() {
string sqlStr = "SELECT double precision '1'";
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect select = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true)!);
global::DripSharp.Testing.JavaAssertions.True((select.getSelectItem(0).getExpression() is global::DripSharp.SqlTrellis.Expression.CastExpression), null);
}

public virtual void testCastToSigned() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS SIGNED) A");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS SIGNED INTEGER) A");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS UNSIGNED) A");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS UNSIGNED INTEGER) A");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT CAST(contact_id AS TIME WITHOUT TIME ZONE) A");
}

internal virtual void testDataTypeFrom() {
global::DripSharp.SqlTrellis.Expression.CastExpression.DataType float64 = global::DripSharp.SqlTrellis.Expression.CastExpression.DataType.from("FLOAT64");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Expression.CastExpression.DataType.FLOAT64, float64, null);
global::DripSharp.SqlTrellis.Expression.CastExpression.DataType float128 = global::DripSharp.SqlTrellis.Expression.CastExpression.DataType.from("FLOAT128");
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Expression.CastExpression.DataType.UNKNOWN, float128, null);
}

internal virtual void testParenthesisCastIssue1997() {
string sqlStr = "SELECT ((foo)::text = ANY((ARRAY['bar'])::text[]))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SELECT ((foo)::text = ANY((((ARRAY['bar'])))::text[]))";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a3258f8fe36b0401()
{
        try
        {
            this.testCastToRowConstructorIssue1267();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dc793b1701250dd2()
{
        try
        {
            this.testCastToSigned();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3aef60fdd7ce34e0()
{
        try
        {
            this.testDataKeywordIssue1969();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ef1740848f1ce81()
{
        try
        {
            this.testDataTypeFrom();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_35bb587497d0e32d()
{
        try
        {
            this.testImplicitCast();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6608c340feb58aa1()
{
        try
        {
            this.testImplicitCastDoublePrecisionIssue1344();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab277018b41193cb()
{
        try
        {
            this.testImplicitCastTimestampIssue1364();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c524556da9ee583c()
{
        try
        {
            this.testParenthesisCastIssue1997();
        }
        finally
        {
        }
}
}
