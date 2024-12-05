namespace MultiProgrammerCSharp.Models;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct UserInfo
{
    /// <summary>
    /// Verification method
    /// </summary>
    /// <remarks>
    /// 0: Compare all data
    /// 1: Compare checksum
    /// </remarks>
    public int UserProgramVerify;

    /// <summary>
    /// User program segments
    /// </summary>
    /// <remarks>
    /// The number of segments if the user program is divided into multiple address areas. Maximum 1,024
    /// </remarks>
    public int UserParamCount;

    /// <summary>
    /// User program information start pointer
    /// </summary>
    /// <remarks>
    /// Corresponding information if the user program is divided into multiple address areas
    /// </remarks>
    public IntPtr UserProgramParam; // Pointer to an array of UserProgramParam
}