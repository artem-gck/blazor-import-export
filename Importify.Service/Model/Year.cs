using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Model
{
    public class Year
    {
        public int YearId { get; set; }
        public string Value { get; set; }
        public List<CommonExport>? CommonExports { get; set; } = new();
        public List<CommonImport>? CommonImports { get; set; } = new();
        public List<CategoryExport>? CategoryExports { get; set; } = new();
        public List<CategoryImport>? CategoryImports { get; set; } = new();
    }
}
