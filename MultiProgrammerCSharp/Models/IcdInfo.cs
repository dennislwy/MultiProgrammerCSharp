namespace MultiProgrammerCSharp.Models;

using System.Runtime.InteropServices;

/// <summary>
/// Information about an ICDmini connected to the PC.
/// </summary>
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct IcdInfo
{
    /// <summary>ICD handle</summary>
    public long IcdHandle; 

    // <summary>Number of icdminix.dll used(icdmini2.dll=2, icdmini3.dll=3)</summary>
    public int IcdDllVersion;

    /// <summary>ICD version</summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
    public string IcdVersion; // ICD version
    
    /// <summary>Serial number</summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string IcdSerialNumber; // Serial number
}