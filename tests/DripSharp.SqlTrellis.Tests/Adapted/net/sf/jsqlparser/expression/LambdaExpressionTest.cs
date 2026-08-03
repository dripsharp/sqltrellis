// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class LambdaExpressionTest {
internal virtual void testLambdaFunctionSingleParameter() {
string sqlStr = "select list_transform( split('test', ''),  x -> unicode(x) )";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testNestedLambdaFunctionMultipleParameter() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT list_transform(\n", "        [1, 2, 3],\n"), "        x -> list_reduce([4, 5, 6], (a, b) -> a + b) + x\n"), "    )");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testLambdaMultiParameterIssue2030() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("SELECT map_filter(my_column, v -> v.my_inner_column = 'some_value')\n", "FROM my_table");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testLambdaMultiParameterIssue2032() {
string sqlStr = "SELECT  array_sort(array_agg(named_struct('depth', events_union.depth, 'eventtime',events_union.eventtime)), (left, right) -> case when(left.eventtime, left.depth) <(right.eventtime, right.depth) then -1 when(left.eventtime, left.depth) >(right.eventtime, right.depth) then 1 else 0 end) as col1 FROM your_table;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_cf2dafca89b80580()
{
        try
        {
            this.testLambdaFunctionSingleParameter();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5436d85ad2451355()
{
        try
        {
            this.testLambdaMultiParameterIssue2030();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7728fc12a6591dca()
{
        try
        {
            this.testLambdaMultiParameterIssue2032();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a6d8b8ca6b1c2e02()
{
        try
        {
            this.testNestedLambdaFunctionMultipleParameter();
        }
        finally
        {
        }
}
}
