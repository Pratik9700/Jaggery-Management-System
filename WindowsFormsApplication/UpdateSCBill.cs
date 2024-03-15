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
    public partial class UpdateSCBill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;
        public UpdateSCBill()
        {
            InitializeComponent();
        }

        private void UpdateSCBill_Load(object sender, EventArgs e)
        {
             con.Open();

            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from TblSCRowdata where BillNo like ('" + txtBillNo.Text + "%')";
            cmd.ExecuteNonQuery();
            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            con.Close();
      //      LoadFarName();
          //  farname();
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[1].Visible = false;
        }
            // fill Farmers
        
          
           

        

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            calAmount();
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

        private void txtRate_Leave(object sender, EventArgs e)
        {
            calAmount();
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
            cmbFarmerName.Text = row.Cells[1].Value.ToString();
            txtWeight.Text = row.Cells[2].Value.ToString();
            txtRate.Text = row.Cells[3].Value.ToString();
            txtAmount.Text = row.Cells[4].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow) dataGridView1.Rows.Remove(row);
                LoadSerialNO();


            }
            gridTotal();
            WeightRate();
            Rate1();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if txtdatatbl txt box is empty then add new row else update selected row
            if(txtDataUpdate.Text=="")
            {
              for (int i=0;i<dataGridView1.Rows.Count-1;++i)
                {
                    dataGridView1.Rows[1].Cells[1].Value = (i + 1).ToString();
                }
                 DataTable dt = dataGridView1.DataSource as DataTable;
                 DataRow row1 = dt.NewRow();
                 row1[1] = cmbFarmerName.Text.ToString();
                 row1[2] = txtWeight.Text.ToString();
                 row1[3] = txtRate.Text.ToString();
                 row1[4] = txtAmount.Text.ToString();
                 row1[5] = txtBillNo.Text.ToString();

                
                 txtWeight.Focus();
                 dt.Rows.Add(row1);
            }
            else
            {
                DataGridViewRow row = dataGridView1.Rows[i];
                row.Cells[1].Value = cmbFarmerName.Text;
                row.Cells[2].Value = txtWeight.Text;
                row.Cells[3].Value = txtRate.Text;
                row.Cells[4].Value = txtAmount.Text;
                row.Cells[5].Value = txtBillNo.Text;
            }
            cleartextbox();
            WeightRate();
            gridTotal();
            Rate1();
            
        }

        public void cleartextbox()
        {
           //  cmbFarmerName.Text = "";
            txtWeight.Text = "";
            //  txtRate.Text = "";
            txtAmount.Text = "";
            txtDataUpdate.Text = "";

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

        public void WeightRate()
        {
            Double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value);
            }
            txtTotalweight.Text = sum.ToString();
        }

        private void txtTotalweight_TextChanged(object sender, EventArgs e)
        {
            WeightRate();
        }

        private void txtBillAmount_TextChanged(object sender, EventArgs e)
        {
            gridTotal();
        }

        private void btnSaveBill_Click(object sender, EventArgs e)
        {
            //first delete old bill details row data 
            try
            {
                con.Open();
                cmd = new SqlCommand("Delete from TblSCRowData where BillNo='"+txtBillNo.Text+"'",con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            { 
                 MessageBox.Show(ex.Message);
            }
            // now save the updated bill
            try
            {
                
                for (int i = 0; i < dataGridView1.Rows.Count; ++i)
                {
                    SqlCommand cmd1 = new SqlCommand("Insert into TblSCRowData(SrNo,FarmersName,Weight,Rate,Amount,BillNo,Date)values('" + dataGridView1.Rows[i].Cells[0].Value.ToString() + "','"+dataGridView1.Rows[i].Cells[1].Value.ToString()+"','" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView1.Rows[i].Cells[6].Value.ToString() + "')", con);
                    con.Open(); 
                    cmd1.ExecuteNonQuery();
                    con.Close();
                }

                
              //  dataGridView1.Rows.Clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                con.Open();
                cmd = new SqlCommand("Update TblSCHeaderData SET FarmersName='"+cmbFarmerName.Text+"', BillDate='" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "',TotalWeight='"+txtTotalweight.Text+"',Rate1='"+txtrate1.Text+"',BillAmount='"+txtBillAmount.Text+"' where BillNo='"+txtBillNo.Text+"' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Bill Updated");

                Class2.strInv1 = txtBillNo.Text;
                this.Hide();
                PrintSugercaneBill1 psb = new PrintSugercaneBill1();
                
                psb.Show();
                this.Close();

                txtBillAmount.Text = "";
                txtTotalweight.Text = "";
                txtrate1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Rate1();
            //hide this windows copmlte the print layout we will open from
            this.Hide();

        }

        public void Rate1()
        {

            txtrate1.Text = txtRate.Text;
        }

     
        public void farname()
        {
            con.Open();
            cmd = new SqlCommand("Select FarmersName from TblSCHeaderData Where BillNo='" + txtBillNo.Text + "' ", con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
               cmbFarmerName.Text= dr[0].ToString();
            }
            con.Close();
        }

        private void txtBillNo_TextChanged(object sender, EventArgs e)
        {
            farname();
        }

       

       

      
    }
}
