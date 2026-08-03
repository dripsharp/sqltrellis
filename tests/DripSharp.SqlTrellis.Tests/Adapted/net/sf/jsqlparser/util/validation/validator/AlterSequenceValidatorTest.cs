// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class AlterSequenceValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
private static readonly global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType[] DATABASES_SUPPORTING_SEQUENCES = new global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType[] { global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2 };

public virtual void testValidatorAlterSequence() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("ALTER SEQUENCE my_seq", "ALTER SEQUENCE my_seq INCREMENT BY 1", "ALTER SEQUENCE my_seq START WITH 10", "ALTER SEQUENCE my_seq MAXVALUE 5", "ALTER SEQUENCE my_seq NOMAXVALUE", "ALTER SEQUENCE my_seq MINVALUE 5", "ALTER SEQUENCE my_seq NOMINVALUE", "ALTER SEQUENCE my_seq CYCLE", "ALTER SEQUENCE my_sec INCREMENT BY 2 START WITH 10", "ALTER SEQUENCE my_sec START WITH 2 INCREMENT BY 5 NOCACHE", "ALTER SEQUENCE my_sec START WITH 2 INCREMENT BY 5 CACHE 200 CYCLE")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.AlterSequenceValidatorTest.DATABASES_SUPPORTING_SEQUENCES);
}
}

[Xunit.Fact]
public void __Upstream_367be55787a89815()
{
        try
        {
            this.testValidatorAlterSequence();
        }
        finally
        {
        }
}
}
