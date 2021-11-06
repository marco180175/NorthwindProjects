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
    public partial class MonthCalendarDialog : Form
    {
        private DateTime returnDate;
        public MonthCalendarDialog()
        {
            InitializeComponent();
        }

        public DateTime ReturnDate { get { return returnDate; } }

        private void btnOk_Click(object sender, EventArgs e)
        {
            returnDate = monthCalendar1.SelectionStart;
            DialogResult = DialogResult.OK;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
