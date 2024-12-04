using System.CommandLine;
using MultiProgrammerCSharp;
using MultiProgrammerCSharp.Models;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to initialize target MCU information and user program.
/// </summary>
public static class InitializeTargetInfoCmd
{
    /// <summary>
    /// Creates the InitializeTargetInfo command.
    /// </summary>
    /// <returns>The InitializeTargetInfo command.</returns>
    public static Command Create()
    {
        // Define the option for the target MCU information
        var targetInfoOption = new Option<TargetInfo>(
            "--targetInfo",
            "Target MCU information")
        { IsRequired = true };

        // Define the option for the user program information
        var userInfoOption = new Option<UserInfo>(
            "--userInfo",
            "User program information")
        { IsRequired = true };

        // Create the command with a description
        var initializeTargetInfoCommand = new Command(
            "InitializeTargetInfo",
            "Initializes target MCU information and user program")
        {
            targetInfoOption,
            userInfoOption
        };

        // Set the handler for the command
        initializeTargetInfoCommand.SetHandler((TargetInfo targetInfo, UserInfo userInfo) =>
        {
            try
            {
                // Call the InitializeTargetInfo method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.InitializeTargetInfo(ref targetInfo, ref userInfo, out uint userProgramCheckSum);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"User Program CheckSum: {userProgramCheckSum}");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, targetInfoOption, userInfoOption);

        return initializeTargetInfoCommand;
    }
}