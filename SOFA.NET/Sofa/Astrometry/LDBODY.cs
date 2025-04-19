using System.Runtime.InteropServices;

namespace SOFA.NET;

[StructLayout(LayoutKind.Sequential)]
internal struct LDBODY
{
    public LDBODY()
    {
        
    }

    public double bm;
    public double dl;
    public double[] pv = new double[6]; // [2][3]
}
