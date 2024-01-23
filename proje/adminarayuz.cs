using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace proje
{
    public partial class adminarayuz : Form
    {
        MySqlConnection conn=new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        MySqlCommand cmd;
        MySqlCommand otocmd;
        MySqlCommand sorgu;
        MySqlDataAdapter adapter;
        DataTable dt;
        private string username;
        public adminarayuz(string username)
        {
     
            InitializeComponent();
            this.username = username;
        }
        void VeriGetir()
        {
            dt=new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT kitap_id,kullanici_ismi,kitap_adi,kitap_yazari,alinma_tarihi,geri_getirme_tarihi FROM kitaplar", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            VeriGetir();
            dataGridView1.Columns["kitap_adi"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["kitap_id"].HeaderText = "Kitap No";
            dataGridView1.Columns["kitap_yazari"].HeaderText = "Kitap Yazarı";
            dataGridView1.Columns["kullanici_ismi"].HeaderText = "Alan Kişi";
            dataGridView1.Columns["geri_getirme_tarihi"].HeaderText = "Geri Getirme Tarihi";
            dataGridView1.Columns["alinma_tarihi"].HeaderText = "Alınma Tarihi";
        }
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void butonekle_Click(object sender, EventArgs e)
        {
          adminekle adminekle = new adminekle();
            this.Hide();
            adminekle.ShowDialog();
            this.Show();
 
        }

        private void butonsil_Click(object sender, EventArgs e)
        {
            adminsil adminsil = new adminsil();
            adminsil.ShowDialog();
            this.Show();
        }

        private void butonguncelle_Click(object sender, EventArgs e)
        {
            adminguncelle adminguncelle = new adminguncelle();
adminguncelle.ShowDialog();
            this.Show();

        }
        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "kitap_adi LIKE '" + txtArama.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris sifre=new giris();
            sifre.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris giris=new giris();
            giris.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gunugelenkitaplar gunugelenkitaplar = new gunugelenkitaplar();
            gunugelenkitaplar.ShowDialog();
            this.Close();
        }

        private void adminarayuz_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F6) {
                butonekle.PerformClick();
            }
            else if (e.KeyCode == Keys.F7)
            {
                butonsil.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                butonguncelle.PerformClick();
            }
            else if (e.KeyCode == Keys.F9)
            {
                button3.PerformClick();
            }
        }
    }
    
}
