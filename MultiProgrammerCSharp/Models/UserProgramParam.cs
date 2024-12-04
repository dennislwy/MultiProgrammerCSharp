namespace MultiProgrammerCSharp.Models;

using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
public struct UserProgramParam
{
    /// <summary>
    /// User program address
    /// </summary>
    public uint UserProgramAddr; // unsigned long

    /// <summary>
    /// User program size
    /// </summary>
    /// <remarks>
    /// Units: bytes; this must be an even value
    /// </remarks>
    public uint UserProgramSize; // unsigned long

    /// <summary>
    /// User program start pointer
    /// </summary>
    public IntPtr UserProgramPointer; // unsigned char *
}