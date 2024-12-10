using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to disconnect an ICDmini from the corresponding specified ICD handle.
/// </summary>
public static class CloseIcdConnectionCmd
{
    /// <summary>
    /// Creates the CloseIcdConnection command.
    /// </summary>
    /// <returns>The CloseIcdConnection command.</returns>
    public static Command Create()
    {
        // Define the option for the ICD handle
        var icdHandleOption = new Option<long>(
            new[] { "--icdHandle", "-h" },
            "ICD handle")
        { IsRequired = true };

        // Create the command with a description
        var closeIcdConnectionCommand = new Command(
            "CloseIcdConnection", "Disconnects an ICDmini from the corresponding specified ICD handle")
        {
            icdHandleOption
        };

        // Set the handler for the command
        closeIcdConnectionCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                // Call the CloseIcdConnection method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.CloseIcdConnection(icdHandle);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return closeIcdConnectionCommand;
    }
}