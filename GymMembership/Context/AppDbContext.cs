using System;
using GymMembership.Models;
using Microsoft.EntityFrameworkCore;

namespace GymMembership.Context
{
	public class AppDbContext:DbContext
	{
        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    }
}

