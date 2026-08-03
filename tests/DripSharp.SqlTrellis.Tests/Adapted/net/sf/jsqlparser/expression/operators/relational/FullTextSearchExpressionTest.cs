// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression.Operators.Relational;

public class FullTextSearchExpressionTest {
public virtual void testFullTextSearchExpressionWithParameters() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select match (name) against (?) as full_text from commodity", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select match (name) against (:parameter) as full_text from commodity", true);
}

public virtual void testIssue1223() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select\n", "c.*,\n"), "match (name) against (?) as full_text\n"), "from\n"), "commodity c\n"), "where\n"), "match (name) against (?)\n"), "and c.deleted = 0\n"), "order by\n"), "full_text desc"), true);
}

[Xunit.Fact]
public void __Upstream_c9ba7c994b996969()
{
        try
        {
            this.testFullTextSearchExpressionWithParameters();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9471bd00d2bdf9ba()
{
        try
        {
            this.testIssue1223();
        }
        finally
        {
        }
}
}
