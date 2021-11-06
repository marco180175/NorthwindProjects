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
    public partial class ShowListMessageForm : Form
    {
        public ShowListMessageForm(List<string> listMessages)
        {
            InitializeComponent();            
            listBox1.Items.AddRange(listMessages.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
