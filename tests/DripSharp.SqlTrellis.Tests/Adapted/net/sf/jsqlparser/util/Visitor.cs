// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public interface Visitor<T> {
public bool visit(T t);
}

public sealed class __VisitorFunctionalAdapter<T> : global::DripSharp.SqlTrellis.Util.Visitor<T> {
private readonly global::System.Func<T, bool> implementation;

public __VisitorFunctionalAdapter(global::System.Func<T, bool> implementation) {
this.implementation = implementation;
}

public bool visit(T t) {
return this.implementation(t);
}
}
