using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class PrintSugercaneBill1 : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
       
        SqlDataAdapter da;
        public PrintSugercaneBill1()
        {
            InitializeComponent();
        }

        private void PrintSugercaneBill1_Load(object sender, EventArgs e)
        {
            txtBillNo.Text = Class2.strInv1;
            
         try
            {
                con.Open();
                da = new SqlDataAdapter("select TblSCHeaderData.BillNo,TblSCHeaderData.FarmersName,TblSCHeaderData.BillDate,TblSCHeaderData.TotalWeight,TblSCHeaderData.Rate1,TblSCHeaderData.BillAmount,TblSCRowData.SrNo,TblSCRowData.Weight,TblSCRowData.Rate,TblSCRowData.Amount,TblSCRowData.BillNo from TblSCHeaderData inner join TblSCRowData on TblSCHeaderData.BillNo=TblSCRowData.BillNo where  TblSCHeaderData.BillNo='"+txtBillNo.Text+ "'", con);
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
           
            Class2.strInv1 = "";
           
        }

     
        
        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                con.Open();
                da = new SqlDataAdapter("select TblSCHeaderData.BillNo,TblSCHeaderData.FarmersName,TblSCHeaderData.BillDate,TblSCHeaderData.TotalWeight,TblSCHeaderData.Rate1,TblSCHeaderData.BillAmount,TblSCRowData.SrNo,TblSCRowData.Weight,TblSCRowData.Rate,TblSCRowData.Amount,TblSCRowData.BillNo from TblSCHeaderData inner join TblSCRowData on TblSCHeaderData.BillNo=TblSCRowData.BillNo where  TblSCHeaderData.BillNo='" +txtBillNo.Text+ "'", con);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


      
    }
}
