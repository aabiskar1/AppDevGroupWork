using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApplicationDevGroupWork.Models
{
    public class Member
    {
        public  int MemberId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int MemberCategoryId { get; set; }

        [ForeignKey("MemberCategoryId")]
        public virtual MemberCategory MemberCategory { get; set; }
        



    }
}