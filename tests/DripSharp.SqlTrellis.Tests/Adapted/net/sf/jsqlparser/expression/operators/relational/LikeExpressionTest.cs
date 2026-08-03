// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class LikeExpressionTest {
public virtual void testLikeNotIssue660() {
global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression instance = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression();
global::DripSharp.Testing.JavaAssertions.False(instance.isNot(), null);
global::DripSharp.Testing.JavaAssertions.True(instance.withNot(true).isNot(), null);
}

public virtual void testSetEscapeAndGetStringExpression() {
global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression instance = (global::DripSharp.SqlTrellis.Expression.Operators.Relational.LikeExpression)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("name LIKE 'J%$_%'")!);
global::DripSharp.SqlTrellis.Expression.Expression instance2 = new global::DripSharp.SqlTrellis.Expression.StringValue("$");
instance.setEscape(instance2);
global::DripSharp.Testing.JavaAssertions.Equal("name LIKE 'J%$_%' ESCAPE '$'", instance.ToString(), null);
}

internal virtual void testNotRLikeIssue1553() {
string sqlStr = "select * from test where id  not rlike '111'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDuckDBSimuilarTo() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT v\n", "    FROM strings\n"), "    WHERE v SIMILAR TO 'San* [fF].*'\n"), "    ORDER BY v;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testMatchAny() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v MATCH_ANY 'keyword1 keyword2'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v NOT MATCH_ANY 'keyword1 keyword2'", true);
}

public virtual void testMatchAll() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v MATCH_ALL 'keyword1 keyword2'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v NOT MATCH_ALL 'keyword1 keyword2'", true);
}

public virtual void testMatchPhrase() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v MATCH_PHRASE 'keyword1 keyword2'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v NOT MATCH_PHRASE 'keyword1 keyword2'", true);
}

public virtual void testMatchPhrasePrefix() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v MATCH_PHRASE_PREFIX 'keyword1 keyword2'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v NOT MATCH_PHRASE_PREFIX 'keyword1 keyword2'", true);
}

public virtual void testMatchRegexp() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v MATCH_REGEXP 'keyword1 keyword2'", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where v NOT MATCH_REGEXP 'keyword1 keyword2'", true);
}

[Xunit.Fact]
public void __Upstream_fe7ce80eadb99fd7()
{
        try
        {
            this.testDuckDBSimuilarTo();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c1995533ec1f1425()
{
        try
        {
            this.testLikeNotIssue660();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cf17ad3ff56c6912()
{
        try
        {
            this.testMatchAll();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8f63191a76e537ec()
{
        try
        {
            this.testMatchAny();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2de3c07f10a24460()
{
        try
        {
            this.testMatchPhrase();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_567ced7b40a65b40()
{
        try
        {
            this.testMatchPhrasePrefix();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_03a4bee1566bf001()
{
        try
        {
            this.testMatchRegexp();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c2bdcb147de57240()
{
        try
        {
            this.testNotRLikeIssue1553();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aa2f9a19e764bbe7()
{
        try
        {
            this.testSetEscapeAndGetStringExpression();
        }
        finally
        {
        }
}
}
