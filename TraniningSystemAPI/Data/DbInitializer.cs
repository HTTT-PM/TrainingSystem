namespace TraniningSystemAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}   