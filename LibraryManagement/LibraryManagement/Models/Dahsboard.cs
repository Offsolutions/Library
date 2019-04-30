using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryManagement.Models
{
    public class Dahsboard
    {
        dbcontext db = new dbcontext();
        public static DateTime date = System.DateTime.Now;
        public int TotalBooks
        {
            get
            {
                return db.Books.Sum(x => x.BookCopies);
            }
        }
        public int IssueBook
        {
            get
            {
                return db.IssueBooks.Where(x=>x.Status=="Issue").Count();
            }
        }
        public int TodayMember
        {
            get
            {
                return db.Memberships.Count();
            }
        }
        public List<IssueBook> Today
        {
            get
            {
                return db.IssueBooks.Where(x => x.LastDate<= date).ToList();
            }
        }
    }
    
}