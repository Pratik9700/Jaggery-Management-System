using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //to open child form in parent form .
            Products p = new Products();
            p.MdiParent = this;
            p.Show();
            
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new_bill nb = new new_bill();
            nb.MdiParent = this;
            nb.Show();
        }

        private void farmersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Farmers f = new Farmers();
            f.MdiParent = this;
            f.Show();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Customers c = new Customers();
            c.MdiParent = this;
            c.Show();
        }

      

        private void viewSalesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Sales_Bill vsb = new View_Sales_Bill();
            vsb.MdiParent = this;
            vsb.Show();
        }

        private void viewFarmersBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Farmers_Bill vfb = new View_Farmers_Bill();
            vfb.MdiParent = this;
            vfb.Show();
        }

        private void printSalesBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSalesBilll pb = new PrintSalesBilll();
            pb.MdiParent = this;
            pb.Show();
        }

      


        private void printSalesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalesReport sr = new SalesReport();
            sr.MdiParent = this;
            sr.Show();
        }

        private void printSugercaneReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SugercaneReport sr1 = new SugercaneReport();
            sr1.MdiParent = this;
            sr1.Show();
        }



     /*   private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Image myimage = new Bitmap(@"C:\Users\91997\Downloads\New folder\sugercane.jpg");
            this.BackgroundImage = myimage;
            
        }*/

        private void main_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(@"C:\Users\91997\Desktop\project\my project\New folder (2)\New folder (2)\WindowsFormsApplication2\Resources\sugercane.jpg");
            this.BackgroundImage = myimage;
        }

       

        private void productsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProductsReport PR = new ProductsReport();
            PR.MdiParent = this;
            PR.Show();
        }

        private void customersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomersReportcs CR = new CustomersReportcs();
            CR.MdiParent = this;
            CR.Show();
            

        }

        private void farmersReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FarmersReport FR = new FarmersReport();
            FR.MdiParent = this;
            FR.Show();
        }

        private void SugercaneBillingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SugercaneBilling Sb = new SugercaneBilling();
            Sb.MdiParent= this;
            Sb.Show();
        }

        private void printFarmersBillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintSugercaneBill1 pb = new PrintSugercaneBill1();
            pb.MdiParent = this;
            pb.Show();
        }
        
    }

}
