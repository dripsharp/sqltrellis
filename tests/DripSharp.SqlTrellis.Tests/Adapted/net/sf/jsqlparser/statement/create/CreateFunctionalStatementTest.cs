// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Create;

public class CreateFunctionalStatementTest {
public virtual void createFunctionMinimal() {
string statement = "CREATE FUNCTION foo RETURN 5; END;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Function.CreateFunction().addFunctionDeclarationParts("foo").addFunctionDeclarationParts(global::DripSharp.Runtime.JavaCompat.AsList<string>("RETURN 5;", "END;")), statement);
}

public virtual void createFunctionLong() {
global::DripSharp.SqlTrellis.Statement.Create.Function.CreateFunction stm = (global::DripSharp.SqlTrellis.Statement.Create.Function.CreateFunction)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE FUNCTION fun(query_from_time date) RETURNS TABLE(foo double precision, bar double precision)\n", "    LANGUAGE plpgsql\n"), "    AS $$\n"), "      BEGIN\n"), "       RETURN QUERY\n"), "      WITH bla AS (\n"), "        SELECT * from foo)\n"), "      Select * from bla;\n"), "      END;\n"), "      $$;"))!);
global::DripSharp.Testing.JavaAssertJ.That(stm).IsNotNull();
global::DripSharp.Testing.JavaAssertJ.That(stm.formatDeclaration()).Contains("fun ( query_from_time date )");
}

public virtual void createProcedureMinimal() {
string statement = "CREATE PROCEDURE foo AS BEGIN END;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(new global::DripSharp.SqlTrellis.Statement.Create.Procedure.CreateProcedure().addFunctionDeclarationParts("foo", "AS").addFunctionDeclarationParts(global::DripSharp.Runtime.JavaCompat.AsList<string>("BEGIN", "END;")), statement);
}

public virtual void createProcedureLong() {
global::DripSharp.SqlTrellis.Statement.Create.Procedure.CreateProcedure stm = (global::DripSharp.SqlTrellis.Statement.Create.Procedure.CreateProcedure)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE PROCEDURE remove_emp (employee_id NUMBER) AS\n", "   tot_emps NUMBER;\n"), "   BEGIN\n"), "      DELETE FROM employees\n"), "      WHERE employees.employee_id = remove_emp.employee_id;\n"), "   tot_emps := tot_emps - 1;\n"), "   END;"))!);
global::DripSharp.Testing.JavaAssertJ.That(stm).IsNotNull();
global::DripSharp.Testing.JavaAssertJ.That(stm.formatDeclaration()).Contains("remove_emp ( employee_id NUMBER )");
}

public virtual void createOrReplaceFunctionMinimal() {
string statement = "CREATE OR REPLACE FUNCTION foo RETURN 5; END;";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement);
global::DripSharp.SqlTrellis.Statement.Create.Function.CreateFunction func = new global::DripSharp.SqlTrellis.Statement.Create.Function.CreateFunction().addFunctionDeclarationParts("foo").addFunctionDeclarationParts(global::DripSharp.Runtime.JavaCompat.AsList<string>("RETURN 5;", "END;"));
func.setOrReplace(true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertDeparse(func, statement);
}

[Xunit.Fact]
public void __Upstream_20ecd878b7b0c24e()
{
        try
        {
            this.createFunctionLong();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0986096566aa46df()
{
        try
        {
            this.createFunctionMinimal();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_61bfaa0a89ca358f()
{
        try
        {
            this.createOrReplaceFunctionMinimal();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_cae3ea3f82924be1()
{
        try
        {
            this.createProcedureLong();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_47ad4590dfc038c9()
{
        try
        {
            this.createProcedureMinimal();
        }
        finally
        {
        }
}
}
