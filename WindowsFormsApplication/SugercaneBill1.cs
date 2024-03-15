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
using CrystalDecisions.CrystalReports.Engine;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        
        SqlDataAdapter da;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                da = new SqlDataAdapter("select TblSCHeaderData.BillNo,TblSCHeaderData.FarmersName,TblSCHeaderData.BillDate,TblSCHeaderData.TotalWeight,TblSCHeaderData.Rate1,TblSCHeaderData.BillAmount,TblSCRowData.SrNo,TblSCRowData.Weight,TblSCRowData.Rate,TblSCRowData.Amount,TblSCRowData.BillNo from TblSCHeaderData inner join TblSCRowData on TblSCHeaderData.BillNo=TblSCRowData.BillNo where  TblSCHeaderData.BillNo='" + textBox1.Text + "'", con);
                DataSet dst = new DataSet();
                ReportDocument cryrpt = new ReportDocument();
                da.Fill(dst, "PrintBill1");
                cryrpt.Load("FarmersBillPrint.rpt");
                cryrpt.SetDataSource(dst);
                crystalReportViewer1.ReportSource = cryrpt;
                
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Class2.strInv1;
            Class2.strInv1 = "";
        }
    }
}
