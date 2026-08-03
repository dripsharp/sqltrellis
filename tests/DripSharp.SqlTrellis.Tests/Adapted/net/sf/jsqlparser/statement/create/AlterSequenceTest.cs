// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class AlterSequenceTest {
public virtual void testCreateSequence_withIncrement() {
string statement = "ALTER SEQUENCE my_seq CACHE 100";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Alter.Sequence.AlterSequence created = new global::DripSharp.SqlTrellis.Statement.Alter.Sequence.AlterSequence().withSequence(new global::DripSharp.SqlTrellis.Schema.Sequence().withName("my_seq").addParameters(new global::DripSharp.SqlTrellis.Schema.Sequence.Parameter(global::DripSharp.SqlTrellis.Schema.Sequence.ParameterType.CACHE).withValue(100L)));
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

[Xunit.Fact]
public void __Upstream_1a3959201b728da6()
{
        try
        {
            this.testCreateSequence_withIncrement();
        }
        finally
        {
        }
}
}
