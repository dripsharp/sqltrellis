// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation;

public class ValidationTest : global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts {
public static void main(string[] args) {
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat("mysql", ((global::DripSharp.SqlTrellis.Parser.Feature.FeatureSet)(global::DripSharp.SqlTrellis.Util.Validation.Feature.MySqlVersion.V8_0)).getNotContained(global::DripSharp.SqlTrellis.Util.Validation.Feature.MariaDbVersion.V10_5_4.getFeatures())));
global::DripSharp.Runtime.JavaCompat.@out.WriteLine(global::DripSharp.Runtime.JavaCompat.Concat("mariadb", ((global::DripSharp.SqlTrellis.Parser.Feature.FeatureSet)(global::DripSharp.SqlTrellis.Util.Validation.Feature.MariaDbVersion.V10_5_4)).getNotContained(global::DripSharp.SqlTrellis.Util.Validation.Feature.MySqlVersion.V8_0.getFeatures())));
}

public virtual void testValidationWithStatementValidator() {
string sql = "SELECT * FROM tab1, tab2 WHERE tab1.id (+) = tab2.ref";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Util.Validation.Validator.StatementValidator validator = new global::DripSharp.SqlTrellis.Util.Validation.Validator.StatementValidator();
validator.setContext(new global::DripSharp.SqlTrellis.Util.Validation.ValidationContext().setCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL)));
((global::DripSharp.SqlTrellis.Statement.Statement)(stmt)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(validator));
global::System.Collections.Generic.IDictionary<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability, global::System.Collections.Generic.ISet<global::DripSharp.SqlTrellis.Util.Validation.ValidationException>> unsupportedErrors = global::DripSharp.SqlTrellis.Tests.Support.FilterValidationErrors(((global::DripSharp.SqlTrellis.Util.Validation.IValidator)(validator)), global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastDictionary<object, object>(unsupportedErrors), 1);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertNotSupported(global::DripSharp.Runtime.JavaCompat.MapGet(unsupportedErrors, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER), global::DripSharp.SqlTrellis.Parser.Feature.Feature.oracleOldJoinSyntax);
unsupportedErrors = global::DripSharp.SqlTrellis.Tests.Support.FilterValidationErrors(((global::DripSharp.SqlTrellis.Util.Validation.IValidator)(validator)), global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastDictionary<object, object>(unsupportedErrors), 1);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertNotSupported(global::DripSharp.Runtime.JavaCompat.MapGet(unsupportedErrors, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL), global::DripSharp.SqlTrellis.Parser.Feature.Feature.oracleOldJoinSyntax);
}

public virtual void testWithValidation() {
string stmt = "SELECT * FROM tab1, tab2 WHERE tab1.id (+) = tab2.ref";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.ListOf<global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER)), stmt);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 1);
global::DripSharp.Testing.JavaAssertions.Equal(stmt, global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getStatements(), null);
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getCapability(), null);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertNotSupported(global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getErrors(), global::DripSharp.SqlTrellis.Parser.Feature.Feature.oracleOldJoinSyntax);
}

public virtual void testWithValidationMultipleStatements() {
string sql = "UPDATE tab1 SET val = ? WHERE id = ?; DELETE FROM tab2 t2 WHERE t2.id = ?;";
global::DripSharp.SqlTrellis.Util.Validation.Validation validation = new global::DripSharp.SqlTrellis.Util.Validation.Validation(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL)), sql);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = validation.validate();
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
global::DripSharp.Testing.JavaAssertions.Equal(2, global::DripSharp.Runtime.JavaCompat.CollectionCount(validation.getParsedStatements().getStatements()), null);
}

public virtual void testWithValidationOnlyParse() {
string stmt = "SELECT * FROM tab1, tab2 WHERE tab1.id (+) = tab2.ref";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::System.Array.Empty<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability>()), stmt);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
}

public virtual void testWithValidationOnlyParse2() {
string sql = "SELECT * FROM tab1, tab2 WHERE value XOR other_value";
global::DripSharp.SqlTrellis.Statement.Statement stmt = global::DripSharp.SqlTrellis.Parser.CCJSqlParserUtil.parse(sql);
global::DripSharp.SqlTrellis.Util.Validation.Validator.StatementValidator validator = new global::DripSharp.SqlTrellis.Util.Validation.Validator.StatementValidator();
validator.setContext(new global::DripSharp.SqlTrellis.Util.Validation.ValidationContext().setCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER, global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.MYSQL)));
((global::DripSharp.SqlTrellis.Statement.Statement)(stmt)).accept<object>((global::DripSharp.SqlTrellis.Statement.StatementVisitor<object>)(validator));
global::System.Collections.Generic.IDictionary<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability, global::System.Collections.Generic.ISet<global::DripSharp.SqlTrellis.Util.Validation.ValidationException>> unsupportedErrors = global::DripSharp.SqlTrellis.Tests.Support.FilterValidationErrors(((global::DripSharp.SqlTrellis.Util.Validation.IValidator)(validator)), global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.SQLSERVER);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastDictionary<object, object>(unsupportedErrors), 0);
}

public virtual void testWithValidationOnlyParseInvalid() {
string stmt = "SELECT * FROM tab1 JOIN tab2 WHERE tab1.id (++) = tab2.ref";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::System.Array.Empty<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability>()), stmt);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
global::DripSharp.SqlTrellis.Util.Validation.ValidationException actual = global::DripSharp.Runtime.JavaCompat.FindFirstOptional(global::DripSharp.Runtime.JavaCompat.Stream(global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getErrors())).Get();
global::DripSharp.Testing.JavaHamcrest.AssertThat(actual, global::DripSharp.Testing.JavaHamcrest.InstanceOf(typeof(global::DripSharp.SqlTrellis.Util.Validation.ParseException)));
global::DripSharp.Testing.JavaHamcrest.AssertThat(global::DripSharp.Runtime.JavaCompat.ExceptionMessage(actual), global::DripSharp.Testing.JavaHamcrest.StartsWith("Cannot parse statement"));
}

public virtual void testWithValidationUpdateButAcceptOnlySelects() {
string stmt = "UPDATE tab1 t1 SET t1.ref = ? WHERE t1.id = ?";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.FeatureSetValidation>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC))), stmt);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 1);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertNotAllowed(global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getErrors(), global::DripSharp.SqlTrellis.Parser.Feature.Feature.update);
}

public virtual void testWithValidatonAcceptOnlySelects() {
string stmt = "SELECT * FROM tab1 JOIN tab2 WHERE tab1.id = tab2.ref";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.FeatureSetValidation>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.POSTGRESQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT)), stmt);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
}

public virtual void testFeatureSetName() {
global::DripSharp.Testing.JavaAssertions.Equal("SELECT + jdbc", global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UPDATE + SELECT", global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.UPDATE.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("DELETE + SELECT", global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DELETE.getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("DELETE + SELECT + UPDATE + jdbc", global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.DELETE.copy().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.UPDATE).add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.JDBC).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UPDATE + SELECT", new global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed().add(global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.UPDATE).getName(), null);
global::DripSharp.Testing.JavaAssertions.Equal("UPDATE + SELECT + feature set", global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.UPDATE.copy().add(new global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed(global::DripSharp.SqlTrellis.Parser.Feature.Feature.commit)).getName(), null);
}

public virtual void testRowConstructorValidation() {
string stmt = "SELECT CAST(ROW(dataid, value, calcMark) AS ROW(datapointid CHAR, value CHAR, calcMark CHAR))";
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.Validation.validate(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.Feature.FeatureSetValidation>(global::DripSharp.SqlTrellis.Util.Validation.Feature.DatabaseType.ANSI_SQL, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed.SELECT)), stmt);
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
}

[Xunit.Fact]
public void __Upstream_1d6f86aff9aa4beb()
{
        try
        {
            this.testFeatureSetName();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_9bb3fa3652d8127a()
{
        try
        {
            this.testRowConstructorValidation();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_187cd93c55952ca7()
{
        try
        {
            this.testValidationWithStatementValidator();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_13439a1de647db74()
{
        try
        {
            this.testWithValidation();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_5ea21249057f3dd7()
{
        try
        {
            this.testWithValidationMultipleStatements();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_7f4df8cea6607da2()
{
        try
        {
            this.testWithValidationOnlyParse();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_00e6252fa9131d38()
{
        try
        {
            this.testWithValidationOnlyParse2();
        }
        finally
        {
        }
}

[Xunit.Fact(Skip = "Upstream @Disabled/@Ignore has no reason.")]
public void __Upstream_e299b2921e5f15ac()
{
        try
        {
            this.testWithValidationOnlyParseInvalid();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_842a68893d42d644()
{
        try
        {
            this.testWithValidationUpdateButAcceptOnlySelects();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_4779258c97a26c47()
{
        try
        {
            this.testWithValidatonAcceptOnlySelects();
        }
        finally
        {
        }
}
}
