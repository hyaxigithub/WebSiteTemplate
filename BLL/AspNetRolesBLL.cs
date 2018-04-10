using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using DAL;
using Common;

namespace BLL
{
    /// <summary>
    /// AspNetRoles 
    /// </summary>
    public partial  class AspNetRolesBLL : IBLL.IAspNetRolesBLL, IDisposable
    {
        /// <summary>
        /// 私有的数据访问上下文
        /// </summary>
        protected LYProjectEntities db;
        /// <summary>
        /// AspNetRoles的数据库访问对象
        /// </summary>
        AspNetRolesRepository repository = new AspNetRolesRepository();
        /// <summary>
        /// 构造函数，默认加载数据访问上下文
        /// </summary>
        public AspNetRolesBLL()
        {
            db = new LYProjectEntities();
        }
        /// <summary>
        /// 已有数据访问上下文的方法中调用
        /// </summary>
        /// <param name="entities">数据访问上下文</param>
        public AspNetRolesBLL(LYProjectEntities entities)
        {
            db = entities;
        }
        /// <summary>
        /// 查询的数据
        /// </summary>
        /// <param name="id">额外的参数</param>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <param name="total">结果集的总数</param>
        /// <returns>结果集</returns>
        public List<AspNetRoles> GetByParam(string id, int page, int rows, string order, string sort, string search, ref int total)
        {

            
            IQueryable<AspNetRoles> queryData = repository.DaoChuData(db, order, sort, search);
            total = queryData.Count();
            if (total > 0)
            {
                if (page <= 1)
                {
                    queryData = queryData.Take(rows);
                }
                else
                {
                    queryData = queryData.Skip((page - 1) * rows).Take(rows);
                }
                
                    //foreach (var item in queryData) 
                    //{ 
                    //    if (item.AspNetUsers != null)
                    //    {
                    //        item.AspNetUsersId = string.Empty;
                    //        foreach (var it in item.AspNetUsers)
                    //        {
                    //            item.AspNetUsersId += it.Email + ' ';
                    //        }                         
                    //    } 

                    //}
 
            }
            return queryData.ToList();
        }
        
        /// <summary>
        /// 创建一个AspNetRoles
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据库上下文</param>
        /// <param name="entity">一个AspNetRoles</param>
        /// <returns></returns>
       public bool Create(ref ValidationErrors validationErrors, LYProjectEntities db, AspNetRoles entity)
        {   
            int count = 1;
        
            foreach (string item in entity.AspNetUsers.Select(x=>x.Id))
            {
                AspNetUsers sys = new AspNetUsers { Id = item };
                db.AspNetUsers.Attach(sys);
                entity.AspNetUsers.Add(sys);
                count++;
            }

            repository.Create(db, entity);
            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("创建出错了");
            }
            return false;
        }
        /// <summary>
        /// 创建一个AspNetRoles
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个AspNetRoles</param>
        /// <returns></returns>
        public bool Create(ref ValidationErrors validationErrors, AspNetRoles entity)
        {
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                { 
                    if (Create(ref validationErrors, db, entity))
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建AspNetRoles集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">AspNetRoles集合</param>
        /// <returns></returns>
        public bool CreateCollection(ref ValidationErrors validationErrors, IQueryable<AspNetRoles> entitys)
        {
            try
            {
                if (entitys != null)
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Create(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }

      /// <summary>
        /// 删除一个AspNetRoles
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="id">一个AspNetRoles的主键</param>
        /// <returns></returns>  
        public bool Delete(ref ValidationErrors validationErrors, string id)
        {
            try
            {
                return repository.Delete(id) == 1;
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        /// 删除AspNetRoles集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="deleteCollection">主键的AspNetRoles</param>
        /// <returns></returns>    
        public bool DeleteCollection(ref ValidationErrors validationErrors, string[] deleteCollection)
        {
            try
            {
                if (deleteCollection != null)
                { 

                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            repository.Delete(db, deleteCollection);
                            if (deleteCollection.Length == repository.Save(db))
                            {
                                transactionScope.Complete();
                                return true;
                            }
                            else
                            {
                                Transaction.Current.Rollback();
                            }
                        }
                    
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        /// <summary>
        ///  创建AspNetRoles集合
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entitys">AspNetRoles集合</param>
        /// <returns></returns>
        public bool EditCollection(ref ValidationErrors validationErrors, IQueryable<AspNetRoles> entitys)
        {
            if (entitys != null)
            {
                try
                {
                    int flag = 0, count = entitys.Count();
                    if (count > 0)
                    {
                        using (TransactionScope transactionScope = new TransactionScope())
                        {
                            foreach (var entity in entitys)
                            {
                                if (Edit(ref validationErrors, db, entity))
                                {
                                    flag++;
                                }
                                else
                                {
                                    Transaction.Current.Rollback();
                                    return false;
                                }
                            }
                            if (count == flag)
                            {
                                transactionScope.Complete();
                                return true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    validationErrors.Add(ex.Message);
                    ExceptionsHander.WriteExceptions(ex);                
                }
            }
            return false;
        }
        /// <summary>
        /// 编辑一个AspNetRoles
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="db">数据上下文</param>
        /// <param name="entity">一个AspNetRoles</param>
        /// <returns>是否编辑成功</returns>
       public bool Edit(ref ValidationErrors validationErrors, LYProjectEntities db, AspNetRoles entity)
        {  /*                       
                           * 不操作 原有 现有
                           * 增加   原没 现有
                           * 删除   原有 现没
                           */
            if (entity == null)
            {
                return false;
            }
            int count = 1;
            AspNetRoles editEntity = repository.Edit(db, entity);
            
            List<string> addAspNetUsersId = new List<string>();
            List<string> deleteAspNetUsersId = new List<string>();
            DataOfDiffrent.GetDiffrent(entity.AspNetUsers.Select(x=>x.Id).ToList(), entity.AspNetUsers.Select(x => x.Id).ToList(), ref addAspNetUsersId, ref deleteAspNetUsersId);
            if (addAspNetUsersId != null && addAspNetUsersId.Count() > 0)
            {
                foreach (var item in addAspNetUsersId)
                {
                    AspNetUsers sys = new AspNetUsers { Id = item };
                    db.AspNetUsers.Attach(sys);
                    editEntity.AspNetUsers.Add(sys);
                    count++;
                }
            }
            if (deleteAspNetUsersId != null && deleteAspNetUsersId.Count() > 0)
            {
                List<AspNetUsers> listEntity = new List<AspNetUsers>();
                foreach (var item in deleteAspNetUsersId)
                {
                    AspNetUsers sys = new AspNetUsers { Id = item };
                    listEntity.Add(sys);
                    db.AspNetUsers.Attach(sys);
                }
                foreach (AspNetUsers item in listEntity)
                {
                    editEntity.AspNetUsers.Remove(item);//查询数据库
                    count++;
                }
            } 

            if (count == repository.Save(db))
            {
                return true;
            }
            else
            {
                validationErrors.Add("编辑AspNetRoles出错了");
            }
            return false;
        }
        /// <summary>
        /// 编辑一个AspNetRoles
        /// </summary>
        /// <param name="validationErrors">返回的错误信息</param>
        /// <param name="entity">一个AspNetRoles</param>
        /// <returns>是否编辑成功</returns>
        public bool Edit(ref ValidationErrors validationErrors, AspNetRoles entity)
        {           
            try
            {
                using (TransactionScope transactionScope = new TransactionScope())
                { 
                    if (Edit(ref validationErrors, db, entity))
                    {
                        transactionScope.Complete();
                        return true;
                    }
                    else
                    {
                        Transaction.Current.Rollback();
                    }
                }
            }
            catch (Exception ex)
            {
                validationErrors.Add(ex.Message);
                ExceptionsHander.WriteExceptions(ex);                
            }
            return false;
        }
        public List<AspNetRoles> GetAll()
        {            
            return repository.GetAll(db).ToList();          
        }     
        
        /// <summary>
        /// 根据主键获取一个AspNetRoles
        /// </summary>
        /// <param name="id">AspNetRoles的主键</param>
        /// <returns>一个AspNetRoles</returns>
        public AspNetRoles GetById(string id)
        {          
            return repository.GetById(db, id);           
        }
        
        /// <summary>
        /// 获取在该表一条数据中，出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<AspNetUsers> GetRefAspNetUsers(string id)
        { 
            return repository.GetRefAspNetUsers(db, id).ToList();
        }
        /// <summary>
        /// 获取在该表中出现的所有外键实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>外键实体集合</returns>
        public List<AspNetUsers> GetRefAspNetUsers()
        { 
            return repository.GetRefAspNetUsers(db).ToList();
        }

        
        public void Dispose()
        {
           
        }
    }
}

