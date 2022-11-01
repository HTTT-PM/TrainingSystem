using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManager.Entity
{
    public partial class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Book> Book { get; set; }
    }
}
