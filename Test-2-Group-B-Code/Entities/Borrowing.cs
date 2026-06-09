namespace Test_2_Group_B_Code.Entities;

public class Borrowing
{
    public int       BorrowingId { get; set; }
    public int       MemberId    { get; set; }
    public int       BookId      { get; set; }
    public DateTime  BorrowDate  { get; set; }
    public DateTime? ReturnDate  { get; set; }
    public string    Status      { get; set; } = null!;

    public Member Member { get; set; } = null!;
    public Book   Book   { get; set; } = null!;
}