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
        public int InstrumentId {get;set;}
        public virtual UserLimited User {get;set;}
    }
}
