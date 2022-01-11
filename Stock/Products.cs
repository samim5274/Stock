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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            cbxStatus.SelectedIndex = 0;
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=STOCK;Integrated Security=True");
            con.Open();
            bool obj = false;
            if (cbxStatus.SelectedIndex == 0)
            {
                obj = true;
            }
            else
            {
                obj = false;
            }
            SqlCommand cmd = new SqlCommand(@"INSERT INTO [STOCK].[dbo].[Products]
           ([ProductCode]
           ,[ProductName]
           ,[ProductStatus])
            VALUES
           ('"+ txtCode.Text+"','" +txtProduct.Text+"','"+obj+"')",con);
           cmd.ExecuteNonQuery();
           con.Close();

            //reading data
           LoadData();

                //ctrl + k,ctrl+ c (for comment)
                //ctrl + k,ctrl+ u (for uncomment)
           //SqlDataAdapter sda = new SqlDataAdapter("Select * from [STOCK].[dbo].[Products]", con);
           //DataTable dt = new DataTable();
           //sda.Fill(dt);
           //dataGridView1.Rows.Clear();
           //foreach (DataRow item in dt.Rows)
           //{
           //    int n = dataGridView1.Rows.Add();
           //    dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
           //    dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
           //    if ((bool)item["ProductStatus"])
           //    {
           //        dataGridView1.Rows[n].Cells[2].Value = "Active";
           //    }
           //    else
           //    {
           //        dataGridView1.Rows[n].Cells[2].Value = "Deactive"; 
           //    }
           //}   
     
            }
            catch (Exception)
            {
                MessageBox.Show("Product Code Invalit ..!","Erorr",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void LoadData()
        {
            SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=STOCK;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("Select * from [STOCK].[dbo].[Products]", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = item["ProductCode"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = item["ProductName"].ToString();
                if ((bool)item["ProductStatus"])
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Active";
                }
                else
                {
                    dataGridView1.Rows[n].Cells[2].Value = "Deactive";
                }
            }   
 
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtCode.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtProduct.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells[2].Value.ToString() == "Active")
            {
                cbxStatus.SelectedIndex = 0;
            }
            else
            {
                cbxStatus.SelectedIndex = 1;
            }            
        }

    }
}
