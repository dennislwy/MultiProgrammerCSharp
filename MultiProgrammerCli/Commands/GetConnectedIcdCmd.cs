using System.CommandLine;
using MultiProgrammerCSharp;
using MultiProgrammerCSharp.Models;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to fetch information for the ICDmini connected to the PC.
/// </summary>
public static class GetConnectedIcdCmd
{
    /// <summary>
    /// Creates the GetConnectedIcd command.
    /// </summary>
    /// <returns>The GetConnectedIcd command.</returns>
    public static Command Create()
    {
        // Define the option for the maximum number of ICDminis connected
        var maxCountOption = new Option<long>(
            aliases: new[] { "--maxCount", "-mc" },
            description: "Maximum number of ICDminis connected (Up to 10)",
            getDefaultValue: () => 10);

        // Create the command with a description
        var getConnectedIcdCommand = new Command(
            "GetConnectedIcd", "Fetches information for the ICDmini connected to the PC")
        {
            maxCountOption
        };

        // Set the handler for the command
        getConnectedIcdCommand.SetHandler((long maxCount) =>
        {
            try
            {
                // Create an array to hold the ICD information
                var icdInfoArray = new IcdInfo[maxCount];

                // Call the GetConnectedIcd method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.GetConnectedIcd(maxCount, out long connectedCount, icdInfoArray);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"Connected ICD Count: {connectedCount}");

                // Loop through the connected ICDs and output their information
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
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, maxCountOption);

        return getConnectedIcdCommand;
    }
}