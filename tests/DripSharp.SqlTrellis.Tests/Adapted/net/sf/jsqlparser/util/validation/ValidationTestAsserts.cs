// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Util.Validation;

public class ValidationTestAsserts {
public static void assertNotSupported(global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.ValidationException> errors, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] feature) {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.toSet((f) => global::DripSharp.Runtime.JavaCompat.Concat(f, " not supported."), feature), global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.toErrorsSet(errors), null);
}

public static void assertNotAllowed(global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.ValidationException> errors, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] feature) {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.toSet((f) => global::DripSharp.Runtime.JavaCompat.Concat(f, " not allowed."), feature), global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.toErrorsSet(errors), null);
}

public static void assertMetadata(global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.ValidationException> errors, bool checkForExists, params string[] names) {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.SetOfValues<string>(global::DripSharp.Runtime.JavaCompat.Map(global::DripSharp.Runtime.JavaCompat.Stream<string>(global::DripSharp.Runtime.JavaCompat.StreamOf<string>(names)), (f) => global::DripSharp.Runtime.JavaCompat.JavaStringFormat("%s does %sexist.", f, (checkForExists ? (object)("not ") : (object)(""))))), global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.toErrorsSet(errors), null);
}

public static void assertErrorsSize(global::System.Collections.Generic.ICollection<object> errors, int size) {
global::DripSharp.Testing.JavaAssertions.NotNull(errors, null);
global::DripSharp.Testing.JavaAssertions.Equal(size, global::DripSharp.Runtime.JavaCompat.CollectionCount(errors), global::DripSharp.Runtime.JavaCompat.JavaStringFormat("Expected %d errors, but got: %s", size, global::DripSharp.Runtime.JavaCompat.StringValueOf(errors)));
}

public static void assertErrorsSize(global::System.Collections.Generic.IDictionary<object, object> errors, int size) {
global::DripSharp.Testing.JavaAssertions.NotNull(errors, null);
global::DripSharp.Testing.JavaAssertions.Equal(size, global::DripSharp.Runtime.JavaCompat.MapCount(errors), null);
}

public static void validateNoErrors(string sql, int statementCount, params global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability[] versions) {
global::DripSharp.SqlTrellis.Util.Validation.Validation validation = new global::DripSharp.SqlTrellis.Util.Validation.Validation(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability>(versions)), sql);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = validation.validate();
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), 0);
global::DripSharp.Testing.JavaAssertions.Equal(statementCount, global::DripSharp.Runtime.JavaCompat.CollectionCount(validation.getParsedStatements().getStatements()), null);
}

public static global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> validate(string sql, int statementCount, int errorCount, global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability> validationCapabilities) {
global::DripSharp.SqlTrellis.Util.Validation.Validation validation = new global::DripSharp.SqlTrellis.Util.Validation.Validation(global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(validationCapabilities), sql);
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = validation.validate();
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertErrorsSize(global::DripSharp.Runtime.JavaCompat.CastObjects(errors), errorCount);
global::DripSharp.Testing.JavaAssertions.Equal(statementCount, global::DripSharp.Runtime.JavaCompat.CollectionCount(validation.getParsedStatements().getStatements()), null);
return errors;
}

public static global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> validate(string sql, int statementCount, int errorCount, params global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability[] validationCapabilities) {
return global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validate(sql, statementCount, errorCount, global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(global::DripSharp.Runtime.JavaCompat.AsList<global::DripSharp.SqlTrellis.Util.Validation.ValidationCapability>(validationCapabilities)));
}

public static void validateMetadata(string sql, int statementCount, int errorCount, global::DripSharp.SqlTrellis.Util.Validation.Metadata.DatabaseMetaDataValidation allowed, bool exists, params string[] names) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateMetadata(sql, statementCount, errorCount, global::DripSharp.Runtime.JavaCompat.SetOf<global::DripSharp.SqlTrellis.Util.Validation.Metadata.DatabaseMetaDataValidation>(allowed), exists, names);
}

public static void validateMetadata(string sql, int statementCount, int errorCount, global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.Metadata.DatabaseMetaDataValidation> allowed, bool exists, params string[] names) {
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validate(sql, statementCount, errorCount, global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(allowed));
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertMetadata(global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getErrors(), exists, names);
}

public static void validateNotAllowed(string sql, int statementCount, int errorCount, global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed allowed, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] features) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotAllowed(sql, statementCount, errorCount, global::DripSharp.Runtime.JavaCompat.SetOf<global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed>(allowed), features);
}

public static void validateNotAllowed(string sql, int statementCount, int errorCount, global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed> allowed, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] features) {
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validate(sql, statementCount, errorCount, global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(allowed));
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertNotAllowed(global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getErrors(), features);
}

public static void validateNotSupported(string sql, int statementCount, int errorCount, global::DripSharp.SqlTrellis.Util.Validation.Feature.Version supported, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] features) {
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validateNotSupported(sql, statementCount, errorCount, global::DripSharp.Runtime.JavaCompat.SetOf<global::DripSharp.SqlTrellis.Util.Validation.Feature.Version>(supported), features);
}

public static void validateNotSupported(string sql, int statementCount, int errorCount, global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.Feature.Version> supported, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] features) {
global::System.Collections.Generic.IList<global::DripSharp.SqlTrellis.Util.Validation.ValidationError> errors = global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.validate(sql, statementCount, errorCount, global::DripSharp.SqlTrellis.Tests.Support.ValidationCapabilities(supported));
global::DripSharp.SqlTrellis.Util.Validation.ValidationTestAsserts.assertNotSupported(global::DripSharp.Runtime.JavaCompat.ListGet(errors, 0).getErrors(), features);
}

private static global::System.Collections.Generic.ISet<string> toErrorsSet(global::System.Collections.Generic.ICollection<global::DripSharp.SqlTrellis.Util.Validation.ValidationException> errors) {
return global::DripSharp.Runtime.JavaCompat.SetOfValues<string>(global::DripSharp.Runtime.JavaCompat.Map(global::DripSharp.Runtime.JavaCompat.Stream(errors), (value0) => value0.Message));
}

private static global::System.Collections.Generic.ISet<string> toSet(global::System.Func<global::DripSharp.SqlTrellis.Parser.Feature.Feature, string> message, params global::DripSharp.SqlTrellis.Parser.Feature.Feature[] feature) {
return global::DripSharp.Runtime.JavaCompat.SetOfValues<string>(global::DripSharp.Runtime.JavaCompat.Map(global::DripSharp.Runtime.JavaCompat.StreamOf<global::DripSharp.SqlTrellis.Parser.Feature.Feature>(feature), message));
}

public ValidationTestAsserts() {}
}
