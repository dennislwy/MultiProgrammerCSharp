using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class CloseIcdConnectionCmd
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>("--icdHandle", "ICD handle") { IsRequired = true };

        var closeIcdConnectionCommand = new Command(
            "CloseIcdConnection", "Disconnects an ICDmini from the corresponding specified ICD handle")
        {
            icdHandleOption
        };

        closeIcdConnectionCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                var returnValue = MultiProgrammer.CloseIcdConnection(icdHandle);

                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return closeIcdConnectionCommand;
    }
}