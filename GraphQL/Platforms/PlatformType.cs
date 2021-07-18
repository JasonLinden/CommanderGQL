using System.Linq;
using CommandeGQL.Data;
using CommandeGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommandeGQL.GraphQL.Platforms
{
    public class PlatformType : ObjectType<Platform>
    {
        protected override void Configure(IObjectTypeDescriptor<Platform> descriptor)
        {
            descriptor.Description("Represents any software or service that has a command line interface");
            descriptor.Field(x => x.LicenseKey).Description("Represents a purchased, valid license for the platform").Ignore();
            descriptor
                .Field(x => x.Commands)
                .ResolveWith<Resolvers>(p => p.GetCommands(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the list of available commands for this platform");
        }

        private class Resolvers
        {
            public IQueryable<Command> GetCommands(Platform platform, [ScopedService] AppDbContext appDbContext)
            {
                return appDbContext.Command.Where(p => p.PlatformId == platform.Id);
            }
        }
    }
}