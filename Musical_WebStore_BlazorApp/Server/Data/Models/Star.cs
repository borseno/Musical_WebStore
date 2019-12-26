using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class Star
    {
        public int Mark { get; set; }

        public int InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set; }
        
        public string AuthorId { get; set;  }
        public virtual User Author { get; set; }

    }
}
