﻿using System;
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
    public partial class FarmersReport : Form
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.Samplebillingcom);

        SqlDataAdapter da;
        public FarmersReport()
        {
            InitializeComponent();
        }

        private void FarmersReport_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                da = new SqlDataAdapter("select * from tblFarmers1", con);
                DataSet dst = new DataSet();
                ReportDocument cryrpt = new ReportDocument();
                da.Fill(dst,"Far");
                cryrpt.Load("FarmersCrystalReport.rpt");
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