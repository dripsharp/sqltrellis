// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Schema;

public class SequenceTest {
public virtual void testSetName() {
global::DripSharp.SqlTrellis.Schema.Sequence sequence = new global::DripSharp.SqlTrellis.Schema.Sequence().withName("foo");
global::DripSharp.Testing.JavaAssertJ.That(sequence.getName()).IsEqualTo("foo");
global::DripSharp.Testing.JavaAssertJ.That(sequence.getFullyQualifiedName()).IsEqualTo("foo");
}

public virtual void testSetSchemaName() {
global::DripSharp.SqlTrellis.Schema.Sequence sequence = new global::DripSharp.SqlTrellis.Schema.Sequence().withName("foo").withSchemaName("bar");
global::DripSharp.Testing.JavaAssertJ.That(sequence.getSchemaName()).IsEqualTo("bar");
global::DripSharp.Testing.JavaAssertJ.That(sequence.getFullyQualifiedName()).IsEqualTo("bar.foo");
}

public virtual void testSetDatabase() {
global::DripSharp.SqlTrellis.Schema.Sequence sequence = new global::DripSharp.SqlTrellis.Schema.Sequence().withName("foo").withSchemaName("bar").withDatabase(new global::DripSharp.SqlTrellis.Schema.Database("default"));
global::DripSharp.Testing.JavaAssertJ.That(sequence.getDatabase().getDatabaseName()).IsEqualTo("default");
global::DripSharp.Testing.JavaAssertJ.That(sequence.getFullyQualifiedName()).IsEqualTo("default.bar.foo");
}

public virtual void testSetPartialName() {
global::DripSharp.SqlTrellis.Schema.Sequence sequence = new global::DripSharp.SqlTrellis.Schema.Sequence();
sequence.setName("foo");
sequence.setDatabase(new global::DripSharp.SqlTrellis.Schema.Database("default"));
global::DripSharp.Testing.JavaAssertJ.That(sequence.getFullyQualifiedName()).IsEqualTo("default..foo");
}

[Xunit.Fact]
public void __Upstream_a15e30526a7e63ee()
{
        try
        {
            this.testSetDatabase();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d9c617a331b9d941()
{
        try
        {
            this.testSetName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f6b7567a523fae4()
{
        try
        {
            this.testSetPartialName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7682961364a5de6c()
{
        try
        {
            this.testSetSchemaName();
        }
        finally
        {
        }
}
}
