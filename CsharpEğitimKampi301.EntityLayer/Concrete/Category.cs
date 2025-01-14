using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEğitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }

        //category sınıfını product ile ilişkisinden haberdar etmek için
        public List<Product> Products { get; set; }
    }

    /* Code First yaklaşımı içerisinde  CategoryId birinicil anahtar olduğunu ve otomatik artan olduğunu
      bildirmek  adına sınıfın adı birebir aynı yazılmalı ve sonuna Id getirilmeli.
     
     ***Field -- değişken class içerisine tanımlanıryorsa örneğin int x; bu fieldir.
     
     ***Variable -- değişken metot içerisinde tanımlanıyorsa örneğin void test() { int z;} bu variabledır.
    
     ***Property -- değişken  get; set ile tanımlanıyorsa proprertydir örneğin public int y {get; set;}
    
    get; ve set; değerleri gönderdiğimiz değeri istediğimiz formatta kullanbileceğimizi ifade eder.

    kategoriismi ile ilgili bir kısıtlama getirmek istersek;

    get;get tarafında category ismi her zaman büyük gelsin gibi

    set;set tarafında kurallar koyabiliriz category adı 5 karakterden küçükse bir uyarı göster gibi
     */
}
