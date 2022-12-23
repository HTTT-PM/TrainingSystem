using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DocumentID { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public int CourseID { get; set; }
        public ICollection<Course> Course { get; set; }
    }
}
