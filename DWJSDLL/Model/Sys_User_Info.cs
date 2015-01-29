using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Serializable]
    public partial class Sys_User_Info
    {
        public Sys_User_Info()
        { }
        #region Model
        private int _userid;
        private string _username;
        private string _realname;
        private string _nickname;
        private string _pwd;
        private int? _fk_unitid;
        private int? _userarea;
        private int? _sex = 0;
        private int? _age = 0;
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
        private int _state = 1;
        private int _isdel;
        private string _usermangerarea;
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName
        {
            set { _nickname = value; }
            get { return _nickname; }
        }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 所在单位ID
        /// </summary>
        public int? FK_UnitID
        {
            set { _fk_unitid = value; }
            get { return _fk_unitid; }
        }
        /// <summary>
        /// 所属地区（参见数据字典）
        /// </summary>
        public int? UserArea
        {
            set { _userarea = value; }
            get { return _userarea; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 年龄
        /// </summary>
        public int? Age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? Birth
        {
            set { _birth = value; }
            get { return _birth; }
        }
        /// <summary>
        /// 其它联系方式
        /// </summary>
        public string Contact
        {
            set { _contact = value; }
            get { return _contact; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 创建人的ID
        /// </summary>
        public int? FK_CreateID
        {
            set { _fk_createid = value; }
            get { return _fk_createid; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 修改者ID
        /// </summary>
        public int? FK_EditID
        {
            set { _fk_editid = value; }
            get { return _fk_editid; }
        }
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? EditTime
        {
            set { _edittime = value; }
            get { return _edittime; }
        }
        /// <summary>
        /// 0:禁用 1：启用
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 0:已删除  1:正常
        /// </summary>
        public int IsDel
        {
            set { _isdel = value; }
            get { return _isdel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserMangerArea
        {
            set { _usermangerarea = value; }
            get { return _usermangerarea; }
        }

        #endregion Model

    }
}

