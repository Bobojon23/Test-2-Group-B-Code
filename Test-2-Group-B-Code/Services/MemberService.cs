using Microsoft.EntityFrameworkCore;
using Test_2_Group_B_Code.Data;
using Test_2_Group_B_Code.DTOs;

namespace Test_2_Group_B_Code.Services;

public class MemberService : IMemberService
{
    private readonly AppDbContext _db;
    public MemberService(AppDbContext db) => _db = db;

    public async Task<IEnumerable<MemberDto>> GetMembersAsync(string? email)
    {
        var query = _db.Members
            .Include(m => m.Borrowings)
            .ThenInclude(b => b.Book)
            .ThenInclude(bk => bk.Author)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(email))
            query = query.Where(m => m.Email.Contains(email));

        var members = await query.ToListAsync();

        return members.Select(m => new MemberDto
        {
            FirstName  = m.FirstName,
            LastName   = m.LastName,
            Email      = m.Email,
            Phone      = m.Phone,
            Borrowings = m.Borrowings.Select(b => new BorrowingDto
            {
                BorrowingId = b.BorrowingId,
                BorrowDate  = b.BorrowDate,
                ReturnDate  = b.ReturnDate,
                Status      = b.Status,
                Book = new BookDto
                {
                    BookId        = b.Book.BookId,
                    Title         = b.Book.Title,
                    ISBN          = b.Book.ISBN,
                    PublishedYear = b.Book.PublishedYear,
                    Author = new AuthorDto
                    {
                        FirstName = b.Book.Author.FirstName,
                        LastName  = b.Book.Author.LastName,
                        Country   = b.Book.Author.Country
                    }
                }
            }).ToList()
        });
    }
}