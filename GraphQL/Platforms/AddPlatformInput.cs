namespace CommandeGQL.GraphQL.Platforms
{
    public class AddPlatformInput
    {
        public AddPlatformInput(string Name)
        {
            this.Name = Name;
        }

        public string Name { get; }
    }
}