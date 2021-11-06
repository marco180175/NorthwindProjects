using System;
using System.ComponentModel.DataAnnotations;

namespace NorthwindModel.Models
{
    public interface IShoppingCartItem
    {
        Int32 ShoppingCartItemID { get; set; }
        Int32 ShoppingCartID { get; set; }        
        Int32 ProductID { get; set; }        
        Int32 Quantity { get; set; }        
        Decimal UnitPrice { get; set; }
    }

    public class ShoppingCartItem: IShoppingCartItem
    {
        public ShoppingCartItem()
        {

        }

        public Int32 ShoppingCartItemID { get; set; }

        public Int32 ShoppingCartID { get; set; }

        [Required(ErrorMessage ="Selecione id do produto")]
        public Int32 ProductID { get; set; }

        [Range(minimum:1,maximum:10,ErrorMessage ="Valor deve estar entre 1 e 10")]        
        public Int32 Quantity { get; set; }

        [Required(ErrorMessage = "Selecione preço unitario do produto")]
        public Decimal UnitPrice { get; set; } 
        
        
        
        
    }
}
