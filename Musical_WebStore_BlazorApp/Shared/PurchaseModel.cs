using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class PurchaseModel
    {
        [Required(ErrorMessage = "You must choose a location")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Invalid")]
        public string LocationId {get;set;}
        [Required(ErrorMessage = "You must provide a phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone {get;set;}
    }
}
