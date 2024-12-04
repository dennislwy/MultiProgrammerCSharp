using System.CommandLine;
using MultiProgrammerCSharp;
using MultiProgrammerCSharp.Models;

namespace MultiProgrammerCli.Commands;

public static class InitializeTargetInfoCmd
{
    public static Command Create()
    {
        var targetInfoOption = new Option<TargetInfo>("--targetInfo", "Target MCU information") { IsRequired = true };
        var userInfoOption = new Option<UserInfo>("--userInfo", "User program information") { IsRequired = true };

        var initializeTargetInfoCommand = new Command(
            "InitializeTargetInfo", "Initializes target MCU information and user program")
        {
            targetInfoOption,
            userInfoOption
        };

        initializeTargetInfoCommand.SetHandler((TargetInfo targetInfo, UserInfo userInfo) =>
        {
            try
            {
                var returnValue = MultiProgrammer.InitializeTargetInfo(ref targetInfo, ref userInfo, out uint userProgramCheckSum);

                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"User Program CheckSum: {userProgramCheckSum}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, targetInfoOption, userInfoOption);

        return initializeTargetInfoCommand;
    }
}