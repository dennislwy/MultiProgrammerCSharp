using System.CommandLine;
using System.Text;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

public static class GetStringCmd
{
    public static Command Create()
    {
        var returnCodeOption = new Option<int>(new[] { "--returnCode", "--rc" }, "Return code") { IsRequired = true };

        var getStringCommand = new Command(
            "GetString", "Returns a text string in response to a return code")
        {
            returnCodeOption
        };

        getStringCommand.SetHandler((returnCode) =>
        {
            try
            {
                var stringBuilder = new StringBuilder();
                var returnValue = MultiProgrammer.GetString(returnCode, stringBuilder);

                Console.WriteLine($"Return value: {returnValue}\n");
                Console.WriteLine($"ReturnedString: {stringBuilder}");

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, returnCodeOption);

        return getStringCommand;
    }
}