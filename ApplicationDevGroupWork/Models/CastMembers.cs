using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApplicationDevGroupWork.Models
{
    public class CastMembers
    {
        [Key]
        public int CastMemberId { get; set; }
        public int CastDetailsId { get; set; }

        public int DVDDetailsId { get; set; }

        [ForeignKey("CastDetailsId")]

        public virtual CastDetails CastDetails { get; set; }

        [ForeignKey("DVDDetailsId")]
        public virtual DVDDetails DVDDetails { get; set; }
    }
}