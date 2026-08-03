// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser;

public class CCJSqlParserTest {
public virtual void parserWithTimeout() {
global::DripSharp.SqlTrellis.Parser.CCJSqlParser parser = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.newParser("foo").withTimeOut(123L);
long? timeOut = parser.getAsLong(global::DripSharp.SqlTrellis.Parser.Feature.Feature.timeOut);
global::DripSharp.Testing.JavaAssertJ.That(timeOut).IsEqualTo(123L);
}

[Xunit.Fact]
public void __Upstream_d3387deb7d767c99()
{
        try
        {
            this.parserWithTimeout();
        }
        finally
        {
        }
}
}
