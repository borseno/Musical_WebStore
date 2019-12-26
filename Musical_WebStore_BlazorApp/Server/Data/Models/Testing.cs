using Musical_WebStore_BlazorApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class Testing
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Comment { get; set; }

        public bool IsConfirmed { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }
    }
}
