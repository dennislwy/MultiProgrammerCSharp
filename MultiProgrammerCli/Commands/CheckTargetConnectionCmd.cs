using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class CheckTargetConnectionCmd
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>("--icdHandle", "ICD handle") { IsRequired = true };

        var checkTargetConnectionCommand = new Command(
            "CheckTargetConnection", "Checks the connection to the target system connected to the ICDmini corresponding to the specified ICD handle")
        {
            icdHandleOption
        };

        checkTargetConnectionCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                var returnValue = MultiProgrammer.CheckTargetConnection(icdHandle);

                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return checkTargetConnectionCommand;
    }
}