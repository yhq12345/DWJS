using System;
namespace Eastcom.Model
{
    /// <summary>
    /// v_Sys_User_Info:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_Sys_User_Info
    {
        public v_Sys_User_Info()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _realname;
        private string _nickname;
        private string _pwd;
        private int? _fk_unitid;
        private int? _userarea;
        private int? _sex;
        private int? _age;
        private string _email;
        private string _tel;
        private string _qq;
        private string _address;
        private DateTime? _birth;
        private string _contact;
        private string _remark;
        private int? _fk_createid;
        private DateTime? _createtime;
        private int? _fk_editid;
        private DateTime? _edittime;
        private int _state;
        private int _isdel;
        private string _usermangerarea;
        private string _角色名;
        private string _角色id;
        private int _最大角色权重;
        private string _性别;
        private string _创建者名;
        private string _修改者名;
        private string _账户状态;
        private string _所在地区;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
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
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_UnitID
        {
            set { _fk_unitid = value; }
            get { return _fk_unitid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserArea
        {
            set { _userarea = value; }
            get { return _userarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Contact
        {
            set { _contact = value; }
            get { return _contact; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_CreateID
        {
            set { _fk_createid = value; }
            get { return _fk_createid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? FK_EditID
        {
            set { _fk_editid = value; }
            get { return _fk_editid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EditTime
        {
            set { _edittime = value; }
            get { return _edittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }

        /// <summary>
        /// 用户管理的地区
        /// </summary>
        public string UserMangerArea
        {
            set { _usermangerarea = value; }
            get { return _usermangerarea; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 角色名
        {
            set { _角色名 = value; }
            get { return _角色名; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 角色ID
        {
            set { _角色id = value; }
            get { return _角色id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int 最大角色权重
        {
            set { _最大角色权重 = value; }
            get { return _最大角色权重; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 性别
        {
            set { _性别 = value; }
            get { return _性别; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 创建者名
        {
            set { _创建者名 = value; }
            get { return _创建者名; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 修改者名
        {
            set { _修改者名 = value; }
            get { return _修改者名; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 账户状态
        {
            set { _账户状态 = value; }
            get { return _账户状态; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 所在地区
        {
            set { _所在地区 = value; }
            get { return _所在地区; }
        }
        #endregion Model

    }
}

