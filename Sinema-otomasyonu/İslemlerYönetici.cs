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
    public partial class İslemlerYönetici : Form
    {
        public İslemlerYönetici()
        {
            InitializeComponent();
        }



        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        SqlDataReader dr;
        DataSet ds;
        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";
        public string sqlSorgu;
        void GridD(string sorgu)
        {


            con = new SqlConnection(baglanti);
            da = new SqlDataAdapter(sorgu, con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "Filmler");
            dataGridView1.DataSource = ds.Tables["Filmler"];
            con.Close();

        }
        

        private void biletİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bİlet_İşlemleri asd=new Bİlet_İşlemleri();
            asd.ShowDialog();
        }

        private void İslemlerYönetici_Load(object sender, EventArgs e)
        {
            VeriTabani.GridD(dataGridView1, "select*from Filmler");

            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Film Adı";
            dataGridView1.Columns[2].HeaderText = "Film Saati";
            dataGridView1.Columns[3].HeaderText = "Kategori";
            dataGridView1.Columns[4].HeaderText = "Fiyat";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox4.Text != "" && comboBox1.Text != "" && maskedTextBox1.Text != "" && textBox3.Text != "")
            {
            string sorgu = "insert into Filmler(filmAd,filmSaat,kategori,fiyat)values('" + textBox4.Text + "','" + maskedTextBox1.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "')";
            VeriTabani.islemler(sorgu);
            VeriTabani.GridD(dataGridView1, "select*from Filmler");
            }
            else
            {
                MessageBox.Show("Boşlukları eksiksiz doldurunuz.");
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string sqlSorgu = "select * from Filmler where filmAd like '%" + textBox1.Text + "%'";
            GridD(sqlSorgu);
        }

        private void filmRaporuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rapor r=new Rapor();    
            r.ShowDialog();
        }

        private void biletRaporuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BiletDetayRapor r = new BiletDetayRapor();
            r.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "delete from Filmler where filmAd='" + textBox4.Text + "'";
            VeriTabani.islemler(sorgu);
            VeriTabani.GridD(dataGridView1, "select *from Filmler");
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

       
    }
}
