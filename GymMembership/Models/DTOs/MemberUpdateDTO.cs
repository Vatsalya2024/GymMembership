using System;
namespace GymMembership.Models.DTOs
{
    public class MemberUpdateDto
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? MembershipExpiry { get; set; }
        public DateTime? DOJ { get; set; }
    }
}

