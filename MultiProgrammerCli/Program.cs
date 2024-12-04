using System.CommandLine;
using MultiProgrammerCli.Commands;

namespace MultiProgrammerCli;

internal static class Program
{
    static int Main(string[] args)
    {
        // Root command for the application
        var rootCommand = new RootCommand("MultiProgrammer CLI Tool");

        rootCommand.AddCommand(StartOperationCommand.Create());
       // rootCommand.AddCommand(CreateGetConnectedIcdCommand());
        rootCommand.AddCommand(GetStringCommand.Create());

        return rootCommand.Invoke(args);
    }


    // private static Command CreateGetConnectedIcdCommand()
    // {
    //     var maxCountOption = new Option<long>("--maxCount", () => 10, "Maximum number of ICDminis to detect");
    //
    //     var getConnectedIcdCommand = new Command("GetConnectedICD", "Retrieve connected ICDmini devices")
    //     {
    //         maxCountOption
    //     };
    //
    //     getConnectedIcdCommand.SetHandler((maxCount) =>
    //     {
    //         try
    //         {
    //             var icdInfoArray = new IcdInfo[maxCount];
    //             var result = MultiProgrammer.GetConnectedICD(maxCount, out long connectedCount, icdInfoArray);
    //
    //             Console.WriteLine($"Operation Result: {result}");
    //             Console.WriteLine($"Connected ICD Count: {connectedCount}");
    //
    //             for (int i = 0; i < connectedCount; i++)
    //             {
    //                 Console.WriteLine($"ICD {i + 1}:");
    //                 Console.WriteLine($"  Handle: {icdInfoArray[i].Handle}");
    //                 Console.WriteLine($"  Type: {icdInfoArray[i].Type}");
    //                 // Add other IcdInfo properties as needed
    //             }
    //         }
    //         catch (Exception ex)
    //         {
    //             Console.Error.WriteLine($"Error: {ex.Message}");
    //         }
    //     }, maxCountOption);
    //
    //     return getConnectedIcdCommand;
    // }
}