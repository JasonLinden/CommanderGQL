using CommandeGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommanderGQP.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdded([EventMessage] Platform platform) => platform;
    }
}