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
    public partial class SugercaneBilling : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataReader dr;

        public SugercaneBilling()
        {
            InitializeComponent();
            txtDataUpdate.Visible = false;
        }

        private void SugercaneBilling_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'samplebillingDataSet.tblCustomers' table. You can move, or remove it, as needed.
            this.tblCustomersTableAdapter.Fill(this.samplebillingDataSet.tblCustomers);
            cmbFarmerName.Select();
            cmbFarmerName.Items.Clear(); //clear combobox before load.
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT FarName FROM TblFarmers1 ORDER BY FarName asc";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cmbFarmerName.Items.Add(dr["FarName"].ToString());

            }
            con.Close();
            LoadBillNo();
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
           // dataGridView1.Columns[1].Visible = false;

        }
        public void LoadBillNo()
        {
            //load bill no from database
            int a;
            string constr = (Properties.Settings.Default.Samplebillingcom);
            con.Open();
            string query = "Select Max(BillNo) from TblSCHeaderData";
            cmd = new SqlCommand(query, con);

            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    txtBillNo.Text = "1";
                }
                else
                {
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a+1;
                    txtBillNo.Text = a.ToString();
                }
                con.Close();
            }
        }

        
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbFarmerName.Text=="")
            {
                MessageBox.Show("Farmers Name is empty");
            }
            if(txtAmount.Text=="")
            {
                MessageBox.Show("Amount is empty");
            }
            else if(txtRate.Text=="")
            {
                 MessageBox.Show(" Rate is empty");            
            }
            else if (txtWeight.Text=="")
            {
                MessageBox.Show("Weight is empty");
            }
            else
            { // add the data in gridview
                if(txtDataUpdate.Text=="")
                {
                    int row = 0;
                    dataGridView1.Rows.Add();
                    row = dataGridView1.Rows.Count - 1;
               //     dataGridView1["SrNo",row].Value =txtSrNo.Text ;
                    dataGridView1["FarName", row].Value = cmbFarmerName.Text;
                    dataGridView1["Weight", row].Value = txtWeight.Text;
                    dataGridView1["Rate", row].Value = txtRate.Text;
                    dataGridView1["Amount", row].Value = txtAmount.Text;
                    dataGridView1["BillNo", row].Value = txtBillNo.Text;
                    dataGridView1["Date", row].Value = dateTimePicker1.Value.ToString("dd-MM-yyyy");
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
                    row.Cells[1].Value = cmbFarmerName.Text;
                    row.Cells[2].Value = txtWeight.Text;
                    row.Cells[3].Value = txtRate.Text;
                    row.Cells[4].Value = txtAmount.Text;
                    row.Cells[5].Value = txtBillNo.Text;
                    row.Cells[0].Value = txtSrNo.Text;
                    

                    btnAdd.Text = "Add";
                }

                    cleartextbox();
                    WeightRate();
                    gridTotal();
                    Rate1();

                    
        
            }
        }
        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dataGridView1.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
           
        }

        int i;
        private void dataGridView1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            i = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[i];
            cmbFarmerName.Text = row.Cells[1].Value.ToString();
            txtWeight.Text = row.Cells[2].Value.ToString();
            txtRate.Text = row.Cells[3].Value.ToString();
            txtAmount.Text = row.Cells[4].Value.ToString();
            txtDataUpdate.Text = row.Cells[0].Value.ToString();

            btnAdd.Text = "Update";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
        
            if (txtDataUpdate.Text == "")
            {
                MessageBox.Show("Select Bill to delete..!!");
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
            
          //  txtBillAmount.Text = "";
            
        }

        public void cleartextbox()
        {
          //  cmbFarmerName.Text = "";
            txtWeight.Text = "";
          //  txtRate.Text = "";
            txtAmount.Text = "";
            txtDataUpdate.Text = "";

        }

        public void calAmount()
        {
            double a1, b1, i;
            double.TryParse(txtWeight.Text, out a1);
            double.TryParse(txtRate.Text, out b1);
            i = a1 * b1;
            if (i > 0)
            {
                txtAmount.Text = i.ToString("C").Remove(0, 1);
            }
        }

        private void txtWeight_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        private void txtRate_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        public void gridTotal()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            txtBillAmount.Text = sum.ToString();
        }


        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count < 1)
            {
                MessageBox.Show("Please Add Minimum One Product To Bill ");
            }
            else
            {
                // to save header data
                con.Open();
                cmd = new SqlCommand("Insert into TblSCHeaderData(BillNo,FarmersName,BillDate,TotalWeight,Rate1,BillAmount) Values('" + txtBillNo.Text + "','" + cmbFarmerName.Text + "','" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "','"+txtTotalweight.Text+"','" + txtrate1.Text+ "','" + txtBillAmount.Text + "')", con);
                cmd.ExecuteNonQuery();
                // to save row data 
                
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    SqlCommand cmd1 = new SqlCommand("Insert into TblSCRowData(SrNo,FarmersName,Weight,Rate,Amount,BillNo) values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "')", con);
                    cmd1.ExecuteNonQuery();
                }
                dataGridView1.Rows.Clear();
                MessageBox.Show("Bill saved...!!!");
                con.Close();

                Class2.strInv1 = txtBillNo.Text;

                LoadBillNo();
                //cleartextbox();
                txtBillAmount.Text = "";
                WeightRate();
                Rate1();
                
                cmbFarmerName.Select();
                PrintSugercaneBill1 pb1 = new PrintSugercaneBill1();
                pb1.ShowDialog();
                
            }
        }

        private void cmbFarmerName_SelectedIndexChanged(object sender, EventArgs e)
        {   
             
            con.Open();
            cmd = new SqlCommand("Select * from tblFarmers1 where FarName='" + cmbFarmerName.Text + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                 txtSrNo.Text= dr[0].ToString();
            }
            con.Close();
          
       
        }

        

        public void WeightRate()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            txtTotalweight.Text = sum.ToString();
           
        }
        public void Rate1()
        {

            txtrate1.Text = txtRate.Text;
        }

        private void txtTotalweight_TextChanged(object sender, EventArgs e)
        {
            WeightRate();
        }

        private void txtrate1_Leave(object sender, EventArgs e)
        {
            Rate1();
            WeightRate();
        }

        private void txtBillAmount_Leave(object sender, EventArgs e)
        {
            calAmount();
        }

        private void cmbFarmerName_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select * from tblFarmers1 where FarName='" + cmbFarmerName.Text + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtSrNo.Text = dr[0].ToString();
            }
            con.Close();
        }

       

       
        
    }
}
