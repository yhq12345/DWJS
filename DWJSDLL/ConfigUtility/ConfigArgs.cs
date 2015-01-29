using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eastcom.ConfigUntility
{
    public class ConfigArgs
    {
        #region 系统参数

        /// <summary>
        /// 导入的初始行数
        /// </summary>

        public const int sysimportExcelStartLine = 3;

        public const int NetWorkimportExcelStartLine = 2;
        /// <summary>
        /// 人员照片上传路径
        /// </summary>
        public const string sysFileUpLoadPath = "~/UpLoadFile/MemberPhoto/";

        //<!--分页、缓存-->
        public const int sysPageSize = 10;
        public const int sysModelCache = 180;

        //<!--异常处理-->

        public const string sysErrPage = "~/error.aspx";
        public const string sysErrMsg_Login_TimeOut = "登陆超时，请重新登陆!";
        public const string sysErrMsg_Login_Fail = "登陆失败!";
        public const string sysErrMsg_Operate_Fail = "没有操作权限!";

        //	审批方式(对应数据表sys_AuditRoleMapping字段auditTypeCode)：增加:10 短假:11 长假:12 调离:13 回岗:14  跨地区人员请假:15
        //<!--专业负责人:角色id-->
        public const int memPrincipalRoleId = 10003;
        //<!--人员状态：0:未上岗、(1:在岗、2:短假、3:长假、4:调离、5:回岗)在下拉列表中 
        public const int memWorkStateValue_UnUsed = 0;
        public const string memWorkStateText_UnUsed = "未上岗";
        public const int memWorkStateValue_OnWork = 1;
        public const string memWorkStateText_OnWork = "在岗";
        public const int memWorkStateValue_ShortLeave = 2;
        public const string memWorkStateText_ShortLeave = "短假";
        public const int memWorkStateValue_LongLeave = 3;
        public const string memWorkStateText_LongLeave = "长假";
        public const int memWorkStateValue_Transfer = 4;
        public const string memWorkStateText_Transfer = "调离";
        public const int memWorkStateValue_BackWork = 5;
        public const string memWorkStateText_BackWork = "回岗";
        //人员性别：男：1、女：0
        public const int memSexValue_Man = 1;
        public const string memSexText_Man = "男";
        public const int memSexValue_WoMan = 0;
        public const string memSexText_WoMan = "女";
        //<!--审核：未审核:0 驳回:1 待复审:2 通过:3   --> 
        public const int auditStateValue_UnAudit = 0;
        public const string auditStateText_UnAudit = "未审核";
        public const int auditStateValue_Reject = 1;
        public const string auditStateText_Reject = "驳回";
        public const int auditStateValue_ReAudit = 2;
        public const string auditStateText_ReAudit = "待复审";
        public const int auditStateValue_Pass = 3;
        public const string auditStateText_Pass = "通过";

        //车辆信息：状态（未使用，调入/增加，调出/删除） 调度（调入/增加，调出/删除，更换/地区/车牌） 审批流程：调入/调出16，更换17） 
        public const int carStateValue_UnUsed = 1;
        public const string carStateText_UnUsed = "未使用";
        public const int carStateValue_TransferIn = 2;
        public const string carStateText_TransferIn = "调入";
        public const int carStateValue_TransferOut = 3;
        public const string carStateText_TransferOut = "调出";
        public const int carStateValue_Changed = 4;
        public const string carStateText_Changed = "更换";

        //人员地区
        public const string memArea_LC = "鹿城";
        public const string memArea_LW = "龙湾";
        public const string memArea_OH = "瓯海";
        public const string memArea_RA = "瑞安";
        public const string memArea_PY = "平阳";
        public const string memArea_CN = "苍南";
        public const string memArea_YQ = "乐清";
        public const string memArea_WC = "文成";
        public const string memArea_DT = "洞头";
        public const string memArea_YJ = "永嘉";
        public const string memArea_TS = "泰顺";
        public const string memArea_ALL = "全地区";
        public const string memArea_SGS = "市公司";

        /// <summary>
        /// 
        /// </summary>
        public static string[] Area_Group = new string[11]{
            memArea_LC,memArea_OH,memArea_LW,memArea_YQ,memArea_YJ
            ,memArea_PY,memArea_RA,memArea_CN,memArea_WC,memArea_TS,memArea_DT
        };

        //光交
        public const string GJ_LC = "LCGJ";
        public const string GJ_LW = "LWGJ";
        public const string GJ_OH = "OHGJ";
        public const string GJ_RA = "RAGJ";
        public const string GJ_PY = "PYGJ";
        public const string GJ_CN = "CNGJ";
        public const string GJ_YQ = "YQGJ";
        public const string GJ_WC = "WCGJ";
        public const string GJ_DT = "DTGJ";
        public const string GJ_YJ = "YJGJ";
        public const string GJ_TS = "TSGJ";

        //考核
        public const string examTypeText_Province = "省管";
        public const string examTypeText_City = "市管";
        public const int examTypeValue_Province = 1;
        public const int examTypeValue_City = 2;
        public const string examItemProvincePrintTemp_JL = "~/tempLate/provinceTemp/监理单位评估表.xls";
        public const string examItemProvincePrintTemp_SJ = "~/tempLate/provinceTemp/设计单位评估表.xls";
        public const string examItemProvincePrintTemp_SG = "~/tempLate/provinceTemp/施工单位评估表.xls";
        public const string examPlanPrintTemp_Province = "~/tempLate/provinceTemp/汇总表.xls";
        public const string examCityPrintTemp = "~/tempLate/provinceTemp/市管合作单位月度考核汇总.xls";
        public const string examTempSheetName = "评估细项-";
        public const string examTempSheetTimeText = "评估时间：";
        public const string examTempSavePath = "~/tempLate/tempFiles/";
        public const string examComTypeCode_JL = "JL";         //监理单位
        public const string examComTypeText_JL = "监理单位";         //监理单位
        public const string examComTypeCode_SG = "SG";         //施工单位
        public const string examComTypeText_SG = "施工单位";         //施工单位
        public const string examComTypeCode_SJ = "SJ";         //设计单位
        public const string examComTypeText_SJ = "设计单位";         //设计单位
        public const string examDepartment_GW = "G网";      //考核项目名称
        public const string examDepartment_TD = "TD";
        public const string examDepartment_QYWGX = "全业务管线";
        public const string examDepartment_QYWSB = "全业务设备";
        public const string examDepartment_CSSB = "传输设备";
        public const string examDepartment_CSGX = "传输管线";

        public const string excelTempExport = "~/tempLate/provinceTemp/Export.xls";
        /// <summary>
        /// 1
        /// </summary>
        public const int ModelRowSum = 1;
        /// <summary>
        /// 12
        /// </summary>
        public const int ModelRowPortSum = 12;
        /// <summary>
        /// 1
        /// </summary>
        public const int ModelColumn = 1;

        public static string RedisServer = "111.1.13.250";  /* 172.10.12.18 内网*/ /*111.1.13.250 外网*/

        public static string _RedisServer
        {
            set;
            get;
        }



        #endregion

        public   enum 提交情况
        {
            未提交 = 0,
            已提交 = 1,
            已删除 = 2
        }
    }

}
