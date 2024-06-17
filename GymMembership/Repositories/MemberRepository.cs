using System;
using GymMembership.Context;
using GymMembership.Interface;
using GymMembership.Models;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.Repositories
{
    public class MemberRepository : IRepository<int, Member>
    {
        private readonly AppDbContext _context;

        public MemberRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Member> Add(Member item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Member> Delete(int key)
        {
            var member = await Get(key);
            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
            return member;
        }

        public async Task<Member> Get(int key)
        {
            var member = await _context.Members.FindAsync(key);
            if (member == null)
                throw new NoSuchMemberException();
            return member;
        }

        public async Task<List<Member>> GetAll()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<Member> Update(Member item)
        {
            var member = await Get(item.MemberId);
            if (member != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return item;
        }
    }
}

