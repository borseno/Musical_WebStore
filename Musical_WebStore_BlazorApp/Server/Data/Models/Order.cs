using System;
using System.Collections.Generic;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class Order
    {
        public int Id {get;set;}
        public string UserId {get;set;}
        public int LocationId {get;set;}
        public virtual Location Location {get;set;}
        public string Phone {get;set;}
        public int StatusId {get;set;}
        public DateTime Date {get;set;}
        public virtual IEnumerable<ItemOrder> Items {get;set;}

    }
}