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
//using static System.TimeSpan;



namespace Sinema_otomasyonu
{
    public partial class Bİlet_İşlemleri : Form
    {
        public Bİlet_İşlemleri()
        {
            InitializeComponent();
        }


        private void Bİlet_İşlemleri_Load(object sender, EventArgs e)
        {
            VeriTabani.GridD(dataGridView1, "select Koltuklar.*, BiletKayit.* from Koltuklar INNER JOIN BiletKayit ON Koltuklar.koID = BiletKayit.kID");

            ///header text
            dataGridView1.Columns[0].HeaderText = "Koltuk ID";
            dataGridView1.Columns[1].HeaderText = "Koltuk Numarası";
            dataGridView1.Columns[2].HeaderText= "Film Adı";
            dataGridView1.Columns[3].HeaderText = "Müşteri Adı";
            dataGridView1.Columns[4].HeaderText = "Kullanıcı ID";
            dataGridView1.Columns[5].HeaderText = "Kullanıcı Adı";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible=false;
            dataGridView1.Columns[8].HeaderText = "Film Saati";
            dataGridView1.Columns[9].HeaderText = "Bilet Saati";
            dataGridView1.Columns[10].HeaderText = "Kategori";
            dataGridView1.Columns[11].HeaderText = "Fiyat";
            ///gizlemme
        }
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (radioButton1.Checked)
                {
                    VeriTabani.GridDP(dataGridView1, textBox1.Text, "MUSTERIARAMA", "musteriAd", SqlDbType.NVarChar, 50);
                }


                else if (radioButton3.Checked)
                {
                    VeriTabani.GridDP(dataGridView1, textBox1.Text, "CALISANARAMA", "calisanAd", SqlDbType.NVarChar, 50);
                }
            }
            else
            {
                 VeriTabani.GridD(dataGridView1, "select Koltuklar.*, BiletKayit.* from Koltuklar INNER JOIN BiletKayit ON Koltuklar.koID = BiletKayit.kID");

            }

        }
    }
       
    }




