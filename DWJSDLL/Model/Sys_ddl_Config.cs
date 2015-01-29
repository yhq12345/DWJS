using System;
namespace Eastcom.Model
{
    /// <summary>
    /// Sys_ddl_Config:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Sys_ddl_Config
    {
        public Sys_ddl_Config()
        { }
        #region Model
        private long _id;
        private string _ddl_value;
        private string _ddl_type;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DDl_Value
        {
            set { _ddl_value = value; }
            get { return _ddl_value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DDl_Type
        {
            set { _ddl_type = value; }
            get { return _ddl_type; }
        }
        #endregion Model

    }
}

