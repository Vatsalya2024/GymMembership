using System;
using GymMembership.Models;
using GymMembership.Models.DTOs;

namespace GymMembership.Interface
{
	public interface IUserService
	{
        Task<List<User>> GetAllUsers();
        Task<User> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User> UpdateUser(int id, UserUpdateDto userDto);
        Task<User> DeleteUser(int id);
        Task<User> Login(LoginDto loginDto);

    }
}

