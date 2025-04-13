using System.Runtime.InteropServices;

namespace SOFA.NET.Tests;

internal static class SofaTestHelper
{

    public static void AssertLastError(bool occured = false)
    {
        var err = Marshal.GetLastWin32Error();
        if (occured)
        {
            Assert.That(err, Is.Not.EqualTo(0));
        }
        else
        {
            Assert.That(err, Is.EqualTo(0));
        }
    }

}
