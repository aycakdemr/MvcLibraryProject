using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class Context :DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRecord> BookRecords { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<LateFee> LateFees { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writer { get; set; }
    }
}
