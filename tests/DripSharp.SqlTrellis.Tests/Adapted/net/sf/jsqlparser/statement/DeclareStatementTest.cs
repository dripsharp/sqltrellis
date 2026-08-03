// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class DeclareStatementTest {
public DeclareStatementTest() {}

public virtual void testDeclareType() {
string statement = "DECLARE @find nvarchar (30)";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.DeclareStatement created = new global::DripSharp.SqlTrellis.Statement.DeclareStatement().addTypeDefExprList(new global::DripSharp.SqlTrellis.Statement.DeclareStatement.TypeDefExpr(new global::DripSharp.SqlTrellis.Expression.UserVariable().withName("find"), new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("nvarchar (30)"), (global::DripSharp.SqlTrellis.Expression.Expression)default!)).withDeclareType(global::DripSharp.SqlTrellis.Statement.DeclareType.TYPE);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDeclareTypeWithDefault() {
string statement = "DECLARE @find varchar (30) = 'Man%'";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.DeclareStatement created = new global::DripSharp.SqlTrellis.Statement.DeclareStatement().addTypeDefExprList(new global::DripSharp.SqlTrellis.Statement.DeclareStatement.TypeDefExpr(new global::DripSharp.SqlTrellis.Expression.UserVariable().withName("find"), new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("varchar (30)"), new global::DripSharp.SqlTrellis.Expression.StringValue().withValue("Man%"))).withDeclareType(global::DripSharp.SqlTrellis.Statement.DeclareType.TYPE);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDeclareTypeList() {
string statement = "DECLARE @group nvarchar (50), @sales money";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.DeclareStatement created = new global::DripSharp.SqlTrellis.Statement.DeclareStatement().addTypeDefExprList(global::DripSharp.SqlTrellis.Test.TestUtils.asList<global::DripSharp.SqlTrellis.Statement.DeclareStatement.TypeDefExpr>(new global::DripSharp.SqlTrellis.Statement.DeclareStatement.TypeDefExpr(new global::DripSharp.SqlTrellis.Expression.UserVariable().withName("group"), new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("nvarchar (50)"), (global::DripSharp.SqlTrellis.Expression.Expression)default!), new global::DripSharp.SqlTrellis.Statement.DeclareStatement.TypeDefExpr(new global::DripSharp.SqlTrellis.Expression.UserVariable().withName("sales"), new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("money"), (global::DripSharp.SqlTrellis.Expression.Expression)default!))).withDeclareType(global::DripSharp.SqlTrellis.Statement.DeclareType.TYPE);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDeclareTypeList2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DECLARE @group nvarchar (50), @sales varchar (50)");
}

public virtual void testDeclareTable() {
string statement = "DECLARE @MyTableVar TABLE (EmpID int NOT NULL, OldVacationHours int, NewVacationHours int, ModifiedDate datetime)";
global::DripSharp.SqlTrellis.Statement.Statement parsed = global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.DeclareStatement created = new global::DripSharp.SqlTrellis.Statement.DeclareStatement().withUserVariable(new global::DripSharp.SqlTrellis.Expression.UserVariable("MyTableVar")).withColumnDefinitions(new global::System.Collections.Generic.List<global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition>()).addColumnDefinitions(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("EmpID", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType().withDataType("int"), global::DripSharp.SqlTrellis.Test.TestUtils.asList<string>("NOT", "NULL")), new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("OldVacationHours", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType("int"))).addColumnDefinitions(global::DripSharp.SqlTrellis.Test.TestUtils.asList<global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition>(new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("NewVacationHours", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType("int")), new global::DripSharp.SqlTrellis.Statement.Create.Table.ColumnDefinition("ModifiedDate", new global::DripSharp.SqlTrellis.Statement.Create.Table.ColDataType("datetime")))).withDeclareType(global::DripSharp.SqlTrellis.Statement.DeclareType.TABLE);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(created, statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertEqualsObjectTree(parsed, created);
}

public virtual void testDeclareAs() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DECLARE @LocationTVP AS LocationTableType");
}

[Xunit.Fact]
public void __Upstream_7babdbde82decf2d()
{
        try
        {
            this.testDeclareAs();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_172ed635c64b2655()
{
        try
        {
            this.testDeclareTable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ac2351401e14341e()
{
        try
        {
            this.testDeclareType();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9cacf18e81985801()
{
        try
        {
            this.testDeclareTypeList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1db4d0eb0025091b()
{
        try
        {
            this.testDeclareTypeList2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_33010d5a3488cc26()
{
        try
        {
            this.testDeclareTypeWithDefault();
        }
        finally
        {
        }
}
}
