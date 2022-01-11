using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stock
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
            txtUsername.Clear();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //TO.DO username & password
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=STOCK;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter(@"SELECT * 
                    FROM [STOCK].[dbo].[Login] where Username='"+ txtUsername.Text +"' and Password='"+ txtPassword.Text+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                this.Hide();
                MainStock main = new MainStock();
                main.Show();
            }
            else 
            {
                MessageBox.Show("Invalit username & password ..!","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
                btnClear_Click(sender, e);
            }
                        
        }
    }
}
