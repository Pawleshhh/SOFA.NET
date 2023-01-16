using NUnit.Framework.Constraints;

namespace SOFA.NET.Test;

[TestFixture]
internal class CoordinatesModuleTest
{

    [Test]
    public void EclipticToEquatorialIAU06_Test()
    {
        var julianDate = new JulianDate(2456165.5 + 0.401182685);
        var eclipticCoords = new EclipticCoordinates(5.1, -0.9);

        var result = CoordinatesModule.EclipticToEquatorialIAU06(julianDate, eclipticCoords);

        Assert.Multiple(() =>
        {
            Assert.That(result.RightAscension, Is.EqualTo(5.533459733613627767).Within(1e-14));
            Assert.That(result.Declination, Is.EqualTo(-1.246542932554480576).Within(1e-14));
        });
    }

    [Test]
    public void EquatorialToEclipticIAU06_Test()
    {
        var julianDate = new JulianDate(1234.5 + 2440000.5);
        var equatorialCoords = new EquatorialCoordinates(0.987, 1.234);

        var result = CoordinatesModule.EquatorialToEclipticIAU06(julianDate, equatorialCoords);

        Assert.Multiple(() =>
        {
            Assert.That(result.Longitude, Is.EqualTo(1.342509918994654619).Within(1e-14));
            Assert.That(result.Latitude, Is.EqualTo(0.5926215259704608132).Within(1e-14));
        });
    }

    [Test]
    public void RotationMatrixOfEquatorialToEclipticIAU06_Test()
    {
        var julianDate = new JulianDate(2456165.5 + 0.401182685);

        var result = CoordinatesModule.RotationMatrixOfEquatorialToEclipticIAU06(julianDate);

        Assert.Multiple(() =>
        {
            Assert.That(result[0, 0], IsEqualTo(0.9999952427708701137));
            Assert.That(result[0, 1], IsEqualTo(-0.2829062057663042347e-2));
            Assert.That(result[0, 2], IsEqualTo(-0.1229163741100017629e-2));
            Assert.That(result[1, 0], IsEqualTo(0.3084546876908653562e-2));
            Assert.That(result[1, 1], IsEqualTo(0.9174891871550392514));
            Assert.That(result[1, 2], IsEqualTo(0.3977487611849338124));
            Assert.That(result[2, 0], IsEqualTo(0.2488512951527405928e-5));
            Assert.That(result[2, 1], IsEqualTo(-0.3977506604161195467));
            Assert.That(result[2, 2], IsEqualTo(0.9174935488232863071));
        });
    }

    [Test]
    public void SphericalToCartesian_Test()
    {
        var spherical = ICoordinateSystem2D<double>.Create(3.0123, -0.999);

        var result = CoordinatesModule.SphericalToCartesian(spherical);

        Assert.Multiple(() =>
        {
            double delta = 1e-12;
            Assert.That(result[0], Is.EqualTo(-0.5366267667260523906).Within(delta));
            Assert.That(result[1], Is.EqualTo(0.0697711109765145365).Within(delta));
            Assert.That(result[2], Is.EqualTo(-0.8409302618566214041).Within(delta));
        });
    }

    [Test]
    public void VectorToSphericalCoordinates_Test()
    {
        var vector = new double[] { 100.0, -50.0, 25.0 };

        var result = CoordinatesModule.VectorToSphericalCoordinates(vector);

        Assert.Multiple(() =>
        {
            double delta = 1e-14;
            Assert.That(result.X, Is.EqualTo(-0.4636476090008061162).Within(delta));
            Assert.That(result.Y, Is.EqualTo(0.2199879773954594463).Within(delta));
        });
    }

    [Test]
    public void EclipticToEquatorialLongTerm_Test()
    {
        var julianEpoch = 2500.0;
        var eclipticCoords = new EclipticCoordinates(1.5, 0.6);

        var result = CoordinatesModule.EclipticToEquatorialLongTerm(julianEpoch, eclipticCoords);

        Assert.Multiple(() =>
        {
            Assert.That(result.RightAscension, Is.EqualTo(1.275156021861921167).Within(1e-14));
            Assert.That(result.Declination, Is.EqualTo(0.9966573543519204791).Within(1e-14));
        });
    }

    [Test]
    public void RotationMatrixOfEquatorialToEclipticLongTerm_Test()
    {
        var julianEpoch = -3000.0;

        var result = CoordinatesModule.RotationMatrixOfEquatorialToEclipticLongTerm(julianEpoch);

        Assert.Multiple(() =>
        {
            Assert.That(result[0, 0], IsEqualTo(0.3564105644859788825));
            Assert.That(result[0, 1], IsEqualTo(0.8530575738617682284));
            Assert.That(result[0, 2], IsEqualTo(0.3811355207795060435));
            Assert.That(result[1, 0], IsEqualTo(-0.9343283469640709942));
            Assert.That(result[1, 1], IsEqualTo(0.3247830597681745976));
            Assert.That(result[1, 2], IsEqualTo(0.1467872751535940865));
            Assert.That(result[2, 0], IsEqualTo(0.1431636191201167793e-2));
            Assert.That(result[2, 1], IsEqualTo(-0.4084222566960599342));
            Assert.That(result[2, 2], IsEqualTo(0.9127919865189030899));
        });
    }

    private static EqualConstraint IsEqualTo(double x)
        => Is.EqualTo(x).Within(1e-14);

}
