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
            var know = new Knowledge[]
            {
 new Knowledge{KnowledgeName="Java" },
 new Knowledge{KnowledgeName="C" }
            };
            var skill = new Skill[]
            {
 new Skill{SkillName="Testing" },
 new Skill{SkillName="Coding" }
            };
            var train = new TrainingProgram[]
           {
 new TrainingProgram{ TrainingName="Lap Trinh"}
           };
            train[0].Knowledge.Add(know[0]);
            train[0].Knowledge.Add(know[1]);
            train[0].Skill.Add(skill[0]);
            train[0].Skill.Add(skill[1]);
            foreach (TrainingProgram tra in train)
            {
                context.TrainingProgram.Add(tra);
            }
            context.SaveChanges();

        }

    }
}