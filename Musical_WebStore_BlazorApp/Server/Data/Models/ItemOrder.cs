using System;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class ItemOrder 
    {
        public int OrderId {get;set;}
        public virtual Order Order {get;set;}
        public int InstrumentId {get;set;}
        public virtual Instrument Instrument {get;set;}
        public int Num {get;set;}

    }
}