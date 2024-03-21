using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class BookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=LAPTOP-841VLQD0;Database=BookStore;Trusted_Connection=True;TrustServerCertificate=True");

        }

        //Hangi nesnem hangisine karsilik geliyor onu belirtiyoruz.
        public DbSet<Book> Books { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Premium> Premiums { get; set; }
        public DbSet<Regular> Regular { get; set; }










    }
}
