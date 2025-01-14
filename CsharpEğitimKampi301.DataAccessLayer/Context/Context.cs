using CsharpEğitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEğitimKampi301.DataAccessLayer.Context
{
    public class Context:DbContext // veri tabanına yansıyacak bütün tablolar burada
    {
        //veri tabanı bağlantı adresi appconfig içerisinde
        
       
        //category : C# tarafında kullnacağımız sınıf ismi
        //categories: veri tabanına yansıyacak tablo ismi
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
