using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationDevGroupWork.Models
{
    public class CastDetails
    {

        [Key]
        public int CastDetailsId { get; set; }
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public String Gender { get; set; }
    }
}