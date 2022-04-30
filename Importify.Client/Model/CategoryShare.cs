namespace Importify.Client.Model
{
    public class CategoryShare
    {
        public string Country { get; set; }
        public decimal Value { get; set; }
        public string Summary { get { return Country + " " + Math.Round(Value / 1_000_000, 2) + "M $"; } }
    }
}
