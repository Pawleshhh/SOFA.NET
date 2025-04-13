using System.Runtime.InteropServices;

namespace SOFA.NET;

internal static partial class SofaCalendars
{

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauCal2jd", SetLastError = true)]
    internal static partial int Cal2jd(int iy, int im, int id, ref double djm0, ref double djm);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauEpb", SetLastError = true)]
    public static partial double Epb(double dj1, double dj2);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauEpb2jd", SetLastError = true)]
    public static partial void Epb2jd(double epb, ref double djm0, ref double djm);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauEpj", SetLastError = true)]
    public static partial double Epj(double dj1, double dj2);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauEpj2jd", SetLastError = true)]
    public static partial void Epj2jd(double epj, ref double djm0, ref double djm);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauJd2cal", SetLastError = true)]
    public static partial int Jd2cal(double dj1, double dj2, ref int iy, ref int im, ref int id, ref double fd);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauJdcalf", SetLastError = true)]
    public static partial int Jdcalf(int ndp, double dj1, double dj2, [Out] int[] iymdf);
}
