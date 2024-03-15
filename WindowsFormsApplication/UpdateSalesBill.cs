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
    public partial class UpdateSalesBill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public UpdateSalesBill()
        {
            InitializeComponent();
        }

        private void UpdateSalesBill_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from TblRowdata where BillNo like ('" + txtBillNo.Text + "%')";
            
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
       
            
            // fill products
            cmbProducts.Select();
            cmbProducts.Items.Clear(); //clear combobox before load.
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT ProName FROM TblProducts ORDER BY ProName asc";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbProducts.Items.Add(dr["ProName"].ToString());

            }
            con.Close();
            //  LoadBillNo();
            //   dataGridView1.Columns[6].Visible = false;
            // dataGridView1.Columns[7].Visible = false;
            //  dataGridView1.Columns[1].Visible = false;
           // gridTotal();
            //discal();
        }

       
        public void calAmount()
        {
            double a1, b1, i;
            double.TryParse(txtPrice.Text, out a1);
            double.TryParse(txtQty.Text, out b1);
            i = a1 * b1;
            if (i > 0)
            {
                txtAmount.Text = i.ToString("C").Remove(0, 1);
            }
        }

        private void txtQty_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from tblProducts where ProName='" + cmbProducts.Text + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtPrice.Text = dr[2].ToString();
            }
            con.Close();
        }

        

        private void LoadSerialNO()
        {
            int i=1;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[0].Value = i; i++;
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            LoadSerialNO();
        }

        int i;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            txtDataUpdate.Text = row.Cells[0].Value.ToString();
            cmbCustName.Text= row.Cells[1].Value.ToString();
            cmbProducts.Text = row.Cells[2].Value.ToString();
            txtPrice.Text = row.Cells[3].Value.ToString();
            txtQty.Text = row.Cells[4].Value.ToString();
            txtAmount.Text = row.Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow) dataGridView1.Rows.Remove(row);
                LoadSerialNO();

            }
          //  gridTotal();
            //discal();
            
           // txtDiscount.Text = "";
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                //if txtdatatbl txt box is empty then add new row else update selected row
                if (txtDataUpdate.Text == "")
                {
                    for (int i = 0;i < dataGridView1.Rows.Count-1; i++)
                    {
                        dataGridView1.Rows[1].Cells[0].Value = (i + 1).ToString();
                    }
                    DataTable dt = dataGridView1.DataSource as DataTable;
                    DataRow row1 = dt.NewRow();
                    row1[1] = cmbCustName.Text.ToString();
                    row1[2] = cmbProducts.Text.ToString(); 
                    row1[3] = txtPrice.Text.ToString();
                    row1[4] = txtQty.Text.ToString();
                    row1[5] = txtAmount.Text.ToString();
                    row1[6] = txtBillNo.Text.ToString();

                    cmbProducts.Focus();
                    dt.Rows.Add(row1);
                    discal();
             //   gridTotal();
                }
                else
                {
                    DataGridViewRow row = dataGridView1.Rows[i];
                    row.Cells[1].Value=cmbCustName.Text;
                    row.Cells[2].Value = cmbProducts.Text;
                    row.Cells[3].Value = txtPrice.Text;
                    row.Cells[4].Value = txtQty.Text;
                    row.Cells[5].Value = txtAmount.Text;
                    row.Cells[6].Value = txtBillNo.Text;
                }
                gridTotal();
                discal();
                
            }

       

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

       
        public void discal()
        {
            Double a2, b2, i;
            Double.TryParse(txtBillTotal.Text, out a2);
            Double.TryParse(txtDiscount.Text, out b2);
            i = a2 - b2;
            if (i > 0)
            {
                txtNetPay.Text = i.ToString("C").Remove(0, 1);
            }
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

        private void txtBillTotal_TextChanged(object sender, EventArgs e)
        {
            discal();

        }

        public void cleartextbox()
        {
            cmbProducts.Text = "";
            txtPrice.Text = "";
            txtQty.Text = "";
            txtAmount.Text = "";
            txtDataUpdate.Text = "";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //first delete old bill details row data 
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete from TblRowData where BillNo='" + txtBillNo.Text + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            discal();
            // now save the updated bill
            try
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    SqlCommand cmd1 = new SqlCommand("Insert into TblRowData(SRNo,CustomerName,ProductName,Price,Qty,Amount,BillNO,Date)values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','"+dataGridView1.Rows[i].Cells[1].Value.ToString()+"','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[7].Value.ToString() + "')", con);
                    con.Open();
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }
                
                MessageBox.Show("Bill Updated..!!!");

                Class1.strInv = txtBillNo.Text;
                this.Hide();
                PrintSalesBilll psb = new PrintSalesBilll();
                psb.Show();
                this.Close();

                txtAmount.Text = "";
                txtDiscount.Text = "";
                txtNetPay.Text = "";
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //update total bill amiunt discount and other in header data
            try
            {
              
                con.Open();
                cmd = new SqlCommand("Update TblHeaderData SET BillDate='" + dateTimePicker2.Value.ToString("MM/dd/yyyy")+ "',TotalAmount='" + txtBillTotal.Text+ "',DisAmount='" + txtDiscount.Text+ "',NetPay='" + txtNetPay.Text+"' where BillNo='"+txtBillNo.Text+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();

               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            discal();
            


            //hide this windows copmlte the print layout we will open from
            this.Hide();
           
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            discal();
        }

        private void cmbCustName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select CostomerName from TblRowData where BillNo='" +txtBillNo.Text + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                cmbCustName.Text = dr[2].ToString();
            }
            con.Close();
        }
    }
}
