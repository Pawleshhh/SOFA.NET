using System.Runtime.InteropServices;

namespace SOFA.NET;

[StructLayout(LayoutKind.Sequential)]
internal struct ASTROM
{
    public ASTROM()
    {
        
    }

    public double pmt;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public double[] eb = new double[3]; // [3]
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public double[] eh = new double[3]; // [3]
    public double em;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public double[] v = new double[3]; // [3]
    public double bm1;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
    public double[] bpn = new double[9]; // [3][3]
    public double along;
    public double phi;
    public double xpl;
    public double ypl;
    public double sphi;
    public double cphi;
    public double diurab;
    public double eral;
    public double refa;
    public double refb;
}

