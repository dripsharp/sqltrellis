// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Merge;

public class MergeTest {
public virtual void testOracleMergeIntoStatement() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO bonuses B\n", "USING (\n"), "  SELECT employee_id, salary\n"), "  FROM employee\n"), "  WHERE dept_no =20) E\n"), "ON (B.employee_id = E.employee_id)\n"), "WHEN MATCHED THEN\n"), "  UPDATE SET B.bonus = E.salary * 0.1\n"), "WHEN NOT MATCHED THEN\n"), "  INSERT (B.employee_id, B.bonus)\n"), "  VALUES (E.employee_id, E.salary * 0.05)  ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testMergeIssue232() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO xyz using dual ", "ON ( custom_id = ? ) "), "WHEN matched THEN "), "UPDATE SET abc = sysdate "), "WHEN NOT matched THEN "), "INSERT (custom_id) VALUES (?)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testMergeIssue676() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("merge INTO M_KC21 USING\n", "(SELECT AAA, BBB FROM I_KC21 WHERE I_KC21.aaa = 'li_kun'\n"), ") TEMP ON (TEMP.AAA = M_KC21.AAA)\n"), "WHEN MATCHED THEN\n"), "UPDATE SET M_KC21.BBB = 6 WHERE enterprise_id IN (0, 1)\n"), "WHEN NOT MATCHED THEN\n"), "INSERT VALUES\n"), "(TEMP.AAA,TEMP.BBB\n"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testComplexOracleMergeIntoStatement() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO DestinationValue Dest USING\n", "(SELECT TheMonth ,\n"), "  IdentifyingKey ,\n"), "  SUM(NetPrice) NetPrice ,\n"), "  SUM(NetDeductionPrice) NetDeductionPrice ,\n"), "  MAX(CASE RowNumberMain WHEN 1 THEN QualityIndicator ELSE NULL END) QualityIndicatorMain ,\n"), "  MAX(CASE RowNumberDeduction WHEN 1 THEN QualityIndicator ELSE NULL END) QualityIndicatorDeduction \n"), "FROM\n"), "  (SELECT pd.TheMonth ,\n"), "    COALESCE(pd.IdentifyingKey, 0) IdentifyingKey ,\n"), "    COALESCE(CASE pd.IsDeduction WHEN 1 THEN NULL ELSE ConvertedCalculatedValue END, 0) NetPrice ,\n"), "    COALESCE(CASE pd.IsDeduction WHEN 1 THEN ConvertedCalculatedValue ELSE NULL END, 0) NetDeductionPrice ,\n"), "    pd.QualityIndicator ,\n"), "    row_number() OVER (PARTITION BY pd.TheMonth , pd.IdentifyingKey ORDER BY COALESCE(pd.QualityMonth, to_date('18991230', 'yyyymmdd')) DESC ) RowNumberMain ,\n"), "    NULL RowNumberDeduction\n"), "  FROM PricingData pd\n"), "  WHERE pd.ThingsKey      IN (:ThingsKeys)\n"), "  AND pd.TheMonth       >= :startdate\n"), "  AND pd.TheMonth       <= :enddate\n"), "  AND pd.IsDeduction = 0\n"), "  UNION ALL\n"), "  SELECT pd.TheMonth ,\n"), "    COALESCE(pd.IdentifyingKey, 0) IdentifyingKey ,\n"), "    COALESCE(CASE pd.IsDeduction WHEN 1 THEN NULL ELSE ConvertedCalculatedValue END, 0) NetPrice ,\n"), "    COALESCE(CASE pd.IsDeduction WHEN 1 THEN ConvertedCalculatedValue ELSE NULL END, 0) NetDeductionPrice ,\n"), "    pd.QualityIndicator ,\n"), "    NULL RowNumberMain ,\n"), "    row_number() OVER (PARTITION BY pd.TheMonth , pd.IdentifyingKey ORDER BY COALESCE(pd.QualityMonth, to_date('18991230', 'yyyymmdd')) DESC ) RowNumberDeduction \n"), "  FROM PricingData pd\n"), "  WHERE pd.ThingsKey       IN (:ThingsKeys)\n"), "  AND pd.TheMonth        >= :startdate\n"), "  AND pd.TheMonth        <= :enddate\n"), "  AND pd.IsDeduction <> 0\n"), "  )\n"), "GROUP BY TheMonth ,\n"), "  IdentifyingKey\n"), ") Data ON ( Dest.TheMonth = Data.TheMonth \n"), "            AND COALESCE(Dest.IdentifyingKey,0) = Data.IdentifyingKey )\n"), "WHEN MATCHED THEN\n"), "  UPDATE\n"), "  SET NetPrice        = ROUND(Data.NetPrice, PriceDecimalScale) ,\n"), "    DeductionPrice    = ROUND(Data.NetDeductionPrice, PriceDecimalScale) ,\n"), "    SubTotalPrice     = ROUND(Data.NetPrice + (Data.NetDeductionPrice * Dest.HasDeductions), PriceDecimalScale) ,\n"), "    QualityIndicator  =\n"), "    CASE Dest.HasDeductions\n"), "      WHEN 0\n"), "      THEN Data.QualityIndicatorMain\n"), "      ELSE\n"), "        CASE\n"), "          WHEN COALESCE(Data.CheckMonth1, to_date('18991230', 'yyyymmdd'))> COALESCE(Data.CheckMonth2,to_date('18991230', 'yyyymmdd'))\n"), "          THEN Data.QualityIndicatorMain\n"), "          ELSE Data.QualityIndicatorDeduction\n"), "        END\n"), "    END ,\n"), "    RecUser = :recuser ,\n"), "    RecDate = :recdate\n"), "  WHERE 1 =1\n"), "  AND IsImportant = 1\n"), "  AND COALESCE(Data.SomeFlag,-1) <> COALESCE(ROUND(Something, 1),-1)\n"), "  DELETE WHERE\n"), "  IsImportant = 0\n"), "  OR COALESCE(Data.SomeFlag,-1) = COALESCE(ROUND(Something, 1),-1)\n"), " WHEN NOT MATCHED THEN \n"), "  INSERT\n"), "    (\n"), "      TheMonth ,\n"), "      ThingsKey ,\n"), "      IsDeduction ,\n"), "      CreatedAt \n"), "    )\n"), "    VALUES\n"), "    (\n"), "      Data.TheMonth ,\n"), "      Data.ThingsKey ,\n"), "      Data.IsDeduction ,\n"), "      SYSDATE\n"), "    )\n");
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testMergeUpdateInsertOrderIssue401() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("MERGE INTO a USING dual ON (col3 = ? AND col1 = ? AND col2 = ?) WHEN NOT MATCHED THEN INSERT (col1, col2, col3, col4) VALUES (?, ?, ?, ?) WHEN MATCHED THEN UPDATE SET col4 = col4 + ?");
}

public virtual void testMergeUpdateInsertOrderIssue401_2() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("MERGE INTO a USING dual ON (col3 = ? AND col1 = ? AND col2 = ?) WHEN MATCHED THEN UPDATE SET col4 = col4 + ? WHEN NOT MATCHED THEN INSERT (col1, col2, col3, col4) VALUES (?, ?, ?, ?)");
}

public virtual void testOracleHint() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE /*+ SOMEHINT */ INTO bonuses B\n", "USING (\n"), "  SELECT employee_id, salary\n"), "  FROM employee\n"), "  WHERE dept_no =20) E\n"), "ON (B.employee_id = E.employee_id)\n"), "WHEN MATCHED THEN\n"), "  UPDATE SET B.bonus = E.salary * 0.1\n"), "WHEN NOT MATCHED THEN\n"), "  INSERT (B.employee_id, B.bonus)\n"), "  VALUES (E.employee_id, E.salary * 0.05)  ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertOracleHintExists(sql, true, "SOMEHINT");
}

public virtual void testInsertMergeWhere() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("-- Both clauses present.\n", "MERGE INTO test1 a\n"), "  USING all_objects b\n"), "    ON (a.object_id = b.object_id)\n"), "  WHEN MATCHED THEN\n"), "    UPDATE SET a.status = b.status\n"), "    WHERE  b.status != 'VALID'\n"), "  WHEN NOT MATCHED THEN\n"), "    INSERT (object_id, status)\n"), "    VALUES (b.object_id, b.status)\n"), "\n"), "    WHERE  b.status != 'VALID'\n");
global::DripSharp.SqlTrellis.Statement.Statement statement = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
global::DripSharp.SqlTrellis.Statement.Merge.Merge merge = (global::DripSharp.SqlTrellis.Statement.Merge.Merge)(statement!);
global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert mergeInsert = merge.getMergeInsert();
global::DripSharp.Testing.JavaAssertJ.That(mergeInsert.getWhereCondition());
global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate mergeUpdate = merge.getMergeUpdate();
global::DripSharp.Testing.JavaAssertJ.That(mergeUpdate.getWhereCondition());
}

public virtual void testWith() {
string statement = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "WITH a\n"), "     AS (SELECT 1 id_instrument_ref)\n"), "select * from a ");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(statement, true);
}

public virtual void testOutputClause() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("", "WITH\n"), "        WMachine AS\n"), "        (   SELECT\n"), "                DISTINCT \n"), "                ProjCode,\n"), "                PlantCode,\n"), "                BuildingCode,\n"), "                FloorCode,\n"), "                Room\n"), "            FROM\n"), "                TAB_MachineLocation\n"), "            WHERE\n"), "                TRIM(Room) <> '' AND TRIM(Room) <> '-'\n"), "        ) \n"), "    MERGE INTO\n"), "        TAB_RoomLocation AS TRoom\n"), "    USING\n"), "        WMachine\n"), "    ON\n"), "        (\n"), "            TRoom.ProjCode = WMachine.ProjCode\n"), "        AND TRoom.PlantCode = WMachine.PlantCode\n"), "        AND TRoom.BuildingCode = WMachine.BuildingCode\n"), "        AND TRoom.FloorCode = WMachine.FloorCode\n"), "        AND TRoom.Room = WMachine.Room)\n"), "    WHEN NOT MATCHED /* BY TARGET */ THEN\n"), "    INSERT\n"), "        (\n"), "            ProjCode,\n"), "            PlantCode,\n"), "            BuildingCode,\n"), "            FloorCode,\n"), "            Room\n"), "        )\n"), "        VALUES\n"), "        (\n"), "            WMachine.ProjCode,\n"), "            WMachine.PlantCode,\n"), "            WMachine.BuildingCode,\n"), "            WMachine.FloorCode,\n"), "            WMachine.Room\n"), "        )\n"), "        OUTPUT GETDATE() AS TimeAction,\n"), "        $action as Action,\n"), "        INSERTED.ProjCode,\n"), "        INSERTED.PlantCode,\n"), "        INSERTED.BuildingCode,\n"), "        INSERTED.FloorCode,\n"), "        INSERTED.Room\n"), "    INTO\n"), "        TAB_MergeActions_RoomLocation");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public virtual void testSnowflakeMergeStatementSimple() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO target\n", "  USING src ON target.k = src.k\n"), "  WHEN MATCHED THEN UPDATE SET target.v = src.v");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

public virtual void testSnowflakeMergeStatementWithMatchedAndPredicate() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO target\n", "  USING src ON target.k = src.k\n"), "  WHEN MATCHED AND src.v = 11 THEN UPDATE SET target.v = src.v");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

internal virtual void testSnowflakeMergeStatementWithNotMatchedAndPredicate() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO target USING (select k, max(v) as v from src group by k) AS b ON target.k = b.k\n", "  WHEN MATCHED THEN UPDATE SET target.v = b.v\n"), "  WHEN NOT MATCHED AND b.v != 11 THEN INSERT (k, v) VALUES (b.k, b.v)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

internal virtual void testSnowflakeMergeStatementWithManyWhensAndDelete() {
string sql = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("MERGE INTO t1 USING t2 ON t1.t1Key = t2.t2Key\n", "    WHEN MATCHED AND t2.marked = 1 THEN DELETE\n"), "    WHEN MATCHED AND t2.isNewStatus = 1 THEN UPDATE SET val = t2.newVal, status = t2.newStatus\n"), "    WHEN MATCHED THEN UPDATE SET val = t2.newVal\n"), "    WHEN NOT MATCHED THEN INSERT (val, status) VALUES (t2.newVal, t2.newStatus)");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sql, true);
}

internal virtual void testDeriveOperationsFromStandardClauses(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Merge.MergeOperation> expectedOperations, global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate update, global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert insert, bool insertFirst) {
global::DripSharp.SqlTrellis.Statement.Merge.Merge merge = new global::DripSharp.SqlTrellis.Statement.Merge.Merge();
merge.setMergeUpdate(update);
merge.setMergeInsert(insert);
merge.setInsertFirst(insertFirst);
global::DripSharp.Testing.JavaAssertJ.That(merge.getOperations()).IsEqualTo(expectedOperations);
}

private static global::DripSharp.Runtime.JavaStream<object> deriveOperationsFromStandardClausesCases() {
global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate update = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate>();
global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert insert = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert>();
return global::DripSharp.Runtime.JavaCompat.Stream<object>(global::DripSharp.Runtime.JavaCompat.StreamOf<object>(new object[] { global::DripSharp.Runtime.JavaCompat.AsList<object>(update, insert), update, insert, false }, new object[] { global::DripSharp.Runtime.JavaCompat.AsList<object>(insert, update), update, insert, true }));
}

internal virtual void testDeriveStandardClausesFromOperations(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Merge.MergeOperation> operations, global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate expectedUpdate, global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert expectedInsert, bool expectedInsertFirst) {
global::DripSharp.SqlTrellis.Statement.Merge.Merge merge = new global::DripSharp.SqlTrellis.Statement.Merge.Merge();
merge.setOperations(operations);
global::DripSharp.Testing.JavaAssertJ.That(merge.getMergeUpdate()).IsEqualTo(expectedUpdate);
global::DripSharp.Testing.JavaAssertJ.That(merge.getMergeInsert()).IsEqualTo(expectedInsert);
global::DripSharp.Testing.JavaAssertJ.That(merge.isInsertFirst()).IsEqualTo(expectedInsertFirst);
}

private static global::DripSharp.Runtime.JavaStream<object> deriveStandardClausesFromOperationsCases() {
global::DripSharp.SqlTrellis.Statement.Merge.MergeDelete delete1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeDelete>();
global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate update1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate>();
global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate update2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate>();
global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert insert1 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert>();
global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert insert2 = global::DripSharp.Testing.JavaMockito.Mock<global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert>();
return global::DripSharp.Runtime.JavaCompat.Stream<object>(global::DripSharp.Runtime.JavaCompat.StreamOf<object>(new object[] { global::DripSharp.Runtime.JavaCompat.AsList<object>(update1, insert1), update1, insert1, false }, new object[] { global::DripSharp.Runtime.JavaCompat.AsList<object>(insert1, update1), update1, insert1, true }, new object[] { global::DripSharp.Runtime.JavaCompat.ListOf<global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate>(update1), update1, (object[])default!, false }, new object[] { global::DripSharp.Runtime.JavaCompat.ListOf<global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert>(insert1), (object[])default!, insert1, true }, new object[] { global::System.Array.Empty<object>(), (object[])default!, (object[])default!, false }, new object[] { global::DripSharp.Runtime.JavaCompat.AsList<object>(update1, update2, delete1, insert1, insert2), update1, insert1, false }, new object[] { global::DripSharp.Runtime.JavaCompat.AsList<object>(insert1, insert2, update1, update2, delete1), update1, insert1, true }));
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_7aa11077aaaf3e45()
{
    foreach (var value in deriveOperationsFromStandardClausesCases())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Merge.MergeOperation>>(row[0]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate>(row[1]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert>(row[2]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<bool>(row[3]) };
    }
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_aea055c09aaa0faa()
{
    foreach (var value in deriveStandardClausesFromOperationsCases())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Merge.MergeOperation>>(row[0]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate>(row[1]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert>(row[2]), global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<bool>(row[3]) };
    }
}

[Xunit.Fact]
public void __Upstream_a2659c235dd07e9c()
{
        try
        {
            this.testComplexOracleMergeIntoStatement();
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_7aa11077aaaf3e45")]
public void __Upstream_bccf31952cfd3dd7(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Merge.MergeOperation> expectedOperations, global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate update, global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert insert, bool insertFirst)
{
        try
        {
            this.testDeriveOperationsFromStandardClauses(expectedOperations, update, insert, insertFirst);
        }
        finally
        {
        }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_aea055c09aaa0faa")]
public void __Upstream_606c50a4751878d6(global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Statement.Merge.MergeOperation> operations, global::DripSharp.SqlTrellis.Statement.Merge.MergeUpdate expectedUpdate, global::DripSharp.SqlTrellis.Statement.Merge.MergeInsert expectedInsert, bool expectedInsertFirst)
{
        try
        {
            this.testDeriveStandardClausesFromOperations(operations, expectedUpdate, expectedInsert, expectedInsertFirst);
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_91dc95ac27da7313()
{
        try
        {
            this.testInsertMergeWhere();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8d91899b9c82b9bf()
{
        try
        {
            this.testMergeIssue232();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b5c74648fe6c6d1e()
{
        try
        {
            this.testMergeIssue676();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_84023558819745f6()
{
        try
        {
            this.testMergeUpdateInsertOrderIssue401();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a8ec03f236d4ea19()
{
        try
        {
            this.testMergeUpdateInsertOrderIssue401_2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4a499ea91d41bcf1()
{
        try
        {
            this.testOracleHint();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_02a3837e2e4ddff4()
{
        try
        {
            this.testOracleMergeIntoStatement();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b7d232ec223f87e4()
{
        try
        {
            this.testOutputClause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_29d8154219f3ea48()
{
        try
        {
            this.testSnowflakeMergeStatementSimple();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f3ab58c57d07c8f4()
{
        try
        {
            this.testSnowflakeMergeStatementWithManyWhensAndDelete();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b677de8c379433cf()
{
        try
        {
            this.testSnowflakeMergeStatementWithMatchedAndPredicate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5839f465f6dd548b()
{
        try
        {
            this.testSnowflakeMergeStatementWithNotMatchedAndPredicate();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_502e3c6cc0317b45()
{
        try
        {
            this.testWith();
        }
        finally
        {
        }
}
}
