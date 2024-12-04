using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to release model-specific information file.
/// </summary>
public static class ReleaseTargetInfoCmd
{
    /// <summary>
    /// Creates the ReleaseTargetInfo command.
    /// </summary>
    /// <returns>The ReleaseTargetInfo command.</returns>
    public static Command Create()
    {
        // Create the command with a description
        var releaseTargetInfoCommand = new Command(
            "ReleaseTargetInfo", "Model-specific information file release");

        // Set the handler for the command
        releaseTargetInfoCommand.SetHandler(() =>
        {
            try
            {
                // Call the ReleaseTargetInfo method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.ReleaseTargetInfo();

                // Output the result
                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        });

        return releaseTargetInfoCommand;
    }
}