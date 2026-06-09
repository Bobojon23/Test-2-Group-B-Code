using Microsoft.AspNetCore.Mvc;
using Test_2_Group_B_Code.DTOs;
using Test_2_Group_B_Code.Services;

namespace LibraryApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MembersController : ControllerBase
{
    private readonly IMemberService _memberService;

    public MembersController(IMemberService memberService)
        => _memberService = memberService;
    
    [HttpGet]
    public async Task<IActionResult> GetMembers([FromQuery] string? email)
    {
        var members = await _memberService.GetMembersAsync(email);
        return Ok(members);
    }
}