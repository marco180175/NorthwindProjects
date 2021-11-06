using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    /*!
    * Interfece crud basico
    */
    public interface ICustomBusiness
    {
        List<object> SelectList();
        object SelectItem(int id);
        void InsertItem(object item);
        void UpdateItem(object item);
        void DeleteItem(int id);
    }
}
