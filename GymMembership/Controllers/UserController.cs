using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymMembership.Services;
using GymMembership.Models;
using GymMembership.Models.DTOs;
using GymMembership.Interface;
using GymMembership.Repositories;

namespace GymMembership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            try
            {
                var user = await _userService.GetUser(id);
                return Ok(user);
            }
            catch (NoSuchUserException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            var newUser = await _userService.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto userDto)
        {
            try
            {
                var updatedUser = await _userService.UpdateUser(id, userDto);
                return Ok(updatedUser);
            }
            catch (NoSuchUserException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var deletedUser = await _userService.DeleteUser(id);
                return Ok(deletedUser);
            }
            catch (NoSuchUserException)
            {
                return NotFound();
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _userService.Login(loginDto);
                return Ok(user);
            }
            catch (NoSuchUserException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}