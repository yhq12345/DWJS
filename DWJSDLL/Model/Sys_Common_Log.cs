using System;
namespace Eastcom.Model
{
    /// <summary>
    /// Sys_Common_Log:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_Common_Log
    {
        public Sys_Common_Log()
        { }
        #region Model
        private int _logid;
        private DateTime? _dtdate;
        private string _sthread;
        private string _slevel;
        private string _slogger;
        private string _smessage;
        private string _sexception;
        /// <summary>
        /// 
        /// </summary>
        public int LogID
        {
            set { _logid = value; }
            get { return _logid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DtDate
        {
            set { _dtdate = value; }
            get { return _dtdate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SThread
        {
            set { _sthread = value; }
            get { return _sthread; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SLevel
        {
            set { _slevel = value; }
            get { return _slevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SLogger
        {
            set { _slogger = value; }
            get { return _slogger; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SMessage
        {
            set { _smessage = value; }
            get { return _smessage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SException
        {
            set { _sexception = value; }
            get { return _sexception; }
        }
        #endregion Model

    }
}

