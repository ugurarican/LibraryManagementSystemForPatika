namespace LibraryManagementSystemForPatika.Models
{
    public class AuthorListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FullName { get; set; }
        public int BookCount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
