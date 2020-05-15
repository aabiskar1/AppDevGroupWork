using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DVDRentalSystem.Models
{
    public class DVDMember
    {
        [Key]
        public int DVDMemberId { get; set; }
        public int MemberId { get; set; }

        public int DVDDetailsId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Members { get; set; }

        [ForeignKey("DVDDetailsId")]
        public virtual DVDDetails DVDDetails { get; set; }
    }
}