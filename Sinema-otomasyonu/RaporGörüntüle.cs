using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_otomasyonu
{
    public partial class RaporGörüntüle : Form
    {
        public RaporGörüntüle()
        {
            InitializeComponent();
        }

        public DataSet ds;
        public string kadi;


        private void RaporGörüntüle_Load(object sender, EventArgs e)
        {
            kullaniciDetayRapor1.SetDataSource(ds.Tables[0]);
            kullaniciDetayRapor1.SetParameterValue("kAd", kadi);
            crystalReportViewer1.ReportSource = kullaniciDetayRapor1;
        }
    }
}
