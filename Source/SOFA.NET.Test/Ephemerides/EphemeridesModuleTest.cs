namespace SOFA.NET.Test;

[TestFixture]
internal class EphemeridesModuleTest
{

    [Test]
    public void ApproximateHeliocentricPositionAndVelocity_Test()
    {
        var julianDate = new JulianDate(2400000.5 + 43999.9);
        var planet = Planet.Mercury;

        var result = EphemeridesModule.ApproximateHeliocentricPositionAndVelocity(julianDate, planet);

        Assert.Multiple(() =>
        {
            double delta = 1e-11;
            Assert.That(result[0, 0], Is.EqualTo(0.2945293959257430832).Within(delta));
            Assert.That(result[0, 1], Is.EqualTo(-0.2452204176601049596).Within(delta));
            Assert.That(result[0, 2], Is.EqualTo(-0.1615427700571978153).Within(delta));

            Assert.That(result[1, 0], Is.EqualTo(0.1413867871404614441e-1).Within(delta));
            Assert.That(result[1, 1], Is.EqualTo(0.1946548301104706582e-1).Within(delta));
            Assert.That(result[1, 2], Is.EqualTo(0.8929809783898904786e-2).Within(delta));
        });
    }

}
