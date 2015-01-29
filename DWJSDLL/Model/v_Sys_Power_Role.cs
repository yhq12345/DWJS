using System;
namespace Eastcom.Model
{
    /// <summary>
    /// v_Sys_Power_Role:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_Sys_Power_Role
    {
        public v_Sys_Power_Role()
        { }
        #region Model
        private int _roleid;
        private string _rolename;
        private int _roleweight;
        private string _remark;
        private int? _fk_editid;
        private DateTime? _edittime;
        private int? _fk_createid;
        private DateTime? _createtime;
        private int? _sort;
        private string _创建者名;
        private string _修改者名;
        /// <summary>
        /// 
        /// </summary>
        public int RoleID
        {
            set { _roleid = value; }
            get { return _roleid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RoleName
        {
            set { _rolename = value; }
            get { return _rolename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RoleWeight
        {
            set { _roleweight = value; }
            get { return _roleweight; }
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
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
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
        #endregion Model

    }
}

