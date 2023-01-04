using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

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
        public int ContentID { get; set; }
        public ICollection<Content> Content { get; set; }
    }
}
