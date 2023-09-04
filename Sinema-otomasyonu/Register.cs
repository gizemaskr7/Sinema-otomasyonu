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
    public partial class Register : Form
    {
        //Data Source=localhost\SQLEXPRESS;Initial Catalog=Sinema;Integrated Security=True
        public static string baglanti =@"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";

    
        public Register()
        {
            InitializeComponent();   
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           VeriTabani.GridD(dataGridView1,"select *from giris");
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kullanıcı Adı";
        }


        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text=dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Login.kullanicim == "giz")
            {
                string sss = "select *from giris where kullanici_adi='" + textBox1.Text + "'";

                if (VeriTabani.kullanici_kontrol(sss))
                {
                    MessageBox.Show("Aynı isimde kullamıcı vardır.");
                }
                else
                {
                    if (textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Kullanıcı adı ve şifre giriniz");
                    }
                    else
                    {
                        string sorgu = "insert into giris (kullanici_adi,sifre)values('" + textBox1.Text + "','" + VeriTabani.MD5Sifrele(textBox2.Text) + "')";
                        VeriTabani.islemler(sorgu);
                        VeriTabani.GridD(dataGridView1, "select*from giris");
                    }
                }
            }
            else
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Login.kullanicim == "giz")
            {
                string sorgu = "delete from giris where kullanici_adi='" + textBox1.Text + "' and sifre='" + textBox2.Text + "'";
                VeriTabani.islemler(sorgu);
                VeriTabani.GridD(dataGridView1, "select *from giris");
            }
            else
            {
                MessageBox.Show("Bu işlem için yetkiniz yoktur.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu="update giris set sifre='"+ VeriTabani.MD5Sifrele(textBox2.Text)+"'where kullanici_adi='"+textBox1.Text+"'";
            VeriTabani.islemler(sorgu);
            VeriTabani.GridD(dataGridView1, "select*from giris");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login lg=new Login();
            lg.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }

        private void şifreİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SifreIslemleri a=new SifreIslemleri();
            a.ShowDialog();
        }

        private void üyeleriGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Üyelerim ü = new Üyelerim();
            ü.ShowDialog(); 
            
        }

        private void çalışanİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            İslemlerCalisan a = new İslemlerCalisan();
            a.ShowDialog();
        }

        private void yöneticiİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Login.kullanicim == "giz")
            {
                İslemlerYönetici a = new İslemlerYönetici();
                a.ShowDialog();
            }
            else
            {
                MessageBox.Show("İzinsiz Giris !");
            }
        }
    }
}