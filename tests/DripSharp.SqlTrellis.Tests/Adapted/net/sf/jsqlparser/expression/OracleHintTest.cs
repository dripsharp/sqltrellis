// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class OracleHintTest {
internal virtual void testSelect() {
string sqlString = "SELECT /*+parallel*/ * from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

internal virtual void testDelete() {
string sqlString = "DELETE /*+parallel*/ from dual";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

internal virtual void testInsert() {
string sqlString = "INSERT /*+parallel*/ INTO dual VALUES(1)";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

internal virtual void testUpdate() {
string sqlString = "UPDATE /*+parallel*/ dual SET a=b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

internal virtual void testMerge() {
string sqlString = "MERGE /*+parallel*/ INTO dual USING z ON (a=b) WHEN MATCHED THEN UPDATE SET a=b";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlString, true);
}

[Xunit.Fact]
public void __Upstream_77738a3f723d1e1e()
{
        try
        {
            this.testDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f4682e62c2e78e9a()
{
        try
        {
            this.testInsert();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f51679971851c00a()
{
        try
        {
            this.testMerge();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_aaa7205db9677c57()
{
        try
        {
            this.testSelect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ef02c4edbc6b1d12()
{
        try
        {
            this.testUpdate();
        }
        finally
        {
        }
}
}
