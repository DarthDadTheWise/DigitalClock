namespace Circuitry;

public class Board
{
    private readonly CommandHistory commands = new();

    public Battery Battery { get; } = new();

    public void Connect(Output output, Input input)
    {
        commands.Execute(new ConnectCommand(commands, output, input));
    }
}
