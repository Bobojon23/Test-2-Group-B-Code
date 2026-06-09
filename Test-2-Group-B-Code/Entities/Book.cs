namespace Test_2_Group_B_Code.Entities;

public class Book
{
    public int    BookId        { get; set; }
    public string Title         { get; set; } = null!;
    public string ISBN          { get; set; } = null!;
    public int    PublishedYear { get; set; }
    public int    AuthorId      { get; set; }

    public Author              Author    { get; set; } = null!;
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Review>    Reviews    { get; set; } = new List<Review>();
}