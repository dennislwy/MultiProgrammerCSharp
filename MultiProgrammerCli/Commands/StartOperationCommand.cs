using System.CommandLine;
using System.Text;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class StartOperationCommand
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>("--icdHandle", "ICD handle for the operation");
        var icdOperationOption = new Option<long>("--icdOperation", "Operation to perform (bit flags)");
        var timeOutOption = new Option<long>("--timeOut", "Execution timeout value (0.1s units)");
        var serialWriteAddressOption = new Option<uint>("--serialWriteAddress", "Address for writing serial number");
        var serialNumberSizeOption = new Option<int>("--serialNumberSize", "Size of serial number");
        var serialNumberOption = new Option<string>("--serialNumber", "Serial number to write");

        var startOperationCommand = new Command("StartOperation", "Start a programming operation")
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
                    ? Encoding.ASCII.GetBytes(serialNumber)
                    : new byte[serialNumberSize];

                var result = MultiProgrammer.StartOperation(
                    icdHandle,
                    icdOperation,
                    timeOut,
                    serialWriteAddress,
                    serialNumberSize,
                    serialNumberBytes
                );

                Console.WriteLine($"Operation Result: {result}");

                // Optionally, get and print the status
                var statusResult = MultiProgrammer.GetStatus(
                    icdHandle,
                    out int outSerialNumberSize,
                    new byte[serialNumberSize]
                );

                Console.WriteLine($"Status Result: {statusResult}");
                Console.WriteLine($"Serial Number Size: {outSerialNumberSize}");
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