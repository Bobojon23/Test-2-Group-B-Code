using Test_2_Group_B_Code.DTOs;

namespace Test_2_Group_B_Code.Services;

public interface IMemberService
{
    Task<IEnumerable<MemberDto>> GetMembersAsync(string? email);
}