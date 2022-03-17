using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.ViewModels
{
    public class WorldConstituents
    {
        public int Year { get; set; }
        public string Constituent { get; set; }
        public decimal ExportValue { get; set; }
        public decimal ImportValue { get; set; }
        public string Country { get; set; }
    }
}
