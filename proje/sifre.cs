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
    public partial class sifre : Form
    {
        public sifre()
        {
            InitializeComponent();
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        private void sifre_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM kullanicilar WHERE kullanici_adi=@kullanici_adi AND sifre=@sifre AND yetki=1", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
            adapter.SelectCommand.Parameters.AddWithValue("@sifre", textBox2.Text);
            adapter.Fill(dt);
            DataTable pt = new DataTable();
            MySqlDataAdapter padapter = new MySqlDataAdapter("SELECT * FROM kullanicilar WHERE kullanici_adi=@kullanici_adi AND sifre=@sifre AND yetki=0", connection);
            padapter.SelectCommand.Parameters.AddWithValue("@kullanici_adi", textBox1.Text);
            padapter.SelectCommand.Parameters.AddWithValue("@sifre", textBox2.Text);
            padapter.Fill(pt);
            string username=textBox2.Text;

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Giriş başarılı!");
                this.Close();
                adminarayuz aa=new adminarayuz(username);
                aa.Show();
            }
            else if (pt.Rows.Count > 0)
            {
                MessageBox.Show("Giriş başarılı!");
                this.Close();
                kullaniciarayuz ka=new kullaniciarayuz(username);
                ka.Show();
            }

            else
            {
                MessageBox.Show("Giriş başarısız!\nLütfen Şifrenizi Kontrol Ediniz!");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            kayit.Show();
            this.Close();
        }
    }
}
