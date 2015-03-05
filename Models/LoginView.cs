using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class LoginView
    {
        [StringLength(20, MinimumLength = 2)]
        public virtual string Username { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public virtual string Password { get; set; }

    }
}