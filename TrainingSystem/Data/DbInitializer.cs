using BookManager.Entity;
using System.Linq;

namespace BookManager.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ModelContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Author.Any())
            {
                return; // DB has been seeded
            }
            var books = new Book[]
            {
                new Book{
                    Title="Nam Ngu",
                    Desciption="Tieng Nam Ngu hay duoc su dung",
                    Date= new System.DateTime(2001,12,30),
                    Rent=false
                },
                new Book{
                    Title="Hehe",
                    Desciption="....",
                    Date= new System.DateTime(2002,08,30),
                    Rent=false
                }
            };

            var authors = new Author[]
            {
                new Author{ 
                    Name="Wander",
                    Age= 21
                },
                new Author{
                    Name="Kygor",
                    Age= 21
                }
            };

            authors[0].Book.Add(books[0]);
            authors[0].Book.Add(books[1]);

            foreach (Author author in authors)
            {
                context.Author.Add(author);
            }
            context.SaveChanges();
        }
    }
}
