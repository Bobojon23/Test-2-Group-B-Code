using Microsoft.AspNetCore.Mvc;
using Test_2_Group_B_Code.DTOs;
using Test_2_Group_B_Code.Services;

namespace Test_2_Group_B_Code.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowingsController : ControllerBase
{
    private readonly IBorrowingService _borrowingService;

    public BorrowingsController(IBorrowingService borrowingService)
        => _borrowingService = borrowingService;

   [HttpPut("{id}/return")]
    public async Task<IActionResult> ReturnBorrowing(
        int id, [FromBody] ReturnBorrowingDto dto)
    {
        var (success, message) = await _borrowingService.ReturnBorrowingAsync(id, dto);

        if (!success)
        {
            if (message == "Borrowing not found.")
                return NotFound(message);

            return BadRequest(message);
        }

        return NoContent();
    }
}
