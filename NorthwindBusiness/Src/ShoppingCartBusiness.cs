using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{

    public class ShoppingCartExtend: IShoppingCart
    {
        private ShoppingCart item;
        public ShoppingCartExtend(ShoppingCart shoppingCart)
        {
            item = shoppingCart;
        }
        public Int32 ShoppingCartID
        { get { return item.ShoppingCartID; } set { item.ShoppingCartID = value; } }
        public String CustomerID
        { get { return item.CustomerID; } set { item.CustomerID = value; } }        
        public DateTime PurchaseDate
        { get { return item.PurchaseDate; } set { item.PurchaseDate=value; } }
        public string Description
        { get { return item.Description; } set { item.Description = value; } }
        public int Count { get; set; }
    }

    /*!
     * carrinho de compras
     */
    public class ShoppingCartBusiness
    {
        private NorthwindShoppingCartsDAO northwindDAO = new NorthwindShoppingCartsDAO();
        public ShoppingCartBusiness()
        { }
        /*!
         * Retorna lista de carrinhos e atualiza numero de items
         */
        public List<ShoppingCartExtend> SelectList()
        {
            var shoppingCartItemsDAO = new NorthwindShoppingCartItemsDAO();
            List<ShoppingCart> list1 = northwindDAO.ShoppingCartsSelect();
            List<ShoppingCartExtend> list2 = new List<ShoppingCartExtend>();
            foreach (var item in list1)
            {
                var item2 = new ShoppingCartExtend(item);
                item2.Count = shoppingCartItemsDAO.ShoppingCartItemCount(item.ShoppingCartID);
                list2.Add(item2);                
            }
            return list2;
        }
        /*!
         * Retorna carrinho 
         */
        public ShoppingCart SelectItem(int id)
        {        
            return northwindDAO.ShoppingCartSelect(id);
        }
        /*!
         * Salva no banco
         */
        public void InsertItem(ShoppingCart item)
        {         
            northwindDAO.ShoppingCartInsert(item);            
        }
        /*!
         * Atualiza no banco   
         */
        public void UpdateItem(ShoppingCart item)
        {           
            northwindDAO.ShoppingCartUpdate(item);
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
     * Extensão do carrinho de compras
     */
    public class ShoppingCartItemExtend : IShoppingCartItem
    {
        private ShoppingCartItem item;
        public ShoppingCartItemExtend(ShoppingCartItem shoppingCartItem)
        {
            item = shoppingCartItem;
        }
        public Int32 ShoppingCartItemID
        { get { return item.ShoppingCartItemID; } set { item.ShoppingCartItemID = value; } }

        public Int32 ShoppingCartID
        { get { return item.ShoppingCartID; } set { item.ShoppingCartID = value; } }
        
        public Int32 ProductID
        { get { return item.ProductID; } set { item.ProductID = value; } }  
        
        public Double Quantity
        { get { return item.Quantity; } set { item.Quantity = value; } } 
        
        public Decimal UnitPrice
        { get { return item.UnitPrice; } set { item.UnitPrice = value; } }

        public Double Total
        {
            get { return (Double)(Quantity * Convert.ToDouble(UnitPrice)); }
        }
    }
    /*!
     * Items carrinho de compras
     */
    public class ShoppingCartItemBusiness 
    {
        private NorthwindShoppingCartItemsDAO northwindDAO = new NorthwindShoppingCartItemsDAO();
        private int shoppingCartID;
        public ShoppingCartItemBusiness(int shoppingCartID)
        {
            this.shoppingCartID = shoppingCartID;
        }
        /*!
         * Select ShoppingCartItem por shoppingCartItemID(chave)  
         */
        public ShoppingCartItem SelectItem(int id)
        {
             return  northwindDAO.ShoppingCartItemSelect(id);
            //return new ShoppingCartItemExtend(item);
        }
        /*!
         * Retorna lista de items pelo id do carrinho 
         */
        public List<ShoppingCartItemExtend> SelectList()
        {
            List<ShoppingCartItem> list = northwindDAO.ShoppingCartItemsSelect(shoppingCartID);
            List<ShoppingCartItemExtend> list2 = new List<ShoppingCartItemExtend>();
            foreach (var item in list)
            {
                list2.Add(new ShoppingCartItemExtend(item));               
            }
            return list2;
        }
        /*!
         * Salva no banco
         */
        public void InsertItem(ShoppingCartItem item)
        {            
            item.ShoppingCartID = shoppingCartID;                         
            northwindDAO.ShoppingCartItemInsert(item);            
        }
        /*!
         * Atualiza no banco   
         */
        public void UpdateItem(ShoppingCartItem item)
        {            
            item.ShoppingCartID = shoppingCartID;
            northwindDAO.ShoppingCartItemUpdate(item);
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
