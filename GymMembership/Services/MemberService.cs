using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymMembership.Interface;
using GymMembership.Models;
using GymMembership.Models.DTOs;
using GymMembership.Repositories;

namespace GymMembership.Services
{
    public class MemberService : IMemberService
    {
        private readonly IRepository<int, Member> _repository;

        public MemberService(IRepository<int, Member> repository)
        {
            _repository = repository;
        }

        public Task<List<Member>> GetAllMembers()
        {
            return _repository.GetAll();
        }

        public Task<Member> GetMember(int id)
        {
            return _repository.Get(id);
        }

        public Task<Member> AddMember(Member member)
        {
            return _repository.Add(member);
        }

        public async Task<Member> UpdateMember(int id, MemberUpdateDto memberDto)
        {
            var member = await _repository.Get(id);
            if (member == null)
            {
                throw new NoSuchMemberException();
            }

            // Map DTO to entity
            if (memberDto.Name != null) member.Name = memberDto.Name;
            if (memberDto.Email != null) member.Phone = memberDto.Email;
            if (memberDto.Phone != null) member.Phone = memberDto.Phone;
            if (memberDto.MembershipExpiry.HasValue) member.MembershipExpiry = memberDto.MembershipExpiry.Value;
            if (memberDto.DOJ.HasValue) member.DateOfJoining = memberDto.DOJ.Value;

            return await _repository.Update(member);
        }

        public Task<Member> DeleteMember(int id)
        {
            return _repository.Delete(id);
        }
    }
}