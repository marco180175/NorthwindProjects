using NorthwindDAO.Src.DAO;
using NorthwindModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBusiness.Src
{    
    public class ShoppingCartItemWrapper: IShoppingCartItem
    {
        private ShoppingCartItem cartItem;
        public ShoppingCartItemWrapper(ShoppingCartItem item)
        {
            cartItem = item;
        }
        public Int32 ShoppingCartItemID
        {
            get { return cartItem.ShoppingCartItemID; }
            set { cartItem.ShoppingCartItemID = value; }
        }
        public Int32 ShoppingCartID
        {
            get { return cartItem.ShoppingCartID; }
            set { cartItem.ShoppingCartID = value; }
        }
        public Int32 ProductID
        {
            get { return cartItem.ProductID; }
            set { cartItem.ProductID = value; }
        }
        public Double Quantity
        {
            get { return cartItem.Quantity; }
            set { cartItem.Quantity = value; }
        }
        public Decimal UnitPrice
        {
            get { return cartItem.UnitPrice; }
            set { cartItem.UnitPrice = value; }
        }
        public Double Total
        {
            get { return (Double)(cartItem.Quantity * Convert.ToDouble(cartItem.UnitPrice)); }
        }
    }

    public class ShoppingCartWrapper//: IShoppingCart
    {
        private ShoppingCart cartItem;
        public ShoppingCartWrapper(ShoppingCart item)
        {
            cartItem = item;
        }        

        public Int32 ShoppingCartID
        {
            get { return cartItem.ShoppingCartID; }
            set { cartItem.ShoppingCartID = value; }
        }
        public String CustomerID
        {
            get { return cartItem.CustomerID; }
            set { cartItem.CustomerID = value; }
        }
        public DateTime PurchaseDate
        {
            get { return cartItem.PurchaseDate.Value; }
            set { cartItem.PurchaseDate = value; }
        }
        public string Description
        {
            get { return cartItem.Description; }
            set { cartItem.Description = value; }
        }

        public int Count { get; set; }
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
            return northwindDAO.ShoppingCartsSelect();            
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
    public class ShoppingCartBusiness : ICustomBusiness
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
        public object SelectItem(int id)
        {            
            return northwindDAO.ShoppingCartItemSelect(id);
        }
        /*!
         * Retorna lista de items pelo id do carrinho 
         */
        public List<object> SelectList()
        {            
            var list = northwindDAO.ShoppingCartItemsSelect(shoppingCartID);
            List<ShoppingCartItemWrapper> returnList = new List<ShoppingCartItemWrapper>();
            foreach (var item in list)
                returnList.Add(new ShoppingCartItemWrapper(item));
            return returnList.Cast<object>().ToList();
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
