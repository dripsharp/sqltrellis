// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util;

public class APISanitationTest {
private static readonly global::System.Collections.Generic.SortedSet<global::System.Type> CLASSES = new(global::System.Collections.Generic.Comparer<global::System.Type>.Create((left, right) => global::System.StringComparer.Ordinal.Compare(left.FullName ?? left.Name, right.FullName ?? right.Name)));

private static readonly global::DripSharp.Runtime.JavaLogger LOGGER = global::DripSharp.Runtime.JavaLogger.GetLogger((typeof(global::DripSharp.SqlTrellis.Util.APISanitationTest).FullName ?? typeof(global::DripSharp.SqlTrellis.Util.APISanitationTest).Name));

private static readonly global::System.Type[] EXPRESSION_CLASSES = new global::System.Type[] { typeof(global::DripSharp.SqlTrellis.Expression.Expression), typeof(global::DripSharp.SqlTrellis.Schema.Column), typeof(global::DripSharp.SqlTrellis.Expression.Function) };

public static void findClasses(Visitor<string> visitor)
{
    foreach (string className in global::DripSharp.SqlTrellis.Tests.Support.SqlTrellisJavaTypeNames())
    {
        if (!visitor.visit(className)) return;
    }
}

private static bool findClasses(global::System.IO.FileInfo root, global::System.IO.FileInfo file, Visitor<string> visitor)
{
    foreach (string className in global::DripSharp.SqlTrellis.Tests.Support.SqlTrellisJavaTypeNames())
    {
        if (!visitor.visit(className)) return false;
    }
    return true;
}

private static string createClassName(global::System.IO.FileInfo root, global::System.IO.FileInfo file) {
global::System.Text.StringBuilder sb = new global::System.Text.StringBuilder();
string fileName = file.Name;
sb.Append(fileName, 0, (fileName.LastIndexOf(".class", global::System.StringComparison.Ordinal) - 0));
global::System.IO.FileInfo file1 = global::DripSharp.SqlTrellis.Tests.Support.ParentFile(file);
while (((file1 != default!) && !(global::DripSharp.Runtime.JavaCompat.FileEquals(file1, root)))) {
sb.Insert(0, '.').Insert(0, file1.Name);
file1 = global::DripSharp.SqlTrellis.Tests.Support.ParentFile(file1);
}
return sb.ToString();
}

internal static void findRelevantClasses() {
global::DripSharp.SqlTrellis.Util.APISanitationTest.findClasses(new Anonymous_106_21());
}

private sealed class Anonymous_106_21 : global::DripSharp.SqlTrellis.Util.Visitor<string> {
public Anonymous_106_21() {}

public bool visit(string clazz) {
if (((global::DripSharp.Runtime.JavaCompat.StringStartsWith(clazz, "net.sf.jsqlparser.statement") || global::DripSharp.Runtime.JavaCompat.StringStartsWith(clazz, "net.sf.jsqlparser.expression")) || global::DripSharp.Runtime.JavaCompat.StringStartsWith(clazz, "net.sf.jsqlparser.schema"))) {
int lastDotIndex = clazz.LastIndexOf(".", global::System.StringComparison.Ordinal);
int last_Index = clazz.LastIndexOf("$", global::System.StringComparison.Ordinal);
string className = ((last_Index > 0) ? global::DripSharp.Runtime.JavaCompat.StringSubstring(clazz, lastDotIndex, last_Index) : clazz.Substring(lastDotIndex));
if (!((global::DripSharp.Runtime.JavaCompat.StringStartsWith(className.ToLowerInvariant(), "test") || global::DripSharp.Runtime.JavaCompat.StringEndsWith(className.ToLowerInvariant(), "test")))) {
try {
global::DripSharp.SqlTrellis.Util.APISanitationTest.CLASSES.Add(global::DripSharp.SqlTrellis.Tests.Support.ResolveSqlTrellisType(clazz));
} catch (global::System.TypeLoadException e) {
(global::DripSharp.SqlTrellis.Util.APISanitationTest.LOGGER).Log(global::DripSharp.Runtime.JavaLogLevel.Severe, "Class not found", e);
}
}
}
return true;
}
}

private static global::DripSharp.Runtime.JavaStream<global::System.Reflection.FieldInfo> fields()
{
    var fields = new global::System.Collections.Generic.SortedSet<global::System.Reflection.FieldInfo>(global::System.Collections.Generic.Comparer<global::System.Reflection.FieldInfo>.Create((left, right) => global::System.StringComparer.Ordinal.Compare(left.ToString(), right.ToString())));
    foreach (global::System.Type clazz in CLASSES)
    {
        if (clazz.IsEnum) continue;
        foreach (var field in clazz.GetFields(global::System.Reflection.BindingFlags.Instance | global::System.Reflection.BindingFlags.Static | global::System.Reflection.BindingFlags.Public | global::System.Reflection.BindingFlags.NonPublic | global::System.Reflection.BindingFlags.DeclaredOnly))
        {
            if ((global::DripSharp.Runtime.JavaCompat.ReflectionFieldModifiers(field) & 16) != 16) fields.Add(field);
        }
    }
    return global::DripSharp.Runtime.JavaCompat.Stream(fields);
}

internal virtual void testFieldAccess(global::System.Reflection.FieldInfo field) {
global::System.Type clazz = field.DeclaringType;
string fieldName = field.Name;
if (!(global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(fieldName, "$jacocoData"))) {
bool foundGetter = false;
bool foundSetter = false;
bool foundFluentSetter = false;
foreach (global::System.Reflection.MethodInfo method in clazz.GetMethods()) {
string methodName = method.Name;
global::System.Type typeClass = field.FieldType;
bool isBooleanType = (global::DripSharp.Runtime.JavaCompat.Equals(typeClass, typeof(bool)) || global::DripSharp.Runtime.JavaCompat.Equals(typeClass, typeof(bool)));
foundGetter |= (((((global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("get", fieldName), methodName) | (isBooleanType && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("is", fieldName), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "is")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(fieldName, methodName))) | (isBooleanType && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("has", fieldName), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(fieldName, methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("isUsing", fieldName.Substring("use".Length)), methodName)));
foundSetter |= (((((((global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("set", fieldName), methodName) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "is")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("set", fieldName.Substring("is".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("set", fieldName.Substring("has".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("setHas", fieldName.Substring("has".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("setHaving", fieldName.Substring("has".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("set", fieldName.Substring("use".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("setUse", fieldName.Substring("use".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("setUsing", fieldName.Substring("use".Length)), methodName)));
foundFluentSetter |= (((((((global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("with", fieldName), methodName) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "is")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("with", fieldName.Substring("is".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("with", fieldName.Substring("has".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("withHas", fieldName.Substring("has".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "has")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("withHaving", fieldName.Substring("has".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("with", fieldName.Substring("use".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("withUse", fieldName.Substring("use".Length)), methodName))) | ((isBooleanType && global::DripSharp.Runtime.JavaCompat.StringStartsWith(fieldName, "use")) && global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(global::DripSharp.Runtime.JavaCompat.Concat("withUsing", fieldName.Substring("use".Length)), methodName)));
}
if (!(((foundGetter && foundSetter) && foundFluentSetter))) {
string message = global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(fieldName, " "), (!foundGetter ? "[Getter] " : "")), (!foundSetter ? "[Setter] " : "")), (!foundFluentSetter ? "[Fluent Setter] " : "")), "missing");
global::DripSharp.SqlTrellis.Util.APISanitationTest.throwException(field, clazz, message);
}
}
}

internal virtual bool testGenericType(global::System.Reflection.FieldInfo field, global::System.Type boundClass)
{
    global::System.Type fieldType = field.FieldType;
    foreach (global::System.Type argument in fieldType.GetGenericArguments())
    {
        if (argument.IsAssignableFrom(boundClass)) return true;
        if (argument.IsGenericParameter)
        {
            foreach (global::System.Type bound in argument.GetGenericParameterConstraints())
                if (global::System.String.Equals(bound.FullName ?? bound.Name, boundClass.FullName ?? boundClass.Name, global::System.StringComparison.Ordinal)) return true;
        }
    }
    global::System.Type superclass = fieldType.BaseType;
    if (superclass is not null)
        foreach (global::System.Type argument in superclass.GetGenericArguments())
            if (argument.IsAssignableFrom(boundClass)) return true;
    return false;
}

internal virtual void testExpressionList(global::System.Reflection.FieldInfo field)
{
    global::System.Type clazz = field.FieldType;
    string fieldName = field.Name;
    if (!global::DripSharp.Runtime.JavaCompat.EqualsIgnoreCase(fieldName, "$jacocoData"))
    {
        bool isExpressionList = false;
        foreach (global::System.Type boundClass in EXPRESSION_CLASSES)
        {
            if (typeof(global::System.Collections.ICollection).IsAssignableFrom(clazz) && !global::DripSharp.SqlTrellis.Tests.Support.IsExpressionListType(clazz))
                isExpressionList |= this.testGenericType(field, boundClass);
        }
        if (isExpressionList)
            throwException(field, clazz, global::DripSharp.Runtime.JavaCompat.Concat(fieldName, " is an Expression List"));
    }
}

private static void throwException(global::System.Reflection.FieldInfo field, global::System.Type clazz, string message) {
string fieldName = field.Name;
string pureFieldName = ((fieldName.LastIndexOf("$", global::System.StringComparison.Ordinal) > 0) ? fieldName.Substring(fieldName.LastIndexOf("$", global::System.StringComparison.Ordinal)) : fieldName);
global::System.Type declaringClazz = field.DeclaringType;
while ((declaringClazz.DeclaringType != default!)) {
declaringClazz = declaringClazz.DeclaringType;
}
string pureDeclaringClassName = (declaringClazz.FullName ?? declaringClazz.Name);
global::System.IO.FileInfo file = global::DripSharp.SqlTrellis.Tests.Support.TestFile(global::DripSharp.Runtime.JavaCompat.Concat("src/main/java/", (pureDeclaringClassName.Replace(".", "/", global::System.StringComparison.Ordinal)) + ".java"));
int position = 1;
global::System.Text.RegularExpressions.Regex pattern = global::DripSharp.Runtime.JavaCompat.CompileRegex(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("\\s", field.FieldType.Name), "(<\\w*>)?(\\s*\\w*,?)*\\s*\\W"), 8);
try {
using (global::System.IO.TextReader reader = global::DripSharp.Runtime.JavaCompat.OpenFileReader(file)) {
global::System.Collections.Generic.IList<string> lines = global::DripSharp.SqlTrellis.Tests.Support.ReadLines(reader);
global::System.Text.StringBuilder builder = new global::System.Text.StringBuilder();
foreach (string s in lines) {
builder.Append(s).Append("\n");
}
global::DripSharp.Runtime.JavaRegexMatcher matcher = global::DripSharp.Runtime.JavaCompat.RegexMatcher(pattern, builder.ToString());
while (matcher.Find()) {
string group0 = matcher.Group(0);
if ((global::DripSharp.Runtime.JavaCompat.StringContains(group0, pureFieldName) && (global::DripSharp.Runtime.JavaCompat.StringEndsWith(group0, "=") || global::DripSharp.Runtime.JavaCompat.StringEndsWith(group0, ";")))) {
int pos = matcher.Start(0);
int readCharacters = 0;
foreach (string line in lines) {
readCharacters += (line.Length + 1);
if ((readCharacters >= pos)) {
break;
}
position++;
}
break;
}
}
}
} catch (global::System.Exception ex) when (ex is not global::System.TypeInitializationException) {
(global::DripSharp.SqlTrellis.Util.APISanitationTest.LOGGER).Warning(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("Could not find the field ", fieldName), " for "), (clazz.FullName ?? clazz.Name)));
}
global::DripSharp.SqlTrellis.Tests.JavaStackTraceElement stackTraceElement = new global::DripSharp.SqlTrellis.Tests.JavaStackTraceElement((field.DeclaringType.FullName ?? field.DeclaringType.Name), fieldName, (global::DripSharp.Runtime.JavaCompat.NormalizeUri(global::DripSharp.Runtime.JavaCompat.FileToUri(file))).AbsoluteUri, position);
throw new global::DripSharp.SqlTrellis.Util.APISanitationTest.MethodNamingException(message, stackTraceElement);
}

public class MethodNamingException : global::System.Exception {
public MethodNamingException(string message, global::DripSharp.SqlTrellis.Tests.JavaStackTraceElement stackTrace) : base(message) {
global::DripSharp.SqlTrellis.Tests.Support.SetStackTrace(this, new global::DripSharp.SqlTrellis.Tests.JavaStackTraceElement[] { stackTrace });
}

private static readonly bool __UpstreamBeforeAll = __RunUpstreamBeforeAll();

private static bool __RunUpstreamBeforeAll()
{
    findRelevantClasses();
    return true;
}
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_12bf1842f9abda6a()
{
    foreach (var value in fields())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::System.Reflection.FieldInfo>(row[0]) };
    }
}

public static global::System.Collections.Generic.IEnumerable<object[]> __Data_eef4a8ca0f162582()
{
    foreach (var value in fields())
    {
        object[] row = ((object?)value is object[] values)
            ? values : new object[] { value! };
        yield return new object[] { global::DripSharp.SqlTrellis.Tests.Support.TheoryArgument<global::System.Reflection.FieldInfo>(row[0]) };
    }
}

[Xunit.Theory]
[Xunit.MemberData("__Data_12bf1842f9abda6a")]
public void __Upstream_f5014b74a6b805f4(global::System.Reflection.FieldInfo field)
{
        try
        {
            this.testExpressionList(field);
        }
        finally
        {
        }
}

[Xunit.Theory(Skip = "Upstream @Disabled/@Ignore has no reason.")]
[Xunit.MemberData("__Data_eef4a8ca0f162582")]
public void __Upstream_dededc6aeeb2ab4e(global::System.Reflection.FieldInfo field)
{
        try
        {
            this.testFieldAccess(field);
        }
        finally
        {
        }
}

private static readonly bool __UpstreamBeforeAll = __RunUpstreamBeforeAll();

private static bool __RunUpstreamBeforeAll()
{
    findRelevantClasses();
    return true;
}
}
