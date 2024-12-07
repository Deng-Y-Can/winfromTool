using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZoeWorld.MAINVIEW;
using ZoeWorld.MAINVIEW.Excel;
using ZoeWorld.MAINVIEW.ImageConversion;
using ZoeWorld.MAINVIEW.Login;

namespace ZoeWorld
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            TreeNode();
        }

        public void TreeNode()
        {
            // 创建根节点
            TreeNode rootNode = new TreeNode("目录");
            treeView1.Nodes.Add(rootNode);
            // 创建子节点
            TreeNode subNode1 = new TreeNode("办公");
            TreeNode subNode11 = new TreeNode("Excel");
            TreeNode subNode12 = new TreeNode("表格");
            TreeNode subNode2 = new TreeNode("多媒体");
            TreeNode subNode21 = new TreeNode("图片转换1");
            TreeNode subNode22 = new TreeNode("图片转换2");
            TreeNode subNode23 = new TreeNode("Vlc播放器");
            TreeNode subNode9 = new TreeNode("用户设置");
            TreeNode subNode91 = new TreeNode("登录");
            rootNode.Nodes.Add(subNode1);
            subNode1.Nodes.Add(subNode11);
            subNode1.Nodes.Add(subNode12);

            rootNode.Nodes.Add(subNode2);
            subNode2.Nodes.Add(subNode21);
            subNode2.Nodes.Add(subNode22);
            subNode2.Nodes.Add(subNode23);
           
            rootNode.Nodes.Add(subNode9);
            subNode9.Nodes.Add(subNode91);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Excel")
            {
                ExcelForm form2 = new ExcelForm();
                form2.Show();
            }
            else if (e.Node.Text == "表格")
            {
                ShowTable form3 = new ShowTable();
                form3.Show();
            }
            else if (e.Node.Text == "图片转换1")
            {
                ImageConverseForm form3 = new ImageConverseForm();
                form3.Show();
            }
            else if (e.Node.Text == "图片转换2")
            {
                ImageExchange form3 = new ImageExchange();
                form3.Show();
            }
            else if (e.Node.Text == "Vlc播放器")
            {
                VlcPlayerForm form3 = new VlcPlayerForm();
                form3.Show();
            }
            else if (e.Node.Text == "登录")
            {
                Login form3 = new Login();
                form3.Show();
            }
           
        }
    }
}
