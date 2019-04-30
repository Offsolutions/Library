using System.Data.Entity;
namespace LibraryManagement.Models
{
    public class dbcontext:DbContext
    {
        public dbcontext() : base("dbcontext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<dbcontext,LibraryManagement.Migrations.Configuration>("dbcontext"));
           // Database.SetInitializer<dbcontext>(new MigrateDatabaseToLatestVersion<dbcontext, LibraryManagement.Migrations.Configuration>("dbcontext"));
        }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Publisher> Publishers { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Books> Books { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Department> Departments { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Batch> Batches { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Membership> Memberships { get; set; }
        public System.Data.Entity.DbSet<LibraryManagement.Models.IssueBook> IssueBooks { get; set; }

        public System.Data.Entity.DbSet<LibraryManagement.Models.Setting> Settings { get; set; }
    }
}