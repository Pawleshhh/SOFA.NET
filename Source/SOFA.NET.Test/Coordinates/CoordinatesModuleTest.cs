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

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(-1.246542932554480576, 5.533459733613627767),
            result,
            1e-14);
    }

    [Test]
    public void EquatorialToEclipticIAU06_Test()
    {
        var julianDate = new JulianDate(1234.5 + 2440000.5);
        var equatorialCoords = new EquatorialCoordinates(0.987, 1.234);

        var result = CoordinatesModule.EquatorialToEclipticIAU06(julianDate, equatorialCoords);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(1.342509918994654619, 0.5926215259704608132),
            result,
            1e-14);
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

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(-0.4636476090008061162, 0.2199879773954594463),
            result,
            1e-14);
    }

    [Test]
    public void EclipticToEquatorialLongTerm_Test()
    {
        var julianEpoch = 2500.0;
        var eclipticCoords = new EclipticCoordinates(1.5, 0.6);

        var result = CoordinatesModule.EclipticToEquatorialLongTerm(julianEpoch, eclipticCoords);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(0.9966573543519204791, 1.275156021861921167),
            result,
            1e-14);
    }

    [Test]
    public void EquatorialToEclipticLongTerm_Test()
    {
        var julianEpoch = -1500.0;
        var equatorialCoords = new EquatorialCoordinates(0.987, 1.234);

        var result = CoordinatesModule.EquatorialToEclipticLongTerm(julianEpoch, equatorialCoords);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(0.5039483649047114859, 0.5848534459726224882),
            result,
            1e-14);
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

    [Test]
    public void GalacticToEquatorialCoordinatesICRS_Test()
    {
        var galacticCoords = 
            new GalacticCoordinates(5.5850536063818546461558105, -0.7853981633974483096156608);

        var result = CoordinatesModule.GalacticToEquatorialCoordinatesICRS(galacticCoords);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(-1.1784870613579944551541, 5.9338074302227188048671),
            result,
            1e-14);
    }

    [Test]
    public void EquatorialToGalacticCoordinatesICRS_Test()
    {
        var equatorialCoords =
            new EquatorialCoordinates(-1.1784870613579944551540570, 5.9338074302227188048671087);

        var result = CoordinatesModule.EquatorialToGalacticCoordinatesICRS(equatorialCoords);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(5.5850536063818546461558, -0.7853981633974483096157),
            result,
            1e-14);
    }

    [Test]
    public void HorizonToHourAngleCoordinates_Test()
    {
        var horizonCoords = new HorizonCoordinates(1.1, 5.5);
        double siteLatitude = 0.7;

        var result = CoordinatesModule.HorizonToHourAngleCoordinates(horizonCoords, siteLatitude);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(0.9613934761647817620, 0.5933291115507309663),
            result,
            1e-14);
    }

    [Test]
    public void HourAngleToHorizonCoordinates_Test()
    {
        var hourAngleCoords = new HourAngleCoordinates(1.2, 1.1);
        double siteLatitude = 0.3;

        var result = CoordinatesModule.HourAngleToHorizonCoordinates(hourAngleCoords, siteLatitude);

        AssertCoordinateSystem2D(ICoordinateSystem2D<double>.Create(0.4472186304990486228, 5.916889243730066194),
            result,
            1e-14);
    }

    [Test]
    public void ParallacticAngle_Test()
    {
        double ha = 1.1,
            dec = 1.2,
            phi = 0.3;

        var result = CoordinatesModule.ParallacticAngle(ha, dec, phi);

        Assert.That(result, Is.EqualTo(1.906227428001995580).Within(1e-13));
    }

    private static EqualConstraint IsEqualTo(double x)
        => Is.EqualTo(x).Within(1e-14);

}
