using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class Knowledge
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int KnowledgeID { get; set; }
        public string KnowledgeName { get; set; }
    }
}

