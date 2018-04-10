using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Common;
using System.Data;
namespace DAL
{
    /// <summary>
    /// Article
    /// </summary>
    public partial class ArticleRepository : BaseRepository<Article>, IDisposable
    {
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="LYProjectEntities">数据访问的上下文</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param> 
        /// <param name="listQuery">额外的参数</param>
        /// <returns></returns>      
        public IQueryable<Article> DaoChuData(LYProjectEntities db, string order, string sort, string search, params object[] listQuery)
        {
            string where = string.Empty;
            int flagWhere = 0;

            Dictionary<string, string> queryDic = ValueConvert.StringToDictionary(search.GetString());
            if (queryDic != null && queryDic.Count > 0)
            {
                foreach (var item in queryDic)
                {
                    if (flagWhere != 0)
                    {
                        where += " and ";
                    }
                    flagWhere++;



                    if (queryDic.ContainsKey("Article") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key == "Article")
                    {//查询多对多关系的列名
                        where += "EXISTS(select p from it.Article as p where p.ArticleId='" + item.Value + "')";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Time)) //需要查询的列名
                    {
                        where += "it. " + item.Key.Remove(item.Key.IndexOf(Start_Time)) + " >=  CAST('" + item.Value + "' as   System.DateTime)";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Time)) //需要查询的列名
                    {
                        where += "it." + item.Key.Remove(item.Key.IndexOf(End_Time)) + " <  CAST('" + Convert.ToDateTime(item.Value).AddDays(1) + "' as   System.DateTime)";
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(Start_Int)) //需要查询的列名
                    {
                        where += "it." + item.Key.Remove(item.Key.IndexOf(Start_Int)) + " >= " + item.Value.GetInt();
                        continue;
                    }
                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_Int)) //需要查询的列名
                    {
                        where += "it." + item.Key.Remove(item.Key.IndexOf(End_Int)) + " <= " + item.Value.GetInt();
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(End_String)) //需要查询的列名
                    {
                        where += "it." + item.Key.Remove(item.Key.IndexOf(End_String)) + " = '" + item.Value + "'";
                        continue;
                    }

                    if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_String)) //需要查询的列名
                    {
                        where += "it." + item.Key.Remove(item.Key.IndexOf(DDL_String)) + " = '" + item.Value + "'";
                        continue;
                    }
                    where += "it." + item.Key + " like '%" + item.Value + "%'";
                }
            }
            Func<string, bool> A = it => it == where;
            return db.Articles
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + sort.GetString() + " " + order.GetString())
                     .AsQueryable();

        }
        /// <summary>
        /// 通过主键id，获取Article---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>Article</returns>
        public Article GetById(string id)
        {
            using (LYProjectEntities db = new LYProjectEntities())
            {
                return GetById(db, id);
            }
        }
        /// <summary>
        /// 通过主键id，获取Article---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>Article</returns>
        public Article GetById(LYProjectEntities db, string id)
        {
            return db.Articles.SingleOrDefault(s => s.ArticleId == id);
        }

        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<Article> GetRefArticle(string id)
        {
            using (LYProjectEntities db = new LYProjectEntities())
            {
                return GetRefArticle(db, id);
            }
        }
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<Article> GetRefArticle(LYProjectEntities db, string id)
        {
            return from m in db.Articles
                   from f in db.AspNetUsers
                   where m.User.Id == id
                   select m;

        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<Article> GetRefArticle(LYProjectEntities db)
        {
            return from m in db.Articles
                   select m;
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public IQueryable<Article> GetRefArticle()
        {
            using (LYProjectEntities db = new LYProjectEntities())
            {
                return GetRefArticle(db);
            }
        }


        /// <summary>
        /// 确定删除一个对象，调用Save方法
        /// </summary>
        /// <param name="id">一条数据的主键</param>
        /// <returns></returns>    
        public int Delete(string id)
        {
            using (LYProjectEntities db = new LYProjectEntities())
            {
                this.Delete(db, id);
                return Save(db);
            }
        }
        /// <summary>
        /// 删除一个Article
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条Article的主键</param>
        public void Delete(LYProjectEntities db, string id)
        {
            Article deleteItem = GetById(db, id);
            if (deleteItem != null)
            {
                db.Articles.Remove(deleteItem);
            }
        }
        /// <summary>
        /// 删除对象集合
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="deleteCollection">主键的集合</param>
        public void Delete(LYProjectEntities db, string[] deleteCollection)
        {
            //数据库设置级联关系，自动删除子表的内容   
            IQueryable<Article> collection = from f in db.Articles
                                             where deleteCollection.Contains(f.ArticleId)
                                             select f;
            foreach (var deleteItem in collection)
            {
                db.Articles.Remove(deleteItem);
            }
        }

        public void Dispose()
        {
        }
    }
}

