using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.Entities
{
    public class Massage
    {
        public int MassageId { get; set; }
        public string MassageText { get; set; }
        public User? User { get; set; }
    }
}
