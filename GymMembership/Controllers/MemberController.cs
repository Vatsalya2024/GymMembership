using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GymMembership.Services;
using GymMembership.Models;
using GymMembership.Models.DTOs;

using GymMembership.Repositories;
using GymMembership.Interface;

namespace GymMembership.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        //private readonly MemberService _memberService;

        //public MemberController(MemberService memberService)
        //{
        //    _memberService = memberService;
        //}
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMembers()
        {
            var members = await _memberService.GetAllMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMember(int id)
        {
            try
            {
                var member = await _memberService.GetMember(id);
                return Ok(member);
            }
            catch (NoSuchMemberException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMember([FromBody] Member member)
        {
            var newMember = await _memberService.AddMember(member);
            return CreatedAtAction(nameof(GetMember), new { id = newMember.MemberId }, newMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, [FromBody] MemberUpdateDto memberDto)
        {
            try
            {
                var updatedMember = await _memberService.UpdateMember(id, memberDto);
                return Ok(updatedMember);
            }
            catch (NoSuchMemberException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            try
            {
                var deletedMember = await _memberService.DeleteMember(id);
                return Ok(deletedMember);
            }
            catch (NoSuchMemberException)
            {
                return NotFound();
            }
        }
    }
}