// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Alter;

public class AlterSessionTest {
public virtual void testAlterSessionAdvise() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ADVISE COMMIT", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ADVISE ROLLBACK", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ADVISE NOTHING", true);
}

public virtual void testAlterSessionCloseDatabaseLink() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION CLOSE DATABASE LINK mylink", true);
}

public virtual void testAlterSessionEnable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE COMMIT IN PROCEDURE", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE GUARD", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE PARALLEL DML", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE PARALLEL DML PARALLEL 10", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE PARALLEL DDL", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE PARALLEL DDL PARALLEL 10", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE PARALLEL QUERY", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE PARALLEL QUERY PARALLEL 10", true);
}

public virtual void testAlterSessionDisable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION DISABLE COMMIT IN PROCEDURE", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION DISABLE GUARD", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION DISABLE PARALLEL DML", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION DISABLE PARALLEL DDL", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION DISABLE PARALLEL QUERY", true);
}

public virtual void testAlterSessionForceParallel() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION FORCE PARALLEL DML", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION FORCE PARALLEL DML PARALLEL 10", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION FORCE PARALLEL DDL", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION FORCE PARALLEL DDL PARALLEL 10", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION FORCE PARALLEL QUERY", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION FORCE PARALLEL QUERY PARALLEL 10", true);
}

public virtual void testAlterSessionSet() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION SET ddl_lock_timeout=7200", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION SET ddl_lock_timeout = 7200", true);
}

public virtual void testAlterSessionResumable() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION ENABLE RESUMABLE", true);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("ALTER SESSION DISABLE RESUMABLE", true);
}

public virtual void testObject() {
global::DripSharp.SqlTrellis.Statement.Alter.AlterSession alterSession = new global::DripSharp.SqlTrellis.Statement.Alter.AlterSession(global::DripSharp.SqlTrellis.Statement.Alter.AlterSessionOperation.FORCE_PARALLEL_QUERY, global::System.Array.Empty<string>());
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterSessionOperation.FORCE_PARALLEL_QUERY, alterSession.getOperation(), null);
alterSession.setOperation(global::DripSharp.SqlTrellis.Statement.Alter.AlterSessionOperation.DISABLE_PARALLEL_DML);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Statement.Alter.AlterSessionOperation.DISABLE_PARALLEL_DML, alterSession.getOperation(), null);
global::DripSharp.Testing.JavaAssertions.Equal(0, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterSession.getParameters()), null);
alterSession.setParameters(global::DripSharp.Runtime.JavaCompat.AsList<string>("PARALLEL", "6"));
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(alterSession.getParameters()), null);
}

[Xunit.Fact]
public void __Upstream_b464a67003a8669c()
{
        try
        {
            this.testAlterSessionAdvise();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e8919aaa137518a2()
{
        try
        {
            this.testAlterSessionCloseDatabaseLink();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bc3f443f4b906a3e()
{
        try
        {
            this.testAlterSessionDisable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_426dcc32acad54cf()
{
        try
        {
            this.testAlterSessionEnable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3026dee90a8f96d0()
{
        try
        {
            this.testAlterSessionForceParallel();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_85bffedafe239cb0()
{
        try
        {
            this.testAlterSessionResumable();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5460e7cd84dae31b()
{
        try
        {
            this.testAlterSessionSet();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8655d6f9a0676a31()
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
