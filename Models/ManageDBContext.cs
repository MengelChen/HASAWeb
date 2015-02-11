using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using HASAWeb.Models;

namespace HASAWeb.Models
{
    public class ManageDBContext : DbContext
    {
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}