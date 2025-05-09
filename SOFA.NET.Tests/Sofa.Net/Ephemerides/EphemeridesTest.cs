﻿namespace SOFA.NET.Tests;

[TestFixture]
internal class EphemeridesTest
{

    [Test]
    public void EarthPositionAndVelocityBCRS_Test()
    {
        var jd = new JulianDate(2400000.5 + 53411.52501161);
        var result = Ephemerides.EarthPositionAndVelocityBCRS(jd);
        Assert.Multiple(() =>
        {
            var hes = result.HeliocentricEarthState;
            Assert.That(hes[0, 0], Is.EqualTo(-0.7757238809297706813).Within(1e-14));
            Assert.That(hes[0, 1], Is.EqualTo(0.5598052241363340596).Within(1e-14));
            Assert.That(hes[0, 2], Is.EqualTo(0.2426998466481686993).Within(1e-14));
            Assert.That(hes[1, 0], Is.EqualTo(-0.1091891824147313846e-1).Within(1e-15));
            Assert.That(hes[1, 1], Is.EqualTo(-0.1247187268440845008e-1).Within(1e-15));
            Assert.That(hes[1, 2], Is.EqualTo(-0.5407569418065039061e-2).Within(1e-15));

            var bes = result.BarycentricEarthState;
            Assert.That(bes[0, 0], Is.EqualTo(-0.7714104440491111971).Within(1e-14));
            Assert.That(bes[0, 1], Is.EqualTo(0.5598412061824171323).Within(1e-14));
            Assert.That(bes[0, 2], Is.EqualTo(0.2425996277722452400).Within(1e-14));
            Assert.That(bes[1, 0], Is.EqualTo(-0.1091874268116823295e-1).Within(1e-15));
            Assert.That(bes[1, 1], Is.EqualTo(-0.1246525461732861538e-1).Within(1e-15));
            Assert.That(bes[1, 2], Is.EqualTo(-0.5404773180966231279e-2).Within(1e-15));
        });
    }

    [Test]
    public void ApproximateGeocentricMoonState_Test()
    {
        var jd = new JulianDate(2400000.5 + 43999.9);
        var result = Ephemerides.ApproximateGeocentricMoonState(jd);
        Assert.Multiple(() =>
        {
            Assert.That(result[0, 0], Is.EqualTo(-0.2601295959971044180e-2).Within(1e-11));
            Assert.That(result[0, 1], Is.EqualTo(0.6139750944302742189e-3).Within(1e-11));
            Assert.That(result[0, 2], Is.EqualTo(0.2640794528229828909e-3).Within(1e-11));
            Assert.That(result[1, 0], Is.EqualTo(-0.1244321506649895021e-3).Within(1e-11));
            Assert.That(result[1, 1], Is.EqualTo(-0.5219076942678119398e-3).Within(1e-11));
            Assert.That(result[1, 2], Is.EqualTo(-0.1716132214378462047e-3).Within(1e-11));
        });
    }

    [TestCase(2400000.5 - 320000, Planet.Earth, 
        0.9308038666832975759,    0.3258319040261346000,    0.1422794544481140560,
       -0.6429458958255170006e-2, 0.1468570657704237764e-1, 0.6406996426270981189e-2)]
    [TestCase(2400000.5 + 43999.9, Planet.Mercury,
        0.2945293959257430832,   -0.2452204176601049596,   -0.1615427700571978153,
        0.1413867871404614441e-1, 0.1946548301104706582e-1, 0.8929809783898904786e-2)]
    public void ApproximatePlanetState_Test(
        double date,
        Planet planet,
        double x, double y, double z,
        double xdot, double ydot, double zdot)
    {
        var jd = new JulianDate(date);
        var result = Ephemerides.ApproximatePlanetState(jd, planet).Data;
        Assert.Multiple(() =>
        {
            Assert.That(result[0, 0], Is.EqualTo(x).Within(1e-11));
            Assert.That(result[0, 1], Is.EqualTo(y).Within(1e-11));
            Assert.That(result[0, 2], Is.EqualTo(z).Within(1e-11));
            Assert.That(result[1, 0], Is.EqualTo(xdot).Within(1e-11));
            Assert.That(result[1, 1], Is.EqualTo(ydot).Within(1e-11));
            Assert.That(result[1, 2], Is.EqualTo(zdot).Within(1e-11));
        });
    }
}
