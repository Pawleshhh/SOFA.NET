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

    [Test]
    public void PrepareAstrometryParametersGeocentric_Test()
    {
        var julianDate = new JulianDate(2456165.5, 0.401182685);
        var barycentricEarthState = Matrix<double>.FromFlatArray(
            2, 3,
            [0.901310875, -0.417402664, -0.180982288,
             0.00742727954, 0.0140507459, 0.00609045792]);
        var heliocentricEarthPosition = new Vector3<double>(
            0.903358544,
            -0.415395237,
            -0.180084014);

        var result = Astrometry.PrepareAstrometryParametersGeocentric(
            julianDate,
            barycentricEarthState,
            heliocentricEarthPosition);

        Assert.Multiple(() =>
        {
            Assert.That(result.Pmt, Is.EqualTo(12.65133794027378508).Within(1e-11));
            Assert.That(result.SSBToObserver[0], Is.EqualTo(0.901310875).Within(1e-12));
            Assert.That(result.SSBToObserver[1], Is.EqualTo(-0.417402664).Within(1e-12));
            Assert.That(result.SSBToObserver[2], Is.EqualTo(-0.180982288).Within(1e-12));
            Assert.That(result.SunToObserver[0], Is.EqualTo(0.8940025429324143045).Within(1e-12));
            Assert.That(result.SunToObserver[1], Is.EqualTo(-0.4110930268679817955).Within(1e-12));
            Assert.That(result.SunToObserver[2], Is.EqualTo(-0.1782189004872870264).Within(1e-12));
            Assert.That(result.SunObserverDistance, Is.EqualTo(1.010465295811013146).Within(1e-12));
            Assert.That(result.BarycentricObserverVelocity[0], Is.EqualTo(0.4289638913597693554e-4).Within(1e-16));
            Assert.That(result.BarycentricObserverVelocity[1], Is.EqualTo(0.8115034051581320575e-4).Within(1e-16));
            Assert.That(result.BarycentricObserverVelocity[2], Is.EqualTo(0.3517555136380563427e-4).Within(1e-16));
            Assert.That(result.Bm1, Is.EqualTo(0.9999999951686012981).Within(1e-12));

            var bpn = result.Bpn;

            Assert.That(bpn[0, 0], Is.EqualTo(1.0));
            Assert.That(bpn[0, 1], Is.EqualTo(0));
            Assert.That(bpn[0, 2], Is.EqualTo(0));
            Assert.That(bpn[1, 0], Is.EqualTo(0));
            Assert.That(bpn[1, 1], Is.EqualTo(1.0));
            Assert.That(bpn[1, 2], Is.EqualTo(0));
            Assert.That(bpn[2, 0], Is.EqualTo(0));
            Assert.That(bpn[2, 1], Is.EqualTo(0));
            Assert.That(bpn[2, 2], Is.EqualTo(1.0));
        });
    }

}
