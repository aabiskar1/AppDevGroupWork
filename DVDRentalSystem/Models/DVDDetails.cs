using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DVDRentalSystem.Models
{
    public class DVDDetails
    {
        [Key]
        public int DVDDetailsId { get; set; }
        [Required]

        public string Name { get; set; }
        public string Genre { get; set; }


        public DateTime ReleaseDate { get; set; }

        public int Length { get; set; }
        [NotMapped]

        public HttpPostedFileBase CoverImage { get; set; }

        [DisplayName("Cover Image")]
        public string CoverImagePath { get; set; }


        public virtual IEnumerable<CastDetails> CastDetails { get; set; }
    }
}