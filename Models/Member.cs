﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class Member
    {
        [Key]
        public virtual int MemberID {get; set;}

        public virtual string Name { get; set; }
        public virtual int PictureID { get; set; }
        public virtual string Position { get; set; }
        public virtual string Introduction { get; set; }
    }
}