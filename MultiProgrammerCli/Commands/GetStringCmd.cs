using System.CommandLine;
using System.Text;
using MultiProgrammerCSharp;

namespace MultiProgrammerCli.Commands;

/// <summary>
/// Command to return a text string in response to a return code.
/// </summary>
public static class GetStringCmd
{
    /// <summary>
    /// Creates the GetString command.
    /// </summary>
    /// <returns>The GetString command.</returns>
    public static Command Create()
    {
        // Define the option for the return code
        var returnCodeOption = new Option<int>(
            new[] { "--returnCode", "-rc" },
            "Return code")
        { IsRequired = true };

        // Create the command with a description
        var getStringCommand = new Command(
            "GetString", "Returns a text string in response to a return code")
        {
            returnCodeOption
        };

        // Set the handler for the command
        getStringCommand.SetHandler((returnCode) =>
        {
            try
            {
                // Create a StringBuilder to hold the returned string
                var stringBuilder = new StringBuilder(256);

                // Call the GetString method from MultiProgrammerCSharp
                var returnValue = MultiProgrammer.GetString(returnCode, stringBuilder);

                // Output the result
                Console.WriteLine($"Return value: {returnValue}");
                Console.WriteLine($"ReturnedString: {stringBuilder}\n");

            }
            catch (Exception ex)
            {
                // Handle any exceptions and output the error message
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }, returnCodeOption);

        return getStringCommand;
    }
}