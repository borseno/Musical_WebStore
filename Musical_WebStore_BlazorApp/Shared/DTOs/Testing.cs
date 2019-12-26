using System;

namespace Musical_WebStore_BlazorApp.Shared.DTOs
{
    public class TestingDTO
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string Comment { get; set; }

        public bool IsConfirmed { get; set; }
        
        public string UserId { get; set; }

        public UserLimited User { get; set; }

        public Instrument Instrument { get; set; }
    }
}
