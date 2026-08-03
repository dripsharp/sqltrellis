// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Schema;

public class ColumnTest {
public virtual void testCheckNonFinalClass() {
global::DripSharp.SqlTrellis.Schema.Column myColumn = new Anonymous_27_27((global::DripSharp.SqlTrellis.Schema.Table)default!, "myColumn");
global::DripSharp.Testing.JavaAssertions.Equal("anonymous class", myColumn.ToString(), null);
}

private sealed class Anonymous_27_27 : global::DripSharp.SqlTrellis.Schema.Column {
public Anonymous_27_27(global::DripSharp.SqlTrellis.Schema.Table baseArgument0, string baseArgument1) : base(baseArgument0, baseArgument1) {}

public override string ToString() {
return "anonymous class";
}
}

public virtual void testConstructorNameParts() {
global::DripSharp.SqlTrellis.Schema.Column column = new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.Runtime.JavaCompat.ListOf<string>("schema", "table", "column"));
global::DripSharp.Testing.JavaAssertJ.That(column.getColumnName()).IsEqualTo("column");
global::DripSharp.SqlTrellis.Schema.Table table = column.getTable();
global::DripSharp.Testing.JavaAssertJ.That(table.getNameParts()).ContainsExactly("table", "schema");
global::DripSharp.Testing.JavaAssertJ.That(table.getNamePartDelimiters()).ContainsExactly(".");
}

public virtual void testConstructorNamePartsAndDelimiters() {
global::DripSharp.SqlTrellis.Schema.Column column = new global::DripSharp.SqlTrellis.Schema.Column(global::DripSharp.Runtime.JavaCompat.ListOf<string>("a", "b", "c", "d"), global::DripSharp.Runtime.JavaCompat.ListOf<string>(":", ".", ":"));
global::DripSharp.Testing.JavaAssertJ.That(column.getColumnName()).IsEqualTo("d");
global::DripSharp.SqlTrellis.Schema.Table table = column.getTable();
global::DripSharp.Testing.JavaAssertJ.That(table.getNameParts()).ContainsExactly("c", "b", "a");
global::DripSharp.Testing.JavaAssertJ.That(table.getNamePartDelimiters()).ContainsExactly(".", ":");
}

[Xunit.Fact]
public void __Upstream_cf969c1057b74a1f()
{
        try
        {
            this.testCheckNonFinalClass();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8222c3c23f3bde01()
{
        try
        {
            this.testConstructorNameParts();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_198c53065d76daa2()
{
        try
        {
            this.testConstructorNamePartsAndDelimiters();
        }
        finally
        {
        }
}
}
