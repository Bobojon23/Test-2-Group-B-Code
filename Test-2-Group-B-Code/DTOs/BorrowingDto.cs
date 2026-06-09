namespace Test_2_Group_B_Code.DTOs;

public class BorrowingDto
{
    public int       BorrowingId { get; set; }
    public BookDto   Book        { get; set; } = null!;
    public DateTime  BorrowDate  { get; set; }
    public DateTime? ReturnDate  { get; set; }
    public string    Status      { get; set; } = null!;
}