// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Alter;

public class AlterSystemTest {
public virtual void testStatement() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SYSTEM KILL SESSION '13, 8'", true);
}

public virtual void testStatementVisitorAdaptor() {
string sqlStr = "ALTER SYSTEM KILL SESSION '13, 8'";
((global::DripSharp.SqlTrellis.Statement.Statement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr))).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(new global::DripSharp.SqlTrellis.Statement.StatementVisitorAdapter<object>()));
}

public virtual void testTableNamesFinder() {
string sqlStr = "ALTER SYSTEM KILL SESSION '13, 8'";
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr);
global::System.Collections.Generic.IList<string> tables = new global::DripSharp.SqlTrellis.Util.TablesNamesFinder<object>().getTableList(statement);
global::DripSharp.Testing.JavaAssertions.Equal(0, global::DripSharp.Runtime.JavaCompat.CollectionCount(tables), null);
}

public virtual void testValidator() {
string sqlStr = "ALTER SYSTEM KILL SESSION '13, 8'";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sqlStr, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testObjectAccess() {
string sqlStr = "ALTER SYSTEM KILL SESSION '13, 8'";
global::DripSharp.SqlTrellis.Statement.Alter.AlterSystemStatement statement = (global::DripSharp.SqlTrellis.Statement.Alter.AlterSystemStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterSystemOperation.KILL_SESSION, statement.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal("'13, 8'", global::DripSharp.Runtime.JavaCompat.ListGet(statement.getParameters(), 0), null);
}

[Xunit.Fact]
public void __Upstream_2e6fff045280423d()
{
        try
        {
            this.testObjectAccess();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_166eab2a62ac0acc()
{
        try
        {
            this.testStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a2697ab0f3344571()
{
        try
        {
            this.testStatementVisitorAdaptor();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6a3e6bbf9570d235()
{
        try
        {
            this.testTableNamesFinder();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bafd406d4f41a952()
{
        try
        {
            this.testValidator();
        }
        finally
        {
        }
}
}
