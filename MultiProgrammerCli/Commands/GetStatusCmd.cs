using System.CommandLine;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class GetStatusCmd
{
    public static Command Create()
    {
        var icdHandleOption = new Option<long>("--icdHandle", "ICD handle") { IsRequired = true };

        var getStatusCommand = new Command(
            "GetStatus", "Fetches the processing status for the ICDmini corresponding to the specified ICD handle")
        {
            icdHandleOption
        };

        getStatusCommand.SetHandler((long icdHandle) =>
        {
            try
            {
                var serialNumber = new byte[256];
                var returnValue = MultiProgrammer.GetStatus(icdHandle, out int serialNumberSize, serialNumber);

                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"Serial Number Size: {serialNumberSize}");
                Console.WriteLine($"Serial Number: {BitConverter.ToString(serialNumber, 0, serialNumberSize)}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, icdHandleOption);

        return getStatusCommand;
    }
}