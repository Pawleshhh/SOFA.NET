namespace SOFA.NET.Tests;

using static SofaTestHelper;
using static SofaEphemerides;

internal class SofaEphemeridesTest
{

    [Test]
    public void TestExternMethods()
    {
        // Epv00
        var phv = new double[6];
        var pvb = new double[6];
        var epv00 = Epv00(2400000.5, 53411.52501161, phv, pvb);
        AssertLastError();

        // Moon98
        var pv = new double[6];
        Moon98(2400000.5, 43999.9, pv);
        AssertLastError();

        // Plan94
        pv = new double[6];
        var plan94 = Plan94(2400000.5, 1e6, 0, pv);
        AssertLastError();
    }

}
