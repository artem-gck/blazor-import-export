using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.ViewModels
{
    public class CountryData
    {
        public string Country { get; set; }
        public int Year { get; set; }
        public decimal ExportValue { get; set; }
        public decimal ImportValue { get; set; }
        public decimal netExportValue { get; set; }
    }
}
