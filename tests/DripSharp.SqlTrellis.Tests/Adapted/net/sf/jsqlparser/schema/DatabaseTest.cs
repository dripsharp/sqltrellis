// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Schema;

public class DatabaseTest {
public virtual void testDatabaseSimple() {
string databaseName = "db1";
global::DripSharp.SqlTrellis.Schema.Database database = new global::DripSharp.SqlTrellis.Schema.Database(databaseName);
global::DripSharp.Testing.JavaAssertions.Equal(databaseName, database.getFullyQualifiedName(), null);
}

public virtual void testDatabaseAndServer() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server("SERVER", "INSTANCE");
string databaseName = "db1";
global::DripSharp.SqlTrellis.Schema.Database database = new global::DripSharp.SqlTrellis.Schema.Database(server, databaseName);
global::DripSharp.Testing.JavaAssertions.Equal("[SERVER\\INSTANCE].db1", database.getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Same(server, database.getServer(), null);
global::DripSharp.Testing.JavaAssertions.Equal(databaseName, database.getDatabaseName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("[SERVER\\INSTANCE].db1", database.ToString(), null);
}

public virtual void testNullDatabaseAndServer() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server("SERVER", "INSTANCE");
global::DripSharp.SqlTrellis.Schema.Database database = new global::DripSharp.SqlTrellis.Schema.Database(server, (string)default!);
global::DripSharp.Testing.JavaAssertions.Equal("[SERVER\\INSTANCE].", database.getFullyQualifiedName(), null);
global::DripSharp.Testing.JavaAssertions.Same(server, database.getServer(), null);
}

[Xunit.Fact]
public void __Upstream_ddde90c26c105ebf()
{
        try
        {
            this.testDatabaseAndServer();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f99733608d31fb41()
{
        try
        {
            this.testDatabaseSimple();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a246121641ee8223()
{
        try
        {
            this.testNullDatabaseAndServer();
        }
        finally
        {
        }
}
}
