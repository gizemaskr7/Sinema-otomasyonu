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
    
    public partial class Üyelerim : Form
    {
         SqlConnection con;
         SqlDataAdapter da;
         DataSet ds;


        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";
        public Üyelerim()
        {
            InitializeComponent();
        }

        private void Üyelerim_Load(object sender, EventArgs e)
        {
            Navigasyon();
        }

        public void Navigasyon()
        {
           con=new SqlConnection(baglanti);
            da = new SqlDataAdapter("select * from giris", con);
            ds= new DataSet();
            con.Open();
            da.Fill(ds);
            con.Close();

            bindingSource1.DataSource=ds.Tables[0];
            bindingNavigator1.BindingSource = bindingSource1;

            label4.DataBindings.Add(new Binding("Text", bindingSource1, "ID"));
            textBox1.DataBindings.Add(new Binding("Text", bindingSource1, "kullanici_adi"));
            textBox2.DataBindings.Add(new Binding("Text", bindingSource1, "sifre"));



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void kaydetToolStripButton_Click(object sender, EventArgs e)
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
                    
                }
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }
        public static string secilen = "";
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            string sorgu = "delete from giris where kullanici_adi='" + secilen + "'";
            VeriTabani.islemler(sorgu);
        }

        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            secilen = textBox1.Text;
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            secilen = textBox1.Text;
        }
    }
}
