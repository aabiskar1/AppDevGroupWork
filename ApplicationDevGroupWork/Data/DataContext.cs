using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ApplicationDevGroupWork.Data
{
    public class DataContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DataContext() : base("name=DataContext")
        {
        }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.CastDetails> CastDetails { get; set; }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.CastMembers> CastMembers { get; set; }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.DVDDetails> DVDDetails { get; set; }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.MemberCategory> MemberCategories { get; set; }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.Loan> Loans { get; set; }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.Member> Members { get; set; }

        public System.Data.Entity.DbSet<ApplicationDevGroupWork.Models.Producer> Producers { get; set; }
    }
}
