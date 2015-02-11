using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace HASAWeb.Models
{
    public class Article
    {
        public virtual int      ArticleId     { get; set; }
        public virtual int      ColumnId      { get; set; }
        public virtual int      Hits          { get; set; }
        public virtual string   Title         { get; set; }
        public virtual string   Keywords      { get; set; }
        public virtual string   Author        { get; set; }
        public virtual string   Pictures      { get; set; }
        public virtual string   Content       { get; set; }
        public virtual bool     Authorized    { get; set; }
        public virtual DateTime PublishTime   { get; set; }
        public virtual DateTime ReviseTime    { get; set; }
    }

    public class ArticleDBContext : DbContext
    {
        public DbSet<Article> Articles { get; set;}
    }
}