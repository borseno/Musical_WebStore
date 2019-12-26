using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class AddItemToCartModel
    {
        public int InstrumentId {get;set;}
        [Required(ErrorMessage = "You must select number of items you want to order")]
        public string Num {get;set;}
    }
}
