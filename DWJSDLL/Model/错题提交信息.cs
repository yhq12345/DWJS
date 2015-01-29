using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 错题提交信息:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 错题提交信息
    {
        public 错题提交信息()
        { }
        #region Model
        private int _id;
        private string _fk_考试题库;
        private string _题目信息;
        private string _答案信息;
        private string _错误提交信息;
        private string _提交人;
        private DateTime? _提交时间;
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
        public string FK_考试题库
        {
            set { _fk_考试题库 = value; }
            get { return _fk_考试题库; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 题目信息
        {
            set { _题目信息 = value; }
            get { return _题目信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 答案信息
        {
            set { _答案信息 = value; }
            get { return _答案信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 错误提交信息
        {
            set { _错误提交信息 = value; }
            get { return _错误提交信息; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 提交人
        {
            set { _提交人 = value; }
            get { return _提交人; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 提交时间
        {
            set { _提交时间 = value; }
            get { return _提交时间; }
        }
        #endregion Model

    }
}

