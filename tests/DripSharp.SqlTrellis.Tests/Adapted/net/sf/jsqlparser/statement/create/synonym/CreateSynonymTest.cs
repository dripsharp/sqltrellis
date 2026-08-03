// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create.Synonym;

public class CreateSynonymTest {
public virtual void createPublic() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE PUBLIC SYNONYM TBL_TABLE_NAME FOR SCHEMA.T_TBL_NAME");
}

public virtual void createWithReplace() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE OR REPLACE SYNONYM TBL_TABLE_NAME FOR SCHEMA.T_TBL_NAME");
}

public virtual void createWithReplacePublic() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE OR REPLACE PUBLIC SYNONYM TBL_TABLE_NAME FOR SCHEMA.T_TBL_NAME");
}

public virtual void createWithDbLink() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("CREATE PUBLIC SYNONYM emp_table FOR hr.employees@remote.us.oracle.com");
}

public virtual void synonymAttributes() {
global::DripSharp.SqlTrellis.Statement.Create.Synonym.CreateSynonym createSynonym = (global::DripSharp.SqlTrellis.Statement.Create.Synonym.CreateSynonym)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("CREATE OR REPLACE PUBLIC SYNONYM TBL_TABLE_NAME FOR SCHEMA.T_TBL_NAME")!);
global::DripSharp.Testing.JavaAssertJ.That(createSynonym.isOrReplace()).IsTrue();
global::DripSharp.Testing.JavaAssertJ.That(createSynonym.isPublicSynonym()).IsTrue();
global::DripSharp.Testing.JavaAssertJ.That(createSynonym.getSynonym().getFullyQualifiedName()).IsEqualTo("TBL_TABLE_NAME");
global::DripSharp.Testing.JavaAssertJ.That(createSynonym.getFor()).IsEqualTo("SCHEMA.T_TBL_NAME");
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(createSynonym.getForList()), null);
global::DripSharp.Testing.JavaAssertions.Equal("NEW_TBL_TABLE_NAME", createSynonym.withSynonym(new global::DripSharp.SqlTrellis.Schema.Synonym().withName("NEW_TBL_TABLE_NAME")).getSynonym().getName(), null);
}

[Xunit.Fact]
public void __Upstream_113d5ba34ae9b97e()
{
        try
        {
            this.createPublic();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6108b4a4dfec8a37()
{
        try
        {
            this.createWithDbLink();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0a6887106ca06955()
{
        try
        {
            this.createWithReplace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4e6c01ec8bf01928()
{
        try
        {
            this.createWithReplacePublic();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_692dd0a38b06bb98()
{
        try
        {
            this.synonymAttributes();
        }
        finally
        {
        }
}
}
