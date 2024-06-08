using System.Diagnostics;

namespace Circuitry;

[DebuggerDisplay("Connect {output} to {input}")]
internal class ConnectCommand(CommandHistory commands, Output output, Input input) : BoardCommand
{
    private readonly CommandHistory commands = commands;
    private readonly Output output = output;
    private readonly Input input = input;

    public Input Input { get { return input; } }

    internal override void Execute()
    {
        input.StateChanged += Input_StateChanged;
        output.StateChanged += Output_StateChanged;

        // Refresh input state from all connections
        input.Connect(output);
        commands.Execute(new RefreshInputCommand(input));
    }

    private void Input_StateChanged(object? sender, EventArgs e)
    {
        // Refresh the gate the owns this input
        commands.Execute(new RefreshGateCommand(input.Gate));
    }

    private void Output_StateChanged(object? sender, EventArgs e)
    {
        // When the output changes, refresh this input
        commands.Execute(new RefreshInputCommand(input));
    }
}
