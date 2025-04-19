namespace SOFA.NET.Tests;

using System.Runtime.InteropServices;
using static SOFA.NET.Tests.SofaTestHelper;

[TestFixture]
internal class SofaAstrometryTest
{

    [Test]
    public void TestExternMethods()
    {
        double d1 = 2456165.5, d2 = 0.401182685;
        var arr6 = new double[6];
        var arr3 = new double[3];
        var astrom = new ASTROM();
        // Ab
        SofaAstrometry.Ab(arr3, arr3, 0, 0, arr3);
        AssertLastError();

        // Apcg
        SofaAstrometry.Apcg(d1, d2, arr6, arr3, ref astrom);
        AssertLastError();

        // Acpg13
        SofaAstrometry.Apcg13(d1, d2, ref astrom);
        AssertLastError();

        // Apci
        astrom = new ASTROM();
        SofaAstrometry.Apci(d1, d2, arr6, arr3, 0, 0, 0, ref astrom);
        AssertLastError();

        // Apci13
        double eo = 0;
        SofaAstrometry.Apci13(d1, d2, ref astrom, ref eo);
        AssertLastError();

        // Apco
        SofaAstrometry.Apco(d1, d2, arr6, arr3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref astrom);
        AssertLastError();

        // Apco13
        SofaAstrometry.Apco13(d1, d2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref astrom, ref eo);
        AssertLastError();

        // Apcs
        SofaAstrometry.Apcs(d1, d2, arr6, arr6, arr3, ref astrom);
        AssertLastError();

        // Apcs13
        SofaAstrometry.Apcs13(d1, d2, arr6, ref astrom);
        AssertLastError();

        // Aper
        SofaAstrometry.Aper(0, ref astrom);
        AssertLastError();
    }
}
