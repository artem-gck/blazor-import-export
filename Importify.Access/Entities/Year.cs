using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.Entities
{
    public class Year
    {
        public int YearId { get; set; }
        public int Value { get; set; }
        public List<CommonExport>? CommonExports { get; set; } = new();
        public List<CommonImport>? CommonImports { get; set; } = new();
        public List<CategoryExport>? CategoryExports { get; set; } = new();
        public List<CategoryImport>? CategoryImports { get; set; } = new();
    }
}
