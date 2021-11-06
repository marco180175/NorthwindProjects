using NorthwindBusiness.Src;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms.Dialogs
{
    public partial class OrderFieldForm : Form, IDialogs
    {
        private Order returnOrder;
        private bool isValid;
        public OrderFieldForm(object item)
        {
            InitializeComponent();
            returnOrder = new Order();
            //
            var nwCustomers = new CustomersBusiness();
            var customers = nwCustomers.SelectList();
            cbxCustomerID.Items.AddRange(customers.ToArray());
            cbxCustomerID.Items.Insert(0, "Select");
            cbxCustomerID.SelectedIndex = 0;
            //
            var nwEmployees = new EmployeesBusiness();
            var employees = nwEmployees.SelectdList();
            cbxEmployeeID.Items.AddRange(employees.ToArray());
            cbxEmployeeID.Items.Insert(0, "Select");
            cbxEmployeeID.SelectedIndex = 0;
            //
            var nwShippers = new ShippersBusiness();
            var shippers = nwShippers.SelectList();
            cbxShippers.Items.AddRange(shippers.ToArray());
            cbxShippers.Items.Insert(0, "Select");
            cbxShippers.SelectedIndex = 0;
            //
            if (item != null)
            {
                Order order = (Order)item;
                returnOrder.OrderID = order.OrderID;
                //
                int j = customers.FindIndex(x => x.CustomerID == order.CustomerID);
                cbxCustomerID.SelectedIndex = j + 1;
                //
                j = employees.FindIndex(x => x.EmployeeID == order.EmployeeID);
                cbxEmployeeID.SelectedIndex = j + 1;
                //
                if (order.ShipVia.HasValue)
                {
                    j = shippers.FindIndex(x => x.ShipperID == order.ShipVia.Value);
                    cbxShippers.SelectedIndex = j + 1;
                }
                else
                {
                    cbxShippers.SelectedIndex = 0;
                }
                //
                if (order.OrderDate.HasValue)
                    txtOrderDate.Text = order.OrderDate.Value.ToShortDateString();

                if (order.RequiredDate.HasValue)
                    txtRequiredDate.Text = order.RequiredDate.Value.ToShortDateString();

                if (order.ShippedDate.HasValue)
                    txtShippedDate.Text = order.ShippedDate.Value.ToShortDateString();

                if (order.Freight.HasValue)
                    nudFreight.Value = order.Freight.Value;

                txtShipName.Text = order.ShipName;

                txtShipAddress.Text = order.ShipAddress;

                txtShipCity.Text = order.ShipCity;

                txtShipRegion.Text = order.ShipRegion;

                txtShipPostalCode.Text = order.ShipPostalCode;

                txtShipCountry.Text = order.ShipCountry;            }            
        }

        public object Return { get { return returnOrder; } }
                
        private void btOk_Click(object sender, EventArgs e)
        {
            Validate();
            if (isValid)
            {
                Customer customer = (Customer)cbxCustomerID.SelectedItem;
                returnOrder.CustomerID = customer.CustomerID;
                Employee employee = (Employee)cbxEmployeeID.SelectedItem;
                returnOrder.EmployeeID = employee.EmployeeID;
                if (string.IsNullOrEmpty(txtOrderDate.Text))
                    returnOrder.OrderDate = null;
                else
                    returnOrder.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
                if (string.IsNullOrEmpty(txtRequiredDate.Text))
                    returnOrder.RequiredDate = null;
                else
                    returnOrder.RequiredDate = Convert.ToDateTime(txtRequiredDate.Text);
                if (string.IsNullOrEmpty(txtShippedDate.Text))
                    returnOrder.ShippedDate = null;
                else
                    returnOrder.ShippedDate = Convert.ToDateTime(txtShippedDate.Text);
                if (cbxShippers.SelectedIndex == 0)
                    returnOrder.ShipVia = null;
                else
                {
                    Shipper shipper = (Shipper)cbxShippers.SelectedItem;
                    returnOrder.ShipVia = shipper.ShipperID;
                }
                //returnOrder.ShipVia = Convert.ToInt32(nudShipVia.Value);
                returnOrder.Freight = nudFreight.Value;
                returnOrder.ShipName = txtShipName.Text;
                returnOrder.ShipAddress = txtShipAddress.Text;
                returnOrder.ShipCity = txtShipCity.Text;
                returnOrder.ShipRegion = txtShipRegion.Text;
                returnOrder.ShipPostalCode = txtShipPostalCode.Text;
                returnOrder.ShipCountry = txtShipCountry.Text;
                //
                DialogResult = DialogResult.OK;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private new void Validate()
        {
            isValid = true;
            List<string> messageList = new List<string>();            
            //
            if (cbxCustomerID.Text == "Select")
            {
                isValid = false;
                messageList.Add("Selecione um customer para a order");
            }
            //
            if (cbxEmployeeID.Text == "Select")
            {
                isValid = false;
                messageList.Add("Selecione um employee para o order");
            }
            //            
            if (!isValid)
            {
                ShowListMessageForm showListMessage = new ShowListMessageForm(messageList);
                showListMessage.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MonthCalendarDialog calendar = new MonthCalendarDialog();            
            if (calendar.ShowDialog(this) == DialogResult.OK)
                txtOrderDate.Text = calendar.ReturnDate.ToShortDateString();
        }        

        private void txtOrderDate_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                txtOrderDate.Text = "";
                e.Handled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var orders = new OrdersBusiness();
            returnOrder.ShipCity = txtShipCity.Text;
            orders.UpdateItem(returnOrder, "ShipCity");
        }
    }
}
