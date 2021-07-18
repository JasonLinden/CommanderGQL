using System.Linq;
using CommandeGQL.Data;
using CommandeGQL.Models;
using HotChocolate;
using HotChocolate.Types;

namespace CommandeGQL.GraphQL.Commands
{
    public class CommandType : ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command");
            
            descriptor
                .Field(x => x.Platform)
                .ResolveWith<Resolvers>(p => p.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>();
        }

        private class Resolvers
        {
            public Platform GetPlatform(Command command, [ScopedService] AppDbContext appDbContext)
            {
                return appDbContext.Platform.FirstOrDefault(p => p.Id == command.PlatformId);
            }
        }
    }
}