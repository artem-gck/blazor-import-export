using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; }
        public double? Area { get; set; }
        public long? Population { get; set; }
        public decimal? Gdp { get; set; }
    }
}
