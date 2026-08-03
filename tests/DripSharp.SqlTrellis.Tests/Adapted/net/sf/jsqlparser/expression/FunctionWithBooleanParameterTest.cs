// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class FunctionWithBooleanParameterTest {
public FunctionWithBooleanParameterTest() {}

public virtual void testParseOpLowerTotally() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a<b, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a < b, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseOpLowerOrEqual() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a+x<=b+y, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a + x <= b + y, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseOpGreaterTotally() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a>b, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a > b, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseOpGreaterOrEqual() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a>=b, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a >= b, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseOpEqual() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a=b, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a = b, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseOpNotEqualStandard() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a<>b, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a <> b, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

public virtual void testParseOpNotEqualBang() {
global::DripSharp.SqlTrellis.Expression.Expression result = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression("if(a!=b, c, d)");
global::DripSharp.Testing.JavaAssertions.Equal("if(a != b, c, d)", global::DripSharp.Runtime.JavaCompat.StringValueOf(result), null);
}

[Xunit.Fact]
public void __Upstream_ed69262d42526531()
{
        try
        {
            this.testParseOpEqual();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dce8f23924d99a1a()
{
        try
        {
            this.testParseOpGreaterOrEqual();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_32134af7eaf05620()
{
        try
        {
            this.testParseOpGreaterTotally();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ffd7892cd334288d()
{
        try
        {
            this.testParseOpLowerOrEqual();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_01eee79d6eb5ae20()
{
        try
        {
            this.testParseOpLowerTotally();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e25b8dc5525599ad()
{
        try
        {
            this.testParseOpNotEqualBang();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f3b96e237fee87a()
{
        try
        {
            this.testParseOpNotEqualStandard();
        }
        finally
        {
        }
}
}
