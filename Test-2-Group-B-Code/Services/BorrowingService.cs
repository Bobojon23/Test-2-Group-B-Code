using Microsoft.EntityFrameworkCore;
using Test_2_Group_B_Code.Data;
using Test_2_Group_B_Code.DTOs;

namespace Test_2_Group_B_Code.Services;

public class BorrowingService : IBorrowingService
{
    private readonly AppDbContext _db;
    public BorrowingService(AppDbContext db) => _db = db;

    public async Task<(bool success, string message)> ReturnBorrowingAsync(
        int borrowingId, ReturnBorrowingDto dto)
    {
        await using var transaction = await _db.Database.BeginTransactionAsync();
        try
        {
            var borrowing = await _db.Borrowings.FindAsync(borrowingId);
            if (borrowing is null)
                return (false, "Borrowing not found.");

            if (borrowing.Status == "Returned")
                return (false, "Borrowing has already been returned.");

            if (dto.ReturnDate < borrowing.BorrowDate)
                return (false, "Return date cannot be earlier than borrow date.");
            borrowing.ReturnDate = dto.ReturnDate;
            borrowing.Status     = "Returned";

            await _db.SaveChangesAsync();
            await transaction.CommitAsync();
            return (true, string.Empty);
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}
