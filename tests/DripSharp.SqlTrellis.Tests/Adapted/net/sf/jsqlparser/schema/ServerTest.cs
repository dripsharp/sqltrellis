// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Schema;

public class ServerTest {
public virtual void testServerNameParsing() {
string serverName = "LOCALHOST";
string fullServerName = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("[%s]", serverName);
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server(fullServerName);
global::DripSharp.Testing.JavaAssertions.Equal(serverName, server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(fullServerName, server.ToString(), null);
}

public virtual void testServerNameAndInstanceParsing() {
string serverName = "LOCALHOST";
string serverInstanceName = "SQLSERVER";
string fullServerName = global::DripSharp.Runtime.JavaCompat.JavaStringFormat("[%s\\%s]", serverName, serverInstanceName);
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server(fullServerName);
global::DripSharp.Testing.JavaAssertions.Equal(serverName, server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(serverInstanceName, server.getInstanceName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(fullServerName, server.ToString(), null);
}

public virtual void testServerNameAndInstanceParsing2() {
string simpleName = "LOCALHOST";
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server(simpleName);
global::DripSharp.Testing.JavaAssertions.Equal(simpleName, server.getFullyQualifiedName(), null);
}

public virtual void testServerNameAndInstanceParsingNull() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server((string)default!);
global::DripSharp.Testing.JavaAssertions.Equal("", server.getFullyQualifiedName(), null);
}

public virtual void testServerNameAndInstancePassValues() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server("SERVER", "INSTANCE");
global::DripSharp.Testing.JavaAssertions.Equal("SERVER", server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSTANCE", server.getInstanceName(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.JavaStringFormat("[%s\\%s]", "SERVER", "INSTANCE"), server.getFullyQualifiedName(), null);
}

public virtual void testServerNameNull() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server((string)default!, "INSTANCE");
global::DripSharp.Testing.JavaAssertions.Equal((object)default!, server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSTANCE", server.getInstanceName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("", server.getFullyQualifiedName(), null);
}

public virtual void testServerNameEmpty() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server("", "INSTANCE");
global::DripSharp.Testing.JavaAssertions.Equal("", server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("INSTANCE", server.getInstanceName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("", server.getFullyQualifiedName(), null);
}

public virtual void testInstanceNameNull() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server("LOCALHOST", (string)default!);
global::DripSharp.Testing.JavaAssertions.Equal("LOCALHOST", server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal((object)default!, server.getInstanceName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("[LOCALHOST]", server.getFullyQualifiedName(), null);
}

public virtual void testInstanceNameEmpty() {
global::DripSharp.SqlTrellis.Schema.Server server = new global::DripSharp.SqlTrellis.Schema.Server("LOCALHOST", "");
global::DripSharp.Testing.JavaAssertions.Equal("LOCALHOST", server.getServerName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("", server.getInstanceName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("[LOCALHOST]", server.getFullyQualifiedName(), null);
}

[Xunit.Fact]
public void __Upstream_935c3e3626766432()
{
        try
        {
            this.testInstanceNameEmpty();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a2423240ac6a3a04()
{
        try
        {
            this.testInstanceNameNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_a7878e9bb63b917d()
{
        try
        {
            this.testServerNameAndInstanceParsing();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_506828f5a828fa96()
{
        try
        {
            this.testServerNameAndInstanceParsing2();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b28452e3bd7ff35d()
{
        try
        {
            this.testServerNameAndInstanceParsingNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b7bdd295c445b8a2()
{
        try
        {
            this.testServerNameAndInstancePassValues();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b92da69d081e1559()
{
        try
        {
            this.testServerNameEmpty();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_3e4227cb77649ee2()
{
        try
        {
            this.testServerNameNull();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ae601f9047031800()
{
        try
        {
            this.testServerNameParsing();
        }
        finally
        {
        }
}
}
