using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 考试题库_His:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 考试题库_His
    {
        public 考试题库_His()
        { }
        #region Model
        private int _id;
        private string _题目内容;
        private string _a选项;
        private string _b选项;
        private string _c选项;
        private string _d选项;
        private string _其他选项;
        private string _标准答案;
        private string _标准答案2;
        private DateTime? _备份时间;
        private string _操作人;
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
        public string 题目内容
        {
            set { _题目内容 = value; }
            get { return _题目内容; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string A选项
        {
            set { _a选项 = value; }
            get { return _a选项; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string B选项
        {
            set { _b选项 = value; }
            get { return _b选项; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string C选项
        {
            set { _c选项 = value; }
            get { return _c选项; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string D选项
        {
            set { _d选项 = value; }
            get { return _d选项; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 其他选项
        {
            set { _其他选项 = value; }
            get { return _其他选项; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 标准答案
        {
            set { _标准答案 = value; }
            get { return _标准答案; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 标准答案2
        {
            set { _标准答案2 = value; }
            get { return _标准答案2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 备份时间
        {
            set { _备份时间 = value; }
            get { return _备份时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 操作人
        {
            set { _操作人 = value; }
            get { return _操作人; }
        }
        #endregion Model

    }
}

