
using NorthwindBusiness.Src;
using NorthwindModel.Models;
using NorthwindWinForm.Src.Forms.Dialogs;
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
    public partial class OrderTableForm : Form
    {
        private OrdersBusiness orders = new OrdersBusiness();
        private DrawDataGridViewButtonsManager drawDataGridViewButtonsManager;
        public OrderTableForm(Control parent)
        {
            InitializeComponent();
            //            
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Parent = parent;
            this.Dock = DockStyle.Fill;
            //
            dataGridView1.DataSource = orders.SelectList();
            dataGridView1.Columns[OrderProperties.SHIP_NAME].Visible = false;
            dataGridView1.Columns[OrderProperties.SHIP_ADDRESS].Visible = false;
            dataGridView1.Columns[OrderProperties.SHIP_CITY].Visible = false;
            dataGridView1.Columns[OrderProperties.SHIP_COUNTRY].Visible = false;
            dataGridView1.Columns[OrderProperties.SHIP_POSTAL_CODE].Visible = false;
            dataGridView1.Columns[OrderProperties.SHIP_REGION].Visible = false;
            //           
            drawDataGridViewButtonsManager = new DrawDataGridViewButtonsManager(dataGridView1);
            drawDataGridViewButtonsManager.addEditButton();
            drawDataGridViewButtonsManager.addDeleteButton();
        }
                
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var orderForm = new OrderFieldForm(null);
            if (orderForm.ShowDialog(this) == DialogResult.OK)
            {                
                orders.InsertItem(orderForm.Return);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderID = Convert.ToInt32(dataGridView1[OrderProperties.ORDER_ID, e.RowIndex].Value);
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_EDIT)
            {                
                drawDataGridViewButtonsManager.eventButtonEdit(orderID, orders,DialogType.OrderDialog);
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == AppStrings.STR_DELETE)
            {
                drawDataGridViewButtonsManager.eventButtonDelete(orderID, orders);
            }
        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            drawDataGridViewButtonsManager.drawButtons(e);
        }
    }
}
