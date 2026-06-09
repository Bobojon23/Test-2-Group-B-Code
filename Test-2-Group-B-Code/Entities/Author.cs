namespace Test_2_Group_B_Code.Entities;

public class Author
{
    public int AuthorId { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName  { get; set; } = null!;
    public string Country   { get; set; } = null!;
    public int    BirthYear { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}