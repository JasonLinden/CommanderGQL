using CommandeGQL.Models;

namespace CommanderGQL.GraphQL.Platforms
{
    public class AddPlatformPayload
    {
        public AddPlatformPayload(Platform platform)
        {
            this.platform = platform;
        }

        public Platform platform { get; }
    }
}