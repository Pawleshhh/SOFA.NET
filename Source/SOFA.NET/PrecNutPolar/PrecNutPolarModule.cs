﻿using static SOFA.NET.ThrowHelper;

namespace SOFA.NET;

public static class PrecNutPolarModule
{

    /// <summary>
    /// Mean obliquity of the ecliptic, IAU 2006 precession model.
    /// SOFA name: iauObl06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double MeanObliquityOfTheEclipticIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var t = ttJulianDate.JulianCentury();
        double eps0 = (84381.406 +
          (-46.836769 +
          (-0.0001831 +
          (0.00200340 +
          (-0.000000576 +
          (-0.0000000434) * t) * t) * t) * t) * t) * Constants.DAS2R;

        return eps0;
    }

    /// <summary>
    /// Precession matrix (including frame bias) from GCRS to a specified date, IAU 2006 model
    /// SOFA name: iauPmat06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static double[,] PrecessionMatrixFromGcrsToDateIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);

        var angles = PrecessionAnglesIAU06(ttJulianDate);
        var matrix = FormRotationMatrix(angles);

        return matrix;
    }

    /// <summary>
    /// Precession angles, IAU 2006 (Fukushima-Williams 4-angle formulation)
    /// SOFA name: iauPfw06
    /// </summary>
    /// <param name="ttJulianDate"></param>
    /// <returns></returns>
    public static FukushimaWilliamsAngles PrecessionAnglesIAU06(JulianDate ttJulianDate)
    {
        ThrowIfNotExpectedJulianDateKind(JulianDateKind.Tt, ttJulianDate);
        double gamb, phib, psib, epsa;

        var t = ttJulianDate.JulianCentury();
        gamb = (-0.052928 +
            (10.556378 +
            (0.4932044 +
            (-0.00031238 +
            (-0.000002788 +
            (0.0000000260)
            * t) * t) * t) * t) * t) * Constants.DAS2R;
        phib = (84381.412819 +
            (-46.811016 +
            (0.0511268 +
            (0.00053289 +
            (-0.000000440 +
            (-0.0000000176)
            * t) * t) * t) * t) * t) * Constants.DAS2R;
        psib = (-0.041775 +
            (5038.481484 +
            (1.5584175 +
            (-0.00018522 +
            (-0.000026452 +
            (-0.0000000148)
            * t) * t) * t) * t) * t) * Constants.DAS2R;
        epsa = MeanObliquityOfTheEclipticIAU06(ttJulianDate);

        return new(gamb, phib, psib, epsa);
    }

    /// <summary>
    /// Form rotation matrix given the Fukushima-Williams angles
    /// SOFA name: iauFw2m
    /// </summary>
    /// <param name="angles"></param>
    /// <returns></returns>
    public static double[,] FormRotationMatrix(FukushimaWilliamsAngles angles)
    {
        double[,] matrix = MatrixHelper.IdentityMatrix();
        var (gamma, phi, psi, eps) = angles;

        MatrixHelper.RotateZ(matrix, gamma);
        MatrixHelper.RotateX(matrix, phi);
        MatrixHelper.RotateZ(matrix, -psi);
        MatrixHelper.RotateX(matrix, -eps);

        return matrix;
    }

}