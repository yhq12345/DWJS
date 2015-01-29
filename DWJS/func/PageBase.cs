using System;
using System.Web.Security;
using System.Web.UI;
using System.Linq;
using Config = Eastcom.ConfigUntility;
using BLL = Eastcom.BLL;
using System.Collections.Generic;
using CommonClass.DataHandler;
using System.Web;
using System.Xml;
using Eastcom.Model;

    /// <summary>
    /// 页面层(表示层)基类,所有页面继承该页面
    /// </summary>
    public class PageBase : System.Web.UI.Page
    {
        public static readonly string CookieName = "userLogin_WJGL";// 用户登录cookie名
        /// <summary>
        /// Log4Net 配置
        /// </summary>
        public static log4net.ILog log = log4net.LogManager.GetLogger("LoggerConfig");

        /// <summary>
        /// 是否需要登录的验证
        /// </summary>
        public bool CheckPermission = false;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PageBase()
        {
            //this.Load+=new EventHandler(PageBase_Load);
        }
        protected override void OnInit(EventArgs e)
        {
            this.BaseInitData();

            #region 新加内容 by:xcl @08-01 添加页面类型的判断
            this.InitPageType(Request.Params[Convert.ToString(PageParamsName.type)] ?? "");
            this.InitPageMethod(Request.Params[Convert.ToString(PageParamsName.method)] ?? "");
            Int32.TryParse(Request.Params["page"] ?? "1", out this._pageIndex);
            #endregion

            base.OnInit(e);
            this.Load += new System.EventHandler(PageBase_Load);
            this.Error += new System.EventHandler(PageBase_Error);

            //if (!IsLogin)
            //{
            //    Response.Redirect("~/login.aspx", true);
            //}
        }

        //错误处理
        protected void PageBase_Error(object sender, System.EventArgs e)
        {
            string errMsg;
            Exception currentError = Server.GetLastError();
            errMsg = currentError.Message;
            
            string msg = string.Format("Url:{0}\r\nReferUrl:{1}\r\n", Request.Url, Request.UrlReferrer);
            PageBase.log.Error(msg, HttpContext.Current.Error);

            Config.ConfigFunc.GotoErrorPage(this.Page, errMsg);
            Server.ClearError();
        }
        private void PageBase_Load(object sender, EventArgs e)
        {

            // if (!Page.IsPostBack) 去掉原因:用户进入页面后，过期后进行操作。
            //登陆超时，或未登陆
            if (CheckPermission)
            {
                if (!(BLL.SessionConfig.IsLoginUser()))
                {
                    Config.ConfigFunc.GotoErrorPage(this.Page, Config.ConfigArgs.sysErrMsg_Login_TimeOut);
                }
                //else
                //{
                //    if (!new BLL.sys_RoleFunctionMapping().CanOperator(PermissionID))
                //    {
                //        Config.ConfigFunc.GotoErrorPage(this.Page, Config.ConfigArgs.sysErrMsg_Operate_Fail);
                //    }
                //}
                //}
            }
        }

        #region 登录相关
        /// <summary>
        /// true:已登录
        /// </summary>
        public bool IsLogin
        {
            get;
            set;
        }
        #endregion
        public static bool ValueMax(string Value, int max)
        {
            try
            {
                if (Value.Length > max)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsNumer(string Value)
        {
            try
            {
                Convert.ToInt32(Value);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool isDateTime(string Value)
        {
            try
            {
                Convert.ToDateTime(Value);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #region 新加内容  by:xcl @08-01
        public string GuidStr = string.Format("_{0}", Guid.NewGuid().ToString("N"));
        /// <summary>
        /// 网站根路径
        /// </summary>
        public static string Url
        {
            get
            {
                string m_ApplicationPath = HttpContext.Current.Request.ApplicationPath;
                if (String.IsNullOrEmpty(m_ApplicationPath))
                    m_ApplicationPath = "/";
                if (!m_ApplicationPath.EndsWith("/"))
                    m_ApplicationPath += "/";
                return m_ApplicationPath;
            }
        }

        #region 页面分页相关
        private int _pageSize = 10;
        private int _pageIndex = 1;//1为第一页
        public int RecordCount;//总记录数
        /// <summary>
        /// 每页最多显示的数目
        /// </summary>
        public int PageSize
        {
            get { return this._pageSize; }
            set { this._pageSize = value; }
        }

        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex
        {
            get { return this._pageIndex; }
            set { this._pageIndex = value; }
        }

        /// <summary>
        /// 初始化分页
        /// </summary>
        public void InitPager(Wuqi.Webdiyer.AspNetPager pager)
        {
            CommonClass.Control.Pagination.AspNetPager.AspNetPagerClass pageClass = new CommonClass.Control.Pagination.AspNetPager.AspNetPagerClass(pager);
            pageClass.PageIndex = this.PageIndex;
            pageClass.PageSize = this.PageSize;
            pageClass.RecordCount = this.RecordCount;
            pageClass.InitPager();
        }
      
        #endregion

        /// <summary>
        /// 导出条件session名
        /// </summary>
        public string StrWhereOutPutSessionName
        {
            get
            {
                return string.Format("o{0}", this.GuidStr);
            }
        }

        public string StrWhereOutPut
        {
            get
            {
                return Request.Params["StrWhereOutPut"] ?? "";
            }
        }

        #region 页面操作相关
        /// <summary>
        /// true:当前页面以AJAX执行
        /// </summary>
        public bool IsAjax
        {
            get;
            set;
        }
        /// <summary>
        /// 权限检查-地区
        /// </summary>
        /// <param name="parentName">父类名 如:(用户管理)</param>
        /// <param name="rightName">权限名,如:新增用户</param>
        /// <param name="isWriteMsg">停止当页执行并输出信息</param>
        /// <returns>ture:有权限</returns>
        public bool CheckRight(string parentName, string rightName, string UserArea, params bool[] isWriteMsg)
        {
            bool flag, flagarea, flagSum = false;
            Eastcom.Model.Sys_Power_Right rightModel = new Eastcom.BLL.Sys_Power_Right().GetModel(parentName, rightName);

            if (null != rightModel)
            {
                if (CurrentRightModelList != null)
                {
                    flag = this.CurrentRightModelList.Exists(m => m.RightID == rightModel.RightID);

                    flagarea = Config.BaseFunc.IsAreaRole(UserArea);
                    flagSum = flag || flagarea;
                }
            }
            else
            {
                throw new Exception(string.Format("县市权限{0},权限配置【{1}——{2}】不存在！", UserArea, parentName, rightName));
            }
            #region 没有权限的强制登陆
            if (!flagSum && null != isWriteMsg && isWriteMsg.Length > 0)
            {
                if (isWriteMsg[0])
                    NoRightsInfo();
            }
            #endregion
            return flagSum;
        }
        /// <summary>
        /// 权限检查--地区
        /// </summary>
        /// <param name="parentName">父类名 如:(用户管理)</param>
        /// <param name="rightName">权限名,如:新增用户</param>
        /// <param name="isWriteMsg">停止当页执行并输出信息</param>
        /// <returns>ture:有权限</returns>
        public bool CheckRight(string parentName, string rightName, params bool[] isWriteMsg)
        {
            bool flag = false;
            Eastcom.BLL.Sys_Power_Right rightBLL = new Eastcom.BLL.Sys_Power_Right();
            Eastcom.Model.Sys_Power_Right rightModel = rightBLL.GetModel(parentName, rightName);

            if (null != rightModel)
            {
                if (CurrentRightModelList != null)
                {
                    flag = this.CurrentRightModelList.Exists(m => m.RightID == rightModel.RightID);
                }
            }
            else
            {
                throw new Exception(string.Format("权限配置【{0}——{1}】不存在！", parentName, rightName));
            }
            #region 没有权限的强制登陆
            if (!flag && null != isWriteMsg && isWriteMsg.Length > 0)
            {
                if (isWriteMsg[0])
                    NoRightsInfo();
            }
            #endregion
            return flag;
        }

        /// <summary>
        /// 没有权限时输出信息
        /// </summary>
        public static void NoRightsInfo()
        {
            HttpContext con = HttpContext.Current;
            con.Response.Clear();
            con.Response.Write("对不起，您没有权限操作此页！可能是权限配置不正确，请及时联系管理员，谢谢！");
            con.Response.End();
        }


        /// <summary>
        /// 当前页面类型(EnumPageType的值)
        /// </summary>
        public EnumPageType PageType
        {
            get;
            set;
        }

        /// <summary>
        /// PageType传过来的值，如:"type=add",则此值为"add"
        /// </summary>
        public string PageTypeValue
        {
            get;
            set;
        }

        /// <summary>
        /// 页面类型枚举
        /// </summary>
        public enum EnumPageType
        {
            修改 = 0,
            添加 = 1,
            删除 = 2,
            其它 = 3,
            导入 = 4,
            导出 = 5,
            查看 = 6
        }

        /// <summary>
        /// 页面的参数
        /// </summary>
        public enum PageParamsName
        {
            /// <summary>
            /// 页面方法参数名（xxx.aspx?method=ajax）
            /// </summary>
            method = 0,
            /// <summary>
            /// 页面操作类型参数名（xxx.aspx?type=add）
            /// </summary>
            type = 1
        }

        /// <summary>
        /// 页面操作类型 新增:add  更新:update  删除:del
        /// </summary>
        public enum PageParamsTypeValue
        {
            /// <summary>
            /// 新增
            /// </summary>
            add = 0,
            /// <summary>
            /// 更新
            /// </summary>
            update = 1,
            /// <summary>
            /// 删除
            /// </summary>
            del = 2,
            /// <summary>
            /// 导入
            /// </summary>
            input = 3,
            /// <summary>
            /// 导出
            /// </summary>
            output = 4,
            /// <summary>
            /// 查看
            /// </summary>
            see = 5
        }

        /// <summary>
        /// 页面方法类型 异步:ajax
        /// </summary>
        public enum PageParamsMethodValue
        {
            /// <summary>
            /// 异步ajax
            /// </summary>
            ajax = 0
        }

        /// <summary>
        /// 初始页面类型
        /// </summary>
        /// <param name="type">PageParamsName中的type值</param>
        public virtual void InitPageType(string type)
        {
            this.PageTypeValue = string.IsNullOrEmpty(type) ? "" : type;
            if (string.Equals(this.PageTypeValue, Convert.ToString(PageParamsTypeValue.add), StringComparison.OrdinalIgnoreCase))
            {
                this.PageType = EnumPageType.添加;
            }
            else if (string.Equals(this.PageTypeValue, Convert.ToString(PageParamsTypeValue.del), StringComparison.OrdinalIgnoreCase))
            {
                this.PageType = EnumPageType.删除;
            }
            else if (string.Equals(this.PageTypeValue, Convert.ToString(PageParamsTypeValue.update), StringComparison.OrdinalIgnoreCase))
            {
                this.PageType = EnumPageType.修改;
            }
            else if (string.Equals(this.PageTypeValue, Convert.ToString(PageParamsTypeValue.input), StringComparison.OrdinalIgnoreCase))
            {
                this.PageType = EnumPageType.导入;
            }
            else if (string.Equals(this.PageTypeValue, Convert.ToString(PageParamsTypeValue.output), StringComparison.OrdinalIgnoreCase))
            {
                this.PageType = EnumPageType.导出;
            }
            else if (string.Equals(this.PageTypeValue, Convert.ToString(PageParamsTypeValue.see), StringComparison.OrdinalIgnoreCase))
            {
                this.PageType = EnumPageType.查看;
            }
            else
            {
                this.PageType = EnumPageType.其它;
            }
        }

        /// <summary>
        /// 初始化页面method的类型
        /// </summary>
        /// <param name="method">PageParamsMethodValue值</param>
        public virtual void InitPageMethod(string method)
        {
            method = string.IsNullOrEmpty(method) ? "" : method.ToLower();
            if (string.Equals(method, Convert.ToString(PageParamsMethodValue.ajax), StringComparison.OrdinalIgnoreCase))
            {
                this.IsAjax = true;
            }
        }

        /// <summary>
        /// 要导出的数据的列表信息
        /// </summary>
        public static List<OutPutClass> OutPutClassLst
        {
            get
            {
                List<OutPutClass> lst = new List<OutPutClass>();
                string configPath = HttpContext.Current.Server.MapPath("~/Config/Config.xml");
                XmlNodeList nodeList = CommonClass.XML.XMLHelper.GetXmlNodeListByXpath(configPath, "//Root//OutPut//Table");
                if (null != nodeList && nodeList.Count > 0)
                {
                    OutPutClass model = null;
                    foreach (XmlNode m in nodeList)
                    {
                        model = new OutPutClass();
                        model.tableName = (m.Attributes["tableName"]).Value.Trim();
                        List<OutPutField> lstFiled = new List<OutPutField>();
                        XmlNodeList fieldNodes = m.ChildNodes;
                        if (null != fieldNodes && fieldNodes.Count > 0)
                        {
                            OutPutField outPutFieldModel = null;
                            foreach (XmlNode n in fieldNodes)
                            {
                                outPutFieldModel = new OutPutField();
                                outPutFieldModel.newName = (n.Attributes["newName"]).Value.Trim();
                                outPutFieldModel.oldName = (n.Attributes["oldName"]).Value.Trim();
                                lstFiled.Add(outPutFieldModel);
                            }
                        }
                        model.fields = lstFiled;
                        lst.Add(model);
                    }
                }
                return lst;
            }
        }
        #endregion
        #endregion


        #region 添加内容 修改了用户--权限管理
        #region 当前登录用户信息
        /// <summary>
        /// 当前用户实体信息
        /// </summary>
        public v_Sys_User_Info CurrentUserModel
        {
            get;
            set;
        }

        /// <summary>
        /// 当前用户角色信息model list
        /// </summary>
        public List<Sys_Power_Role> CurrentRoleModelList
        {
            get;
            set;
        }

        /// <summary>
        /// 当前用户所拥有的所有权限model list
        /// </summary>
        public List<Sys_Power_Right> CurrentRightModelList
        {
            get;
            set;
        }
        #endregion
        #region 初始化
        /// <summary>
        /// 根据登录cookie初始化
        /// </summary>
        /// <returns></returns>
        public void BaseInitData()
        {
            bool loginFlag = false;
            string userId = CommonClass.StringHander.Common.GetCookies(CookieName);
            //string userId = BLL.SessionConfig.GetUserID().ToString();
            if (!string.IsNullOrEmpty(userId))
            {
                Eastcom.Model.v_Sys_User_Info uModel = new Eastcom.BLL.v_Sys_User_Info().GetModel(CommonClass.StringHander.Common.GetInt(userId));

                if (null != uModel)
                {
                    this.CurrentUserModel = uModel;

                    loginFlag = true;
                    Eastcom.BLL.Sys_Power_Role roleBLL = new Eastcom.BLL.Sys_Power_Role();
                    Eastcom.BLL.Sys_Power_Right rightBLL = new Eastcom.BLL.Sys_Power_Right();

                    //1：当前用户角色初始化
                    this.CurrentRoleModelList = roleBLL.GetModelListByUserId(this.CurrentUserModel.UserID);
                    //2：当前用户权限初始化
                    List<Eastcom.Model.Sys_Power_Right> rightLst = new List<Sys_Power_Right>();
                    List<Eastcom.Model.Sys_Power_Right> rightTempLst = new List<Sys_Power_Right>();
                    /*角色——权限*/
                    if (null != this.CurrentRoleModelList && this.CurrentRoleModelList.Count > 0)
                    {
                        foreach (Eastcom.Model.Sys_Power_Role m in this.CurrentRoleModelList)
                        {
                            rightTempLst = rightBLL.GetModelListByRoleID(m.RoleID);
                            if (null != rightTempLst && rightTempLst.Count > 0)
                            {
                                rightLst.AddRange(rightTempLst);
                            }
                        }
                    }
                    /*用户——权限*/
                    rightTempLst = rightBLL.GetModelListByUserID(this.CurrentUserModel.UserID);
                    if (null != rightTempLst && rightTempLst.Count > 0)
                    {
                        rightLst.AddRange(rightTempLst);
                    }
                    if (null != rightLst && rightLst.Count > 0)
                    {
                        rightLst = rightLst.Distinct().ToList();
                        this.CurrentRightModelList = rightLst;
                    }
                }
            }

            //this.IsLogin = loginFlag;
        }
        #endregion
        #endregion
    }
