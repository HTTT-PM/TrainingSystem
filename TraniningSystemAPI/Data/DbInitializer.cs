using TraniningSystemAPI.Entity;
using System.Linq;

namespace TraniningSystemAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();
            var Classroom = new Classroom[]
      {
 new Classroom{ ClassroomName="Lop toan",Desciption="Giao vien moi"}
      };
            foreach (Classroom d in Classroom)
            {
                context.Classroom.Add(d);
            }
            context.SaveChanges();
            // Look for any students.
        }
    }
}
