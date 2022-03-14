using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public List<CategoryExport>? CategoryExports { get; set; } = new();
        public List<CategoryImport>? CategoryImports { get; set; } = new();
    }
}
