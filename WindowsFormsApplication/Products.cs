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

namespace WindowsFormsApplication2
{
    public partial class Products : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save product details
            if (txtProName.Text == "")
            {
                MessageBox.Show("Please enter Products name");
            }
            else
            {
                try
                {
                    con.Open();
          //          cmd = new SqlCommand("INSERT INTO tblProducts (Rate)VALUES('" + txtRate.Text + "')", con);
                    cmd = new SqlCommand("INSERT INTO TblProducts (ProName,Rate)VALUES('" + txtProName.Text +"','"+txtRate.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("product info saved...!!!");
                    // after saving the data show the recent saved product id in gridview
                    fillGrid();
                    cleartext();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void fillGrid()
        {
            // fill datagridview from database
            con.Open();
            da = new SqlDataAdapter("select * from TblProducts order by ProName", con);
            con.Close();
            SqlCommandBuilder cd = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            txtProID.Text = row.Cells[0].Value.ToString();
            txtProName.Text = row.Cells[1].Value.ToString();
            txtRate.Text = row.Cells[2].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtProID.Text == "")
            {
                MessageBox.Show("please select product to Update.");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE TblProducts SET ProName='" + txtProName.Text + "',Rate='" + txtRate.Text + "' where ProID='" + txtProID.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Product info updated..!!");
                    fillGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }
        private void cleartext()
        {
            txtProID.Text =" ";
            txtProName.Text ="";
            txtRate.Text = " ";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // check product is selected or not to delete......
            if (txtProID.Text == "")
            {
                MessageBox.Show("select product to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM TblProducts where ProID='" + txtProID.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    fillGrid();
                    cleartext();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            cleartext();
        }
    }
}
