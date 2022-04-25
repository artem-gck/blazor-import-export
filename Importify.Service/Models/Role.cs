using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int UserInfoId { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
