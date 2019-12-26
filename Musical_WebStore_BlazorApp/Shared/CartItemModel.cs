using System;

using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class CartItemModel
    {
        public string UserId {get;set;}
        public int InstrumentId {get;set;}
        public virtual Instrument Instrument {get;set;}
        public int Num {get;set;}
    }
}