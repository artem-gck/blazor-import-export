using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Model
{
    public class CommonImport
    {
        public int CommonImportId { get; set; }
        public long Value { get; set; }
        public Country? Country { get; set; }
        public Year? Year { get; set; }
    }
}
