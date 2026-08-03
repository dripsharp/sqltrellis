// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class LikeExpressionTest {
public virtual void testLikeWithEscapeExpressionIssue420() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("a LIKE ?1 ESCAPE ?2", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("select * from dual where a LIKE ?1 ESCAPE ?2", true);
}

public virtual void testEscapeExpressionIssue1638() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select case \n", "    when id_portfolio like '%\\_1' escape '\\' then '1'\n"), "    end");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
global::DripSharp.Testing.JavaAssertions.Throws<global::DripSharp.SqlTrellis.JSQLParserException>(() => {
global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr, (parser) => parser.withBackslashEscapeCharacter(true));
}, null);
}

public virtual void testEscapingIssue1209() {
string sqlStr = "INSERT INTO \"a\".\"b\"(\"c\", \"d\", \"e\") VALUES ('c c\\', 'dd', 'ee\\')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
}

public virtual void testEscapingIssue1173() {
string sqlStr = "update PARAM_TBL set PARA_DESC = null where PARA_DESC = '\\' and DEFAULT_VALUE = '\\'";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
}

public virtual void testEscapingIssue1172() {
string sqlStr = "SELECT A ALIA1, CASE WHEN B LIKE 'ABC\\_%' ESCAPE '\\' THEN 'DEF' ELSE 'CCCC' END AS OBJ_SUB_TYPE FROM TABLE2";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
}

public virtual void testEscapingIssue832() {
string sqlStr = "SELECT * FROM T1 WHERE (name LIKE ? ESCAPE '\\') AND (description LIKE ? ESCAPE '\\')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
}

public virtual void testEscapingIssue827() {
string sqlStr = "INSERT INTO my_table (my_column_1, my_column_2) VALUES ('my_value_1\\', 'my_value_2')";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
}

public virtual void testEscapingIssue578() {
string sqlStr = "SELECT * FROM t1 WHERE UPPER(t1.TIPCOR_A8) like ? ESCAPE '' ORDER BY PERFILB2||TRANSLATE(UPPER(AP1SOL10 || ' ' || AP2SOL10 || ',' || NOMSOL10), '?', 'A') asc";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
}

public virtual void testEscapingIssue875() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("insert into standard_table(gmt_create, gmt_modified, config_name, standard_code) values (now(), now(), null, 'if \n", "@fac.sql_type in \n"), "[ ''UPDATE'', ''DELETE'', ''INSERT'', ''INSERT_SELECT''] \n"), "then \n"), "@act.allow_submit \n"), "end \n"), "')");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(false));
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("insert into standard_table(gmt_create, gmt_modified, config_name, standard_code) values (now(), now(), null, 'if \n", "@fac.sql_type in \n"), "[ \\'UPDATE\\', \\'DELETE\\', \\'INSERT\\', \\'INSERT_SELECT\\'] \n"), "then \n"), "@act.allow_submit \n"), "end \n"), "')");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true, (parser) => parser.withBackslashEscapeCharacter(true));
}

[Xunit.Fact]
public void __Upstream_50b0be210cd6cc13()
{
        try
        {
            this.testEscapeExpressionIssue1638();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_82aa1b25276a02ce()
{
        try
        {
            this.testEscapingIssue1172();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_69319715fae2a52e()
{
        try
        {
            this.testEscapingIssue1173();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3d00201bddf585e2()
{
        try
        {
            this.testEscapingIssue1209();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c648cfc307316f44()
{
        try
        {
            this.testEscapingIssue578();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_294a108701b0b088()
{
        try
        {
            this.testEscapingIssue827();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e191363d25322db1()
{
        try
        {
            this.testEscapingIssue832();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_748954c823866abf()
{
        try
        {
            this.testEscapingIssue875();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_dfd654f14da0ecc4()
{
        try
        {
            this.testLikeWithEscapeExpressionIssue420();
        }
        finally
        {
        }
}
}
