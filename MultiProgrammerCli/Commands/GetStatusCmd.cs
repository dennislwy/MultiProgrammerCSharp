using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to fetch the processing status for the ICDmini corresponding to the specified ICD handle.
/// </summary>
public static class GetStatusCmd
{
    /// <summary>
    /// Creates the GetStatus command.
    /// </summary>
    /// <returns>The GetStatus command.</returns>
    public static Command Create()
    {
        // Define the option for the ICD handle
        var icdHandleOption = new Option<long>(
            new[] { "--icdHandle", "-h" },
            "ICD handle")
        { IsRequired = true };

        // Create the command with a description
        var getStatusCommand = new Command(
            "GetStatus", "Fetches the processing status for the ICDmini corresponding to the specified ICD handle")
        {
            icdHandleOption
        };

        // Set the handler for the command
        getStatusCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                // Create a buffer to hold the serial number
                var serialNumber = new byte[256];

                // Call the GetStatus method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.GetStatus(icdHandle, out int serialNumberSize, serialNumber);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"Serial Number Size: {serialNumberSize}");
                Console.WriteLine($"Serial Number: {BitConverter.ToString(serialNumber, 0, serialNumberSize)}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return getStatusCommand;
    }
}