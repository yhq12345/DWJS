using System;
namespace Eastcom.Model
{
    /// <summary>
    /// 系统表--字典库表
    /// </summary>
    [Serializable]
    public partial class Sys_Common_Dic
    {
        public Sys_Common_Dic()
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
        private int? _sort;
        /// <summary>
        /// 
        /// </summary>
        public int DicID
        {
            set { _dicid = value; }
            get { return _dicid; }
        }
        /// <summary>
        /// 子FK-父ID
        /// </summary>
        public int ParentID
        {
            set { _parentid = value; }
            get { return _parentid; }
        }
        /// <summary>
        /// 字典名称
        /// </summary>
        public string DicName
        {
            set { _dicname = value; }
            get { return _dicname; }
        }
        /// <summary>
        /// 字典值
        /// </summary>
        public string DicValue
        {
            set { _dicvalue = value; }
            get { return _dicvalue; }
        }
        /// <summary>
        /// 是否只读
        /// </summary>
        public int IsReadOnly
        {
            set { _isreadonly = value; }
            get { return _isreadonly; }
        }
        /// <summary>
        /// 是否有派生
        /// </summary>
        public int IsHasChild
        {
            set { _ishaschild = value; }
            get { return _ishaschild; }
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
        /// 外键--修改人名称[Sys_User_Info].[userID]
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
        /// 外键--创建人ID[Sys_User_Info].[userid]
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
        /// 
        /// </summary>
        public int? Sort
        {
            set { _sort = value; }
            get { return _sort; }
        }
        #endregion Model

    }
}

