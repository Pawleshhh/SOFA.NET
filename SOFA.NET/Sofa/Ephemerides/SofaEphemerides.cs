using System.Runtime.InteropServices;

namespace SOFA.NET;

internal static partial class SofaEphemerides
{

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauEpv00", SetLastError = true)]
    internal static partial int Epv00(
        double date1, 
        double date2, 
        [In, Out] double[] pvh,
        [In, Out] double[] pvb);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauMoon98", SetLastError = true)]
    internal static partial void Moon98(double date1, double date2, [In, Out] double[] pv);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauPlan94", SetLastError = true)]
    internal static partial int Plan94(double date1, double date2, int np, [In, Out] double[] pv);
}
