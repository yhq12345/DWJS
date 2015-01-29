using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

namespace Eastcom.ConfigUntility
{
    public abstract class ConfigFunc
    {



        #region 文件上传
        /// <summary>
        /// 上传类型错误
        /// </summary> 
        public static string UpLoadFile_ExtendError()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("UpLoadFileExtendError");
        }

        /// <summary>
        /// 上传图片扩展名
        /// </summary> 
        public static bool UpLoadFile_IsValidImgExtend(string type)
        {
            string imgExtend = Eastcom.Common.ConfigHelper.GetConfigString("UpLoadFileImgExtend");
            string[] imgExtendList = imgExtend.Split('|');
            bool isValid = false;
            for (int i = 0; i < imgExtendList.Length; i++)
            {
                if (type == imgExtendList[i])
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }


        #endregion

        #region 页面错误信息
        /// <summary>
        /// 跳转错误页
        /// </summary>
        public static void GotoErrorPage(System.Web.UI.Page page, string errorMsg)
        {
            page.Response.Redirect(ConfigArgs.sysErrPage + "?&errorMsg=" + System.Web.HttpContext.Current.Server.UrlEncode((errorMsg.Replace("\n", "")).Replace("\r", "")));
        }

        #endregion 页面错误信息

        #region 数据处理

        /// <summary>
        /// 未找到符合要求的数据 
        /// </summary> 
        public static string DataQueryNoData()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("QueryNoData");
        }

        /// <summary>
        /// 数据已经存在
        /// </summary> 
        public static string DataExistsData()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("ExistsData");
        }

        /// <summary>
        /// 添加数据成功 
        /// </summary> 
        public static string DataAddSuccess()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("AddSuccess");
        }

        /// <summary>
        /// 添加数据失败 
        /// </summary> 
        public static string DataAddFail()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("AddFail");
        }


        /// <summary>
        /// 修改数据成功 
        /// </summary> 
        public static string DataModifySuccess()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("ModifySuccess");
        }

        /// <summary>
        /// 修改数据失败 
        /// </summary> 
        public static string DataModifyFail()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("ModifyFail");
        }

        /// <summary>
        /// 删除数据成功 
        /// </summary> 
        public static string DataDeleteSuccess()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("DeleteSuccess");
        }

        /// <summary>
        /// 删除数据失败 
        /// </summary> 
        public static string DataDeleteFail()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("DeleteFail");
        }

        #endregion

        #region  人员

        /// <summary>
        /// 人员工作状态：文本
        /// </summary> 
        public static string MemWorkStateText(int state)
        {
            switch (state)
            {
                //未上岗
                case ConfigArgs.memWorkStateValue_UnUsed: return ConfigArgs.memWorkStateText_UnUsed;
                //在岗
                case ConfigArgs.memWorkStateValue_OnWork: return ConfigArgs.memWorkStateText_OnWork;
                //短假
                case ConfigArgs.memWorkStateValue_ShortLeave: return ConfigArgs.memWorkStateText_ShortLeave;
                //长假
                case ConfigArgs.memWorkStateValue_LongLeave: return ConfigArgs.memWorkStateText_LongLeave;
                //调离
                case ConfigArgs.memWorkStateValue_Transfer: return ConfigArgs.memWorkStateText_Transfer;
                //回岗
                case ConfigArgs.memWorkStateValue_BackWork: return ConfigArgs.memWorkStateText_BackWork;
                default: return "";
            }

        }

        /// <summary>
        /// 人员工作状态：值
        /// </summary>
        public static int MemWorkStateValue(string stateText)
        {
            switch (stateText)
            {
                //未上岗
                case ConfigArgs.memWorkStateText_UnUsed: return ConfigArgs.memWorkStateValue_UnUsed;
                //在岗
                case ConfigArgs.memWorkStateText_OnWork: return ConfigArgs.memWorkStateValue_OnWork;
                //短假
                case ConfigArgs.memWorkStateText_ShortLeave: return ConfigArgs.memWorkStateValue_ShortLeave;
                //长假
                case ConfigArgs.memWorkStateText_LongLeave: return ConfigArgs.memWorkStateValue_LongLeave;
                //调离
                case ConfigArgs.memWorkStateText_Transfer: return ConfigArgs.memWorkStateValue_Transfer;
                //回岗
                case ConfigArgs.memWorkStateText_BackWork: return ConfigArgs.memWorkStateValue_BackWork;
                default: return -1;
            }
        }
        /// <summary>
        /// 人员性别
        /// </summary>
        public static string MemSexText(int sexValue)
        {
            switch (sexValue)
            {
                case ConfigArgs.memSexValue_Man: return ConfigArgs.memSexText_Man;
                case ConfigArgs.memSexValue_WoMan: return ConfigArgs.memSexText_WoMan;
                default: return "";
            }
        }


        #endregion

        #region 审核

        /// <summary>
        ///  审核状态：未审核、驳回、待复审、通过、异常状态
        /// </summary>
        public static string AudtiStateText(int state)
        {
            switch (state)
            {
                case ConfigArgs.auditStateValue_UnAudit: return ConfigArgs.auditStateText_UnAudit;
                case ConfigArgs.auditStateValue_Reject: return ConfigArgs.auditStateText_Reject;
                case ConfigArgs.auditStateValue_ReAudit: return ConfigArgs.auditStateText_ReAudit;
                case ConfigArgs.auditStateValue_Pass: return ConfigArgs.auditStateText_Pass;
                default: return "";
            }
        }
        /// <summary>
        ///  审核状态：未审核、驳回、待复审、通过、异常状态
        /// </summary>
        public static string AudtiStateText(string stateValue)
        {
            int state = -1;
            if (stateValue == string.Empty)
                return "";
            else
                state = int.Parse(stateValue);
            switch (state)
            {
                case ConfigArgs.auditStateValue_UnAudit: return ConfigArgs.auditStateText_UnAudit;
                case ConfigArgs.auditStateValue_Reject: return ConfigArgs.auditStateText_Reject;
                case ConfigArgs.auditStateValue_ReAudit: return ConfigArgs.auditStateText_ReAudit;
                case ConfigArgs.auditStateValue_Pass: return ConfigArgs.auditStateText_Pass;
                default: return "";
            }
        }
        #endregion

        #region 车辆信息


        /// <summary>
        /// 车辆状态：文本
        /// </summary> 
        public static string CarStateText(int state)
        {
            switch (state)
            {
                //未使用
                case ConfigArgs.carStateValue_UnUsed: return ConfigArgs.carStateText_UnUsed;
                //调入
                case ConfigArgs.carStateValue_TransferIn: return ConfigArgs.carStateText_TransferIn;
                //调出
                case ConfigArgs.carStateValue_TransferOut: return ConfigArgs.carStateText_TransferOut;
                //更改
                case ConfigArgs.carStateValue_Changed: return ConfigArgs.carStateText_Changed;
                default: return "";
            }
        }

        #endregion

        #region 字典库信息
        /// <summary>
        /// 创建字典库DataTable 一个空表
        /// </summary> 
        public static DataTable DicCreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("text");
            dt.Columns.Add("value");
            return dt;
        }

        /// <summary>
        /// 人员状态
        /// </summary> 
        public static DataTable DicGetMemState()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr = dt.NewRow();
            //设置text：未上岗
            dr[0] = ConfigArgs.memWorkStateText_UnUsed;
            //设置value：未上岗
            dr[1] = ConfigArgs.memWorkStateValue_UnUsed;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            //设置text：长假
            dr[0] = ConfigArgs.memWorkStateText_LongLeave;
            //设置value：长假
            dr[1] = ConfigArgs.memWorkStateValue_LongLeave;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            //设置text：调离
            dr[0] = ConfigArgs.memWorkStateText_Transfer;
            //设置value：调离
            dr[1] = ConfigArgs.memWorkStateValue_Transfer;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            //设置text：回岗
            dr[0] = ConfigArgs.memWorkStateText_BackWork;
            //设置value：回岗
            dr[1] = ConfigArgs.memWorkStateValue_BackWork;
            dt.Rows.Add(dr);

            return dt;
        }

        /// <summary>
        /// 请假类型
        /// </summary> 
        public static DataTable DicGetMemState_LeaveType()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr = dt.NewRow();
            //设置text：短假
            dr[0] = ConfigArgs.memWorkStateText_ShortLeave;
            //设置value：短假
            dr[1] = ConfigArgs.memWorkStateValue_ShortLeave;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            //设置text：长假
            dr[0] = ConfigArgs.memWorkStateText_LongLeave;
            //设置value：长假
            dr[1] = ConfigArgs.memWorkStateValue_LongLeave;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 调度 
        /// </summary>
        public static DataTable DicGetMemState_Transfer()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr = dt.NewRow();
            //设置text：调离
            dr[0] = ConfigArgs.memWorkStateText_Transfer;
            //设置value：调离
            dr[1] = ConfigArgs.memWorkStateValue_Transfer;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            //设置text：回岗
            dr[0] = ConfigArgs.memWorkStateText_BackWork;
            //设置value：回岗
            dr[1] = ConfigArgs.memWorkStateValue_BackWork;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 人员地区
        /// </summary>
        public static DataTable DicGetMemArea()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_LC;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_LW;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_OH;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_RA;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_PY;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_CN;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_YQ;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_WC;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_DT;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_YJ;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_TS;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 配置是否交接代维
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="IsClear"></param>
        public static void InidlltoIsToManaged(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Clear();

            }

            ddl.Items.Add(new ListItem("请选择", "")); //名称 ,d=值0就是它绑定 SelectedIndex
            ddl.Items.Add(new ListItem("是", "是"));
            ddl.Items.Add(new ListItem("否", "否"));
        }
        /// <summary>
        /// 配置站点类型
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="IsClear"></param>
        public static void InidllODFType(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Clear();
            }
            ddl.Items.Add(new ListItem("请选择", "")); //名称 ,d=值0就是它绑定 SelectedIndex
            ddl.Items.Add(new ListItem("接入站点", "接入站点"));
            ddl.Items.Add(new ListItem("汇聚站点", "汇聚站点"));
            ddl.Items.Add(new ListItem("核心站点", "核心站点"));
            ddl.Items.Add(new ListItem("骨干站点", "骨干站点"));
            ddl.Items.Add(new ListItem("其它", "其它"));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="IsClear"></param>
        public static void InidllArea(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Add(new ListItem("请选择", ""));
                //   ddl.Items.Add(new ListItem(BaseConfig.AreaName_0, BaseConfig.AreaCode_0.ToString()));	//请选择
            }
            ddl.Items.Add(new ListItem("全地区", "全地区")); //名称 ,d=值0就是它绑定 SelectedIndex
            ddl.Items.Add(new ListItem("鹿城", "鹿城"));
            ddl.Items.Add(new ListItem("龙湾", "龙湾"));
            ddl.Items.Add(new ListItem("瓯海", "瓯海"));
            ddl.Items.Add(new ListItem("瑞安", "瑞安"));
            ddl.Items.Add(new ListItem("平阳", "平阳"));
            ddl.Items.Add(new ListItem("苍南", "苍南"));
            ddl.Items.Add(new ListItem("乐清", "乐清"));
            ddl.Items.Add(new ListItem("文成", "文成"));
            ddl.Items.Add(new ListItem("洞头", "洞头"));
            ddl.Items.Add(new ListItem("永嘉", "永嘉"));
            ddl.Items.Add(new ListItem("泰顺", "泰顺"));

        }

        public static void InidllCanCheck(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Add(new ListItem("请选择", ""));
                //   ddl.Items.Add(new ListItem(BaseConfig.AreaName_0, BaseConfig.AreaCode_0.ToString()));	//请选择
            }
            ddl.Items.Add(new ListItem("是", "1")); //名称 ,d=值0就是它绑定 SelectedIndex
            ddl.Items.Add(new ListItem("否", "0"));


        }
        /// <summary>
        /// 配置光交状态
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="IsClear"></param>
        public static void InidllCableState(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Clear();
                // ddl.Items.Add(new ListItem(BaseConfig.AreaName_0, BaseConfig.AreaCode_0.ToString()));	//请选择
            }

            ddl.Items.Add(new ListItem("请选择", "")); //名称 ,d=值0就是它绑定 SelectedIndex
            ddl.Items.Add(new ListItem("规划中", "规划中"));
            ddl.Items.Add(new ListItem("建设中", "建设中"));
            ddl.Items.Add(new ListItem("维护中", "维护中"));
        }

        /// <summary>
        /// 配置光交属性
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="IsClear"></param>
        public static void InidllCableProperty(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Clear();
                //  ddl.Items.Add(new ListItem(BaseConfig.AreaName_0, BaseConfig.AreaCode_0.ToString()));	//请选择
            }
            ddl.Items.Add(new ListItem("请选择", "")); //名称 ,d=值0就是它绑定 SelectedIndex
            ddl.Items.Add(new ListItem("主配", "主配"));
            ddl.Items.Add(new ListItem("辅配", "辅配"));
            ddl.Items.Add(new ListItem("普通", "普通"));
        }
        /// <summary>
        /// 设计容量
        /// </summary>
        public static void InidllDesignCapacity(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            { ddl.Items.Clear(); }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("72", "72"));
            ddl.Items.Add(new ListItem("144", "144"));
            ddl.Items.Add(new ListItem("288", "288"));
            ddl.Items.Add(new ListItem("576", "576"));
        }

        /// <summary>
        /// 绑定生产厂家
        /// </summary>
        /// <param name="ddl"></param>
        /// <param name="IsClear"></param>
        public static void Iniddl_Manufacuturer(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            { ddl.Items.Clear(); }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("宁波余大", "宁波余大"));
            ddl.Items.Add(new ListItem("杭州更新", "杭州更新"));
            ddl.Items.Add(new ListItem("华为", "华为"));
            ddl.Items.Add(new ListItem("其它", "其它"));
        }
        public static void Iniddl_InstallCapacity(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            { ddl.Items.Clear(); }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("72", "72"));
            ddl.Items.Add(new ListItem("144", "144"));
            ddl.Items.Add(new ListItem("288", "288"));
            ddl.Items.Add(new ListItem("576", "576"));
        }
        public static void Iniddl_EquityProperty(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            { ddl.Items.Clear(); }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("自建", "自建"));
            ddl.Items.Add(new ListItem("共建", "共建"));
        }
        public static void Iniddl_EquityUnit(DropDownList ddl, bool IsClear)
        {
            { ddl.Items.Clear(); }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("移动", "移动"));
            ddl.Items.Add(new ListItem("电信", "电信"));
            ddl.Items.Add(new ListItem("联通", "联通"));
        }
        public static void Iniddl_UsedUnit(DropDownList ddl, bool IsClear)
        {
            { ddl.Items.Clear(); }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("移动", "移动"));
            ddl.Items.Add(new ListItem("电信", "电信"));
            ddl.Items.Add(new ListItem("联通", "联通"));
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public static void InidllCheckState(DropDownList ddl, bool IsClear)
        {
            if (IsClear)
            {
                ddl.Items.Clear();
            }
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("未审核", "未审核"));
            ddl.Items.Add(new ListItem("信息修改", "信息修改"));
            ddl.Items.Add(new ListItem("审核通过", "审核通过"));
            ddl.Items.Add(new ListItem("审核驳回", "审核驳回"));

        }

        public static void IniddlIsintegrity(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("是", "是"));
            ddl.Items.Add(new ListItem("否", "否"));
        }

        public static void Iniddl_NetWorkType(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("综合箱", "综合箱"));
            ddl.Items.Add(new ListItem("综合柜", "综合柜"));
            ddl.Items.Add(new ListItem("分纤箱", "分纤箱"));
        }

        public static void Iniddl_FiberType(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("请选择", ""));
            ddl.Items.Add(new ListItem("主干", "主干"));
            ddl.Items.Add(new ListItem("汇聚", "汇聚"));
            ddl.Items.Add(new ListItem("主配", "主配"));
            ddl.Items.Add(new ListItem("辅配", "辅配"));
            ddl.Items.Add(new ListItem("接入", "接入"));
            ddl.Items.Add(new ListItem("引入", "引入"));

        }

        public static void Iniddl_IsCableRelation(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("光交", "光交"));
            ddl.Items.Add(new ListItem("ODF", "ODF"));

        }
        public static string[] Iniddl_NetWorkType()
        {
            string[] ReturnValue = new string[3];
            ReturnValue[0] = "综合箱";
            ReturnValue[1] = "综合柜";
            ReturnValue[2] = "分纤箱";
            return ReturnValue;
        }
    


        public static string[] Iniddl_FiberType()
        {
            string[] ReturnValue = new string[6];
            ReturnValue[0] = "主干";
            ReturnValue[1] = "汇聚";
            ReturnValue[2] = "主配";
            ReturnValue[3] = "辅配";
            ReturnValue[4] = "接入";
            ReturnValue[5] = "引入";
      
            return ReturnValue;
        }
        public static string[] Iniddl_FiberState()
        {
            string[] ReturnValue = new string[3];
            ReturnValue[0] = "规划中";
            ReturnValue[1] = "建设中";
            ReturnValue[2] = "维护中";
            return ReturnValue;
        }
        /// <summary>
        /// 是否交接代维
        /// </summary>
        public static void SelectDropDownListValue(DropDownList ddl, string strvalue)
        {
            bool hasExist = false;
            for (int i = 0; i < ddl.Items.Count; i++)
            {
                if (ddl.Items[i].Value == strvalue)
                {
                    ddl.SelectedIndex = i;
                    hasExist = true;
                    break;
                }
            }
            if (!hasExist)
            {
                if (strvalue.Trim() != string.Empty)
                {
                    ddl.Items.Add(strvalue);
                    ddl.SelectedIndex = ddl.Items.Count - 1;
                }
                else
                {
                    ddl.SelectedIndex = 0;
                }
            }
            //   return hasExist;
        }

        /// <summary>
        /// 审核状态：未审核，驳回，待复审，通过
        /// </summary>
        public static DataTable DicGetAuditState()
        {
            DataTable dt = DicCreateDataTable();
            //未审核
            DataRow dr = dt.NewRow();
            dr[0] = ConfigArgs.auditStateText_UnAudit;
            dr[1] = ConfigArgs.auditStateValue_UnAudit;
            dt.Rows.Add(dr);
            //驳回
            dr = dt.NewRow();
            dr[0] = ConfigArgs.auditStateText_Reject;
            dr[1] = ConfigArgs.auditStateValue_Reject;
            dt.Rows.Add(dr);
            //待复审
            dr = dt.NewRow();
            dr[0] = ConfigArgs.auditStateText_ReAudit;
            dr[1] = ConfigArgs.auditStateValue_ReAudit;
            dt.Rows.Add(dr);
            //通过
            dr = dt.NewRow();
            dr[0] = ConfigArgs.auditStateText_Pass;
            dr[1] = ConfigArgs.auditStateValue_Pass;
            dt.Rows.Add(dr);

            return dt;
        }

        /// <summary>
        /// 审核结果：驳回，通过
        /// </summary>
        public static DataTable DicGetAuditResult()
        {
            DataTable dt = DicCreateDataTable();
            //驳回
            DataRow dr = dt.NewRow();
            dr[0] = ConfigArgs.auditStateText_Reject;
            dr[1] = ConfigArgs.auditStateValue_Reject;
            dt.Rows.Add(dr);
            //通过
            dr = dt.NewRow();
            dr[0] = ConfigArgs.auditStateText_Pass;
            dr[1] = ConfigArgs.auditStateValue_Pass;
            dt.Rows.Add(dr);

            return dt;
        }

        /// <summary>
        /// 车辆地区
        /// </summary>
        public static DataTable DicGetCarArea()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_LC;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_LW;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_OH;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_RA;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_PY;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_CN;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_YQ;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_WC;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_DT;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_YJ;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_TS;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[1] = dr[0] = ConfigArgs.memArea_SGS;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 车辆调度：调入\调出
        /// </summary>
        public static DataTable DicGetCarTransfer()
        {
            DataTable dt = DicCreateDataTable();
            //调入
            DataRow dr = dt.NewRow();
            dr[0] = ConfigArgs.carStateText_TransferIn;
            dr[1] = ConfigArgs.carStateValue_TransferIn;
            dt.Rows.Add(dr);
            //调出
            dr = dt.NewRow();
            dr[0] = ConfigArgs.carStateText_TransferOut;
            dr[1] = ConfigArgs.carStateValue_TransferOut;
            dt.Rows.Add(dr);

            return dt;
        }

        /// <summary>
        /// 性别：男、女
        /// </summary>
        public static DataTable DicGetMemSex()
        {
            DataTable dt = DicCreateDataTable();
            //男
            DataRow dr = dt.NewRow();
            dr[0] = ConfigArgs.memSexText_Man;
            dr[1] = ConfigArgs.memSexValue_Man;
            dt.Rows.Add(dr);
            //女
            dr = dt.NewRow();
            dr[0] = ConfigArgs.memSexText_WoMan;
            dr[1] = ConfigArgs.memSexValue_WoMan;
            dt.Rows.Add(dr);

            return dt;
        }

        /// <summary>
        /// 年份
        /// </summary> 
        public static DataTable DicGetYear()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr;
            for (int i = 0; i < 5; i++)
            {
                dr = dt.NewRow();
                dr[0] = DateTime.Now.Year - i;
                dr[1] = DateTime.Now.Year - i;
                dt.Rows.Add(dr);
            }

            return dt;
        }
        /// <summary>
        /// 月份
        /// </summary> 
        public static DataTable DicGetMonth()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr;
            for (int i = 1; i <= 12; i++)
            {
                dr = dt.NewRow();
                dr[0] = i + "月";
                dr[1] = i;
                dt.Rows.Add(dr);
            }

            return dt;
        }

        /// <summary>
        /// 考核类型
        /// </summary> 
        public static DataTable DicGetExamItemsType()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = ConfigArgs.examTypeText_Province;
            dr[1] = ConfigArgs.examTypeValue_Province;
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = ConfigArgs.examTypeText_City;
            dr[1] = ConfigArgs.examTypeValue_City;
            dt.Rows.Add(dr);
            return dt;
        }

        /// <summary>
        /// 考核计划状态
        /// </summary> 
        public static string DicGetExamPlanText_IsFinish(bool isFinish)
        {
            if (isFinish)
                return "已完成";
            else
                return "进行中";
        }

        /// <summary>
        /// 项目考核状态
        /// </summary> 
        public static string DicGetExamItemsIsFiniallyText(bool isFinally)
        {
            if (isFinally)
                return "已评分";
            else
                return "未评分";
        }


        /// <summary>
        /// 考核状态
        /// </summary> 
        public static string DicGetExamItemTypeText(int type)
        {
            if (type == 1)
                return ConfigArgs.examTypeText_Province;
            else
                return ConfigArgs.examTypeText_City;
        }

        /// <summary>
        /// 考核类型
        /// </summary> 
        public static DataTable DicGetExamProject()
        {
            DataTable dt = DicCreateDataTable();
            DataRow dr;
            dr = dt.NewRow();
            dr[0] = dr[1] = ConfigArgs.examDepartment_GW;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = dr[1] = ConfigArgs.examDepartment_TD;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = dr[1] = ConfigArgs.examDepartment_QYWGX;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = dr[1] = ConfigArgs.examDepartment_QYWSB;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = dr[1] = ConfigArgs.examDepartment_CSSB;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr[0] = dr[1] = ConfigArgs.examDepartment_CSGX;
            dt.Rows.Add(dr);

            return dt;
        }


        #endregion

        #region 考核

        /// <summary>
        /// 省管考核项总分数信息:打印时判断考核项分数是否有被扣分
        /// </summary>
        public static int[] ExamProvinceGradeValueList(string companyTypeText)
        {
            switch (companyTypeText)
            {
                case ConfigArgs.examComTypeText_JL: int[] listJL = {
                             5, 3, 2, 5, 
                             10, 3, 4, 3, 
                             10, 5, 5, 
                             5, 5, 5, 
                             5, 5, 5, 5,
                             6, 2, 2 
                         }; return listJL;
                case ConfigArgs.examComTypeText_SJ: int[] listSJ = {
                            8,5, 2, 5, 
                            10, 10,  4,3, 3, 
                             10, 5, 5, 
                             5, 5, 5, 5, 
                             6, 2, 2 
                         }; return listSJ;
                case ConfigArgs.examComTypeText_SG: int[] listSG = {
                             5, 3, 2, 5, 
                             10, 2,3, 2, 3, 
                             10, 5, 5, 
                             2,3,3,3,4,
                             5, 5, 5,5,
                             6, 2, 2 
                         }; return listSG;
                default: return null;
            }
        }

        /// <summary>
        /// 省管考核项文本信息
        /// </summary>
        public static string[] ExamProvinceGradeTextList(string companyTypeText)
        {
            switch (companyTypeText)
            {
                case ConfigArgs.examComTypeText_JL: string[] listJL = { 
                                "人员、车辆及工器具","人员、车辆及工器具","人员、车辆及工器具","人员、车辆及工器具",
                                "质量控制","质量控制","质量控制","质量控制",
                                "进度控制","进度控制","进度控制",
                                "现场管理","现场管理","现场管理",
                                "服务沟通","服务沟通","服务沟通","服务沟通",
                                "安全管理","安全管理","安全管理"
                            }; return listJL;
                case ConfigArgs.examComTypeText_SJ: string[] listSJ = { 
                                "人员、车辆及工器具","人员、车辆及工器具","人员、车辆及工器具","人员、车辆及工器具",
                                "质量控制","质量控制","质量控制","质量控制","质量控制",
                                "进度控制","进度控制","进度控制",
                                "服务沟通","服务沟通","服务沟通","服务沟通",  
                                "安全管理","安全管理","安全管理"
                            }; return listSJ;
                case ConfigArgs.examComTypeText_SG: string[] listSG = { 
                                "人员、车辆及工器具","人员、车辆及工器具","人员、车辆及工器具","人员、车辆及工器具",
                                "质量控制","质量控制","质量控制","质量控制","质量控制",
                                "进度控制","进度控制","进度控制",
                                "现场管理","现场管理","现场管理","现场管理","现场管理",
                                "服务沟通","服务沟通","服务沟通","服务沟通",  
                                "安全管理","安全管理","安全管理"
                            }; return listSG;
                default: return null;
            }
        }

        /// <summary>
        /// 考核类型编码：用于页面跳转
        /// </summary> 
        public static string ExamProvinceCompanyTypeCode(string companyTypeText)
        {
            switch (companyTypeText)
            {
                case ConfigArgs.examComTypeText_JL: return ConfigArgs.examComTypeCode_JL;
                case ConfigArgs.examComTypeText_SJ: return ConfigArgs.examComTypeCode_SJ;
                case ConfigArgs.examComTypeText_SG: return ConfigArgs.examComTypeCode_SG;
                default: return string.Empty;
            }
        }

        /// <summary>
        /// 打印模板
        /// </summary> 
        public static string ExamProvinceTempLate(string companyTypeText)
        {
            switch (companyTypeText)
            {
                case ConfigArgs.examComTypeText_JL: return ConfigArgs.examItemProvincePrintTemp_JL;
                case ConfigArgs.examComTypeText_SJ: return ConfigArgs.examItemProvincePrintTemp_SJ;
                case ConfigArgs.examComTypeText_SG: return ConfigArgs.examItemProvincePrintTemp_SG;
                default: return string.Empty;
            }
        }

        /// <summary>
        /// 打印数据显示的日期（天）为每月的25号
        /// </summary> 
        public static string GetExamPrintDay()
        {
            return Eastcom.Common.ConfigHelper.GetConfigString("ExamPrintDay");
        }
        #endregion
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形）                
                    break;
                case "W"://指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                new System.Drawing.Rectangle(x, y, ow, oh),
                System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        /// <summary>
        /// 得到全部编号 NetWork Fiber
        /// </summary>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static ArrayList GetNetWorkNo(string Type)
        {
            ArrayList ReturnValue = new ArrayList();
            string OneValue = "";
            if (Type == "NetWork")
            {
                for (int i = 1; i < 1000; i++)
                {
                    switch (i.ToString().Length)
                    {
                        case 1: OneValue = "00" + i.ToString(); break;
                        case 2: OneValue = "0" + i.ToString(); break;
                        case 3: OneValue = i.ToString(); break;
                    }
                    ReturnValue.Add(OneValue); // ReturnValue[i-1] = OneValue;
                }
                return ReturnValue;
            }
            else
            {
                for (int i = 1; i < 100; i++)
                {
                    switch (i.ToString().Length)
                    {
                        case 1: OneValue = "0" + i.ToString(); break;
                        case 2: OneValue = i.ToString(); break;
                    }
                    ReturnValue.Add(OneValue);
                }
                return ReturnValue;
            }

        }

        /// <summary>
        /// 是否编号占用
        /// </summary>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsInAllItems(string item, string type)
        {
            if (type == "NetWork")
            {
                for (int i = 0; i < 1000; i++)
                {
                    if (GetNetWorkNo(type).Contains(item))
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    if (GetNetWorkNo(type).Contains(item))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
