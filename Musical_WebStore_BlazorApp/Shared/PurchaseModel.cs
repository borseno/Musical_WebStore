using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class PurchaseModel
    {
        public string CardNumber {get;set;}
        public string CVV {get;set;}
        public string Year {get;set;}
        public string Month {get;set;}
    }
}
