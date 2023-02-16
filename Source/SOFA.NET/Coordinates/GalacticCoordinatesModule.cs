namespace SOFA.NET;

public static partial class CoordinatesModule
{

    private static readonly double[,] galacticRotationMatrix = new double[,]
    {
        { -0.054875560416215368492398900454,
          -0.873437090234885048760383168409,
          -0.483835015548713226831774175116 },
        { +0.494109427875583673525222371358,
          -0.444829629960011178146614061616,
          +0.746982244497218890527388004556 },
        { -0.867666149019004701181616534570,
          -0.198076373431201528180486091412,
          +0.455983776175066922272100478348 }
    };

    /// <summary>
    /// Transformation from Galactic Coordinates to ICRS.
    /// SOFA name: iauG2icrs
    /// </summary>
    /// <param name="galacticCoordinates"></param>
    /// <returns></returns>
    public static EquatorialCoordinates GalacticToEquatorialCoordinatesICRS(GalacticCoordinates galacticCoordinates)
    {
        var v1 = SphericalToCartesian(galacticCoordinates);
        var v2 = MatrixHelper.TransposeMultiply(galacticRotationMatrix, v1);
        var eq = VectorToSphericalCoordinates(v2);

        return new(MathHelper.NormalizeAngleIntoMinusOnePIToPlusOnePI(eq.Y),
            MathHelper.NormalizeAngleIntoZero2PI(eq.X));
    }

}
