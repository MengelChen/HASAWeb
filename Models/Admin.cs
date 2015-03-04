using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class Admin
    {
        [Key]
        public virtual int AdminId { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual int Power { get; set; }
        public virtual DateTime RegisterTime { get; set; }
        public virtual DateTime LastLogin { get; set; }

        public Admin()
        {
            Username = string.Empty;
            Password = string.Empty;
            Name = string.Empty;
            Power = 0;
            RegisterTime = DateTime.Now;
            LastLogin = DateTime.Now;
        }
    }

}