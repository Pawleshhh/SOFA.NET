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

}
