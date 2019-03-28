using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace LibraryManagement.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext() : base("dbcontext")
        {
            //Database.SetInitializer<dbcontext>(new CreateDatabaseIfNotExists<dbcontext>());

          //  Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbcontext, MvcFeeManage.Migrations.Configuration>("dbcontext"));
        }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Publisher> Publishers { get; set; }
    }
}