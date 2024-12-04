using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class ReleaseTargetInfoCmd
{
    public static Command Create()
    {
        var releaseTargetInfoCommand = new Command(
            "ReleaseTargetInfo", "Model-specific information file release");

        releaseTargetInfoCommand.SetHandler(() =>
        {
            try
            {
                var returnValue = MultiProgrammer.ReleaseTargetInfo();

                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        });

        return releaseTargetInfoCommand;
    }
}