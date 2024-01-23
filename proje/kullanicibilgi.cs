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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace proje
{
    public partial class kullanicibilgi : Form
    {
        string kullaniciad;
        MySqlConnection conn = new MySqlConnection("server=localhost;user=root;password=;database=ejhquykv_library");
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        DataTable dt1;
        MySqlDataAdapter adapter1;
        public kullanicibilgi(string kullaniciad)
        {
            InitializeComponent();
            this.kullaniciad = kullaniciad;
        }
        void VeriGetir()
        {
            dt = new DataTable();
            dt1 = new DataTable();
            conn.Open();
            adapter = new MySqlDataAdapter("SELECT * FROM kalici WHERE kullanici_ismi ='"+kullaniciad+"'",conn);
            adapter1 = new MySqlDataAdapter("SELECT * FROM kullanicilar WHERE kullanici_adi ='" + kullaniciad + "'", conn);
            adapter.Fill(dt);
            adapter1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            dataGridView1.DataSource = dt;
            conn.Close();
            dataGridView1.Columns["kitap_adi"].HeaderText = "Kitap Adı";
            dataGridView1.Columns["kitap_id"].HeaderText = "Kitap No";
            dataGridView1.Columns["kitap_yazari"].HeaderText = "Kitap Yazarı";
            dataGridView1.Columns["kullanici_ismi"].HeaderText = "Alan Kişi";
            dataGridView1.Columns["geri_getirme_tarihi"].HeaderText = "Geri Getirme Tarihi";
            dataGridView1.Columns["alinma_tarihi"].HeaderText = "Alınma Tarihi";
        }

        private void kullanicibilgi_Load(object sender, EventArgs e)
        {
            VeriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            giris giris=new giris();
            giris.Show();
            this.Close();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtAKisi.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
