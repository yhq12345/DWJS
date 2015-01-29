using System;
namespace Eastcom.Model
{
    /// <summary>
    /// User:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class User_Info
    {
        public User_Info()
        { }
        #region Model
        private int _id;
        private string _username;
        private string _password;
        private string _area;
        private string _cancheced;
        private string _realname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Area
        {
            set { _area = value; }
            get { return _area; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CanCheced
        {
            set { _cancheced = value; }
            get { return _cancheced; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        #endregion Model

    }
}

