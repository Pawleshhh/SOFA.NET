using System.Runtime.InteropServices;

namespace SOFA.NET.Tests;

internal static class SofaTestHelper
{

    public static void AssertLastError(bool occured = false)
    {
        var err = Marshal.GetLastPInvokeError();
        var msg = Marshal.GetLastPInvokeErrorMessage();
        if (occured)
        {
            Assert.That(err, Is.Not.EqualTo(0), $"Error code: {err}. Message: {msg}");
        }
        else
        {
            Assert.That(err, Is.EqualTo(0));
        }
    }

}
