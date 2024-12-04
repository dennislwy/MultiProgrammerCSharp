namespace MultiProgrammerCSharp.Enums;

/// <summary>
/// Returns code indicating the result status. Please refer to Appendix A.2.9
/// </summary>
public enum ReturnCode
{
    /// <summary>Normally ended.</summary>
    OK = 0x00,

    /// <summary>Error occurred.</summary>
    NG = 0x01,

    /// <summary>Time out occurred while connecting with the target system.</summary>
    ERROR_TIMEOUT_TARGET_CONNECTION = 0x12,

    /// <summary>Time out occurred while executing target-reset.</summary>
    ERROR_TIMEOUT_TARGET_RESET = 0x13,

    /// <summary>Time out occurred while erasing the FLASH memory.</summary>
    ERROR_TIMEOUT_ERASE = 0x14,

    /// <summary>Time out occurred while writing to the FLASH memory.</summary>
    ERROR_TIMEOUT_WRITE = 0x15,

    /// <summary>Time out occurred while verifying the FLASH memory.</summary>
    ERROR_TIMEOUT_VERIFY = 0x16,

    /// <summary>Can not connect with the ICDmini.</summary>
    ERROR_ICD_OPEN_CONNECTION = 0x21,

    /// <summary>Already disconnected with the ICDmini.</summary>
    ERROR_ICD_CONNECTION = 0x22,

    /// <summary>Can not disconnect with the ICDmini.</summary>
    ERROR_ICD_CLOSE_CONNECTION = 0x29,

    /// <summary>Disconnected with the target system.</summary>
    ERROR_TARGET_CONNECTION = 0x32,

    /// <summary>No response from the target for target-reset.</summary>
    ERROR_TARGET_RESET = 0x33,

    /// <summary>Error occurred while erasing the FLASH memory.</summary>
    ERROR_ERASE = 0x44,

    /// <summary>Error occurred while writing to the FLASH memory.</summary>
    ERROR_WRITE = 0x45,

    /// <summary>Error occurred while verifying the FLASH memory.</summary>
    ERROR_VERIFY = 0x46,

    /// <summary>Parameter is invalid.</summary>
    ERROR_PARAMETER = 0x50,

    /// <summary>Connecting with the target system.</summary>
    OPERATION_TARGET_CONNECTION = 0x82,

    /// <summary>Executing target-reset.</summary>
    OPERATION_TARGET_RESET = 0x83,

    /// <summary>Erasing the FLASH memory.</summary>
    OPERATION_ERASE = 0x84,

    /// <summary>Writing to the FLASH memory.</summary>
    OPERATION_WRITE = 0x85,

    /// <summary>Verifying the FLASH memory.</summary>
    OPERATION_VERIFY = 0x86,

    /// <summary>Time out occurred while writing serial number to the FLASH memory.</summary>
    ERROR_TIMEOUT_WRITE_SERIALNO = 0x90,

    /// <summary>Error occurred while writing serial number to the FLASH memory.</summary>
    ERROR_WRITE_SERIALNO = 0x91,

    /// <summary>Writing serial number to the FLASH memory.</summary>
    OPERATION_WRITE_SERIALNO = 0x92,

    /// <summary>Error occurred while verifying serial number to the FLASH memory.</summary>
    ERROR_VERIFY_SERIALNO = 0x93
}