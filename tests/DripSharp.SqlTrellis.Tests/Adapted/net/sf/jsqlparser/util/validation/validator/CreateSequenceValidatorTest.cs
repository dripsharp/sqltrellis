// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class CreateSequenceValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
private static readonly global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType[] DATABASES_SUPPORTING_SEQUENCES = new global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType[] { global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2 };

public virtual void testValidateCreateSequence() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE SEQUENCE my_sec INCREMENT BY 2 START WITH 10", "CREATE SEQUENCE my_sec START WITH 2 INCREMENT BY 5 NOCACHE", "CREATE SEQUENCE my_sec START WITH 2 INCREMENT BY 5 CACHE 200 CYCLE")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Validator.CreateSequenceValidatorTest.DATABASES_SUPPORTING_SEQUENCES);
}
}

public virtual void testValidateCreateSequenceNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE SEQUENCE my_sec INCREMENT BY 2 START WITH 10", "CREATE SEQUENCE my_sec START WITH 2 INCREMENT BY 5 NOCACHE", "CREATE SEQUENCE my_sec START WITH 2 INCREMENT BY 5 CACHE 200 CYCLE")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.createSequence);
}
}

[Xunit.Fact]
public void __Upstream_e5af179e88cde51e()
{
        try
        {
            this.testValidateCreateSequence();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7c35f6cec37447ba()
{
        try
        {
            this.testValidateCreateSequenceNotAllowed();
        }
        finally
        {
        }
}
}
