namespace SOFA.NET.Tests;

[TestFixture]
internal class AstrometryTests
{

    [Test]
    public void ApplyAberration_Test()
    {
        var pnat = new Vector3<double>(
            -0.76321968546737951,
            -0.60869453983060384,
            -0.21676408580639883);
        var v = new Vector3<double>(
            2.1044018893653786e-5,
            -8.9108923304429319e-5,
            -3.8633714797716569e-5);
        var s = 0.99980921395708788;
        var bm1 = 0.99999999506209258;

        var result = Astrometry.ApplyAberration(pnat, v, s, bm1);

        Assert.Multiple(() =>
        {
            Assert.That(result[0], Is.EqualTo(-0.7631631094219556269).Within(1e-12));
            Assert.That(result[1], Is.EqualTo(-0.6087553082505590832).Within(1e-12));
            Assert.That(result[2], Is.EqualTo(-0.2167926269368471279).Within(1e-12));
        });
    }

}
