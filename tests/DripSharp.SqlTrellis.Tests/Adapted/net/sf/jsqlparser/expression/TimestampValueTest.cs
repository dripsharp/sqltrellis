// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Expression;

public class TimestampValueTest {
public virtual void testTimestampValue_issue525() {
global::DripSharp.Runtime.JavaSimpleDateFormat dateFormat = new global::DripSharp.Runtime.JavaSimpleDateFormat("yyyy-MM-dd HH:mm:ss", global::System.Globalization.CultureInfo.CurrentCulture);
string currentDate = dateFormat.Format(global::System.DateTimeOffset.Now);
global::DripSharp.SqlTrellis.Expression.TimestampValue tv = new global::DripSharp.SqlTrellis.Expression.TimestampValue(currentDate);
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(tv.ToString());
global::DripSharp.Testing.JavaAssertions.Equal(currentDate, tv.getRawValue(), null);
}

public virtual void testTimestampValueWithQuotation_issue525() {
global::DripSharp.Runtime.JavaSimpleDateFormat dateFormat = new global::DripSharp.Runtime.JavaSimpleDateFormat("yyyy-MM-dd HH:mm:ss", global::System.Globalization.CultureInfo.CurrentCulture);
string currentDate = dateFormat.Format(global::System.DateTimeOffset.Now);
global::DripSharp.SqlTrellis.Expression.TimestampValue tv = new global::DripSharp.SqlTrellis.Expression.TimestampValue(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("'", currentDate), "'"));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(tv.ToString());
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.Concat(global::DripSharp.Runtime.JavaCompat.Concat("'", currentDate), "'"), tv.getRawValue(), null);
}

[Xunit.Fact]
public void __Upstream_53044ca9f77a5e51()
{
        try
        {
            this.testTimestampValueWithQuotation_issue525();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_f0f1dc35ac6aa229()
{
        try
        {
            this.testTimestampValue_issue525();
        }
        finally
        {
        }
}
}
