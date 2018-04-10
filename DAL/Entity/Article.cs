using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Article")]
    public class Article : BaseEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string ArticleId { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public string Creator { get; set; }
        public string Attachs { get; set; }
        //public int Status { get; set; }


        public virtual AspNetUsers User { get; set; }
    }
}
