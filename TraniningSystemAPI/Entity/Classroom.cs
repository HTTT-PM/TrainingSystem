using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class Classroom
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ClassroomID { get; set; }
        public string ClassroomName { get; set; }
        public string Desciption { get; set; }
        public DateTime StartDay { get; set; }
        public DateTime EndDay { get; set; }
        public virtual ICollection<ClassroomDetail> ClassroomDetails { get; set; }
    }
}
