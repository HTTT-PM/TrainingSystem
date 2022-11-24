using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraniningSystemAPI.Entity
{
    public class ClassroomParticipant
    {
        public int ClassroomKey { get; set; }
        public Classroom Classroom { get; set; }
        public int TraineeKey { get; set; }
        public Trainee Trainee { get; set; }
    }
}
