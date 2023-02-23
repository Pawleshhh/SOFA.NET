namespace SOFA.NET.Test;

internal static class TestUtils
{

    public static void AssertCoordinateSystem2D(ICoordinateSystem2D<double> expected, ICoordinateSystem2D<double> actual, double delta)
        => AssertCoordinateSystem2D(expected, actual, delta, delta);

    public static void AssertCoordinateSystem2D(ICoordinateSystem2D<double> expected, ICoordinateSystem2D<double> actual, double xDelta = 0.0, double yDelta = 0.0)
    {
        Assert.Multiple(() =>
        {
            Assert.That(actual.X, Is.EqualTo(expected.X).Within(xDelta), $"X failed");
            Assert.That(actual.Y, Is.EqualTo(expected.Y).Within(yDelta), $"Y failed");
        });
    }

    public static void AssertCoordinateSystem3D(ICoordinateSystem3D<double> expected, ICoordinateSystem3D<double> actual, double delta)
        => AssertCoordinateSystem3D(expected, actual, delta, delta, delta);

    public static void AssertCoordinateSystem3D(
        ICoordinateSystem3D<double> expected, 
        ICoordinateSystem3D<double> actual, 
        double xDelta = 0.0,
        double yDelta = 0.0,
        double zDelta = 0.0)
    {
        Assert.Multiple(() =>
        {
            Assert.That(actual.X, Is.EqualTo(expected.X).Within(xDelta), $"X failed");
            Assert.That(actual.Y, Is.EqualTo(expected.Y).Within(yDelta), $"Y failed");
            Assert.That(actual.Z, Is.EqualTo(expected.Z).Within(zDelta), $"Z failed");
        });
    }

}
