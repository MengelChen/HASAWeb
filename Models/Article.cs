using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace HASAWeb.Models
{
    public class Article
    {
        [Key]
        public virtual int          ArticleId     { get; set; }

        public virtual int          Hits          { get; set; }
        public virtual string       Title         { get; set; }
        public virtual string       Keywords      { get; set; }
        public virtual string       Author        { get; set; }
        public virtual string       Pictures      { get; set; }//Pictures存储格式："12,13,15,17"分别对应SPictures[0]到SPictures[3]
        public virtual string       Content       { get; set; }
        public virtual string       Abstraction   { get; set; } 
        public virtual DateTime     PublishTime   { get; set; }
        public virtual DateTime     ReviseTime    { get; set; }
        public virtual DateTime     ExpiredTime   { get; set; }

        public Article()
        {
            Hits = 0;
            Title = string.Empty;
            Keywords = string.Empty;
            Author = string.Empty;
            Pictures = string.Empty;
            Content = string.Empty;
            Abstraction = string.Empty;
            PublishTime = DateTime.Now;
            ReviseTime = DateTime.Now;
            ExpiredTime = DateTime.Now;
        }

        /// <summary>
        /// 目前还缺乏检验是否为数字
        /// </summary>
        /// <param name="Pic"></param>
        /// <returns></returns>
        public List<int> PicturesToList(string Pic)
        {
            List<int> SPictures = new List<int>();
            List<string> temp = new List<string>();
            temp = Pic.Split(',').ToList<string>();
            foreach(string m in temp)
            {
                SPictures.Add(int.Parse(m));
            }
            return SPictures;
        }
    }

}