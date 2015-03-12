using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class Column
    {
        [Key]
        public virtual int ColumnID { get; set; }

        public virtual List<int> Articles { get; set; }
        public virtual string ColumnName { get; set; }

        public Column()
        {
        }
    }
}