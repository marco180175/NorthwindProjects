using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindWinForm.Src
{
    public class ShowListFormEventArgs : EventArgs
    {
        public ShowListFormEventArgs(int id)
        {
            Id = id;
        }
        public int Id { get; }
    }

    public delegate void ShowListFormEventHandler(object sender, ShowListFormEventArgs e);
}
