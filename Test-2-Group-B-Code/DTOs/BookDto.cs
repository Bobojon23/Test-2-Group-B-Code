namespace Test_2_Group_B_Code.DTOs;
public class BookDto
{
    public int       BookId        { get; set; }
    public string    Title         { get; set; } = null!;
    public string    ISBN          { get; set; } = null!;
    public int       PublishedYear { get; set; }
    public AuthorDto Author        { get; set; } = null!;
}