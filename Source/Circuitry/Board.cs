namespace DigitalClock.Circuitry
{
    public class Board
    {
        private readonly CommandHistory commands = new();

        public Battery Battery { get; }

        public Board()
        {
            Battery = new();
        }

        public void Connect(Output output, Input input)
        {
            commands.Execute(new ConnectCommand(commands, output, input));
        }
    }
}
