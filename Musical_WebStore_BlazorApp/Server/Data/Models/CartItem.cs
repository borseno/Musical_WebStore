using System;
using Musical_WebStore_BlazorApp.Server.Data.Models;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class CartItem
    {
        public string UserId {get;set;}
        public virtual User User {get;set;}
        public int InstrumentId {get;set;}
        public virtual Instrument Instrument {get;set;}
    }
}