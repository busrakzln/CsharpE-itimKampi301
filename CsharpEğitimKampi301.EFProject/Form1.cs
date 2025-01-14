using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpEğitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // Form'un başlangıç bileşenlerini başlatır.
        }

        // EğitimKampiEfTravelDbEntities, veritabanı ile etkileşim sağlayan Entity Framework bağlamıdır.
        EğitimKampiEfTravelDbEntities db = new EğitimKampiEfTravelDbEntities();

        // Rehber listesini getiren butonun tıklama olayı
        private void btnListele_Click(object sender, EventArgs e)
        {
            // Veritabanındaki Guide tablosundaki tüm kayıtları liste olarak alır.
            var values = db.Guide.ToList();

            // DataGridView kontrolüne verileri bağlar ve rehber listesini gösterir.
            dataGridView1.DataSource = values;
        }

        // Yeni rehber ekleyen butonun tıklama olayı
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Yeni bir rehber nesnesi oluşturulur.
            Guide guide = new Guide();

            // TextBox'lardan girilen değerler rehber nesnesine atanır.
            guide.GuideName = txtName.Text; // Adı alır.
            guide.GuideSurname = txtSurname.Text; // Soyadı alır.

            // Rehber nesnesi veritabanına eklenir.
            db.Guide.Add(guide);

            // Veritabanına yapılan değişiklikler kaydedilir.
            db.SaveChanges();

            // Kullanıcıya işlemin başarıyla gerçekleştiğini gösteren bir mesaj kutusu açılır.
            MessageBox.Show("Rehber başarıyla eklendi.");
        }

        // Rehber silen butonun tıklama olayı
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Silinecek rehberin ID'si TextBox'tan alınır ve tam sayıya dönüştürülür.
            int id = int.Parse(txtId.Text);

            // Veritabanından ID'sine göre silinecek rehber bulunur.
            var removeValues = db.Guide.Find(id);

            // Bulunan rehber veritabanından kaldırılır.
            db.Guide.Remove(removeValues);

            // Değişiklikler veritabanına kaydedilir.
            db.SaveChanges();

            // Kullanıcıya işlemin başarıyla gerçekleştiğini gösteren bir mesaj kutusu açılır.
            MessageBox.Show("Rehber başarıyla silindi.");
        }

        // Rehberi güncelleyen butonun tıklama olayı
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Güncellenecek rehberin ID'si TextBox'tan alınır ve tam sayıya dönüştürülür.
            int id = int.Parse(txtId.Text);

            // Veritabanından ID'sine göre güncellenecek rehber bulunur.
            var updateValues = db.Guide.Find(id);

            // TextBox'lardan alınan yeni bilgiler rehber nesnesine atanır.
            updateValues.GuideName = txtName.Text; // Yeni ad
            updateValues.GuideSurname = txtSurname.Text; // Yeni soyad

            // Değişiklikler veritabanına kaydedilir.
            db.SaveChanges();

            // Kullanıcıya işlemin başarıyla gerçekleştiğini gösteren bir uyarı mesaj kutusu açılır.
            MessageBox.Show("Rehber başarıyla güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ID'ye göre rehberi getiren butonun tıklama olayı
        private void btnGetbyID_Click(object sender, EventArgs e)
        {
            // Alınacak rehberin ID'si TextBox'tan alınır ve tam sayıya dönüştürülür.
            int id = int.Parse(txtId.Text);

            // Veritabanında belirtilen ID'ye sahip rehberler filtrelenir ve listeye alınır.
            var values = db.Guide.Where(x => x.GuideId == id).ToList();

            // Filtrelenen rehber bilgileri DataGridView'e bağlanarak gösterilir.
            dataGridView1.DataSource = values;
        }
    }
    /*Kodun Özeti:
    Listeleme: btnListele_Click ile tüm rehberler listelenir ve DataGridView'de gösterilir.
    Ekleme: btnAdd_Click ile rehber bilgileri formdan alınır ve veritabanına eklenir.
    Silme: btnDelete_Click ile rehber ID'si kullanılarak rehber silinir.
    Güncelleme: btnUpdate_Click ile mevcut rehber bilgileri değiştirilir.
    ID'ye Göre Getirme: btnGetbyID_Click ile belirtilen ID'ye sahip rehberler görüntülenir.
    Bu kod, Entity Framework kullanarak bir rehber tablosu üzerinde CRUD (Create, Read, Update, Delete)
    işlemleri gerçekleştirmektedir.*/
}
