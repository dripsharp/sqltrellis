// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class SelectXMLSerializeTest {
public virtual void testXmlAgg1() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT xmlserialize(xmlagg(xmltext(COMMENT_LINE) ORDER BY COMMENT_SEQUENCE) AS varchar (1024)) FROM mytable GROUP BY COMMENT_NUMBER");
}

public virtual void testXmlAgg2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT xmlserialize(xmlagg(xmltext(COMMENT_LINE) ORDER BY COMMENT_SEQUENCE, COMMENT_LINE) AS varchar (1024)) FROM mytable GROUP BY COMMENT_NUMBER");
}

public virtual void testXmlAgg3() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT xmlserialize(xmlagg(xmltext(COMMENT_LINE) ORDER BY COMMENT_SEQUENCE) AS varchar (1024))");
}

public virtual void testXmlAgg4() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT xmlserialize(xmlagg(xmltext(COMMENT_LINE_PREFIX || COMMENT_LINE) ORDER BY COMMENT_SEQUENCE) AS varchar (1024))");
}

public virtual void testXmlAgg5() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT xmlserialize(xmlagg(xmltext(CONCAT(', ', TRIM(SOME_COLUMN))) ORDER BY MY_SEQUENCE) AS varchar (1024))", true);
}

public virtual void testXmlAgg6() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT xmlserialize(xmlagg(xmltext(COMMENT_LINE)) AS varchar (1024))");
}

[Xunit.Fact]
public void __Upstream_615d7bdf4936f5ca()
{
        try
        {
            this.testXmlAgg1();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a08cdb6073303247()
{
        try
        {
            this.testXmlAgg2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4636da08691163c3()
{
        try
        {
            this.testXmlAgg3();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b4f097ffc0357d46()
{
        try
        {
            this.testXmlAgg4();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_679b856f410e4777()
{
        try
        {
            this.testXmlAgg5();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_40f2629291dcc54d()
{
        try
        {
            this.testXmlAgg6();
        }
        finally
        {
        }
}
}
