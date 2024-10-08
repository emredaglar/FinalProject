using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    //Context:Db tabloları ile proje classlarını bağlamak
    //DbContext Ef ile gelen bir sınıftır.
    public class NorthwindContext:DbContext
    {

        //seni projen hangi veritabanıyla ilişkiliyi  belirteceğimiz kısım. override on- tab
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string @ ters slaş olarak algılar
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Northwind;Trusted_Connection=true");
        }
        //Hnagi verim hangi veriye karşılık gelcek. Bağlama yapacağız yani.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
