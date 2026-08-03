// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class CreateIndexValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateCreateIndex() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE INDEX idx_american_football_action_plays_1 ON american_football_action_plays USING btree (play_type)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testValidateCreateIndexNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE INDEX idx_american_football_action_plays_1 ON american_football_action_plays USING btree (play_type)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.createIndex);
}
}

[Xunit.Fact]
public void __Upstream_cd1b571d144aeba2()
{
        try
        {
            this.testValidateCreateIndex();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_43267b94d3f8afea()
{
        try
        {
            this.testValidateCreateIndexNotAllowed();
        }
        finally
        {
        }
}
}
