using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DataContext.Data
{
    public class DVDRentalSystemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DVDRentalSystemContext() : base("name=DVDRentalSystemContext")
        {
        }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.CastDetails> CastDetails { get; set; }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.CastMembers> CastMembers { get; set; }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.DVDDetails> DVDDetails { get; set; }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.Loan> Loans { get; set; }

        public System.Data.Entity.DbSet<DVDRentalSystem.Models.Producer> Producers { get; set; }
    }
}
