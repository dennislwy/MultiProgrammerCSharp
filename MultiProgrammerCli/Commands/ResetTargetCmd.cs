using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to reset the target for the target system connected to the ICDmini corresponding to the specified ICD handle.
/// </summary>
public static class ResetTargetCmd
{
    /// <summary>
    /// Creates the ResetTarget command.
    /// </summary>
    /// <returns>The ResetTarget command.</returns>
    public static Command Create()
    {
        // Define the option for the ICD handle
        var icdHandleOption = new Option<long>(
            new[] { "--icdHandle", "-h" },
            "ICD handle")
        { IsRequired = true };

        // Create the command with a description
        var resetTargetCommand = new Command(
            "ResetTarget",
            "Resets the target for the target system connected to the ICDmini corresponding to the specified ICD handle")
        {
            icdHandleOption
        };

        // Set the handler for the command
        resetTargetCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                // Call the ResetTarget method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.ResetTarget(icdHandle);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return resetTargetCommand;
    }
}