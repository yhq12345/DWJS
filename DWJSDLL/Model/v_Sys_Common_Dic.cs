using System;
namespace Eastcom.Model
{
    /// <summary>
    /// v_Sys_Common_Dic:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class v_Sys_Common_Dic
    {
        public v_Sys_Common_Dic()
        { }
        #region Model
        private int _dicid;
        private int _parentid;
        private string _dicname;
        private string _dicvalue;
        private int _isreadonly;
        private int _ishaschild;
        private string _remark;
        private int? _fk_editid;
        private DateTime? _edittime;
        private int? _fk_createid;
        private DateTime? _createtime;
        private int _sort;
        private string _父权限名;
        private string _创建者名;
        private string _修改者名;
        /// <summary>
        /// 
        /// </summary>
        public int DicID
        {
            set { _dicid = value; }
            get { return _dicid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DicName
        {
            set { _dicname = value; }
            get { return _dicname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DicValue
        {
            set { _dicvalue = value; }
            get { return _dicvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsReadOnly
        {
            set { _isreadonly = value; }
            get { return _isreadonly; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IsHasChild
        {
            set { _ishaschild = value; }
            get { return _ishaschild; }
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
        public int Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string 父权限名
        {
            set { _父权限名 = value; }
            get { return _父权限名; }
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

