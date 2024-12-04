using System.CommandLine;
using MultiProgrammerCSharp;
using MultiProgrammerCSharp.Models;

namespace MultiProgrammerCli.Commands;

public static class GetConnectedIcdCmd
{
    public static Command Create()
    {
        var maxCountOption = new Option<long>(
            aliases: new[] { "--maxCount", "-mc" },
            description: "Maximum number of ICDminis connected (Up to 10)",
            getDefaultValue: () => 10);

        var getConnectedIcdCommand = new Command(
            "GetConnectedIcd", "Fetches information for the ICDmini connected to the PC")
        {
            maxCountOption
        };

        getConnectedIcdCommand.SetHandler((long maxCount) =>
        {
            try
            {
                var icdInfoArray = new IcdInfo[maxCount];
                var returnValue = MultiProgrammer.GetConnectedIcd(maxCount, out long connectedCount, icdInfoArray);

                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"Connected ICD Count: {connectedCount}");

                for (var i = 0; i < connectedCount; i++)
                {
                    Console.WriteLine($"ICD {i + 1}:");
                    Console.WriteLine($"  Handle: {icdInfoArray[i].IcdHandle}");
                    Console.WriteLine($"  DLL version: {icdInfoArray[i].IcdVersion}");
                    Console.WriteLine($"  Version: {icdInfoArray[i].IcdVersion}");
                    Console.WriteLine($"  SerialNumber: {icdInfoArray[i].IcdSerialNumber}");
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, maxCountOption);

        return getConnectedIcdCommand;
    }
}