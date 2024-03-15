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
    public partial class Farmers : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public Farmers()
        {
            InitializeComponent();
        }
        private void Farmers_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save product details
            if (txtFarmerName.Text=="")
            {
                MessageBox.Show("Please enter Farmers details");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO tblFarmers1(FarName,Address,MobileNo)VALUES('" + txtFarmerName.Text + "','"+txtAddress.Text+"','"+txtMobile.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Farmers info saved...!!!");
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
            da = new SqlDataAdapter("select * from tblFarmers1 order by FarName", con);
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
            txtFarmerID.Text = row.Cells[0].Value.ToString();
            txtFarmerName.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[2].Value.ToString();
            txtMobile.Text = row.Cells[3].Value.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtFarmerID.Text=="")
            {
                MessageBox.Show("please select product to Update.");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE tblFarmers1 SET FarName='" +txtFarmerName.Text + "', Address='" + txtAddress.Text+ "', MobileNo='" + txtMobile.Text+ "'where FarID='" + txtFarmerID.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Farmers info updated..!!");
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
            txtFarmerID.Text = " ";
            txtFarmerName.Text = "";
            txtAddress.Text = " ";
            txtMobile.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // check product is selected or not to delete......
            if (txtFarmerID.Text== "")
            {
                MessageBox.Show("select product to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tblFarmers1 where FarID='" + txtFarmerID.Text + "'", con);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            cleartext();
        }
        
    }
}
