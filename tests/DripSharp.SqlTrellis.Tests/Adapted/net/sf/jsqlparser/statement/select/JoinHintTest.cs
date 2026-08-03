// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement.Select;

public class JoinHintTest {
public static global::DripSharp.Runtime.JavaStream<string> sqlStrings() {
return global::DripSharp.Runtime.JavaCompat.Stream<string>(global::DripSharp.Runtime.JavaCompat.StreamOf<string>(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT p.Name, pr.ProductReviewID  \n", "FROM Production.Product AS p  \n"), "LEFT OUTER HASH JOIN Production.ProductReview AS pr  \n"), "ON p.ProductID = pr.ProductID  \n"), "ORDER BY ProductReviewID DESC"), global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("DELETE spqh   \n", "FROM Sales.SalesPersonQuotaHistory AS spqh  \n"), "    INNER LOOP JOIN Sales.SalesPerson AS sp  \n"), "    ON spqh.SalesPersonID = sp.SalesPersonID  \n"), "WHERE sp.SalesYTD > 2500000.00"), global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("SELECT poh.PurchaseOrderID, poh.OrderDate, pod.ProductID, pod.DueDate, poh.VendorID   \n", "FROM Purchasing.PurchaseOrderHeader AS poh  \n"), "INNER MERGE JOIN Purchasing.PurchaseOrderDetail AS pod   \n"), "    ON poh.PurchaseOrderID = pod.PurchaseOrderID")));
}

internal virtual void testJoinHint(string sqlStr) {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_81cf6e7278be1888()
{
    foreach (var value in sqlStrings())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<string>(row[0]) };
    }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_81cf6e7278be1888")]
public void __Upstream_e0635f05b2af5732(string sqlStr)
{
        try
        {
            this.testJoinHint(sqlStr);
        }
        finally
        {
        }
}
}
