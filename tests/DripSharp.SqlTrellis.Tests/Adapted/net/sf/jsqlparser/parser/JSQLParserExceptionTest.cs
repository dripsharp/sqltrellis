// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser;

public class JSQLParserExceptionTest {
public virtual void testExceptionWithCause() {
global::System.ArgumentException arg1 = new global::System.ArgumentException();
global::DripSharp.SqlTrellis.JSQLParserException ex1 = new global::DripSharp.SqlTrellis.JSQLParserException("", arg1);
global::DripSharp.Testing.JavaAssertions.Same(arg1, global::DripSharp.Runtime.JavaCompat.GetCause(ex1)!, null);
}

public virtual void testExceptionPrintStacktrace() {
global::System.ArgumentException arg1 = new global::System.ArgumentException("BRATKARTOFFEL");
global::DripSharp.SqlTrellis.JSQLParserException ex1 = new global::DripSharp.SqlTrellis.JSQLParserException("", arg1);
global::System.IO.StringWriter sw = new global::System.IO.StringWriter();
global::DripSharp.Runtime.JavaCompat.PrintStackTrace(ex1, sw);
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.StringContains(sw.ToString(), "BRATKARTOFFEL"), null);
global::DripSharp.Runtime.JavaByteArrayOutputStream bos = new global::DripSharp.Runtime.JavaByteArrayOutputStream();
global::DripSharp.Runtime.JavaCompat.PrintStackTrace(ex1, new global::System.IO.StreamWriter(bos, global::System.Text.Encoding.UTF8, 1024, true) { AutoFlush = true });
global::DripSharp.Testing.JavaAssertions.True(global::DripSharp.Runtime.JavaCompat.StringContains(global::DripSharp.Runtime.JavaCompat.NewString(global::DripSharp.Runtime.JavaCompat.ToSignedBytes(bos), global::DripSharp.Runtime.JavaStandardCharsets.UTF8), "BRATKARTOFFEL"), null);
}

public virtual void testExceptionPrintStacktraceNoCause() {
global::DripSharp.SqlTrellis.JSQLParserException ex1 = new global::DripSharp.SqlTrellis.JSQLParserException("", (global::System.Exception)default!);
global::System.IO.StringWriter sw = new global::System.IO.StringWriter();
global::DripSharp.Runtime.JavaCompat.PrintStackTrace(ex1, sw);
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.StringContains(sw.ToString(), "BRATKARTOFFEL"), null);
global::DripSharp.Runtime.JavaByteArrayOutputStream bos = new global::DripSharp.Runtime.JavaByteArrayOutputStream();
global::DripSharp.Runtime.JavaCompat.PrintStackTrace(ex1, new global::System.IO.StreamWriter(bos, global::System.Text.Encoding.UTF8, 1024, true) { AutoFlush = true });
global::DripSharp.Testing.JavaAssertions.False(global::DripSharp.Runtime.JavaCompat.StringContains(global::DripSharp.Runtime.JavaCompat.NewString(global::DripSharp.Runtime.JavaCompat.ToSignedBytes(bos), global::DripSharp.Runtime.JavaStandardCharsets.UTF8), "BRATKARTOFFEL"), null);
}

public virtual void testExceptionDefaultContructorCauseInit() {
global::DripSharp.SqlTrellis.JSQLParserException ex1 = new global::DripSharp.SqlTrellis.JSQLParserException();
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.GetCause(ex1)!, null);
ex1 = new global::DripSharp.SqlTrellis.JSQLParserException((global::System.Exception)default!);
global::DripSharp.Testing.JavaAssertions.Null(global::DripSharp.Runtime.JavaCompat.GetCause(ex1)!, null);
}

[Xunit.Fact]
public void __Upstream_96175a0fd99c5b1e()
{
        try
        {
            this.testExceptionDefaultContructorCauseInit();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e7d38290e98aaae0()
{
        try
        {
            this.testExceptionPrintStacktrace();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4986eabf412c8af7()
{
        try
        {
            this.testExceptionPrintStacktraceNoCause();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_46a7ce7264044045()
{
        try
        {
            this.testExceptionWithCause();
        }
        finally
        {
        }
}
}
