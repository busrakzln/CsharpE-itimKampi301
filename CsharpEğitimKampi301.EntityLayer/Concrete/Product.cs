using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEğitimKampi301.EntityLayer.Concrete
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }

        //her ürünün bir kategorisi olmalı bu sınıf ile ilişkilendirmek için
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; } //kategori tablosunun değerlerine ürün üzerinden  ulaşabilmek için

        public List<Order> Orders { get; set; }
    }
}
