// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class ForClauseTest {
internal virtual void testForBrowse() {
string sqlStr = "SELECT * FROM table FOR BROWSE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testForXMLPath() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * ", "   FROM table "), "   FOR XML PATH('something'), ROOT('trkseg'), TYPE, BINARY BASE64, ELEMENTS ABSENT ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testForXMLRaw() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * ", "   FROM table "), "   FOR XML RAW('something'), ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testForXMLAuto() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * ", "   FROM table "), "   FOR XML AUTO, ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testForXMLExplicit() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * ", "   FROM table "), "   FOR XML EXPLICIT, ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testForXML() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * ", "   FROM table "), "   FOR XML EXPLICIT, ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA "), "UNION ALL "), "SELECT * "), "   FROM table "), "   FOR XML EXPLICIT, ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA "), "UNION ALL "), "SELECT * "), "   FROM table "), "   FOR XML AUTO, ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA "), "UNION ALL "), "SELECT * "), "   FROM table "), "   FOR XML RAW('something'), ROOT('trkseg'), TYPE, BINARY BASE64, XMLDATA ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testForJSON() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT * ", "   FROM table "), "   FOR JSON AUTO, ROOT('trkseg'), WITHOUT_ARRAY_WRAPPER, INCLUDE_NULL_VALUES "), "UNION ALL "), "SELECT * "), "   FROM table "), "   FOR JSON PATH, ROOT('trkseg'), INCLUDE_NULL_VALUES, WITHOUT_ARRAY_WRAPPER ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testIssue1800() {
string sqlStr = "SELECT (SELECT '1.0' AS '@Version', (SELECT 'Test' AS 'name', (SELECT (SELECT DISTINCT 51.64315 AS '@lat', 14.31709 AS '@lon' FOR XML PATH('trkpt'), TYPE) FOR XML PATH(''), ROOT('trkseg'), TYPE) FOR XML PATH('trk'), TYPE) FOR XML PATH('gpx'), TYPE) FOR XML PATH('')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a96f9c0f6e7cccfe()
{
        try
        {
            this.testForBrowse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_41b89212e3234240()
{
        try
        {
            this.testForJSON();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_417a46466be49882()
{
        try
        {
            this.testForXML();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_39ac912508871efb()
{
        try
        {
            this.testForXMLAuto();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e5ca279130adeed4()
{
        try
        {
            this.testForXMLExplicit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7cea400848d4eee0()
{
        try
        {
            this.testForXMLPath();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6b586dd331c9825a()
{
        try
        {
            this.testForXMLRaw();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8bdcd561a78f4338()
{
        try
        {
            this.testIssue1800();
        }
        finally
        {
        }
}
}
