using System;
using System.Collections.Generic;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class Good
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public Good()
        {
            Id = 1;
            Title = "test title";
            Price = 1;
            Quantity = 1;
            Description = "test desc";
        }
        public Good(int id, string title, int price, int quantity, string description) 
        {
            Id = id;
            Title = title;
            Price = price;
            Quantity = quantity;
            Description = description;
        }
    }   
}
