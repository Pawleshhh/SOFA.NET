namespace SOFA.NET.Tests;

using static SOFA.NET.Tests.SofaTestHelper;

[TestFixture]
internal class SofaCalendarsTest
{

    [Test]
    public void TestExternMethods()
    {
        // Cal2jd
        double djm0 = 0, djm = 0;
        var cal2jd = SofaCalendars.Cal2jd(2015, 5, 5, ref djm0, ref djm);
        AssertLastError();

        // Epb
        var epb = SofaCalendars.Epb(djm0, djm);
        AssertLastError();

        // Epb2jd
        SofaCalendars.Epb2jd(epb, ref djm0, ref djm);
        AssertLastError();

        // Epj
        var epj = SofaCalendars.Epj(djm0, djm);
        AssertLastError();

        // Epj2jd
        SofaCalendars.Epj2jd(epj, ref djm0, ref djm);
        AssertLastError();

        // Jd2cal
        int iy = 0, im = 0, id = 0;
        double fd = 0;
        var jd2cal = SofaCalendars.Jd2cal(djm0, djm, ref iy, ref im, ref id, ref fd);
        AssertLastError();

        // Jdcalf
        int[] iymdf = new int[4];
        var jdcalf = SofaCalendars.Jdcalf(1, djm0, djm, iymdf);
        AssertLastError();
    }

}
