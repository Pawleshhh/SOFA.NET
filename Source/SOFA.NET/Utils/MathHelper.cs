using static System.Math;

namespace SOFA.NET;

internal static class MathHelper
{

    #region Methods

    /// <summary>
    /// SOFA's counterpart: iauAnp
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static double NormalizeAngleIntoZero2PI(double angle)
    {
        angle = angle % Constants.PI2;
        if (angle < 0)
        {
            angle += Constants.PI2;
        }

        return angle;
    }

    /// <summary>
    /// SOFA's counterpart: iauAnpm
    /// </summary>
    /// <param name="angle"></param>
    /// <returns></returns>
    public static double NormalizeAngleIntoMinusOnePIToPlusOnePI(double angle)
    {
        var result = angle % Constants.PI2;
        if (Abs(result) >= PI)
        {
            result -= angle < 0.0 ? -Abs(Constants.PI2) : Abs(Constants.PI2);
        }

        return result;
    }

    public static double DegreesToRadians(double a)
    {
        return a * PI / 180.0;
    }

    public static double RadiansToDegrees(double a)
    {
        return a * 180.0 / PI;
    }

    #endregion

}
