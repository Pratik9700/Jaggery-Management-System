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
    public partial class new_bill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataReader dr;

        public new_bill()
        {
            InitializeComponent();
            txtDataUpdate.Visible = false;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

       

        private void new_bill_Load(object sender, EventArgs e)
        {
            
           // TODO: This line of code loads data into the 'samplebillingDataSet.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.samplebillingDataSet.tblCustomers);
            cmbProducts.Select();
            cmbProducts.Items.Clear(); //clear combobox before load.
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ProName FROM TblProducts ORDER BY ProName asc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbProducts.Items.Add(dr["ProName"].ToString());

            }
            con.Close();
            LoadBillNo();
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }
        public void LoadBillNo()
        {
            //load bill no from database
            int a;
            string constr = (Properties.Settings.Default.Samplebillingcom);
            con.Open();
            string query = "Select Max(BillNo) from TblHeaderData";
            cmd = new SqlCommand(query, con);

            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtBillNo.Text = "1";
                }
                else
                {
                        a = Convert.ToInt32(dr[0].ToString());
                        a=a+1;
                        txtBillNo.Text = a.ToString();
                }
                con.Close();
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbCustName.Text == "")
            {
                MessageBox.Show("Customers Name is empty");
            }
            if(cmbProducts.Text=="")
            {
                MessageBox.Show("Product Name is empty");
            }
            else if(txtPrice.Text=="")
            {
                 MessageBox.Show(" Product Price is empty");            
            }
            else if (txtQty.Text == "")
            {
                MessageBox.Show("Product Quantity is empty");
            }
            else
            { // add the data in gridview
                if(txtDataUpdate.Text=="")
                {
                    int row = 0;
                    dataGridView1.Rows.Add();
                    row = dataGridView1.Rows.Count - 1;
                    dataGridView1["ProductName",row].Value = cmbProducts.Text;
                    dataGridView1["Cust_Name", row].Value = cmbCustName.Text;
                    dataGridView1["Price", row].Value = txtPrice.Text;
                    dataGridView1["Qty", row].Value = txtQty.Text;
                    dataGridView1["Amount", row].Value = txtAmount.Text;
                    dataGridView1["BillNo", row].Value = txtBillNo.Text;
                    dataGridView1["Date", row].Value = dateTimePicker2.Value.ToString("dd-MM-yyyy");
                    dataGridView1.Refresh();
                    dataGridView1.Focus();
                    
                    if(dataGridView1.Rows.Count>0)
                    {
                        dataGridView1.CurrentCell=dataGridView1.Rows[dataGridView1.Rows.Count-1].Cells[0];
                    }
                }
                   
                else
                {

                    btnAdd.Text = "Update";
                    //update rows from datagridview and after edit textbox to gridview
                    int i;
                    i = Convert.ToInt32(txtDataUpdate.Text);
                    DataGridViewRow row = dataGridView1.Rows[i - 1];
                    row.Cells[1].Value = cmbCustName.Text;
                    row.Cells[2].Value = cmbProducts.Text;
                    row.Cells[3].Value = txtPrice.Text;
                    row.Cells[4].Value = txtQty.Text;
                    row.Cells[5].Value = txtAmount.Text;

                    btnAdd.Text = "Add";
                }

                cleartextbox();
                calAmount();
                gridTotal();

            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value=(e.RowIndex+1).ToString();
        }

        int i;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            cmbCustName.Text = row.Cells[1].Value.ToString();
            cmbProducts.Text = row.Cells[2].Value.ToString();
            txtPrice.Text= row.Cells[3].Value.ToString();
            txtQty.Text = row.Cells[4].Value.ToString();
            txtAmount.Text = row.Cells[5].Value.ToString();
            txtDataUpdate.Text = row.Cells[0].Value.ToString();

            btnAdd.Text = "Update";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtDataUpdate.Text == "")
            {
                MessageBox.Show("Select Product to delete..!!");
            }

            else
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    if (!row.IsNewRow) dataGridView1.Rows.Remove(row);
                }
            }
            btnAdd.Text = "Add";
            gridTotal();
            cleartextbox();
            txtNetPay.Text = "";
            txtDiscount.Text = "";
            
        }

        public void cleartextbox()
        {
            cmbProducts.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
            txtDataUpdate.Text = "";
        
        }
       
        public void calAmount()
        {
            double a1, b1, i;
            double.TryParse(txtPrice.Text, out a1);
            double.TryParse(txtQty.Text, out b1);
            i = a1 * b1;
            if(i>0)
            {
                txtAmount.Text = i.ToString("C").Remove(0, 1);
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        public void gridTotal()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            txtBillTotal.Text = sum.ToString();
        }
        public void discal()
        {
            Double a2, b2, i;
            Double.TryParse(txtBillTotal.Text, out a2);
            Double.TryParse(txtDiscount.Text, out b2);
            i = a2 - b2;
            if(i>0)
            {
                txtNetPay.Text = i.ToString("C").Remove(0, 1);            
            }
        }

        private void txtBillTotal_TextChanged(object sender, EventArgs e)
        {
            discal();
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            discal();
        }
        
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Please Add Minimum One Product To Bill ");
            }
            else
            {
                // to save header data
                con.Open();
                cmd = new SqlCommand("Insert into TblHeaderData(BillNo,CustomerName,BillDate,TotalAmount,DisAmount,NetPay) values('" + txtBillNo.Text + "','"+ cmbCustName.Text +"','" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "','" + txtBillTotal.Text + "','" + txtDiscount.Text + "','" + txtNetPay.Text + "')", con);
                cmd.ExecuteNonQuery();
                // to save row data
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("Insert into TblRowData(SRNo,CustomerName,ProductName,Price,Qty,Amount,BillNo) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "')", con);
                    cmd1.ExecuteNonQuery();
                }

                dataGridView1.Rows.Clear();
                MessageBox.Show("Bill saved...!!!");
                con.Close();

                Class1.strInv = txtBillNo.Text;

                LoadBillNo();
                cleartextbox();
                calAmount();
                txtBillTotal.Text = "";
                txtDiscount.Text = "";
                txtNetPay.Text = "";     
                cmbProducts.Select();

                PrintSalesBilll pb = new PrintSalesBilll();
                pb.ShowDialog();
            }
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd=new SqlCommand("Select * from tblProducts where ProName='"+cmbProducts.Text+"' ",con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtPrice.Text = dr[2].ToString();
            }
            con.Close();
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        


    }
}
