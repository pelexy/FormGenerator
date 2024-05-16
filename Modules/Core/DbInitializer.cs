
using Ripple.API.Modules.Core.Implementations;
using Ripple.API.Modules.Core.Models;

namespace Ripple.API.Modules.Core
{
    public class DbInitializer
    {
        public static void Initialize(AppDbContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();




        }
    }
}
