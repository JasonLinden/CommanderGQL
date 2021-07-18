using System.Threading;
using System.Threading.Tasks;
using CommandeGQL.Data;
using CommandeGQL.GraphQL.Platforms;
using CommandeGQL.Models;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;

namespace CommanderGQP.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddPlatformPayload> AddPlatformAsync(
            AddPlatformInput input,
            [ScopedService] AppDbContext appDbContext,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var platform = new Platform()
            {
                Name = input.Name
            };

            appDbContext.Platform.Add(platform);
            await appDbContext.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdded), platform, cancellationToken);

            return new AddPlatformPayload(platform);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<AddCommandPayload> AddCommandAsync(AddCommandInput input,
            [ScopedService] AppDbContext appDbContext)
        {
            var command = new Command()
            {
                PlatformId = input.PlatformId,
                CommandLine = input.Commandline,
                HowTo = input.HowTo
            };

            appDbContext.Command.Add(command);
            await appDbContext.SaveChangesAsync();

            return new AddCommandPayload(command);
        }
    }
}