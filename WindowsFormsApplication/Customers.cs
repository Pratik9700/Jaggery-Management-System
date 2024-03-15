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
    public partial class Customers : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public Customers()
        {
            InitializeComponent();
        }

        public void fillGrid()
        {
            // fill datagridview from database
            con.Open();
            da = new SqlDataAdapter("select * from tblCustomers order by Cust_Name", con);
            con.Close();
            SqlCommandBuilder cd = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        
        private void Customers_Load(object sender, EventArgs e)
        {
            fillGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //save product details
            if (txtCustId.Text=="")
            {
                MessageBox.Show("Please enter Customers details");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("INSERT INTO tblCustomers(Cust_Name,Address,MobileNo,Email)VALUES('" + txtCustName.Text+ "','" +txtAddress.Text+ "','"+txtMobileNO.Text+"','"+txtEmail.Text+"')", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customers info saved...!!!");
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

        int i;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            txtCustId.Text = row.Cells[0].Value.ToString();
            txtCustName.Text = row.Cells[1].Value.ToString();
            txtAddress.Text = row.Cells[2].Value.ToString();
            txtMobileNO.Text = row.Cells[3].Value.ToString();
            txtEmail.Text = row.Cells[4].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtCustId.Text=="")
            {
                MessageBox.Show("please select product to Update.");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("UPDATE tblCustomers SET Cust_Name='" + txtCustName.Text+ "',Address='" + txtAddress.Text+ "',MobileNO='" + txtMobileNO.Text + "',Email='"+txtEmail.Text+"' where Cust_ID='" + txtCustId.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Customers info updated..!!");
                    fillGrid();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // check product is selected or not to delete......
            if (txtCustId.Text == "")
            {
                MessageBox.Show("select Customers to delete");
            }
            else
            {
                try
                {
                    con.Open();
                    cmd = new SqlCommand("DELETE FROM tblCustomers where Cust_ID='" + txtCustId.Text + "'", con);
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

        private void cleartext()
        {
            txtCustId.Text = " ";
            txtCustName.Text = " ";
            txtAddress.Text = " ";
            txtMobileNO.Text = " ";
            txtEmail.Text = " ";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            cleartext();
        }


    }
}
