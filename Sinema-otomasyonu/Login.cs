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
    public partial class Login : Form
    {
        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";
        public Login()
        {
            InitializeComponent();

        }
        public static string kullanicim = "";
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (VeriTabani.login(textBox1.Text, textBox2.Text))
            {
                MessageBox.Show("giris basarili");
                kullanicim=textBox1.Text;
                Register f = new Register();
                f.Show();
                this.Hide();
            }
           else if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz");
            }
            else
                MessageBox.Show("kullanıcı adı veya şifre hatalı");
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}


     

