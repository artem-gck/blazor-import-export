using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Importify.Access.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string? Login { get; set; }
        public byte[]? Password { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
        public UserInfo? UserInfo { get; set; }
    }
}
