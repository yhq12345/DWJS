using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Eastcom.Common
{
    public class System_Args
    {

        public static string CheckStateLevel1 = "综合管理员申请";
        public static string CheckStateHandle1 = "综合管理员处理";
        public static string CheckStateEdit1 = "综合管理员修改";

        public static string CheckStateLevel2 = "代维中心主任审批";
        public static string CheckStateOverRole2 = "代维中心主任驳回";

        public static string CheckStateLevel3 = "分公司管理员审批";
        public static string CheckStateOverRole3 = "分公司管理员驳回";

        public static string CheckStateLevel4 = "市公司管理员审批";
        public static string CheckStateOverRole4 = "市公司管理员驳回";


        public static string CheckType1 = "添加";
        public static string CheckType2 = "修改";
        public static string CheckType3 = "请假";


        /// <summary>
        /// 指定人员处理
        /// </summary>
        public static string Hidden_CheckStateLevel3 = "指定人员处理";
        //public static string Hidden_CheckStateOverRole3 = "分公司管理驳回";

        /// <summary>
        /// 分公司管理确认审批
        /// </summary>
        public static string Hidden_CheckStateLevel4 = "分公司确认审批";
        public static string Hidden_CheckStateOverRole4 = "分公司确认驳回";





        public enum 安全隐患管理状态
        {
            准确性审核,
            准确性审核驳回,
            隐患处理,
            处理审核,
            工单结束
        }
        public enum 安全隐患管理详细状态
        {
            新建工单,
            准确性审核通过,
            准确性审核驳回,
            准确性审核驳回后修改,
            隐患处理,
            处理审核通过,
            处理审核驳回,
            处理审核驳回后修改,
            工单结束
        }

        public enum 安全隐患管理_操作类型
        {
            新建工单,
            准确性审核通过,
            准确性审核驳回,
            准确性审核驳回后修改,
            隐患处理,
            隐患处理保存,
            处理审核通过,
            处理审核驳回,
            处理审核驳回后修改,
            //工单结束
        }










    }
}
