using NUnit.Framework.Constraints;

namespace SOFA.NET.Test;

[TestFixture]
internal class CoordinatesModuleTest
{

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

        static EqualConstraint IsEqualTo(double x)
            => Is.EqualTo(x).Within(1e-14);
    }

}
