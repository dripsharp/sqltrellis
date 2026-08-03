// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Show;

public class ShowTablesStatementTest {
public virtual void showTables() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW TABLES");
}

public virtual void showTablesModifiers() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW EXTENDED FULL TABLES");
}

public virtual void showTablesFromDbName() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW EXTENDED TABLES FROM db_name");
}

public virtual void showTablesInDbName() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW FULL TABLES IN db_name");
}

public virtual void showTablesLikeExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW TABLES LIKE '%FOO%'");
}

public virtual void showTablesWhereExpression() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("SHOW TABLES WHERE table_name = 'FOO'");
}

public virtual void testObject() {
global::DripSharp.SqlTrellis.Statement.Show.ShowTablesStatement showTablesStatement = (global::DripSharp.SqlTrellis.Statement.Show.ShowTablesStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SHOW TABLES WHERE table_name = 'FOO'")!);
global::DripSharp.Testing.JavaAssertions.Equal(0, global::DripSharp.Runtime.JavaCompat.CollectionCount(showTablesStatement.getModifiers()), null);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(showTablesStatement.getWhereCondition(), "table_name = 'FOO'");
showTablesStatement = (global::DripSharp.SqlTrellis.Statement.Show.ShowTablesStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SHOW FULL TABLES IN db_name")!);
global::DripSharp.Testing.JavaAssertions.Equal(1, global::DripSharp.Runtime.JavaCompat.CollectionCount(showTablesStatement.getModifiers()), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Show.ShowTablesStatement.SelectionMode.IN, showTablesStatement.getSelectionMode(), null);
showTablesStatement = (global::DripSharp.SqlTrellis.Statement.Show.ShowTablesStatement)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse("SHOW TABLES LIKE '%FOO%'")!);
global::DripSharp.SqlTrellis.Test.TestUtils.assertExpressionCanBeDeparsedAs(showTablesStatement.getLikeExpression(), "'%FOO%'");
}

[Xunit.Fact]
public void __Upstream_570c108b1074a764()
{
        try
        {
            this.showTables();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ae72db2219cc64b2()
{
        try
        {
            this.showTablesFromDbName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_53548e599b4975a1()
{
        try
        {
            this.showTablesInDbName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8381944f56bb73df()
{
        try
        {
            this.showTablesLikeExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a8f1c8ad17060d76()
{
        try
        {
            this.showTablesModifiers();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab6116d8521d4028()
{
        try
        {
            this.showTablesWhereExpression();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d4d35d900e24c285()
{
        try
        {
            this.testObject();
        }
        finally
        {
        }
}
}
