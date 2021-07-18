using CommandeGQL.Models;

namespace CommanderGQL.GraphQL.Commands
{
    public class AddCommandPayload
    {
        public AddCommandPayload(Command command)
        {
            Command = command;
        }

        public Command Command { get; }
    }
}