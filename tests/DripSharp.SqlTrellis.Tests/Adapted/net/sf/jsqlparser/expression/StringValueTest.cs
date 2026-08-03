// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class StringValueTest {
public virtual void testGetValue() {
global::DripSharp.SqlTrellis.Expression.StringValue instance = new global::DripSharp.SqlTrellis.Expression.StringValue("'*'");
string expResult = "*";
string result = instance.getValue();
global::DripSharp.Testing.JavaAssertions.Equal(expResult, result, null);
}

public virtual void testGetValue2_issue329() {
global::DripSharp.SqlTrellis.Expression.StringValue instance = new global::DripSharp.SqlTrellis.Expression.StringValue("*");
string expResult = "*";
string result = instance.getValue();
global::DripSharp.Testing.JavaAssertions.Equal(expResult, result, null);
}

public virtual void testGetNotExcapedValue() {
global::DripSharp.SqlTrellis.Expression.StringValue instance = new global::DripSharp.SqlTrellis.Expression.StringValue("'*''*'");
string expResult = "*'*";
string result = instance.getNotExcapedValue();
global::DripSharp.Testing.JavaAssertions.Equal(expResult, result, null);
}

public virtual void testPrefixes() {
this.checkStringValue("E'test'", "test", "E");
this.checkStringValue("'test'", "test", (string)default!);
}

private void checkStringValue(string original, string expectedValue, string expectedPrefix) {
global::DripSharp.SqlTrellis.Expression.StringValue v = new global::DripSharp.SqlTrellis.Expression.StringValue(original);
global::DripSharp.Testing.JavaAssertions.Equal(expectedValue, v.getValue(), null);
global::DripSharp.Testing.JavaAssertions.Equal(expectedPrefix, v.getPrefix(), null);
}

public virtual void testIssue1566EmptyStringValue() {
global::DripSharp.SqlTrellis.Expression.StringValue v = new global::DripSharp.SqlTrellis.Expression.StringValue("'");
global::DripSharp.Testing.JavaAssertions.Equal("'", v.getValue(), null);
}

public virtual void testOracleAlternativeQuoting() {
string sqlStr = "COMMENT ON COLUMN EMP.NAME IS q'{Na'm\\e}'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "COMMENT ON COLUMN EMP.NAME IS q'(Na'm\\e)'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "COMMENT ON COLUMN EMP.NAME IS q'[Na'm\\e]'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "COMMENT ON COLUMN EMP.NAME IS q''Na'm\\e]''";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "select q'{Its good!}' from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "select q'{It's good!}' from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testParseInput_BYTEA() {
string sqlStr = "VALUES (X'', X'01FF', X'01 bc 2a', X'01' '02')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_eb47d641c0795d1b()
{
        try
        {
            this.testGetNotExcapedValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c14c2b0b86bc7086()
{
        try
        {
            this.testGetValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a1f8d609a32e8c6a()
{
        try
        {
            this.testGetValue2_issue329();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9e6106f2c5045917()
{
        try
        {
            this.testIssue1566EmptyStringValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7969de3b401a0cfe()
{
        try
        {
            this.testOracleAlternativeQuoting();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_210a36bb73a098ea()
{
        try
        {
            this.testParseInput_BYTEA();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0fd3cbda04ac06cc()
{
        try
        {
            this.testPrefixes();
        }
        finally
        {
        }
}
}
