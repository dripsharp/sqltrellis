// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Test;

public class TestException : global::System.Exception {
private global::System.Exception cause = default!;

public TestException() : base() {

}

public TestException(string arg0) : base(arg0) {

}

public TestException(global::System.Exception arg0) {
this.cause = arg0;
}

public TestException(string arg0, global::System.Exception arg1) : base(arg0) {
this.cause = arg1;
}

public virtual global::System.Exception getCause() => this.cause;

public virtual void printStackTrace() => this.printStackTrace(global::System.Console.Error);

public virtual void printStackTrace(global::System.IO.TextWriter writer) => global::DripSharp.SqlTrellis.Tests.Support.PrintStackTrace(this, this.cause, writer);

private void printStackTraceToPrintStream(global::System.IO.TextWriter writer) => this.printStackTrace(writer);
}
