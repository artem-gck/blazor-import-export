using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Service.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
