using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthwindWinForm.Src.Forms.Dialogs
{
    public interface IDialogs
    {
        object Return { get; }
        DialogResult ShowDialog();
    }
}
