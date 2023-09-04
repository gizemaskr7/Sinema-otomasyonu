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
    public partial class SifreIslemleri : Form
    {
        public SifreIslemleri()
        {
            InitializeComponent();
        }
        SqlConnection con;
       
        SqlCommand cmd;
        SqlDataReader dr;
        


        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";


        int sonuc = 0;


        public void RandomS()
        {
            Random r = new Random();
            int ilk = r.Next(0,50);
            int ikinci = r.Next(0,50);
            sonuc = ilk + ikinci;
            label4.Text = ilk.ToString()+"+"+ikinci.ToString()+"=";

        }

        public void sil()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        public void SifreK()
        {
            string sorgu = "select * from giris where kullanici_adi=@k and sifre=@s ";
            con = new SqlConnection(baglanti);
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@k", Login.kullanicim);
            cmd.Parameters.AddWithValue("@s", VeriTabani.MD5Sifrele(textBox1.Text));

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string sql = "update giris set sifre='" + VeriTabani.MD5Sifrele(textBox2.Text) + "'where kullanici_adi='" + Login.kullanicim + "'";
                VeriTabani.islemler(sql);
                MessageBox.Show("Şifre değiştirildi");
            }
            else
            {
                MessageBox.Show("Eski şifrenizi yanlış girdiniz.");
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox4.Text == sonuc.ToString())
            {
                if(textBox2.Text == textBox3.Text)
                {
                    SifreK();
                    RandomS();

                    sil();
                }
                else
                {
                    MessageBox.Show("Şifreler aynı değil");
                    RandomS();
                    sil();
                }
            }
            else
            {
                MessageBox.Show("Sonuç hatalı");
                RandomS();
                sil();

            }
        }

        private void SifreIslemleri_Load(object sender, EventArgs e)
        {
            RandomS();
        }
    }
}
