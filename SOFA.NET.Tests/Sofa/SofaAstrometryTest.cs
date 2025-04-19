namespace SOFA.NET.Tests;

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

        // Aper13
        SofaAstrometry.Aper13(d1, d2, ref astrom);
        AssertLastError();

        // Apio
        SofaAstrometry.Apio(d1, d2, 0, 0, 0, 0, 0, 0, 0, ref astrom);
        AssertLastError();

        // Apio13
        SofaAstrometry.Apio13(d1, d2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref astrom);
        AssertLastError();

        // Atcc13
        double ra = 0, dc = 0;
        SofaAstrometry.Atcc13(0, 0, 0, 0, 0, 0, d1, d2, ref ra, ref dc);
        AssertLastError();

        // Atccq
        SofaAstrometry.Atccq(0, 0, 0, 0, 0, 0, ref astrom, ref ra, ref dc);
        AssertLastError();

        // Atci13
        SofaAstrometry.Atci13(0, 0, 0, 0, 0, 0, d1, d2, ref ra, ref dc, ref eo);
        AssertLastError();

        // Atciq
        SofaAstrometry.Atciq(0, 0, 0, 0, 0, 0, ref astrom, ref ra, ref dc);
        AssertLastError();

        // Atciqn
        SofaAstrometry.Atciqn(0, 0, 0, 0, 0, 0, ref astrom, 3, new LDBODY[3], ref ra, ref dc);
        AssertLastError();

        // Atciqz
        SofaAstrometry.Atciqz(0, 0, ref astrom, ref ra, ref dc);
        AssertLastError();

        // Atco13
        double aob = 0, zob = 0, hob = 0, dob = 0, rob = 0;
        SofaAstrometry.Atco13(
            0, 0, 0, 0, 0, 0,
            d1, d2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            ref aob, ref zob, ref hob, ref dob, ref rob, ref eo);
        AssertLastError();

        // Atic13
        SofaAstrometry.Atic13(0, 0, d1, d2, ref ra, ref dc, ref eo);
        AssertLastError();

        // Aticq
        SofaAstrometry.Aticq(0, 0, ref astrom, ref ra, ref dc);
        AssertLastError();

        // Aticqn
        SofaAstrometry.Aticqn(0, 0, ref astrom, 3, new LDBODY[3], ref ra, ref dc);
        AssertLastError();

        // Atio13
        SofaAstrometry.Atio13(
            0, 0, d1, d2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            ref aob, ref zob, ref hob, ref dob, ref rob);
        AssertLastError();

        // Atioq
        SofaAstrometry.Atioq(0, 0, ref astrom, ref aob, ref zob, ref hob, ref dob, ref rob);
        AssertLastError();

        // Atoc13
        SofaAstrometry.Atoc13("R", 0, 0, d1, d2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref ra, ref dc);
        AssertLastError();

        // Atoi13
        SofaAstrometry.Atoi13("R", 0, 0, d1, d2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref ra, ref dc);
        AssertLastError();

        // Atoiq
        SofaAstrometry.Atoiq("R", 0, 0, ref astrom, ref ra, ref dc);
        AssertLastError();

        // Ld
        SofaAstrometry.Ld(0, arr3, arr3, arr3, 0, 0, new double[3]);
        AssertLastError();

        // Ldn
        SofaAstrometry.Ldn(3, new LDBODY[3], arr3, arr3, new double[3]);
        AssertLastError();

        // Ldsun
        SofaAstrometry.Ldsun(arr3, arr3, 0, new double[3]);
        AssertLastError();

        // Pmpx
        SofaAstrometry.Pmpx(0, 0, 0, 0, 0, 0, 0, arr3, new double[3]);
        AssertLastError();

        // Pmsafe
        double ra2 = 0, dec2 = 0, pmr2 = 0, pmd2 = 0, px2 = 0, rv2 = 0;
        SofaAstrometry.Pmsafe(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ref ra2, ref dec2, ref pmr2, ref pmd2, ref px2, ref rv2);
        AssertLastError();

        // Pvtob
        SofaAstrometry.Pvtob(0, 0, 0, 0, 0, 0, 0, new double[6]);
        AssertLastError();

        // Refco
        double refa = 0, refb = 0;
        SofaAstrometry.Refco(0, 0, 0, 0, ref refa, ref refb);
        AssertLastError();
    }
}
