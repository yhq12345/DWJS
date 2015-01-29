using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 月度考核内容_详细:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 月度考核内容_详细
    {
        public 月度考核内容_详细()
        { }
        #region Model
        private int _id;
        private int? _fk_月度考核内容;
        private int? _考核题目编号;
        private int? _题目编号;
        private string _用户答案;
        private string _回答情况;
        private decimal? _得分;
        private DateTime? _提交时间;

        private string _题目内容_原;
        private string _a选项_原;
        private string _b选项_原;
        private string _c选项_原;
        private string _d选项_原;
        private string _其他选项_原;
        private string _标准答案_原;


        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_月度考核内容
        {
            set { _fk_月度考核内容 = value; }
            get { return _fk_月度考核内容; }
        }
        /// <summary>
        /// 题目的序号 1,2,3,4,5,6,7,8,9,10----20 考试的题目总数
        /// </summary>
        public int? 考核题目编号
        {
            set { _考核题目编号 = value; }
            get { return _考核题目编号; }
        }
        /// <summary>
        /// 题目的 在题库的编号 ---1,2,3,----题库总数 640 (2014-03-26) 
        /// </summary>
        public int? 题目编号
        {
            set { _题目编号 = value; }
            get { return _题目编号; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 用户答案
        {
            set { _用户答案 = value;  }
            get { return _用户答案; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 回答情况
        {
            set { _回答情况 = value; }
            get { return _回答情况; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? 得分
        {
            set { _得分 = value; }
            get { return _得分; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 提交时间
        {
            set { _提交时间 = value; }
            get { return _提交时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 题目内容_原
        {
            set { _题目内容_原 = value; }
            get { return _题目内容_原; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A选项_原
        {
            set { _a选项_原 = value; }
            get { return _a选项_原; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B选项_原
        {
            set { _b选项_原 = value; }
            get { return _b选项_原; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string C选项_原
        {
            set { _c选项_原 = value; }
            get { return _c选项_原; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string D选项_原
        {
            set { _d选项_原 = value; }
            get { return _d选项_原; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 其他选项_原
        {
            set { _其他选项_原 = value; }
            get { return _其他选项_原; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 标准答案_原
        {
            set { _标准答案_原 = value; }
            get { return _标准答案_原; }
        }




        #endregion Model

    }
}

