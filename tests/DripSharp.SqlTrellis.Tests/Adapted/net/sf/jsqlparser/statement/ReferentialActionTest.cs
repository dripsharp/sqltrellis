// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class ReferentialActionTest {
internal virtual void testCaseSensitivity() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("CREATE TABLE DATABASES\n", "(\n"), "NAME VARCHAR(50) NOT NULL,\n"), "OWNER VARCHAR(50) NOT NULL,\n"), "PRIMARY KEY (NAME),\n"), "FOREIGN KEY(OWNER) REFERENCES USERS (USERNAME) ON delete cascade\n"), ")");
global::DripSharp.SqlTrellis.Test.TestUtils.assertSqlCanBeParsedAndDeparsed(sqlStr, true);
}

[Xunit.Fact]
public void __Upstream_7e00458b11d18b95()
{
        try
        {
            this.testCaseSensitivity();
        }
        finally
        {
        }
}
}
