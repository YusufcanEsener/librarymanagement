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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void giris_Load(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();//this.close yapınca arkada çalışmaya devam ediyor bu yüzden application exit yapıyoruz
        }
        MySqlConnection connection = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        private void button3_Click_1(object sender, EventArgs e)
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
            string username = textBox1.Text;

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Giriş başarılı!");
                this.Hide();
                adminarayuz aa = new adminarayuz(string.Empty);
                aa.Show();
            }
            else if (pt.Rows.Count > 0)
            {
                MessageBox.Show("Giriş başarılı!");
                this.Hide();
                kullaniciarayuz ka = new kullaniciarayuz(username);
                ka.Show();
            }

            else
            {
                MessageBox.Show("Lütfen Şifrenizi Kontrol Ediniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

                kayit kayit = new kayit();
                kayit.Show();
                this.Hide();
            
        }
    
    }
}
