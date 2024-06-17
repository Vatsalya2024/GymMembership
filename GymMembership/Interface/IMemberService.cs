using System;
using GymMembership.Models;
using GymMembership.Models.DTOs;

namespace GymMembership.Interface
{
	public interface IMemberService
	{
        Task<List<Member>> GetAllMembers();
        Task<Member> GetMember(int id);
        Task<Member> AddMember(Member member);
        Task<Member> UpdateMember(int id, MemberUpdateDto memberDto);
        Task<Member> DeleteMember(int id);

    }
}

