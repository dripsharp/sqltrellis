// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class CreateSequenceTest {
public virtual void testCreateSequence_noParams() {
string statement = "CREATE SEQUENCE my_seq";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Sequence.CreateSequence().withSequence(new global::DripSharp.SqlTrellis.Schema.Sequence().withName("my_seq")), statement);
}

public virtual void testCreateSequence_withIncrement() {
string statement = "CREATE SEQUENCE db.schema.my_seq INCREMENT BY 1";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Sequence.CreateSequence().withSequence(new global::DripSharp.SqlTrellis.Schema.Sequence().withDatabase(new global::DripSharp.SqlTrellis.Schema.Database("db")).withSchemaName("schema").withName("my_seq").addParameters(new global::DripSharp.SqlTrellis.Schema.Sequence.Parameter(global::DripSharp.SqlTrellis.Schema.Sequence.ParameterType.INCREMENT_BY).withValue(1L))), statement);
}

public virtual void testCreateSequence_withStart() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq START WITH 10");
}

public virtual void testCreateSequence_withMaxValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq MAXVALUE 5");
}

public virtual void testCreateSequence_withNoMaxValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq NOMAXVALUE");
}

public virtual void testCreateSequence_withMinValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq MINVALUE 5");
}

public virtual void testCreateSequence_withNoMinValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq NOMINVALUE");
}

public virtual void testCreateSequence_withCycle() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq CYCLE");
}

public virtual void testCreateSequence_withNoCycle() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq NOCYCLE");
}

public virtual void testCreateSequence_withCache() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq CACHE 10");
}

public virtual void testCreateSequence_withNoCache() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq NOCACHE");
}

public virtual void testCreateSequence_withOrder() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq ORDER");
}

public virtual void testCreateSequence_withNoOrder() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq NOORDER");
}

public virtual void testCreateSequence_withKeep() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq KEEP");
}

public virtual void testCreateSequence_withNoKeep() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq NOKEEP");
}

public virtual void testCreateSequence_withSession() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq SESSION");
}

public virtual void testCreateSequence_withGlobal() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_seq GLOBAL");
}

public virtual void testCreateSequence_preservesParamOrder() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_sec INCREMENT BY 2 START WITH 10");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE SEQUENCE my_sec START WITH 2 INCREMENT BY 5 NOCACHE");
string statement = "CREATE SEQUENCE my_sec START WITH 2 INCREMENT BY 5 CACHE 200 CYCLE";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Sequence.CreateSequence().withSequence(new global::DripSharp.SqlTrellis.Schema.Sequence().withName("my_sec").addParameters(global::DripSharp.SqlTrellis.Test.TestUtils.asList<global::DripSharp.SqlTrellis.Schema.Sequence.Parameter>(new global::DripSharp.SqlTrellis.Schema.Sequence.Parameter(global::DripSharp.SqlTrellis.Schema.Sequence.ParameterType.START_WITH).withValue(2L), new global::DripSharp.SqlTrellis.Schema.Sequence.Parameter(global::DripSharp.SqlTrellis.Schema.Sequence.ParameterType.INCREMENT_BY).withValue(5L), new global::DripSharp.SqlTrellis.Schema.Sequence.Parameter(global::DripSharp.SqlTrellis.Schema.Sequence.ParameterType.CACHE).withValue(200L), new global::DripSharp.SqlTrellis.Schema.Sequence.Parameter(global::DripSharp.SqlTrellis.Schema.Sequence.ParameterType.CYCLE)))), statement);
}

[Xunit.Fact]
public void __Upstream_749a319e31e3e6fb()
{
        try
        {
            this.testCreateSequence_noParams();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b437cfb524696334()
{
        try
        {
            this.testCreateSequence_preservesParamOrder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8be4c9c8fd9ea6f1()
{
        try
        {
            this.testCreateSequence_withCache();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1edf9ab5269cf310()
{
        try
        {
            this.testCreateSequence_withCycle();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5df6ae10f207fa81()
{
        try
        {
            this.testCreateSequence_withGlobal();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8c518dd4f9513f92()
{
        try
        {
            this.testCreateSequence_withIncrement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_fceb7bd1dbea3108()
{
        try
        {
            this.testCreateSequence_withKeep();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b66f29603790eb2()
{
        try
        {
            this.testCreateSequence_withMaxValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1c0698c6b5994760()
{
        try
        {
            this.testCreateSequence_withMinValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6e3fffa148218d9c()
{
        try
        {
            this.testCreateSequence_withNoCache();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0e109b6c7b008f54()
{
        try
        {
            this.testCreateSequence_withNoCycle();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_09b24aeb6bb2ae8e()
{
        try
        {
            this.testCreateSequence_withNoKeep();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e99c848c60b9627e()
{
        try
        {
            this.testCreateSequence_withNoMaxValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8eba377c9f29f614()
{
        try
        {
            this.testCreateSequence_withNoMinValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_da28c419de50b24f()
{
        try
        {
            this.testCreateSequence_withNoOrder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f9ab07eab1d7d319()
{
        try
        {
            this.testCreateSequence_withOrder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_782b38d19726ef65()
{
        try
        {
            this.testCreateSequence_withSession();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cb3d0026b2d4a58a()
{
        try
        {
            this.testCreateSequence_withStart();
        }
        finally
        {
        }
}
}
