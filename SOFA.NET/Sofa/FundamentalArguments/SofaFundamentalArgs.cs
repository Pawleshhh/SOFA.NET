using System.Runtime.InteropServices;

namespace SOFA.NET;

internal static partial class SofaFundamentalArgs
{

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFad03", SetLastError = true)]
    internal static partial double Fad03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFae03", SetLastError = true)]
    internal static partial double Fae03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFaf03", SetLastError = true)]
    internal static partial double Faf03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFaju03", SetLastError = true)]
    internal static partial double Faju03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFal03", SetLastError = true)]
    internal static partial double Fal03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFalp03", SetLastError = true)]
    internal static partial double Falp03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFama03", SetLastError = true)]
    internal static partial double Fama03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFame03", SetLastError = true)]
    internal static partial double Fame03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFane03", SetLastError = true)]
    internal static partial double Fane03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFaom03", SetLastError = true)]
    internal static partial double Faom03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFapa03", SetLastError = true)]
    internal static partial double Fapa03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFasa03", SetLastError = true)]
    internal static partial double Fasa03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFaur03", SetLastError = true)]
    internal static partial double Faur03(double t);

    [LibraryImport(SofaDllHelper.DllPath, EntryPoint = "iauFave03", SetLastError = true)]
    internal static partial double Fave03(double t);
}
