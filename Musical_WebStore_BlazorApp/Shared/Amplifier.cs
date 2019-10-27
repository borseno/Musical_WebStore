using System;
using System.Collections.Generic;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class Amplifier : Instrument
    {
        public Amplifier() { }
        public Amplifier(int id, string title, int price, int quantity, string description, string image) : base(id, title, price, quantity, description, image) { }
    }
}
