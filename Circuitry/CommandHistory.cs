namespace Circuitry
{
    public class CommandHistory
    {
        private readonly LinkedList<BoardCommand> commands = new();
        private LinkedListNode<BoardCommand>? current;

        internal void Execute(BoardCommand command)
        {
            commands.AddLast(command);
            if (current == null)
            {
                current = commands.Last;
                while (current != null)
                {
                    current.Value.Execute();
                    current = current.Next;
                }
            }
        }
    }
}
