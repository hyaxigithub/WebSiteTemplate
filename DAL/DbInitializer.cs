using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbInitializer
    {
        public static void Initial(LYProjectEntities db)
        {
            Article article = new Article();
            article.Title = "ddd";
            article.Profile = "dddd";
            article.Content = "ddddd";
            article.CreateTime = DateTime.Now;
            db.Set<Article>().Add(article);
            db.SaveChangesAsync();
        }
    }
}
