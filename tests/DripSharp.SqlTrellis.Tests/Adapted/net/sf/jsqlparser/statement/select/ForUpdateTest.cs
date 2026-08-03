// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class ForUpdateTest {
internal virtual void testOracleForUpdate() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT e.employee_id, e.salary, e.commission_pct\n", "   FROM employees e, departments d\n"), "   WHERE job_id = 'SA_REP'\n"), "   AND e.department_id = d.department_id\n"), "   AND location_id = 2500\n"), "   ORDER BY e.employee_id\n"), "   FOR UPDATE;\n");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT e.employee_id, e.salary, e.commission_pct\n", "   FROM employees e JOIN departments d\n"), "   USING (department_id)\n"), "   WHERE job_id = 'SA_REP'\n"), "   AND location_id = 2500\n"), "   ORDER BY e.employee_id\n"), "   FOR UPDATE OF e.salary;");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

internal virtual void testMySqlIssue1995() {
string sqlStr = "select * from t_demo where a = 1 order by b asc limit 1 for update";
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_3b42a51ae20b25e3()
{
        try
        {
            this.testMySqlIssue1995();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_97f9a4bfb1e1f8d8()
{
        try
        {
            this.testOracleForUpdate();
        }
        finally
        {
        }
}
}
