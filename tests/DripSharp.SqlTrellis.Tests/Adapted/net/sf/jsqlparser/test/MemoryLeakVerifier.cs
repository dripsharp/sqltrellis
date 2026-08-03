// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Test;

public class MemoryLeakVerifier {
private const int MAX_GC_ITERATIONS = 50;

private const int GC_SLEEP_TIME = 100;

private readonly global::System.Collections.Generic.IList<global::DripSharp.Runtime.JavaWeakReference<object>> references = new global::System.Collections.Generic.List<global::DripSharp.Runtime.JavaWeakReference<object>>();

public virtual void addObject(object @object) {
global::DripSharp.Runtime.JavaCompat.Add(this.references, new global::DripSharp.Runtime.JavaWeakReference<object>(@object));
}

public virtual void assertGarbageCollected() {
this.assertGarbageCollected(global::DripSharp.SqlTrellis.Test.MemoryLeakVerifier.MAX_GC_ITERATIONS);
}

internal virtual void assertGarbageCollected(int maxIterations) {
try {
foreach (global::DripSharp.Runtime.JavaWeakReference<object> @ref in this.references) {
global::DripSharp.SqlTrellis.Test.MemoryLeakVerifier.assertGarbageCollected(@ref, maxIterations);
}
} catch (global::System.Threading.ThreadInterruptedException) {}
}

private static void assertGarbageCollected(global::DripSharp.Runtime.JavaWeakReference<object> @ref, int maxIterations) {
global::DripSharp.Runtime.JavaRuntime runtime = global::DripSharp.Runtime.JavaRuntime.getRuntime();
for (int i = 0; (i < maxIterations); i++) {
global::System.GC.WaitForPendingFinalizers();
global::System.GC.Collect();
if (((@ref == default!) || (@ref.Get() == default!))) {
break;
}
global::DripSharp.Runtime.JavaThread.Sleep((long)(global::DripSharp.SqlTrellis.Test.MemoryLeakVerifier.GC_SLEEP_TIME));
}
global::DripSharp.Testing.JavaAssertions.Null(@ref.Get(), global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("Object should not exist after ", global::DripSharp.SqlTrellis.Test.MemoryLeakVerifier.MAX_GC_ITERATIONS), " collections, but still had: "), @ref.Get()));
}
}
