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
    public partial class İslemlerCalisan : Form
    {
        public İslemlerCalisan()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
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
         
        public static int[] koltukno = new int[18];

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (radioButton1.Checked)
                {
                    //isme göre
                    sqlSorgu = "select * from Filmler where filmAd like '%" + textBox1.Text + "%'";
                    GridD(sqlSorgu);
                }
                else if (radioButton2.Checked)
                {
                    //kategoriye göre
                    sqlSorgu = "select * from Filmler where kategori like '%" + textBox1.Text + "%'";
                    GridD(sqlSorgu);
                }
                else if (radioButton3.Checked)
                {
                    //saate göre
                    sqlSorgu = "select * from Filmler where filmSaat like '%" + textBox1.Text + "%'";
                    GridD(sqlSorgu);
                }
            }
            else
            {
                sqlSorgu = "select * from Filmler";
                GridD(sqlSorgu);
            }
           
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void İslemlerCalisan_Load(object sender, EventArgs e)
        {
            VeriTabani.GridD(dataGridView1, "select* from Filmler");
            
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Film Adı";
            dataGridView1.Columns[2].HeaderText = "Film Saat";
            dataGridView1.Columns[3].HeaderText = "Kategori";
            dataGridView1.Columns[4].HeaderText = "Fiyat";
            label10.Text = "";


        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text= dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox1.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
            label8.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            koltukSecimi koltuk = new koltukSecimi();
            koltuk.ShowDialog();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        double para = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            para = Convert.ToDouble(textBox3.Text);

            if (textBox4.Text !="" && comboBox2.Text != "" && label10.Text != "") {

            string sorgu3 = "select *from Koltuklar where koltukNu='" + label10.Text + "'and filmAd='" + label8.Text + "'";
            if (VeriTabani.kullanici_kontrol(sorgu3) == true)
            {
                MessageBox.Show("Koltuk Dolu.");
            }
            else
            {
                string sorgu = "insert into BiletKayit (kullaniciAdi,musteriAdi,filmAd,filmSaat,biletSaat,kategori,fiyat)values('" + Login.kullanicim + "','" + textBox4.Text + "','" + label8.Text + "','" + maskedTextBox1.Text + "','" + DateTime.Now.ToShortTimeString() + "','" + comboBox1.Text + "','" + para.ToString() + "')";
                VeriTabani.islemler(sorgu);    
                string sorgu2 = "insert into Koltuklar (koltukNu,filmAd,musteriAdi)values('" + label10.Text + "','" + label8.Text + "','" + textBox4.Text + "')";
                VeriTabani.islemler(sorgu2);
                MessageBox.Show("Satış yapıldı.");
                } 
        }
            else
            {
                MessageBox.Show("Boşlukları doldurduğunuzdan emin olunuz.");
            }
           
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            label10.Text = koltukSecimi.secilen;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
