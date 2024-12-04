using System.CommandLine;
using MultiProgrammerCli.Commands;

namespace MultiProgrammerCli;

/// <summary>
/// The main entry point for the MultiProgrammer CLI Tool.
/// </summary>
internal static class Program
{
    /// <summary>
    /// The main method that sets up and runs the CLI tool.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    /// <returns>The exit code of the application.</returns>
    static int Main(string[] args)
    {
        // Create the root command with a description
        var rootCommand = new RootCommand("MultiProgrammer CLI Tool");

        // Add subcommands to the root command
        rootCommand.AddCommand(InitializeTargetInfoCmd.Create());
        rootCommand.AddCommand(ReleaseTargetInfoCmd.Create());
        rootCommand.AddCommand(OpenIcdConnectionCmd.Create());
        rootCommand.AddCommand(CloseIcdConnectionCmd.Create());
        rootCommand.AddCommand(ResetTargetCmd.Create());
        rootCommand.AddCommand(CheckTargetConnectionCmd.Create());
        rootCommand.AddCommand(StartOperationCmd.Create());
        rootCommand.AddCommand(GetStatusCmd.Create());
        rootCommand.AddCommand(GetStringCmd.Create());
        rootCommand.AddCommand(GetConnectedIcdCmd.Create());

#if DEBUG
        args = new[] { "GetString", "-rc", "0" };
#endif

        // Invoke the command-line parser and execute the appropriate command
        return rootCommand.Invoke(args);
    }
}