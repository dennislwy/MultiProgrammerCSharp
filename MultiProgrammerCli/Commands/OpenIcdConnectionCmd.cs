using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class OpenIcdConnectionCmd
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>("--icdHandle", "ICD handle") { IsRequired = true };

        var openIcdConnectionCommand = new Command(
            "OpenIcdConnection", "Connects an ICDmini to the corresponding specified ICD handle")
        {
            icdHandleOption
        };

        openIcdConnectionCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                var returnValue = MultiProgrammer.OpenIcdConnection(icdHandle);

                Console.WriteLine($"Return value: {returnValue}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return openIcdConnectionCommand;
    }
}