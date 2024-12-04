using System.CommandLine;
using System.Text;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class StartOperationCmd
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>(new[] { "--icdHandle", "-h" },
        "ICD handle")
        { IsRequired = true };

        var icdOperationOption = new Option<long>(new[] { "--icdOperation", "-o" },
        "Operation to perform (bit flags)")
        { IsRequired = true };

        var timeOutOption = new Option<long>(new[] { "--timeOut", "-t" },
        "Execution timeout value (1 = 0.1s). Range: 0 to 72000s. If 0, no timeout")
        { IsRequired = true };

        var serialWriteAddressOption = new Option<uint>(new[] { "--serialWriteAddress", "-address" },
        "Address for writing serial number (0x0-0xfffffc)")
        { IsRequired = true };

        var serialNumberSizeOption = new Option<int>(new[] { "--serialNumberSize", "-size" },
        "Serial number size (Bytes). If 0, no serial number is written")
        { IsRequired = true };

        var serialNumberOption = new Option<string>(new[] { "--serialNumber", "-sn" },
        "Serial number")
        { IsRequired = true };

        var startOperationCommand = new Command(
            "StartOperation", "Start a programming operation")
        {
            icdHandleOption,
            icdOperationOption,
            timeOutOption,
            serialWriteAddressOption,
            serialNumberSizeOption,
            serialNumberOption
        };

        startOperationCommand.SetHandler((icdHandle, icdOperation, timeOut, serialWriteAddress, serialNumberSize, serialNumber) =>
        {
            try
            {
                byte[] serialNumberBytes = serialNumber != null
                    ? Encoding.UTF8.GetBytes(serialNumber)
                    : new byte[serialNumberSize];

                var returnValue = MultiProgrammer.StartOperation(
                    icdHandle,
                    icdOperation,
                    timeOut,
                    serialWriteAddress,
                    serialNumberSize,
                    serialNumberBytes
                );

                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        },
        icdHandleOption,
        icdOperationOption,
        timeOutOption,
        serialWriteAddressOption,
        serialNumberSizeOption,
        serialNumberOption);

        return startOperationCommand;
    }
}