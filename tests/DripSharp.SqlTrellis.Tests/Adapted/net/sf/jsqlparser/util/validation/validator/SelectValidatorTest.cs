// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class SelectValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationSelectNotAllowed() {
string sql = "SELECT 1";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DDL, global::DripSharp.SqlTrellis.Parser.Feature.Feature.select);
}

public virtual void testValidationSelectDistinct() {
string sql = "SELECT DISTINCT a, b FROM tab";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationSelectUnique() {
string sql = "SELECT UNIQUE a, b FROM tab";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.MariaDbVersion.ORACLE_MODE);
}

public virtual void testValidationFetchAndOffset() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SELECT * FROM mytable t WHERE t.col = 9 ORDER BY t.id FETCH FIRST 5 ROWS ONLY", "SELECT * FROM mytable t WHERE t.col = 9 ORDER BY t.id OFFSET 3 ROWS", "SELECT * FROM mytable t WHERE t.col = 9 ORDER BY t.id OFFSET 3 ROWS FETCH NEXT 5 ROWS ONLY")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

public virtual void testValidationUnion() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat("SELECT * FROM mytable WHERE mytable.col = 9 UNION ", "SELECT * FROM mytable3 WHERE mytable3.col = ?");
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationSqlIntersect() {
string sql = "(SELECT * FROM a) INTERSECT (SELECT * FROM b)";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidationForUpdateWaitWithTimeout() {
string sql = "SELECT * FROM mytable FOR UPDATE WAIT 60";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB);
}

public virtual void testValidationForShare() {
string sql = "SELECT * FROM mytable FOR SHARE";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}

public virtual void testValidationForPostgresShare() {
string sql = "SELECT * FROM mytable FOR KEY SHARE";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
string sql2 = "SELECT * FROM mytable FOR NO KEY UPDATE";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql2, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql2, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Parser.Feature.Feature.selectForNoKeyUpdate);
}

public virtual void testValidationForUpdateNoWait() {
string sql = "SELECT * FROM mytable FOR UPDATE NOWAIT";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL);
}

public virtual void testValidationJoinOuterSimple() {
string sql = "SELECT * FROM foo AS f, OUTER bar AS b WHERE f.id = b.id";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Parser.Feature.Feature.joinOuterSimple);
}

public virtual void testValidationJoin() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SELECT t1.col, t2.col, t1.id FROM tab1 t1, tab2 t2 WHERE t1.id = t2.id", "SELECT t1.col, t2.col, t1.id FROM tab1 t1 JOIN tab2 t2 ON t1.id = t2.id", "SELECT t1.col, t2.col, t1.id FROM tab1 t1 INNER JOIN tab2 t2 ON t1.id = t2.id")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testOracleHierarchicalQuery() {
string sql = "SELECT last_name, employee_id, manager_id, LEVEL FROM employees START WITH employee_id = 100 CONNECT BY PRIOR employee_id = manager_id ORDER SIBLINGS BY last_name";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testOracleJoin() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM tabelle1, tabelle2 WHERE tabelle1.a = tabelle2.b(+)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testValidationLeftRightJoin() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SELECT t1.col, t2.col, t1.id FROM tab1 t1 LEFT JOIN tab2 t2 ON t1.id = t2.id", "SELECT t1.col, t2.col, t1.id FROM tab1 t1 LEFT OUTER JOIN tab2 t2 ON t1.id = t2.id", "SELECT t1.col, t2.col, t1.id FROM tab1 t1 RIGHT JOIN tab2 t2 ON t1.id = t2.id", "SELECT t1.col, t2.col, t1.id FROM tab1 t1 RIGHT OUTER JOIN tab2 t2 ON t1.id = t2.id", "SELECT t1.col, t2.col, t1.id FROM tab1 t1 OUTER JOIN tab2 t2 ON t1.id = t2.id")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testValidationWith() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("WITH DINFO (DEPTNO, AVGSALARY, EMPCOUNT) AS ", "(SELECT OTHERS.WORKDEPT, AVG(OTHERS.SALARY), COUNT(*) FROM EMPLOYEE AS OTHERS "), "GROUP BY OTHERS.WORKDEPT), DINFOMAX AS (SELECT MAX(AVGSALARY) AS AVGMAX FROM DINFO) "), "SELECT THIS_EMP.EMPNO, THIS_EMP.SALARY, DINFO.AVGSALARY, DINFO.EMPCOUNT, DINFOMAX.AVGMAX "), "FROM EMPLOYEE AS THIS_EMP INNER JOIN DINFO INNER JOIN DINFOMAX "), "WHERE THIS_EMP.JOB = 'SALESREP' AND THIS_EMP.WORKDEPT = DINFO.DEPTNO");
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(statement, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidationWithRecursive() {
string statement = "WITH RECURSIVE t (n) AS ((SELECT 1) UNION ALL (SELECT n + 1 FROM t WHERE n < 100)) SELECT sum(n) FROM t";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(statement, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(statement, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Parser.Feature.Feature.withItemRecursive);
}

public virtual void testSelectMulipleExpressionList() {
string sql = "SELECT * FROM mytable WHERE (SSN, SSM) IN (('11111111111111', '22222222222222'))";
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}

public virtual void testValidatePivotWithAlias() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM (SELECT * FROM mytable LEFT JOIN mytable2 ON Factor_ID = Id) f PIVOT (max(f.value) FOR f.factoryCode IN (ZD, COD, SW, PH))", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

public virtual void testValidatePivotXml() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM mytable PIVOT XML (count(a) FOR b IN ('val1'))", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

public virtual void testValidateUnPivot() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("select * from pivot_table unpivot (yearly_total for order_mode in (store as 'direct', internet as 'online')) order by year, order_mode", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

public virtual void testValidateSubJoin() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT * FROM ((tabc c INNER JOIN tabn n ON n.ref = c.id) INNER JOIN taba a ON a.REF = c.id)", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}

public virtual void testValidateTableFunction() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("SELECT f2 FROM SOME_FUNCTION()", "SELECT f2 FROM SOME_FUNCTION(1, 'val')")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
}
}

public virtual void testValidateLateral() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("SELECT O.ORDERID, O.CUSTNAME, OL.LINETOTAL FROM ORDERS AS O, LATERAL(SELECT SUM(NETAMT) AS LINETOTAL FROM ORDERLINES AS LINES WHERE LINES.ORDERID = O.ORDERID) AS OL", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testValidateIssue1502() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("select b.id, name ,(select name from Blog where name = 'sadf') as name2 ", ", category, owner, b.update_time "), "from Blog as b "), "left join Content "), "ON b.id = Content.blog_id "), "where name = 'sadf' order by Content.title desc"), 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}

[Xunit.Fact]
public void __Upstream_bcc268386f86e722()
{
        try
        {
            this.testOracleHierarchicalQuery();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_2b578e8849c6edac()
{
        try
        {
            this.testOracleJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_88af049fd9b365ff()
{
        try
        {
            this.testSelectMulipleExpressionList();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_73d3cbc1321d4638()
{
        try
        {
            this.testValidateIssue1502();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8ec703a81507c76a()
{
        try
        {
            this.testValidateLateral();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_0157ea1692ddc404()
{
        try
        {
            this.testValidatePivotWithAlias();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3f6cf1fa412ee495()
{
        try
        {
            this.testValidatePivotXml();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e2031f45c6e885ab()
{
        try
        {
            this.testValidateSubJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ab9538efc3c7ba89()
{
        try
        {
            this.testValidateTableFunction();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_afff371eae36f0ab()
{
        try
        {
            this.testValidateUnPivot();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3c3a557dee2492da()
{
        try
        {
            this.testValidationFetchAndOffset();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_74d294363dae46ee()
{
        try
        {
            this.testValidationForPostgresShare();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ec905a6da8170e2c()
{
        try
        {
            this.testValidationForShare();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6511bf4f218ea672()
{
        try
        {
            this.testValidationForUpdateNoWait();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7d060237353cb9a9()
{
        try
        {
            this.testValidationForUpdateWaitWithTimeout();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_00e332262a5a849a()
{
        try
        {
            this.testValidationJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7cbf097ddbfe6245()
{
        try
        {
            this.testValidationJoinOuterSimple();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_db3df3f3ddbfb0d2()
{
        try
        {
            this.testValidationLeftRightJoin();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_26783c40bded8711()
{
        try
        {
            this.testValidationSelectDistinct();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e980c867ff896b3d()
{
        try
        {
            this.testValidationSelectNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_02ca77233d72a8fe()
{
        try
        {
            this.testValidationSelectUnique();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b9dae0cfd63cd9c7()
{
        try
        {
            this.testValidationSqlIntersect();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a92c460b255929de()
{
        try
        {
            this.testValidationUnion();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_1a4cfe17d61addc0()
{
        try
        {
            this.testValidationWith();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_892f85560f9d068e()
{
        try
        {
            this.testValidationWithRecursive();
        }
        finally
        {
        }
}
}
