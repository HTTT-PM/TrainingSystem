using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public class Content
    {
        public Content()
        {
            Documents = new HashSet<Document>();
            Exercises = new HashSet<Exercise>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContentID { get; set; }
        public string ContentName { get; set; }
        public string Description { get; set; }
        public int TrainingTime { get; set; }
        public int CourseID { get; set; }
        public ICollection<Course> Course { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
