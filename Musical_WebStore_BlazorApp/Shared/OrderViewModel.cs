using System;
using System.Collections.Generic;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class OrderViewModel
    {
        public int Id {get;set;}
        public string UserId {get;set;}
        public int LocationId {get;set;}
        public virtual LocationModel Location {get;set;}
        public string Phone {get;set;}
        public int StatusId {get;set;}
        public DateTime Date {get;set;}
        public virtual IEnumerable<ItemOrderModel> Items {get;set;}

    }
}