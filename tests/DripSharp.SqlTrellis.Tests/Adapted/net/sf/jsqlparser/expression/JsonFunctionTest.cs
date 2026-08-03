// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class JsonFunctionTest {
public virtual void testObjectAgg() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( foo:bar) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( foo:bar FORMAT JSON) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar NULL ON NULL) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar ABSENT ON NULL) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar WITH UNIQUE KEYS) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar WITHOUT UNIQUE KEYS) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar NULL ON NULL WITH UNIQUE KEYS ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar NULL ON NULL WITH UNIQUE KEYS ) FILTER( WHERE name = 'Raj' ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar NULL ON NULL WITH UNIQUE KEYS ) OVER( PARTITION BY name ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECTAGG( KEY foo VALUE bar NULL ON NULL WITH UNIQUE KEYS ) FILTER( WHERE name = 'Raj' ) OVER( PARTITION BY name ) FROM dual ", true);
}

public virtual void testObjectBuilder() {
global::DripSharp.SqlTrellis.Expression.JsonFunction f = new global::DripSharp.SqlTrellis.Expression.JsonFunction();
f.setType(global::DripSharp.SqlTrellis.Expression.JsonFunctionType.OBJECT);
global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair keyValuePair1 = new global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair("foo", "bar", false, false);
keyValuePair1.setUsingKeyKeyword(true);
keyValuePair1.setUsingValueKeyword(true);
f.add(keyValuePair1.withUsingFormatJson(true));
global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair keyValuePair2 = new global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair("foo", "bar", false, false).withUsingKeyKeyword(true).withUsingValueKeyword(true).withUsingFormatJson(false);
global::DripSharp.Testing.JavaAssertions.Equal(keyValuePair1, keyValuePair2, null);
global::DripSharp.Testing.JavaAssertions.NotEqual(keyValuePair1.ToString(), keyValuePair2.ToString(), null);
global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair keyValuePair3 = new global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair("foo", "bar", false, false).withUsingKeyKeyword(false).withUsingValueKeyword(false).withUsingFormatJson(false);
global::DripSharp.Testing.JavaAssertions.NotNull(keyValuePair3, null);
global::DripSharp.Testing.JavaAssertions.Equal(keyValuePair3, keyValuePair3, null);
global::DripSharp.Testing.JavaAssertions.NotEqual(keyValuePair3, f, null);
global::DripSharp.Testing.JavaAssertions.True((keyValuePair3.GetHashCode() != 0), null);
f.add(keyValuePair2);
}

public virtual void testArrayBuilder() {
global::DripSharp.SqlTrellis.Expression.JsonFunction f = new global::DripSharp.SqlTrellis.Expression.JsonFunction();
f.setType(global::DripSharp.SqlTrellis.Expression.JsonFunctionType.ARRAY);
global::DripSharp.SqlTrellis.Expression.JsonFunctionExpression expression1 = new global::DripSharp.SqlTrellis.Expression.JsonFunctionExpression(new global::DripSharp.SqlTrellis.Expression.NullValue());
expression1.setUsingFormatJson(true);
global::DripSharp.SqlTrellis.Expression.JsonFunctionExpression expression2 = new global::DripSharp.SqlTrellis.Expression.JsonFunctionExpression(new global::DripSharp.SqlTrellis.Expression.NullValue()).withUsingFormatJson(true);
global::DripSharp.Testing.JavaAssertions.Equal(expression1.ToString(), expression2.ToString(), null);
f.add(expression1);
f.add(expression2);
}

public virtual void testArrayAgg() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a ORDER BY a ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a NULL ON NULL ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a FORMAT JSON ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a FORMAT JSON NULL ON NULL ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a FORMAT JSON ABSENT ON NULL ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a FORMAT JSON ABSENT ON NULL ) FILTER( WHERE name = 'Raj' ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a FORMAT JSON ABSENT ON NULL ) OVER( PARTITION BY name )  FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG( a FORMAT JSON ABSENT ON NULL ) FILTER( WHERE name = 'Raj' ) OVER( PARTITION BY name ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT json_arrayagg(json_array(\"v0\") order by \"t\".\"v0\") FROM dual ", true);
}

public virtual void testObject() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat("WITH Items AS (SELECT 'hello' AS key, 'world' AS value)\n", "SELECT JSON_OBJECT(key, value) AS json_data FROM Items"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( KEY 'foo' VALUE bar, KEY 'foo' VALUE bar) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( 'foo' : bar, 'foo' : bar) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( 'foo':bar, 'foo':bar FORMAT JSON) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( KEY 'foo' VALUE bar, 'foo':bar FORMAT JSON, 'foo':bar NULL ON NULL) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( KEY 'foo' VALUE bar FORMAT JSON, 'foo':bar, 'foo':bar ABSENT ON NULL) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( KEY 'foo' VALUE bar FORMAT JSON, 'foo':bar, 'foo':bar ABSENT ON NULL WITH UNIQUE KEYS) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( KEY 'foo' VALUE bar FORMAT JSON, 'foo':bar, 'foo':bar ABSENT ON NULL WITHOUT UNIQUE KEYS) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_object(null on null)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_object(absent on null)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_object()", true);
}

public virtual void testObjectWithExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( KEY 'foo' VALUE cast( bar AS VARCHAR(40)), KEY 'foo' VALUE bar) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAYAGG(obj) FROM (SELECT trt.relevance_id,JSON_OBJECT('id',CAST(trt.id AS CHAR),'taskName',trt.task_name,'openStatus',trt.open_status,'taskSort',trt.task_sort) as obj FROM tb_review_task trt ORDER BY trt.task_sort ASC)", true);
}

public virtual void testObjectIssue1504() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT(key 'person' value tp.account) obj", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT(key 'person' value tp.account, key 'person' value tp.account) obj", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( 'person' : tp.account) obj", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( 'person' : tp.account, 'person' : tp.account) obj", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( 'person' : '1', 'person' : '2') obj", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT( 'person' VALUE tp.person, 'account' VALUE tp.account) obj", true);
}

public virtual void testObjectMySQL() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_OBJECT('person', tp.person, 'account', tp.account) obj", true);
}

public virtual void testArray() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAY( (SELECT * from dual) ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAY( 1, 2, 3 ) FROM dual ", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT JSON_ARRAY( \"v0\" ) FROM dual ", true);
}

public virtual void testArrayWithNullExpressions() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("JSON_ARRAY( 1, 2, 3 )", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_array(null on null)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_array(null null on null)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_array(null, null null on null)", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("json_array()", true);
}

public virtual void testIssue1260() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select \n", "  cast((\n"), "    select coalesce(\n"), "      json_arrayagg(json_array(\"v0\") order by \"t\".\"v0\"),\n"), "      json_array(null on null)\n"), "    )\n"), "    from (\n"), "      select 2 \"v0\"\n"), "      union\n"), "      select 4 \"ID\"\n"), "    ) \"t\"\n"), "  ) as text)"), true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeParsedAndDeparsed("listagg( json_object(key 'v0' value \"v0\"), ',' )", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select (\n", "  select coalesce(\n"), "    cast(('[' || listagg(\n"), "      json_object(key 'v0' value \"v0\"),\n"), "      ','\n"), "    ) || ']') as varchar(32672)),\n"), "    json_array()\n"), "  )\n"), "  from (\n"), "    select cast(null as timestamp) \"v0\"\n"), "    from SYSIBM.DUAL\n"), "    union all\n"), "    select timestamp '2000-03-15 10:15:00.0' \"a\"\n"), "    from SYSIBM.DUAL\n"), "  ) \"t\"\n"), ")\n"), "from SYSIBM.DUAL"), true);
}

public virtual void testIssue1371() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT json_object('{a, 1, b, 2}')", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT json_object('{{a, 1}, {b, 2}}')", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SELECT json_object('{a, b}', '{1,2 }')", true);
}

public virtual void testJavaMethods() {
string expressionStr = "JSON_OBJECT( KEY 'foo' VALUE bar FORMAT JSON, 'foo':bar, 'foo':bar ABSENT ON NULL WITHOUT UNIQUE KEYS)";
global::DripSharp.SqlTrellis.Expression.JsonFunction jsonFunction = (global::DripSharp.SqlTrellis.Expression.JsonFunction)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parseExpression(expressionStr)!);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Expression.JsonFunctionType.OBJECT, jsonFunction.getType(), null);
global::DripSharp.Testing.JavaAssertions.NotEqual(jsonFunction.withType(global::DripSharp.SqlTrellis.Expression.JsonFunctionType.POSTGRES_OBJECT), jsonFunction.getType(), null);
global::DripSharp.Testing.JavaAssertions.Equal(3, global::DripSharp.Runtime.JavaCompat.CollectionCount(jsonFunction.getKeyValuePairs()), null);
global::DripSharp.Testing.JavaAssertions.Equal(new global::DripSharp.SqlTrellis.Expression.JsonKeyValuePair("'foo'", "bar", true, true), jsonFunction.getKeyValuePair(0), null);
jsonFunction.setOnNullType(global::DripSharp.SqlTrellis.Expression.JsonAggregateOnNullType.NULL);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Expression.JsonAggregateOnNullType.ABSENT, jsonFunction.withOnNullType(global::DripSharp.SqlTrellis.Expression.JsonAggregateOnNullType.ABSENT).getOnNullType(), null);
jsonFunction.setUniqueKeysType(global::DripSharp.SqlTrellis.Expression.JsonAggregateUniqueKeysType.WITH);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Expression.JsonAggregateUniqueKeysType.WITH, jsonFunction.withUniqueKeysType(global::DripSharp.SqlTrellis.Expression.JsonAggregateUniqueKeysType.WITH).getUniqueKeysType(), null);
}

internal virtual void testIssue1753JSonObjectAggWithColumns() {
string sqlStr = "SELECT JSON_OBJECTAGG( KEY q.foo VALUE q.bar) FROM dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
sqlStr = "SELECT JSON_OBJECTAGG(foo, bar) FROM dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr);
}

[Xunit.Fact]
public void __Upstream_9a1836a896092828()
{
        try
        {
            this.testArray();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_590a14735a89dea1()
{
        try
        {
            this.testArrayAgg();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f8e633f856a90d14()
{
        try
        {
            this.testArrayBuilder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f148ba10ee83f951()
{
        try
        {
            this.testArrayWithNullExpressions();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0437c4486627c19c()
{
        try
        {
            this.testIssue1260();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_45e7dd7683f92d1a()
{
        try
        {
            this.testIssue1371();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3323c65b1eb76059()
{
        try
        {
            this.testIssue1753JSonObjectAggWithColumns();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_56c67ce18df53a78()
{
        try
        {
            this.testJavaMethods();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1490f2c1643c9588()
{
        try
        {
            this.testObject();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6835e7bcda888bcc()
{
        try
        {
            this.testObjectAgg();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c9ad0b1e69ac7388()
{
        try
        {
            this.testObjectBuilder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6d2a0d1773e86618()
{
        try
        {
            this.testObjectIssue1504();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_72ee40232cf158a8()
{
        try
        {
            this.testObjectMySQL();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7b31ce40bed28a5c()
{
        try
        {
            this.testObjectWithExpression();
        }
        finally
        {
        }
}
}
