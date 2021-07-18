namespace CommanderGQL.GraphQL.Commands
{
    public class AddCommandInput
    {
        public AddCommandInput(string howTo, string commandline, int platformId)
        {
            HowTo = howTo;
            Commandline = commandline;
            PlatformId = platformId;
        }

        public string HowTo { get; }
        public string Commandline { get; }
        public int PlatformId { get; }
    }
}