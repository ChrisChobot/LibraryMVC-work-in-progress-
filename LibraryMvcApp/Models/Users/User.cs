using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryMvcApp.Models.Users
{
    public class User
    {
        [Key]
        uint Id;
        string Login;
        string Password;
        UserType UserType;
    }
}