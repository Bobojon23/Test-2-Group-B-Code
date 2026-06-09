namespace LibraryApp.Entities;

public class Member
{
    public int    MemberId  { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName  { get; set; } = null!;
    public string Email     { get; set; } = null!;
    public string Phone     { get; set; } = null!;

    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
    public ICollection<Review>    Reviews    { get; set; } = new List<Review>();
}