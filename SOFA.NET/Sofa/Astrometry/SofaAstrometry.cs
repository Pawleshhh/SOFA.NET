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
        [In] double[] ebpv,
        [In] double[] ehp,
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
        [In] double[] ebpv,
        [In] double[] ehp,
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
        [In] double[] ebpv, [In] double[] ehp,
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
        double date1, double date2, [In] double[] pv,
        [In] double[] ebpv, [In] double[] ehp,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApcs13", SetLastError = true)]
    internal static extern void Apcs13(
        double date1, double date2,
        [In] double[] pv,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAper", SetLastError = true)]
    internal static extern void Aper(
        double theta,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAper13", SetLastError = true)]
    internal static extern void Aper13(
        double ut11, double ut12, [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApio", SetLastError = true)]
    internal static extern void Apio(
        double sp, double theta,
        double elong, double phi, double hm, double xp, double yp,
        double refa, double refb,
        [In, Out] ref ASTROM astrom);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauApio13", SetLastError = true)]
    internal static extern int Apio13(
        double utc1, double utc2, double dut1,
        double elong, double phi, double hm, double xp, double yp,
        double phpa, double tc, double rh, double wl,
        [In, Out] ref ASTROM astrom);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtcc13", SetLastError = true)]
    internal static partial void Atcc13(
        double rc, double dc,
        double pr, double pd, double px, double rv,
        double date1, double date2,
        ref double ra, ref double da);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAtccq", SetLastError = true)]
    internal static extern void Atccq(
        double rc, double dc,
        double pr, double pd, double px, double rv,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double ra, [In, Out] ref double da);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtci13", SetLastError = true)]
    internal static partial void Atci13(
        double rc, double dc,
        double pr, double pd, double px, double rv,
        double date1, double date2,
        ref double ri, ref double di, ref double eo);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAtciq", SetLastError = true)]
    internal static extern void Atciq(
        double rc, double dc, double pr, double pd,
        double px, double rv,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double ri, [In, Out] ref double di);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAtciqn", SetLastError = true)]
    internal static extern void Atciqn(
        double rc, double dc, double pr, double pd,
        double px, double rv,
        [In, Out] ref ASTROM astrom,
        int n,
        [In] LDBODY[] b,
        [In, Out] ref double ri, [In, Out] ref double di);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAtciqz", SetLastError = true)]
    internal static extern void Atciqz(
        double rc, double dc,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double ri, [In, Out] ref double di);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtco13", SetLastError = true)]
    internal static partial int Atco13(
        double rc, double dc,
        double pr, double pd, double px, double rv,
        double utc1, double utc2, double dut1,
        double elong, double phi, double hm, double xp, double yp,
        double phpa, double tc, double rh, double wl,
        ref double aob, ref double zob, ref double hob,
        ref double dob, ref double rob, ref double eo);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtic13", SetLastError = true)]
    internal static partial void Atic13(
        double ri, double di,
        double date1, double date2,
        ref double rc, ref double dc, ref double eo);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAticq", SetLastError = true)]
    internal static extern void Aticq(
        double ri, double di,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double rc, [In, Out] ref double dc);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAticqn", SetLastError = true)]
    internal static extern void Aticqn(
        double ri, double di,
        [In, Out] ref ASTROM astrom,
        int n,
        [In, Out] LDBODY[] b,
        [In, Out] ref double rc, [In, Out] ref double dc);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtio13", SetLastError = true)]
    internal static partial int Atio13(
        double ri, double di,
        double utc1, double utc2, double dut1,
        double elong, double phi, double hm, double xp, double yp,
        double phpa, double tc, double rh, double wl,
        ref double aob, ref double zob, ref double hob,
        ref double dob, ref double rob);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAtioq", SetLastError = true)]
    internal static extern void Atioq(
        double ri, double di,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double aob, [In, Out] ref double zob,
        [In, Out] ref double hob, [In, Out] ref double dob, [In, Out] ref double rob);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtoc13", SetLastError = true)]
    internal static partial int Atoc13(
        [MarshalAs(UnmanagedType.LPStr)] string type,
        double ob1, double ob2,
        double utc1, double utc2, double dut1,
        double elong, double phi, double hm, double xp, double yp,
        double phpa, double tc, double rh, double wl,
        ref double rc, ref double dc);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauAtoi13", SetLastError = true)]
    internal static partial int Atoi13(
        [MarshalAs(UnmanagedType.LPStr)] string type,
        double ob1, double ob2,
        double utc1, double utc2, double dut1,
        double elong, double phi, double hm, double xp, double yp,
        double phpa, double tc, double rh, double wl,
        ref double ri, ref double di);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauAtoiq", SetLastError = true)]
    internal static extern void Atoiq(
        [MarshalAs(UnmanagedType.LPStr)] string type,
        double ob1, double ob2,
        [In, Out] ref ASTROM astrom,
        [In, Out] ref double ri, [In, Out] ref double di);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauLd", SetLastError = true)]
    internal static partial void Ld(
        double bm,
        [In] double[] p, [In] double[] q, [In] double[] e,
        double em, double dlim,
        [Out] double[] p1);

    [DllImport(SofaDllHelper.DllPath, EntryPoint = "iauLdn", SetLastError = true)]
    internal static extern void Ldn(
        int n,
        [In] LDBODY[] b,
        [In] double[] ob,
        [In] double[] sc,
        [Out] double[] sn);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauLdsun", SetLastError = true)]
    internal static partial void Ldsun(
        [In] double[] p,
        [In] double[] e,
        double em,
        [Out] double[] p1);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauPmpx", SetLastError = true)]
    internal static partial void Pmpx(
        double rc, double dc, double pr, double pd,
        double px, double rv, double pmt,
        [In] double[] pob,
        [Out] double[] pco);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauPmsafe", SetLastError = true)]
    internal static partial int Pmsafe(
        double ra1, double dec1, double pmr1, double pmd1,
        double px1, double rv1,
        double ep1a, double ep1b, double ep2a, double ep2b,
        ref double ra2, ref double dec2,
        ref double pmr2, ref double pmd2,
        ref double px2, ref double rv2);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauPvtob", SetLastError = true)]
    internal static partial void Pvtob(
        double elong, double phi, double height,
        double xp, double yp, double sp, double theta,
        [Out] double[] pv);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauRefco", SetLastError = true)]
    internal static partial void Refco(
        double phpa, double tc, double rh, double wl,
        ref double refa, ref double refb);

}
