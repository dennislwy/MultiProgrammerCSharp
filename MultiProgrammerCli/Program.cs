using System.CommandLine;
using MultiProgrammerCli.Commands;

namespace MultiProgrammerCli;

internal static class Program
{
    static int Main(string[] args)
    {
        var rootCommand = new RootCommand("MultiProgrammer CLI Tool");

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

        return rootCommand.Invoke(args);
    }
}