using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proje
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        private void kayit_Load(object sender, EventArgs e)
        {

        }
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        DataTable dt = new DataTable();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO kullanicilar (kullanici_adi,tc,dogum_tarihi,mail_adresi,sifre,yetki,ad_soyad) VALUES " +
                "(@kullanici_adi,@tc,@dogum_tarihi,@mail_adresi,@sifre,@yetki,@ad_soyad)";
            cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@kullanici_adi", textBox4.Text);
            cmd.Parameters.AddWithValue("@tc", textBox2.Text);
            cmd.Parameters.AddWithValue("@dogum_tarihi", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@mail_adresi", textBox3.Text);
            cmd.Parameters.AddWithValue("@ad_soyad", textBox1.Text);
            cmd.Parameters.AddWithValue("@sifre", textBox5.Text);
            cmd.Parameters.AddWithValue("@yetki", 0);
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Kayıt işlemi gerçekleştirilmez
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Kayıt Başarıyla Oluşturuldu");
            giris giris=new giris();
            giris.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Close();
        }
    }
}
