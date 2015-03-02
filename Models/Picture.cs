using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class Picture
    {
        [Key]
        public virtual int PictureId { get; set; }

        public virtual string Name { get; set; }
        public virtual string Route { get; set; }
        public virtual DateTime UploadTime { get; set; }
    }

}