namespace SOFA.NET.Test;

[TestFixture]
internal class FundamentalArgsModuleTest
{

    [Test]
    public void MeanElongationOfMoonFromSunIERS03_Test()
    {
        double t = 0.8;

        var result = FundamentalArgsModule.MeanElongationOfMoonFromSunIERS03(t);

        Assert.That(result, Is.EqualTo(1.946709205396925672).Within(1e-12));
    }

}
