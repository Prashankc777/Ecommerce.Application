using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.AuthModels
{
    public class AuthRelated
    {


    }

    public class LoginVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterVM
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }

        public string Role { get; set; }
    }

    public class CreateRole
    {
        public string Name { get; set; }
    }

    public class ResetPasswordModel
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int UserId { get; set; }
    }



}
