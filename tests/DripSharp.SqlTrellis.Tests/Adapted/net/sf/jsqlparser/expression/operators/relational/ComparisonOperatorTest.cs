// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class ComparisonOperatorTest {
public virtual void testDoubleAnd() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo WHERE a && b");
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.DoubleAnd>(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a && b"), null);
}

public virtual void testContains() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo WHERE a &> b");
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.Contains>(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a &> b"), null);
}

public virtual void testContainedBy() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT * FROM foo WHERE a <& b");
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.ContainedBy>(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("a <& b"), null);
}

internal virtual void testCosineSimilarity() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT (embedding <=> '[3,1,2]') AS cosine_similarity FROM items;");
global::DripSharp.Testing.JavaAssertions.InstanceOf<global::DripSharp.SqlTrellis.Expression.Operators.Relational.CosineSimilarity>(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("embedding <=> '[3,1,2]'"), null);
}

[Xunit.Fact]
public void __Upstream_1a0d5733d82d44ab()
{
        try
        {
            this.testContainedBy();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_974754b504997f72()
{
        try
        {
            this.testContains();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a7fae36cdc242af()
{
        try
        {
            this.testCosineSimilarity();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_718820f16406cfdc()
{
        try
        {
            this.testDoubleAnd();
        }
        finally
        {
        }
}
}
