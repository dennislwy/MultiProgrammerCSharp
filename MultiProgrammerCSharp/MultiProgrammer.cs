namespace MultiProgrammerCSharp;

using System.Text;
using System.Runtime.InteropServices;
using Models;
using Enums;

/// <summary>
/// C# wrapper class for the MultiProgrammer.dll
/// </summary>
/// <remarks>
/// Based on Multi Programmer Ver.4.0 (S5U1C17000Y24) pdf documentation
/// </remarks>
public static class MultiProgrammer
{
    /// <summary>
    /// Target MCU information and user program initialization
    /// Model-specific information file reading and initialization
    /// </summary>
    /// <remarks>
    /// int InitializeTargetInfo(const TargetInfo * pTargetInfo, const UserInfo * pUserInfo, unsigned long *userProgramCheckSum);
    /// </remarks>
    /// <param name="pTargetInfo">Target MCU information</param>
    /// <param name="pUserInfo">User program information</param>
    /// <param name="userProgramCheckSum">User program checksum. Calculates and stores the user program checksum.</param>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "InitializeTargetInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue InitializeTargetInfo(
        ref TargetInfo pTargetInfo,
        ref UserInfo pUserInfo,
        out uint userProgramCheckSum // unsigned long
    );

    /// <summary>
    /// Model-specific information file release
    /// </summary>
    /// <remarks>
    /// int ReleaseTargetInfo(void);
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "ReleaseTargetInfo", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue ReleaseTargetInfo();

    /// <summary>
    /// Connects an ICDmini to the corresponding specified ICD handle.
    /// </summary>
    /// <param name="icdHandle">ICD handle</param>
    /// <remarks>
    /// int OpenIcdConnection(long icdHandle);
    /// This function checks to confirm that GetConnectedICD() has been executed.
    /// This function does not return control until success or failure is confirmed
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "OpenIcdConnection", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue OpenIcdConnection(
        long icdHandle // signed long
    );

    /// <summary>
    /// Disconnects an ICDmini from the corresponding specified ICD handle.
    /// </summary>
    /// <param name="icdHandle">ICD handle</param>
    /// <remarks>
    /// int CloseIcdConnection(long icdHandle);
    /// This function checks to confirm that GetConnectedICD() has been executed.
    ///This function does not return control until success or failure is confirmed
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "CloseIcdConnection", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue CloseIcdConnection(
        long icdHandle // signed long
    );

    /// <summary>
    /// Resets the target for the target system connected to the ICDmini corresponding to the specified ICD handle.
    /// </summary>
    /// <param name="icdHandle">ICD handle</param>
    /// <remarks>
    /// int ResetTarget(long icdHandle);
    /// This function checks to confirm that GetConnectedICD() has been executed.
    /// This function returns control immediately after calling.
    /// This function requires monitoring of processing completion with GetStatus().
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "ResetTarget", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue ResetTarget(
        long icdHandle // signed long
    );

    /// <summary>
    /// Checks the connection to the target system connected to the ICDmini corresponding to the specified ICD handle.
    /// </summary>
    /// <param name="icdHandle">ICD handle</param>
    /// <remarks>
    /// int CheckTargetConnection(long icdHandle);
    /// This function checks to confirm that GetConnectedICD() has been executed.
    /// This function returns control immediately after calling.
    /// This function requires monitoring of processing completion with GetStatus().
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "CheckTargetConnection", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue CheckTargetConnection(
        long icdHandle // signed long
    );

    /// <summary>
    /// Executes the specified processing using the ICDmini corresponding to the specified ICD handle.
    /// </summary>
    /// <param name="icdHandle">ICD handle</param>
    /// <param name="icdOperation">Processing performed:
    /// bit0: Reset target system (1: Yes, 0: No)
    /// bit1: Erase target flash (1: Yes, 0: No)
    /// bit2: Write target flash (1: Yes, 0: No)
    /// bit3: Verify target flash (1: Yes, 0: No)
    /// bit4: Write serial number (1: Yes, 0: No)</param>
    /// <param name="timeOut">Execution timeout value (1 = 0.1s). Range: 0 to 72000s. If 0, no timeout.</param>
    /// <param name="serialWriteAddress">Address for writing serial number (0x0-0xfffffc).</param>
    /// <param name="serialNumberSize">Serial number size (Bytes). If 0, no serial number is written.</param>
    /// <param name="serialNumber">Serial number</param>
    /// <remarks>
    /// int StartOperation(long icdHandle, long icdOperation, long timeOut, unsinged long serialWriteAddress, int serialNumberSize, unsigned char *serialNumber);
    /// This function checks to confirm that GetConnectedICD() has been executed.
    /// This function returns control immediately after calling.
    /// This function requires monitoring of processing completion with GetStatus().
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "StartOperation", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue StartOperation(
        long icdHandle,
        long icdOperation,
        long timeOut,
        uint serialWriteAddress, // unsigned long
        int serialNumberSize,
        byte[] serialNumber // unsigned char *
    );

    /// <summary>
    /// Fetches the processing status for the ICDmini corresponding to the specified ICD handle.
    /// </summary>
    /// <param name="icdHandle">ICD handle</param>
    /// <param name="serialNumberSize">Serial number size (0 indicates matching).</param>
    /// <param name="serialNumber">Serial number read from the target system.</param>
    /// <remarks>
    /// int GetStatus(long icdHandle, int *serialNumberSize, unsigned char *serialNumber);
    /// </remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "GetStatus", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue GetStatus(
        long icdHandle,
        out int serialNumberSize, // int*
        [Out] byte[] serialNumber // unsigned char*
    );

    /// <summary>
    /// Returns a text string in response to a return code.
    /// </summary>
    /// <param name="returnCode">Return code.</param>
    /// <param name="returnedString">Text string corresponding to the return code. Must have at least 256 bytes of space.</param>
    /// <remarks>int GetString(int returnCode, char * returnedString);</remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "GetString", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue GetString(
        int returnCode,
        [Out] StringBuilder returnedString // char*
    );

    /// <summary>
    /// Fetches information for the ICDmini connected to the PC.
    /// </summary>
    /// <param name="maxCount">Maximum number of ICDminis connected (Up to 10).</param>
    /// <param name="connectedCount">Number of ICDminis connected.</param>
    /// <param name="pIcdInfo">ICDmini information.</param>
    /// <remarks>int GetConnectedICD (long maxCount, long *connectedCount, struct icdInfo *pIcdInfo);</remarks>
    /// <returns>Returns value indicating the result status</returns>
    [DllImport("MultiProgrammer.dll", EntryPoint = "GetConnectedICD", CallingConvention = CallingConvention.Cdecl)]
    public static extern ReturnValue GetConnectedIcd(
        long maxCount,
        out long connectedCount, // long*
        [Out] IcdInfo[] pIcdInfo // struct icdInfo*
    );
}
