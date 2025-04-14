namespace SOFA.NET.Tests;

using static SofaFundamentalArgs;
using static SofaTestHelper;

[TestFixture]
internal class SofaFundamentalArgsTest
{

    [Test]
    public void TestExternMethods()
    {
        double t = 0.8;

        List<Func<double, double>> funcs = new()
        {
            Fad03,
            Fae03,
            Faf03,
            Faju03,
            Fal03,
            Falp03,
            Fama03,
            Fame03,
            Fane03,
            Faom03,
            Fapa03,
            Fasa03,
            Faur03,
            Fave03
        };

        foreach (var func in funcs)
        {
            func(t);
            AssertLastError();
        }
    }
}
