using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{
    public class ShoppingCartItemExtend: ShoppingCartItem
    {
        public Double Total
        {
            get { return (Double)(Quantity * Convert.ToDouble(UnitPrice)); }
        }
    }
    /*!
     * Lista de carrinho de compras
     */
    public class ShoppingCartListBusiness//: ICustomBusiness
    {
        private NorthwindShoppingCartsDAO northwindDAO = new NorthwindShoppingCartsDAO();
        public ShoppingCartListBusiness()
        { }
        /*!
         * Retorna lista de carrinhos e atualiza numero de items
         */
        public List<ShoppingCart> SelectList()
        {
            var shoppingCartItemsDAO = new NorthwindShoppingCartItemsDAO();
            List<ShoppingCart> list = northwindDAO.ShoppingCartsSelect();
            foreach (var item in list)
                item.Count = shoppingCartItemsDAO.ShoppingCartItemCount(item.ShoppingCartID);
            return list;
        }
        /*!
         * Retorna carrinho 
         */
        public object SelectItem(int id)
        {        
            return northwindDAO.ShoppingCartSelect(id);
        }
        /*!
         * Salva no banco
         */
        public void InsertItem(object item)
        {         
            northwindDAO.ShoppingCartInsert((ShoppingCart)item);            
        }
        /*!
         * Atualiza no banco   
         */
        public void UpdateItem(object item)
        {           
            northwindDAO.ShoppingCartUpdate((ShoppingCart)item);
        }
        /*!
         * Deleta no banco principal e de items
         */
        public void DeleteItem(int id)
        {
            var shoppingCartItemsDAO = new NorthwindShoppingCartItemsDAO();
            shoppingCartItemsDAO.ShoppingCartItemsDelete(id);
            northwindDAO.ShoppingCartDelete(id);
        }
    }

    /*!
     * Carrinho de compras
     */
    public class ShoppingCartBusiness //: ICustomBusiness
    {
        private NorthwindShoppingCartItemsDAO northwindDAO = new NorthwindShoppingCartItemsDAO();
        private int shoppingCartID;
        public ShoppingCartBusiness(int shoppingCartID)
        {
            this.shoppingCartID = shoppingCartID;
        }
        /*!
         * Select ShoppingCartItem por shoppingCartItemID(chave)  
         */
        public ShoppingCartItemExtend SelectItem(int id)
        {
            ShoppingCartItem item = northwindDAO.ShoppingCartItemSelect(id);
            return (ShoppingCartItemExtend)item;
        }
        /*!
         * Retorna lista de items pelo id do carrinho 
         */
        public List<ShoppingCartItemExtend> SelectList()
        {            
            var list = northwindDAO.ShoppingCartItemsSelect(shoppingCartID);
            List<ShoppingCartItemExtend> returnList = new List<ShoppingCartItemExtend>();
            foreach (var item in list)
                returnList.Add(new ShoppingCartItemExtend());
            return returnList.Cast<ShoppingCartItemExtend>().ToList();
        }
        /*!
         * Salva no banco
         */
        public void InsertItem(object item)
        {
            ShoppingCartItem shoppingCartItem = (ShoppingCartItem)item;
            shoppingCartItem.ShoppingCartID = shoppingCartID;                         
            northwindDAO.ShoppingCartItemInsert(shoppingCartItem);            
        }
        /*!
         * Atualiza no banco   
         */
        public void UpdateItem(object item)
        {
            ShoppingCartItem shoppingCartItem = (ShoppingCartItem)item;
            shoppingCartItem.ShoppingCartID = shoppingCartID;
            northwindDAO.ShoppingCartItemUpdate(shoppingCartItem);
        }
        /*!
         * Deleta do banco de items
         */
        public void DeleteItem(int id)
        {           
            northwindDAO.ShoppingCartItemDelete(id);
        }        
    }    
}
