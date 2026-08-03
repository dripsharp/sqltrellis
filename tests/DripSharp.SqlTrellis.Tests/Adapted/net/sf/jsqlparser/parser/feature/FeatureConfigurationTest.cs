// SPDX-FileCopyrightText: 2026 Isak Sky
// SPDX-License-Identifier: Apache-2.0

#nullable disable
namespace DripSharp.SqlTrellis.Parser.Feature;

public class FeatureConfigurationTest {
public virtual void getAsLong() {
global::DripSharp.SqlTrellis.Parser.Feature.FeatureConfiguration featureConfiguration = new global::DripSharp.SqlTrellis.Parser.Feature.FeatureConfiguration();
featureConfiguration.setValue(global::DripSharp.SqlTrellis.Parser.Feature.Feature.timeOut, 123L);
long? timeOut = featureConfiguration.getAsLong(global::DripSharp.SqlTrellis.Parser.Feature.Feature.timeOut);
global::DripSharp.Testing.JavaAssertJ.That(timeOut).IsEqualTo(123L);
}

[Xunit.Fact]
public void __Upstream_bef4119337c3ca91()
{
        try
        {
            this.getAsLong();
        }
        finally
        {
        }
}
}
