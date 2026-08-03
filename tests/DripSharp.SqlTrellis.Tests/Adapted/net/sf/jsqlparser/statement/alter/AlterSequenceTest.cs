// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Alter;

public class AlterSequenceTest {
public virtual void testAlterSequence_noParams() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq");
}

public virtual void testAlterSequence_withIncrement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq INCREMENT BY 1");
}

public virtual void testAlterSequence_withStart() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq START WITH 10");
}

public virtual void testAlterSequence_withMaxValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq MAXVALUE 5");
}

public virtual void testAlterSequence_withNoMaxValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq NOMAXVALUE");
}

public virtual void testAlterSequence_withMinValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq MINVALUE 5");
}

public virtual void testAlterSequence_withNoMinValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq NOMINVALUE");
}

public virtual void testAlterSequence_withCycle() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq CYCLE");
}

public virtual void testAlterSequence_withNoCycle() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq NOCYCLE");
}

public virtual void testAlterSequence_withCache() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq CACHE 10");
}

public virtual void testAlterSequence_withNoCache() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq NOCACHE");
}

public virtual void testAlterSequence_withOrder() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq ORDER");
}

public virtual void testAlterSequence_withNoOrder() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq NOORDER");
}

public virtual void testAlterSequence_withKeep() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq KEEP");
}

public virtual void testAlterSequence_withNoKeep() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq NOKEEP");
}

public virtual void testAlterSequence_withSession() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq SESSION");
}

public virtual void testAlterSequence_withGlobal() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq GLOBAL");
}

public virtual void testAlterSequence_preservesParamOrder() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_sec INCREMENT BY 2 START WITH 10");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_sec START WITH 2 INCREMENT BY 5 NOCACHE");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_sec START WITH 2 INCREMENT BY 5 CACHE 200 CYCLE");
}

public virtual void testAlterSequence_restartIssue1405() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq RESTART WITH 1");
}

public virtual void testAlterSequence_restartIssue1405WithoutValue() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SEQUENCE my_seq RESTART");
}

[Xunit.Fact]
public void __Upstream_4eaa860fe649976e()
{
        try
        {
            this.testAlterSequence_noParams();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_350a9759c05e1051()
{
        try
        {
            this.testAlterSequence_preservesParamOrder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_760791e24c825290()
{
        try
        {
            this.testAlterSequence_restartIssue1405();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9681729a3cf7852c()
{
        try
        {
            this.testAlterSequence_restartIssue1405WithoutValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c3a1df11ea95546c()
{
        try
        {
            this.testAlterSequence_withCache();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4877bd91d3b6b64d()
{
        try
        {
            this.testAlterSequence_withCycle();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a032f0d88a564aaf()
{
        try
        {
            this.testAlterSequence_withGlobal();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_956d89e54e15bc36()
{
        try
        {
            this.testAlterSequence_withIncrement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a6c113ccda93f7f()
{
        try
        {
            this.testAlterSequence_withKeep();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_06fc4c7cfe561006()
{
        try
        {
            this.testAlterSequence_withMaxValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6422fe69ffe646ff()
{
        try
        {
            this.testAlterSequence_withMinValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4e48825830224ce9()
{
        try
        {
            this.testAlterSequence_withNoCache();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_93193e463bb2c345()
{
        try
        {
            this.testAlterSequence_withNoCycle();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_71c5366098cb3a4e()
{
        try
        {
            this.testAlterSequence_withNoKeep();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_89196758a7f2270b()
{
        try
        {
            this.testAlterSequence_withNoMaxValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_093063663e550614()
{
        try
        {
            this.testAlterSequence_withNoMinValue();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7f0523a8a0372a22()
{
        try
        {
            this.testAlterSequence_withNoOrder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_c8f2a6c785bb97a1()
{
        try
        {
            this.testAlterSequence_withOrder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_287a536486f6ec20()
{
        try
        {
            this.testAlterSequence_withSession();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6fa92048fa67526e()
{
        try
        {
            this.testAlterSequence_withStart();
        }
        finally
        {
        }
}
}
