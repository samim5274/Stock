using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class MainStock : Form
    {
        private int childFormNumber = 0;

        public MainStock()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Products pro = new Products();
            pro.MdiParent = this;
            pro.Show();
        }

        private void MainStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
              
    }
}
