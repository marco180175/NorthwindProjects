using NorthwindBusiness.Src;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms
{
    public partial class CustomersForm : Form
    {
        private CustomersBusiness customer = new CustomersBusiness();
        public CustomersForm(Control parent)
        {
            InitializeComponent();
            //            
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Parent = parent;
            this.Dock = DockStyle.Fill;            
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (cbCountry.SelectedIndex == 0)
                dataGridView1.DataSource = customer.SelectList();
            else
                dataGridView1.DataSource = customer.Get(cbCountry.Text, FilterType.Country);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbCity.SelectedIndex == 0)
                dataGridView1.DataSource = customer.SelectList();
            else
                dataGridView1.DataSource = customer.Get(cbCity.Text, FilterType.City);
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            var list = customer.SelectList();

            cbCountry.Items.Add("Select...");
            foreach(var item in list)
                cbCountry.Items.Add(item.Country);
            cbCountry.SelectedIndex = 0;

            cbCity.Items.Add("Select...");
            foreach (var item in list)
                cbCountry.Items.Add(item.City);
            cbCity.SelectedIndex = 0;            
        }        
    }
}
