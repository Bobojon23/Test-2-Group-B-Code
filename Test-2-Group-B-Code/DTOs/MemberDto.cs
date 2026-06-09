namespace Test_2_Group_B_Code.DTOs;

public class MemberDto
{
    public string             FirstName  { get; set; } = null!;
    public string             LastName   { get; set; } = null!;
    public string             Email      { get; set; } = null!;
    public string             Phone      { get; set; } = null!;
    public List<BorrowingDto> Borrowings { get; set; } = new();

}