using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraniningSystemAPI.Dto
{
    public class TrainingProgramDto
    {
        public int TrainingID { get; set; }
        public string TrainingName { get; set; }
        public string JobPositionName { get; set; }
        public string DepartmentName { get; set; }
    }
}
