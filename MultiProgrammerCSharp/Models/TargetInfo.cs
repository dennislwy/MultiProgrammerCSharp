namespace MultiProgrammerCSharp.Models;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct TargetInfo
{
    /// <summary>
    /// Model name
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public string McuName;

    /// <summary>
    /// Model-specific information file path
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2000)]
    public string McuPath;

    /// <summary>
    /// MCU model Detail option text string
    /// </summary>
    /// <remarks>
    /// Set to "ALL 0x00" if not specified.
    /// (For more information, refer to the readme file
    /// included in the model-specific information file package.)
    /// </remarks>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
    public string McuOption;

    /// <summary>
    /// Flash security password unlocking (0: No, 1: Yes)
    /// </summary>
    public int McuSecurityRelease;

    /// <summary>
    /// Flash security version (fixed at M03)
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
    public string McuSecurityVersion;

    /// <summary>
    /// Flash security password
    /// </summary>
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
    public string McuSecurityPassword;
}