using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to connect an ICDmini to the corresponding specified ICD handle.
/// </summary>
public static class OpenIcdConnectionCmd
{
    /// <summary>
    /// Creates the OpenIcdConnection command.
    /// </summary>
    /// <returns>The OpenIcdConnection command.</returns>
    public static Command Create()
    {
        // Define the option for the ICD handle
        var icdHandleOption = new Option<long>(
            new[] { "--icdHandle", "-h" },
            "ICD handle")
        { IsRequired = true };

        // Create the command with a description
        var openIcdConnectionCommand = new Command(
            "OpenIcdConnection",
            "Connects an ICDmini to the corresponding specified ICD handle")
        {
            icdHandleOption
        };

        // Set the handler for the command
        openIcdConnectionCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                // Call the OpenIcdConnection method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.OpenIcdConnection(icdHandle);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return openIcdConnectionCommand;
    }
}