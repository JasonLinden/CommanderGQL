using System.Linq;
using CommandeGQL.Data;
using CommandeGQL.Models;
using HotChocolate;
using HotChocolate.Data;

namespace CommanderGQP.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platform;
        }

        [UseDbContext(typeof(AppDbContext))]
        // [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Command;
        }
    }
}