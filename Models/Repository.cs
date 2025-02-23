namespace LibraryManagementSystemForPatika.Models
{
    public static class Repository
    {
            private static readonly List<Book> books = new List<Book>
        {
            new Book {Id=1, Title = "1984", AuthorId=1, Genre="Dystopian Fiction", PublishDate= new DateTime(1949, 6, 8), ISBN="9780451524935", CopiesAvailable=5},
            new Book {Id=2, Title="Animal Farm", AuthorId=1, Genre="Political Satire", PublishDate=new DateTime(1945,08,17), ISBN="9780451526342", CopiesAvailable=3},
            new Book {Id=3, Title="Harry Potter and the Philosopher's Stone", AuthorId=2, Genre="Fantasy", PublishDate=new DateTime(1997,06,26), ISBN="9780747532743", CopiesAvailable=10},
            new Book {Id=4, Title="Harry Potter and the Chamber of Secrets", AuthorId=2, Genre="Fantasy", PublishDate=new DateTime(1998,07,02), ISBN="9780747538493", CopiesAvailable=8},
            new Book {Id=5, Title="Crime and Punishment", AuthorId=3, Genre="Psychological Fiction", PublishDate=new DateTime(1866,01,01), ISBN="9780140449136", CopiesAvailable=7},
            new Book {Id=6, Title="The Brothers Karamazov", AuthorId=3, Genre="Philosophical Fiction", PublishDate=new DateTime(1880,01,01), ISBN="9780374528379", CopiesAvailable=4},
            new Book {Id=7, Title="Pride and Prejudice", AuthorId=4, Genre="Romance", PublishDate=new DateTime(1813,01,28), ISBN="9780141439518", CopiesAvailable=6},
            new Book {Id=8, Title="Sense and Sensibility", AuthorId=2, Genre="Romance", PublishDate=new DateTime(1811,01,01), ISBN="9780141439662", CopiesAvailable=5},
            new Book {Id=9, Title="One Hundred Years of Solitude", AuthorId=5, Genre="Magical Realism", PublishDate=new DateTime(1967,05,30), ISBN="9780060883287", CopiesAvailable=9},
            new Book {Id=10, Title="Love in the Time of Cholera", AuthorId=2, Genre="Romance", PublishDate=new DateTime(1985,1,1), ISBN="9780307389732", CopiesAvailable=7},
            new Book {Id=11, Title="Harry Potter and the Prisoner of Azkaban", AuthorId=2, Genre="Fantasy", PublishDate=new DateTime(1999,7,8), ISBN="9780747542155", CopiesAvailable=9},
            new Book {Id=12, Title="Harry Potter and the Goblet of Fire", AuthorId=2, Genre="Fantasy", PublishDate=new DateTime(2000,7,08), ISBN="9780747546245", CopiesAvailable=8},
            new Book {Id=13, Title="Harry Potter and the Order of the Phoenix", AuthorId=2, Genre="Fantasy", PublishDate=new DateTime(2003,6,21), ISBN="9780747581086", CopiesAvailable=6},
            new Book {Id=15, Title="Harry Potter and the Deathly Hallows", AuthorId=2, Genre="Fantasy", PublishDate=new DateTime(2007,7,21), ISBN="9780545010221", CopiesAvailable=5},
        };

            private static readonly List<Author> authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "George", LastName = "Orwell", DateOfBirth = new DateTime(1903, 6, 25) },
            new Author { Id = 2, FirstName = "J.K.", LastName = "Rowling", DateOfBirth = new DateTime(1965, 7, 31) },
            new Author { Id = 3, FirstName="Fyodor", LastName = "Dostoevsky", DateOfBirth = new DateTime(1821,11,11)},
            new Author { Id = 4, FirstName="Jane", LastName = "Austen", DateOfBirth = new DateTime(1775,12,26)},
            new Author { Id = 5, FirstName="Gabriel", LastName = "García Márquez", DateOfBirth = new DateTime(1927, 3, 6)},
        };

            public static List<Author> Authors => authors;
            public static List<Book> Books => books;
        }
    }
