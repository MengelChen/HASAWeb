using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class ColumnView
    {
        public virtual int ColumnID { get; set; }
        public virtual List<Article> Articles { get; set; }
        public virtual string ColumnName { get; set; }
        public ManagerContext db = new ManagerContext();

        public ColumnView(int id)
        {
            Column col = db.Columns.Find(id);
            ColumnID = col.ColumnID;
            ColumnName = col.ColumnName;
            foreach(var i in col.Articles)
            {
                Article art = db.Articles.Find(i);
                Articles.Add(art);
            }
        }
    }
}