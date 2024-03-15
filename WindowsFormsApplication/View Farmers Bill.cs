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
    public partial class View_Farmers_Bill : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt;

        public View_Farmers_Bill()
        {
            InitializeComponent();
        }

        private void View_Farmers_Bill_Load(object sender, EventArgs e)
        {
            FillGrid();
            totalBills();
        }

        private void btnViewBills_Click(object sender, EventArgs e)
        {
            con.Open();
            da = new SqlDataAdapter("Select * from TblSCHeaderData where BillDate between '" + dateTimePicker1.Value.ToString("MM/dd/yyyy") + "' and '" + dateTimePicker2.Value.ToString("MM/dd/yyyy") + "'order by BillNo asc", con);
            DataSet ds = new DataSet();
            da.Fill(ds, "TblSCHeaderData");
            dataGridView1.DataSource = ds.Tables["TblSCHeaderData"];
            con.Close();
            totalBills();
        }

        private void btnDeleteBills_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " ")
            {
                MessageBox.Show("Select Bill NO for Delete..!!!");
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("You want to Delete bill", "Deleting Bill", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlCommand cmd1 = new SqlCommand();
                    con.Open();
                    cmd = new SqlCommand("Delete from TblSCHeaderData where BillNo ='" + textBox1.Text + "'", con);
                    cmd1 = new SqlCommand("Delete from TblSCRowData where BillNo ='" + textBox1.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();
                    con.Close();

                    FillGrid();
                    totalBills();
                    textBox1.Text = "";
                }
                else if (dialogResult == DialogResult.No)
                {

                }
            }
        }

        

        public void FillGrid()
        {
            con.Open();
            da = new SqlDataAdapter("Select * from TblSCHeaderData order by BillNo asc", con);
            con.Close();
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        //to show total bills 
        public void totalBills()
        {
            txtTotalbills.Text = dataGridView1.Rows.Count.ToString();

            // total bill paid
            double sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value);
            }
            txtBillPaid.Text= sum.ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            UpdateSCBill ufb = new UpdateSCBill();
            ufb.txtBillNo.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
           
            ufb.txtBillAmount.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            ufb.Show(); // to open update bill 
            this.Hide();//to close view
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DataGridViewRow dr = dataGridView1.SelectedRows[0];
            textBox1.Text = dr.Cells[0].Value.ToString();
        }

        private void btnPrintSummary_Click(object sender, EventArgs e)
        {

        }
    }
}
