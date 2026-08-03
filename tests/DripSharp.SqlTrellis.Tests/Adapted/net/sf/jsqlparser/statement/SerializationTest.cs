// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Statement;

public class SerializationTest {
internal virtual void serializeWithItem() {
string sqlStr = global::DripSharp.Runtime.JavaCompat.Concat("with sample_data(day, value) as (values ((0, 13), (1, 12), (2, 15), (3, 4), (4, 8), (5, 16))), test2 as (values (1,2,3)) \n", "select day, value from sample_data as a");
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect originalSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sqlStr)!);
global::DripSharp.Runtime.JavaByteArrayOutputStream byteArrayOutputStream = new global::DripSharp.Runtime.JavaByteArrayOutputStream();
using (global::DripSharp.SqlTrellis.Tests.JavaObjectOutputStream @out = new global::DripSharp.SqlTrellis.Tests.JavaObjectOutputStream(byteArrayOutputStream)) {
@out.WriteObject(originalSelect);
}
global::DripSharp.SqlTrellis.Statement.Select.PlainSelect deserializedSelect;
using (global::DripSharp.SqlTrellis.Tests.JavaObjectInputStream @in = new global::DripSharp.SqlTrellis.Tests.JavaObjectInputStream(global::DripSharp.Runtime.JavaCompat.NewMemoryStream(global::DripSharp.Runtime.JavaCompat.ToSignedBytes(byteArrayOutputStream)))) {
deserializedSelect = (global::DripSharp.SqlTrellis.Statement.Select.PlainSelect)(@in.ReadObject()!);
}
global::DripSharp.Testing.JavaAssertions.Equal(originalSelect.ToString(), deserializedSelect.ToString(), "The deserialized object should be equal to the original");
}

[Xunit.Fact]
public void __Upstream_dedc03cb05d55858()
{
        try
        {
            this.serializeWithItem();
        }
        finally
        {
        }
}
}
