using System;
using System.ComponentModel.DataAnnotations;

namespace GymMembership.Models
{
	public class User
	{
        //public int UserId { get; set; }
        //public string Username { get; set; }
        //public string Password { get; set; }
        //public string Email { get; set; }
        //public bool IsAdmin { get; set; }

        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }

        public User()
        {
        }

        public User(int userId, string username, string password, string email, bool isAdmin)
        {
            UserId = userId;
            Username = username;
            Password = password;
            Email = email;
            this.isAdmin = isAdmin;
        }

    }
}

