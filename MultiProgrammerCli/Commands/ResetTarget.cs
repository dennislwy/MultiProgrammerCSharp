using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class ResetTargetCmd
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>("--icdHandle", "ICD handle") { IsRequired = true };

        var resetTargetCommand = new Command(
            "ResetTarget", "Resets the target for the target system connected to the ICDmini corresponding to the specified ICD handle")
        {
            icdHandleOption
        };

        resetTargetCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                var returnValue = MultiProgrammer.ResetTarget(icdHandle);

                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return resetTargetCommand;
    }
}