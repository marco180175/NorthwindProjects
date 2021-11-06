using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NorthwindBusiness.Src;
using NorthwindModel.Models;
using NorthwindWinForm.Src;
using NorthwindWinForm.Src.Forms;
using NorthwindWinForm.Src.Forms.Reports;

namespace NorthwindWinForm
{
    public partial class MainForm : Form
    {
        private Form form = null;
        public MainForm()
        {
            InitializeComponent();
            
        }              

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string url = @"c:\teste.pdf";
        //    Process.Start("file:///" + url);
        //}       
        
        private void miCategories_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();            
            form = new CategoriesForm(panel1);
            form.Show();
        }

        private void miProducts_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();            
            form = new ProductsForm(panel1);
            form.Show();
        }

        private void miOrders_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();
            form = new OrderTableForm(panel1);
            form.Show();
        }

        private void miOrderDetails_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();
            var orderDetails = new OrderDetailsBusiness();
            form = new TableForm(panel1, orderDetails.Get());
            form.Show();
        }

        private void miSuppliers_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();
            var suppliers = new SuppliersBusiness();
            form = new TableForm(panel1, suppliers.SelectList());
            form.Show();
        }

        private void miCustomers_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();            
            form = new CustomersForm(panel1);
            form.Show();
        }

        private void miEmployees_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();
            var employees = new EmployeesBusiness();
            form = new TableForm(panel1, employees.SelectdList());
            form.Show();
        }

        private void tsbShopping_Click(object sender, EventArgs e)
        {
            //LoginForm login = new LoginForm();
            //if (login.ShowDialog(this) == DialogResult.OK)
            //{
            //    ShoppingForm shopping = new ShoppingForm();
            //    shopping.Show();
            //}
            
        }

        private void tsbStoredProcedures_Click(object sender, EventArgs e)
        {
            //ProceduresForm procedutesForm = new ProceduresForm();
            //procedutesForm.Show();
            
        }

        private void tsbShoppingCarts_Click(object sender, EventArgs e)
        {            
            
        }

        private void tsbCartItems_Click(object sender, EventArgs e)
        {
            //var northwindDAO = new NorthwindShoppingCartItemsDAO();
            //TableForm tableForm = new TableForm(northwindDAO.ShoppingCartItemsSelect(-1));
            //tableForm.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
            //var report = new ReportersBusiness(Application.StartupPath);
            //report.Select();
            //MessageBox.Show("convertido !");
            //TableForm tableForm = new TableForm(panel1, report.Select());
            //tableForm.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //var report = new ReportViewerForm();
            //report.Show();
        }

        private void custOrderHistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new CustOrderHistForm();
            report.ShowDialog();
        }

        private void custOrdersDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new CustOrdersDetailForm();
            report.ShowDialog();
        }

        private void salesByCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new SalesByCategoryForm();
            report.ShowDialog();
        }

        private void employeeSalesbyCountryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new EmployeeSalesbyCountryForm();
            report.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var report = new CustOrdersOrdersForm();
            report.ShowDialog();
        }

        private void salesByYearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new SalesbyYearForm();
            report.ShowDialog();
        }

        private void tenMostExpensiveProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var report = new TenMostExpensiveProductsForm();
            report.ShowDialog();
        }

        private void tsmShoppingCarts_Click(object sender, EventArgs e)
        {
            if (form != null)
                form.Close();
            try
            {
                form = new ShoppingForm(panel1);
                ((ShoppingForm)form).ShowList += new ShowListFormEventHandler(shoppingCartItems_Click);
                form.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void shoppingCartItems_Click(object sender, ShowListFormEventArgs e)
        {
            if (form != null)
                form.Close();
            var shoppingItemForm = new ShoppingItemForm(panel1, e.Id);
            form = shoppingItemForm;
            shoppingItemForm.Show();
        }
    }
}
