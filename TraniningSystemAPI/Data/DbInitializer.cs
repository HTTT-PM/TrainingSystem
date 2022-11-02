using TraniningSystemAPI.Entity;
using System.Linq;

namespace TraniningSystemAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
        }
    }
}
