// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class RefreshMaterializedViewStatementValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidationRefresh() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("REFRESH MATERIALIZED VIEW my_view")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

public virtual void testValidationRefreshWithData() {
foreach (string sql__34_21 in global::DripSharp.Runtime.JavaCompat.AsList<string>("REFRESH MATERIALIZED VIEW CONCURRENTLY my_view WITH DATA")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql__34_21, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
foreach (string sql__39_21 in global::DripSharp.Runtime.JavaCompat.AsList<string>("REFRESH MATERIALIZED VIEW my_view WITH DATA")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql__39_21, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

public virtual void testValidationRefreshWithConcurrently() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("REFRESH MATERIALIZED VIEW CONCURRENTLY my_view")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

public virtual void testValidationRefreshNotAllowed() {
foreach (string sql__54_21 in global::DripSharp.Runtime.JavaCompat.AsList<string>("REFRESH MATERIALIZED VIEW my_view")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql__54_21, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT, global::DripSharp.SqlTrellis.Parser.Feature.Feature.refreshMaterializedView);
}
foreach (string sql__59_21 in global::DripSharp.Runtime.JavaCompat.AsList<string>("REFRESH MATERIALIZED VIEW CONCURRENTLY my_view WITH DATA")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql__59_21, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT, global::DripSharp.SqlTrellis.Parser.Feature.Feature.refreshMaterializedView, global::DripSharp.SqlTrellis.Parser.Feature.Feature.refreshMaterializedWithDataView, global::DripSharp.SqlTrellis.Parser.Feature.Feature.refreshMaterializedWithNoDataView);
}
}

[Xunit.Fact]
public void __Upstream_887ca561cd066f7d()
{
        try
        {
            this.testValidationRefresh();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_e3868dbb3aa54bf2()
{
        try
        {
            this.testValidationRefreshNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7a8a9a587c6f912b()
{
        try
        {
            this.testValidationRefreshWithConcurrently();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_6ce9e5155116d953()
{
        try
        {
            this.testValidationRefreshWithData();
        }
        finally
        {
        }
}
}
