// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class ExecuteValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationExecute() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("EXECUTE myproc 'a', 2, 'b'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

public virtual void testValidationExec() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("EXEC myproc 'a', 2, 'b'", "EXEC procedure @param = 1", "EXEC procedure @param = 'foo'", "EXEC procedure @param = 'foo', @param2 = 'foo2'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

public virtual void testValidationCall() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CALL myproc 'a', 2, 'b'", "CALL BAR.FOO", "CALL myproc ('a', 2, 'b')")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}
}

public virtual void testValidationCallNotSupported() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CALL myproc 'a', 2, 'b'", "CALL BAR.FOO", "CALL myproc ('a', 2, 'b')")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Parser.Feature.Feature.executeCall);
}
}

public virtual void testValidationExecuteNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("EXECUTE myproc 'a', 2, 'b'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.execute, global::DripSharp.SqlTrellis.Parser.Feature.Feature.executeExecute);
}
}

public virtual void testValidationExecNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("EXEC myproc 'a', 2, 'b'", "EXEC procedure @param = 1", "EXEC procedure @param = 'foo'", "EXEC procedure @param = 'foo', @param2 = 'foo2'")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.execute, global::DripSharp.SqlTrellis.Parser.Feature.Feature.executeExec);
}
}

public virtual void testValidationCallNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CALL myproc 'a', 2, 'b'", "CALL BAR.FOO", "CALL myproc ('a', 2, 'b')")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.execute, global::DripSharp.SqlTrellis.Parser.Feature.Feature.executeCall);
}
}

[Xunit.Fact]
public void __Upstream_dcb58ada5abd905e()
{
        try
        {
            this.testValidationCall();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_986ffc093c161d9b()
{
        try
        {
            this.testValidationCallNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50b35620e18b00f1()
{
        try
        {
            this.testValidationCallNotSupported();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b1c215819ae1e2f()
{
        try
        {
            this.testValidationExec();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_96b4b0e6e2ef883f()
{
        try
        {
            this.testValidationExecNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4410d2549916e38d()
{
        try
        {
            this.testValidationExecute();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6565c624556792ee()
{
        try
        {
            this.testValidationExecuteNotAllowed();
        }
        finally
        {
        }
}
}
