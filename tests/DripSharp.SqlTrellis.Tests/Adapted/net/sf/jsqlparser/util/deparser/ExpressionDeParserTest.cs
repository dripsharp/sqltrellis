// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Deparser;

public class ExpressionDeParserTest {
private global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser expressionDeParser = null!;

private global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder> selectVisitor = null!;

private global::System.Text.StringBuilder buffer = null!;

private global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser orderByDeParser = null!;

public virtual void setUp() {
this.buffer = new global::System.Text.StringBuilder();
this.expressionDeParser = new global::DripSharp.SqlTrellis.Util.Deparser.ExpressionDeParser(this.selectVisitor, this.buffer, this.orderByDeParser);
}

public virtual void shouldDeParseSimplestAnalyticExpression() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
analyticExpression.setName("name");
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name() OVER ()", this.buffer.ToString(), null);
}

public virtual void shouldDeParseAnalyticExpressionWithExpression() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
analyticExpression.setName("name");
analyticExpression.setExpression(expression);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("expression")).Given(expression).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name(expression) OVER ()", this.buffer.ToString(), null);
}

public virtual void shouldDeParseAnalyticExpressionWithOffset() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression offset = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
analyticExpression.setName("name");
analyticExpression.setExpression(expression);
analyticExpression.setOffset(offset);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("expression")).Given(expression).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("offset")).Given(offset).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name(expression, offset) OVER ()", this.buffer.ToString(), null);
}

public virtual void shouldDeParseAnalyticExpressionWithDefaultValue() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::DripSharp.SqlTrellis.Expression.Expression expression = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression offset = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression defaultValue = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
analyticExpression.setName("name");
analyticExpression.setExpression(expression);
analyticExpression.setOffset(offset);
analyticExpression.setDefaultValue(defaultValue);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("expression")).Given(expression).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("offset")).Given(offset).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("default value")).Given(defaultValue).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name(expression, offset, default value) OVER ()", this.buffer.ToString(), null);
}

public virtual void shouldDeParseAnalyticExpressionWithAllColumns() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
analyticExpression.setName("name");
analyticExpression.setAllColumns(true);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name(*) OVER ()", this.buffer.ToString(), null);
}

public virtual void shouldDeParseComplexAnalyticExpressionWithKeep() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::DripSharp.SqlTrellis.Expression.KeepExpression keep = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.KeepExpression>();
analyticExpression.setName("name");
analyticExpression.setKeep(keep);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("keep")).Given(keep).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name() keep OVER ()", this.buffer.ToString(), null);
}

public virtual void shouldDeParseComplexAnalyticExpressionWithPartitionExpressionList() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression> partitionExpressionList = new global::DripSharp.SqlTrellis.Expression.Operators.Relational.ExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression partitionExpression1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
global::DripSharp.SqlTrellis.Expression.Expression partitionExpression2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.Expression>();
analyticExpression.setName("name");
analyticExpression.setPartitionExpressionList(global::DripSharp.SqlTrellis.SqlTrellisGenericCompatibility.CastExpressionList<global::DripSharp.SqlTrellis.Expression.Expression>(partitionExpressionList));
global::DripSharp.Runtime.JavaCompat.Add(partitionExpressionList, partitionExpression1);
global::DripSharp.Runtime.JavaCompat.Add(partitionExpressionList, partitionExpression2);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("partition expression 1")).Given(partitionExpression1).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("partition expression 2")).Given(partitionExpression2).accept<global::System.Text.StringBuilder, object>((global::DripSharp.SqlTrellis.Expression.ExpressionVisitor<global::System.Text.StringBuilder>)(this.expressionDeParser), (object)default!);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name() OVER (PARTITION BY partition expression 1, partition expression 2 )", this.buffer.ToString(), null);
}

public virtual void shouldDeParseAnalyticExpressionWithOrderByElements() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement> orderByElements = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
analyticExpression.setName("name");
analyticExpression.setOrderByElements(orderByElements);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement1);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement2);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("order by element 1")).Given(this.orderByDeParser).deParseElement(orderByElement1);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("order by element 2")).Given(this.orderByDeParser).deParseElement(orderByElement2);
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name() OVER (ORDER BY order by element 1, order by element 2)", this.buffer.ToString(), null);
}

public virtual void shouldDeParseAnalyticExpressionWithWindowElement() {
global::DripSharp.SqlTrellis.Expression.AnalyticExpression analyticExpression = new global::DripSharp.SqlTrellis.Expression.AnalyticExpression();
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement> orderByElements = new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Statement.Select.OrderByElement orderByElement2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.OrderByElement>();
global::DripSharp.SqlTrellis.Expression.WindowElement windowElement = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Expression.WindowElement>();
analyticExpression.setName("name");
analyticExpression.setOrderByElements(orderByElements);
analyticExpression.setWindowElement(windowElement);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement1);
global::DripSharp.Runtime.JavaCompat.Add(orderByElements, orderByElement2);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("order by element 1")).Given(this.orderByDeParser).deParseElement(orderByElement1);
global::DripSharp.Testing.JavaMockito.Will(this.appendToBuffer("order by element 2")).Given(this.orderByDeParser).deParseElement(orderByElement2);
global::DripSharp.Testing.JavaMockito.Given(windowElement.ToString()).WillReturn("window element");
this.expressionDeParser.visit<object>(analyticExpression, (object)default!);
global::DripSharp.Testing.JavaAssertions.Equal("name() OVER (ORDER BY order by element 1, order by element 2 window element)", this.buffer.ToString(), null);
}

private global::DripSharp.Testing.JavaAnswer<object> appendToBuffer(string @string) {
return (invocation) => {
this.buffer.Append(@string);
return default!;
};
}

[Xunit.Fact]
public void __Upstream_14101ba642d53227()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseAnalyticExpressionWithAllColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0ecd01fb200471c3()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseAnalyticExpressionWithDefaultValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8368edbfd2e07ed5()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseAnalyticExpressionWithExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5280cfadfa2685e6()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseAnalyticExpressionWithOffset();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_71176e3867d37314()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseAnalyticExpressionWithOrderByElements();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9610d566c4a1c29()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseAnalyticExpressionWithWindowElement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_305611da5fc70938()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseComplexAnalyticExpressionWithKeep();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8863fb42f4ac38b2()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseComplexAnalyticExpressionWithPartitionExpressionList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_908f2184a3dec1f7()
{
        this.orderByDeParser = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Util.Deparser.OrderByDeParser>();
        this.selectVisitor = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Select.SelectVisitor<global::System.Text.StringBuilder>>();
        this.setUp();
        try
        {
            this.shouldDeParseSimplestAnalyticExpression();
        }
        finally
        {
        }
}
}
