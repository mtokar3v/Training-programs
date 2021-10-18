using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiServer.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Rep { get; set; }
        public DateTime Bithday { get; set; }
        public string Signature { get; set; }
        public bool SendEmail { get; set; }
    }
}
