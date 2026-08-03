// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class RandomUtils {
private static readonly global::DripSharp.Runtime.JavaLogger LOG = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Util.RandomUtils).FullName ?? typeof(global::DripSharp.SqlTrellis.Util.RandomUtils).Name));

private static readonly global::DripSharp.Runtime.JavaRandom RANDOM = new global::DripSharp.Runtime.JavaRandom();

private static readonly global::DripSharp.Runtime.JavaThreadLocal<global::System.Collections.Generic.IDictionary<global::System.Type, object>> OBJECTS = global::DripSharp.Runtime.JavaThreadLocal<global::System.Collections.Generic.IDictionary<global::System.Type, object>>.WithInitial(() => default!);

public static void pushObjects(global::System.Collections.Generic.IList<object> obj) {
global::System.Collections.Generic.IDictionary<global::System.Type, object> m = global::DripSharp.Runtime.JavaCompat.NewJavaDictionary<global::System.Type, object>();
(global::DripSharp.SqlTrellis.Util.RandomUtils.OBJECTS).Set(m);
global::DripSharp.Runtime.JavaCompat.ForEach(global::DripSharp.Runtime.JavaCompat.Stream(obj), (o) => {
global::DripSharp.Runtime.JavaCompat.MapPut(m, ((object)(o)).GetType(), o);
foreach (global::System.Type iface in (((object)(o)).GetType()).GetInterfaces()) {
global::DripSharp.Runtime.JavaCompat.MapPut(m, iface, o);
}
global::System.Type cls = ((object)(o)).GetType();
while (((cls = cls.BaseType) != default!)) {
if (!(global::DripSharp.Runtime.JavaCompat.Equals(typeof(object), cls))) {
global::DripSharp.Runtime.JavaCompat.MapPut(m, cls, o);
}
}
});
}

public static T getRandomValueForType<T>(global::System.Type type) {
object value = default!;
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(int), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(int), type))) {
value = global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM.NextInt();
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(long), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(long), type))) {
value = global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM.NextLong();
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(bool), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(bool), type))) {
value = global::DripSharp.SqlTrellis.Tests.Support.RandomBoolean(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM);
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(float), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(float), type))) {
value = global::DripSharp.SqlTrellis.Tests.Support.RandomFloat(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM);
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(double), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(double), type))) {
value = global::DripSharp.SqlTrellis.Tests.Support.RandomDouble(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM);
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(sbyte), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(sbyte), type))) {
sbyte[] b = new sbyte[1];
global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM.NextBytes(b);
value = b[0];
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(short), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(short), type))) {
value = (short)(global::DripSharp.SqlTrellis.Tests.Support.RandomInt(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM, 15));
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(char), type)) {
value = global::DripSharp.SqlTrellis.Tests.Support.RandomString(1).ToCharArray()[0];
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::DripSharp.Runtime.JavaSqlTime), type)) {
value = global::DripSharp.SqlTrellis.Tests.Support.SqlTimeFromMillis(global::System.Math.Abs(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM.NextLong()));
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::DripSharp.Runtime.JavaSqlTimestamp), type)) {
value = global::DripSharp.SqlTrellis.Tests.Support.SqlTimestampFromMillis(global::System.Math.Abs(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM.NextLong()));
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::DripSharp.Runtime.JavaSqlDate), type)) {
value = global::DripSharp.SqlTrellis.Tests.Support.SqlDateFromMillis(global::System.Math.Abs(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM.NextLong()));
} else {
int size = global::DripSharp.SqlTrellis.Tests.Support.RandomInt(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM, 10);
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(string), type)) {
value = global::DripSharp.SqlTrellis.Tests.Support.RandomString(size);
} else {
if ((global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::System.Collections.ICollection), type) || global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::System.Collections.IList), type))) {
global::System.Collections.Generic.IList<object> c__106_30 = new global::System.Collections.Generic.List<object>();
value = c__106_30;
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::System.Collections.ICollection), type)) {
global::System.Collections.Generic.ISet<object> c__109_29 = new global::System.Collections.Generic.HashSet<object>();
value = c__109_29;
} else {
if (type.IsArray) {
object[] a = (object[])(global::System.Array.CreateInstance(type.GetElementType(), size)!);
for (int i = 0; (i < size); i++) {
a[i] = global::DripSharp.SqlTrellis.Util.RandomUtils.getRandomValueForType<object>(type.GetElementType());
}
value = a;
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::System.Collections.IDictionary), type)) {
global::System.Collections.Generic.IDictionary<object, object> c__118_37 = global::DripSharp.Runtime.JavaCompat.NewJavaDictionary<object, object>();
value = c__118_37;
} else {
if (global::DripSharp.Runtime.JavaCompat.Equals(typeof(global::System.DateTime), type)) {
value = global::System.DateTime.Now;
} else {
value = global::DripSharp.Runtime.JavaCompat.MapGet((global::DripSharp.SqlTrellis.Util.RandomUtils.OBJECTS).Get(), type);
if ((value! == default!)) {
if (type.IsEnum) {
global::System.Collections.Generic.ISet<object> enums = global::DripSharp.SqlTrellis.Tests.Support.EnumValues(global::DripSharp.Runtime.JavaCompat.ClassAsSubclass(type, typeof(object)));
value = global::DripSharp.Runtime.JavaCompat.ListGet(new global::System.Collections.Generic.List<object>(enums), global::DripSharp.SqlTrellis.Tests.Support.RandomInt(global::DripSharp.SqlTrellis.Util.RandomUtils.RANDOM, global::DripSharp.Runtime.JavaCompat.CollectionCount(enums)));
} else {
try {
value = global::DripSharp.Runtime.JavaCompat.ConstructorInvoke<object>(global::DripSharp.Runtime.JavaCompat.ClassGetConstructor(type));
} catch (global::System.Exception e) when (e is global::System.MemberAccessException or global::System.ArgumentException or global::System.Reflection.TargetInvocationException or global::System.MissingMethodException or global::System.Security.SecurityException) {
(global::DripSharp.SqlTrellis.Util.RandomUtils.LOG).Log(global::DripSharp.Runtime.JavaLogLevel.Warning, global::DripSharp.Runtime.JavaCompat.Concat("cannot get default instance with reflection for type ", type));
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
}
T t = global::DripSharp.Runtime.JavaCompat.CastReference<T>(value);
return t!;
}
}
