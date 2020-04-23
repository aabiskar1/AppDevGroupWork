using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ApplicationDevGroupWork.Models
{
    public class Loan
    {
        [Key]
        public int LoanId { get; set; }

        public int DVDDetailsId { get; set; }

        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member{ get; set; }

        [ForeignKey("DVDDetailsId")]
        public virtual DVDDetails DVDDetails{ get; set; }
    }
}