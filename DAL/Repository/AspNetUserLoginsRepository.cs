using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using System.Data;
using System.Linq.Dynamic;

namespace DAL
{
    /// <summary>
    /// AspNetUserLogins
    /// </summary>
    public partial class AspNetUserLoginsRepository : BaseRepository<AspNetUserLogins>, IDisposable
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
        public IQueryable<AspNetUserLogins> DaoChuData(LYProjectEntities db, string order, string sort, string search, params object[] listQuery)
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
                    
                    
                    if (queryDic.ContainsKey("UserId") && !string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Value == "noway" && item.Key == "UserId")
                    {//查询一对多关系的列名
                        where += "it.UserId is null";
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
                         where += "it." + item.Key.Remove(item.Key.IndexOf(End_String)) + " = '" + item.Value +"'";
                         continue;
                     }

                     if (!string.IsNullOrWhiteSpace(item.Key) && !string.IsNullOrWhiteSpace(item.Value) && item.Key.Contains(DDL_String)) //需要查询的列名
                     {
                         where += "it." + item.Key.Remove(item.Key.IndexOf(DDL_String)) + " = '" + item.Value +"'";
                         continue;
                     }
                    where += "it." + item.Key + " like '%" + item.Value + "%'";
                }
            }
            return db.AspNetUserLogins
                     .Where(string.IsNullOrEmpty(where) ? "true" : where)
                     .OrderBy("it." + sort.GetString() + " " + order.GetString())
                     .AsQueryable(); 

        }
        /// <summary>
        /// 通过主键id，获取AspNetUserLogins---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>AspNetUserLogins</returns>
        public AspNetUserLogins GetById(string id)
        {
            using (LYProjectEntities db = new LYProjectEntities())
            {
                return GetById(db, id);
            }                   
        }
        /// <summary>
        /// 通过主键id，获取AspNetUserLogins---查看详细，首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>AspNetUserLogins</returns>
        public AspNetUserLogins GetById(LYProjectEntities db, string id)
        { 
            return db.AspNetUserLogins.SingleOrDefault(s => s.LoginProvider == id);
        
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
        /// 删除一个AspNetUserLogins
        /// </summary>
        /// <param name="db">实体数据</param>
        /// <param name="id">一条AspNetUserLogins的主键</param>
        public void Delete(LYProjectEntities db, string id)
        {
            AspNetUserLogins deleteItem = GetById(db, id);
            if (deleteItem != null)
            { 
                db.AspNetUserLogins.Remove(deleteItem);
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
            IQueryable<AspNetUserLogins> collection = from f in db.AspNetUserLogins
                    where deleteCollection.Contains(f.LoginProvider)
                    select f;
            foreach (var deleteItem in collection)
            {
                db.AspNetUserLogins.Remove(deleteItem);
            }
        }

        /// <summary>
        /// 根据UserId，获取所有AspNetUserLogins数据
        /// </summary>
        /// <param name="id">外键的主键</param>
        /// <returns></returns>
        public IQueryable<AspNetUserLogins> GetByRefUserId(LYProjectEntities db, string id)
        {
            return from c in db.AspNetUserLogins
                        where c.UserId == id
                        select c;
                      
        }

        public void Dispose()
        {          
        }
    }
}

