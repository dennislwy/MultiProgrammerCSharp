using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to check the connection to the target system connected to the ICDmini.
/// </summary>
public static class CheckTargetConnectionCmd
{
    /// <summary>
    /// Creates the CheckTargetConnection command.
    /// </summary>
    /// <returns>The CheckTargetConnection command.</returns>
    public static Command Create()
    {
        // Define the option for the ICD handle
        var icdHandleOption = new Option<long>(new[] { "--icdHandle", "-h" }, "ICD handle") { IsRequired = true };

        // Create the command with a description
        var checkTargetConnectionCommand = new Command(
            "CheckTargetConnection", "Checks the connection to the target system connected to the ICDmini corresponding to the specified ICD handle")
        {
            icdHandleOption
        };

        // Set the handler for the command
        checkTargetConnectionCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                // Call the CheckTargetConnection method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.CheckTargetConnection(icdHandle);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return checkTargetConnectionCommand;
    }
}