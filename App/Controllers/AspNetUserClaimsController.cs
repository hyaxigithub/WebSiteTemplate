﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.EnterpriseServices;
using System.Configuration;
using Models;
using Common;
using DAL;
using BLL;
using App.Models;

namespace yl.App.Controllers
{
    /// <summary>
    /// AspNetUserClaims
    /// </summary>
    public class AspNetUserClaimsController : BaseController
    {

        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Index()
        {
        
            return View();
        }
         /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        public ActionResult IndexSef()
        {

            return View();
        }
        /// <summary>
        /// 异步加载数据
        /// </summary>
        /// <param name="page">页码</param>
        /// <param name="rows">每页显示的行数</param>
        /// <param name="order">排序字段</param>
        /// <param name="sort">升序asc（默认）还是降序desc</param>
        /// <param name="search">查询条件</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetData(int? id, int page, int rows, string order, string sort, string search)
        {

            int total = 0;
            List<AspNetUserClaims> queryData = m_BLL.GetByParam(id, page, rows, order, sort, search, ref total);
            return Json(new datagrid
            {
                total = total,
                rows = queryData.Select(s => new
                {
                    Id = s.Id
					//,UserId =   s.UserIdOld
					,ClaimType = s.ClaimType
					,ClaimValue = s.ClaimValue
					
                }

                    )
            });
        }
        /// <summary>
        /// 查看详细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [SupportFilter]  
        public ActionResult Details(int id)
        {
            AspNetUserClaims item = m_BLL.GetById(id);
            return View(item);

        }
 
        /// <summary>
        /// 首次创建
        /// </summary>
        /// <returns></returns>
        [SupportFilter]
        public ActionResult Create(string id)
        { 
            
            return View();
        }
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult Create(AspNetUserClaims entity)
        {           
            if (entity != null && ModelState.IsValid)
            {
                string currentPerson = GetCurrentPerson();
                //entity.CreateTime = DateTime.Now;
                //entity.CreatePerson = currentPerson;
              
                   
                string returnValue = string.Empty;
                if (m_BLL.Create(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.InsertSucceed  + "，AspNetUserClaims的信息的Id为" + entity.Id,"AspNetUserClaims"
                        );//写入日志 
                    return Json(Suggestion.InsertSucceed);
                }
                else
                { 
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.InsertFail + "，AspNetUserClaims的信息，" + returnValue,"AspNetUserClaims"
                        );//写入日志                      
                    return Json(Suggestion.InsertFail  + returnValue); //提示插入失败
                }
            }

            return Json(Suggestion.InsertFail + "，请核对输入的数据的格式"); //提示输入的数据的格式不对 
        }
        /// <summary>
        /// 首次编辑
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns> 
        [SupportFilter] 
        public ActionResult Edit(int id)
        {
            AspNetUserClaims item = m_BLL.GetById(id);
            return View(item);
        }
        /// <summary>
        /// 提交编辑信息
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="collection">客户端传回的集合</param>
        /// <returns></returns>
        [HttpPost]
        [SupportFilter]
        public ActionResult Edit(int id, AspNetUserClaims entity)
        {
            if (entity != null && ModelState.IsValid)
            {   //数据校验
            
                string currentPerson = GetCurrentPerson();                 
                //entity.UpdateTime = DateTime.Now;
                //entity.UpdatePerson = currentPerson;
                           
                string returnValue = string.Empty;   
                if (m_BLL.Edit(ref validationErrors, entity))
                {
                    LogClassModels.WriteServiceLog(Suggestion.UpdateSucceed + "，AspNetUserClaims信息的Id为" + id,"AspNetUserClaims"
                        );//写入日志                           
                    return Json(Suggestion.UpdateSucceed); //提示更新成功 
                }
                else
                { 
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.UpdateFail + "，AspNetUserClaims信息的Id为" + id + "," + returnValue, "AspNetUserClaims"
                        );//写入日志                           
                    return Json(Suggestion.UpdateFail  + returnValue); //提示更新失败
                }
            }
            return Json(Suggestion.UpdateFail + "请核对输入的数据的格式"); //提示输入的数据的格式不对               
          
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>   
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            string returnValue = string.Empty;
            int[] deleteId = collection["query"].GetString().Split(',').Select(s => Convert.ToInt32(s)).ToArray();
            if (deleteId != null && deleteId.Length > 0)
            { 
                if (m_BLL.DeleteCollection(ref validationErrors, deleteId))
                {
                    LogClassModels.WriteServiceLog(Suggestion.DeleteSucceed + "，信息的Id为" + string.Join(",", deleteId), "消息"
                        );//删除成功，写入日志
                    return Json("OK");
                }
                else
                {
                    if (validationErrors != null && validationErrors.Count > 0)
                    {
                        validationErrors.All(a =>
                        {
                            returnValue += a.ErrorMessage;
                            return true;
                        });
                    }
                    LogClassModels.WriteServiceLog(Suggestion.DeleteFail + "，信息的Id为" + string.Join(",", deleteId)+ "," + returnValue, "消息"
                        );//删除失败，写入日志
                }
            }
            return Json(returnValue);
        }
     
        IBLL.IAspNetUserClaimsBLL m_BLL;

        ValidationErrors validationErrors = new ValidationErrors();

        public AspNetUserClaimsController()
            : this(new AspNetUserClaimsBLL()) { }

        public AspNetUserClaimsController(AspNetUserClaimsBLL bll)
        {
            m_BLL = bll;
        }
        
    }
}

