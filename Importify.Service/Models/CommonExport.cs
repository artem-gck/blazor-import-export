using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Models
{
    public class CommonExport
    {
        public int CommonExportId { get; set; }
        public decimal Value { get; set; }
        public Country? Country { get; set; }
        public Year? Year { get; set; }
    }
}
