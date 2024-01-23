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
    public partial class gunugelenkitaplar : Form
    {
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        MySqlCommand cmd;
        MySqlCommand otocmd;
        MySqlCommand sorgu;
        MySqlDataAdapter adapter;
        DataTable dt;
        public gunugelenkitaplar()
        {
            InitializeComponent();
        }
        void VeriGetir()
        {
            dt = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT kitap_id,kullanici_ismi,kitap_adi,kitap_yazari,alinma_tarihi,geri_getirme_tarihi FROM kitaplar WHERE DATE(geri_getirme_tarihi) <= CURDATE()", conn);
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gunugelenkitaplar_Load(object sender, EventArgs e)
        {
            VeriGetir();
            dataGridView1.Columns["kitap_adi"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["kitap_id"].HeaderText = "Kitap No";
            dataGridView1.Columns["kitap_yazari"].HeaderText = "Kitap Yazarı";
            dataGridView1.Columns["kullanici_ismi"].HeaderText = "Alan Kişi";
            dataGridView1.Columns["geri_getirme_tarihi"].HeaderText = "Geri Getirme Tarihi";
            dataGridView1.Columns["alinma_tarihi"].HeaderText = "Alınma Tarihi";
        }

        private void txtArama_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "kitap_adi LIKE '" + txtArama.Text + "%'";
            dataGridView1.DataSource = dv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminarayuz sifre = new adminarayuz(string.Empty);
            sifre.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris sifre = new giris();
            sifre.Show();
            this.Close();
        }
    }
}
