using System.Diagnostics;

namespace Circuitry
{
    [DebuggerDisplay("Connect {output} to {input}")]

    public class ConnectCommand(CommandHistory commands, Output output, Input input) : BoardCommand
    {
        private readonly CommandHistory commands = commands;
        private readonly Output output = output;
        private readonly Input input = input;

        public Input Input { get { return input; } }

        internal override void Execute()
        {
            input.StateChanged += OnInputStateChanged;
            output.StateChanged += OnOutputStateChanged;

            // Refresh input state from all connections
            input.Connect(output);
            commands.Execute(new RefreshInputCommand(input));
        }

        private void OnInputStateChanged(object? sender, EventArgs e)
        {
            // Refresh the gate the owns this input
            commands.Execute(new RefreshGateCommand(input.Gate));
        }

        private void OnOutputStateChanged(object? sender, EventArgs e)
        {
            // When the output changes, refresh this input
            commands.Execute(new RefreshInputCommand(input));
        }
    }
}
