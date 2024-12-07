using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoeWorld.DLL;

namespace ZoeWorld.MAINVIEW.Excel
{
    public partial class ExcelForm : Form
    {
        public ExcelForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //String connString=  ConfigurationManager.ConnectionStrings["dbConnStr"].ToString(); ;
            //connString = Properties.Settings.Default.psd;
            DataTable a = AccessUser.ExecuteDataTable("select * from person");
        }
    }
}
