// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class SetStatementTest {
public virtual void testSimpleSet() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET statement_timeout = 0");
}

public virtual void testIssue373() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET deferred_name_resolution true");
}

public virtual void testIssue373_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET tester 5");
}

public virtual void testMultiValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET v = 1, c = 3");
}

public virtual void testListValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET v = 1, 3");
}

public virtual void tesTimeZone() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET LOCAL Time Zone 'UTC'");
}

public virtual void tesLocalWithEq() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET LOCAL cursor_tuple_fraction = 0.05");
}

public virtual void testValueOnIssue927() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SET standard_conforming_strings = on");
}

public virtual void testObject() {
global::DripSharp.SqlTrellis.Statement.SetStatement setStatement = new global::DripSharp.SqlTrellis.Statement.SetStatement();
setStatement.add("standard_conforming_strings", global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.StringValue("ON"))), false);
setStatement.withUseEqual(0, true).remove(0);
global::DripSharp.Testing.JavaAssertions.Equal(0, setStatement.getCount(), null);
setStatement.addKeyValuePairs(new global::DripSharp.SqlTrellis.Statement.SetStatement.NameExpr("test", global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(new global::DripSharp.SqlTrellis.Expression.StringValue("1"))), false));
global::DripSharp.Runtime.JavaCompat.ListGet(setStatement.getKeyValuePairs(), 0).setUseEqual(true);
global::DripSharp.Testing.JavaAssertions.Equal("test", global::DripSharp.Runtime.JavaCompat.ListGet(setStatement.getKeyValuePairs(), 0).getName(), null);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.ListGet(setStatement.getKeyValuePairs(), 0).isUseEqual(), null);
setStatement.clear();
global::DripSharp.Testing.JavaAssertions.Equal(0, setStatement.getCount(), null);
}

public virtual void testSettingUserVariable() {
string sqlStr = "set @Flag = 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "SET @@global.time_zone = '01:00'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testMultiPartVariables() {
string sqlStr = "set a.b.c=false";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_c335bd9cdb0ed29b()
{
        try
        {
            this.tesLocalWithEq();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a90da267e3a35b8a()
{
        try
        {
            this.tesTimeZone();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a66a0d792a89dd38()
{
        try
        {
            this.testIssue373();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_75a9b98ce30cc298()
{
        try
        {
            this.testIssue373_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5b1a475dee2ce13c()
{
        try
        {
            this.testListValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ac30318e0bfb2e76()
{
        try
        {
            this.testMultiPartVariables();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0cd9ac2f9a107cc8()
{
        try
        {
            this.testMultiValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f8062d3bb318ab52()
{
        try
        {
            this.testObject();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c2b696de22f403fc()
{
        try
        {
            this.testSettingUserVariable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_38f7cc0a13e28439()
{
        try
        {
            this.testSimpleSet();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0840e8786a0611dc()
{
        try
        {
            this.testValueOnIssue927();
        }
        finally
        {
        }
}
}
