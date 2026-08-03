// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Piped;

public class SetOperationPipeOperatorTest {
internal virtual void parseAndDeparseUnion() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT 3\n", "|> UNION ALL\n"), "    (SELECT 1),\n"), "    (SELECT 2);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void parseAndDeparseIntersect() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM UNNEST(ARRAY[1, 2, 3, 3, 4]) AS number\n", "|> INTERSECT DISTINCT\n"), "    (SELECT * FROM UNNEST(ARRAY[2, 3, 3, 5]) AS number);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void parseAndDeparseExcept() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM UNNEST(ARRAY[1, 2, 3, 3, 4]) AS number\n", "|> EXCEPT DISTINCT\n"), "    (SELECT * FROM UNNEST(ARRAY[1, 2]) AS number);");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_e9229ee2f01e5476()
{
        try
        {
            this.parseAndDeparseExcept();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_870de251de2ee25a()
{
        try
        {
            this.parseAndDeparseIntersect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_62e729988468ce2a()
{
        try
        {
            this.parseAndDeparseUnion();
        }
        finally
        {
        }
}
}
