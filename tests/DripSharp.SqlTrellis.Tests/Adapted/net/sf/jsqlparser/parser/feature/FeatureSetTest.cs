// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser.Feature;

public class FeatureSetTest {
public virtual void testGetNotContained() {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.EnumSetOf<global::DripSharp.SqlTrellis.Parser.Feature.Feature>(global::DripSharp.SqlTrellis.Parser.Feature.Feature.select), ((global::DripSharp.SqlTrellis.Parser.Feature.FeatureSet)(new global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed(global::DripSharp.SqlTrellis.Parser.Feature.Feature.select, global::DripSharp.SqlTrellis.Parser.Feature.Feature.update))).getNotContained(new global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed(global::DripSharp.SqlTrellis.Parser.Feature.Feature.update, global::DripSharp.SqlTrellis.Parser.Feature.Feature.delete).getFeatures()), null);
}

public virtual void testRetainAll() {
global::DripSharp.Testing.JavaAssertions.Equal(global::DripSharp.Runtime.JavaCompat.EnumSetOf<global::DripSharp.SqlTrellis.Parser.Feature.Feature>(global::DripSharp.SqlTrellis.Parser.Feature.Feature.update), ((global::DripSharp.SqlTrellis.Parser.Feature.FeatureSet)(new global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed(global::DripSharp.SqlTrellis.Parser.Feature.Feature.select, global::DripSharp.SqlTrellis.Parser.Feature.Feature.update))).retainAll(new global::DripSharp.SqlTrellis.Util.Validation.Feature.FeaturesAllowed(global::DripSharp.SqlTrellis.Parser.Feature.Feature.update, global::DripSharp.SqlTrellis.Parser.Feature.Feature.delete).getFeatures()), null);
}

[Xunit.Fact]
public void __Upstream_ae631b1cfa09931e()
{
        try
        {
            this.testGetNotContained();
        }
        finally
        {
        }
}

[Xunit.Fact]
public void __Upstream_ea961c0bc9d3df83()
{
        try
        {
            this.testRetainAll();
        }
        finally
        {
        }
}
}
