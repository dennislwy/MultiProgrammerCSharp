using System.CommandLine;
using System.Text;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to start a programming operation.
/// </summary>
public static class StartOperationCmd
{
    /// <summary>
    /// Creates the StartOperation command.
    /// </summary>
    /// <returns>The StartOperation command.</returns>
    public static Command Create()
    {
        // Define the option for the ICD handle
        var icdHandleOption = new Option<long>(
            new[] { "--icdHandle", "-h" },
            "ICD handle")
        { IsRequired = true };

        // Define the option for the ICD operation
        var icdOperationOption = new Option<long>(
            new[] { "--icdOperation", "-o" },
            "Operation to perform (bit flags)")
        { IsRequired = true };

        // Define the option for the execution timeout value
        var timeOutOption = new Option<long>(
            new[] { "--timeOut", "-t" },
            "Execution timeout value (1 = 0.1s). Range: 0 to 72000s. If 0, no timeout")
        { IsRequired = true };

        // Define the option for the serial write address
        var serialWriteAddressOption = new Option<uint>(
            new[] { "--serialWriteAddress", "-a" },
            "Address for writing serial number (0x0-0xfffffc)")
        { IsRequired = true };

        // Define the option for the serial number size
        var serialNumberSizeOption = new Option<int>(
            new[] { "--serialNumberSize", "-s" },
            "Serial number size (Bytes). If 0, no serial number is written")
        { IsRequired = true };

        // Define the option for the serial number
        var serialNumberOption = new Option<string>(
            new[] { "--serialNumber", "-sn" },
            "Serial number")
        { IsRequired = true };

        // Create the command with a description
        var startOperationCommand = new Command(
            "StartOperation",
            "Start a programming operation")
        {
            icdHandleOption,
            icdOperationOption,
            timeOutOption,
            serialWriteAddressOption,
            serialNumberSizeOption,
            serialNumberOption
        };

        // Set the handler for the command
        startOperationCommand.SetHandler((icdHandle, icdOperation, timeOut, serialWriteAddress, serialNumberSize, serialNumber) =>
        {
            try
            {
                byte[] serialNumberBytes = serialNumber != null
                    ? Encoding.UTF8.GetBytes(serialNumber)
                    : new byte[serialNumberSize];

                // Call the StartOperation method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.StartOperation(
                    icdHandle,
                    icdOperation,
                    timeOut,
                    serialWriteAddress,
                    serialNumberSize,
                    serialNumberBytes);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
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