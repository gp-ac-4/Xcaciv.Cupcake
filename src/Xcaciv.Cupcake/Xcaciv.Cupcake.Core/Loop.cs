using Xcaciv.Command.Interface;

namespace Xcaciv.Cupcake.Core;

public class Loop
{
    public string Prompt { get; set; } = "Ɛ> ";
    public List<string> ExitCommands { get; set; } = new List<string>() { "END", "EXIT", "BYEE" };
    public async Task Run(IOutputMessageContext output, Func<string, string> inputFunc)
    {
        await output.SetStatusMessage("Running");
        await Task.Run(() => {
            var command = "RUN";
            while (!this.ExitCommands.Contains(command, StringComparer.OrdinalIgnoreCase))
            {
                command = inputFunc(this.Prompt);
                // TODO: Send command to Command.Manager
                // TODO: support NuGet style directory structure
                // TODO: figure out how to handle non existing commands: download, compile
            }
        });
        await output.SetStatusMessage("Done");
    }
}
