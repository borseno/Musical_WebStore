namespace Musical_WebStore_BlazorApp.Shared
{
    public class Instrument : Good
    {
        public Instrument() { }
        public Instrument(int id, string title, int price, int quantity, string description, string image) : base(id, title, price, quantity, description, image) { }
    }
}
