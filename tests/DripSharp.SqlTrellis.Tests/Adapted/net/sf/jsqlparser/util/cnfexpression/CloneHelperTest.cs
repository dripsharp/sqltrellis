// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Cnfexpression;

public class CloneHelperTest {
public virtual void testChangeBack() {
global::DripSharp.SqlTrellis.Util.Cnfexpression.MultipleExpression ors = global::DripSharp.SqlTrellis.Util.Cnfexpression.CloneHelperTest.transform(global::DripSharp.Runtime.JavaCompat.AsList<string>("a>b", "5=a", "b=c", "a>c"));
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Util.Cnfexpression.CloneHelper.changeBack(true, ors);
global::DripSharp.Testing.JavaAssertJ.That(expr).IsInstanceOf(typeof(global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>));
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.Runtime.JavaCompat.StringValueOf(expr)).IsEqualTo("(a > b OR 5 = a OR b = c OR a > c)");
}

public virtual void testChangeBackOddNumberOfExpressions() {
global::DripSharp.SqlTrellis.Util.Cnfexpression.MultipleExpression ors = global::DripSharp.SqlTrellis.Util.Cnfexpression.CloneHelperTest.transform(global::DripSharp.Runtime.JavaCompat.AsList<string>("a>b", "5=a", "b=c", "a>c", "e<f"));
global::DripSharp.SqlTrellis.Expression.Expression expr = global::DripSharp.SqlTrellis.Util.Cnfexpression.CloneHelper.changeBack(true, ors);
global::DripSharp.Testing.JavaAssertJ.That(expr).IsInstanceOf(typeof(global::DripSharp.SqlTrellis.Expression.Operators.Relational.ParenthesedExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>));
global::DripSharp.Testing.JavaAssertJ.That(global::DripSharp.Runtime.JavaCompat.StringValueOf(expr)).IsEqualTo("(a > b OR 5 = a OR b = c OR a > c OR e < f)");
}

private static global::DripSharp.SqlTrellis.Util.Cnfexpression.MultipleExpression transform(global::System.Collections.Generic.IList<string> expressions) {
return new global::DripSharp.SqlTrellis.Util.Cnfexpression.MultiOrExpression(global::DripSharp.Runtime.JavaCompat.ToListValues(global::DripSharp.Runtime.JavaCompat.Map(global::DripSharp.Runtime.JavaCompat.Stream(expressions), (expr) => {
try {
return global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseCondExpression(expr);
} catch (global::DripSharp.SqlTrellis.JSQLParserException ex) {
global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Util.Cnfexpression.CloneHelperTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Util.Cnfexpression.CloneHelperTest).Name)).Log(global::DripSharp.Runtime.JavaLogLevel.Severe, (string)default!, ex);
return default!;
}
})));
}

[Xunit.Fact]
public void __Upstream_7506b632ae8b3ce6()
{
        try
        {
            this.testChangeBack();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8751cbea8dbbec65()
{
        try
        {
            this.testChangeBackOddNumberOfExpressions();
        }
        finally
        {
        }
}
}
