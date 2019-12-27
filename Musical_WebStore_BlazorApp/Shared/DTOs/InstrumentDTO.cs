namespace Musical_WebStore_BlazorApp.Shared.DTOs
{
    public class InstrumentDTO 
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public string Description { get; set; }

        public string Image { get; set; } 
        
        public string TypeName { get; set; }
        public float AvgMark {get;set;}
    }
}