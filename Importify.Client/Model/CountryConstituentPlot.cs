namespace Importify.Client.Model
{
    public class CountryConstituentPlot
    {
        public string Constituent { get; set; }
        public decimal Value { get; set; }
        public string Summary { get { return Constituent + " " + Math.Round(Value / 1_000_000, 2) + "M $"; } }
    }
}
