// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ReturningClauseTest {
internal virtual void returnIntoTest() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("  insert into emp\n", "  (empno, ename)\n"), "  values\n"), "  (seq_emp.nextval, 'morgan')\n"), "  returning empno\n"), "  into x");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_a6f1474a7356e828()
{
        try
        {
            this.returnIntoTest();
        }
        finally
        {
        }
}
}
