using System.CommandLine;
using System.CommandLine.Invocation;
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
        var mcuNameOption = new Option<string>(
            new[] { "--mcuName", "-n" },
            "Model name")
        { IsRequired = true };

        var mcuPathOption = new Option<string>(
            new[] { "--mcuPath", "-p" },
            "Model-specific information file path")
        { IsRequired = true };

        var mcuOptionOption = new Option<string>(
            new[] { "--mcuOption", "-o" },
            "MCU model Detail option text string")
        { IsRequired = true };

        var mcuSecurityReleaseOption = new Option<int>(
            new[] { "--mcuSecurityRelease", "-sr" },
            "Flash security password unlocking (0: No, 1: Yes)")
        { IsRequired = true };

        var mcuSecurityVersionOption = new Option<string>(
            new[] { "--mcuSecurityVersion", "-sv" },
            "Flash security version (fixed at M03)")
        { IsRequired = true };

        var mcuSecurityPasswordOption = new Option<string>(
            new[] { "--mcuSecurityPassword", "-sp" },
            "Flash security password")
        { IsRequired = true };

        // Define the option for the user program information
        var userProgramVerifyOption = new Option<int>(
            new[] { "--userProgramVerify", "-pv" },
            "Verification method (0: Compare all data, 1: Compare checksum)")
        { IsRequired = true };

        var userParamCountOption = new Option<int>(
            new[] { "--userParamCount", "-pc" },
            "User program segments (The number of segments if the user program is divided into multiple address areas. Maximum 1,024)")
        { IsRequired = true };

        var userProgramParamOption = new Option<long>(
            new[] { "--userProgramParam", "-pp" },
            "User program information start pointer")
        { IsRequired = true };

        // Create the command with a description
        var initializeTargetInfoCommand = new Command(
            "InitializeTargetInfo",
            "Initializes target MCU information and user program")
        {
            mcuNameOption,
            mcuPathOption,
            mcuOptionOption,
            mcuSecurityReleaseOption,
            mcuSecurityVersionOption,
            mcuSecurityPasswordOption,
            userProgramVerifyOption,
            userParamCountOption,
            userProgramParamOption
        };

        // Set the handler for the command
        initializeTargetInfoCommand.SetHandler((InvocationContext context) =>
        {
            try
            {
                // Retrieve option values from the command context
                var mcuName = context.ParseResult.GetValueForOption(mcuNameOption);
                var mcuPath = context.ParseResult.GetValueForOption(mcuPathOption);
                var mcuOption = context.ParseResult.GetValueForOption(mcuOptionOption);
                var mcuSecurityRelease = context.ParseResult.GetValueForOption(mcuSecurityReleaseOption);
                var mcuSecurityVersion = context.ParseResult.GetValueForOption(mcuSecurityVersionOption);
                var mcuSecurityPassword = context.ParseResult.GetValueForOption(mcuSecurityPasswordOption);
                var userProgramVerify = context.ParseResult.GetValueForOption(userProgramVerifyOption);
                var userParamCount = context.ParseResult.GetValueForOption(userParamCountOption);
                var userProgramParam = context.ParseResult.GetValueForOption(userProgramParamOption);

                // Populate TargetInfo
                var targetInfo = new TargetInfo
                {
                    McuName = mcuName ?? string.Empty,
                    McuPath = mcuPath ?? string.Empty,
                    McuOption = mcuOption ?? string.Empty,
                    McuSecurityRelease = mcuSecurityRelease,
                    McuSecurityVersion = mcuSecurityVersion ?? string.Empty,
                    McuSecurityPassword = mcuSecurityPassword ?? string.Empty
                };

                // Populate UserInfo
                var userInfo = new UserInfo
                {
                    UserProgramVerify = userProgramVerify,
                    UserParamCount = userParamCount,
                    UserProgramParam = (IntPtr)userProgramParam
                };

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
        });

        return initializeTargetInfoCommand;
    }
}