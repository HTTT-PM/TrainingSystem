using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public class Department
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string Desciption { get; set; }
        public ICollection<Trainee> Trainees { get; set; }
        public ICollection<TrainingProgram> TrainingPrograms { get; set; }
    }
}
