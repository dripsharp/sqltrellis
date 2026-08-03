// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class DateTimeLiteralTest {
internal virtual void testDateTimeWithAlias() {
string sqlStr = "SELECT DATETIME '2005-01-03 12:34:56' as datetime";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testDateTimeWithDoubleQuotes() {
string sqlStr = "SELECT DATETIME \"2005-01-03 12:34:56\" as datetime";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_58e48cbf8665a845()
{
        try
        {
            this.testDateTimeWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_833e62475e68025d()
{
        try
        {
            this.testDateTimeWithDoubleQuotes();
        }
        finally
        {
        }
}
}
