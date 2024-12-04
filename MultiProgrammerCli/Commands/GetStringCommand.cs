using System.CommandLine;
using System.Text;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class GetStringCommand
{
    public static Command Create()
    {
        var returnCodeOption = new Option<int>(new[] { "--returnCode", "--rc" }, "Return code to get string description for") { IsRequired = true };

        var getStringCommand = new Command("GetString", "Get description for a return code")
        {
            returnCodeOption
        };

        getStringCommand.SetHandler((returnCode) =>
        {
            try
            {
                var stringBuilder = new StringBuilder(256);
                var result = MultiProgrammer.GetString(returnCode, stringBuilder);

                Console.WriteLine($"Operation Result: {result}");
                Console.WriteLine($"Description: {stringBuilder}");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, returnCodeOption);

        return getStringCommand;
    }
}