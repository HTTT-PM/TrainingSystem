#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraniningSystemAPI.Entity
{
    public partial class Notify
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
        
        [ForeignKey("ReciveId")]
        public int? ReciveId { get; set; }
        public Account Recive { get; set; }
        
        [ForeignKey("ConfirmId")]
        public int? ConfirmId { get; set; }
        public Account Confirm { get; set; }
        
        
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        
    }
}
