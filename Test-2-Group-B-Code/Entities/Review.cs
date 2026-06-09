namespace Test_2_Group_B_Code.Entities;

public class Review
{
    public int      MemberId   { get; set; }
    public int      BookId     { get; set; }
    public int      Rating     { get; set; }
    public string   Comment    { get; set; } = null!;
    public DateTime ReviewDate { get; set; }

    public Member Member { get; set; } = null!;
    public Book   Book   { get; set; } = null!;
}