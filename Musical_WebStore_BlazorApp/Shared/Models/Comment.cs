using System;
using System.Collections.Generic;
using System.Text;

namespace Musical_WebStore_BlazorApp.Shared
{
    public class Comment
    {
        public int Id {get;set;}
        public string Text {get;set;}
        public DateTime Date {get;set;}
        public Good Instrument {get;set;}
        public string AuthorId {get;set;}
    }
}
