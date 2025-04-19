using System.Runtime.InteropServices;

namespace SOFA.NET;

internal static partial class SofaAstrometry
{

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAb", SetLastError = true)]
    internal static partial void Ab(
        [In] double[] pnat,
        [In] double[] v,
        double s,
        double bm1,
        [Out] double[] ppr);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApcg", SetLastError = true)]
    internal static extern void Apcg(
        double date1,
        double date2,
        [In, Out] double[] ebpv,
        [In, Out] double[] ehp,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApcg13", SetLastError = true)]
    internal static extern void Apcg13(
        double date1,
        double date2,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApci", SetLastError = true)]
    internal static extern void Apci(
        double date1,
        double date2,
        [In, Out] double[] ebpv,
        [In, Out] double[] ehp,
        double x,
        double y,
        double s,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApci13", SetLastError = true)]
    internal static extern void Apci13(
        double date1,
        double date2,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double eo);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApco", SetLastError = true)]
    internal static extern void Apco(
        double date1, double date2,
        [In, Out] double[] ebpv, [In, Out] double[] ehp,
        double x, double y, double s, double theta,
        double elong, double phi, double hm,
        double xp, double yp, double sp,
        double refa, double refb,
        [In, Out] ref ASTROM astrom);


    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApco13", SetLastError = true)]
    internal static extern int Apco13(
        double utc1, double utc2, double dut1,
        double elong, double phi, double hm, double xp, double yp,
        double phpa, double tc, double rh, double wl,
        [In, Out] ref ASTROM astrom, [In, Out] ref double eo);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApcs", SetLastError = true)]
    internal static extern void Apcs(
        double date1, double date2, [In, Out] double[] pv,
        [In, Out] double[] ebpv, [In, Out] double[] ehp,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApcs13", SetLastError = true)]
    internal static extern void Apcs13(
        double date1, double date2,
        [In, Out] double[] pv,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAper", SetLastError = true)]
    internal static extern void Aper(
        double theta,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAper13", SetLastError = true)]
    internal static extern void Aper13(
        double ut11, double ut12, [In, Out] ref ASTROM astrom);
}
