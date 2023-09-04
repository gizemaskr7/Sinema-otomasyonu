using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sinema_otomasyonu
{
    public partial class BiletDetayRapor : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";
        public string sqlSorgu;
        public BiletDetayRapor()
        {
            InitializeComponent();
        }


        void GridD(string sorgu)
        {


            con = new SqlConnection(baglanti);
            da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {

                sqlSorgu = "select *from BiletKayit  where kullaniciAdi like '%" + textBox1.Text + "%'";
                GridD(sqlSorgu);

            }
            else
            {
                sqlSorgu = "select *from BiletKayit";
                GridD(sqlSorgu);
            }
        }

        private void BiletDetayRapor_Load(object sender, EventArgs e)
        {
            sqlSorgu = "select *from BiletKayit";
            GridD(sqlSorgu);

            dataGridView1.Columns[0].HeaderText = "Kullanıcı ID";
            dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[2].HeaderText = "Müşteri Adı";
            dataGridView1.Columns[3].HeaderText = "Film Adı"; 
            dataGridView1.Columns[4].HeaderText = "Film Saati";
            dataGridView1.Columns[5].HeaderText = "Bilet Saati";
            dataGridView1.Columns[6].HeaderText = "Kategori";
            dataGridView1.Columns[7].HeaderText = "Fiyat";





        }

        private void button1_Click(object sender, EventArgs e)
        {
            RaporGörüntüle r = new RaporGörüntüle();
            r.kadi = textBox1.Text;
            r.ds = ds;
            r.Show();
        }
    }
}
