using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HASAWeb.Models
{
    public class Admin
    {
        public virtual int AdminId { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual int rank { get; set; }
        public virtual DateTime RegisterTime { get; set; }
        public virtual DateTime LastLogin { get; set; }
    }

}