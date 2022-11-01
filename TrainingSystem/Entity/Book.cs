using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Entity
{
    public partial class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Desciption { get; set; }
        public DateTime Date { get; set; }
        public bool Rent { get; set; }
        public int AuthorId { get; set; }

        public virtual Author AuthornoNavigation { get; set; }
    }
}