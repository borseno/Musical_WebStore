using System;
using System.Collections.Generic;
using System.Text;
using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
