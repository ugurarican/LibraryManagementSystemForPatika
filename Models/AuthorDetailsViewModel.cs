namespace LibraryManagementSystemForPatika.Models
{
    public class AuthorDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth {  get; set; }
        public int BookCount { get; set; }
        public List<Book> Books { get; set; }
    }
}
