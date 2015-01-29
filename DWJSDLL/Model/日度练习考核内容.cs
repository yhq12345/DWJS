using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 日度练习考核内容:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 日度练习考核内容
    {
        public 日度练习考核内容()
        { }
        #region Model
        private int _id;
        private int? _fk_userid;
        private DateTime? _日期;
        private DateTime? _考务生成时间;
        private string _提交情况;
        private int? _生成的题目数;
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
        public int? FK_UserID
        {
            set { _fk_userid = value; }
            get { return _fk_userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 日期
        {
            set { _日期 = value; }
            get { return _日期; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? 考务生成时间
        {
            set { _考务生成时间 = value; }
            get { return _考务生成时间; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 提交情况
        {
            set { _提交情况 = value; }
            get { return _提交情况; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? 生成的题目数
        {
            set { _生成的题目数 = value; }
            get { return _生成的题目数; }
        }
        #endregion Model

    }
}

