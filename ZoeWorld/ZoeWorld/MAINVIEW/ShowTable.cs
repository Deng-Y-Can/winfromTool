using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoeWorld.DLL.db.HomeView.DLL.DATABASE;

namespace ZoeWorld.MAINVIEW
{
    public partial class ShowTable : Form
    {
        public ShowTable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int limit = 20;
            int page = 1;
            string sql = $@"select * from person ";
            //真分页 根据page limit来进行分页
            SqliteHelper sqliteHelper = new SqliteHelper();
            DataTable dt = sqliteHelper.ExecuteDataTable(sql);
            dataTableToListView(listView1, dt);
        }

        public bool SetTable(DataTable dataTable)
        {
            try
            {
                // 假设dataTable是已经填充数据的DataTable实例
                dataTable.TableName = "person"; // 设置DataTable的表名

                // 将DataTable绑定到ListView控件
                listView1.GridLines = true; // 显示网格线
                listView1.View = View.Details; // 设置为详细信息视图
                listView1.FullRowSelect = true; // 选择整行
                //listView1.DataSource = dataTable; // 设置数据源

                // 创建列头
                foreach (DataColumn column in dataTable.Columns)
                {
                    listView1.Columns.Add(column.ColumnName, column.ColumnName);
                }
                return true;
            }catch(Exception ex)
            {
                return false;
            }
            
        }
        public static void dataTableToListView(ListView lv, DataTable dt)
        {
            lv.GridLines = true; // 显示网格线
            lv.View = View.Details; // 设置为详细信息视图
            lv.FullRowSelect = true;
            if (dt != null)
            {
                lv.Items.Clear();
                lv.Columns.Clear();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    lv.Columns.Add(dt.Columns[i].Caption.ToString());
                }
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem lvi = new ListViewItem(dr[0].ToString());
                    for (int i = 1; i < dt.Columns.Count; i++)
                    {
                        lvi.SubItems.Add(dr[i].ToString());
                    }
                    lv.Items.Add(lvi);
                }
                lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        public static void listViewToDataTable(ListView lv, DataTable dt)
        {

            dt.Clear();
            dt.Columns.Clear();
            //生成DataTable列头
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                dt.Columns.Add(lv.Columns[i].Text.Trim(), typeof(string));
            }
            //每行内容
            for (int i = 0; i < lv.Items.Count; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < lv.Columns.Count; j++)
                {
                    dr[j] = lv.Items[i].SubItems[j].Text.Trim();
                }
                dt.Rows.Add(dr);
            }
        }
    }
}
