using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymMembership.Models
{
	public class Member
	{
        //public int MemberId { get; set; }
        //public string Name { get; set; }
        //public string Email { get; set; }
        //public string Phone { get; set; }
        //public DateTime MembershipExpiry { get; set; }
        //public DateTime DOJ { get; set; }
        [Key]
        public int MemberId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime? MembershipExpiry { get; set; } = DateTime.Now.AddMonths(6);
        public DateTime? DateOfJoining { get; set; } = DateTime.Now;
        public int UserID { get; set; }
        [ForeignKey("UserID")]
        public User? User { get; set; }

        public Member()
        {
        }

        public Member(int memberId, string name, string phone, DateTime membershipExpiry, DateTime dateOfJoining, int userID)
        {
            MemberId = memberId;
            Name = name;
            Phone = phone;
            MembershipExpiry = membershipExpiry;
            DateOfJoining = dateOfJoining;
            UserID = userID;
        }
    }
}

