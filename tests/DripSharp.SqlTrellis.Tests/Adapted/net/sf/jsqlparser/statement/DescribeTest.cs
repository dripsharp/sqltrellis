// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class DescribeTest {
public virtual void testDescribe() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DESCRIBE foo.products");
}

public virtual void testDescribeIssue1931() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DESC table_name");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("EXPLAIN table_name");
}

public virtual void testDescribeIssue1212() {
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed("DESCRIBE file_azbs.productcategory.json");
}

[Xunit.Fact]
public void __Upstream_c7f8ad00b9b7ce84()
{
        try
        {
            this.testDescribe();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_50650a1382cd7421()
{
        try
        {
            this.testDescribeIssue1212();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6364ed4db82d29df()
{
        try
        {
            this.testDescribeIssue1931();
        }
        finally
        {
        }
}
}
