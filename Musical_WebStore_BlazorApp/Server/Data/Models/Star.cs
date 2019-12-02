using Musical_WebStore_BlazorApp.Shared;

namespace Musical_WebStore_BlazorApp.Server.Data.Models
{
    public class Star
    {
        public int Mark { get; set; }

        public int InstrumentId { get; set; }
        public Instrument Instrument { get; set; }
        
        public string AuthorId { get; set;  }
        public User Author { get; set; }

    }
}
