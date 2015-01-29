using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using Eastcom.Model;

namespace Eastcom.BLL
{
    public class SessionConfig
    {
        //获取登陆用户信息
        public static readonly string CookieName = "userLogin_WJGL";// 用户登录cookie名
        //public  Eastcom.Model.v_Sys_User_Info uModel = null;


        public SessionConfig()
        {
            //return uModel;
        }
        public static Eastcom.Model.v_Sys_User_Info GetuModelCookies()
        {
            Eastcom.Model.v_Sys_User_Info uModel = null;
            string userId = CommonClass.StringHander.Common.GetCookies(CookieName);
            if (!string.IsNullOrEmpty(userId))
            {
                uModel = new Eastcom.BLL.v_Sys_User_Info().GetModel(CommonClass.StringHander.Common.GetInt(userId));
            }
            return uModel;
        }

        public static Eastcom.Model.v_Sys_User_Info GetUserInfo()
        {
            Eastcom.Model.v_Sys_User_Info uModel=GetuModelCookies();
            return uModel;
        }

        //清除用户的信息 
        public static void ClearUserInfo()
        {
            CommonClass.StringHander.Common.DelCookies(CookieName);
        }

        //设置登陆用户信息--用户信息的初始化 登录成功后执行
        public static void SetUserInfo(Model.v_Sys_User_Info model)
        {
            if (CommonClass.StringHander.Common.SetCookies(CookieName, model.UserID.ToString(), 30))
            {
                //XCLNetTools.Cache.CacheClass.Clear(string.Format("RightCacheName_{0}", model.UserID.ToString()));
            }

        }


        // 是否登陆状态
        public static bool IsLoginUser()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel != null)
                return true;
            else
                return false;
        }
        // 获取用户真实名
        public static string GetUserRealName()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel == null)
                return "";
            else
                return uModel.RealName;
        }
        // 获取用户真实名
        public static string GetUserPwd()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel == null)
                return "";
            else
                return uModel.Pwd;
        }

        // 获取用户地区
        public static string GetUserArea()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel == null)
                return "";
            else
                return uModel.UserMangerArea;
        }


        /// <summary>
        /// 获取角色ID 编号
        /// </summary>
        /// <returns></returns>
        public static int GetUserID()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel == null)
                return -1;
            else
                return uModel.UserID;
        }

        /// <summary>
        /// 获取角色ID 编号
        /// </summary>
        /// <returns></returns>
        public static string GetRoleName()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel == null)
                return "";
            else
                return uModel.角色名;
        }
        /// <summary>
        /// 获取角色名
        /// </summary>
        /// <returns></returns>
        public static string GetRoleID()
        {
            Eastcom.Model.v_Sys_User_Info uModel = GetuModelCookies();
            if (uModel == null)
                return "";
            else
                return uModel.角色ID;
        }

    }
}
