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
    public partial class Rapor : Form
    {
        public Rapor()
        {
            InitializeComponent();
        }
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        public static string baglanti = @"Data Source = localhost\SQLEXPRESS;Initial Catalog = Sinema; Integrated Security = True";

        public void RDoldur(string sql)
        {
            con = new SqlConnection(baglanti);
            da = new SqlDataAdapter(sql, con);
            ds = new DataSet();

            con.Open();
            da.Fill(ds);

            vizyondaki_filmler1.SetDataSource(ds.Tables[0]);
            crystalReportViewer1.ReportSource = vizyondaki_filmler1;

            con.Close();
        }
        private void Rapor_Load(object sender, EventArgs e)
        {
            RDoldur("select * from Filmler");
        }
    }
}
