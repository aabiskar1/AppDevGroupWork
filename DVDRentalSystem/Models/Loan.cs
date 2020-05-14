using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DVDRentalSystem.Models
{
    public class Loan
    {
    
            [Key]
            public int LoanId { get; set; }

            public int DVDDetailsId { get; set; }

        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int FineAmount{ get; set; }
        public int MemberId { get; set; }

            [ForeignKey("MemberId")]
            public virtual Member Member { get; set; }

            [ForeignKey("DVDDetailsId")]
            public virtual DVDDetails DVDDetails { get; set; }
        }
    
}