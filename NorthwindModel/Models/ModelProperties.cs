using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindModel.Models
{
    public class ProductProperties
    {
        public const string PRODUCT_ID = "ProductID";//PRIMARY KEY
        public const string PRODUCT_NANE = "ProductName";
        public const string SUPPLIER_ID = "SupplierID";
        public const string CATEGORY_ID = "CategoryID";
        public const string QUANTITY_PER_UNIT = "QuantityPerUnit";
        public const string UNIT_PRICE = "UnitPrice";
        public const string UNITS_IN_STOCK = "UnitsInStock";
        public const string UNITS_ON_ORDER = "UnitsOnOrder";
        public const string REORDER_LEVEL = "ReorderLevel";
        public const string DISCONTINUED = "Discontinued";
    }

    public class OrderProperties
    {
        public const string ORDER_ID = "OrderID";//PRIMARY KEY
        public const string COSTUMER_ID = "CustomerID";
        public const string EMPLOYEE_ID = "EmployeeID";
        public const string ORDER_DATE = "OrderDate";
        public const string REQUIRED_DATE = "RequiredDate";
        public const string SHIPPED_DATE = "ShippedDate";
        public const string SHIP_VIA = "ShipVia";
        public const string FREIGHT = "Freight";
        public const string SHIP_NAME = "ShipName";
        public const string SHIP_ADDRESS = "ShipAddress";
        public const string SHIP_CITY = "ShipCity";
        public const string SHIP_REGION = "ShipRegion";
        public const string SHIP_POSTAL_CODE = "ShipPostalCode";
        public const string SHIP_COUNTRY = "ShipCountry";
    }

    public class ShipperProperties
    {
        public const string SHIPPER_ID ="ShipperID";
        public const string COMPANY_NAME = "CompanyName";
        public const string PHONE = "Phone";
    }

    public class CategoryProperties
    {
        public const string CATEGORY_ID = "CategoryID";
        public const string CATEGORY_NAME = "CategoryName";
        public const string DESCRIPTION = "Description";
    }

    public class ShoppingCartProperties
    {
        public const string SHOPPINGCART_ID = "ShoppingCartID";
        public const string COSTUMER_ID = "CustomerID";
        public const string PUSRCHASEDATE = "PurchaseDate";
        public const string DESCRIPTION = "Description";
    }
    
    public class ShoppingCartItemProperty
    {
        public const string SHOPPINGCARTITEM_ID = "ShoppingCartItemID";
        public const string SHOPPINGCART_ID = "ShoppingCartID";
        public const string PRODUCT_ID = "ProductID";
        public const string QUANTITY = "Quantity";
        public const string UNIT_PRICE = "UnitPrice";
    }
}

