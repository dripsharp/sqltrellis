// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class ReflectionTestUtils {
public static readonly global::System.Func<global::System.Reflection.MethodInfo, bool> GETTER_METHODS = (m) => ((!(typeof(void).IsAssignableFrom(m.ReturnType)) && (m.GetParameters().Length == 0)) && (global::DripSharp.Runtime.JavaCompat.StringStartsWith(m.Name, "get") || global::DripSharp.Runtime.JavaCompat.StringStartsWith(m.Name, "is")));

public static readonly global::System.Func<global::System.Reflection.MethodInfo, bool> SETTER_METHODS = (m) => ((typeof(void).IsAssignableFrom(m.ReturnType) && (m.GetParameters().Length == 1)) && global::DripSharp.Runtime.JavaCompat.StringStartsWith(m.Name, "set"));

public static readonly global::System.Func<global::System.Reflection.MethodInfo, bool> CHAINING_METHODS = (m) => (m.DeclaringType.IsAssignableFrom(m.ReturnType) && (m.GetParameters().Length == 1));

public static void testGetterSetterChaining(global::System.Collections.Generic.IList<object> objs, params global::System.Func<global::System.Reflection.MethodInfo, bool>[] testMethodFilter) {
global::DripSharp.SqlTrellis.Util.RandomUtils.pushObjects(objs);
global::DripSharp.Runtime.JavaCompat.ForEach(objs, (o) => {
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.testMethodInvocation(o, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.anyReturnType, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.reflectiveNonNullArgs, global::DripSharp.SqlTrellis.Tests.Support.ArrayInsert(0, testMethodFilter, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.GETTER_METHODS, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.notDeclaredInObjectClass));
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.testMethodInvocation(o, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.noReturnTypeValid, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.reflectiveNonNullArgs, global::DripSharp.SqlTrellis.Tests.Support.ArrayInsert(0, testMethodFilter, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.SETTER_METHODS, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.notDeclaredInObjectClass));
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.testMethodInvocation(o, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.returnTypeThis, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.reflectiveNonNullArgs, global::DripSharp.SqlTrellis.Tests.Support.ArrayInsert(0, testMethodFilter, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.CHAINING_METHODS, global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.notDeclaredInObjectClass));
});
}

private static bool notDeclaredInObjectClass(global::System.Reflection.MethodInfo m) {
return !(global::DripSharp.Runtime.JavaCompat.Equals(typeof(object), m.DeclaringType));
}

private static object[] reflectiveNonNullArgs(global::System.Reflection.MethodInfo m) {
global::System.Collections.Generic.IList<object> @params = new global::System.Collections.Generic.List<object>();
foreach (global::System.Reflection.ParameterInfo p in m.GetParameters()) {
global::System.Type type = p.ParameterType;
object value = global::DripSharp.SqlTrellis.Util.RandomUtils.getRandomValueForType<object>(type);
global::DripSharp.Testing.JavaAssertions.AssumeTrue((value != default!), global::DripSharp.Runtime.JavaCompat.Concat("cannot get random value for type ", type));
global::DripSharp.Runtime.JavaCompat.Add(@params, value);
}
return global::DripSharp.Runtime.JavaCompat.ToObjectArray(@params);
}

private static bool returnTypeThis(object returnValue, global::System.Reflection.MethodInfo m) {
return ((returnValue != default!) && global::DripSharp.Runtime.JavaCompat.Equals(m.DeclaringType, ((object)(returnValue)).GetType()));
}

private static bool anyReturnType(object returnValue, global::System.Reflection.MethodInfo m) {
return true;
}

private static bool noReturnTypeValid(object returnValue, global::System.Reflection.MethodInfo m) {
return (returnValue == default!);
}

public static void testMethodInvocation(object @object, global::DripSharp.Runtime.JavaBiPredicate<object, global::System.Reflection.MethodInfo> returnTypeCheck, global::System.Func<global::System.Reflection.MethodInfo, object[]> argsFunction, params global::System.Func<global::System.Reflection.MethodInfo, bool>[] methodFilters) {
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.log(global::DripSharp.Runtime.JavaLogLevel.Info, global::DripSharp.Runtime.JavaCompat.Concat("testing methods of class ", ((object)(@object)).GetType()));
foreach (global::System.Reflection.MethodInfo m in (((object)(@object)).GetType()).GetMethods()) {
bool testMethod = true;
foreach (global::System.Func<global::System.Reflection.MethodInfo, bool> f in methodFilters) {
if (!f(m)) {
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.log(global::DripSharp.Runtime.JavaLogLevel.Fine, global::DripSharp.Runtime.JavaCompat.Concat("skip method ", m.ToString()));
testMethod = false;
break;
}
}
if (testMethod) {
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.log(global::DripSharp.Runtime.JavaLogLevel.Info, global::DripSharp.Runtime.JavaCompat.Concat("testing method ", m.ToString()));
try {
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.invoke(m, returnTypeCheck, argsFunction, @object);
} catch (global::System.Exception e) when (e is not global::System.TypeInitializationException) {
global::DripSharp.Testing.JavaAssertions.False(false, global::DripSharp.Runtime.JavaCompat.JavaStringFormat("%s throws on invocation on object: %s", m.ToString(), ((object)(@object)).GetType()));
}
}
}
}

public static void invoke(global::System.Reflection.MethodInfo method, global::DripSharp.Runtime.JavaBiPredicate<object, global::System.Reflection.MethodInfo> returnValueCheck, global::System.Func<global::System.Reflection.MethodInfo, object[]> argsFunction, object @object) {
try {
object returnValue = method.Invoke(@object, argsFunction(method));
if (!(typeof(void).IsAssignableFrom(method.ReturnType))) {
global::DripSharp.Testing.JavaAssertions.True(returnValueCheck(returnValue, method), global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("unexpected return-value with type ", ((object)(returnValue)).GetType()), " for method "), method.ToString()));
}
} catch (global::Xunit.Sdk.SkipException tae) {
global::DripSharp.SqlTrellis.Util.ReflectionTestUtils.log(global::DripSharp.Runtime.JavaLogLevel.Info, global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("skip methods ", method.ToString()), ", detail: "), global::DripSharp.Runtime.JavaCompat.ExceptionMessage(tae)));
}
}

private static void log(global::DripSharp.Runtime.JavaLogLevel level, string @string) {
if (global::DripSharp.Runtime.JavaLogger.GetLogger("anonymous").IsLoggable(level)) {
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(@string);
}
}
}
