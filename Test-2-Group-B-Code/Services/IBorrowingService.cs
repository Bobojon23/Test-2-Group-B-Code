using Test_2_Group_B_Code.DTOs;

namespace Test_2_Group_B_Code.Services;

public interface IBorrowingService
{
    Task<(bool success, string message)> ReturnBorrowingAsync(
        int borrowingId, ReturnBorrowingDto dto);
}