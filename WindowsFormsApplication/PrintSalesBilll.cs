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
    public partial class PrintSalesBilll : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);
        ReportDocument cryrpt=new ReportDocument();
        SqlDataAdapter da;
        public PrintSalesBilll()
        {
            InitializeComponent();
        }

        private void PrintSalesBilll_Load(object sender, EventArgs e)
        {
            txtBillNo.Text = Class1.strInv;
            try
            { 
                con.Open();
                da = new SqlDataAdapter("select TblHeaderData.BillNo,TblHeaderData.CustomerName,TblHeaderData.BillDate,TblHeaderData.TotalAmount,TblHeaderData.DisAmount,TblHeaderData.NetPay, TblRowData.SRNo,TblRowData.ProductName,TblRowData.Price,TblRowData.Qty,TblRowData.Amount,TblRowData.BillNo from TblHeaderData inner join TblRowData on TblHeaderData.BillNo=TblRowData.BillNo where  TblHeaderData.BillNo='"+txtBillNo.Text+"'",con);
                DataSet dst = new DataSet();
                da.Fill(dst, "PrintBill");
                cryrpt.Load("SalesBillingPrint.rpt");
                cryrpt.SetDataSource(dst);
                crystalReportViewer1.ReportSource = cryrpt;
                con.Close();

            }
             catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Class1.strInv = "";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                da = new SqlDataAdapter("select TblHeaderData.BillNo,TblHeaderData.CustomerName,TblHeaderData.BillDate,TblHeaderData.TotalAmount,TblHeaderData.DisAmount,TblHeaderData.NetPay, TblRowData.SRNo,TblRowData.ProductName,TblRowData.Price,TblRowData.Qty,TblRowData.Amount,TblRowData.BillNo from TblHeaderData inner join TblRowData on TblHeaderData.BillNo=TblRowData.BillNo where  TblHeaderData.BillNo='" + txtBillNo.Text + "'", con);
                DataSet dst = new DataSet();
                da.Fill(dst, "PrintBill");
                cryrpt.Load("SalesBillingPrint.rpt");
                cryrpt.SetDataSource(dst);
                crystalReportViewer1.ReportSource = cryrpt;
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
