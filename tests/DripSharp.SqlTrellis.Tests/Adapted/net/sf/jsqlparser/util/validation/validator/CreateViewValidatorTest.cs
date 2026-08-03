// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation.Validator;

public class CreateViewValidatorTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public virtual void testValidateCreateView() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE VIEW myview AS SELECT * FROM mytab", "CREATE VIEW myview AS (SELECT * FROM mytab)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testValidateCreateViewNotAllowed() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE VIEW myview AS SELECT * FROM mytab", "CREATE VIEW myview AS (SELECT * FROM mytab)")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, 1, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DML, global::DripSharp.SqlTrellis.Parser.Feature.Feature.createView);
}
}

public virtual void testValidateCreateViewMaterialized() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("CREATE MATERIALIZED VIEW myview AS SELECT * FROM mytab", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE);
}

public virtual void testValidateCreateOrReplaceView() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("CREATE OR REPLACE VIEW myview AS SELECT * FROM mytab", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidateCreateForceView() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("CREATE FORCE VIEW myview AS SELECT * FROM mytab", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ORACLE, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.H2);
}

public virtual void testValidateCreateTemporaryView() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE TEMPORARY VIEW myview AS SELECT * FROM mytab", "CREATE TEMP VIEW myview AS SELECT * FROM mytab")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
}
}

public virtual void testValidateCreateViewWith() {
foreach (string sql in global::DripSharp.Runtime.JavaCompat.AsList<string>("CREATE VIEW foo(\"BAR\") AS WITH temp AS (SELECT temp_bar FROM foobar) SELECT bar FROM temp")) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors(sql, 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.DATABASES);
}
}

public virtual void testValidateCreateViewWithComment() {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNoErrors("CREATE VIEW v14(c1 COMMENT 'comment1', c2 COMMENT 'comment2') COMMENT = 'view' AS SELECT c1, C2 FROM t1 WITH READ ONLY", 1, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MARIADB);
}

[Xunit.Fact]
public void __Upstream_a2ba02cec282b97a()
{
        try
        {
            this.testValidateCreateForceView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_8effc854c36a59e2()
{
        try
        {
            this.testValidateCreateOrReplaceView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_bdc8be854fa7fb05()
{
        try
        {
            this.testValidateCreateTemporaryView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_461acee13e251bb1()
{
        try
        {
            this.testValidateCreateView();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_69d65580c54659f9()
{
        try
        {
            this.testValidateCreateViewMaterialized();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_b4f24a5c3685e8bc()
{
        try
        {
            this.testValidateCreateViewNotAllowed();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9fcc4d183b7137b7()
{
        try
        {
            this.testValidateCreateViewWith();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_d42dd9e629dcef10()
{
        try
        {
            this.testValidateCreateViewWithComment();
        }
        finally
        {
        }
}
}
