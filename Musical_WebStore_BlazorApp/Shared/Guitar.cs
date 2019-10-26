using System;
using System.Collections.Generic;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class Guitar : Instrument
    {
        public Guitar() { }
        public Guitar(int id, string title, int price, int quantity, string description, string image) : base(id, title, price, quantity, description, image) { }
    }
}
