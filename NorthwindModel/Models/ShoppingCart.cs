using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace NorthwindModel.Models
{
    //public interface IShoppingCart
    //{
    //    Int32 ShoppingCartID { get; set; }
    //    String CustomerID { get; set; }       
    //    DateTime PurchaseDate { get; set; }        
    //    string Description { get; set; }
    //}

    public class ShoppingCart//: IShoppingCart
    {
        public ShoppingCart()
        {
            //Date = DateTime.Now;
        }

        public ShoppingCart(Int32 shoppingCartID)
        {
            ShoppingCartID = shoppingCartID;
        }
        [Required]
        public Int32 ShoppingCartID { get; set; }
        [Required]
        public String CustomerID { get; set; }//Cliente
        
        //[DataBrasil(ErrorMessage = "Data inválida", DataRequerida = true)]
        //[DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //Data da compra
        public DateTime? PurchaseDate { get; set; }

        [MaxLength(ErrorMessage = "Maximo 100 characters.")]
        public string Description { get; set; }
        
    }
}
