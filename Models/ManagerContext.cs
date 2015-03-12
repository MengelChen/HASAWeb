using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HASAWeb.Models
{
    public class ManagerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ManagerContext() : base("name=ManagerContext")
        {
        }

        public System.Data.Entity.DbSet<HASAWeb.Models.Article> Articles { get; set; }
        public System.Data.Entity.DbSet<HASAWeb.Models.Admin> Admins { get; set; }
        public System.Data.Entity.DbSet<HASAWeb.Models.Picture> Pictures { get; set; }
        public System.Data.Entity.DbSet<HASAWeb.Models.Member> Members { get; set; }
        public System.Data.Entity.DbSet<HASAWeb.Models.Column> Columns { get; set; }

        /// <summary>
        /// return the ID of the first column that satisfies the Name parameter
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int FindColumnByName(string name)
        {
            List<Column> cols = Columns.ToList<Column>();
            Column col = new Column();
            foreach(var i in cols)
            {
                if(i.ColumnName==name)
                {
                    col = i;
                    break;
                }
            }

            return col.ColumnID;
        }

        public List<Article> FindArticleByColumnName(string name)
        {
            int id = FindColumnByName(name);
            Column col = Columns.Find(id);
            List<Article> result = new List<Article>();
            foreach (var i in col.Articles)
            {
                result.Add(Articles.Find(i));
            }

            return result;
        }

        public List<Article> FindArticlesByColumnID(int id)
        {
            Column col = Columns.Find(id);
            List<Article> result = new List<Article>();
            foreach(var i in col.Articles)
            {
                result.Add(Articles.Find(i));
            }

            return result;
        }
    }
}
