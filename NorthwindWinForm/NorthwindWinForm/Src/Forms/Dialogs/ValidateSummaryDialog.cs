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
    public partial class ValidateSummaryDialog : Form
    {
        public ValidateSummaryDialog(List<string> list)
        {
            InitializeComponent();
            listBox1.Items.AddRange(list.ToArray());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
