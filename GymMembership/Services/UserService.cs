using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymMembership.Interface;
using GymMembership.Models;
using GymMembership.Models.DTOs;
using GymMembership.Repositories;

namespace GymMembership.Services
{
    public class UserService:IUserService
    {
        private readonly IRepository<int, User> _repository;

        public UserService(IRepository<int, User> repository)
        {
            _repository = repository;
        }

        public Task<List<User>> GetAllUsers()
        {
            return _repository.GetAll();
        }

        public Task<User> GetUser(int id)
        {
            return _repository.Get(id);
        }

        public Task<User> AddUser(User user)
        {
            return _repository.Add(user);
        }

        public async Task<User> UpdateUser(int id, UserUpdateDto userDto)
        {
            var user = await _repository.Get(id);
            if (user == null)
            {
                throw new NoSuchUserException();
            }

            // Map DTO to entity
            if (userDto.Username != null) user.Username = userDto.Username;
            if (userDto.Email != null) user.Email = userDto.Email;
            // Map other fields as needed

            return await _repository.Update(user);
        }

        public Task<User> DeleteUser(int id)
        {
            return _repository.Delete(id);
        }

        public async Task<User> Login(LoginDto loginDto)
        {
            var user = await _repository.GetAll()
                .ContinueWith(task => task.Result.FirstOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password));

            if (user == null)
            {
                throw new NoSuchUserException("Invalid username or password.");
            }
            return user;
        }
    }
}