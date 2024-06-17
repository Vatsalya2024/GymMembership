using System;
using GymMembership.Context;
using GymMembership.Interface;
using GymMembership.Models;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<User> Delete(int key)
        {
            var user = await Get(key);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<User> Get(int key)
        {
            var user = await _context.Users.FindAsync(key);
            if (user == null)
                throw new NoSuchUserException();
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Update(User item)
        {
            var user = await Get(item.UserId);
            if (user != null)
            {
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            return item;
        }
    }
}