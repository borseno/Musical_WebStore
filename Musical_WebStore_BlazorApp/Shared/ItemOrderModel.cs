using System;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class ItemOrderModel
    {
        public int OrderId {get;set;}
        public int InstrumentId {get;set;}
        public virtual Instrument Instrument {get;set;}
        public int Num {get;set;}

    }
}