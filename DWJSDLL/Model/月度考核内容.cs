using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 月度考核内容:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class 月度考核内容
    {
        public 月度考核内容()
        { }
        #region Model
        private int _id;
        private int? _fk_userid;
        private DateTime? _月份;
        private DateTime? _考务生成时间;
        private DateTime? _提交时间;
        private string _回答情况;
        private decimal? _得分;
        private string _提交情况;
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
        public DateTime? 月份
        {
            set { _月份 = value; }
            get { return _月份; }
        }
        public DateTime? 考务生成时间
        {
            get{return _考务生成时间;}
            set { _考务生成时间 = value; }
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
        /// 提交情况
        /// </summary>
        public string 提交情况
        {
            set { _提交情况 = value; }
            get { return _提交情况; }
        }
        #endregion Model

    }
}

