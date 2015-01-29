using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SystemConfig
{
    public class CommonState {
        /// <summary>
        /// 首页中选项卡的表头
        /// </summary>
        public enum TabsDate
        { 
            今天=0,
            昨天=1,
            本周=2,
            上周=3,
            本月=4,
            上月=5,
            全部=6
        }
        /// <summary>
        /// 时间周期
        /// </summary>
        public enum DateCycle
        { 
            年=0,
            月=1,
            日=2,
            周=3
        }
        /// <summary>
        /// 性别
        /// </summary>
        public enum Sex
        { 
            女=0,
            男=1
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public enum VerifyState
        { 
            未审核=0,//待审核
            已审核=1,//已通过
            未通过=2,
            未提交=3
        }
        /// <summary>
        /// 任务类型
        /// </summary>
        public enum TaskType
        { 
            手动添加=0,
            Excel导入=1
        }
        /// <summary>
        /// 数据有效性状态
        /// </summary>
        public enum State
        { 
            无效=0,
            有效=1
            //已删除=2（前台不显示）
        }
        /// <summary>
        /// 进度
        /// </summary>
        public enum ProcessState
        {
            进行中 = 0,
            未开始=1,
            已完成=2
        }
        /// <summary>
        /// 任务类型
        /// </summary>
        public enum IsSimple
        { 
            简易版=0,//无自定义字段
            扩展版=1//有自定义字段
        }
        /// <summary>
        /// 问题状态
        /// </summary>
        public enum AskState
        { 
            待解决=0,
            已解决=1,
            未解决=2
        }
        #region 搜索控件枚举
        /// <summary>
        /// 左括号
        /// </summary>
        public enum LeftBracket
        { 
            左括号=0
        }
        /// <summary>
        /// 获取实际左括号
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string GetLeftBracket(LeftBracket m)
        {
            string str = string.Empty;
            switch (m)
            { 
                case LeftBracket.左括号:
                    str = "(";
                    break;
                default:
                    str = "(";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 右括号
        /// </summary>
        public enum RightBracket
        {
            右括号 = 0
        }
        /// <summary>
        /// 获取实际右括号
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string GetRightBracket(RightBracket m)
        {
            string str = string.Empty;
            switch (m)
            {
                case RightBracket.右括号:
                    str = ")";
                    break;
                default:
                    str = ")";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 逻辑
        /// </summary>
        public enum logic
        { 
            并且=0,
            或者=1
        }
        /// <summary>
        /// 获取实际逻辑
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string GetLogic(logic m)
        {
            string str = string.Empty;
            switch (m)
            {
                case logic.并且:
                    str = "and";
                    break;
                case logic.或者:
                    str = "or";
                    break;
                default:
                    str = "and";
                    break;
            }
            return str;
        }
        /// <summary>
        /// 符号enum
        /// </summary>
        public enum Symbol
        { 
            包含=0,
            等于=1,
            不等于=2,
            大于=3,
            大于等于=4,
            小于=5,
            小于等于=6
        }
        /// <summary>
        /// 根据符号枚举返回实际符号
        /// </summary>
        public static string GetSymbol(Symbol m)
        {
            string str=string.Empty;
            switch(m)
            {
                case Symbol.包含:
                    str = "like";
                    break;
                case Symbol.等于:
                    str = "=";
                    break;
                case Symbol.不等于:
                    str = "<>";
                    break;
                case Symbol.大于:
                    str = ">";
                    break;
                case Symbol.大于等于:
                    str = ">=";
                    break;
                case Symbol.小于:
                    str = "<";
                    break;
                case Symbol.小于等于:
                    str = "<=";
                    break;
                default :
                    str = "=";
                    break;
            }
            return str;
        }
        #endregion
    }

    public class CommonDic
    {
        public enum 公共字典_附件类型
        {
            
            工作量记录 = 1,
       
            纠错记录审批 = 60
        }

        public enum 数据字典类型
        {
            问题分类=1,
            小组类别=5,
            工单类型=21,
            所属区域=22,
            工单状态=23,
            审批流程类型=59,
            纠错专业类别=63
        }

        public enum 工单处理_接收工单响应状态
        { 
            拒绝=0,
            同意=1
        }

        public enum 工单处理_接收工单处理结果
        {
            中止 = 0,
            完成 = 1
        }


        public enum 工单处理_工单状态//此乃视图字段，判断汉字即可
        { 
            待响应=0,
            已同意待处理=1,
            已处理并中止=2,
            已处理并完成=3,
            已拒绝=4
        }

        public enum 是否
        { 
            是=1,
            否=0
        }

        public enum 审批流程类型
        { 
            工单处理审批=59,
            纠错记录审批=60
        }

        public enum 审批状态
        {
            待审批=0,
            审批中=1,
            已审批=2
        }

        public enum 审批结论
        { 
            不合格=0,
            合格=1
        }


        #region 纠错相关
        public enum 纠错处理_接收纠错处理结果
        {
            中止 = 0,
            完成 = 1
        }


        public enum 纠错处理_纠错处理状态
        {
            待核实 = 0,
            已核实待处理 = 1,
            已处理并中止 = 2,
            已处理并完成 = 3,
        }
        #endregion
    }
}
