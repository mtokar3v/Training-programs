using Microsoft.AspNetCore.Http;
using System;

namespace WebApiServer.Models
{
    public class UserView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public int Rep { get; set; }
        public DateTime Bithday { get; set; }
        public IFormFile Photo { get; set; }
        public string Signature { get; set; }
        public bool SendEmail { get; set; }

        public static explicit operator User(UserView userView)
        {
            User user = new User();
            user.Bithday = userView.Bithday;
            user.Email = userView.Email;
            user.Name = userView.Name;
            user.Password = userView.Password;
            user.Patronymic = userView.Patronymic;
            user.Rep = userView.Rep;
            user.Role = userView.Role;
            user.SendEmail = userView.SendEmail;
            user.Signature = userView.Signature;
            user.Surname = userView.Surname;

            return user;
        }
    }
}