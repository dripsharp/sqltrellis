// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Test;

public class UnicodeTest {
internal virtual void testCJKSetIssue1741() {
string sqlStr = "select c as \u4E2D\u6587 from t";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = "select * from t where \u4E2D\u6587 = 'abc'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testCJKSetIssue1747() {
string sqlStr = "SELECT \uAC00 FROM \uB098";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_37a649609c573df5()
{
        try
        {
            this.testCJKSetIssue1741();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e61e4bf0ddd4327e()
{
        try
        {
            this.testCJKSetIssue1747();
        }
        finally
        {
        }
}
}
